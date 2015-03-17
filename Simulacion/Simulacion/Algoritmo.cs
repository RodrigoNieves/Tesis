using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class Algoritmo
    {
        int _idAlgoritmo = -1;
        string _nombre;
        string _descripcion;
        public Algoritmo(int id, string nombre, string descripcion)
        {
            _idAlgoritmo = id;
            _nombre = nombre;
            _descripcion = descripcion;
        }
        public int id
        {
            get
            {
                return _idAlgoritmo;
            }
        }
        public string nombre
        {
            get
            {
                return _nombre;
            }
        }
        public string descripcion
        {
            get
            {
                return _descripcion;
            }
        }
    }
}
