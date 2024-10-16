using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_SELECCION_ETIQUETA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_SELECCION_ETIQUETA image = new DB_SELECCION_ETIQUETA();
            request_SELECCION_ETIQUETA img = new request_SELECCION_ETIQUETA();
            Array resp = image.run(img);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}