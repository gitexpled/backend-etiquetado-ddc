using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_ELIMINAR_USUARIO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ELIMINAR_usuario ValorSemanaA = new DB_ELIMINAR_usuario();
            request_eliminar_usuario vs = new request_eliminar_usuario();
            vs.ID = Server.UrlDecode(Request["id"]);
            responce_eliminar_usuario resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}