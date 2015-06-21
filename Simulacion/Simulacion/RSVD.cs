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
        double lrate = 0.001;
        int nIterations = 20;
        int minimoCalificaciones = 10;
        double difConvergencia = 0.01;
        bool limitaPrediccion = true;
        double[,] userFeatrure;
        double[,] problemFeature;
        Dictionary<int, Dictionary<int, int>> uVector;
        double squareSum;
        int nPuntos;

        int nUsuarios;
        int[] usuarios;
        int nProblemas;
        int[] problemas;
        int tiempo = 0;
        int fueraPor = 10;
        Dictionary<int, int> pUser;
        Dictionary<int, int> pProblem;

        Recomendador coldStart;

        SVDDB db;
        double rmse
        {
            get
            {
                return Math.Sqrt(squareSum / nPuntos);
            }
        }
        public RSVD(Recomendador rEnColdStart = null)
        {
            db = SVDDB.Instance;
            coldStart = rEnColdStart;
        }
        void Recomendador.iniciaRecomendador()
        {
            tiempo = 0;
            db.limpiaExpertoRecomendacion();
            db.limpiaSVDRecomendacion();
            coldStart.iniciaRecomendador();
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

            uVector = db.calificacionesUsuarios();

            userFeatrure = new double[nUsuarios, nFeatures];
            problemFeature = new double[nProblemas, nFeatures];
            double inicio = Math.Sqrt(50.0 / nFeatures);
            for (int i = 0; i < nFeatures; i++)
            {
                for (int p = 0; p < nProblemas; p++)
                {
                    problemFeature[p, i] = inicio; //Inicializa con la raiz de 50
                }
                for (int u = 0; u < nUsuarios; u++)
                {
                    userFeatrure[u, i] = inicio;
                }
            }
           
            actualizaRMSE();
        }
        public void actualizaRMSE()
        {
            squareSum = 0.0;
            nPuntos = 0;
            foreach (var u in uVector)
            {
                foreach (var p in u.Value)
                {
                    int us = pUser[u.Key];
                    int pr = pProblem[p.Key];
                    double prediction = predict(us, pr);
                    nPuntos++;
                    double err = p.Value - prediction;
                    squareSum += err*err;
                }
            }
        }
        private double predict(int u, int p)
        {
            double prediction = 0.0;
            for (int i = 0; i < nFeatures; i++)
            {
                prediction += userFeatrure[u, i] * problemFeature[p, i];
            }
            if (limitaPrediccion)
            {
                if (prediction < 0.0)
                {
                    prediction = 0.0;
                }
                if (prediction > 100.0)
                {
                    prediction = 100.0;
                }
            }
            return prediction;
        }
        private void train(int f, int u, int p, int puntos)
        {
            double err = lrate * (puntos - predict(u, p));

            double uv = userFeatrure[u, f];
            userFeatrure[u, f] += err * problemFeature[p, f];
            problemFeature[p, f] += err * uv;
        }
        void Recomendador.realizaAnalisis()
        {
            tiempo++;
            coldStart.realizaAnalisis();
            
            InicializaSVD();

            for (int f = 0; f < nFeatures; f++)
            {
                double antRMSE = 0.0;
                for (int iterarion = 0; iterarion < nIterations && Math.Abs(rmse - antRMSE) >= difConvergencia; iterarion++)
                {
                    foreach (var u in uVector)
                    {
                        foreach (var p in u.Value)
                        {
                            train(f, pUser[u.Key], pProblem[p.Key], p.Value);
                        }
                    }
                    antRMSE = rmse;
                    actualizaRMSE();
                    //Registra RMSE

                    
                    EventoManager.Instance.registraEvento("RMSE-SVD", rmse.ToString());
                }
            }
            //gurada los features
            db.guardaUserF(nFeatures, usuarios, userFeatrure);
            db.guardaProblemF(nFeatures, problemas, problemFeature);
        }

        private int sinRecomendacion(int usuario)
        {
            VariablesCompartidas.Instance.nColdStart++;
            return coldStart.recomendacion(usuario);
        }

        int Recomendador.recomendacion(int idCompetidor)
        {
            int totalIntentados = db.intentados(idCompetidor);
            if (totalIntentados < minimoCalificaciones)
            {
                //muy pocos atributos no es confiable SVD
                int rec = sinRecomendacion(idCompetidor);
                db.registraRecomendacion(idCompetidor, rec, tiempo);
                return rec;
            }
            List<int> problemasPosibles = db.problemasPosibles(idCompetidor, tiempo - fueraPor);
            if (problemasPosibles.Count <= 0)
            {
                //NO es posible recomendar
                return -1;
            }
            int idProblema = -1;
            double maximo = -100000.0;
            foreach (var candidato in problemasPosibles)
            {
                double pred = predict(pUser[idCompetidor], pProblem[candidato]);
                if (pred > maximo)
                {
                    maximo = pred;
                    idProblema = candidato;
                }
            }
            db.registraRecomendacion(idCompetidor, idProblema, tiempo);
            return idProblema;
        }
    }
}
