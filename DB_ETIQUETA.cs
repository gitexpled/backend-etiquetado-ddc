using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public class DB_ETIQUETA
    {
        public responce_etiqueta run(request_etiqueta datos)
        {
            responce_etiqueta res = new responce_etiqueta();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String jss = datos.jsn;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["etiqueta"];
            JObject item;
            int aux = items.Count - 1;
            String sql = "";
            // JToken jtoken;
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = connection;
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd = new SqlCommand("PRDETIQUETA", connection);
                    cmd.Parameters.Add(new SqlParameter("@Proceso", datos.Proceso));
                    cmd.Parameters.Add(new SqlParameter("@Centro", datos.Centro));
                    cmd.Parameters.Add(new SqlParameter("@Especie", item["especie"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Variedad", item["variedad"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@grsmunit", item["grsmunit"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@countapp", item["countapp"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@nom1calibre", item["nom1calibre"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@glosalibre", item["glosalibre"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@productor", item["productor"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@gglote", item["gglote"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@compprod", item["compprod"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@proproduc", item["proproduc"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@prodesc", item["prodesc"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@CSG", item["CSG"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@IDG", item["IDG"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@SDP", item["SDP"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@envain14", item["envain14"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@embasex14", item["embasex14"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@dun14", item["dun14"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@lotegti", item["lotegti"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@nomfrut", item["nomfrut"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@comfrut", item["comfrut"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@provfrut", item["provfrut"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@cspfrut", item["cspfrut"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@idpfrut", item["idpfrut"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@fdafrut", item["fdafrut"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@kilos", item["kilos"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@diametro", item["diametro"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@codmat", item["codmat"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@nlote", item["nlote"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@fechprd", item["fechprd"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@fechapprd", item["fechapprd"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@voickb", item["voickb"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@voicka", item["voicka"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@correlativo", item["correlativo"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@salida", item["salida"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@turno", item["turno"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@lpack", item["lpack"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Posicion", datos.Posicion));
                    cmd.Parameters.Add(new SqlParameter("@tipoEmbalaje", item["tipoEmbalaje"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@codmatKilos", item["codmatKilos"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@variedadVal", item["variedadVal"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@calidad", item["calidad"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@tfrio", item["tfrio"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@upc", item["upc"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@ean13", item["ean13"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Estado", datos.Estado));
                    cmd.Parameters.Add(new SqlParameter("@envaein14IMP", item["envaein14IMP"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@id", Int32.Parse(datos.id)));
                    cmd.Parameters.Add(new SqlParameter("@id_ZPL", Int32.Parse(datos.idZPL)));
                   /* var date = DateTime.Now;
                    var HH = (date.Hour < 10) ? "0" + date.Hour.ToString() : date.Hour.ToString();
                    var MM = (date.Minute < 10) ? "0" + date.Minute.ToString() : date.Minute.ToString();
                    var hora = HH + ":" + MM;
                    var zpl = datos.zpl.Replace("@HORA", hora);
                    zpl = datos.zpl.Replace("@hora", hora);*/
                    cmd.Parameters.Add(new SqlParameter("@zpl", datos.zpl));
                    cmd.Parameters.Add(new SqlParameter("@stock", Int32.Parse(datos.stock)));
                    cmd.Parameters.Add(new SqlParameter("@idPosicion", Int32.Parse(datos.IDPosicion)));
                    cmd.Parameters.Add(new SqlParameter("@ip_zebra", datos.ip_Zebra));
                    cmd.Parameters.Add(new SqlParameter("@LINE", Int32.Parse(item["lpack"].ToString())));
                    cmd.Parameters.Add(new SqlParameter("@kilosMat", float.Parse(item["codmatKilos"].ToString())));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        res.val = dr[0].ToString();


                    }
                    res.ok = res.val; 
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
    public class request_etiqueta
    {
        public String jsn;
        public String Proceso;
        public String Centro;
        public String Posicion;
        public String Estado;
        public String id;
        public String idZPL;
        public String zpl;
        public String stock;
        public String IDPosicion;
        public String ip_Zebra;
    }
    public class responce_etiqueta
    {
        public String ok;
        public String val;
        public String error;
    }
}