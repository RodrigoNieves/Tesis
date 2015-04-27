using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class SimulacionDB
    {
        // TODO: Aplicar patron Singleton en DB
        private string SimulacionConnectionString;
        private string pathScripts;
        public SimulacionDB()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.SimulacionConnectionString"].ConnectionString;
            SimulacionConnectionString = connection;
            var scripts = Simulacion.Properties.Settings.Default.PathSimulacionScript;
            pathScripts = scripts;
        }
        private void ejecutaScript(string scriptDir)
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = System.IO.File.ReadAllText(scriptDir);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 60*60;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();

            sqlConnection.Close();

        }
        public void agregaAlgoritmo(Algoritmo nuevo)
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO SimulacionKarelotitlan.dbo.Algoritmo VALUES(" + 
                nuevo.id.ToString() + ",'" + 
                nuevo.nombre.ToString() + "','" + 
                nuevo.descripcion.ToString() + "')";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void limpiaBase()
        {
            //TODO: remplantear limpiar Base de datos
            //ejecutaScript(pathScripts + "02 Tabla UsuarioProblemas.sql");
            //ejecutaScript(pathScripts + "03 Datos Simulacion.sql");
            limpiaUsuariosProblema();
            quitaUsuariosFictiocios();
        }
        public void llenaUsuarios()
        {
            ejecutaScript(pathScripts + "04 Datos Usuarios.sql");
        }
        public void llenaUsuariosProbelmas()
        {
            ejecutaScript(pathScripts + "05 Datos UsuariosProblema.sql");
        }
        public List<Algoritmo> algoritmos()
        {
            List<Algoritmo> algoritmos = new List<Algoritmo>();

            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = "SELECT * FROM SimulacionKarelotitlan.dbo.Algoritmo";
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                int id = (int)result["id"];
                string nombre = (string)result["nombre"];
                string descripcion = (string)result["descripcion"];
                Algoritmo nuevo = new Algoritmo(id, nombre, descripcion);
                algoritmos.Add(nuevo);
            }
            return algoritmos;
        }
        public int iniciaSimulacion()
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO SimulacionKarelotitlan.dbo.Simulacion (inicio)
                                    VALUES(SYSDATETIME ())
                                    SELECT SCOPE_IDENTITY()";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            decimal temp = (decimal)cmd.ExecuteScalar();
            int idSimulacion = decimal.ToInt32(temp);
            sqlConnection.Close();
            return idSimulacion;
        }
        public void finalizaSimulacion(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE SimulacionKarelotitlan.dbo.Simulacion
                                SET fin = SYSDATETIME ()
                                WHERE Simulacion.id = "+id.ToString();
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public int creaUsuarioFicticion()
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO SimulacionKarelotitlan.dbo.Usuario (nombreReal,nombreUsuario,password,correo,estado,sexo,pregunta,respuesta,lang,omi,recibirEmail,asesor)
                                VALUES('Ficticio','Ficticio',0,'Fictiocio@noimporta.com',32,0,1,'1',1,5,0,1)
                                SELECT SCOPE_IDENTITY()";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            decimal temp = (decimal)cmd.ExecuteScalar();
            int idUsuario = decimal.ToInt32(temp);
            sqlConnection.Close();
            return idUsuario;
        }
        public int creaUsuarioSimulacion(int idUsuario, int idSimulacion, double motivacion, double aPositiva, double aNegativa, double fFacilidad,double sinRecomendacion)
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO SimulacionKarelotitlan.dbo.UsuarioSimulacion (idUsuario, idSimulacion, motivacionInicial, aPositiva, aNegativa, fFacilidad, sinRecomendacion)" +
                            "VALUES(" +
                            idUsuario.ToString() + "," +
                            idSimulacion.ToString() + "," +
                            motivacion.ToString() + "," +
                            aPositiva.ToString() + "," +
                            aNegativa.ToString() + "," +
                            fFacilidad.ToString() + "," +
                            sinRecomendacion.ToString() + ")" +
                            "SELECT SCOPE_IDENTITY()";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            decimal temp = (decimal)cmd.ExecuteScalar();
            int idUsuarioSimulacion = decimal.ToInt32(temp);
            sqlConnection.Close();
            return idUsuarioSimulacion;
        }
        public void quitaUsuariosFictiocios()
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"DELETE FROM SimulacionKarelotitlan.dbo.Usuario
                                WHERE clave > 14983";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void registraRecomendacion(int idAlgoritmos, int idSimulacion, int idUsuarioSimulacion, int idProblema,int resolvio, int subioNivel)
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO SimulacionKarelotitlan.dbo.Recomendacion(idAlgoritmo,idSimulacion,idUsuarioSimulacion,idProblema,resolvio,subioNivel,timestamp) " +
                                "VALUES(" +
                                idAlgoritmos.ToString() + "," +
                                idSimulacion.ToString() + "," +
                                idUsuarioSimulacion.ToString() + "," +
                                idProblema.ToString() + "," +
                                resolvio.ToString() + "," +
                                subioNivel.ToString() + ",SYSDATETIME())";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void limpiaUsuariosProblema()
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"DELETE FROM SimulacionKarelotitlan.dbo.UsuarioProblema
                                WHERE UsuarioProblema.usuario > 14983";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void registraResultado(int idUsuario, int idPorblema, int puntos)
        {

            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("SELECT * FROM SimulacionKarelotitlan.dbo.UsuarioProblema WHERE UsuarioProblema.usuario = {0} and UsuarioProblema.problema = {1}", idUsuario,idPorblema);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            bool crear = !data.HasRows;
            if (data.HasRows)
            {
                data.Read();
                int oldPuntos = (int)data["puntos"];
                if (oldPuntos > puntos) puntos = oldPuntos;
            }
            sqlConnection.Close();

            string hora = DateTime.Now.Year.ToString() +
                          DateTime.Now.Month.ToString() +
                          DateTime.Now.Day.ToString() +
                          DateTime.Now.Hour.ToString() +
                          DateTime.Now.Minute.ToString();

            sqlConnection = new SqlConnection(SimulacionConnectionString);
            cmd = new SqlCommand();
            if (crear)
            {
                cmd.CommandText = string.Format("INSERT INTO SimulacionKarelotitlan.DBO.UsuarioProblema (usuario,problema,primero,puntos,hora) VALUES({0},{1},{2},{2},{3})",idUsuario,idPorblema,puntos,hora);
            }
            else
            {
                cmd.CommandText = string.Format("UPDATE SimulacionKarelotitlan.DBO.UsuarioProblema SET puntos = {0} WHERE UsuarioProblema.usuario = {1} and UsuarioProblema.problema = {2}",puntos,idUsuario,idPorblema);
            }
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public bool resolvioTodo(int idUsuario)
        {
            int nProblemas = -1;
            int nResueltos = -2;
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("select count(*) from SimulacionKarelotitlan.dbo.UsuarioProblema where UsuarioProblema.usuario = {0} and UsuarioProblema.puntos = 100", idUsuario);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
            {
                nResueltos = (int)data[0];
            }
            sqlConnection.Close();

            sqlConnection = new SqlConnection(SimulacionConnectionString);
            cmd = new SqlCommand();
            cmd.CommandText = "select count(*) from SimulacionKarelotitlan.dbo.Problema";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            data = cmd.ExecuteReader();
            if (data.Read())
            {
                nProblemas = (int)data[0];
            }
            sqlConnection.Close(); 

            return nProblemas == nResueltos;
        }
    }
}
