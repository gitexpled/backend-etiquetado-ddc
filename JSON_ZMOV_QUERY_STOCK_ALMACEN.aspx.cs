using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_STOCK_ALMACEN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String WERKS = "";
            if (Request["WERKS"] != null)
            {
                WERKS = Request["WERKS"].ToString();
            }
            String LGORT = "";
            if (Request["LGORT"] != null)
            {
                LGORT = Request["LGORT"].ToString();
            }
            String FABRICACION = "";
            if (Request["FABRICACION"] != null)
            {
                FABRICACION = Request["FABRICACION"].ToString();
            }
            String LIFNR = "";
            if (Request["LIFNR"] != null)
            {
                LIFNR = Request["LIFNR"].ToString();
            }
            String MATNR = "";
            if (Request["MATNR"] != null)
            {
                MATNR = Request["MATNR"].ToString();
            }



            ZMOV_QUERY_STOCK_ALMACEN_2 sap = new ZMOV_QUERY_STOCK_ALMACEN_2();
            request_ZMOV_QUERY_STOCK_ALMACEN_2 imp = new request_ZMOV_QUERY_STOCK_ALMACEN_2();


            
            
        

            
            if (WERKS != "")
            {
                
                imp.WERKS = new ZMOV_QUERY_STOCK_ALMACEN_2_WERKS[1];
                
                ZMOV_QUERY_STOCK_ALMACEN_2_WERKS we = new ZMOV_QUERY_STOCK_ALMACEN_2_WERKS();
                we.SIGN = "I";
                we.OPTION = "EQ";
                we.LOW = WERKS;
                we.HIGH = "";
                imp.WERKS[0] = we;
            }
            if (LGORT != "")
            {
                imp.LGORT = new ZMOV_QUERY_STOCK_ALMACEN_2_LGORT[1];
                
                ZMOV_QUERY_STOCK_ALMACEN_2_LGORT lg = new ZMOV_QUERY_STOCK_ALMACEN_2_LGORT();
                lg.SIGN = "I";
                lg.OPTION = "EQ";
                lg.STLOC_LOW = LGORT;
                lg.STLOC_HIGH = "";
                imp.LGORT[0] = lg;
            }
            if (FABRICACION != "")
            {
                imp.FABRICACION = new ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION[1];
                
                ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION fa = new ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION();
                fa.SIGN = "I";
                fa.OPTION = "LE";
                fa.LOW = FABRICACION;
                fa.HIGH = "";
                imp.FABRICACION[0] = fa;
            }
            if (LIFNR != "")
            {
                imp.LIFNR = new ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR[1];
                
                ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR li = new ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR();
                li.SIGN = "I";
                li.OPTION = "EQ";
                li.LOW = LIFNR;
                li.HIGH = "";
                imp.LIFNR[0] = li;
            }
            if (MATNR != "")
            {
                imp.MATNR = new ZMOV_QUERY_STOCK_ALMACEN_2_MATNR[1];
                ZMOV_QUERY_STOCK_ALMACEN_2_MATNR mt = new ZMOV_QUERY_STOCK_ALMACEN_2_MATNR();
                mt.SIGN = "I";
                mt.OPTION = "EQ";
                mt.LOW = MATNR;
                mt.HIGH = "";
                imp.MATNR[0] = mt;
            }

            responce_ZMOV_QUERY_STOCK_ALMACEN_2 obj = sap.sapRun(imp);

            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}