using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_CONSULTA_HISTORICO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String centro = Request["c"].ToString();
            String productor = Request["p"].ToString();
            String especie = Request["e"].ToString();
            String usuario = Request["US"].ToString();
            String variedad = Request["v"].ToString();
            DB_ECO_CONSULTA_HISTORICO db = new DB_ECO_CONSULTA_HISTORICO();
            request_ECO_CONSULTA_HISTORICO req = new request_ECO_CONSULTA_HISTORICO();
            req.CENTRO = centro;
            req.PRODUCTOR = productor;
            req.ESPECIE = especie;
            req.USUARIO = usuario;
            req.VARIEDAD = variedad;
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}