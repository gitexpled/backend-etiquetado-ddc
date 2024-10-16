using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_PROCESO_ALL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_PROCESO_ALL pr = new DB_PROCESO_ALL();
            request_Proceso req = new request_Proceso();
            Array res = pr.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}