using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_DESACTIVAR_PROCESOS
    {
        public responce_DB_DESACTIVAR_PROCESOS run(request_DB_DESACTIVAR_PROCESOS datos)
        {
            responce_DB_DESACTIVAR_PROCESOS res = new responce_DB_DESACTIVAR_PROCESOS();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("Desactivar_procesos", connection);
                cmd.Parameters.Add(new SqlParameter("@planta", datos.PLANTA));
                cmd.Parameters.Add(new SqlParameter("@usuario", datos.USUARIO));
                cmd.Parameters.Add(new SqlParameter("@ip_pantalla", datos.IP_PANTALLA));
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
    public class responce_DB_DESACTIVAR_PROCESOS
    {
        public String resp;

    }
    public class request_DB_DESACTIVAR_PROCESOS
    {
        public String PLANTA;
        public String USUARIO;
        public String IP_PANTALLA;

    }
}