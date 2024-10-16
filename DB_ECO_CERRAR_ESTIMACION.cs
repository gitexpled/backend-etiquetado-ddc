
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
    public class DB_ECO_CERRAR_ESTIMACION
    {
        public responce_ECO_CERRAR_ESTIMACION run(request_ECO_CERRAR_ESTIMACION datos)
        {
            responce_ECO_CERRAR_ESTIMACION res = new responce_ECO_CERRAR_ESTIMACION();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("CERRAR_ESTIMACION", connection);
                cmd.Parameters.Add(new SqlParameter("@estimacion", datos.estimacion));
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
    public class responce_ECO_CERRAR_ESTIMACION
    {
        public String error;
        public String ok;
    }
    public class request_ECO_CERRAR_ESTIMACION
    {
        public String especie;
        public String productor;
        public String variedad;
        public String usuario;
        public String centro;
        public String estimacion;
        public String ano;
    }
}