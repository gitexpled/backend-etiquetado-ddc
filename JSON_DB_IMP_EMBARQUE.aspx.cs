using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_IMP_EMBARQUE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var json2 = new JavaScriptSerializer().Serialize(DB_IMP_EMBARQUE.EjecutaIMPEmbarque(Request["PARAMETROS"]));
            json.Text = json2.ToString();
        }
    }
}