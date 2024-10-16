using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections;

namespace rfcBaika
{
    public partial class JSON_DB_MONITOR_PANTALLA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String centro = Request["CENTRO"].ToString();


            DB_MONITOR_PANTALLA sap = new DB_MONITOR_PANTALLA();
            
            ArrayList obj = sap.run(centro);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}