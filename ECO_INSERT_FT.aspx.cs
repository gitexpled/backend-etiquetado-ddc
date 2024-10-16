using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_INSERT_FT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_INSERT_FT ValorSemanaA = new DB_ECO_INSERT_FT();
            request_DB_ECO_INSERT_FT vs = new request_DB_ECO_INSERT_FT();
            vs.productor = Server.UrlDecode(Request["productor"]);
            vs.nombre = Server.UrlDecode(Request["nombre"]); 
            vs.huerto = Server.UrlDecode(Request["huerto"]); 
            vs.csg = Server.UrlDecode(Request["csg"]); 
            vs.idp = Server.UrlDecode(Request["idp"]); 
            vs.georeferenciacion = Server.UrlDecode(Request["georeferenciacion"]); 
            vs.usuario = Server.UrlDecode(Request["usuario"]); 
            vs.temporada = Server.UrlDecode(Request["temporada"]); 

            vs.especie = Server.UrlDecode(Request["especie"]);
            vs.cuartel = Server.UrlDecode(Request["cuartel"]); 
            vs.tipo_cert = Server.UrlDecode(Request["tipo_cert"]); 
            vs.ggn = Server.UrlDecode(Request["ggn"]); 
            vs.ggnd = Server.UrlDecode(Request["ggnd"]); 
            vs.ggnh = Server.UrlDecode(Request["ggnh"]); 

            vs.variedad = Server.UrlDecode(Request["variedad"]);
            vs.dise = Server.UrlDecode(Request["dise"]); 
            vs.diss = Server.UrlDecode(Request["diss"]); 
            vs.arb = Server.UrlDecode(Request["arb"]);
            vs.plantas_ha = Server.UrlDecode(Request["plantas_ha"]); 
            vs.superficie = Server.UrlDecode(Request["superficie"]); 
            vs.plan_totales = Server.UrlDecode(Request["plan_totales"]); 
            vs.ano_plan = Server.UrlDecode(Request["ano_plan"]);
            vs.uniformidad = Server.UrlDecode(Request["uniformidad"]); 
            vs.central_cargo = Server.UrlDecode(Request["central_cargo"]); 
            vs.tipo_packing = Server.UrlDecode(Request["tipo_packing"]); 
            vs.tipo_riesgo = Server.UrlDecode(Request["tipo_riesgo"]); 
            vs.cspv = Server.UrlDecode(Request["cspv"]); 
            vs.idpv = Server.UrlDecode(Request["idpv"]);
            vs.idft = Server.UrlDecode(Request["idft"]);
            responce_DB_ECO_INSERT_FT resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}