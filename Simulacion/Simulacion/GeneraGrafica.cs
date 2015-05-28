using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class GeneraGrafica
    {
        private static GeneraGrafica instance;
        private string pathR = "../../../../RCode";
        GraficaDB db;
        private GeneraGrafica()
        {
            db = GraficaDB.Instance;
        }
        private void runCommand(string commando)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = pathR;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + commando;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
        public static GeneraGrafica Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GeneraGrafica();
                }
                return instance;
            }
        }
        public void graficaXY(int[] x, double[] y,int height = 480, int width = 480,string xlabel="", string ylable = "")
        {
            StringBuilder xString = new StringBuilder();
            xString.Append("x <- c(");
            for (int i = 0; i < x.Length; i++)
            {
                if (i != 0)
                {
                    xString.Append(",");
                }
                xString.Append(x[i].ToString());
            }
            xString.Append(")");

            StringBuilder yString = new StringBuilder();
            yString.Append("y <- c(");
            for (int i = 0; i < y.Length; i++)
            {
                if (i != 0) yString.Append(",");
                yString.Append(y[i].ToString());
            }
            yString.Append(")");

            String Rxlabel = "PNGxlabel <- \"" + xlabel + "\"";
            String Rylabel = "PNGylabel <- \"" + ylable + "\"";
            String RHeight = "PNGheight <- " + height.ToString();
            String RWidth = "PNGwidth <- " + width.ToString();

            System.IO.File.WriteAllLines(pathR + "/variables.R", new string[] { xString.ToString(), yString.ToString(), Rxlabel, Rylabel, RHeight, RWidth });

            runCommand("del .RData");
            runCommand("R < variables.R --save");
            runCommand("R < xyPlot.R --no-save");
            
        }
        public void graficaRMSE_SVD(int idSimulacion)
        {
            List<double> rmse = db.RMSE_SVD(idSimulacion);
            List<int> iteracion = new List<int>();
            for (int i = 0; i < rmse.Count; i++)
            {
                iteracion.Add(i + 1);
            }
            graficaXY(iteracion.ToArray(), rmse.ToArray(), xlabel: "Iteracion", ylable: "RMSE", height: 500, width: iteracion.Count);
        }
    }
}
