using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_FILAS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_FILAS consulta = new DB_FILAS();
            request_fila cons = new request_fila();
            Array resp = consulta.run(cons);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}