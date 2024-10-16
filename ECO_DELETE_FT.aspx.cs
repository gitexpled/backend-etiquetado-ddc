using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_DELETE_FT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_DELETE_FT ValorSemanaA = new DB_ECO_DELETE_FT();
            request_DB_ECO_DELETE_FT vs = new request_DB_ECO_DELETE_FT();
            vs.idft = Server.UrlDecode(Request["idft"]);
            responce_DB_ECO_DELETE_FT resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}