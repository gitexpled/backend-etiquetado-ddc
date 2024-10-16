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
    public class DB_ECO_INGRESOS
    {
        public responce_ECO_INGRESOS run(request_ECO_INGRESOS datos)
        {
            responce_ECO_INGRESOS res = new responce_ECO_INGRESOS();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String jss = datos.ingresos;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Data"];
            JObject item;
            // JToken jtoken;
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                //Convert.ToInt32();
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = connection;
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd = new SqlCommand("ECO_INGRESOS", connection);
                    cmd.Parameters.Add(new SqlParameter("@usuario", item["usuario"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@productor", item["Productor"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@especie", item["especie"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@variedad", item["variedad"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@exportacion", item["exportacion"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@merma", item["merma"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@comercial", item["comercial"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@centro", item["centro"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@fecha", item["Fecha"].ToString()));
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
    public class responce_ECO_INGRESOS
    {
        public String error;
        public String ok;
    }
    public class request_ECO_INGRESOS
    {
        public String ingresos;
    }
}