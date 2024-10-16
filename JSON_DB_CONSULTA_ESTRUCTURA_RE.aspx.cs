using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_CONSULTA_ESTRUCTURA_RE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Centro = Request["C"].ToString();
            DB_CONSULTA_ESTRUCTURA_RE pr = new DB_CONSULTA_ESTRUCTURA_RE();
            request_CONSULTA_ESTRUCTURA_RE req = new request_CONSULTA_ESTRUCTURA_RE();
            req.centro = Centro;
            Array res = pr.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}