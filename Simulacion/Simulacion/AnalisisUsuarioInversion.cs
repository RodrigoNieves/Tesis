using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class AnalisisUsuarioInversion: IComparable
    {
        public int u1;
        public int u2;
        public int inversiones;
        public int iguales;
        public int complemento;
        public double score;

        int IComparable.CompareTo(Object o)
        {
            AnalisisUsuarioInversion other = (AnalisisUsuarioInversion)o;
            if (score < other.score)
            {
                return -1;
            }
            else if (score == other.score)
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
