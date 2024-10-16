using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_HU_READ_EXIDV2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String EXIDV2 = Request["EXIDV2"].ToString();
            // String WERKS = Request["WERKS"].ToString();

            ZMOV_QUERY_HU_READ_EXIDV2 sap = new ZMOV_QUERY_HU_READ_EXIDV2();
            request_ZMOV_QUERY_HU_READ_EXIDV2 imp = new request_ZMOV_QUERY_HU_READ_EXIDV2();
            imp.EXIDV2 = EXIDV2;
            responce_ZMOV_QUERY_HU_READ_EXIDV2 obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}