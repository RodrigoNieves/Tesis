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
        Random rnd;
        bool incluyeCero = true;
        int rango = 3;  // tamanio de ventana de analisis para determinar el nivel de usuario
        int min_sup = 2; // minimo numero de problemas para considerar que esta en ese nivel
        Dictionary<int, Problema> problemas;
        List<Tema> temas;
        List<Dificultad> dificultades;
        Dictionary<int, List<int>> historias;
        Dictionary<int, Dictionary<int, List<int>>> historiasDificultad; // [Tema][IdUsuario]
        Dictionary<int, Dictionary<int, List<int>>> nivelUsuarios;        // [Tema][IdUsuario]
        Dictionary<int, Dictionary<int, int>> countPN;                  //[Problema][Nivel] Conteo de cuantas personas resolvieron el Problema p y tenian el Nivel n
        Dictionary<int, double> pNivelMayorIgual;                       //[x] probabilidad de que nivel sea mayor o igal que x
        Dictionary<int, int> resuelto;                                  //[p] conteo de cuantos usuarios resolvieron en algun momento el problema p
        Dictionary<int, double> pResolverProblema;                      //[problema] probabilidad que el usuario haya resuelto problema
        Dictionary<int, Dictionary<int, double>> pInterseccion;         // [Problema][Nivel] probabilidad que se resuelva el problema y se tenga nivel de al menos nivel


        Dictionary<int, Dictionary<int, double>> pResolver;             // [Problema][Nivel] Probabilidad de resolver Problema dado que se es nivel Nivel o menor
        Dictionary<int, Dictionary<int, double>> pNivel;                // [Problema][Nivel] Probabilidad de pasar al siguiente nivel dado que se resolvio el problema 
        Dictionary<int, Usuario> usuarios;
        Recomendador _recomendador;                                      // Recomendador 
        public Recomendador recomendador
        {
            get
            {
                return _recomendador;
            }
            set
            {
                _recomendador = value;
            }
        }
        int _nUsuarios = 100;
        public int nUsuarios
        {
            get
            {
                return _nUsuarios;
            }
            set
            {
                _nUsuarios = value;
            }
        }
        int _nCiclos = 30;
        public int ciclosCompletos;
        public int nCiclos
        {
            get
            {
                return _nCiclos;
            }
            set
            {
                _nCiclos = value;
            }
        }
        public bool termino = false;

        public int totalRResueltas;
        public int totalRFallidas;
        public int totalSubioNivel;
        public int parcialRResueltas;
        public int parcialRFallidas;
        public int parcialSubioNivel;

        public int alumnosRendidos;
        public int alumnosCompletos;

        public int sinRecomendaciones;

        public int idSimulacion = -1;
        StringBuilder log;

        public int simulacionesADar;
        public int simulacionesDadas;

        public Simulador()
        {
            rnd = new Random(123456);
        }

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
            iniciaProbabilidaResolverProblema();
            iniciaProbabilidaNivel();
        }

        private void iniciaProbabilidaNivel()
        {
            Dictionary<int, Dictionary<int, int>> acumulado = new Dictionary<int, Dictionary<int, int>>();
            Stack<Dificultad> orden = new Stack<Dificultad>(dificultades);
            foreach (var problema in problemas)
            {
                acumulado[problema.Key] = new Dictionary<int, int>();
                int total = 0;
                foreach (var nivel in orden)
                {
                    total += countPN[problema.Key][nivel.idDificultad];
                    acumulado[problema.Key][nivel.idDificultad] = total;
                }
            }
            pNivel = new Dictionary<int, Dictionary<int, double>>();
            foreach (var problema in problemas)
            {
                pNivel[problema.Key] = new Dictionary<int, double>();
                foreach (var nivel in dificultades)
                {
                    pNivel[problema.Key][nivel.idDificultad] = (double)acumulado[problema.Key][nivel.idDificultad] / (double)resuelto[problema.Key];
                }
            }
        }

        private void iniciaProbabilidaResolverProblema()
        {
            Dictionary<int, Dictionary<int, int>> acumulado = new Dictionary<int, Dictionary<int, int>>();
            List<Dificultad> orden = new List<Dificultad>(dificultades);
            int idMayorDificultad = -100;
            foreach (var nivel in orden)
            {
                if (idMayorDificultad < nivel.idDificultad)
                {
                    idMayorDificultad = nivel.idDificultad;
                }
            }
            foreach (var problema in problemas)
            {
                acumulado[problema.Key] = new Dictionary<int, int>();
                int total = 0;
                foreach (var nivel in orden)
                {
                    total += countPN[problema.Key][nivel.idDificultad];
                    acumulado[problema.Key][nivel.idDificultad] = total;
                }
            }
            pResolver = new Dictionary<int, Dictionary<int, double>>();
            foreach (var problema in problemas)
            {
                pResolver[problema.Key] = new Dictionary<int, double>();
                foreach (var nivel in dificultades)
                {
                    pResolver[problema.Key][nivel.idDificultad] = (double)acumulado[problema.Key][nivel.idDificultad] / (double)historias.Count;
                }
                // hacer que alguien del maximo nivel siempre prodra resolver el problema
                foreach (var nivel in dificultades)
                {
                    pResolver[problema.Key][nivel.idDificultad] /= pResolver[problema.Key][idMayorDificultad];
                }
            }
        }

        private void probabilidaExtra()
        {
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
            countPN = new Dictionary<int, Dictionary<int, int>>();
            foreach (var problema in problemas)
            {
                conteo[problema.Key] = new Dictionary<int, int>();
                countPN[problema.Key] = new Dictionary<int, int>();
                foreach (var dificultad in dificultades)
                {
                    conteo[problema.Key][dificultad.idDificultad] = 0;
                    countPN[problema.Key][dificultad.idDificultad] = 0;
                }
            }
            foreach (var usuario in historias)
            {
                foreach (var tema in temas)
                {
                    var nivel = nivelUsuarios[tema.idTema][usuario.Key].GetEnumerator();
                    foreach (var problema in usuario.Value)
                    {
                        if (tema.idTema == problemas[problema].idTema)
                        {
                            int nivelAct = nivel.Current;
                            countPN[problema][nivelAct]++;
                            foreach (var dificultad in dificultades)
                            {
                                if (dificultad.idDificultad >= nivelAct)
                                {
                                    conteo[problema][dificultad.idDificultad]++;
                                }
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
            resuelto = new Dictionary<int, int>();
            foreach (var problema in problemas)
            {
                resuelto[problema.Value.idProblema] = 0;
            }
            foreach (var usuario in historias)
            {
                foreach (var problema in usuario.Value)
                {
                    resuelto[problema]++;
                }
            }
            pResolverProblema = new Dictionary<int, double>();
            foreach (var problema in problemas)
            {
                pResolverProblema[problema.Key] = (double)resuelto[problema.Key] / (double)historias.Count;
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
                        result.Append(nivelUsuario.ToString() + ",");
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

        private bool pasa(Usuario user, int idProblema)
        {
            double pPasa = pResolver[idProblema][user.habilidadEn(problemas[idProblema].idTema)];
            double p = rnd.NextDouble();
            return p <= pPasa;
        }
        private bool subeNivel(Usuario user, int idProblema)
        {
            if (user.habilidadEn(problemas[idProblema].idTema) > 5 ||
                user.habilidadEn(problemas[idProblema].idTema) == -1)
            {
                return false;
            }
            double subeNivel = pNivel[idProblema][user.habilidadEn(problemas[idProblema].idTema)+1];
            double p = rnd.NextDouble();
            return p <= subeNivel;
        }
        public void Simula()
        {
            ciclosCompletos = 0;
            totalRResueltas = 0;
            totalRFallidas = 0;
            totalSubioNivel = 0;
            alumnosCompletos = 0;
            alumnosRendidos = 0;
            sinRecomendaciones = 0;

            RegistroSimulacion rsimulacion = new RegistroSimulacion();
            rsimulacion.inicia();
            idSimulacion = rsimulacion.id;
            EventoManager.Instance.registroSimulacion = rsimulacion; //indica que debe guardar las simulaciones
            rsimulacion.recomendador = recomendador;
            
            SimulacionDB simuladorDB = new SimulacionDB();
            simuladorDB.limpiaBase();
            //simuladorDB.llenaUsuarios();
            //simuladorDB.llenaUsuariosProbelmas();
            
            log = new StringBuilder();
            usuarios = new Dictionary<int, Usuario>();
            for (int i = 0; i < nUsuarios; i++)
            {
                Usuario nuevo = new Usuario(rsimulacion.id, 2.0, 0.5, 0.25, 1.25, 1.0);
                usuarios[nuevo.idUsuario] = nuevo;
                usuarios[nuevo.idUsuario].temas = temas;
            }
            recomendador.iniciaRecomendador();
            for (int iteracion = 0; iteracion < nCiclos; iteracion++)
            {
                parcialRResueltas = 0;
                parcialRFallidas = 0;
                parcialSubioNivel = 0;
                log.Append("Iteracion: " + iteracion.ToString() + "\r\n");
                foreach (var user in usuarios)
                {
                    log.Append(user.Value.ToString());
                }
                recomendador.realizaAnalisis();
                SelectorRandom sr = new SelectorRandom(nUsuarios);
                alumnosCompletos = 0;
                alumnosRendidos = 0;
                foreach (var user in usuarios)
                {
                    int i = user.Key;
                    sr.agrega(i, (int)Math.Floor(usuarios[i].motivacion));
                    if (usuarios[i].rendido)
                    {
                        alumnosRendidos++;
                    }
                    if (usuarios[i].acaboProblemas)
                    {
                        alumnosCompletos++;
                    }
                }
                simulacionesADar = sr.cuantosRestantes();
                EventoManager.Instance.registraEvento("nRecomendaciones", simulacionesADar.ToString());
                simulacionesDadas = 0;
                while (!sr.empty())
                {
                    int pUsuario = sr.saca();
                    int recomendacion = recomendador.recomendacion(usuarios[pUsuario].idUsuario);
                    log.Append(pUsuario);
                    log.Append(",");
                    log.Append(recomendacion.ToString());
                    log.Append(",");
                    //Registrar recomendacion
                    //TODO: hacer un random Unico
                    if (recomendacion < 0)
                    {
                        // el recomendador no pudo generar recomendacion
                        if (usuarios[pUsuario].resolvioTodo())
                        {
                            log.Append("Resolvio Todo");
                        }
                        else
                        {
                            sinRecomendaciones++;
                            log.Append("Recomendador no tiene recomendaciones");
                        }
                    }
                    else
                    {
                        if (pasa(usuarios[pUsuario], recomendacion))
                        {
                            totalRResueltas++;
                            parcialRResueltas++;
                            log.Append("paso");
                            log.Append(",");
                            usuarios[pUsuario].resolvio(problemas[recomendacion]);
                            if (subeNivel(usuarios[pUsuario], recomendacion))
                            {
                                totalSubioNivel++;
                                parcialSubioNivel++;
                                rsimulacion.registraRecomendacion(usuarios[pUsuario], recomendacion, true, true);
                                usuarios[pUsuario].subeNivel(problemas[recomendacion].idTema);
                                log.Append("Subio");
                                log.Append(",");
                            }
                            else
                            {
                                rsimulacion.registraRecomendacion(usuarios[pUsuario], recomendacion, true, false);
                                log.Append("no subio");
                                log.Append(",");
                            }
                        }
                        else
                        {
                            totalRFallidas++;
                            parcialRFallidas++;
                            log.Append("no paso");
                            log.Append(",");
                            rsimulacion.registraRecomendacion(usuarios[pUsuario], recomendacion, false, false);
                            usuarios[pUsuario].fallo(problemas[recomendacion]);
                            log.Append("no subio,");
                        }
                    }
                    log.Append("\r\n");
                    simulacionesDadas++;
                }
                log.Append("\r\n");
                foreach(var user in usuarios)
                {
                    int i = user.Key;
                    usuarios[i].tickTiempo();
                }
                EventoManager.Instance.registraEvento("nFallos", totalRFallidas.ToString());
                EventoManager.Instance.registraEvento("nFallosCiclo", parcialRFallidas.ToString());
                EventoManager.Instance.registraEvento("nExitos", totalRResueltas.ToString());
                EventoManager.Instance.registraEvento("nExitosCiclo", parcialRResueltas.ToString());
                EventoManager.Instance.registraEvento("nIncNivel", totalSubioNivel.ToString());
                EventoManager.Instance.registraEvento("nIncNivelCiclo", parcialSubioNivel.ToString());
                EventoManager.Instance.registraEvento("nCompletos", alumnosCompletos.ToString());
                EventoManager.Instance.registraEvento("nRendidos", alumnosRendidos.ToString());
                EventoManager.Instance.registraEvento("nSinRecomendacion", sinRecomendaciones.ToString());
                double presicion = 0.0;
                if(simulacionesADar != 0){
                    presicion = (double)parcialRResueltas / (double)simulacionesADar;
                }
                EventoManager.Instance.registraEvento("presicion", presicion.ToString());
                ciclosCompletos++;
            }
            rsimulacion.termina();
            idSimulacion = -1;
            this.termino = true;
        }

        public string testSimula()
        {
            return log.ToString();
        }
    }
}
