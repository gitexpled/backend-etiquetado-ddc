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
    public partial class JSON_CONFIG_LINEA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String n = Server.UrlDecode(Request.Form["n"]);
            //DB_VISTA V = new DB_VISTA();
            //request_vista v = new request_vista();
            //v.jsn = n;JSON_CONFIG_LINEA
            //responce_vista resp = V.run(v);JSON_CONFIG_LINEA
            string resp = System.IO.File.ReadAllText(@"/temp/json.txt");

            //var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = resp.ToString();
        }
    }
}