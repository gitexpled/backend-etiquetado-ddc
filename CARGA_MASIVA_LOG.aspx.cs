using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class CARGA_MASIVA_LOG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String data = Server.UrlDecode(Request["Data"]);
            DB_LOG_CARGA_MASIVA DataLog = new DB_LOG_CARGA_MASIVA();
            request_LOG_CARGA_MASIVA vs = new request_LOG_CARGA_MASIVA();
            vs.Data = data;
            responce_LOG_CARGA_MASIVA resp = DataLog.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}