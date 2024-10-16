using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_PORTAL_APRUEBACALIDAD_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String lote = Request["LOTE"].ToString();
            String usuario = Request["USUARIO"].ToString();
            DB_PORTAL db = new DB_PORTAL();

            int res = db.AprobarCalidad(lote,usuario);
            
            
            json.Text = res.ToString();
        }
    }
}