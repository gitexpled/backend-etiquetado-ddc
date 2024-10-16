using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMF_GET_DAT_PROD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String I_ESPECIE = "";
            if (Request["I_ESPECIE"] != null)
            {
                I_ESPECIE = Request["I_ESPECIE"].ToString();
            }
            String I_LIFNR = "";
            if (Request["I_LIFNR"] != null)
            {
                I_LIFNR = Request["I_LIFNR"].ToString();
            }




            ZMF_GET_DAT_PROD sap = new ZMF_GET_DAT_PROD();
            request_ZMF_GET_DAT_PROD imp = new request_ZMF_GET_DAT_PROD();
            imp.I_ESPECIE = I_ESPECIE;
            imp.I_LIFNR = I_LIFNR;

            responce_ZMF_GET_DAT_PROD obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}