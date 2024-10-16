using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_PANTALLAS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String centro = Request["c"].ToString();
            DB_PANTALLAS consulta = new DB_PANTALLAS();            
            request_pantallas cons = new request_pantallas();
            cons.Solicitud = centro;
            Array resp = consulta.run(cons);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}