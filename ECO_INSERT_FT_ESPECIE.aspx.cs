using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_INSERT_FT_ESPECIE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_INSERT_FT_ESPECIE ValorSemanaA = new DB_ECO_INSERT_FT_ESPECIE();
            request_DB_ECO_INSERT_FT_ESPECIE vs = new request_DB_ECO_INSERT_FT_ESPECIE();
            vs.id = Server.UrlDecode(Request["id"]);
            vs.productor = Server.UrlDecode(Request["c"]);
            vs.especie = Server.UrlDecode(Request["e"]);
            vs.tipo_certificacion = Server.UrlDecode(Request["t"]);
            vs.gobla_gap_number = Server.UrlDecode(Request["g"]);
            vs.ggn_desde = Server.UrlDecode(Request["ggd"]);
            vs.cuartel = Server.UrlDecode(Request["cu"]);
            vs.ggn_hasta = Server.UrlDecode(Request["ggh"]);
            responce_DB_ECO_INSERT_FT_ESPECIE resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}