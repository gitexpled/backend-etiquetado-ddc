using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_CONSULTA_GTIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_CONSULTA_GTIN gtin = new DB_CONSULTA_GTIN();
            DB_request_gtin consulta = new DB_request_gtin();
            Array res = gtin.run(consulta);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}