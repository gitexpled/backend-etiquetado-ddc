using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_PRODUCTOR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String KTOKK = Request["KTOKK"].ToString();
            // String WERKS = Request["WERKS"].ToString();

            ZMOV_QUERY_PRODUCTOR sap = new ZMOV_QUERY_PRODUCTOR();
            request_ZMOV_QUERY_PRODUCTOR imp = new request_ZMOV_QUERY_PRODUCTOR();
            imp.I_KTOKK  = KTOKK;
            imp.I_COUNTRY = "CL";
            
            responce_ZMOV_QUERY_PRODUCTOR obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}