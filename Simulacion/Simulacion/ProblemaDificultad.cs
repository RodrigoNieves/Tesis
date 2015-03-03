using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class ProblemaDificultad
    {
        Dictionary<int, Dificultad> idADificultad;
        Dictionary<string, Dificultad> nombreADificultad;
        private static ProblemaDificultad instance;
        private ProblemaDificultad()
        {
            KarelotitlanDB karelotitlan = new KarelotitlanDB();
            var dificultades = karelotitlan.dificultades();
            idADificultad = new Dictionary<int, Dificultad>();
            nombreADificultad = new Dictionary<string, Dificultad>();
            foreach (var dificultad in dificultades)
            {
                idADificultad[dificultad.idDificultad] = dificultad;
                nombreADificultad[dificultad.nombre] = dificultad;
            }
        }
        public static ProblemaDificultad Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProblemaDificultad();
                }
                return instance;
            }
        }
        public string getNombreDificultad(int id)
        {
            return idADificultad[id].nombre;
        }
        public string getDescripcion(int id)
        {
            return idADificultad[id].descripcion;
        }
        public string getDescripcion(string nombre)
        {
            return nombreADificultad[nombre].descripcion;
        }
        public int getIdDificultad(string nombre)
        {
            return nombreADificultad[nombre].idDificultad;
        }
        
    }
}
