using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class RSVD: Recomendador
    {
        int nFeatures = 16;
        double lrate = 0.01;
        int nIterations = 10;
        double[,] predictions;
        double[,] userFeatrure;
        double[,] problemFeature;
        Dictionary<int, Dictionary<int, int>> uVector;
        double squareSum;
        int nPuntos;

        int nUsuarios;
        int[] usuarios;
        int nProblemas;
        int[] problemas;
        int tiempo;
        Dictionary<int, int> pUser;
        Dictionary<int, int> pProblem;

        SVDDB db;
        double rmse
        {
            get
            {
                return Math.Sqrt(squareSum / nPuntos);
            }
        }
        void Recomendador.iniciaRecomendador()
        {
            tiempo = 0;
            db = SVDDB.Instance;
            db.limpiaExpertoRecomendacion();
            db.limpiaSVDRecomendacion();
        }
        private void InicializaSVD()
        {
            db.limpiaSVDRecomendacion();
            var users = db.usuarios();
            nUsuarios = users.Count;
            usuarios = new int[nUsuarios];
            pUser = new Dictionary<int, int>();
            int pos = 0;
            foreach (var u in users)
            {
                usuarios[pos] = u;
                pUser[u] = pos;
                pos++;
            }
            var problems = db.problemas();
            nProblemas = problems.Count;
            problemas = new int[nProblemas];
            pProblem = new Dictionary<int, int>();
            pos = 0;
            foreach (var problem in problems)
            {
                problemas[pos] = problem.idProblema;
                pProblem[problem.idProblema] = pos;
                pos++;
            }
            
            uVector = db.
            // uvector = db.ObtenPuntos de Usuarios;
            predictions = new double[nUsuarios, nProblemas];
            userFeatrure = new double[nUsuarios, nFeatures];
            problemFeature = new double[nProblemas, nFeatures];
            for (int i = 0; i < nFeatures; i++)
            {
                for (int p = 0; p < nProblemas; p++)
                {
                    problemFeature[p, i] = 7.0710678; //Inicializa con la raiz de 50
                }
                for (int u = 0; u < nUsuarios; u++)
                {
                    userFeatrure[u, i] = 7.0710678;
                }
            }
            for (int u = 0; u < nUsuarios; u++)
            {
                for (int p = 0; p < nProblemas; p++)
                {
                    predictions[u, p] = 0.0;
                    for (int i = 0; i < nFeatures; i++)
                    {
                        predictions[u, p] += userFeatrure[u, i] * problemFeature[p, i];
                    }
                }
            }
            squareSum = 0.0;
            nPuntos = 0;
            foreach (var u in uVector)
            {
                foreach (var p in u.Value)
                {
                    nPuntos++;
                    double err = p.Value - predictions[pUser[u.Key], pProblem[p.Key]];
                    squareSum += err;
                }
            }
        }
        void Recomendador.realizaAnalisis()
        {
            tiempo++;

            InicializaSVD();
            

            
        }

        int Recomendador.recomendacion(int idCompetidor)
        {
            throw new NotImplementedException();
        }
    }
}
