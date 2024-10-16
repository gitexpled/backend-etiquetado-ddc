using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ADD_ESPECIE_VARIEDAD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String especie = Request["ESPECIE"].ToString();
            String variedad = Request["VARIEDAD"].ToString();
            String desde = Request["DESDE"].ToString();
            String hasta = Request["HASTA"].ToString();
            String temporada = Request["TEMPORADA"].ToString();
            DB_PORTAL db = new DB_PORTAL();

            int res = db.add_especie_variedad(especie, variedad, desde, hasta, temporada);
            
            
            json.Text = res.ToString();
        }
    }
}