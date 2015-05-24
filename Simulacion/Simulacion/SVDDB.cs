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
        public Dictionary<int, Dictionary<int, int>> calificacionesUsuarios()
        {
            Dictionary<int, Dictionary<int, int>> resultado = new Dictionary<int, Dictionary<int, int>>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM SimulacionKarelotitlan.dbo.UsuarioProblema order by usuario, problema";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            int uAct = -1;
            Dictionary<int, int> dUsuario = new Dictionary<int, int>();
            while (reader.Read())
            {
                int user = (int)reader["usuario"];
                int problema = (int)reader["problema"];
                int puntos = (int)reader["puntos"];
                if (uAct != user)
                {
                    if (uAct != -1)
                    {
                        resultado[uAct] = dUsuario;
                    }
                    dUsuario = new Dictionary<int, int>();
                    uAct = user;
                }
                dUsuario[problema] = puntos;
            }
            if (uAct != -1)
            {
                resultado[uAct] = dUsuario;
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
                cmd.CommandTimeout = 20000;
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
        public List<int> problemasPosibles(int competidor,int tiempo)
        {
            List<int> pPosible = new List<int>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = string.Format(@"SELECT clave FROM SimulacionKarelotitlan.dbo.Problema WHERE
                                                clave not in (SELECT problema FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE usuario = {0} and puntos = 100) and
                                                clave not in (SELECT problema FROM SimulacionKarelotitlan.dbo.ExpertoRecomendacion WHERE usuario = {0} and tiempo < {1})", competidor, tiempo);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                int clave = (int)result["clave"];
                pPosible.Add(clave);
            }

            sqlConnection.Close();

            return pPosible;
        }
        public void registraRecomendacion(int idUsuarion, int idProblema, int tiempo)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT * FROM SimulacionKarelotitlan.dbo.ExpertoRecomendacion WHERE ExpertoRecomendacion.usuario = {0} and ExpertoRecomendacion.problema = {1}", idUsuarion, idProblema);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            bool crear = !data.HasRows;
            if (data.HasRows)
            {
                data.Read();
                int oldTiempo = (int)data["tiempo"];
                if (oldTiempo < tiempo) tiempo = oldTiempo;
            }
            sqlConnection.Close();

            sqlConnection = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            if (crear)
            {
                cmd.CommandText = string.Format("INSERT INTO SimulacionKarelotitlan.dbo.ExpertoRecomendacion (usuario,problema,tiempo) VALUES ({0},{1},{2})", idUsuarion, idProblema, tiempo);
            }
            else
            {
                cmd.CommandText = string.Format("UPDATE SimulacionKarelotitlan.dbo.ExpertoRecomendacion SET ExpertoRecomendacion.tiempo = {2} WHERE ExpertoRecomendacion.usuario = {0} AND ExpertoRecomendacion.problema = {1}", idUsuarion, idProblema, tiempo);
            }
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public int intentados(int usuario)
        {
            int intentados = 0;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT count(*) as intentos FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE usuario = {0}", usuario);
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
            {
                intentados = (int)data["intentos"];
            }
            sqlConnection.Close();
            return intentados;
        }
    }
}
