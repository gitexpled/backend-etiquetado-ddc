using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_GET_SP_ACUMULADO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String variedad = Request["VARIEDAD"].ToString();
            String procedure = Request["PROCEDURE"].ToString();
            String productor = Request["PRODUCTOR"].ToString();
            String lote = Request["LOTE"].ToString();
            DB_PORTAL db = new DB_PORTAL();
            Array res = null;
            switch (procedure)
                {
                    case  "GET_ACUM_CALIBRE_VARIEDAD":
                        res = db.GET_ACUM_CALIBRE_VARIEDAD(variedad, productor, lote);
                        break;

                    case "GET_ACUM_CALIBRE_GRUPO_VARIEDAD":
                        res = db.GET_ACUM_CALIBRE_GRUPO_VARIEDAD(variedad, productor, lote);
                        break;

                    case "GET_ACUM_CAT_GRUPO_VARIEDAD":
                        res = db.GET_ACUM_CAT_GRUPO_VARIEDAD(variedad, productor, lote);
                        break;

                    case "GET_ACUM_CAT_VARIEDAD":
                        res = db.GET_ACUM_CAT_VARIEDAD(variedad, productor, lote);
                        break;

                    default:
                        break;
                }



            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}