using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_ELIMINAR_ESTIMACION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Server.UrlDecode(Request["id"]);
            DB_ECO_ELIMINAR_ESTIMACION ValorSemanaA = new DB_ECO_ELIMINAR_ESTIMACION();
            request_DB_ECO_ELIMINAR_ESTIMACION vs = new request_DB_ECO_ELIMINAR_ESTIMACION();
            vs.id = id;
            responce_DB_ECO_ELIMINAR_ESTIMACION resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}