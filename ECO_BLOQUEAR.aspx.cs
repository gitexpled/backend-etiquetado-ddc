using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_BLOQUEAR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ESTADO = Server.UrlDecode(Request["E"]);
            DB_ECO_BLOQUEAR ValorSemanaA = new DB_ECO_BLOQUEAR();
            request_ECO_BLOQUEAR vs = new request_ECO_BLOQUEAR();
            vs.estado = ESTADO;
            responce_ECO_BLOQUEAR resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}