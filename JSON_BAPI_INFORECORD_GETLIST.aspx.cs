using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_BAPI_INFORECORD_GETLIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String MATERIAL = Request["MATERIAL"].ToString();
            String PLANT = Request["PLANT"].ToString();
            String VENDOR = Request["VENDOR"].ToString();
            BAPI_INFORECORD_GETLIST sap = new BAPI_INFORECORD_GETLIST();
            request_BAPI_INFORECORD_GETLIST imp = new request_BAPI_INFORECORD_GETLIST();
            imp.MATERIAL = MATERIAL;
            imp.PLANT = PLANT;
            imp.VENDOR = VENDOR;
            responce_BAPI_INFORECORD_GETLIST obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}