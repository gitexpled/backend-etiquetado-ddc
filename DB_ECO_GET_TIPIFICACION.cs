using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_GET_TIPIFICACION
    {
        public Array run(request_ECO_GET_TIPIFICACION datos)
        {
            List<responce_ECO_GET_TIPIFICACION> List = new List<responce_ECO_GET_TIPIFICACION>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT TIPO FROM TIPIFICACION WHERE especie = '" + datos.ESPECIE + "' ";
            
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            Int16 i = 0;
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ECO_GET_TIPIFICACION res = new responce_ECO_GET_TIPIFICACION();
                    res.TIPO = dataReader[0].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_GET_TIPIFICACION
    {
        public String TIPO;
       
    }
    public class request_ECO_GET_TIPIFICACION
    {
        public String ESPECIE;
        
    }
}