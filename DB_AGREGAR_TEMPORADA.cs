
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
    public class DB_AGREGAR_TEMPORADA
    {
        public responce_AGREGAR_TEMPORADA run(String temporada)
        {
            responce_AGREGAR_TEMPORADA res = new responce_AGREGAR_TEMPORADA();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("AGREGAR_TEMPORADA", connection);
                cmd.Parameters.Add(new SqlParameter("@temporada", temporada));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();



                dr.Close();
                res.ok = "Todo Bien ";
            }
            catch (Exception e)
            {
                res.error = e.ToString();
            }
                
            
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class responce_AGREGAR_TEMPORADA
    {
        public String error;
        public String ok;
    }
    public class request_AGREGAR_TEMPORADA
    {
        
    }
}