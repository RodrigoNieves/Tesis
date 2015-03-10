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
        bool incluyeCero = true;
        int rango = 3;  // tamanio de ventana de analisis para determinar el nivel de usuario
        int min_sup = 2; // minimo numero de problemas para considerar que esta en ese nivel
        Dictionary<int, Problema> problemas;
        List<Tema> temas;
        List<Dificultad> dificultades;
        Dictionary<int, List<int>> historias;
        Dictionary<int, Dictionary<int, List<int>>> historiasDificultad; // [Tema][IdUsuario]
        Dictionary<int, Dictionary<int, List<int>>> nivelUsuarios;        // [Tema][IdUsuario]
        Dictionary<int, double> pNivelMayorIgual;                       //[x] probabilidad de que nivel sea mayor o igal que x
        Dictionary<int, double> pResolverProblema;                      //[problema] probabilidad que el usuario haya resuelto problema
        Dictionary<int, Dictionary<int, double>> pInterseccion;         // [Problema][Nivel] probabilidad que se resuelva el problema y se tenga nivel de al menos nivel
       
        Dictionary<int, Dictionary<int, double>> pResolver;             // [Problema][Nivel] Probabilida de resolver Problema dado que se es nivel Nivel
        Dictionary<int, Dictionary<int, double>> pNivel;                // [Problema][Nivel] 
        
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
            dificultades = karelotitlan.dificultades();
            historiasDificultad = new Dictionary<int, Dictionary<int, List<int>>>();
            nivelUsuarios = new Dictionary<int, Dictionary<int, List<int>>>();
            foreach (var tema in temas)
            {
                historiasDificultad[tema.idTema] = new Dictionary<int, List<int>>();
                nivelUsuarios[tema.idTema] = new Dictionary<int, List<int>>();
            }
            foreach (KeyValuePair<int, List<int>> usuario in historias)
            {
                foreach (var tema in temas)
                {
                    historiasDificultad[tema.idTema][usuario.Key] = new List<int>();
                    nivelUsuarios[tema.idTema][usuario.Key] = new List<int>();
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
                        nivelUsuarios[tema.idTema][usuario.Key].Add(nivelUsuario);
                    }
                }
            }
            iniciaProbabilidadNivel();
            iniciaProbabilidadResolverProblema();
            iniciaProbabilidadInterseccion();

            pResolver = new Dictionary<int, Dictionary<int, double>>();
            pNivel = new Dictionary<int, Dictionary<int, double>>();
            foreach (var problema in problemas)
            {
                pResolver[problema.Key] = new Dictionary<int, double>();
                pNivel[problema.Key] = new Dictionary<int, double>();
                foreach (var nivel in dificultades)
                {
                    pResolver[problema.Key][nivel.idDificultad] = pInterseccion[problema.Key][nivel.idDificultad] * pResolverProblema[problema.Key] / pNivelMayorIgual[nivel.idDificultad];
                    pNivel[problema.Key][nivel.idDificultad] = pInterseccion[problema.Key][nivel.idDificultad] * pNivelMayorIgual[nivel.idDificultad] / pResolverProblema[problema.Key];
                }  
            }
            
        }

        private void iniciaProbabilidadInterseccion()
        {
            Dictionary<int, Dictionary<int, int>> conteo = new Dictionary<int, Dictionary<int, int>>(); // problema Nivel
            foreach (var problema in problemas)
            {
                conteo[problema.Key] = new Dictionary<int, int>();
                foreach (var dificultad in dificultades)
                {
                    conteo[problema.Key][dificultad.idDificultad] = 0;
                }
            }
            foreach (var usuario in historias)
            {
                foreach (var tema in temas)
                {
                    var nivel = nivelUsuarios[tema.idTema][usuario.Key].GetEnumerator();
                    foreach (var problema in usuario.Value)
                    {
                        int nivelAct = nivel.Current;
                        foreach (var dificultad in dificultades)
                        {
                            if (dificultad.idDificultad >= nivelAct)
                            {
                                conteo[problema][dificultad.idDificultad]++;
                            }
                        }
                        nivel.MoveNext();
                    }
                }
            }
            pInterseccion = new Dictionary<int, Dictionary<int, double>>();
            foreach (var problema in problemas)
            {
                pInterseccion[problema.Key] = new Dictionary<int, double>();
                foreach (var nivel in dificultades)
                {
                    pInterseccion[problema.Key][nivel.idDificultad] = (double)conteo[problema.Key][nivel.idDificultad] / (double)historias.Count;
                }
            }
        }

        private void iniciaProbabilidadResolverProblema()
        {
            Dictionary<int, int> resolvieron; // [Problema] cuantos resolvieron el problema X
            resolvieron = new Dictionary<int, int>();
            foreach (var problema in problemas)
            {
                resolvieron[problema.Value.idProblema] = 0;
            }
            foreach (var usuario in historias)
            {
                foreach (var problema in usuario.Value)
                {
                    resolvieron[problema]++;
                }
            }
            pResolverProblema = new Dictionary<int, double>();
            foreach (var problema in problemas)
            {
                pResolverProblema[problema.Key] = (double)resolvieron[problema.Key] / (double)historias.Count;
            }
        }
        private void iniciaProbabilidadNivel()
        {
            pNivelMayorIgual = new Dictionary<int, double>();
            List<int> valNivel = new List<int>();
            foreach (var nivel in dificultades)
            {
                valNivel.Add(nivel.idDificultad);
            }
            valNivel.Sort();
            int total = valNivel.Count;
            int mayores = valNivel.Count;
            foreach (var nivel in valNivel)
            {
                pNivelMayorIgual[nivel] = (double)mayores / (double)total;
                mayores--;
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
                    foreach (var nivelUsuario in nivelUsuarios[tema.idTema][usuario.Key])
                    {
                        result.Append(nivelUsuario.ToString()+ ",");
                    }
                    result.Append("\r\n");
                }
            }
            result.Append("\r\n");
            foreach (var problema in problemas)
            {
                result.Append(problema.Key.ToString() + ",");
                foreach (var tema in pResolver[problema.Key])
                {
                    result.Append(tema.Key.ToString() + "," + tema.Value.ToString() + ",");
                }

                result.Append("\r\n");    
            }
            result.Append("\r\n");
            result.Append("\r\n");
            foreach (var problema in problemas)
            {
                result.Append(problema.Key.ToString() + ",");
                foreach (var tema in pNivel[problema.Key])
                {
                    result.Append(tema.Key.ToString() + "," + tema.Value.ToString() + ",");
                }

                result.Append("\r\n");
            }
            return result.ToString();
        }
    }
}
