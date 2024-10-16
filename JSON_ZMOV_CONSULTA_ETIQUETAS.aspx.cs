using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_CONSULTA_ETIQUETAS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Proceso = Request["p"].ToString();
            DB_CONSULTA_ETIQUETAS etiq = new DB_CONSULTA_ETIQUETAS();
            request_consulta_etiquetas consulta = new request_consulta_etiquetas();
            consulta.Proceso = Proceso;
            Array res = etiq.run(consulta);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}