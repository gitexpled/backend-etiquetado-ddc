
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
    public class DB_ECO_INSERT_FT_HIJO
    {
        public responce_DB_ECO_INSERT_FT_HIJO run(request_DB_ECO_INSERT_FT_HIJO datos)
        {
            responce_DB_ECO_INSERT_FT_HIJO res = new responce_DB_ECO_INSERT_FT_HIJO();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("INSERT_HIJO_PRD", connection);
                cmd.Parameters.Add(new SqlParameter("@id", datos.productor));
                cmd.Parameters.Add(new SqlParameter("@productor", datos.productor));
                cmd.Parameters.Add(new SqlParameter("@hijo", datos.hijo));
                cmd.Parameters.Add(new SqlParameter("@nombre", datos.nombre));
                cmd.Parameters.Add(new SqlParameter("@huerto", datos.huerto));
                cmd.Parameters.Add(new SqlParameter("@csg", datos.csg));
                cmd.Parameters.Add(new SqlParameter("@idp", datos.idp));
                cmd.Parameters.Add(new SqlParameter("@georeferenciacion", datos.georeferenciacion));
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
    public class responce_DB_ECO_INSERT_FT_HIJO
    {
        public String error;
        public String ok;
    }
    public class request_DB_ECO_INSERT_FT_HIJO
    {
        public String id;
        public String productor;
        public String hijo;
        public String nombre;
        public String huerto;
        public String csg;
        public String idp;
        public String georeferenciacion;
    }
}