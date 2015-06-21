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
        public void limpiaUsuarioRecomendacion()
        {
            SqlConnection sqlConnection;
            SqlCommand cmd;
            sqlConnection = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM SimulacionKarelotitlan.dbo.UsuarioRecomendacion";
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
        public void guardaSimilitudes(int[] usuarios, double[,] similitud)
        {
            int top = 10;//guarda los mejores top
            double similitudMinima = 0.5;
            limpiaUsuarioRecomendacion();
            for (int i = 0; i < usuarios.Length; i++)
            {
                PriotiryQueue<CorrelacionUsuario> pq = new PriotiryQueue<CorrelacionUsuario>(invertida:true);
                for (int j = 0; j < usuarios.Length; j++)
                {
                    if (i != j && similitud[i, j] >= similitudMinima)
                    {
                        CorrelacionUsuario nuevo = new CorrelacionUsuario();
                        nuevo.u1 = usuarios[i];
                        nuevo.u2 = usuarios[j];
                        nuevo.correlacion = similitud[i, j];
                        pq.push(nuevo);
                        if (pq.count > top)
                        {
                            pq.pop();
                        }
                    }
                }
                StringBuilder command = new StringBuilder();
                command.Append("INSERT INTO SimulacionKarelotitlan.DBO.UsuarioRecomendacion (u1,u2,correlacion) VALUES  ");
                int cout = 0;
                while (!pq.empty)
                {
                    var elem = pq.pop();
                    if (cout != 0)
                    {
                        command.Append(",");
                    }
                    command.Append("(");
                    command.Append(elem.u1.ToString());
                    command.Append(",");
                    command.Append(elem.u2.ToString());
                    command.Append(",");
                    command.Append(elem.correlacion.ToString());
                    command.Append(")");
                    cout++;
                }
                command.Append(";");
                if (cout > 0)
                {
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
        public List<CorrelacionUsuario> obtenSimilares(int usuario)
        {
            List<CorrelacionUsuario> resultado = new List<CorrelacionUsuario>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = string.Format("SELECT * FROM SimulacionKarelotitlan.dbo.UsuarioRecomendacion where u1 = {0} order by correlacion desc ",usuario);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while(result.Read()){
                CorrelacionUsuario nuevo = new CorrelacionUsuario();
                nuevo.u1 = (int)result["u1"];
                nuevo.u2 = (int)result["u2"];
                nuevo.correlacion = (double)result["correlacion"];
                resultado.Add(nuevo);
            }


            return resultado;
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
        public List<int> viables(int usuario, int tiempo, List<int> candidatos)
        {
            List<int> result = new List<int>();
            StringBuilder candidatosString = new StringBuilder();
            bool first = true;
            foreach (var candidato in candidatos)
            {
                if (!first) candidatosString.Append(",");
                candidatosString.Append(candidato.ToString());
                first = false;
            }

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader sqlReader;

            cmd.CommandText = string.Format(@"SELECT * FROM SimulacionKarelotitlan.dbo.Problema 
                                                WHERE Problema.clave in ({0}) and
	                                                  Problema.clave not in (SELECT UsuarioProblema.problema FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE UsuarioProblema.usuario = {1} and UsuarioProblema.puntos = 100) and 
	                                                  Problema.clave not in (SELECT ExpertoRecomendacion.problema FROM SimulacionKarelotitlan.dbo.ExpertoRecomendacion WHERE ExpertoRecomendacion.usuario = {1} and ExpertoRecomendacion.tiempo < {2})", candidatosString.ToString(), usuario.ToString(), tiempo.ToString());
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                int clave = (int)sqlReader["clave"];
                result.Add(clave);
            }
            sqlConnection.Close();
            return result;
        }
    }
}
