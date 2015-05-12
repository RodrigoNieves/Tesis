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
        ProblemDB db;
        int tiempo = 0;
        int fueraPro = 10;
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
            int[] pId = new int[problemas.Count];
            double[,] sim = new double[problemas.Count, problemas.Count];

            int p = 0;
            var pEnum = problemas.GetEnumerator();
            while (pEnum.MoveNext())
            {
                var problem = pEnum.Current;
                pId[p] = problem.idProblema;
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

        int Recomendador.recomendacion(int idCompetidor)
        {
            throw new NotImplementedException();
        }
    }
}
