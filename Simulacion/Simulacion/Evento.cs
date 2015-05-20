using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class Evento
    {
        int _id;
        string _nombre;
        string _descripcion;
        public Evento(int id, string nombre, string descripcion)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
        }
        public int idEvento
        {
            get
            {
                return _id;
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
