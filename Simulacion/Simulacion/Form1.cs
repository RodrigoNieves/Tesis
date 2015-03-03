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
            foreach(var problema in problemas){
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
        private void button1_Click(object sender, EventArgs e)
        {
            testProblemas();
        }
    }
}
