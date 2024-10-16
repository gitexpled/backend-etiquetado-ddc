using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_DET_PEDIDO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String DESDE = Request["DESDE"].ToString();
            String HASTA = Request["HASTA"].ToString();


            ZMOV_QUERY_DET_PEDIDO sap = new ZMOV_QUERY_DET_PEDIDO();
            request_ZMOV_QUERY_DET_PEDIDO imp = new request_ZMOV_QUERY_DET_PEDIDO();

            ZMOV_QUERY_DET_PEDIDO_I_VBELN[] I_VBELN = new ZMOV_QUERY_DET_PEDIDO_I_VBELN[1];
            I_VBELN[0] = new ZMOV_QUERY_DET_PEDIDO_I_VBELN();
            I_VBELN[0].LOW = DESDE;
            I_VBELN[0].HIGH = HASTA;
            I_VBELN[0].SIGN = "I";
            I_VBELN[0].OPTION = "BT";

            imp.I_VBELN = I_VBELN;





            responce_ZMOV_QUERY_DET_PEDIDO obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}