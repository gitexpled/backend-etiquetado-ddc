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
    public class DB_ESTRUCTURA_RE
    {
        public responce_ESTRUCTURA_RE run(request_ESTRUCTURA_RE datos)
        {
            responce_ESTRUCTURA_RE res = new responce_ESTRUCTURA_RE();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            String jss = datos.jsn;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Enviar"];
            JObject item;
            // JToken jtoken;
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                try
                {
                    cmd = new SqlCommand("ESTRUCTURA_RE", connection);
                    cmd.Parameters.Add(new SqlParameter("@id_zpl", Int32.Parse(item["id_zpl"].ToString())));
                    cmd.Parameters.Add(new SqlParameter("@ip_pantalla", item["ip_pantalla"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@linea_zpl", Int32.Parse(item["linea_zpl"].ToString())));
                    cmd.Parameters.Add(new SqlParameter("@fila_zpl", Int32.Parse(item["fila_zpl"].ToString())));
                    cmd.Parameters.Add(new SqlParameter("@pantalla_zpl", item["Pantalla_zpl"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@pantalla", item["Pantalla"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@centro", item["centro"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@zpl", item["zpl"].ToString()));
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
                    cmd.Parameters.Add(new SqlParameter("@salida", item["salida"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@turno", item["turno"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@lpack", item["lpack"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@tipoEmbalaje", item["tipoEmbalaje"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@codmatKilos", float.Parse(item["codmatKilos"].ToString())));
                    cmd.Parameters.Add(new SqlParameter("@variedadVal", item["variedadVal"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@calidad", item["calidad"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@tfrio", item["tfrio"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@consulta", datos.consulta));
                    cmd.Parameters.Add(new SqlParameter("@envaein14IMP", item["envaein14IMP"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@upc", item["upc"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@ean13", item["ean13"].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@id", Int32.Parse(item["id"].ToString())));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Close();
                    res.ok = "Todo Bien";
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
    public class request_ESTRUCTURA_RE
    {
        public String jsn;
        public String consulta;
    }
    public class responce_ESTRUCTURA_RE
    {
        public String ok;
        public String error;
    }
}