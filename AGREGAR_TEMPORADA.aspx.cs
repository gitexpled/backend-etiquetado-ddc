using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class AGREGAR_TEMPORADA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_AGREGAR_TEMPORADA ValorSemanaA = new DB_AGREGAR_TEMPORADA();
            String temporada = Request["temporada"].ToString();
            responce_AGREGAR_TEMPORADA resp = ValorSemanaA.run(temporada);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}