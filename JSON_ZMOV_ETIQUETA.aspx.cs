using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_ETIQUETA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String et = Server.UrlDecode(Request["eti"]);
            //String n = Request["n"];
            String proceso = Request["prd"].ToString();
            String centro = Request["c"].ToString();
            String posicion = Request["pos"].ToString();
            String estado = Request["es"].ToString();
            String id = Request["id"].ToString();

            String idzpl = Request["z"].ToString();
            String zpl = Request["zpl"].ToString();
            String stock = Request["s"].ToString();
            String IDposicion = Request["idp"].ToString();
            String ip_zebra = Request["iz"].ToString();
            DB_ETIQUETA etiqueta = new DB_ETIQUETA();
            request_etiqueta req = new request_etiqueta();
            req.jsn = et;
            req.Proceso = proceso;
            req.Centro = centro;
            req.Posicion = posicion;
            req.Estado = estado;
            req.id = id;
            req.idZPL = idzpl;
            req.zpl = zpl;
            req.stock = stock;
            req.IDPosicion = IDposicion;
            req.ip_Zebra = ip_zebra;
            responce_etiqueta resp = etiqueta.run(req);
            //var json2 = new JavaScriptSerializer().Serialize(resp);
            //json.Text = json2.ToString();

            var json2 = new JavaScriptSerializer();
            json2.MaxJsonLength = Int32.MaxValue;
            json.Text = json2.Serialize(resp).ToString();
         
        }
    }
}