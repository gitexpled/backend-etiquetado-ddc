using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_CALIBRE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String VSemana = Server.UrlDecode(Request["Cal"]);
            String productor = Request["p"].ToString();
            String especie = Request["E"].ToString();
            DB_ECO_CALIBRE ValorSemana = new DB_ECO_CALIBRE();
            request_ECO_CALIBRE vs = new request_ECO_CALIBRE();
            vs.Calibre = VSemana;
            vs.Productor = productor;
            vs.Especie = especie;
            responce_ECO_CALIBRE resp = ValorSemana.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}