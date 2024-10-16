using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_VOICEPICK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String gtin = Request["g"].ToString();
            String lote = Request["l"].ToString();
            String fecha = Request["f"].ToString();
            DateTime dt = Convert.ToDateTime(fecha);
            VoiceCode vc = new VoiceCode();
            responce_VOICE res = vc.Compute(gtin, lote, dt);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}