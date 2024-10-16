using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_ETIQUETA_CONSULTA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request["id"].ToString();
            DB_ETIQUETA_CONSULTA ventana = new DB_ETIQUETA_CONSULTA();
            request_ETIQUETA_CONSULTA req = new request_ETIQUETA_CONSULTA();
            req.ID = id;
            Array res = ventana.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}