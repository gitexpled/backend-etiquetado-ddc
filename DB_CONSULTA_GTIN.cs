using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_CONSULTA_GTIN
    {
        public Array run(DB_request_gtin datos)
        {
            List<DB_response_gtin> List = new List<DB_response_gtin>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select * from gtin";
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
                    DB_response_gtin res = new DB_response_gtin();
                    res.gtin = dataReader[0].ToString();
                    res.descripcion_impresion = dataReader[1].ToString();
                    res.descripcion_usuario = dataReader[2].ToString();
                    res.especie = dataReader[3].ToString();
                    res.tipo = dataReader[4].ToString();
                    res.ean = dataReader[5].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class DB_response_gtin
    {
        public String gtin;
        public String descripcion_impresion;
        public String descripcion_usuario;
        public String especie;
        public String tipo;
        public String ean;
    }
    public class DB_request_gtin
    {
        public String nada;
    }
}