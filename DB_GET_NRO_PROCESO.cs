
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;

namespace rfcBaika
{
    public class DB_GET_NRO_PROCESO
    {
        public string run()
        {
            string respuesta = "0";
            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[get_numero_proceso]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;




            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                     respuesta = dataReader[0].ToString();
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return respuesta;

        }
    }
}