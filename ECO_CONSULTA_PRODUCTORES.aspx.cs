using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_CONSULTA_PRODUCTORES : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_CONSULTA_PRODUCTORES db = new DB_ECO_CONSULTA_PRODUCTORES();
            request_ECO_CONSULTA_PRODUCTORES req = new request_ECO_CONSULTA_PRODUCTORES();
            req.TEMPORADA = Request["t"].ToString();
            req.CODIGO = Request["c"].ToString();
            req.NOMBRE = Request["n"].ToString();
            req.RUT = Request["r"].ToString();
            req.PLANTA = Request["p"].ToString();
            req.USUARIO = Request["u"].ToString();
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}