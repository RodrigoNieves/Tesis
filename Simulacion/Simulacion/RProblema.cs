using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class RProblema: Recomendador
    {
        Recomendador coldStart;
        double[,] sim;
        int[] pId;
        Dictionary<int, int> invPId;
        ProblemDB db;
        int tiempo = 0;
        int fueraPor = 10;
        List<Problema> problemas;
        public RProblema(Recomendador rEnColdStart = null)
        {
            db = ProblemDB.Instance;
            coldStart = rEnColdStart;
        }
        void Recomendador.iniciaRecomendador()
        {
            db.limpiaExpertoRecomendacion();
            db.limpiaProblemaRecomendacion();
            coldStart.iniciaRecomendador();
            problemas = db.problemas();
        }
        private List<int> interseccion(List<int> a, List<int> b)
        {
            a.Sort();
            b.Sort();
            int[] aa = a.ToArray();
            int[] ab = b.ToArray();
            List<int> result = new List<int>();
            int i, j;
            i = 0;
            j = 0;
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
        public double similitud(Dictionary<int, int> p1, Dictionary<int, int> p2)
        {
            List<int> usuarios = interseccion(p1.Keys.ToList<int>(), p2.Keys.ToList<int>());
            if (problemas.Count <= 0) return 0.0;
            double suma = 0.0;
            double mag1 = 0.0;
            double mag2 = 0.0;
            foreach (var idUsuario in usuarios)
            {
                suma += p1[idUsuario] * p2[idUsuario];
                mag1 += p1[idUsuario] * p1[idUsuario];
                mag2 += p2[idUsuario] * p2[idUsuario];
            }
            if (mag1 <= 0.0 || mag2 <= 0.0)
                return 0.0;
            mag1 = Math.Sqrt(mag1);
            mag2 = Math.Sqrt(mag2);
            return suma / (mag1 * mag2);
        }
        void Recomendador.realizaAnalisis()
        {
            coldStart.realizaAnalisis();
            tiempo++;
            pId = new int[problemas.Count];
            invPId = new Dictionary<int, int>();
            sim = new double[problemas.Count, problemas.Count];

            int p = 0;
            var pEnum = problemas.GetEnumerator();
            while (pEnum.MoveNext())
            {
                var problem = pEnum.Current;
                pId[p] = problem.idProblema;
                invPId[problem.idProblema] = p;
                p++;
            }
            var calificaciones = db.calificacionesProblema();
            for (int i = 0; i < pId.Length; i++)
            {
                for (int j = 0; j < pId.Length; j++)
                {
                    sim[i, j] = similitud(calificaciones[pId[i]], calificaciones[pId[j]]);
                }
            }
            db.registraSimilitudes(pId, sim);
        }
        private int sinRecomendacion(int usuario)
        {
            return coldStart.recomendacion(usuario);
        }
        private int encuentraRecomendacion(Dictionary<int, int> problemasIntentados,List<int> problemasFaltantes)
        {
            double[] total = new double[pId.Length];
            double[] peso = new double[pId.Length];
            for (int i = 0; i < pId.Length; i++)
            {
                total[i] = 0.0;
                peso[i] = 0.0;
            }
            foreach (var prob in problemasIntentados)
            {
                int i = invPId[prob.Key];
                double puntuacion = (double)prob.Value;
                for (int j = 0; j < pId.Length; j++)
                {
                    total[j] += puntuacion * sim[i, j];
                    peso[j] += sim[i, j];
                }
            }
            double[] estimado = new double[pId.Length];
            for (int i = 0; i < pId.Length; i++)
            {
                if (peso[i] > 0.0)
                {
                    estimado[i] = total[i] / peso[i];
                }
            }
            // TODO: sacar el mejor de los problemas faltantes
            double mejor = 0.0;
            int id = -1;
            foreach (var candidato in problemasFaltantes)
            {
                int pC = invPId[candidato];
                if (estimado[pC] > mejor)
                {
                    mejor = estimado[pC];
                    id = candidato;
                }
            }
            return id;
        }
        int Recomendador.recomendacion(int idCompetidor)
        {
            Dictionary<int, int> problemasIntentados = db.problemasIntentados(idCompetidor);
            if (problemasIntentados.Keys.Count < 1)//minimo numero de problemas intentados para dar recomendacion
            {
                // No se ha intentado nada
                int rec = sinRecomendacion(idCompetidor);
                db.registraRecomendacion(idCompetidor, rec, tiempo);
                return rec;
            }
            List<int> problemasFaltantes = db.problemasFaltantes(idCompetidor);
            if (problemasFaltantes.Count < 1)
            {
                //ya resolvio todo
                return -1;
            }
            int mejorCandidato = encuentraRecomendacion(problemasIntentados, problemasFaltantes);
            db.registraRecomendacion(idCompetidor, mejorCandidato, tiempo);
            return mejorCandidato;
        }

        
    }
}
