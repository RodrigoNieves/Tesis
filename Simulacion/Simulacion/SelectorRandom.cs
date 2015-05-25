using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class SelectorRandom
    {
        Dictionary<int, int> posicion;
        Dictionary<int, int> cantidad;
        Random rnd;
        int[] ids;
        int n;
        int total;
        public SelectorRandom(int nElem)
        {
            rnd = new Random(12492); // semilla establecida para repetir 
            ids = new int[nElem];
            n = 0;
            total = 0;
            posicion = new Dictionary<int, int>();
            cantidad = new Dictionary<int, int>();
        }
        public void agrega(int id, int cuantos)
        {
            if (cuantos > 0)
            {
                ids[n] = id;
                cantidad[id] = cuantos;
                posicion[id] = n;
                n++;
                total += cuantos;
            }
        }
        public int saca()
        {
            int pos = rnd.Next(n);
            int result = ids[pos];
            cantidad[result]--;
            if (cantidad[result] <= 0)
            {
                ids[pos] = ids[n - 1];
                posicion[ids[pos]] = pos;
                n--;
            }
            total--;
            return result;
        }
        public int cuantosDiferentes()
        {
            return n;
        }
        public bool empty()
        {
            return cuantosDiferentes() == 0;
        }
        public int cuantosRestantes()
        {
            return total;
        }
        public void quita(int id)
        {
            if(!posicion.ContainsKey(id)){ return;}
            if (cantidad[id] == 0) return;
            n--;
            total -= cantidad[id];
        }
    }
}
