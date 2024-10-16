using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_CONSULTA_G_FT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_CONSULTA_G_FT db = new DB_ECO_CONSULTA_G_FT();
            request_ECO_CONSULTA_G_FT req = new request_ECO_CONSULTA_G_FT();
            req.CODIGO = Request["c"].ToString();
            req.TEMPORADA = Request["t"].ToString();
            req.USUARIO  = Request["us"].ToString();
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}