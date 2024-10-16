using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_CONSULTA_PROCESOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Planta = Request["P"].ToString();
            DB_CONSULTA_PROCESOS pr = new DB_CONSULTA_PROCESOS();
            request_CONSULTA_PROCESOS req = new request_CONSULTA_PROCESOS();
            req.Planta = Planta;
            Array res = pr.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}