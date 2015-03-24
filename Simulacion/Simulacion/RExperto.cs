using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class RExperto : Recomendador
    {
        int tiempo = 0;
        int fueraPor = 10;
        ExpertoDB db;
        public RExperto()
        {
            db = ExpertoDB.Instance;
        }
        void Recomendador.iniciaRecomendador()
        {
            db.limpiaTablas();
        }
        void Recomendador.realizaAnalisis()
        {
            tiempo++;
        }
        int Recomendador.recomendacion(int idCompetidor)
        {
            int rec = db.recommendacionUsuario(idCompetidor, tiempo-fueraPor);
            db.registraRecomendacion(idCompetidor, rec, tiempo);
            return rec;
        }
    }
}
