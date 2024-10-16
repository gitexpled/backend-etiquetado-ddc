using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Web.Script.Serialization;
using System.IO;

namespace rfcBaika
{
    public class DB_VISTA
    {
        public responce_vista run(request_vista datos)
        {
            responce_vista res = new responce_vista();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String jss = datos.jsn;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Enviar"];
            JObject item;
            int aux = items.Count - 1;
            String sql = "";
            // JToken jtoken;
            int auxEntero = 2;
            if (datos.Estado == "modifi")
            {
                //  sql = "UPDATE posicion_zpl SET estado = 'antiguo' where centro = '" + datos.Centro + "'";
                // sql = "delete from posicion_zpl where centro = '" +datos.Centro+"'";
                for (int i = 0; i < auxEntero; i++)
                {
                    /*if (i == 0)
                    {
                        sql = "delete from zpl_ventana where Line = "+datos.linea+"";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Connection = connection;
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        dataReader.Close();
                    }*/
                    if (i == 1)
                    {
                        sql = "delete from posicion_zpl where centro = '" + datos.Centro + "' and linea_zpl = "+datos.linea+"";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.Connection = connection;
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        dataReader.Close();
                    }

                }

            }
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];

                sql = "INSERT INTO posicion_zpl (id_zpl, ip_pantalla, linea_zpl, fila_zpl, pantalla_zpl,pantalla,centro) VALUES (" + item["id_zpl"].ToString() + ",'" + item["ip_pantalla"].ToString() + "'," + item["linea_zpl"].ToString() + "," + item["fila_zpl"].ToString() + "," + item["Pantalla_zpl"].ToString() + ",'" + item["Pantalla"].ToString() + "','" + item["centro"].ToString() + "');";

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Close();
                    if (i == aux) { res.ok = "Todo Bien " + aux; }
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
    public class request_vista
    {
        public String jsn;
        public String Estado;
        public String Centro;
        public String linea;
    }
    public class responce_vista
    {
        public String ok;
        public String error;
    }
}