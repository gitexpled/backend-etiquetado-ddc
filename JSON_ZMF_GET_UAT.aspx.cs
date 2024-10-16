using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMF_GET_UAT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String ATKLA = Request["ATKLA"].ToString();
            // String WERKS = Request["WERKS"].ToString();

            ZMF_GET_UAT sap = new ZMF_GET_UAT();
            request_ZMF_GET_UAT imp = new request_ZMF_GET_UAT();
            responce_ZMF_GET_UAT obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}