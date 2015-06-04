using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class GraficaDB
    {
        private string connectionString;
        private static GraficaDB instance;
        private GraficaDB()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.SimulacionConnectionString"].ConnectionString;
            connectionString = connection;
        }
        public static GraficaDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GraficaDB();
                }
                return instance;
            }
        }
        public List<double> RMSE_SVD(int idSimulacion)
        {
            List<double> rmse_SVD = new List<double>();
            int idEvento = EventoManager.Instance.getIdEvento("RMSE-SVD");

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = string.Format(@"SELECT comentario FROM SimulacionKarelotitlan.dbo.Evento
                                                WHERE idSimulacion = {0} and tipoEvento = {1} order by timestamp", idSimulacion, idEvento);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                string comentario = (string)result["comentario"];
                double RMSE = -1.0;
                if (!double.TryParse(comentario,out RMSE))
                {
                    RMSE = -1.0;
                }
                rmse_SVD.Add(RMSE);
            }
            sqlConnection.Close();
            return rmse_SVD;
        }
        public List<SimulacionData> getSimulaciones()
        {
            List<SimulacionData> simulaciones = new List<SimulacionData>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = "SELECT *,(SELECT TOP 1 nombre FROM SimulacionKarelotitlan.dbo.Algoritmo WHERE Algoritmo.id = (SELECT TOP 1 idAlgoritmo FROM simulacionKarelotitlan.dbo.Recomendacion WHERE Recomendacion.idSimulacion = Simulacion.id)) AS algoritmo,(SELECT TOP 1 descripcion FROM SimulacionKarelotitlan.dbo.Algoritmo WHERE Algoritmo.id = (SELECT TOP 1 idAlgoritmo FROM simulacionKarelotitlan.dbo.Recomendacion WHERE Recomendacion.idSimulacion = Simulacion.id)) as algoritmoDescripcion FROM SimulacionKarelotitlan.dbo.Simulacion";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                int id=-1;
                DateTime? inicio = null;
                DateTime? fin = null;
                string comentario = "";
                string algoritmo = "";
                string algoritmoDescripcion = "";

                id = (int)result["id"];
                if (!(result["inicio"] is DBNull))
                {
                    inicio = (DateTime?)result["inicio"];
                }
                if (!(result["fin"] is DBNull))
                {
                    fin = (DateTime?)result["fin"] as DateTime?;
                }
                comentario = result["comentario"] as string;
                algoritmo = result["algoritmo"] as string;
                algoritmoDescripcion = result["algoritmoDescripcion"] as string;

                SimulacionData nuevo = new SimulacionData();
                nuevo.idSimulacion = id;
                nuevo.inicio = inicio;
                nuevo.fin = fin;
                nuevo.comentario = comentario;
                nuevo.algoritmo = algoritmo;
                nuevo.algoritmoDescripcion = algoritmoDescripcion;

                simulaciones.Add(nuevo);
            }

            sqlConnection.Close();
            return simulaciones;
        }
        public List<int> entero(string tipoEvento, int idSimulacion)
        {
            List<int> entero = new List<int>();

            int idEvento = EventoManager.Instance.getIdEvento(tipoEvento);

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = string.Format(@"SELECT comentario FROM SimulacionKarelotitlan.dbo.Evento
                                                WHERE idSimulacion = {0} and tipoEvento = {1} order by timestamp", idSimulacion, idEvento);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                string comentario = (string)result["comentario"];
                int dato = -100;
                if (!int.TryParse(comentario, out dato))
                {
                    dato = -100;
                }
                entero.Add(dato);
            }
            sqlConnection.Close();
            return entero;
        }
    }
}
