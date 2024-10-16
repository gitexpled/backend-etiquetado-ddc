
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
    public class DB_ECO_CERRAR_ANHO
    {
        public responce_ECO_CERRAR_ANHO run(request_ECO_CERRAR_ANHO datos)
        {
            responce_ECO_CERRAR_ANHO res = new responce_ECO_CERRAR_ANHO();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("CERRAR_ANHO", connection);
                cmd.Parameters.Add(new SqlParameter("@ano", datos.ano));              
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
    public class responce_ECO_CERRAR_ANHO
    {
        public String error;
        public String ok;
    }
    public class request_ECO_CERRAR_ANHO
    {
        public String ano;
    }
}