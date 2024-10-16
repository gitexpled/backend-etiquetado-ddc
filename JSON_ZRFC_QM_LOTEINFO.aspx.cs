using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZRFC_QM_LOTEINFO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String CHARG = Request["CHARG"].ToString();
            // String WERKS = Request["WERKS"].ToString();

            ZRFC_QM_LOTEINFO sap = new ZRFC_QM_LOTEINFO();
            request_ZRFC_QM_LOTEINFO imp = new request_ZRFC_QM_LOTEINFO();
            imp.I_BUKRS = "DC01";
            imp.I_CHARG = CHARG;
            responce_ZRFC_QM_LOTEINFO obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}