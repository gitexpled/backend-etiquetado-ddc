using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace rfcBaika
{
    public partial class JSON_REEMBALAJE_EX : System.Web.UI.Page
    {
        /*[WebMethod]
        public static string GetParametro(string PARAMETRO)
        {
            //var json2 = new JavaScriptSerializer().Serialize(reembalaje.EjecutaReembalaje(param));
            return "asbdhasbdjahsbdja";
        }*/
        protected void Page_Load(object sender, EventArgs e)
        {
            var json2 = new JavaScriptSerializer().Serialize(reembalaje.EjecutaReembalaje(Server.UrlDecode(Request["PARAMETRO"])));
            json.Text = json2.ToString();
        }
    }
}