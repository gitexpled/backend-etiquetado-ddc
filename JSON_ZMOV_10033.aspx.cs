using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10033 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String XBLNR = Request["XBLNR"].ToString();
            String LIFNR = Request["LIFNR"].ToString();
            ZMOV_10033 sap = new ZMOV_10033();
            request_ZMOV_10033 item = new request_ZMOV_10033();
            item.I_LIFNR = LIFNR;
            item.I_XBLNR = XBLNR;
            responce_ZMOV_10033 obj = sap.sapRun(item);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}