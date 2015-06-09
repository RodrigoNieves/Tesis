using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion
{
    public partial class Form1 : Form
    {
        Thread oThread;
        Thread creaImagenThread;
        Thread inicializaOpcion;
        Simulador simulador= null;
        List<SimulacionData> simulaciones;
        int imgContador = 0;
        int lastIdSimulation = -1;
        int cont;
        public Form1()
        {
            InitializeComponent();
            GeneraGrafica.Instance.graphicCreated += Instance_graphicCreated;
            pbGrafica.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        void Instance_graphicCreated(object sender, EventArgs e)
        {
            GraphicCreatedEventArgs args = (GraphicCreatedEventArgs)e;
            imgContador++;

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = Application.StartupPath;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "echo F | xcopy " + args.location.Replace('/','\\') + " Imagenes\\imagen" + imgContador + ".png";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            pbGrafica.ImageLocation = "Imagenes\\imagen" + imgContador + ".png";


            /// Eliminando imagenes anteriores
            Process p2 = new Process();
            ProcessStartInfo si2 = new ProcessStartInfo();
            si2.WindowStyle = ProcessWindowStyle.Hidden;
            si2.WorkingDirectory = Application.StartupPath + "\\Imagenes";
            si2.FileName = "cmd.exe";
            si2.Arguments = "/C " + "for %i in (*) do if not %i == imagen" + imgContador + ".png del %i ";
            p2.StartInfo = si2;
            p2.Start();
            process.WaitForExit();
        }
        private void aplicaActualizacionOpcion()
        {
            string ant1 = cmbSimulacion1.Text;
            string ant2 = cmbSimulacion2.Text;
            cmbSimulacion1.Items.Clear();
            cmbSimulacion2.Items.Clear();
            cmbSimulacion1.Items.Add("Actual");
            cmbSimulacion2.Items.Add("Ninguna");
            foreach (var elem in simulaciones)
            {
                StringBuilder name = new StringBuilder();
                name.Append(string.Format("{0,4}", elem.idSimulacion));
                name.Append(")");
                name.Append(elem.algoritmo);
                name.Append("-");
                name.Append(elem.inicio.ToString());
                name.Append("/");
                name.Append(elem.fin.ToString());
                cmbSimulacion1.Items.Add(name.ToString());
                cmbSimulacion2.Items.Add(name.ToString());
            }
            cmbSimulacion1.Text = ant1;
            cmbSimulacion2.Text = ant2;
        }
        private void inicializaGraficaOpcionSync()
        {
            simulaciones = GraficaDB.Instance.getSimulaciones();
            
        }
        private void inicializaGraficaOpcion()
        {
            inicializaOpcion = new Thread(inicializaGraficaOpcionSync);
            inicializaOpcion.Start();
            timer2.Enabled = true;
        }
        private void testNombreProblemas()
        {
            KarelotitlanDB karelotitlan = new KarelotitlanDB();
            List<String> problemas = karelotitlan.nombreProblemas();
            foreach (String problema in problemas)
            {
                txtLog.AppendText(problema);
                txtLog.AppendText("\r\n");
            }
        }
        private void testHistorias()
        {
            KarelotitlanDB karelotitlan = new KarelotitlanDB();
            var usuarios = karelotitlan.historiasUsuarios();
            foreach (KeyValuePair<int, List<int>> usuario in usuarios)
            {
                txtLog.AppendText(usuario.Key.ToString());
                txtLog.AppendText(":");
                foreach (int problema in usuario.Value)
                {
                    txtLog.AppendText(" " + problema.ToString());
                }
                txtLog.AppendText("\r\n");
            }
        }
        private void testProblemas()
        {
            KarelotitlanDB katelotitlan = new KarelotitlanDB();
            var problemas = katelotitlan.problemas();
            foreach (var problema in problemas)
            {
                string info = "idProblema: " + problema.idProblema.ToString() + ", " +
                               "Problema: " + problema.nombre + ", " +
                               "idTema: " + problema.idTema.ToString() + ", " +
                               "Tema: " + problema.nombreTema + ", " +
                               "Descripcion tema: " + problema.descripcionTema + ", " +
                               "Dificultad: " + problema.dificultad.ToString() + ", " +
                               "Nombre Dificultad: " + problema.nombreDificultad + ", " +
                               "Descripcion Dificultad: " + problema.descripcionDificultad + ", " +
                               "Origen: " + problema.origen;
                txtLog.AppendText(info);
                txtLog.AppendText("\r\n");
            }
        }
        private void testInicialSimulador()
        {
            Simulador simulador = new Simulador();
            simulador.iniciaModelo();
            txtLog.AppendText(simulador.testIniciaModelo());
            Clipboard.SetText(txtLog.Text);
        }
        private int[] ListaDeProblemas()
        {
            KarelotitlanDB karelotitlan = new KarelotitlanDB();
            var problemas = karelotitlan.problemas();
            List<int> ids = new List<int>();
            foreach (var problema in problemas)
            {
                ids.Add(problema.idProblema);
            }
            return ids.ToArray();
        }
        private void testSimulacion()
        {
            simulador = new Simulador();
            simulador.iniciaModelo();
            simulador.recomendador = new RRandom(ListaDeProblemas());
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText("hola"+txtLog.Text);
        }
        private void testExperto()
        {
            simulador = new Simulador();
            simulador.iniciaModelo();
            simulador.recomendador = new RExperto();
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText(txtLog.Text);
        }
        private void testInversion()
        {
            simulador = new Simulador();
            simulador.iniciaModelo();
            RRandom coldStart = new RRandom(ListaDeProblemas());
            simulador.recomendador = new RInversion(rEnColdStart: coldStart);
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText(txtLog.Text);
        }
        private void testPriorityQueue()
        {
            StringBuilder log = new StringBuilder();
            Random rn = new Random(123);
            PriotiryQueue<int> pq = new PriotiryQueue<int>(invertida:false);
            PriotiryQueue<int> pqInvertida = new PriotiryQueue<int>(invertida: true);
            for (int i = 0; i < 10; i++)
            {
                int r = rn.Next()%100;
                log.Append(r.ToString());
                log.Append(",");
                pq.push(r);
                pqInvertida.push(r);
            }
            log.Append("\r\n");
            while (!pq.empty)
            {
                log.Append(pq.top().ToString());
                pq.pop();
                log.Append(",");
            }
            log.Append("\r\n");
            while (!pqInvertida.empty)
            {
                log.Append(pqInvertida.top().ToString());
                pqInvertida.pop();
                log.Append(",");
            }
            log.Append("\r\n");
            txtLog.AppendText(log.ToString());
        }
        private void testUser()
        {
            simulador = new Simulador();
            simulador.iniciaModelo();
            RRandom coldStart = new RRandom(ListaDeProblemas());
            simulador.recomendador = new RUser(rEnColdStart: coldStart);
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText(txtLog.Text);
        }
        private void testProblem()
        {
            simulador = new Simulador();
            simulador.iniciaModelo();
            RRandom coldStart = new RRandom(ListaDeProblemas());
            simulador.recomendador = new RProblema(rEnColdStart: coldStart);
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText(txtLog.Text);
        }
        private void testSVD()
        {
            simulador = new Simulador();
            simulador.iniciaModelo();
            RRandom coldStart = new RRandom(ListaDeProblemas());
            simulador.recomendador = new RSVD(rEnColdStart:coldStart);
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText(txtLog.Text);
        }
        private void testThread()
        {
            if (oThread != null) { return; }
            
            simulador = new Simulador();
            simulador.iniciaModelo();
            RRandom coldStart = new RRandom(ListaDeProblemas());
            simulador.recomendador = new RSVD(rEnColdStart: coldStart);

            oThread = new Thread(new ThreadStart(simulador.Simula));
            oThread.Start();
            cont = 0;
            timer1.Enabled = true;
        }
        private void realizaSimulacion()
        {
            if (simulador != null)
            {
                MessageBox.Show("Actualmente esta corriendo una simulacion");
                return;
            }

            simulador = new Simulador();
            simulador.iniciaModelo();
            Recomendador coldStart = null;
            if (cmbColdStart.Text == "Random")
            {
                coldStart = new RRandom(ListaDeProblemas());
            }
            else if (cmbColdStart.Text == "Experto")
            {
                coldStart = new RExperto();
            }
            Recomendador recomendador = null;
            if (cmbAlgoritmo.Text == "Random")
            {
                //Random
                recomendador = new RRandom(ListaDeProblemas());
            }
            else if (cmbAlgoritmo.Text == "Experto")
            {
                //Experto
                recomendador = new RExperto();
            }
            else if (cmbAlgoritmo.Text == "Inversion")
            {
                //Inversion
                recomendador = new RInversion(rEnColdStart: coldStart);
            }
            else if (cmbAlgoritmo.Text == "Usuario")
            {
                //Usuario
                recomendador = new RUser(rEnColdStart: coldStart);
            }
            else if (cmbAlgoritmo.Text == "Problema")
            {
                //Problema
                recomendador = new RProblema(rEnColdStart: coldStart);
            }
            else if (cmbAlgoritmo.Text == "SVD")
            {
                //SVD
                recomendador = new RSVD(rEnColdStart: coldStart);
            }
            else
            {
                MessageBox.Show("No hay Algoritmo Seleccionado");
                simulador = null;
                return;
            }

            int nUsuarios = int.Parse(txtUsuariosSimulacion.Text);
            int nCiclos = int.Parse(txtNCiclos.Text);

            simulador.recomendador = recomendador;
            simulador.nUsuarios = nUsuarios;
            simulador.nCiclos = nCiclos;

            oThread = new Thread(new ThreadStart(simulador.Simula));
            oThread.Start();
            cont = 0;
            timer1.Enabled = true;
            progressBar.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            realizaSimulacion();
        }
        private void graficaRMSE_SVD(int idSimulacion)
        {
            if (creaImagenThread != null)
            {
                if (creaImagenThread.IsAlive)
                {
                    // termina aun esta corriendo
                    return;
                }
            }
            creaImagenThread = new Thread(() => GeneraGrafica.Instance.graficaRMSE_SVD(idSimulacion));
            creaImagenThread.Start();
        }
        private void graficaRMSE_SVD(int idSimulacion1,int idSimulacion2)
        {
            if (creaImagenThread != null)
            {
                if (creaImagenThread.IsAlive)
                {
                    // termina aun esta corriendo
                    return;
                }
            }
            creaImagenThread = new Thread(() => GeneraGrafica.Instance.graficaRMSE_SVD(idSimulacion1, idSimulacion2));
            creaImagenThread.Start();
        }
        public void graficaEntero(string tipoEvento, int idSimulacion)
        {
            if (creaImagenThread != null)
            {
                if (creaImagenThread.IsAlive)
                {
                    // termina aun esta corriendo
                    return;
                }
            }
            creaImagenThread = new Thread(() => GeneraGrafica.Instance.graficaEntero(tipoEvento, idSimulacion));
            creaImagenThread.Start();
        }
        public void graficaFlotante(string tipoEvento, int idSimulacion)
        {
            if (creaImagenThread != null)
            {
                if (creaImagenThread.IsAlive)
                {
                    return;
                }
            }
            creaImagenThread = new Thread(() => GeneraGrafica.Instance.graficaFlotante(tipoEvento, idSimulacion));
            creaImagenThread.Start();
        }
        public void graficaEntero(string tipoEvento, int idSimulacion1, int idSimulacion2)
        {
            if (creaImagenThread != null)
            {
                if (creaImagenThread.IsAlive)
                {
                    // termina aun esta corriendo
                    return;
                }
            }
            creaImagenThread = new Thread(() => GeneraGrafica.Instance.graficaEntero(tipoEvento, idSimulacion1, idSimulacion2));
            creaImagenThread.Start();
        }
        public void graficaFlotante(string tipoEvento, int idSimulacion1, int idSimulacion2)
        {
            if (creaImagenThread != null)
            {
                if (creaImagenThread.IsAlive)
                {
                    return;
                }
            }
            creaImagenThread = new Thread(() => GeneraGrafica.Instance.graficaFlotante(tipoEvento, idSimulacion1, idSimulacion2));
            creaImagenThread.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            double progreso = 0.0;
            if (simulador.nCiclos > 0)
            {
                progreso += (double)simulador.ciclosCompletos / ((double)simulador.nCiclos+1.0);
                if (simulador.simulacionesADar > 0)
                {
                    progreso += ((double)simulador.simulacionesDadas / (double)simulador.simulacionesADar) / (simulador.nCiclos+1.0);
                }
            }

            progressBar.Value = (int)(progreso*progressBar.Maximum);

            double tiempoTranscurrido = 0.0;
            tiempoTranscurrido = ((double)cont * timer1.Interval) / 1000.0;
            lbTiempo.Text = tiempoTranscurrido.ToString();

            lbTotalCiclos.Text = simulador.nCiclos.ToString();
            lbCiclosCompletados.Text = simulador.ciclosCompletos.ToString();

            lbRDadas.Text = simulador.simulacionesDadas.ToString();
            lbRPorDar.Text = simulador.simulacionesADar.ToString();

            lbTotalResuelto.Text = simulador.totalRResueltas.ToString();
            lbTotalFallado.Text = simulador.totalRFallidas.ToString();
            lbTotalSubioNivel.Text = simulador.totalSubioNivel.ToString();

            lbParcialFallado.Text = simulador.parcialRFallidas.ToString();
            lbParcialResuelto.Text = simulador.parcialRResueltas.ToString();
            lbParcialSubioNivel.Text = simulador.parcialSubioNivel.ToString();

            lbAlumnosCompletos.Text = simulador.alumnosCompletos.ToString();
            lbAlumnosRendidos.Text = simulador.alumnosRendidos.ToString();

            lbSinRecomendaciones.Text = simulador.sinRecomendaciones.ToString();

            lbIdSimulacion.Text = simulador.idSimulacion.ToString();
            if (simulador.idSimulacion > 0)
            {
                lastIdSimulation = simulador.idSimulacion;
            }

            cont++;
            if (simulador.termino)
            {
                simulador = null;
                timer1.Enabled = false;
                oThread = null;
                progressBar.Visible = false;
                inicializaGraficaOpcion();
            }
            actualizaGrafica();
        }
        private void actualizaGrafica()
        {
            string grafica = cmbGrafica.Text;
            string simulacion1 = cmbSimulacion1.Text;
            string simulacion2 = cmbSimulacion2.Text;
            int idS1 = -1;
            int idS2 = -1;
            if (simulacion1 == "Actual")
            {
                idS1 = 0;
            }
            else
            {
                if (!int.TryParse(simulacion1.Split(')')[0].Trim(), out idS1))
                {
                    idS1 = -1;
                }
            }
            if (simulacion2 == "Ninguna")
            {
                idS2 = 0;
            }
            else
            {
                if (!int.TryParse(simulacion2.Split(')')[0].Trim(), out idS2))
                {
                    idS2 = -1;
                }
            }
            if (idS1 < 0) return;
            if(idS1 == 0){
                if (simulador == null) return;
                if (simulador.idSimulacion > 0)
                {
                    idS1 =simulador.idSimulacion;
                }
            }
            if (grafica == "Root Mean Square Error")
            {
                if (idS2 < 1)
                {
                    graficaRMSE_SVD(idS1);
                }
                else
                {
                    graficaRMSE_SVD(idS1, idS2);
                }
            }
            else if (grafica == "Numero de recomendaciones dadas")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nRecomendaciones", idS1);
                }
                else
                {
                    graficaEntero("nRecomendaciones", idS1, idS2);
                }
            }
            else if (grafica == "Numero de problemas fallados")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nFallos", idS1);
                }
                else
                {
                    graficaEntero("nFallos", idS1, idS2);
                }
            }
            else if (grafica == "Numero de problemas fallados por ciclo")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nFallosCiclo", idS1);
                }
                else
                {
                    graficaEntero("nFallosCiclo", idS1, idS2);
                }
            }
            else if (grafica == "Numero de problemas resueltos")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nExitos", idS1);
                }
                else
                {
                    graficaEntero("nExitos", idS1, idS2);
                }
            }
            else if (grafica == "Numero de problemas resueltos por ciclo")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nExitosCiclo", idS1);
                }
                else
                {
                    graficaEntero("nExitosCiclo", idS1, idS2);
                }
            }
            else if (grafica == "Numero de incrementos de nivel")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nIncNivel", idS1);
                }
                else
                {
                    graficaEntero("nIncNivel", idS1, idS2);
                }
            }
            else if (grafica == "Numero de incrementos de nivel por ciclo")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nIncNivelCiclo", idS1);
                }
                else
                {
                    graficaEntero("nIncNivelCiclo", idS1, idS2);
                }
            }
            else if (grafica == "Numero de usuarios que completaron los problemas")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nCompletos", idS1);
                }
                else
                {
                    graficaEntero("nCompletos", idS1, idS2);
                }
            }
            else if (grafica == "Numero de usuarios rendidos")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nRendidos", idS1);
                }
                else
                {
                    graficaEntero("nRendidos", idS1, idS2);
                }
            }
            else if (grafica == "Numero de veces que no se pudo generar recomendacion")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nSinRecomendacion", idS1);
                }
                else
                {
                    graficaEntero("nSinRecomendacion", idS1, idS2);
                }
            }
            else if (grafica == "Numero de veces utilizado coldStart")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nColdStart", idS1);
                }
                else
                {
                    graficaEntero("nColdStart", idS1, idS2);
                }
            }
            else if (grafica == "Numero de veces utilizado coldStart por ciclo")
            {
                if (idS2 < 1)
                {
                    graficaEntero("nColdStartCiclo", idS1);
                }
                else
                {
                    graficaEntero("nColdStartCiclo", idS1, idS2);
                }
            }
            else if (grafica == "Presicion de recomendaciones")
            {
                if (idS2 < 1)
                {
                    graficaFlotante("presicion", idS1);
                }
                else
                {
                    graficaFlotante("presicion", idS1, idS2);
                }
            }
            else if (grafica == "Presicion por recomendaciones")
            {
                if (idS2 < 1)
                {
                    graficaFlotante("presicionRecomendacion", idS1);
                }
                else
                {
                    graficaFlotante("presicionRecomendacion", idS1, idS2);
                }
            }
            else if (grafica == "Presicion por log de recomendaciones")
            {
                if (idS2 < 1)
                {
                    graficaFlotante("presicionRecomendacion2", idS1);
                }
                else
                {
                    graficaFlotante("presicionRecomendacion2", idS1, idS2);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializaGraficaOpcion();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(inicializaOpcion != null){
                if (inicializaOpcion.ThreadState == System.Threading.ThreadState.Stopped)
                {
                    inicializaOpcion = null;
                    aplicaActualizacionOpcion();
                    timer2.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizaGrafica();
        }
    }
}
