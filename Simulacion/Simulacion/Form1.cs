using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            Simulador simulador = new Simulador();
            simulador.iniciaModelo();
            simulador.recomendador = new RRandom(ListaDeProblemas());
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText("hola"+txtLog.Text);
        }
        private void testExperto()
        {
            Simulador simulador = new Simulador();
            simulador.iniciaModelo();
            simulador.recomendador = new RExperto();
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText(txtLog.Text);
        }
        private void testInversion()
        {
            Simulador simulador = new Simulador();
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
            Simulador simulador = new Simulador();
            simulador.iniciaModelo();
            RRandom coldStart = new RRandom(ListaDeProblemas());
            simulador.recomendador = new RUser(rEnColdStart: coldStart);
            simulador.Simula();
            txtLog.AppendText(simulador.testSimula());
            Clipboard.SetText(txtLog.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            testUser();
        }
    }
}
