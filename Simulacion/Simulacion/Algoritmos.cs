using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class Algoritmos
    {
        Dictionary<int, Algoritmo> idAlgoritmo;
        Dictionary<string, Algoritmo> nombreAAlgoritmo;
        private static Algoritmos instance;
        private Algoritmos()
        {
            cargaAlgoritmos();
        }
        private void cargaAlgoritmos()
        {
            SimulacionDB simulacion = new SimulacionDB();
            var algoritmos = simulacion.algoritmos();
            idAlgoritmo = new Dictionary<int, Algoritmo>();
            nombreAAlgoritmo = new Dictionary<string, Algoritmo>();
            foreach (var algorithm in algoritmos)
            {
                idAlgoritmo[algorithm.id] = algorithm;
                nombreAAlgoritmo[algorithm.nombre] = algorithm;
            }
        }
        private void agregaAlgoritmo(string algo)
        {
            int id = 1;
            if (idAlgoritmo.Keys.Count > 0)
            {
                id = idAlgoritmo.Keys.Max() + 1;
            }
            string descripcion = "Algortimo Auto Generado";
            Algoritmo nuevo = new Algoritmo(id, algo, descripcion);
            SimulacionDB simulacion = new SimulacionDB();
            simulacion.agregaAlgoritmo(nuevo);
        }
        public static Algoritmos Instance
        {
            get{
                if(instance == null){
                    instance = new Algoritmos();
                }
                return instance;
            }
        }
        public string getNombre(int id)
        {
            return idAlgoritmo[id].nombre;
        }
        public string getDescripcion(int id)
        {
            return idAlgoritmo[id].descripcion;
        }
        public int getId(string nombre)
        {
            if (!nombreAAlgoritmo.ContainsKey(nombre))
            {
                agregaAlgoritmo(nombre);
                cargaAlgoritmos();
            }
            return nombreAAlgoritmo[nombre].id;
        }
    }
}
