using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DEL_TEMPORADA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String temporada = Request["TEMPORADA"].ToString();
            DB_PORTAL db = new DB_PORTAL();

            int res = db.del_temporada(temporada);
            
            
            json.Text = res.ToString();
        }
    }
}