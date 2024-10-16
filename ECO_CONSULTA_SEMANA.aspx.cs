using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_CONSULTA_SEMANA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String centro = Request["c"].ToString();
            String productor = Request["p"].ToString();
            String especie = Request["e"].ToString();
            String variedad = Request["v"].ToString();
            String s1 = Request["s1"].ToString();
            String s2 = Request["s2"].ToString();
            DB_ECO_CONSULTA_SEMANA db = new DB_ECO_CONSULTA_SEMANA();
            request_ECO_CONSULTA_SEMANA req = new request_ECO_CONSULTA_SEMANA();
            req.Centro = centro;
            req.Productor = productor;
            req.Especie = especie;
            req.Variedad = variedad;
            req.Semana1 = s1;
            req.Semana2 = s2;
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}