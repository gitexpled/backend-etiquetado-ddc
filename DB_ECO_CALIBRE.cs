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
    public class DB_ECO_CALIBRE
    {
        public responce_ECO_CALIBRE run(request_ECO_CALIBRE datos)
        {
            responce_ECO_CALIBRE res = new responce_ECO_CALIBRE();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String jss = datos.Calibre;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Data"];
            JObject item;
            int aux = 0;
            String sql = "";
            // JToken jtoken;
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                //Convert.ToInt32();
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = connection;
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd = new SqlCommand("ECO_CALIBRE_DB", connection);
                    /*cmd.Parameters.Add(new SqlParameter("@productor", item["usuario"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@especie", item["usuario"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@variedad", item["usuario"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@tipo", item["usuario"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@valor", item["usuario"].ToString()));*/
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    res.ok = "Todo Bien ";
                }
                catch (Exception e)
                {
                    res.error = e.ToString();
                }

            }
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class responce_ECO_CALIBRE
    {
        public String error;
        public String ok;
    }
    public class request_ECO_CALIBRE
    {
        public String Calibre;
        public String Productor;
        public String Especie;
    }
}