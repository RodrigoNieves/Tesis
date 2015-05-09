using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class UserDB
    {
        private string connectionString;
        private static UserDB instance;
        private UserDB()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.SimulacionConnectionString"].ConnectionString;
            connectionString = connection;
        }
        public static UserDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDB();
                }
                return instance;
            }
        }
        public void limpiaTablas()
        {
            SqlConnection sqlConnection;
            SqlCommand cmd;
            sqlConnection = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM SimulacionKarelotitlan.dbo.ExpertoRecomendacion";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public Dictionary<int, Dictionary<int, int>> usuariosVector()
        {
            Dictionary<int, Dictionary<int, int>> result = new Dictionary<int, Dictionary<int, int>>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT usuario,problema,puntos FROM SimulacionKarelotitlan.dbo.UsuarioProblema order by usuario,problema";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            int uActual = -1;
            Dictionary<int,int> uProblemas = new Dictionary<int,int>();
            while (reader.Read())
            {
                int user = (int)reader["usuario"];
                int problema = (int)reader["problema"];
                int puntos = (int)reader["puntos"];
                if (uActual != user)
                {
                    if (uActual != -1)
                    {
                        result[uActual] = uProblemas;
                    }
                    uProblemas = new Dictionary<int, int>();
                    uActual = user;
                    //cambiar aqui si se quiere que sea en una esca del 0 al 1
                }
                uProblemas[problema] = puntos;
            }
            sqlConnection.Close();
            return result;
        }
    }
}
