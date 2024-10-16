using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_STOCK_LOTE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String LOTE = Request["LOTE"].ToString();            
            



            ZMOV_QUERY_STOCK_LOTE sap = new ZMOV_QUERY_STOCK_LOTE();
            request_ZMOV_QUERY_STOCK_LOTE imp = new request_ZMOV_QUERY_STOCK_LOTE();


            imp.LOTE = LOTE;


            responce_ZMOV_QUERY_STOCK_LOTE obj = sap.sapRun(imp);

            var json2 = new JavaScriptSerializer().Serialize(obj);
            
            json.Text = json2.ToString();

        }
    }
}