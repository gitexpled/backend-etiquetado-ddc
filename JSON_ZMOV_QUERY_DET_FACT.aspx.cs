using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_DET_FACT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String DESDE = Request["DESDE"].ToString();
            String HASTA = Request["HASTA"].ToString();


            ZMOV_QUERY_DET_FACT sap = new ZMOV_QUERY_DET_FACT();
            request_ZMOV_QUERY_DET_FACT imp = new request_ZMOV_QUERY_DET_FACT();

            ZMOV_QUERY_DET_FACT_I_VBELN[] I_VBELN = new ZMOV_QUERY_DET_FACT_I_VBELN[1];
            I_VBELN[0] = new ZMOV_QUERY_DET_FACT_I_VBELN();
            I_VBELN[0].LOW = DESDE;
            I_VBELN[0].HIGH = HASTA;
            I_VBELN[0].SIGN = "I";
            I_VBELN[0].OPTION = "BT";

            imp.I_VBELN = I_VBELN;





            responce_ZMOV_QUERY_DET_FACT obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}