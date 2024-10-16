using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_FILAS
    {
        public Array run(request_fila datos)
        {
            List<responce_fila> List = new List<responce_fila>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select * from linea_config";
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
                    responce_fila res = new responce_fila();
                    res.centro = dataReader[0].ToString();
                    res.fila = dataReader[1].ToString();
                    res.linea = dataReader[2].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_fila
    {
        public String centro;
        public String fila;
        public String linea;
    }
    public class request_fila
    {
        public String resp;
    }
}