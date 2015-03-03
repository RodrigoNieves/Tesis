using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class Simulador
    {
        Dictionary<int, List<int>> historias;
        Dictionary<int, Dictionary<int, List<int>>> historiasDificultad; // [Tema][IdUsuario]
        Dictionary<int, Dictionary<int, List<int>>> nivelUsurios;        // [Tema][IdUsuario]
        Dictionary<int, Problema> problemas;
        List<Tema> temas;

        public void iniciaModelo()
        {
            KarelotitlanDB karelotitlan = new KarelotitlanDB();
            historias = karelotitlan.historiasUsuarios();
            var problems = karelotitlan.problemas();
            foreach (var problem in problems)
            {
                problemas[problem.idProblema] = problem;
            }
            temas = karelotitlan.temas();
            historiasDificultad = new Dictionary<int, Dictionary<int, List<int>>>();
            nivelUsurios = new Dictionary<int, Dictionary<int, List<int>>>();
            foreach(var tema in temas){
                historiasDificultad[tema.idTema] = new Dictionary<int, List<int>>();
                nivelUsurios[tema.idTema] = new Dictionary<int, List<int>>();
            }
            foreach (KeyValuePair<int, List<int>> usuario in historias)
            {
                foreach (var tema in temas)
                {
                    historiasDificultad[tema.idTema][usuario.Key] = new List<int>();
                }
                foreach (var idProblema in usuario.Value)
                {
                    Problema problema = problemas[idProblema];
                    historiasDificultad[problema.idTema][usuario.Key].Add(problema.dificultad);
                    foreach (var tema in temas)
                    {
                        if (tema.idTema != problema.idTema)
                        {
                            historiasDificultad[tema.idTema][usuario.Key].Add(-1);
                        }
                    }
                }
            }
            /*
             *  TODO: encontrar el nivel de cada usuario 
             */ 
        }
    }
}
