using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10021 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String IV_MATNR = Request["IV_MATNR"].ToString();
           // String IV_STLAL_PALLET = Request["IV_STLAL_PALLET"].ToString();
            String IV_WERKS = Request["IV_WERKS"].ToString();
            ZMOV_10021 sap = new ZMOV_10021();
            request_ZMOV_10021 imp = new request_ZMOV_10021();
            imp.IV_MATNR = IV_MATNR;
            imp.IV_STLAL_PALLET = "99";
            imp.IV_WERKS = IV_WERKS;
            responce_ZMOV_10021 obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}