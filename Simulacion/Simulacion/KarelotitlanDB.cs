using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion
{
    class KarelotitlanDB
    {
        private string KarelotitlanConnectionString = "Data Source=CICPC;Initial Catalog=Karelotitlan;Integrated Security=True";
        public SqlDataReader executeQuery(string query)
        {
            SqlConnection sqlConnection = new SqlConnection(KarelotitlanConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader returnValue;

            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            returnValue = cmd.ExecuteReader();

            sqlConnection.Close();

            return returnValue;
        }
        public List<String> nombreProblemas()
        {
            List<String> returnValue = new List<string>();
            
            SqlConnection sqlConnection = new SqlConnection(KarelotitlanConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader result;

            cmd.CommandText = "SELECT nombre FROM [Karelotitlan].[dbo].[Problema]";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            result = cmd.ExecuteReader();

            while (result.Read())
            {
                IDataReader data = (IDataReader)result;
               returnValue.Add(data.GetString(0));
            }

            sqlConnection.Close();
            return returnValue;
        }
    }
}
