using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMF_PAGOS_PRODUCTORES_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String KTOKK = Request["KTOKK"].ToString();
            // String WERKS = Request["WERKS"].ToString();

            ZMF_PAGOS_PRODUCTORES sap = new ZMF_PAGOS_PRODUCTORES();
            request_ZMF_PAGOS_PRODUCTORES imp = new request_ZMF_PAGOS_PRODUCTORES();
            imp.I_DATE_FROM = Request["I_DATE_FROM"].ToString();
            imp.I_DATE_TO = Request["I_DATE_TO"].ToString();
            imp.I_RUT = Request["I_RUT"].ToString();

            responce_ZMF_PAGOS_PRODUCTORES obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}