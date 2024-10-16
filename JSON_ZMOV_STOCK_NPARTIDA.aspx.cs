using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_STOCK_NPARTIDA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String LOTE = Request["LOTE"].ToString();




            ZMOV_STOCK_NPARTIDA sap = new ZMOV_STOCK_NPARTIDA();
            request_ZMOV_STOCK_NPARTIDA imp = new request_ZMOV_STOCK_NPARTIDA();


            imp.I_BUKRS="DC01";
            imp.I_ATNAM="ZNPARTIDA";
            imp.I_ATWRT=LOTE;


            responce_ZMOV_STOCK_NPARTIDA obj = sap.sapRun(imp);

            var json2 = new JavaScriptSerializer().Serialize(obj);
            
            json.Text = json2.ToString();

        }
    }
}