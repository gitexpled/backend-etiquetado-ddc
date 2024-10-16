using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_AGREGAR_ESTIMACION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ano = Server.UrlDecode(Request["a"]);
            String estimacion = Server.UrlDecode(Request["e"]);
            DB_ECO_AGREGAR_ESTIMACION ValorSemanaA = new DB_ECO_AGREGAR_ESTIMACION();
            request_DB_ECO_AGREGAR_ESTIMACION vs = new request_DB_ECO_AGREGAR_ESTIMACION();
            vs.ano = ano;
            vs.estimacion = estimacion;
            responce_DB_ECO_AGREGAR_ESTIMACION resp = ValorSemanaA.run(vs);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}