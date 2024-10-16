using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_PORTAL_CONSULTA_PRODUCCION_SATELITE_APROBADO_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String productor = Request["COD_PROD"].ToString();
            String centro = Request["CENTRO"].ToString();
            DB_PORTAL db = new DB_PORTAL();

            Array res = db.GetProduccionSateliteAprobar(productor, centro);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}