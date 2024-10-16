using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10001 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String desde = Request["desde"].ToString();
            String hasta = Request["hasta"].ToString();
            DB_PORTAL db = new DB_PORTAL();
            List<responce_LOTES> res = db.getLotesByDate(desde, hasta);
            ZMOV_10001 sap = new ZMOV_10001();
            request_ZMOV_10001 imp = new request_ZMOV_10001();
            imp.IV_SPRAS = "S";
            imp.I_CLASE = "X";
            ZMOV_10001_IR_CHARG[] I_CHARG = new ZMOV_10001_IR_CHARG[res.Count()];
            int i = 0;
            foreach (responce_LOTES lote in res)
            {
                I_CHARG[i] = new ZMOV_10001_IR_CHARG();
                I_CHARG[i].SIGN = "I";
                I_CHARG[i].OPTION = "EQ";
                I_CHARG[i].SIGN = lote.LOTES;
                I_CHARG[i].SIGN = "";
                i++;
            }

            imp.IR_CHARG = I_CHARG;
            responce_ZMOV_10001 obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}