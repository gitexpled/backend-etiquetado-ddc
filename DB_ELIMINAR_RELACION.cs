using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_ELIMINAR_relacion
    {
        public responce_eliminar_relacion run(request_eliminar_relacion datos)
        {
            responce_eliminar_relacion res = new responce_eliminar_relacion();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("DELETE_RELACION_USUARIO", connection);
                cmd.Parameters.Add(new SqlParameter("@especie", datos.ESPECIE));
                cmd.Parameters.Add(new SqlParameter("@productor", datos.PRODUCTOR));
                cmd.Parameters.Add(new SqlParameter("@usuario", datos.USUARIO));
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

    public class responce_eliminar_relacion
    {
        public String error;
        public String ok;
    }
    public class request_eliminar_relacion
    {
        public String PRODUCTOR;
        public String ESPECIE;
        public String USUARIO;
    }
}