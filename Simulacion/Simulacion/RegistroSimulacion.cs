﻿using System;
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
    }
}
