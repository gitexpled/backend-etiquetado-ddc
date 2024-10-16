using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_ANO
    {
        public Array run(request_ECO_CONSULTA_ANO datos)
        {
            List<responce_ECO_CONSULTA_ANO> List = new List<responce_ECO_CONSULTA_ANO>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT * FROM eco_ano order by ano desc";
            
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
                    responce_ECO_CONSULTA_ANO res = new responce_ECO_CONSULTA_ANO();
                    res.ANO = dataReader[1].ToString();
                    res.ESTIMACION = dataReader[2].ToString();
                    res.ESTADO = dataReader[3].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_ANO
    {
        public String ANO;
        public String ESTIMACION;
        public String ESTADO;
       
    }
    public class request_ECO_CONSULTA_ANO
    {


    }
}