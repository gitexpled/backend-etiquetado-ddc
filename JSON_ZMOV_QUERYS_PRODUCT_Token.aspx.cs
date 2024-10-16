using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERYS_PRODUCT_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            ZMOV_QUERYS_PRODUCT sap = new ZMOV_QUERYS_PRODUCT();
            request_ZMOV_QUERYS_PRODUCT imp = new request_ZMOV_QUERYS_PRODUCT();

            String RUT = Request["RUT"].ToString();

            //RUT = "79763350-K";

            ZMOV_QUERYS_PRODUCT_IV_SORTL[] I_VBELN = new ZMOV_QUERYS_PRODUCT_IV_SORTL[0];
            imp.IV_SORTL = I_VBELN;
            if (RUT != "*")
            {
                I_VBELN = new ZMOV_QUERYS_PRODUCT_IV_SORTL[1];
                I_VBELN[0] = new ZMOV_QUERYS_PRODUCT_IV_SORTL();
                I_VBELN[0].LOW = RUT;
                I_VBELN[0].SIGN = "I";
                I_VBELN[0].OPTION = "EQ";
                imp.IV_SORTL = I_VBELN;
            }
            



            
            
           
            

            responce_ZMOV_QUERYS_PRODUCT obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}