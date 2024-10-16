using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_CARGA_INICIAL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String centro = Request["c"].ToString();
            String proceso = Request["p"].ToString();
            DB_CARGA_INICIAL ci = new DB_CARGA_INICIAL();
            request_CARGA_INICIAL req = new request_CARGA_INICIAL();
            req.PROCESO = proceso;
            req.CENTRO = centro;
            Array res = ci.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}