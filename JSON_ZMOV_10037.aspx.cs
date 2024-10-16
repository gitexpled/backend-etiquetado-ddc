using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10037 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ZMOV_10037 sap = new ZMOV_10037();
            request_ZMOV_10037 imp = new request_ZMOV_10037();
            if (Request["ZZ_NUMTRA"] != null)
            {
                ZMOV_10037_IT_NUMTRA[] dat = new ZMOV_10037_IT_NUMTRA[1];
                dat[0] = new ZMOV_10037_IT_NUMTRA();
                dat[0].ZZ_NUMTRA = Request["ZZ_NUMTRA"].ToString();
                imp.IT_NUMTRA = dat;
            }
            if (Request["IT_FECTRAD"] != null && Request["IT_FECTRAH"] != null)
            {
                ZMOV_10037_IT_FECTRA[] dat = new ZMOV_10037_IT_FECTRA[1];
                dat[0] = new ZMOV_10037_IT_FECTRA();
                dat[0].LOW =  Request["IT_FECTRAD"].ToString();
                dat[0].HIGH = Request["IT_FECTRAH"].ToString();
                dat[0].OPTION = "BT";
                dat[0].SIGN = "I";
                imp.IT_FECTRA = dat;
            }
            responce_ZMOV_10037 obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}