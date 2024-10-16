using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_ASIGNAR_USUARIO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String especie = Server.UrlDecode(Request["e"]);
            String productor = Server.UrlDecode(Request["p"]);
            String usuario = Server.UrlDecode(Request["u"]);
            String estimacion = Server.UrlDecode(Request["estimacion"]);
            DB_ECO_ASIGNAR_USUARIO ValorSemanaA = new DB_ECO_ASIGNAR_USUARIO();
            request_ECO_ASIGNAR_USUARIO vs = new request_ECO_ASIGNAR_USUARIO();
            vs.especie = especie;
            vs.productor = productor;
            vs.usuario = usuario;
            vs.estimacion = estimacion;
            responce_ECO_ASIGNAR_USUARIO resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}