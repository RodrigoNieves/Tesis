using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class ProblemaTema
    {
        Dictionary<int, Tema> idATema;
        Dictionary<string, Tema> nombreATema;
        private static ProblemaTema instance;
        private ProblemaTema() {
            KarelotitlanDB karelotitlan = new KarelotitlanDB();
            var temas = karelotitlan.temas();
            foreach (var tema in temas)
            {
                idATema[tema.idTema] = tema;
                nombreATema[tema.nombre] = tema;
            }
        }
        public static ProblemaTema Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProblemaTema();
                }
                return instance;
            }
        }
        public string getNombreTema(int id)
        {
            return idATema[id].nombre;
        }
        public string getDescripcion(int id)
        {
            return idATema[id].descripcion;
        }
        public string getDescripcion(string nombre)
        {
            return nombreATema[nombre].descripcion;
        }
        public int getIdTema(string nombre)
        {
            return nombreATema[nombre].idTema;
        }
    }
}
