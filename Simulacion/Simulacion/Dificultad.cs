using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class Dificultad
    {
        int _idDificultad;
        string _nombre;
        string _descripcion;
        public int idDificultad
        {
            get
            {
                return _idDificultad;
            }
            set
            {
                _idDificultad = value;
            }
        }
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public string descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }
    }
}
