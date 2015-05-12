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
        public void limpiaInversion()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM SimulacionKarelotitlan.dbo.Inversion";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
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

        public void guardaAnalisis(int[] usuarios, int[,] inversiones, int[,] iguales, int[,] complemento, double[,] scroe)
        {
            int top = 10; // guarda los mejores top
            limpiaInversion();
            for (int i = 0; i < usuarios.Length; i++)
            {
                PriotiryQueue<AnalisisUsuarioInversion> pq = new PriotiryQueue<AnalisisUsuarioInversion>(invertida: true);
                for (int j = 0; j < usuarios.Length; j++)
                {
                    AnalisisUsuarioInversion nuevo = new AnalisisUsuarioInversion();
                    nuevo.u1 = usuarios[i];
                    nuevo.u2 = usuarios[j];
                    nuevo.inversiones = inversiones[i, j];
                    nuevo.iguales = iguales[i, j];
                    nuevo.complemento = complemento[i, j];
                    nuevo.score = scroe[i, j];
                    pq.push(nuevo);
                    if (pq.count > top)
                    {
                        pq.pop();
                    }
                }
                StringBuilder command = new StringBuilder();
                command.Append("INSERT INTO SimulacionKarelotitlan.DBO.Inversion (u1,u2,inversiones,iguales,complemento) VALUES  ");
                int count = 0;
                while(!pq.empty){
                    var elem = pq.pop();
                    if (count != 0)
                    {
                        command.Append(",");
                    }
                    command.Append("(");
                    command.Append(elem.u1.ToString());
                    command.Append(",");
                    command.Append(elem.u2.ToString());
                    command.Append(",");
                    command.Append(elem.inversiones.ToString());
                    command.Append(",");
                    command.Append(elem.iguales.ToString());
                    command.Append(",");
                    command.Append(elem.complemento.ToString());
                    command.Append(")");
                    count++;
                }

                command.Append(";");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = command.ToString();
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                /* Comentando la version que guarda todos los resultados.
                int salto = 100;
                for (int jtemp = 0; jtemp < usuarios.Length; jtemp += salto)
                {
                    StringBuilder command = new StringBuilder();
                    command.Append("INSERT INTO SimulacionKarelotitlan.DBO.Inversion (u1,u2,inversiones,iguales,complemento) VALUES  ");

                    for (int j = jtemp;j<jtemp+salto && j < usuarios.Length; j++)
                    {
                        if ((j%salto) != 0)
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

                    command.Append(";");
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = command.ToString();
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }*/


            }
        }
        public List<int> usuariosSimilares(int usuario, int nTop)
        {
            List<int> resultado = new List<int>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = string.Format("SELECT TOP {0} *,(126-sqrt(2*inversiones))*iguales*complemento AS score FROM SimulacionKarelotitlan.dbo.Inversion WHERE u1 = {1} ORDER BY score DESC", nTop, usuario);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while(result.Read()){
                int u2 = (int)result["u2"];
                resultado.Add(u2);
            }
            sqlConnection.Close();
            return resultado;
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
