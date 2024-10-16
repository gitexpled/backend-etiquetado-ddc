using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_STOCK_PROCESO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String LOTEPROCESO = "";
            if (Request["LOTEPROCESO"] != null)
            {
                LOTEPROCESO = Request["LOTEPROCESO"].ToString();
            }



            ZMOV_QUERY_STOCK_PROCESO sap = new ZMOV_QUERY_STOCK_PROCESO();
            request_ZMOV_QUERY_STOCK_PROCESO imp = new request_ZMOV_QUERY_STOCK_PROCESO();
            imp.LOTEPROCESO = LOTEPROCESO;
            responce_ZMOV_QUERY_STOCK_PROCESO obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}