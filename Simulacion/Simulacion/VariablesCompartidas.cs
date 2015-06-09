using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class VariablesCompartidas
    {
        public int nColdStart;
        private static VariablesCompartidas instance;
        private VariablesCompartidas()
        {

        }
        public static VariablesCompartidas Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VariablesCompartidas();
                }
                return instance;
            }
        }
    }
}
