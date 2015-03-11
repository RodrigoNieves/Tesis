using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    interface Recomendador
    {
        void iniciaRecomendador();
        void realizaAnalisis();
        int recomendacion(int idCompetidor);
    }
}
