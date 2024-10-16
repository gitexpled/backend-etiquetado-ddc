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
    public partial class JSON_ZMOV_PROCESO_RANGO_PRZ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String CHARG_ = Request["CHARG"].ToString();

            ZMOV_PROCESO_RANGO_PRZ sap = new ZMOV_PROCESO_RANGO_PRZ();
            request_ZMOV_PROCESO_RANGO_PRZ imp = new request_ZMOV_PROCESO_RANGO_PRZ();

            ZMOV_PROCESO_RANGO_PRZ_CHARG[] CHARG = new ZMOV_PROCESO_RANGO_PRZ_CHARG[1];
            CHARG[0] = new ZMOV_PROCESO_RANGO_PRZ_CHARG();

            CHARG[0].LOW = CHARG_;
            //CHARG[0].HIGH = null;
            CHARG[0].SIGN = "I";
            CHARG[0].OPTION = "EQ";

            string desde = DateTime.Now.AddDays(0).ToString("yyyy");
            int anodesde = Convert.ToInt32(desde);
            imp.CHARG = CHARG;
            imp.MJAHR_F = anodesde;
            imp.MJAHR_I = anodesde-1;

            
            //if (Request["IR_MATNR"].ToString() != "")
            //{
                //imp.IR_MATNR = Request["IR_MATNR"].ToString();
            //}
           
            responce_ZMOV_PROCESO_RANGO_PRZ obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}