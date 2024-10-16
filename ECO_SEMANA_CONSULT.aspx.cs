using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_SEMANA_CONSULT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String centro = Request["c"].ToString();
            String productor = Request["p"].ToString();
            String especie = Request["e"].ToString();
            String usuario = Request["US"].ToString();
            String semana = Request["s"].ToString();
            DB_SEMANA_CONSULT db = new DB_SEMANA_CONSULT();
            request_SEMANA_CONSULT req = new request_SEMANA_CONSULT();
            req.CENTRO = centro;
            req.PRODUCTOR = productor;
            req.ESPECIE = especie;
            req.USUARIO = usuario;
            //req.VARIEDAD = Request["v"].ToString();
            req.SEMANA = semana;
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}