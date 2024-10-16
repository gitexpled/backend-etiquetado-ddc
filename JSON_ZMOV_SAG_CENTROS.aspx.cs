using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_SAG_CENTROS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String ATKLA = Request["ATKLA"].ToString();
            String I_BUKRS = Request["I_BUKRS"].ToString();

            ZMOV_SAG_CENTROS sap = new ZMOV_SAG_CENTROS();
            request_ZMOV_SAG_CENTROS imp = new request_ZMOV_SAG_CENTROS();
            imp.I_BUKRS = I_BUKRS;
            responce_ZMOV_SAG_CENTROS obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}