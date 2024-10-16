using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public partial class JSON_ZDDCRP_PROCESO_RANGO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String CHARG_ = Request["CHARG"].ToString();

            ZDDCRP_PROCESO_RANGO sap = new ZDDCRP_PROCESO_RANGO();
            request_ZDDCRP_PROCESO_RANGO imp = new request_ZDDCRP_PROCESO_RANGO();

            ZDDCRP_PROCESO_RANGO_CHARG[] CHARG = new ZDDCRP_PROCESO_RANGO_CHARG[1];
            CHARG[0] = new ZDDCRP_PROCESO_RANGO_CHARG();

            CHARG[0].LOW = CHARG_;
            //CHARG[0].HIGH = null;
            CHARG[0].SIGN = "I";
            CHARG[0].OPTION = "EQ";

            imp.CHARG = CHARG;
            int desde = Convert.ToInt32( DateTime.Now.AddDays(0).ToString("yyyy"));
            imp.MJAHR_I = desde - 1;
            imp.MJAHR_F = desde;
            


            //if (Request["MATNR"].ToString() != "")
            //{
                //imp.IR_MATNR = Request["IR_MATNR"].ToString();
            //}
           
            responce_ZDDCRP_PROCESO_RANGO obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}