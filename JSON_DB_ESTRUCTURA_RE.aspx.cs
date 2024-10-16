using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_ESTRUCTURA_RE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Estructura = Server.UrlDecode(Request["e"]);
            String Consulta = Request["c"].ToString();
            DB_ESTRUCTURA_RE EL = new DB_ESTRUCTURA_RE();
            request_ESTRUCTURA_RE es = new request_ESTRUCTURA_RE();
            es.jsn = Estructura;
            es.consulta = Consulta;
            responce_ESTRUCTURA_RE resp = EL.run(es);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}