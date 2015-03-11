using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class RRandom : Recomendador
    {
        int[] problemas;
        Random rnd;
        public RRandom(int[] posiblesValores)
        {
            problemas = posiblesValores;
        }

        void Recomendador.iniciaRecomendador()
        {
            //Semilla para hacer siempre la misma prueba
            rnd = new Random(123456);
        }
        void Recomendador.realizaAnalisis()
        {

        }
        int Recomendador.recomendacion(int idCompetidor)
        {
            return problemas[rnd.Next(problemas.Length)];
        }
    }
}
