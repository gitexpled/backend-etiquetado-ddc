using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_GET_CHARG
    {
        public Array run(request_GET_CHARG datos)
        {
            
            List<responce_GET_CHARG> List = new List<responce_GET_CHARG>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select DISTINCT CHARG from PROCESOS where LOTEPROCESO ='" + datos.lote + "' and CHARG != '" + datos.lote + "';";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            int i = 0;
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_GET_CHARG res = new responce_GET_CHARG();
                    res.charg = dataReader[0].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            return List.ToArray();

        }
    }
    public class responce_GET_CHARG
    {
        public String charg;
        
    }
    public class request_GET_CHARG
    {
        public String lote;
    }
}