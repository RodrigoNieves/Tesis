using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class RUser: Recomendador
    {
        Recomendador coldStart;
        UserDB db;
        int tiempo = 0;
        int fueraPor = 10;
        Dictionary<int, Dictionary<int, int>> uVector;
        List<Problema> problemas;
        Dictionary<int, Problema> dictProblemas;
        int[] usuarios;
        double[,] similitud;
        public RUser(Recomendador rEnColdStart = null)
        {
            db = UserDB.Instance;
            coldStart = rEnColdStart;
        }
        void Recomendador.iniciaRecomendador()
        {
            db.limpiaExpertoRecomendacion();
            db.limpiaUsuarioRecomendacion();
            coldStart.iniciaRecomendador();
            problemas = db.problemas();
            dictProblemas = new Dictionary<int, Problema>();
            foreach (var prob in problemas)
            {
                dictProblemas[prob.idProblema] = prob;
            }
        }
        private List<int> interseccion(List<int> a, List<int> b)
        {
            a.Sort();
            b.Sort();
            int[] aa = a.ToArray();
            int[] ab = b.ToArray();
            List<int> result = new List<int>();
            int i, j;
            i =0;
            j=0;
            while (i < aa.Length && j < ab.Length)
            {
                if (aa[i] == ab[j])
                {
                    result.Add(aa[i]);
                    i++;
                    j++;
                }
                else if (aa[i] < ab[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return result;
        }
        /// <summary>
        /// Similitud por coseno, sin ajustar
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public double sim(Dictionary<int, int> u1, Dictionary<int, int> u2)
        {
            List<int> problemas = interseccion(u1.Keys.ToList(), u2.Keys.ToList());
            if (problemas.Count <= 0) return 0.0;
            double suma = 0.0;
            double mag1 = 0.0;
            double mag2 = 0.0;
            foreach (var id in problemas)
            {
                suma += u1[id] * u2[id];
                mag1 += u1[id] * u1[id];
                mag2 += u2[id] * u2[id];
            }
            if (mag1 <= 0.0 || mag2 <= 0.0)
                return 0.0;
            mag1 = Math.Sqrt(mag1);
            mag2 = Math.Sqrt(mag2);
            return suma / (mag1 * mag2);
        }
        public double simCategorizado(Dictionary<int, int> u1, Dictionary<int, int> u2)
        {
            double sim = 0.0;
            Dictionary<int, double> sumaCategoria = new Dictionary<int, double>();
            Dictionary<int, double> mag1Categoria = new Dictionary<int, double>();
            Dictionary<int, double> mag2Categoria = new Dictionary<int, double>();
            List<int> problemas = interseccion(u1.Keys.ToList(), u2.Keys.ToList());
            if (problemas.Count <= 0) return 0.0;
            foreach (var id in problemas)
            {
                int tema = dictProblemas[id].idTema;
                if (!sumaCategoria.ContainsKey(id))
                {
                    sumaCategoria[tema] = 0.0;
                    mag1Categoria[tema] = 0.0;
                    mag2Categoria[tema] = 0.0;
                }
                sumaCategoria[tema] += u1[id] * u2[id];
                mag1Categoria[tema] += u1[id] * u1[id];
                mag2Categoria[tema] += u2[id] * u2[id];
            }
            double total = 0.0;
            foreach (var suma in sumaCategoria)
            {
                int tema = suma.Key;
                if (mag1Categoria[tema] != 0.0 || mag2Categoria[tema] != 0.0)
                {
                    total += sumaCategoria[tema] / (Math.Sqrt(mag1Categoria[tema]) * Math.Sqrt(mag2Categoria[tema]));
                }
            }
            sim = (total + ProblemaTema.Instance.nTemas()-sumaCategoria.Keys.Count)/ ProblemaTema.Instance.nTemas(); 

            return sim;
        }
        public double sim2(int idU1, int idU2)
        {
            if(VariablesCompartidas.Instance.usuarios == null) return 0.0;
            Usuario u1= null;
            if (VariablesCompartidas.Instance.usuarios.ContainsKey(idU1))
            {
                u1 = VariablesCompartidas.Instance.usuarios[idU1];
            }
            Usuario u2 = null;
            if (VariablesCompartidas.Instance.usuarios.ContainsKey(idU2))
            {
                u2 = VariablesCompartidas.Instance.usuarios[idU2];
            }
            
            double similitudHabilidades = 0.0;
            if (u1 != null)
            {
                foreach (var habilidad in u1.habilidades)
                {
                    if (u2 != null)
                    {
                        similitudHabilidades += Math.Abs(habilidad.Value - u2.habilidadEn(habilidad.Key)) / 7.0;
                    }
                    else
                    {
                        similitudHabilidades += Math.Abs(habilidad.Value + 1) / 7.0;
                    }
                }
                similitudHabilidades /= u1.habilidades.Count;
                similitudHabilidades = 1.0 - similitudHabilidades;
            }
            double similitudProblemas= 0.0;
            if (uVector.ContainsKey(idU1) && uVector.ContainsKey(idU2))
            {
                similitudProblemas = simCategorizado(uVector[idU1], uVector[idU2]);
            }
            double similitudMotivacion = 0.0;
            if(u1 != null && u2 != null){
                similitudMotivacion = 1.0 - (Math.Abs(u1.motivacion - u2.motivacion) / VariablesCompartidas.Instance.maximaMotivacion);
            }
             
            double similitud = (0.5) * similitudHabilidades + (0.5) * similitudProblemas + (0.0) * similitudMotivacion;
            return similitud;
        }
        void Recomendador.realizaAnalisis()
        {
            /// TODO: encontrar Usuarios Similares.
            /// TODO: solo calcular similitudes necesarias, no toda la matriz
            coldStart.realizaAnalisis();
            tiempo++;
            uVector = db.usuariosVector();
            usuarios = uVector.Keys.ToArray();
            similitud = new double[usuarios.Length, usuarios.Length];
            for (int i = 0; i < usuarios.Length; i++)
            {
                for (int j = 0; j < usuarios.Length; j++)
                {
                    //similitud[i, j] = sim(uVector[usuarios[i]], uVector[usuarios[j]]);
                    similitud[i, j] = sim2(usuarios[i], usuarios[j]);
                }
            }
            db.guardaSimilitudes(usuarios, similitud);
            similitud = null;
            GC.Collect(); // para que se limpie memoria
        }
        private int sinRecomendacion(int usuario)
        {
            VariablesCompartidas.Instance.nColdStart++;
            return coldStart.recomendacion(usuario);
        }
        private Dictionary<int, double> rankingProblema(List<CorrelacionUsuario> similares)
        {
            int minUsuarios = 1;
            Dictionary<int, double> result = new Dictionary<int, double>();
            foreach (var prob in problemas)
            {
                int idProb = prob.idProblema;
                double total = 0.0;
                int count = 0;
                double totalweight = 0.0;
                foreach (var usuario in similares)
                {
                    int u2 = usuario.u2;
                    if (uVector[u2].ContainsKey(idProb))
                    {
                        double rank = uVector[u2][idProb];
                        double corr = usuario.correlacion;
                        // 
                        total += rank * corr;
                        totalweight += corr;
                        count++;
                    }
                }
                if (count >= minUsuarios) // obtiene al menos 3 rankings diferentes
                {
                    result[idProb] = total / totalweight; 
                }
            }
            return result;
        }
        int Recomendador.recomendacion(int idCompetidor)
        {
            List<CorrelacionUsuario> similares = db.obtenSimilares(idCompetidor);
            var recomedados = rankingProblema(similares);
            if (recomedados.Keys.Count < 1)
            {
                // no hay problemas recomendados
                int rec = sinRecomendacion(idCompetidor);
                db.registraRecomendacion(idCompetidor, rec, tiempo);
                return rec;
            }
            var viables = db.viables(idCompetidor, tiempo - fueraPor, recomedados.Keys.ToList<int>());
            if (viables.Count < 1)
            {
                int rec = sinRecomendacion(idCompetidor);
                db.registraRecomendacion(idCompetidor, rec, tiempo);
                return rec;
            }
            double ranking = -1000.0;
            int idRec = -1;
            foreach (var viable in viables)
            {
                if (ranking < recomedados[viable])
                {
                    ranking = recomedados[viable];
                    idRec = viable;
                }
            }
            if (idRec == -1)
            {
                // No se pudo generar recomendacion
                idRec = sinRecomendacion(idCompetidor);
            }
            db.registraRecomendacion(idCompetidor, idRec, tiempo);
            return idRec;
        }
    }
}
