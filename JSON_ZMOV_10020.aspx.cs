using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10020 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String IV_MATNR = Request["IV_MATNR"].ToString();
            String IV_WERKS = Request["IV_WERKS"].ToString();
            String IV_HU_GRP4 = Request["IV_HU_GRP4"].ToString();
            String IV_TIP_PACKING = Request["IV_TIP_PACKING"].ToString();
            String IV_STLAL_PALLET="99";
            if (Request["IV_STLAL_PALLET"] != null)
            {
                IV_STLAL_PALLET = Request["IV_STLAL_PALLET"].ToString();
            }
            ZMOV_10020 sap = new ZMOV_10020();
            request_ZMOV_10020 imp = new request_ZMOV_10020();
            imp.IV_MATNR = IV_MATNR;
            imp.IV_WERKS = IV_WERKS;
            imp.IV_HU_GRP4 = IV_HU_GRP4;
            imp.IV_TIP_PACKING = IV_TIP_PACKING;
            imp.IV_STLAL_PALLET = IV_STLAL_PALLET;
            responce_ZMOV_10020 obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}