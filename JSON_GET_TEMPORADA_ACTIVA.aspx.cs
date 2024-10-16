using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_GET_TEMPORADA_ACTIVA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_PORTAL db = new DB_PORTAL();

            //int res = db.getTemporadas();

            List<responce_TEMPORADA_ACTIVA> res = db.getTemporadaActiva();
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}