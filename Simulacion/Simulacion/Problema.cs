using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class Problema
    {
        int _idProblema;
        string _nombre;
        int _idTema;
        int _dificultad;
        public int idProblema
        {
            get 
            { 
                return _idProblema;  
            }
            set
            {
                _idProblema = value;
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
        public int idTema
        {
            get
            {
                return _idTema;
            }
            set
            {
                _idTema = value;
            }
        }
        public int dificultad
        {
            get
            {
                return _dificultad;
            }
            set
            {
                _dificultad = value;
            }
        }
        public string nombreTema
        {
            get
            {
                return ProblemaTema.Instance.getNombreTema(_idTema);
            }
        }
        public string descripcionTema
        {
            get
            {
                return ProblemaTema.Instance.getDescripcion(_idTema);
            }
        }
        public string nombreDificultad
        {
            get
            {
                return ProblemaDificultad.Instance.getNombreDificultad(_dificultad);
            }
        }
        public string descripcionDificultad
        {
            get
            {
                return ProblemaDificultad.Instance.getDescripcion(_dificultad);
            }
        }
    }
}
