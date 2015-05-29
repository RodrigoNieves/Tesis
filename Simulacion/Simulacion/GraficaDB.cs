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
            return rmse_SVD;
        }
    }
}
