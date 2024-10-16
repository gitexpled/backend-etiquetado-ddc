using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_FT_VARIEDAD
    {
        public Array run(request_ECO_CONSULTA_FT_VARIEDAD datos)
        {
            List<responce_ECO_CONSULTA_FT_VARIEDAD> List = new List<responce_ECO_CONSULTA_FT_VARIEDAD>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT variedad,tipo_packing FROM especie_variedad ";
            
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
                    responce_ECO_CONSULTA_FT_VARIEDAD res = new responce_ECO_CONSULTA_FT_VARIEDAD();
                    res.variedad = dataReader[0].ToString();
                    res.tipo_packing = dataReader[1].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_FT_VARIEDAD
    {
        public String variedad;
        public String tipo_packing;
       
    }
    public class request_ECO_CONSULTA_FT_VARIEDAD
    {


    }
}