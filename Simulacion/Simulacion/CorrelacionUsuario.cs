using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class CorrelacionUsuario:IComparable
    {
        public int u1;
        public int u2;
        public double correlacion;
        public int CompareTo(object obj)
        {
            CorrelacionUsuario b = (CorrelacionUsuario)obj;
            if (correlacion < b.correlacion)
            {
                return -1;
            }
            else if (correlacion == b.correlacion)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
