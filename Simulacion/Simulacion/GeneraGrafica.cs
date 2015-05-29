using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    public delegate void GraphicCreatedHandler(object sender, EventArgs e);
    class GeneraGrafica
    {
        public event GraphicCreatedHandler graphicCreated;
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
        public void graficaXY(int[] x, double[] y,int height = 480, int width = 480,string xlabel="", string ylable = "", string imageName = "xyplot")
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
            String RImageName = "imageName <- \"" + imageName + "\"";

            System.IO.File.WriteAllLines(pathR + "/variables.R", new string[] { xString.ToString(), yString.ToString(), Rxlabel, Rylabel, RHeight, RWidth, RImageName });

            runCommand("del .RData");
            runCommand("R < variables.R --save");
            runCommand("R < xyPlot.R --no-save");
            if (graphicCreated != null)
            {
                GraphicCreatedEventArgs args = new GraphicCreatedEventArgs();
                args.location = pathR + "/" + imageName + ".png";
                args.name = imageName;
                graphicCreated(this, args);
            }
            
        }
        public void graficaRMSE_SVD(int idSimulacion)
        {
            List<double> rmse = db.RMSE_SVD(idSimulacion);
            List<int> iteracion = new List<int>();
            for (int i = 0; i < rmse.Count; i++)
            {
                iteracion.Add(i + 1);
            }
            graficaXY(iteracion.ToArray(), rmse.ToArray(), xlabel: "Iteracion", ylable: "RMSE", height: 450, width: 450+iteracion.Count*2, imageName: "RMSE");
        }
    }
}
