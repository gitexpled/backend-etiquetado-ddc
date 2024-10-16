using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_UPDATE_ESTADO_ETIQUETA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request["ID"].ToString();
            DB_SELECCION_ETIQUETA image = new DB_SELECCION_ETIQUETA();
            int resp = image.update_estado_etiqueta(id);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}