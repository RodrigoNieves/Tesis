using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class ExpertoDB
    {
        private string connectionString;
        private static ExpertoDB instance;
        private ExpertoDB()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.SimulacionConnectionString"].ConnectionString;
            connectionString = connection;
        }
        public static ExpertoDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExpertoDB();
                }
                return instance;
            }
        }
        public void limpiaTablas()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM SimulacionKarelotitlan.dbo.ExpertoRecomendacion";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public int recommendacionUsuario(int idUsuario,int tiempo)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT TOP 1 * FROM SimulacionKarelotitlan.dbo.Problema " + 
                                            "WHERE Problema.clave not in (SELECT UsuarioProblema.problema FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE UsuarioProblema.usuario = {0} and UsuarioProblema.puntos = 100) and " +
	                                        "Problema.clave not in (SELECT ExpertoRecomendacion.problema FROM SimulacionKarelotitlan.dbo.ExpertoRecomendacion WHERE ExpertoRecomendacion.usuario = {0} and ExpertoRecomendacion.tiempo < {1}) "+
                                            "order by Problema.dificultad",idUsuario,tiempo);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            int result;
            if (data.Read())
            {
                result = (int)data["clave"];
            }
            else
            {
                result = -1;
            }
            sqlConnection.Close();
            return result;
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
                cmd.CommandText = string.Format("INSERT INTO SimulacionKarelotitlan.dbo.ExpertoRecomendacion (usuario,problema,tiempo) VALUES ({0},{1},{2})",idUsuarion,idProblema,tiempo);
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

    }
}
