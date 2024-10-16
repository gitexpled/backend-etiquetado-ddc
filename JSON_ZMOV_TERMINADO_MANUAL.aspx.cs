using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_TERMINADO_MANUAL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String proceso = Request["p"].ToString();
            String centro = Request["c"].ToString();
            DB_TERMINADO_MANUAL etiq = new DB_TERMINADO_MANUAL();
            DB_request_terminado_manual consulta = new DB_request_terminado_manual();
            consulta.Proceso = proceso;
            consulta.Centro = centro;
            DB_responce_terminado_manual res = etiq.run(consulta);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}