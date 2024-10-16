using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_ZPL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Today;
            String zpl = Request["z"].ToString();
            String Densidad = Request["d"].ToString();
            String Tamanio = Request["t"].ToString();
            String Ip_Zebra = Request["i"].ToString();
            String Ruta = Request["r"].ToString();
            String Nombre = Request["n"].ToString();
            String consulta = Request["c"].ToString();
            String ID = Request["id"].ToString();
            DB_ZPL z = new DB_ZPL();
            request_DB_ZPL dato = new request_DB_ZPL();
            dato.zpl = zpl;
            dato.densidad = Densidad;
            dato.Tamanio = Tamanio;
            dato.ipZebra = Ip_Zebra;
            dato.ruta = Ruta;
            dato.nombre = Nombre;
            dato.Consulta = consulta;
            dato.id = ID;
            responce_DB_ZPL resp = z.run(dato);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}