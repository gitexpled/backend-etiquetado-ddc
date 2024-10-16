using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_CONSULTA_ETIQUETA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Centro = Request["c"].ToString();
            DB_CONSULTA_ETIQUETA etiq = new DB_CONSULTA_ETIQUETA();
            request_consulta_etiqueta consulta = new request_consulta_etiqueta();
            consulta.centro = Centro;
            Array res = etiq.run(consulta);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}