using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class PriotiryQueue<T> where T : IComparable
    {
        bool mayor;
        int tamanioMaximo;
        int n;
        T[] monti;
        public PriotiryQueue(int maximo = 100, bool invertida= false)
        {
            mayor = !invertida;
            tamanioMaximo = maximo;
            n = 0;
            monti = new T[tamanioMaximo + 1];
        }
        public void push(T elemento)
        {
            n++;
            int p = n;
            int padre = p/2;
            bool puedeSubir;
            if (p > 1)
            {
                puedeSubir =  (monti[padre].CompareTo(elemento) < 0 && mayor) ||
                              (monti[padre].CompareTo(elemento) > 0 && !mayor);
            }
            else
            {
                puedeSubir = false;
            }  
            while (p > 1 && puedeSubir)
            {
                monti[p] = monti[padre];
                p = padre;
                padre = p / 2;
                puedeSubir = p > 1 && ((monti[padre].CompareTo(elemento) < 0 && mayor) ||
                              (monti[padre].CompareTo(elemento) > 0 && !mayor));
            }
            monti[p] = elemento;
        }
        public T top()
        {
            return monti[1];
        }
        private int mejorHijo(int h1,int h2)
        {
            int hp;
            if (h2 > n)
            {
                hp = h1;
            }
            else
            {
                if (mayor)
                {
                    if (monti[h1].CompareTo(monti[h2]) < 0)
                    {
                        hp = h2;
                    }
                    else
                    {
                        hp = h1;
                    }
                }
                else
                {
                    if (monti[h1].CompareTo(monti[h2]) < 0)
                    {
                        hp = h1;
                    }
                    else
                    {
                        hp = h2;
                    }
                }

            }
            return hp;
        }
        bool debeSubir(int hijo, int padre)
        {
            if (hijo > n) return false;
            if (mayor)
            {
                return monti[padre].CompareTo(monti[hijo]) < 0;
            }else{
                return monti[hijo].CompareTo(monti[padre]) < 0;
            }
        }
        public T pop()
        {
            T result = monti[1];
            int p = 1;
            monti[1] = monti[n];
            n--;
            int h1, h2, hp;
            h1 = p * 2;
            h2 = h1 + 1;
            hp = mejorHijo(h1, h2);
            while (hp <= n && debeSubir(hp, p))
            {
                T aux;
                aux = monti[p];
                monti[p] = monti[hp];
                monti[hp] = aux;
                p = hp;
                h1 = p * 2;
                h2 = h1 + 1;
                hp = mejorHijo(h1, h2);
            }
            return result;
        }
        public bool empty
        {
            get{
                return n <= 0;
            }
        }
        public int count
        {
            get
            {
                return n;
            }
        }
    }
}
