using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_STOCK_CONSULTA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ok = Request["ok"].ToString();
            DB_STOCK_CONSULTA consulta = new DB_STOCK_CONSULTA();
            request_DB_CONSULTA_STOCK cons = new request_DB_CONSULTA_STOCK();
            cons.Solicitud = ok;
            Array resp = consulta.run(cons);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}