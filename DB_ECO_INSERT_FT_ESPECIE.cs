
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
    public class DB_ECO_INSERT_FT_ESPECIE
    {
        public responce_DB_ECO_INSERT_FT_ESPECIE run(request_DB_ECO_INSERT_FT_ESPECIE datos)
        {
            responce_DB_ECO_INSERT_FT_ESPECIE res = new responce_DB_ECO_INSERT_FT_ESPECIE();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("INSERT_ESPECIE", connection);
                cmd.Parameters.Add(new SqlParameter("@id", datos.id));
                cmd.Parameters.Add(new SqlParameter("@productor", datos.productor));
                cmd.Parameters.Add(new SqlParameter("@especie", datos.especie));
                cmd.Parameters.Add(new SqlParameter("@cuartel", datos.cuartel));
                cmd.Parameters.Add(new SqlParameter("@tipo_certificacion", datos.tipo_certificacion));
                cmd.Parameters.Add(new SqlParameter("@gobla_gap_number", datos.gobla_gap_number));
                cmd.Parameters.Add(new SqlParameter("@ggn_desde", datos.ggn_desde));
                cmd.Parameters.Add(new SqlParameter("@ggn_hasta", datos.ggn_hasta));   
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
    public class responce_DB_ECO_INSERT_FT_ESPECIE
    {
        public String error;
        public String ok;
    }
    public class request_DB_ECO_INSERT_FT_ESPECIE
    {
        public String id;
        public String productor;
        public String especie;
        public String cuartel;
        public String tipo_certificacion;
        public String gobla_gap_number;
        public String ggn_desde;
        public String ggn_hasta;
    }
}