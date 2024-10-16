using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Net;

namespace rfcBaika
{
    public partial class execSp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            String et = Request["data"];

            //var json2 = new JavaScriptSerializer().Serialize(resp);
            //json.Text = json2.ToString();
            DB_execSp etiqueta = new DB_execSp();
            //String et = "{sp: 'PORTAL_GET_ESP_VAR', params: {ESPECIE: 'UVAS', TEMPORADA: 1}}";
            JObject resp = etiqueta.run(et);
            Response.ContentType = "application/json";
            Response.Write(resp.ToString());
            //var json2 = new JavaScriptSerializer().Serialize(resp);
            //json.Text = json2;
         
        }
    }
}