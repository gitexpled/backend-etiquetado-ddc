using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_DESACTIVAR_PROCESOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String planta = Request["p"].ToString();
            String usuario = Request["u"].ToString();
            String ip_pantalla = Request["ip"].ToString();
            DB_DESACTIVAR_PROCESOS DB = new DB_DESACTIVAR_PROCESOS();
            request_DB_DESACTIVAR_PROCESOS req = new request_DB_DESACTIVAR_PROCESOS();
            req.PLANTA = planta;
            req.USUARIO = usuario;
            req.IP_PANTALLA = ip_pantalla;
            responce_DB_DESACTIVAR_PROCESOS res = DB.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}