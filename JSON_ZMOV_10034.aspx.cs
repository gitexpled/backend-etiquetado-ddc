using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10034 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String EXIDV = Request["EXIDV"].ToString();
            ZMOV_10034 sap = new ZMOV_10034();
            request_ZMOV_10034 item = new request_ZMOV_10034();
            ZMOV_10034_IR_EXIDV[] exidv = new ZMOV_10034_IR_EXIDV[1];
            exidv[0] = new ZMOV_10034_IR_EXIDV();
            exidv[0].HIGH = EXIDV;
            exidv[0].LOW = EXIDV;
            exidv[0].OPTION = "NB";
            exidv[0].SIGN = "E";
            item.IR_EXIDV = exidv;
            responce_ZMOV_10034 obj = sap.sapRun(item);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}