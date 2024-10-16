using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMF_GET_USER : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String I_UNAME = Request["I_UNAME"].ToString();
            String WERKS = Request["WERKS"].ToString();

            ZMF_GET_USER sap = new ZMF_GET_USER();
            request_ZMF_GET_USER imp = new request_ZMF_GET_USER();
            imp.I_UNAME = I_UNAME;
            ZMF_GET_USER_LT_DET_USER data = new ZMF_GET_USER_LT_DET_USER();
            imp.LT_DET_USER = new ZMF_GET_USER_LT_DET_USER[1];
            data.UNAME = I_UNAME;
            data.WERKS = WERKS;
            imp.LT_DET_USER[0] = data;
            responce_ZMF_GET_USER obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}