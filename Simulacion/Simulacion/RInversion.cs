using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class RInversion : Recomendador
    {
        Recomendador coldStart;
        InversionDB db;
        int nTopUsuarios = 5;
        int tiempo = 0;
        int fueraPor = 10;
        int[] usuarios;
        int[,] inversiones;
        int[,] iguales;
        int[,] complemento;
        double[,] score;
        
        Dictionary<int, List<int>> historias;
        Dictionary<int, List<int>> historiasOrdenadas;
        Dictionary<int, Dictionary<int, bool>> usuarioResolvioP;
        public RInversion(Recomendador rEnColdStart=null)
        {
            db = InversionDB.Instance;
            coldStart = rEnColdStart;
        }
        private int nIguales;
        private int nComplemento;
        private int nInversiones;
        private List<int> ordena(List<int> a)
        {
            if (a.Count <= 1)
            {
                return a;
            }
            List<int> izq = new List<int>();
            List<int> der = new List<int>();
            int n = a.Count;
            int mitad = n / 2;
            var iterador = a.GetEnumerator();
            for (int i = 0; i < mitad; i++)
            {
                iterador.MoveNext();
                izq.Add(iterador.Current);
            }
            while (iterador.MoveNext())
            {
                der.Add(iterador.Current);
            }
            izq = ordena(izq);
            der = ordena(der);
            a = new List<int>();
            var eIzq = izq.GetEnumerator();
            var eDer = der.GetEnumerator();
            eIzq.MoveNext();
            int pIzq = 0;
            eDer.MoveNext();
            int pDer = 0;
            while (pIzq < izq.Count && pDer < der.Count)
            {
                if (eIzq.Current < eDer.Current)
                {
                    a.Add(eIzq.Current);
                    eIzq.MoveNext();
                    pIzq++;
                }
                else
                {
                    a.Add(eDer.Current);
                    eDer.MoveNext();
                    pDer++;
                    nInversiones+= izq.Count-pIzq;
                }
            }
            while (pIzq < izq.Count)
            {
                a.Add(eIzq.Current);
                eIzq.MoveNext();
                pIzq++;
            }
            while (pDer < der.Count)
            {
                a.Add(eDer.Current);
                eDer.MoveNext();
                pDer++;
            }
            return a;
        }
        private int cuentaInversiones(List<int> a, List<int> b)
        {
            int total = 0;
            nIguales = 0;
            Dictionary<int, int> orden = new Dictionary<int, int>();
            int p = 0;
            foreach (var elem in a)
            {
                orden[elem] = p;
                p++;
            }
            List<int> reorden = new List<int>();
            foreach (var elem in b)
            {
                if (orden.ContainsKey(elem))
                {
                    nIguales++;
                    reorden.Add(orden[elem]);
                }
            }
            nInversiones = 0;
            ordena(reorden);
            total = nInversiones;
            nComplemento = b.Count - nIguales;
            return total;
        }
        void Recomendador.iniciaRecomendador()
        {
            db.limpiaExpertoRecomendacion();
            db.limpiaInversion();
            coldStart.iniciaRecomendador();
        }
        void Recomendador.realizaAnalisis()
        {
            coldStart.realizaAnalisis();
            tiempo++;
            historias = db.historiasUsuarios();
            historiasOrdenadas = new Dictionary<int, List<int>>();
            usuarioResolvioP = new Dictionary<int, Dictionary<int, bool>>();
            foreach (var historia in historias)
            {
                historiasOrdenadas[historia.Key] = new List<int>(historia.Value);
                historiasOrdenadas[historia.Key].Sort();
                usuarioResolvioP[historia.Key] = new Dictionary<int, bool>();
                foreach (var problema in historia.Value)
                {
                    usuarioResolvioP[historia.Key][problema] = true;
                }
            }
            List<int> usuariosId = new List<int>(historias.Keys);
            usuarios = usuariosId.ToArray();
            inversiones = new int[usuarios.Length, usuarios.Length];
            iguales = new int[usuarios.Length, usuarios.Length];
            complemento = new int[usuarios.Length, usuarios.Length];
            GC.Collect();
            score = new double[usuarios.Length, usuarios.Length];
            for (int i = 0; i < usuarios.Length; i++)
            {
                for (int j = 0; j < usuarios.Length; j++)
                {
                    inversiones[i, j] = cuentaInversiones(historias[usuarios[i]], historias[usuarios[j]]);
                    iguales[i, j] = nIguales;
                    complemento[i, j] = nComplemento;
                    score[i, j] = (126.0 - Math.Sqrt(2.0 * inversiones[i, j])) * iguales[i, j] * complemento[i, j];
                }
            }
            db.guardaAnalisis(usuarios, inversiones, iguales, complemento, score);
            score = null;
            GC.Collect();
        }
        private int sinRecomendacion(int usuario)
        {
            //En caso de no tener recomendacion se va a otro recomendador.
            VariablesCompartidas.Instance.nColdStart++;
            return coldStart.recomendacion(usuario);
        }
        /// <summary>
        /// Este metodo da como resultado la interseccion de dos conjuntos,
        /// es necesario que los dos conjuntos esten ordenados
        /// </summary>
        /// <param name="a">conjunto ordenado</param>
        /// <param name="b">conjunto ordenado</param>
        /// <returns>interseccion conjunto ordenado</returns>
        private List<int> interseccion(List<int> a, List<int> b)
        {
            List<int> result = new List<int>();
            var eA = a.GetEnumerator();
            var eB = b.GetEnumerator();
            eA.MoveNext();
            int pa = 0;
            eB.MoveNext();
            int pb = 0;
            while (pa < a.Count && pb < b.Count)
            {
                if (eA.Current == eB.Current)
                {
                    result.Add(eA.Current);
                    eA.MoveNext();
                    pa++;
                    eB.MoveNext();
                    pb++;
                }
                else if (eA.Current < eB.Current)
                {
                    eA.MoveNext();
                    pa++;
                }
                else
                {
                    eB.MoveNext();
                    pb++;
                }
            }
            return result;
        }
        /// <summary>
        /// Este metodo da como resultado la union de dos conjuntos,
        /// es necesario que los dos conjuntos esten ordenados
        /// </summary>
        /// <param name="a">conjunto ordenado</param>
        /// <param name="b">conjunto ordenado</param>
        /// <returns>union de los dos conjuntos</returns>
        private List<int> union(List<int> a, List<int> b)
        {
            List<int> result = new List<int>();
            var eA = a.GetEnumerator();
            var eB = b.GetEnumerator();
            eA.MoveNext();
            int pa = 0;
            eB.MoveNext();
            int pb = 0;
            while (pa < a.Count && pb < b.Count)
            {
                if (eA.Current == eB.Current)
                {
                    result.Add(eA.Current);
                    eA.MoveNext();
                    pa++;
                    eB.MoveNext();
                    pb++;
                }
                else if (eA.Current < eB.Current)
                {
                    result.Add(eA.Current);
                    eA.MoveNext();
                    pa++;
                }
                else
                {
                    result.Add(eB.Current);
                    eB.MoveNext();
                    pb++;
                }
            }
            while (pa < a.Count)
            {
                result.Add(eA.Current);
                eA.MoveNext();
                pa++;
            }
            while (pb < b.Count)
            {
                result.Add(eB.Current);
                eB.MoveNext();
                pb++;
            }
            return result;
        }
        private List<int> pProblemas(int usuario, List<int> similares)
        {
            List<int> resultado = new List<int>();
            List<int> parcial;
            foreach (var elem in similares)
            {
                //parcial = interseccion(historiasOrdenadas[usuario], historiasOrdenadas[elem]);
                parcial = historiasOrdenadas[elem];
                resultado = union(resultado,parcial);
            }
            return resultado;
        }
        private int masFrecuente(List<int> usuariosSimilares, List<int> problemasCandidatos)
        {
            int idProblema = -1;
            int frecuencia = 0;
            foreach (var problema in problemasCandidatos)
            {
                int cont = 0;
                foreach (var usuario in usuariosSimilares)
                {
                    if (usuarioResolvioP[usuario].ContainsKey(problema) && usuarioResolvioP[usuario][problema])
                    {
                        cont++;
                    }
                }
                if (cont > frecuencia)
                {
                    frecuencia = cont;
                    idProblema = problema;
                }
            }
            return idProblema;
        }
        int Recomendador.recomendacion(int usuario)
        {
            List<int> similares = db.usuariosSimilares(usuario, nTopUsuarios);
            if (similares.Count <= 0)
            {
                // No se encontraron Usuarios Similares
                int rec = sinRecomendacion(usuario);
                db.registraRecomendacion(usuario,rec,tiempo);
                return rec;
            }
            List<int> posiblesProblemas;
            posiblesProblemas = pProblemas(usuario, similares);
            if (posiblesProblemas.Count <= 0)
            {
                // No hay problmeas para Recommendar
                int rec = sinRecomendacion(usuario);
                db.registraRecomendacion(usuario, rec, tiempo);
                return rec;
            }
            List<int> candidatos = db.viables(usuario, tiempo - fueraPor, posiblesProblemas);
            if (candidatos.Count <= 0)
            {
                // No hay problemas que se puedan recommendar
                int rec = sinRecomendacion(usuario);
                db.registraRecomendacion(usuario, rec, tiempo);
                return rec;
            }
            int res = masFrecuente(similares, candidatos);
            db.registraRecomendacion(usuario, res, tiempo);
            return res;
        }
    }
}
