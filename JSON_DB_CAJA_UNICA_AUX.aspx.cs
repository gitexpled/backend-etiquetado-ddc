using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_CAJA_UNICA_AUX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {;
            String Numero = Request["num"].ToString();
            String planta = Request["pla"].ToString();
            DB_CAJA_UNICA_AUX caja = new DB_CAJA_UNICA_AUX();
            request_CAJA_UNICA_AUX req = new request_CAJA_UNICA_AUX();
            req.Numero = Numero;
            req.planta = planta;
            Array obj = caja.run(req);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}