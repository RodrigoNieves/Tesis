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
            ejecutaScript(pathScripts + "02 Tabla UsuarioProblemas.sql");
            ejecutaScript(pathScripts + "03 Datos Simulacion.sql");
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
                int id = (int)result["AlgoritmoID"];
                string nombre = (string)result["nombre"];
                string descripcion = (string)result["descripcion"];
                Algoritmo nuevo = new Algoritmo(id, nombre, descripcion);
                algoritmos.Add(nuevo);
            }
            return algoritmos;
        }
    }
}
