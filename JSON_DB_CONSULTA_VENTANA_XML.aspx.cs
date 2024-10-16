using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_CONSULTA_VENTANA_XML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ip = Request["ip"].ToString();
            DB_CONSULTA_ETIQUETA_VENTANA ventana = new DB_CONSULTA_ETIQUETA_VENTANA();
            request_CONSULTA_ETIQUETA_VENTANA req = new request_CONSULTA_ETIQUETA_VENTANA();
            req.Ip = ip;
            Array res = ventana.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}