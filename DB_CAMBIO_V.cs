using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_CAMBIO_V
    {
        public responce_cambio_v run(request_cambio_v datos)
        {
            responce_cambio_v res = new responce_cambio_v();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "update proceso set estado = 'VIGENTE' where proceso = '"+datos.Proceso+"'";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Close();
            res.res = "ok";
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class request_cambio_v
    {
        public String Proceso;
    }
    public class responce_cambio_v
    {
        public String res;
    }
}