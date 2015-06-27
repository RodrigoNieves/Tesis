using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class Usuario
    {
        Dictionary<int, int> _habilidades;
        public Dictionary<int, int> habilidades
        {
            get
            {
                return _habilidades;
            }
        }
        double _motivacion;
        double _aPositiva;
        double _aNegativa;
        double _fFacilida;
        double _sinRecomendacion;
        double incremento;
        int _resueltos;
        int _fallos;
        bool _ficticio;
        bool _terminado = false;

        bool _acaboProblemas = false;
        public bool acaboProblemas
        {
            get
            {
                return _acaboProblemas;
            }
        }
        bool _rendido = false;
        public bool rendido
        {
            get
            {
                return _rendido;
            }
        }
        int _idUsuario;
        int _idUsuarioSimulacion;
        public double motivacion
        {
            get
            {
                return _motivacion;
            }
        }
        public bool ficticio
        {
            get
            {
                return _ficticio;
            }
        }
        public Usuario(int idSimulacion, double motivacionInicial, double aPositiva, double aNegativa, double fFacilidad,double sinRecomendacion)
        {
            _ficticio = true;
            _motivacion = motivacionInicial;
            _aPositiva = aPositiva;
            _aNegativa = aNegativa;
            _fFacilida = fFacilidad;
            _sinRecomendacion = sinRecomendacion;
            _resueltos = 0;
            _fallos = 0;
            // TODO: Obtener ID de nuevo usuario creado
            SimulacionDB simulacion = new SimulacionDB();
            _idUsuario = simulacion.creaUsuarioFicticion();
            _idUsuarioSimulacion = simulacion.creaUsuarioSimulacion(_idUsuario,
                idSimulacion,
                motivacionInicial,
                aPositiva,
                aNegativa,
                fFacilidad,
                sinRecomendacion);
            if (VariablesCompartidas.Instance.maximaMotivacion < _motivacion)
            {
                VariablesCompartidas.Instance.maximaMotivacion = _motivacion;
            }
        }
        public Usuario(Dictionary<int, int> nivel)
        {
            _ficticio = false;
            _motivacion = 2.0;
            _habilidades = nivel;
            if (VariablesCompartidas.Instance.maximaMotivacion < _motivacion)
            {
                VariablesCompartidas.Instance.maximaMotivacion = _motivacion;
            }
        }
        public List<Tema> temas
        {
            set
            {
                _habilidades = new Dictionary<int, int>();
                foreach (var tema in value)
                {
                    _habilidades[tema.idTema] = 0; // cero siempre es sin conocer
                }
            }
        }
        public int idUsuario
        {
            get
            {
                return _idUsuario;
            }
        }
        public int idUsuarioSimulacion
        {
            get
            {
                return _idUsuarioSimulacion;
            }
        }
        public int habilidadEn(int idTema)
        {
            return _habilidades[idTema];
        }
        public int habilidadEn(Tema tema)
        {
            return habilidadEn(tema.idTema);
        }
        public void resolvio(Problema problema)
        {
            int difNivel = problema.dificultad - _habilidades[problema.idTema];
            if (difNivel > 0)
            {
                incremento += _aPositiva * Math.Exp(-1 * _aPositiva * _resueltos);
            }
            else
            {
                incremento += _aPositiva * Math.Exp(-1 * _aPositiva * _resueltos) * Math.Exp(difNivel * _fFacilida);
            }
            _resueltos++;
        }
        public void fallo(Problema problema)
        {
            incremento -= _aNegativa * Math.Exp(-1 * _aNegativa * _fallos);
            _fallos++; 
        }
        public void sinRecomendacion()
        {
            incremento -= _sinRecomendacion;
        }
        public void tickTiempo()
        {
            if (!_terminado)
            {
                _motivacion += incremento;
                incremento = 0.0;
                _resueltos = 0;
                _fallos = 0;
            }
            if (VariablesCompartidas.Instance.maximaMotivacion < _motivacion)
            {
                VariablesCompartidas.Instance.maximaMotivacion = _motivacion;
            }
            if ((!_terminado) && _motivacion < 1.0)
            {
                _rendido = true;
                _terminado = true;
                // El usuario ha abandonado
                var llaves = new List<int>(_habilidades.Keys);
                foreach (var idHabilidad in llaves)
                {
                    _habilidades[idHabilidad] = -1;
                }
            }
        }
        public void subeNivel(int idTema)
        {
            _habilidades[idTema]++;
        }
        public void subeNivel(Tema tema)
        {
            subeNivel(tema.idTema);
        }
        public bool resolvioTodo()
        {
            SimulacionDB simulacion = new SimulacionDB();
            bool _resolvioTodo = simulacion.resolvioTodo(_idUsuario);
            if (!_terminado && _resolvioTodo)
            {
                //el usuario ha terminado todo
                _acaboProblemas = true;
                _motivacion = 0.0;
                _terminado = true;
                var llaves = new List<int>(_habilidades.Keys);
                foreach (var idHabilidad in llaves)
                {
                    _habilidades[idHabilidad] = 6;
                }
            }
            return _resolvioTodo;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: " + _idUsuario.ToString());
            sb.Append(",");
            sb.Append("Motivacion: ," + _motivacion.ToString());
            sb.Append(",");
            foreach (var habilidad in _habilidades)
            {
                sb.Append(habilidad.Key.ToString());
                sb.Append(",");
                sb.Append(habilidad.Value.ToString());
                sb.Append(",");
            }
            sb.Append("\r\n");
            return sb.ToString();
        }
        
    }
}
