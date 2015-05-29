using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        Simulador simulador= null;
        int lastIdSimulation = -1;
        int cont;
        public Form1()
        {
            InitializeComponent();
            GeneraGrafica.Instance.graphicCreated += Instance_graphicCreated;
        }

        void Instance_graphicCreated(object sender, EventArgs e)
        {
            /// TODO: copiar imagen a una carpeta nueva y mostrarla en interfaz
            throw new NotImplementedException();
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
            //realizaSimulacion();
            graficaRMSE_SVD(61);
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
    }
}
