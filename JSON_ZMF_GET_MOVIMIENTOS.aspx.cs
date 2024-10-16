using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMF_GET_MOVIMIENTOS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String IR_BUDAT = Request["IR_BUDAT"].ToString();
            String IR_BWART = Request["IR_BWART"].ToString();
            String IR_CHARG = Request["IR_CHARG"].ToString();
            String IR_MATNR = Request["IR_MATNR"].ToString();
            String IR_MBLNR = Request["IR_MBLNR"].ToString();
            String IR_MJAHR = Request["IR_MJAHR"].ToString();
            String IR_WERKS = Request["IR_WERKS"].ToString();

            ZMF_GET_MOVIMIENTOS sap = new ZMF_GET_MOVIMIENTOS();
            request_ZMF_GET_MOVIMIENTOS imp = new request_ZMF_GET_MOVIMIENTOS();
            imp.IR_BUDAT = IR_BUDAT;
            imp.IR_BWART = IR_BWART;
            imp.IR_CHARG = IR_CHARG;
            imp.IR_MATNR = IR_MATNR;
            imp.IR_MBLNR = IR_MBLNR;
            imp.IR_MJAHR = IR_MJAHR;
            imp.IR_WERKS = IR_WERKS;
            responce_ZMF_GET_MOVIMIENTOS obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}