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
        double _motivacion;
        double _aPositiva;
        double _aNegativa;
        double _fFacilida;
        double incremento;
        int _resueltos;
        int _fallos;
        bool _ficticio;

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
        public Usuario(int idSimulacion, double motivacionInicial, double aPositiva, double aNegativa, double fFacilidad)
        {
            _motivacion = motivacionInicial;
            _aPositiva = aPositiva;
            _aNegativa = aNegativa;
            _fFacilida = fFacilidad;
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
                fFacilidad);
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
        public void tickTiempo()
        {
            _motivacion += incremento;
            incremento = 0.0;
            _resueltos = 0;
            _fallos = 0;
            if (_motivacion < 1.0)
            {
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
