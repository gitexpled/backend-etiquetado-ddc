using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_INSERT_FT_HIJO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_INSERT_FT_HIJO ValorSemanaA = new DB_ECO_INSERT_FT_HIJO();
            request_DB_ECO_INSERT_FT_HIJO vs = new request_DB_ECO_INSERT_FT_HIJO();
            vs.id = Server.UrlDecode(Request["id"]);
            vs.productor = Server.UrlDecode(Request["c"]);
            vs.hijo = Server.UrlDecode(Request["h"]);
            vs.nombre = Server.UrlDecode(Request["n"]);
            vs.huerto = Server.UrlDecode(Request["hu"]);
            vs.csg = Server.UrlDecode(Request["csg"]);
            vs.idp = Server.UrlDecode(Request["idp"]);
            vs.georeferenciacion = Server.UrlDecode(Request["g"]);
            responce_DB_ECO_INSERT_FT_HIJO resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}