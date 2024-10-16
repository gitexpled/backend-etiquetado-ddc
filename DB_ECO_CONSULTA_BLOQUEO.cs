using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_BLOQUEO
    {
        public Array run(request_ECO_CONSULTA_BLOQUEO datos)
        {
            List<responce_ECO_CONSULTA_BLOQUEO> List = new List<responce_ECO_CONSULTA_BLOQUEO>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT * FROM bloqueado";
 
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
                    responce_ECO_CONSULTA_BLOQUEO res = new responce_ECO_CONSULTA_BLOQUEO();
                    res.ESTADO = dataReader[0].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_BLOQUEO
    {
        public String ESTADO;
       
    }
    public class request_ECO_CONSULTA_BLOQUEO
    {


    }
}