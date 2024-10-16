using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_RE_ETIQUETA_INICIO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String proceso = Request["p"].ToString();
            DB_RE_ETIQUETA_INICIO ci = new DB_RE_ETIQUETA_INICIO();
            request_RE_ETIQUETA_INICIO req = new request_RE_ETIQUETA_INICIO();
            req.PROCESO = proceso;
            Array res = ci.run(req);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}