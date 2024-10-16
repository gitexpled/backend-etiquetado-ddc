using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_ELIMINAR_RELACION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ELIMINAR_relacion ValorSemanaA = new DB_ELIMINAR_relacion();
            request_eliminar_relacion vs = new request_eliminar_relacion();
            vs.PRODUCTOR = Server.UrlDecode(Request["p"]);
            vs.ESPECIE = Server.UrlDecode(Request["e"]);
            vs.USUARIO = Server.UrlDecode(Request["u"]);
            responce_eliminar_relacion resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}