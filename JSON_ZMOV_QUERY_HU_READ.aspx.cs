using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_HU_READ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String ATKLA = Request["ATKLA"].ToString();
            String HUKEY = Request["HUKEY"].ToString();

            ZMOV_QUERY_HU_READ sap = new ZMOV_QUERY_HU_READ();
            request_ZMOV_QUERY_HU_READ imp = new request_ZMOV_QUERY_HU_READ();
            imp.HUKEY = HUKEY;
            responce_ZMOV_QUERY_HU_READ obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}