using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_TURNO_FECHA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String planta = Request["p"].ToString();
            String fecha1 = Request["f1"].ToString();
            String fecha2 = Request["f2"].ToString();
            String fecha3 = Request["f3"].ToString();
            String fecha4 = Request["f4"].ToString();
            String consulta = Request["c"].ToString();
            DB_TURNO_FECHA ci = new DB_TURNO_FECHA();
            request_TURNO_FECHA req = new request_TURNO_FECHA();
            req.PLANTA = planta;
            req.FECHA1 = fecha1;
            req.FECHA2 = fecha2;
            req.FECHA3 = fecha3;
            req.FECHA4 = fecha4;
            req.CONSULTA = consulta;
            Array res = ci.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}