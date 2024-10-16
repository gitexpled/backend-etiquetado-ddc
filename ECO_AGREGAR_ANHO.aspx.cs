using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_AGREGAR_ANHO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_AGREGAR_ANHO ValorSemanaA = new DB_ECO_AGREGAR_ANHO();
            request_ECO_AGREGAR_ANHO vs = new request_ECO_AGREGAR_ANHO();
            responce_ECO_AGREGAR_ANHO resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}