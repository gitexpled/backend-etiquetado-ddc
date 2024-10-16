using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_CONSULTA_PRODUCTOR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_CONSULTA_PRODUCTOR db = new DB_ECO_CONSULTA_PRODUCTOR();
            request_ECO_CONSULTA_PRODUCTOR req = new request_ECO_CONSULTA_PRODUCTOR();
            req.CODIGO = Request["c"].ToString();
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}