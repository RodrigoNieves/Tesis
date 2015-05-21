using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class EventoManager
    {
        private string connectionString;
        private static EventoManager instance;
        private Dictionary<string, Evento> nombreEvento;
        private Dictionary<int, Evento> idEvento;
        public RegistroSimulacion registroSimulacion = null;
        private EventoManager()
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["Simulacion.Properties.Settings.SimulacionConnectionString"].ConnectionString;
            connectionString = connection;
            cargaTipoEventos();
        }
        private void cargaTipoEventos()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;
            nombreEvento = new Dictionary<string, Evento>();
            idEvento = new Dictionary<int, Evento>();
            cmd.CommandText = "SELECT * FROM SimulacionKarelotitlan.dbo.TipoEvento";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();
            while (result.Read())
            {
                int id = (int)result["id"];
                string nombre = (string)result["nombre"];
                nombre = nombre.Trim();
                string descripcion = "";
                if (!(result["descripcion"] is System.DBNull))
                {
                    descripcion = (string)result["descripcion"];
                }
                Evento nuevo = new Evento(id, nombre, descripcion);
                nombreEvento[nuevo.nombre] = nuevo;
                idEvento[nuevo.idEvento] = nuevo;
            }
        }
        public static EventoManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventoManager();
                }
                return instance;
            }
        }
        public void agregaTipoEvento(string nombre)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("INSERT INTO SimulacionKarelotitlan.dbo.TipoEvento (nombre) values('{0}');", nombre);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void registraEvento(Evento tipoEvento, RegistroSimulacion simulacion, String informacion)
        {
            informacion.Replace('\'','"');
            informacion.Replace('\\', ' ');
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("INSERT INTO SimulacionKarelotitlan.dbo.Evento (idSimulacion,tipoEvento,timestamp,comentario) VALUES ({0},{1},SYSDATETIME(),'{2}');", simulacion.id, tipoEvento.idEvento, informacion);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void registraEvento(Evento tipo, String informacion)
        {
            if (registroSimulacion != null)
            {
                registraEvento(tipo, registroSimulacion, informacion);
            }
        }
        public void registraEvento(String tipo, String informacion)
        {
            if (!nombreEvento.ContainsKey(tipo))
            {
                agregaTipoEvento(tipo);
                cargaTipoEventos();
            }
            Evento tipoEvento = nombreEvento[tipo];
            registraEvento(tipoEvento, informacion);
        }
        public void registraEvento(int idTipo, String informacion)
        {
            if (idEvento.ContainsKey(idTipo))
            {
                Evento tipoEvento = idEvento[idTipo];
                registraEvento(tipoEvento, informacion);
            }
        }
    }
}
