using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_ANUAL_SEMANA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String VSAnual = Server.UrlDecode(Request["VSA"]);
            DB_ECO_ANUAL_SEMANA ValorSemanaA = new DB_ECO_ANUAL_SEMANA();
            request_ECO_ANUAL_SEMANA vs = new request_ECO_ANUAL_SEMANA();
            vs.Semana = VSAnual;
            vs.Calibre = Server.UrlDecode(Request["CALIBRE"]);
            vs.HCalibre = Server.UrlDecode(Request["Hcalibre"]);
            vs.Ingreso = Server.UrlDecode(Request["INGRESO"]);
            vs.Tipificacion = Server.UrlDecode(Request["TIPIFICACION"]);
            vs.HTipificacion = Server.UrlDecode(Request["HTIPIFICACION"]);
            vs.Tipofrio = Server.UrlDecode(Request["TIPOFRIO"]);
            vs.Kilo = Server.UrlDecode(Request["KILO"]);
            vs.Ano = Server.UrlDecode(Request["ANO"]);
            vs.SM1 = Server.UrlDecode(Request["SM1"]);
            vs.SM2 = Server.UrlDecode(Request["SM2"]);
             responce_ECO_ANUAL_SEMANA resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}