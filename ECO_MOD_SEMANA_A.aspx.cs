using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_MOD_SEMANA_A : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String VSemana = Server.UrlDecode(Request["ING"]);
            DB_ECO_MOD_SEMANA_A ValorSemana = new DB_ECO_MOD_SEMANA_A();
            request_ECO_ECO_MOD_SEMANA_A vs = new request_ECO_ECO_MOD_SEMANA_A();
            vs.Semana = VSemana;
            responce_ECO_MOD_SEMANA_A resp = ValorSemana.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}