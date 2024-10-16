using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMF_GET_CENTRO_APP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String ATKLA = Request["ATKLA"].ToString();
            String IR_WERKS = Request["IR_WERKS"].ToString();

            ZMF_GET_CENTRO_APP sap = new ZMF_GET_CENTRO_APP();
            request_ZMF_GET_CENTRO_APP imp = new request_ZMF_GET_CENTRO_APP();
            imp.IR_WERKS = IR_WERKS;
            responce_ZMF_GET_CENTRO_APP obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}