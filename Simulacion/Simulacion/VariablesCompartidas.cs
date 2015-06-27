using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class VariablesCompartidas
    {
        public int nColdStart;
        private Dictionary<int, Usuario> _usuarios;
        public Dictionary<int, Usuario> usuarios
        {
            get
            {
                return _usuarios;
            }
            set
            {
                foreach (var usuario in value)
                {
                    _usuarios[usuario.Key] = usuario.Value;   
                }
            }
        }
        public double maximaMotivacion;
        public void reinicia()
        {
            nColdStart = 0;
            _usuarios = new Dictionary<int,Usuario>();
            maximaMotivacion = 0.00001;
        }
        private static VariablesCompartidas instance;
        private VariablesCompartidas()
        {

        }
        public static VariablesCompartidas Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VariablesCompartidas();
                }
                return instance;
            }
        }
    }
}
