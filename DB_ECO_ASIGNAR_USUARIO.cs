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
    public class DB_ECO_ASIGNAR_USUARIO
    {
        public responce_ECO_ASIGNAR_USUARIO run(request_ECO_ASIGNAR_USUARIO datos)
        {
            responce_ECO_ASIGNAR_USUARIO res = new responce_ECO_ASIGNAR_USUARIO();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("RELACION_USUARIO", connection);
                cmd.Parameters.Add(new SqlParameter("@especie", datos.especie+","));
                cmd.Parameters.Add(new SqlParameter("@productor", datos.productor));
                cmd.Parameters.Add(new SqlParameter("@usuario", datos.usuario+","));
                cmd.Parameters.Add(new SqlParameter("@estimacion", datos.estimacion));
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
    public class responce_ECO_ASIGNAR_USUARIO
    {
        public String error;
        public String ok;
    }
    public class request_ECO_ASIGNAR_USUARIO
    {
        public String especie;
        public String productor;
        public String usuario;
        public String estimacion;
    }
}