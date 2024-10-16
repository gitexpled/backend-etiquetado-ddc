using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_INSERT_FT_VARIEDAD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_INSERT_FT_VARIEDAD ValorSemanaA = new DB_ECO_INSERT_FT_VARIEDAD();
            request_DB_ECO_INSERT_FT_VARIEDAD vs = new request_DB_ECO_INSERT_FT_VARIEDAD();
            vs.id = Server.UrlDecode(Request["id"]);
            vs.id_especie = Server.UrlDecode(Request["ie"]);
            vs.variedad = Server.UrlDecode(Request["va"]);
            vs.dis_entre_hileras = Server.UrlDecode(Request["eh"]);
            vs.dis_sobre_hileras = Server.UrlDecode(Request["sh"]);
            vs.arb_productivos = Server.UrlDecode(Request["ap"]);
            vs.planta_por_ha = Server.UrlDecode(Request["ph"]);
            vs.superficie = Server.UrlDecode(Request["su"]);
            vs.plantas_totales = Server.UrlDecode(Request["pt"]);
            vs.ano_plantacion = Server.UrlDecode(Request["a"]);
            vs.uniformidad = Server.UrlDecode(Request["u"]);
            vs.central_cargo = Server.UrlDecode(Request["cc"]);
            vs.tipo_packing = Server.UrlDecode(Request["tp"]);
            vs.tipo_riesgo = Server.UrlDecode(Request["tr"]);
            vs.csp = Server.UrlDecode(Request["csp"]);
            vs.idp = Server.UrlDecode(Request["idp"]);

            responce_DB_ECO_INSERT_FT_VARIEDAD resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}