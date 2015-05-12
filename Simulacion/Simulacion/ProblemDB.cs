using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class ProblemDB
    {
        private string connectionString;
        private static ProblemDB instance;
        private ProblemDB()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.SimulacionConnectionString"].ConnectionString;
            connectionString = connection;
        }
        public static ProblemDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProblemDB();
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
        public void limpiaProblemaRecomendacion()
        {
            SqlConnection sqlConnection;
            SqlCommand cmd;
            sqlConnection = new SqlConnection();
            cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM SimulacionKarelotitlan.dbo.ProblemaRecomendacion";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
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
                if(probAct != problema){
                    if (probAct != -1)
                    {
                        resultado[probAct] = dProblema;
                    }
                    dProblema = new Dictionary<int, int>();
                    probAct = problema;
                }
                dProblema[user] = problema;
            }
            sqlConnection.Close();
            return resultado;
        }
        public void registraSimilitudes(int[] problemas, double[,] similitud)
        {
            limpiaProblemaRecomendacion();
            for (int i = 0; i < problemas.Length; i++)
            {
                StringBuilder command = new StringBuilder();
                command.Append("INSERT INTO SimulacionKarelotitlan.dbo.ProblemaRecomendacion (p1,p2,correlacion) VALUES ");
                int cont = 0;
                for (int j = 0; j < problemas.Length; j++)
                {
                    if (cont != 0)
                    {
                        command.Append(" , ");
                    }
                    command.Append("(");
                    command.Append(problemas[i].ToString());
                    command.Append(",");
                    command.Append(problemas[j].ToString());
                    command.Append(",");
                    command.Append(similitud[i, j].ToString());
                    command.Append(")");
                    cont++;
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
        public Dictionary<int, int> problemasIntentados(int usuario)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = string.Format("SELECT * FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE usuario = {0} order by problema", usuario);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int problema = (int)reader["problema"];
                int puntos = (int)reader["puntos"];
                result[problema] = puntos;
            }
            return result;
        }
        public List<int> problemasFaltantes(int usuario)
        {
            //TODO: excluir a los que ya fueron recomendados previamente
            List<int> result = new List<int>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = string.Format("SELECT * FROM SimulacionKarelotitlan.dbo.Problema WHERE clave NOT IN (SELECT problema FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE puntos = 100 and usuario = {0})", usuario);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int idProblema = (int)reader["clave"];
                result.Add(idProblema);
            }

            sqlConnection.Close();

            return result;
        }
    }
}
