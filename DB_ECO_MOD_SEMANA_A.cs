using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_ECO_MOD_SEMANA_A
    {
        public responce_ECO_MOD_SEMANA_A run(request_ECO_ECO_MOD_SEMANA_A datos)
        {
            responce_ECO_MOD_SEMANA_A res = new responce_ECO_MOD_SEMANA_A();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String jss = datos.Semana;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Data"];
            JObject item;
            var sql = "";
            // JToken jtoken;
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                //Convert.ToInt32();
                try
                {
                    for (int x = 0; x < 4; x++)
                    {
                        sql = "update ECO_ANUAL set S" + item["s1"]["semana"].ToString() + " = " + item["s1"]["valor"].ToString() + ", S" + item["s2"]["semana"].ToString() + " = " + item["s2"]["valor"].ToString() + ","+
                                                    " S" + item["s3"]["semana"].ToString() + " = " + item["s3"]["valor"].ToString() + ", S" + item["s4"]["semana"].ToString() + " = " + item["s4"]["valor"].ToString() + " "+
                                                    " Where id = " + item["id"].ToString() + " and variedad='" + item["variedad"].ToString() + "'";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Connection = connection;
                        cmd.CommandTimeout = 0;
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        dataReader.Close();
                    }
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
    public class responce_ECO_MOD_SEMANA_A
    {
        public String error;
        public String ok;
    }
    public class request_ECO_ECO_MOD_SEMANA_A
    {
        public String Semana;
    }
}