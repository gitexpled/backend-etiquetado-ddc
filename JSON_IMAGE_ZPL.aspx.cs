using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_IMAGE_ZPL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String sol = Request["req"];
            DB_IMAGE image = new DB_IMAGE();
            request_IMAGE img = new request_IMAGE();
            img.Solicitud =  sol;
            Array resp = image.run(img);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}