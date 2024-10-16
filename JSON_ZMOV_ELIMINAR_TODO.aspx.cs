using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_ELIMINAR_TODO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Proceso = Request["p"].ToString();
            String Centro = Request["c"].ToString();
            String aux = Request["a"].ToString();
            DB_ELIMINAR_TODO el = new DB_ELIMINAR_TODO();
            request_eliminar_todo req = new request_eliminar_todo();
            req.PROCESO = Proceso;
            req.CENTRO = Centro;
            req.AUX = aux;
            responce_eliminar_todo resp = el.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}