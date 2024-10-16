using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_PORTAL_APRUEBAGUIA_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String guia = Request["GUIA"].ToString();
            String user = Request["USER"].ToString();
            DB_PORTAL db = new DB_PORTAL();

            int res = db.AprobarGuia(guia,user);
            
            
            json.Text = res.ToString();
        }
    }
}