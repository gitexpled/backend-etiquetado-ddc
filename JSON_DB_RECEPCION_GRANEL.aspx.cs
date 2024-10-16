using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public partial class JSOn_DB_RECEPCION_GRANEL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ReceptGranel = (Request["ReceptG"] != null) ? Request["ReceptG"].ToString() : "";
            String DatosGen = (Request["dato"] != null) ? Request["dato"].ToString() : "";
            String patente = (Request["patente"] != null) ? Request["patente"].ToString() : "";
            String proceso = (Request["proceso"] != null) ? Request["proceso"].ToString() : "";
            String especie = (Request["especie"] != null) ? Request["especie"].ToString() : "";
            string result = "";
            if (proceso == "nuevaRecepcion")
            {
                result = crearRecepcion(especie, ReceptGranel, DatosGen, patente);
            }
            if (proceso == "listaRecepcion")
            {
                result = getListaRecepcion(especie);
            }

            var json2 = "";//new JavaScriptSerializer().Serialize(obj);
            json.Text = result;
        }
        public string getListaRecepcion(string especie)
        {
            string lista = "[";
            String _connectionStringd = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connectiond = new SqlConnection(_connectionStringd);
            connectiond.Open();
            String sql2 = "select TOP 50 * from recepciones_granel where especie ='" + especie + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, connectiond);
            cmd2.Connection = connectiond;
            cmd2.CommandTimeout = 0;
            SqlDataReader dataReader = cmd2.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    lista += "{\"especie\":\"" + dataReader[1].ToString() + "\",";
                    lista += "\"patente\":\"" + dataReader[4].ToString() + "\",";
                    lista += "\"recepGranel\":" + dataReader[2].ToString() + ",";
                    lista += "\"datosCer\":" + dataReader[3].ToString() + "}";

                    lista += ",";

                }
            }
            lista += "]";
            lista = lista.Replace(",]", "]");
            cmd2.Dispose();
            connectiond.Dispose();
            connectiond.Close();
            return lista;
        }
        public string crearRecepcion(string especie, string recepGranel, string DatosGen, string patente)
        {
            String _connectionStringd = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connectiond = new SqlConnection(_connectionStringd);
            connectiond.Open();
            String sql2 = "insert into recepciones_granel(especie,recepGranel,datosCer,patente)values('" + especie + "','" + recepGranel + "','" + DatosGen + "','" + patente + "')";
            SqlCommand cmd2 = new SqlCommand(sql2, connectiond);
            cmd2.Connection = connectiond;
            cmd2.CommandTimeout = 0;
            SqlDataReader dataReader2 = cmd2.ExecuteReader();
            cmd2.Dispose();
            connectiond.Dispose();
            connectiond.Close();
            return "{\"result\":0,\"message\":\"Recepcion Guardada Correctamente\"}";
        }
    }
}