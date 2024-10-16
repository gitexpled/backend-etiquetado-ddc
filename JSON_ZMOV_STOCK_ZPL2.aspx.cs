using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_STOCK_ZPL2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idzpl = Request["z"].ToString();
            String zpl = Request["zpl"].ToString();
            String stock = Request["s"].ToString();
            String posicion = Request["p"].ToString();
            String proceso = Request["pr"].ToString();
            String kilos = Request["k"].ToString();
            String consulta = Request["consul"].ToString();
            String linea = Request["l"].ToString();
            String ip_zebra = Request["iz"].ToString();
            String salida = Request["sal"].ToString();
            String calibre = Request["cal"].ToString();
            String Tipo_Material = Request["TM"].ToString();
            String ID_etiqueta = Request["IE"].ToString();
            DB_STOCK_CONSULTA_ZPL2 db = new DB_STOCK_CONSULTA_ZPL2();
            request_DB_CONSULTA_STOCK_ZPL2 cons = new request_DB_CONSULTA_STOCK_ZPL2();
            cons.id = idzpl;
            cons.zpl = zpl;
            cons.stock = stock;
            cons.posicion = posicion;
            cons.proceso = proceso;
            cons.kilos = kilos;
            cons.consulta = consulta;
            cons.line = linea;
            cons.ip_zebra = ip_zebra;
            cons.exit = salida;
            cons.Calibre = calibre;
            cons.T_material = Tipo_Material;
            cons.id_etiqueta = ID_etiqueta;
            responce_DB_STOCK_CONSULTA_ZPL2 resp = db.run(cons);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}