
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
    public class DB_ECO_AGREGAR_ANHO
    {
        public responce_ECO_AGREGAR_ANHO run(request_ECO_AGREGAR_ANHO datos)
        {
            responce_ECO_AGREGAR_ANHO res = new responce_ECO_AGREGAR_ANHO();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("AGREGAR_ANHO", connection);
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
    public class responce_ECO_AGREGAR_ANHO
    {
        public String error;
        public String ok;
    }
    public class request_ECO_AGREGAR_ANHO
    {
        
    }
}