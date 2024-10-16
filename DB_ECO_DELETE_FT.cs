
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
    public class DB_ECO_DELETE_FT
    {
        public responce_DB_ECO_DELETE_FT run(request_DB_ECO_DELETE_FT datos)
        {
            responce_DB_ECO_DELETE_FT res = new responce_DB_ECO_DELETE_FT();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("DELETE_FICHA_TECNICA", connection);             
                cmd.Parameters.Add(new SqlParameter("@idft", datos.idft));
  
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
    public class responce_DB_ECO_DELETE_FT
    {
        public String error;
        public String ok;
    }
    public class request_DB_ECO_DELETE_FT
    {
      
        public String idft;
    
    
    }
}