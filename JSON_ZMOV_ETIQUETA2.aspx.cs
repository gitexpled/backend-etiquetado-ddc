using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_ETIQUETA2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String et = Server.UrlDecode(Request["eti"]);
            String proceso = Request["prd"].ToString();
            String centro = Request["c"].ToString();
            String posicion = Request["pos"].ToString();
            String estado = Request["es"].ToString();
            String id = Request["id"].ToString();
            DB_ETIQUETA2 etiqueta = new DB_ETIQUETA2();
            request_etiqueta2 req = new request_etiqueta2();
            req.jsn = et;
            req.Proceso = proceso;
            req.Centro = centro;
            req.Posicion = posicion;
            req.Estado = estado;
            req.id = id;
            responce_etiqueta2 resp = etiqueta.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}