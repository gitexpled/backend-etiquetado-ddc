using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_PANICO
    {
        public responce_PANICO run(request_PANICO datos)
        {
            responce_PANICO res = new responce_PANICO();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("PANICO", connection);
                cmd.Parameters.Add(new SqlParameter("@proceso", datos.Proceso));
                cmd.Parameters.Add(new SqlParameter("@centro", datos.Centro));
                cmd.Parameters.Add(new SqlParameter("@salida", Convert.ToInt32(datos.Salida)));
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
     public class request_PANICO
    {
        public String Proceso;
        public String Centro;
        public String Salida;
    }
    public class responce_PANICO
    {
        public String resp;
    }
}