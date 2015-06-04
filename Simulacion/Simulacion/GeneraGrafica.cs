﻿using System;
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
        public void graficaXY(int[] x1, double[] y1, int[] x2, double[] y2, int height = 480, int width = 480, string xlabel = "", string ylable = "", string imageName = "xyplot")
        {
            StringBuilder x1String = new StringBuilder();
            x1String.Append("x1 <- c(");
            for (int i = 0; i < x1.Length; i++)
            {
                if (i != 0)
                {
                    x1String.Append(",");
                }
                x1String.Append(x1[i].ToString());
            }
            x1String.Append(")");

            StringBuilder y1String = new StringBuilder();
            y1String.Append("y1 <- c(");
            for (int i = 0; i < y1.Length; i++)
            {
                if (i != 0) y1String.Append(",");
                y1String.Append(y1[i].ToString());
            }
            y1String.Append(")");

            StringBuilder x2String = new StringBuilder();
            x2String.Append("x2 <- c(");
            for (int i = 0; i < x2.Length; i++)
            {
                if (i != 0)
                {
                    x2String.Append(",");
                }
                x2String.Append(x2[i].ToString());
            }
            x2String.Append(")");

            StringBuilder y2String = new StringBuilder();
            y2String.Append("y2 <- c(");
            for (int i = 0; i < y2.Length; i++)
            {
                if (i != 0) y2String.Append(",");
                y2String.Append(y2[i].ToString());
            }
            y2String.Append(")");


            String Rxlabel = "PNGxlabel <- \"" + xlabel + "\"";
            String Rylabel = "PNGylabel <- \"" + ylable + "\"";
            String RHeight = "PNGheight <- " + height.ToString();
            String RWidth = "PNGwidth <- " + width.ToString();
            String RImageName = "imageName <- \"" + imageName + "\"";

            System.IO.File.WriteAllLines(pathR + "/variables.R", new string[] { x1String.ToString(), y1String.ToString(), x2String.ToString(), y2String.ToString(), Rxlabel, Rylabel, RHeight, RWidth, RImageName });

            runCommand("del .RData");
            runCommand("R < variables.R --save");
            runCommand("R < xyPlot2.R --no-save");
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
            graficaXY(iteracion.ToArray(), rmse.ToArray(),
                xlabel: "Iteracion", 
                ylable: "RMSE", 
                height: 450, 
                width: 450+iteracion.Count*2, 
                imageName: "RMSE");
        }
        public void graficaRMSE_SVD(int s1, int s2)
        {
            List<double> rmse1 = db.RMSE_SVD(s1);
            List<double> rmse2 = db.RMSE_SVD(s2);
            List<int> iteracion1 = new List<int>();
            for (int i = 0; i < rmse1.Count; i++)
            {
                iteracion1.Add(i + 1);
            }
            List<int> iteracion2 = new List<int>();
            for (int i = 0; i < rmse2.Count; i++)
            {
                iteracion2.Add(i + 1);
            }
            graficaXY(iteracion1.ToArray(), rmse1.ToArray(),
                iteracion2.ToArray(), rmse2.ToArray(),
                xlabel:"Iteracion", 
                ylable: "RMSE", 
                height:450,
                width: 450+Math.Max(iteracion1.Count,iteracion2.Count)*2, 
                imageName: "RMSE");
        }
    }
}
