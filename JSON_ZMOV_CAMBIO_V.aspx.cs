using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_CAMBIO_V : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String proceso = Request["p"].ToString();
            DB_CAMBIO_V change = new DB_CAMBIO_V();
            request_cambio_v req = new request_cambio_v();
            req.Proceso = proceso;
            responce_cambio_v res = change.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}