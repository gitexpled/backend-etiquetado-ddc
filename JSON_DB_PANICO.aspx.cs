using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_PANICO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String proceso = Request["p"].ToString();
            String centro = Request["c"].ToString();
            String salida = Request["s"].ToString();
            DB_PANICO change = new DB_PANICO();
            request_PANICO req = new request_PANICO();
            req.Proceso = proceso;
            req.Centro = centro;
            req.Salida = salida;
            responce_PANICO res = change.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}