using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_SAG_EXTRAE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String EXIDV2 = "";
            if (Request["EXIDV2"] != null)
            {
                EXIDV2 = Request["EXIDV2"].ToString();
            }



            ZMOV_SAG_EXTRAE sap = new ZMOV_SAG_EXTRAE();
            request_ZMOV_SAG_EXTRAE imp = new request_ZMOV_SAG_EXTRAE();
            imp.EXIDV2 = EXIDV2;
            responce_ZMOV_SAG_EXTRAE obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}