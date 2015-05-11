﻿using System;
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
            mag1 = Math.Sqrt(mag1);
            mag2 = Math.Sqrt(mag2);
            return suma / (mag1 * mag2);
        }

        void Recomendador.realizaAnalisis()
        {
            /// TODO: encontrar Usuarios Similares.
            coldStart.realizaAnalisis();
            tiempo++;
            uVector = db.usuariosVector();
            usuarios = uVector.Keys.ToArray();
            similitud = new double[usuarios.Length, usuarios.Length];
            for (int i = 0; i < usuarios.Length; i++)
            {
                for (int j = 0; j < usuarios.Length; j++)
                {
                    similitud[i, j] = sim(uVector[usuarios[i]], uVector[usuarios[j]]);
                }
            }
            db.guardaSimilitudes(usuarios, similitud);
        }
        private int sinRecomendacion(int usuario)
        {
            return coldStart.recomendacion(usuario);
        }
        private Dictionary<int, double> rankingProblema(List<CorrelacionUsuario> similares)
        {
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
                if (count >= 3) // obtiene al menos 3 rankings diferentes
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
            db.registraRecomendacion(idCompetidor, idRec, tiempo);
            return idRec;
        }
    }
}
