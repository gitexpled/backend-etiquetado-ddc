using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public partial class JSON_SP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String row = Server.UrlDecode(Request["input"]);
            DB_SP db = new DB_SP();
            //responce_db_sp resp = db.run(Request);
            //var json2 = new JavaScriptSerializer().Serialize(resp);
            //json.Text = json2.ToString();
            //var json2 = new JavaScriptSerializer();
            //json2.MaxJsonLength = Int32.MaxValue;
            // json = resp.ToString(Newtonsoft.Json.Formatting.None);
            //json.Text = resp.ToString(Newtonsoft.Json.Formatting.None);

            var json2 = new JavaScriptSerializer();
            json2.MaxJsonLength = Int32.MaxValue;
            json.Text = json2.Serialize(row).ToString();
         
        }
    }
}