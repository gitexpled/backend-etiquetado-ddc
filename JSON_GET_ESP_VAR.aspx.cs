using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_GET_ESP_VAR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String especie = Request["ESPECIE"].ToString();
            String temporada = Request["TEMPORADA"].ToString();
            DB_PORTAL db = new DB_PORTAL();


            Array res = db.getEspVar(especie, temporada);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}