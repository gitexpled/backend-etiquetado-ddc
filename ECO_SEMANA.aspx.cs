using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_SEMANA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String VSemana =  Server.UrlDecode(Request["VS"]);
            //String Consulta = Request["cn"].ToString();
            String id = Request["id"].ToString();
            String data = Request["data"].ToString();
            String semana = Request["sm"].ToString();
            String kilo = Request["kilo"].ToString();
            String calibre = Request["calibre"].ToString();
            String calibre2 = Request["calibre2"].ToString();
            String tipificacion = Request["tipificacion"].ToString();
            String tipofrio = Request["tipofrio"].ToString();
            String tipificacion2 = Request["tipificacion2"].ToString();
            String tipofrio2 = Request["tipofrio2"].ToString();
            String hcalibre = Request["hcalibre"].ToString();
            String htipificacion = Request["htipificacion"].ToString();
            String htipofrio = Request["htipofrio"].ToString();
            DB_ECO_SEMANA ValorSemana = new DB_ECO_SEMANA();
            request_ECO_VALOR_SEMANA vs = new request_ECO_VALOR_SEMANA();
            vs.data = data;
            vs.id = id;
            vs.semana = semana;
            vs.kilo = kilo;
            vs.calibre = calibre;
            vs.calibre2 = calibre2;
            vs.hcalibre = hcalibre;
            vs.tipificacion = tipificacion;
            vs.tipificacion2 = tipificacion2;
            vs.htipificacion = htipificacion;
            vs.tipofrio = tipofrio;
            vs.tipofrio2 = tipofrio2;
            vs.htipofrio = htipofrio;
            responce_ECO_VALOR_SEMANA resp = ValorSemana.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}