using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_MOD_PROCESO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Ip_Pantalla = Request["ip"].ToString();
            String Posicion_e = Request["pe"].ToString();
            String Kilos = Request["k"].ToString();
            String Proceso = Request["prc"].ToString();
            DB_PROCESO_MOD prc = new DB_PROCESO_MOD();
            request_DB_PROCESO_MOD req = new request_DB_PROCESO_MOD();
            req.ip_pantalla = Ip_Pantalla;
            req.posicion = Posicion_e;
            req.kilos = Kilos;
            req.Proceso = Proceso;
            responce_DB_PROCESO_MOD obj = prc.run(req);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}