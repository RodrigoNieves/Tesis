using System;
using System.Collections;
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
        Dictionary<int, Dictionary<int, int>> conteo;                   // [Nivel][Problema]
        bool incluyeCero = true;
        List<Tema> temas;
        int rango = 3;  // tamanio de ventana de analisis para determinar el nivel de usuario
        int min_sup = 2; // minimo numero de problemas para considerar que esta en ese nivel
        private int calculaNivel(Queue<int> ventana)
        {
            if (ventana.Count < min_sup) return 0;
            List<int> ordenada = new List<int>(ventana);
            ordenada.Sort();
            int dif = ventana.Count - min_sup;
            return ordenada.ElementAt(dif);
        }
        public void iniciaModelo()
        {
            KarelotitlanDB karelotitlan = new KarelotitlanDB();
            if (incluyeCero)
            {
                historias = karelotitlan.historiasUsuariosIncluido0();
            }
            else
            {
                historias = karelotitlan.historiasUsuarios();
            }
            problemas = new Dictionary<int, Problema>();
            var problems = karelotitlan.problemas();
            foreach (var problem in problems)
            {
                problemas[problem.idProblema] = problem;
            }
            temas = karelotitlan.temas();
            historiasDificultad = new Dictionary<int, Dictionary<int, List<int>>>();
            nivelUsurios = new Dictionary<int, Dictionary<int, List<int>>>();
            foreach (var tema in temas)
            {
                historiasDificultad[tema.idTema] = new Dictionary<int, List<int>>();
                nivelUsurios[tema.idTema] = new Dictionary<int, List<int>>();
            }
            foreach (KeyValuePair<int, List<int>> usuario in historias)
            {
                foreach (var tema in temas)
                {
                    historiasDificultad[tema.idTema][usuario.Key] = new List<int>();
                    nivelUsurios[tema.idTema][usuario.Key] = new List<int>();
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
            foreach (var tema in temas)
            {
                foreach (KeyValuePair<int, List<int>> usuario in historiasDificultad[tema.idTema])
                {
                    int nivelUsuario = 0;
                    Queue<int> ventana = new Queue<int>();
                    foreach (int nivel in usuario.Value)
                    {
                        if (nivel > 0)
                        {
                            ventana.Enqueue(nivel);
                        }
                        if (ventana.Count > rango)
                        {
                            ventana.Dequeue();
                        }
                        nivelUsuario = Math.Max(nivelUsuario, calculaNivel(ventana));
                        nivelUsurios[tema.idTema][usuario.Key].Add(nivelUsuario);
                    }
                }
            }
            conteo = new Dictionary<int, Dictionary<int, int>>();
            foreach (var usuario in historias)
            {
                foreach (var tema in temas)
                {
                    var nivel = nivelUsurios[tema.idTema][usuario.Key].GetEnumerator();
                    foreach (var problema in usuario.Value)
                    {
                        int nivelAct = nivel.Current;
                        nivel.MoveNext();
                        if (tema.idTema == problemas[problema].idTema)
                        {
                            int idUsuario = usuario.Key;
                            if (conteo[nivelAct] == null)
                            {
                                conteo[nivelAct] = new Dictionary<int, int>();
                            }
                            if (conteo[nivelAct][problema] == null)
                            {
                                conteo[nivelAct][problema] = 0;
                            }
                            conteo[nivelAct][problema]++;
                        }
                    }
                }
            }
        }
        public string testIniciaModelo()
        {
            StringBuilder result = new StringBuilder();
            foreach (var usuario in historias)
            {
                result.Append(usuario.Key + ": \r\n");
                result.Append("historia ,");
                foreach (var problema in usuario.Value)
                {
                    result.Append(problema.ToString() + ", ");
                }
                result.Append("\r\n");
                foreach (var tema in temas)
                {
                    result.Append("\"nivel problema: " + tema.idTema + "\",");
                    foreach (var nivelProblema in historiasDificultad[tema.idTema][usuario.Key])
                    {
                        result.Append(nivelProblema.ToString() + ",");
                    }
                    result.Append("\r\n");
                    result.Append("\"nivel usuario: " + tema.idTema + "\",");
                    foreach (var nivelUsuario in nivelUsurios[tema.idTema][usuario.Key])
                    {
                        result.Append(nivelUsuario.ToString()+ ",");
                    }
                    result.Append("\r\n");
                }
            }
            return result.ToString();
        }
    }
}
