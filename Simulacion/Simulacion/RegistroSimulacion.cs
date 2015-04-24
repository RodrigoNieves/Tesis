using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class RegistroSimulacion
    {
        int _id;
        int _idRecomendador;
        public Recomendador recomendador
        {
            set
            {
                _idRecomendador = Algoritmos.Instance.getId(value.GetType().Name);
            }
        }
        public RegistroSimulacion()
        {
            _id = -1;
        }
        public int id
        {
            get
            {
                return _id;
            }
        }
        public void inicia()
        {
            if (_id == -1)
            {
                SimulacionDB simulacion = new SimulacionDB();
                _id = simulacion.iniciaSimulacion();
            }
        }
        public void termina()
        {
            if (_id != -1)
            {
                SimulacionDB simulacion = new SimulacionDB();
                simulacion.finalizaSimulacion(_id);
            }
        }
        public void registraRecomendacion(Usuario user, int idPorblema, bool resolvio, bool subioNivel)
        {
            SimulacionDB simulacion = new SimulacionDB();
            int res = 0;
            if (resolvio)
            {
                res = 1;
            }
            int paso = 0;
            if (subioNivel)
            {
                paso = 1;
            }
            simulacion.registraRecomendacion(
                _idRecomendador, 
                _id, 
                user.idUsuarioSimulacion, 
                idPorblema, 
                res, 
                paso);
            if(resolvio){
                simulacion.registraResultado(user.idUsuario, idPorblema, 100);
            }else{
                simulacion.registraResultado(user.idUsuario, idPorblema, 0);
            }
            
        }
    }
}
