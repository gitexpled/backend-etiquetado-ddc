using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_PORTAL_CONSULTA_PRODUCCION_SATELITE_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String guia = Request["GUIA"].ToString();
            DB_PORTAL db = new DB_PORTAL();

            Array res = db.GetProduccionSateliteGuia(guia);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}