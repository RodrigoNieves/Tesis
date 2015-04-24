using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class InversionDB
    {
        private string connectionString;
        private static InversionDB instance;
        private InversionDB()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.SimulacionConnectionString"].ConnectionString;
            connectionString = connection;
        }
        public static InversionDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InversionDB();
                }
                return instance;
            }
        }
        public void limpiaTablas()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM SimulacionKarelotitlan.dbo.Inversion";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public Dictionary<int, List<int>> historiasUsuarios()
        {
            Dictionary<int, List<int>> historias = new Dictionary<int, List<int>>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
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

        internal void guardaAnalisis(int[] usuarios, int[,] inversiones, int[,] iguales, int[,] complemento)
        {
            limpiaTablas();
            StringBuilder command = new StringBuilder();
            command.Append("INSERT INTO SimulacionKarelotitlan.DBO.Inversion (u1,u2,inversiones,iguales,complemento) VALUES  ");
            for (int i = 0; i < usuarios.Length; i++)
            {
                for (int j = 0; j < usuarios.Length; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        command.Append(",");
                    }
                    command.Append("(");
                    command.Append(usuarios[i].ToString());
                    command.Append(",");
                    command.Append(usuarios[j].ToString());
                    command.Append(",");
                    command.Append(inversiones[i, j].ToString());
                    command.Append(",");
                    command.Append(iguales[i, j].ToString());
                    command.Append(",");
                    command.Append(complemento[i, j].ToString());
                    command.Append(")");
                }
            }
            command.Append(";");
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = command.ToString();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
