using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class KarelotitlanDB
    {
        private string KarelotitlanConnectionString;
        public KarelotitlanDB()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.KarelotitlanConnectionString"].ConnectionString;
            KarelotitlanConnectionString = connection;
        }
        public SqlDataReader executeQuery(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(KarelotitlanConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader returnValue;

            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            returnValue = cmd.ExecuteReader();

            sqlConnection.Close();

            return returnValue;
        }
        public List<String> nombreProblemas()
        {
            List<String> returnValue = new List<string>();
            
            SqlConnection sqlConnection = new SqlConnection(KarelotitlanConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = "SELECT nombre FROM [Karelotitlan].[dbo].[Problema]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();

            while (result.Read())
            {
                IDataReader data = (IDataReader)result;
               returnValue.Add(data.GetString(0));
            }

            sqlConnection.Close();
            return returnValue;
        }
        public Dictionary<int, List<int>> historiasUsuarios()
        {
            Dictionary<int, List<int>> historias = new Dictionary<int, List<int>>();
            
            SqlConnection sqlConnection = new SqlConnection(KarelotitlanConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = @"SELECT usuario,
                                   DateTime,
	                               problema FROM (SELECT
		                            usuario,
		                            problema,
		                            puntos,
		                            hora/100000000 as year,
		                            (hora/1000000) % 100 as month,
		                            (hora/10000)   % 100 as day,
		                            (hora/100)     % 100 as hour,
		                            hora           % 100 as minutes,
		                            DATETIMEFROMPARTS(
			                            hora/100000000,
			                            (hora/1000000) % 100,
			                            (hora/10000)   % 100,
			                            (hora/100)     % 100,
			                            hora           % 100,
			                            0,0) as DateTime
		                            FROM Karelotitlan.dbo.UsuarioProblema
	                            WHERE puntos = 100 and hora != 0) as submitions
	                            order by usuario, DateTime";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            int idUsuarioAnt = -1;
            List<int> historia = new List<int>();
            while (result.Read())
            {
                IDataReader data = (IDataReader)result;
                int idUsuario = data.GetInt32(0);
                int idProblema = data.GetInt32(2);
                if (idUsuario != idUsuarioAnt)
                {
                    if (idUsuarioAnt != -1)
                    {
                        historias[idUsuarioAnt] = historia;
                        historia = new List<int>();
                    }
                }
                idUsuarioAnt = idUsuario;
                historia.Add(idProblema);
                if (idUsuarioAnt != -1)
                {
                    historias[idUsuarioAnt] = historia;
                }
            }

            sqlConnection.Close();
            return historias;
        }
        public List<Tema> temas()
        {
            List<Tema> temas = new List<Tema>();

            SqlConnection sqlConnection = new SqlConnection(KarelotitlanConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = "SELECT * FROM Karelotitlan.dbo.Clasificacion;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                Tema nuevo = new Tema();
                nuevo.idTema = (int)result["clave"];
                nuevo.nombre = (string)result["nombre"];
                nuevo.descripcion = (string)result["descripcion"];
                temas.Add(nuevo);
            }

            sqlConnection.Close();


            return temas;
        }
    }
}
