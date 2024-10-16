using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_ELIMINAR_ET : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Proceso = Request["p"].ToString();
            String id_Posicion = Request["ip"].ToString();
            String id_etiqueta = Request["ie"].ToString();
            DB_ELIMINAR_ET el = new DB_ELIMINAR_ET();
            request_eliminar_et req = new request_eliminar_et();
            req.PROCESO = Proceso;
            req.ID_POSICION = id_Posicion;
            req.ID_ETIQUETA = id_etiqueta;
            responce_eliminar_et resp = el.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}