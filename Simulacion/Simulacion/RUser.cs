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
        Dictionary<int, Dictionary<int, int>> uVector;
        int[] usuarios;
        double[,] similitud;
        public RUser(Recomendador rEnColdStart = null)
        {
            db = UserDB.Instance;
            coldStart = rEnColdStart;
        }
        void Recomendador.iniciaRecomendador()
        {
            db.limpiaTablas();
            coldStart.iniciaRecomendador();
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
        /// Similitud por correlacion de pearson
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public double sim(Dictionary<int, int> u1, Dictionary<int, int> u2)
        {
            List<int> problemas = interseccion(u1.Keys.ToList(), u2.Keys.ToList());
            if (problemas.Count <= 0) return 0.0;

        }

        void Recomendador.realizaAnalisis()
        {
            /// TODO: encontrar Usuarios Similares.
            uVector = db.usuariosVector();
            usuarios = uVector.Keys.ToArray();
            for (int i = 0; i < usuarios.Length; i++)
            {
                for (int j = 0; j < usuarios.Length; j++)
                {
                    similitud[i, j] = sim(uVector[usuarios[i]], uVector[usuarios[j]]);
                }
            }

        }
        private int sinRecomendacion(int usuario)
        {
            return coldStart.recomendacion(usuario);
        }
        int Recomendador.recomendacion(int idCompetidor)
        {
            throw new NotImplementedException();
        }
    }
}
