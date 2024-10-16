using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public partial class JSON_PRINT_ZPL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                String n = Server.UrlDecode(Request.Form["n"]);
                DB_VISTA V = new DB_VISTA();
                request_vista v = new request_vista();
                v.jsn = n;
                responce_vista resp = V.run(v);
                var json2 = new JavaScriptSerializer().Serialize(resp);
                json.Text = json2.ToString();
        }
    }
}