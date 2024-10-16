using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_TERMINADO_MANUAL
    {
        public DB_responce_terminado_manual run(DB_request_terminado_manual datos)
        {
            DB_responce_terminado_manual res = new DB_responce_terminado_manual();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("Terminado_manual", connection);
                cmd.Parameters.Add(new SqlParameter("@proceso", datos.Proceso));
                cmd.Parameters.Add(new SqlParameter("@centro", datos.Centro));
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
            return res;
        }
    }
    public class DB_request_terminado_manual
    {
        public String Proceso;
        public String Centro;
    }
    public class DB_responce_terminado_manual
    {
        public String resp;
    }
}