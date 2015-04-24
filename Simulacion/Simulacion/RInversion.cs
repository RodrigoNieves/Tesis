using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class RInversion : Recomendador
    {
        InversionDB db;
        int[] usuarios;
        int[,] inversiones;
        int[,] iguales;
        int[,] complemento;
        Dictionary<int, List<int>> historias;
        public RInversion()
        {
            db = InversionDB.Instance;
        }
        private int nIguales;
        private int nComplemento;
        private int nInversiones;
        private List<int> ordena(List<int> a)
        {
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
            
        }
        void Recomendador.realizaAnalisis()
        {
            historias = db.historiasUsuarios();
            List<int> usuariosId = new List<int>(historias.Keys);
            usuarios = usuariosId.ToArray();
            inversiones = new int[usuarios.Length, usuarios.Length];
            iguales = new int[usuarios.Length, usuarios.Length];
            complemento = new int[usuarios.Length, usuarios.Length];
            for (int i = 0; i < usuarios.Length; i++)
            {
                for (int j = 0; j < usuarios.Length; j++)
                {
                    inversiones[i, j] = cuentaInversiones(historias[usuarios[i]], historias[usuarios[j]]);
                    iguales[i, j] = nIguales;
                    complemento[i, j] = nComplemento;
                }
            }
            db.guardaAnalisis(usuarios, inversiones, iguales, complemento);
        }
        int Recomendador.recomendacion(int usuario)
        {
            return 0;
        }
    }
}
