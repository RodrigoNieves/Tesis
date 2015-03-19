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
        public int creaUsuarioSimulacion(int idUsuario, int idSimulacion, double motivacion, double aPositiva, double aNegativa, double fFacilidad)
        {
            SqlConnection sqlConnection = new SqlConnection(SimulacionConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO SimulacionKarelotitlan.dbo.UsuarioSimulacion (idUsuario, idSimulacion, motivacionInicial, aPositiva, aNegativa, fFacilidad)" +
                            "VALUES(" +
                            idUsuario.ToString() + "," +
                            idSimulacion.ToString() + "," +
                            motivacion.ToString() + "," +
                            aPositiva.ToString() + "," +
                            aNegativa.ToString() + "," +
                            fFacilidad.ToString() + ")" +
                            "SELECT SCOPE_IDENTITY()";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            decimal temp = (decimal)cmd.ExecuteScalar();
            int idUsuarioSimulacion = decimal.ToInt32(temp);
            sqlConnection.Close();
            return idUsuarioSimulacion;
        }
    }
}
