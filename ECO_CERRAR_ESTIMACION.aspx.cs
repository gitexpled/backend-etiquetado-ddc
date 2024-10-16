using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_CERRAR_ESTIMACION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String estimacion = Server.UrlDecode(Request["es"]);
            String ano = Server.UrlDecode(Request["a"]);
            DB_ECO_CERRAR_ESTIMACION ValorSemanaA = new DB_ECO_CERRAR_ESTIMACION();
            request_ECO_CERRAR_ESTIMACION vs = new request_ECO_CERRAR_ESTIMACION();
            vs.estimacion = estimacion;
            vs.ano = ano;
            responce_ECO_CERRAR_ESTIMACION resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}