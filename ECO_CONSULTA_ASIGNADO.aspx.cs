using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_CONSULTA_ASIGNADO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String especie   = Request["ESPECIE"].ToString();
            String productor = Request["PRODUCTOR"].ToString();
            String usuario  = Request["USUARIO"].ToString();
            DB_ECO_CONSULTA_ASIGNADO db = new DB_ECO_CONSULTA_ASIGNADO();
            request_ECO_CONSULTA_ASIGNADO req = new request_ECO_CONSULTA_ASIGNADO();
            req.ESPECIE = especie;
            req.PRODUCTOR = productor;
            req.USUARIO = usuario;
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}