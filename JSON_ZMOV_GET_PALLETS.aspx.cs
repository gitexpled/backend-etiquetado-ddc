using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_GET_PALLETS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ZMOV_GET_PALLETS sap = new ZMOV_GET_PALLETS();
            request_ZMOV_GET_PALLETS imp = new request_ZMOV_GET_PALLETS();
            responce_ZMOV_GET_PALLETS obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}