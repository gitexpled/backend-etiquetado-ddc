using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public partial class JSON_VISTA_ZPL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                String n = Server.UrlDecode(Request["n"]);
                //String n = Request["n"];
                String estado = Request["e"].ToString();
                String centro = Request["c"].ToString();
                String Linea = Request["l"].ToString();
                DB_VISTA V = new DB_VISTA();
                request_vista v = new request_vista();
                v.jsn = n;
                v.Estado = estado;
                v.Centro = centro;
                v.linea = Linea;
                responce_vista resp = V.run(v);
                var json2 = new JavaScriptSerializer().Serialize(resp);
                json.Text = json2.ToString();
        }
    }
}