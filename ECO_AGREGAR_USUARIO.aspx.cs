using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_AGREGAR_USUARIO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ano = Server.UrlDecode(Request["a"]);
            String estimacion = Server.UrlDecode(Request["e"]);
            DB_ECO_AGREGAR_USUARIO ValorSemanaA = new DB_ECO_AGREGAR_USUARIO();
            request_DB_ECO_AGREGAR_USUARIO vs = new request_DB_ECO_AGREGAR_USUARIO();
            vs.ID = Server.UrlDecode(Request["id"]);
            vs.USUARIO = Server.UrlDecode(Request["u"]);
            vs.PASSWORD = Server.UrlDecode(Request["p"]);
            vs.NOMBRE = Server.UrlDecode(Request["n"]);
            vs.APELLIDO = Server.UrlDecode(Request["a"]);
            responce_DB_ECO_AGREGAR_USUARIO resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}