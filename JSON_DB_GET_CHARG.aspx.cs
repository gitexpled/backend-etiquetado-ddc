using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_GET_CHARG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Lote_Proceso = Request["lp"].ToString();
            DB_GET_CHARG getCharg = new DB_GET_CHARG();
            request_GET_CHARG req = new request_GET_CHARG();
            req.lote = Lote_Proceso;
            Array res = getCharg.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}