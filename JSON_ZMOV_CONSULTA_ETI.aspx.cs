using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_CONSULTA_ETI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Centro = Request["c"].ToString();
            DB_ETIQUETA_STOCK etiq = new DB_ETIQUETA_STOCK();
            request_ETIQUETA_STOCK consulta = new request_ETIQUETA_STOCK();
            consulta.centro = Centro;
            Array res = etiq.run(consulta);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}