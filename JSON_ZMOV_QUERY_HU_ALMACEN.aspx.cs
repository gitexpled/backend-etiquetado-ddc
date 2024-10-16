using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_HU_ALMACEN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ZMOV_QUERY_HU_ALMACEN sap = new ZMOV_QUERY_HU_ALMACEN();
            request_ZMOV_QUERY_HU_ALMACEN imp = new request_ZMOV_QUERY_HU_ALMACEN();
            responce_ZMOV_QUERY_HU_ALMACEN obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}