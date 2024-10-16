using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_ESPECIE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String ATKLA = Request["ATKLA"].ToString();
            // String WERKS = Request["WERKS"].ToString();

            ZMOV_QUERY_ESPECIE sap = new ZMOV_QUERY_ESPECIE();
            request_ZMOV_QUERY_ESPECIE imp = new request_ZMOV_QUERY_ESPECIE();
            responce_ZMOV_QUERY_ESPECIE obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}