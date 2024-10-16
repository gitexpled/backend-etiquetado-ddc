using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class CARGA_MASIVA_CONSULTA_LOG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String desde = Request["desde"].ToString();
            String hasta = Request["hasta"].ToString();
            String tipo = Request["tipo"].ToString();
            DB__CARGA_MASIVA_CONSULA_LOG db = new DB__CARGA_MASIVA_CONSULA_LOG();
            request_CARGA_MASIVA_CONSULA_LOG req = new request_CARGA_MASIVA_CONSULA_LOG();
            req.fecha_desde = desde;
            req.fecha_hasta = hasta;
            req.tipo = tipo;
            Array resp = db.run(req);
            //var json2 = new JavaScriptSerializer().Serialize(resp);
            var json2 = new JavaScriptSerializer();
            json2.MaxJsonLength = Int32.MaxValue;
            json.Text = json2.Serialize(resp).ToString();
            //json.Text = json2.ToString();
        }
    }
}