using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_RFC_READ_TABLE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RFC_READ_TABLE sap = new RFC_READ_TABLE();
            request_RFC_READ_TABLE imp = new request_RFC_READ_TABLE();
            imp.QUERY_TABLE = Request["QUERY_TABLE"].ToString();
            imp.DELIMITER = ";";
            responce_RFC_READ_TABLE obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}