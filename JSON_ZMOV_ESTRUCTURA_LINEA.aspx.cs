using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_ESTRUCTURA_LINEA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Estructura = Server.UrlDecode(Request["e"]);
            String Consulta = Request["c"].ToString();
            DB_ESTRUCTURA_LINEA EL = new DB_ESTRUCTURA_LINEA();
            request_estructura es = new request_estructura();
            es.jsn = Estructura;
            es.consulta = Consulta;
            responce_estructura resp = EL.run(es);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}