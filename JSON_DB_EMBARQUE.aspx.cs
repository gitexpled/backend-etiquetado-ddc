using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_EMBARQUE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*String jsn = Request["jsn"].ToString();
            String con = Request["con"].ToString();
            String cont = Request["cont"].ToString();
            DB_EMBARQUE embar = new DB_EMBARQUE();
            request_DB_EMBARQUE req = new request_DB_EMBARQUE();
            req.consulta = con;
            req.contenedor = cont;
            req.jsn = jsn;
            Array obj = embar.run(req);
            var json2 = new JavaScriptSerializer().Serialize(obj);*/
            var json2 = new JavaScriptSerializer().Serialize(DB_EMBARQUE.EjecutaEmbarque(Request["PARAMETROS"]));
            json.Text = json2.ToString();
        }
    }
}