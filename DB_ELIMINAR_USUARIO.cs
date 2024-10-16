using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_ELIMINAR_usuario
    {
        public responce_eliminar_usuario run(request_eliminar_usuario datos)
        {
            responce_eliminar_usuario res = new responce_eliminar_usuario();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("DELETE_USUARIO", connection);
                cmd.Parameters.Add(new SqlParameter("@id", datos.ID));
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
            cmd.Dispose();
            return res;
        }
    }

    public class responce_eliminar_usuario
    {
        public String error;
        public String ok;
    }
    public class request_eliminar_usuario
    {
        public String ID;
    }
}