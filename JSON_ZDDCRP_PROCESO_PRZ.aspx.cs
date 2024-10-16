using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZDDCRP_PROCESO_PRZ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String CHARG = Request["CHARG"].ToString();
            String MATNR = Request["MATNR"].ToString();
            
            ZDDCRP_PROCESO_PRZ pr = new ZDDCRP_PROCESO_PRZ();
            request_ZDDCRP_PROCESO_PRZ imp = new request_ZDDCRP_PROCESO_PRZ();
            imp.CHARG = CHARG;
            imp.MATNR = MATNR;
            imp.MJAHR_F = 2017;
            imp.MJAHR_I = 2016;

            responce_ZDDCRP_PROCESO_PRZ obj = pr.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}