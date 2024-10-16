
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
    public class DB_ECO_AGREGAR_USUARIO
    {
        public responce_DB_ECO_AGREGAR_USUARIO run(request_DB_ECO_AGREGAR_USUARIO datos)
        {
            responce_DB_ECO_AGREGAR_USUARIO res = new responce_DB_ECO_AGREGAR_USUARIO();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("AGREGAR_USUARIO", connection);
                cmd.Parameters.Add(new SqlParameter("@id", datos.ID));
                cmd.Parameters.Add(new SqlParameter("@usuario", datos.USUARIO));
                cmd.Parameters.Add(new SqlParameter("@password", datos.PASSWORD));
                cmd.Parameters.Add(new SqlParameter("@nombre", datos.NOMBRE));
                cmd.Parameters.Add(new SqlParameter("@apellido", datos.APELLIDO));   
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
    public class responce_DB_ECO_AGREGAR_USUARIO
    {
        public String error;
        public String ok;
    }
    public class request_DB_ECO_AGREGAR_USUARIO
    {
        public String ID;
        public String USUARIO;
        public String PASSWORD;
        public String NOMBRE;
        public String APELLIDO;

    }
}