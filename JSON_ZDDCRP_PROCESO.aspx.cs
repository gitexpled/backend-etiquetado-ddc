using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZDDCRP_PROCESO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String MATNR = "";
            if (Request["MATNR"] != null)
            {
                MATNR = Request["MATNR"].ToString();
            }
            String CHARG = "";
            if (Request["CHARG"] != null)
            {
                CHARG = Request["CHARG"].ToString();
            }

            
             
            ZDDCRP_PROCESO sap = new ZDDCRP_PROCESO();
            request_ZDDCRP_PROCESO imp = new request_ZDDCRP_PROCESO();
            imp.MATNR = MATNR;
            imp.MJAHR_I = Convert.ToInt32(DateTime.Now.AddDays(-365).ToString("yyyy"));
            imp.MJAHR_F = Convert.ToInt32(DateTime.Now.AddDays(0).ToString("yyyy"));
            
            imp.CHARG = CHARG;
            ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO[] dat = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO[5];
            /*dat[0] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[0].BWART = "309";
            dat[1] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[1].BWART = "310";*/
            dat[0] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[0].BWART = "261";
            dat[1] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[1].BWART = "262";
            dat[2] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[2].BWART = "541";
            dat[3] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[3].BWART = "542";
            dat[4] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[4].BWART = "309";
            imp.ZRANGO_MOVIMIENTO = dat;
            responce_ZDDCRP_PROCESO obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}