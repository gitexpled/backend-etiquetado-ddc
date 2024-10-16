using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_ELIMINAR_TODO
    {
        public responce_eliminar_todo run(request_eliminar_todo datos)
        {
            responce_eliminar_todo res = new responce_eliminar_todo();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("ELIMINAR_TODO", connection);
                cmd.Parameters.Add(new SqlParameter("@proceso", datos.PROCESO));
                cmd.Parameters.Add(new SqlParameter("@centro", datos.CENTRO));
                cmd.Parameters.Add(new SqlParameter("@aux", Convert.ToInt32(datos.AUX)));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    res.resp = dr[0].ToString();


                }
            }
            catch (Exception e)
            {
                res.resp = e.ToString();
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return res;
        }
    }
    public class responce_eliminar_todo
    {
        public String resp;
    }
    public class request_eliminar_todo
    {
        public String PROCESO;
        public String CENTRO;
        public String AUX;
    }
}