using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class GET_NRO_PROCESO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_GET_NRO_PROCESO ValorSemanaA = new DB_GET_NRO_PROCESO();
            string resp = ValorSemanaA.run();
            //var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = resp.ToString();
        }
    }
}