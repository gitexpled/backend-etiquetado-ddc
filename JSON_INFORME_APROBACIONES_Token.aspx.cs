using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_INFORME_APROBACIONES_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String centro = Request["CENTRO"].ToString();
            String especie = Request["ESPECIE"].ToString();
            String variedad = Request["VARIEDAD"].ToString();
            String fecha_desde = Request["FECHA_DESDE"].ToString();
            String fecha_hasta = Request["FECHA_HASTA"].ToString();
            DB_PORTAL db = new DB_PORTAL();

            Array res = db.GetInformeAprobado(centro, especie, variedad,fecha_desde,fecha_hasta);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}