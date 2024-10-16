using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10006 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String MATNR = Request["MATNR"].ToString();
            String VENDOR = Request["VENDOR"].ToString();
            String PO = "";
            if (Request["PO"] != null) {
                PO = Request["PO"].ToString();
            }
            
            String PLANT = Request["PLANT"].ToString();

            // String WERKS = Request["WERKS"].ToString();

            ZMOV_10006 sap = new ZMOV_10006();
            request_ZMOV_10006 imp = new request_ZMOV_10006();
            
            imp.VENDOR = VENDOR;
            imp.PLANT = PLANT;
            imp.MATERIAL = MATNR;

            if (PO == "")
            {
                imp.ITEMS_OPEN_FOR_RECEIPT = "X";
            }
            else {
                imp.PURCHASEORDER = PO;
            }
            



            responce_ZMOV_10006 obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}