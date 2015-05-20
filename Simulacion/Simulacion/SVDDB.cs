using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class SVDDB
    {
        private string connectionString;
        private static SVDDB instance;
        private SVDDB()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.SimulacionConnectionString"].ConnectionString;
            connectionString = connection;
        }
        public static SVDDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SVDDB();
                }
                return instance;
            }
        }
        public void limpiaExpertoRecomendacion()
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
        public void limpiaSVDUserF()
        {
            SqlConnection sqlConnection;
            SqlCommand cmd;

            sqlConnection = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM SimulacionKarelotitlan.dbo.SVDUserF";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void limpiaSVDProblemF()
        {
            SqlConnection sqlConnection;
            SqlCommand cmd;

            sqlConnection = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM SimulacionKarelotitlan.dbo.SVDProblemF";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void limpiaSVDRecomendacion()
        {
            limpiaSVDUserF();
            limpiaSVDProblemF();
        }
        public List<Problema> problemas()
        {
            List<Problema> problemas = new List<Problema>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = @"SELECT  clave, 
	                                    nombre,
	                                    origen,
	                                    clasificacion,
	                                    (SELECT problemaDificultad.dificultad FROM SimulacionKarelotitlan.dbo.problemaDificultad WHERE problemaDificultad.problema = Problema.clave )  as DificultadN
	                                FROM Karelotitlan.dbo.Problema;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                Problema nuevo = new Problema();
                nuevo.idProblema = (int)result["clave"];
                nuevo.nombre = (string)result["nombre"];
                nuevo.origen = (string)result["origen"];
                nuevo.idTema = (int)result["clasificacion"];
                nuevo.dificultad = (int)result["DificultadN"];
                problemas.Add(nuevo);
            }

            sqlConnection.Close();


            return problemas;
        }
        public List<int> usuarios()
        {
            List<int> usuariosId = new List<int>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = "SELECT * FROM SimulacionKarelotitlan.DBO.Usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                int clave = (int)result["clave"];
                usuariosId.Add(clave);
            }
            return usuariosId;
        }
        public Dictionary<int, Dictionary<int, int>> calificacionesProblema()
        {
            Dictionary<int, Dictionary<int, int>> resultado = new Dictionary<int, Dictionary<int, int>>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM SimulacionKarelotitlan.dbo.UsuarioProblema order by problema, usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            int probAct = -1;
            Dictionary<int, int> dProblema = new Dictionary<int, int>();
            while (reader.Read())
            {
                int user = (int)reader["usuario"];
                int problema = (int)reader["problema"];
                int puntos = (int)reader["puntos"];
                if (probAct != problema)
                {
                    if (probAct != -1)
                    {
                        resultado[probAct] = dProblema;
                    }
                    dProblema = new Dictionary<int, int>();
                    probAct = problema;
                }
                dProblema[user] = puntos;
            }
            if (probAct != -1)
            {
                resultado[probAct] = dProblema;
            }
            sqlConnection.Close();
            return resultado;
        }
        public void guardaUserF(int nFeatures, int[] users, double[,] features)
        {
            limpiaSVDUserF();
            for (int i = 0; i < users.Length; i++)
            {
                StringBuilder command = new StringBuilder();
                command.Append("INSERT INTO SimulacionKarelotitlan.DBO.SVDUserF (usuario,feature,valor) VALUES ");
                for (int f = 0; f < nFeatures; f++)
                {
                    if (f != 0)
                    {
                        command.Append(" , ");
                    }
                    command.Append("(");
                    command.Append(users[i].ToString());
                    command.Append(",");
                    command.Append(f.ToString());
                    command.Append(",");
                    command.Append(features[i, f].ToString());
                    command.Append(")");
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
        public void guardaProblemF(int nFeatures, int[] problems, double[,] features)
        {
            limpiaSVDProblemF();
            for (int i = 0; i < problems.Length; i++)
            {
                StringBuilder command = new StringBuilder();
                command.Append("INSERT INTO SimulacionKarelotitlan.DBO.SVDProblemF(problema,feature,valor) VALUES ");
                for (int f = 0; f < nFeatures; f++)
                {
                    if (f != 0)
                    {
                        command.Append(" , ");
                    }
                    command.Append("(");
                    command.Append(problems[i].ToString());
                    command.Append(",");
                    command.Append(f.ToString());
                    command.Append(",");
                    command.Append(features[i, f].ToString());
                    command.Append(")");
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
}
