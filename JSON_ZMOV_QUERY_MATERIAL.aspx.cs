using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_MATERIAL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String MTART = (Request["MTART"] != null) ? Request["MTART"].ToString() : "";
            String MATKL = (Request["IR_MATKL"] != null) ? Request["IR_MATKL"].ToString() : "";
            String WERKS = "";

           

            ZMOV_QUERY_MATERIAL sap = new ZMOV_QUERY_MATERIAL();
            request_ZMOV_QUERY_MATERIAL imp = new request_ZMOV_QUERY_MATERIAL();
            
            try
            {
                ZMOV_QUERY_MATERIAL_IR_WERKS[] IR_WERKS = new ZMOV_QUERY_MATERIAL_IR_WERKS[1];

                WERKS = Request["WERKS"].ToString();
                ZMOV_QUERY_MATERIAL_IR_WERKS we = new ZMOV_QUERY_MATERIAL_IR_WERKS();
                we.SIGN = "I";
                we.OPTION = "EQ";
                we.LOW = WERKS;
                we.HIGH = "";
                IR_WERKS[0] = we;
                imp.IR_WERKS = IR_WERKS;
            }
            catch (Exception ex) { }
            if (MTART != "")
            {
                ZMOV_QUERY_MATERIAL_IR_MTART[] IR_MTART = new ZMOV_QUERY_MATERIAL_IR_MTART[1];
                ZMOV_QUERY_MATERIAL_IR_MTART IM = new ZMOV_QUERY_MATERIAL_IR_MTART();
                IM.SIGN = "I";
                IM.OPTION = "EQ";
                IM.LOW = MTART;
                IM.HIGH = "";
                IR_MTART[0] = IM;
                imp.IR_MTART = IR_MTART;
            }
            if (MATKL != "")
            {
                ZMOV_QUERY_MATERIAL_IR_MATKL[] IR_MATKL = new ZMOV_QUERY_MATERIAL_IR_MATKL[1];
                ZMOV_QUERY_MATERIAL_IR_MATKL IM2 = new ZMOV_QUERY_MATERIAL_IR_MATKL();
                IM2.SIGN = "I";
                IM2.OPTION = "EQ";
                IM2.LOW = MATKL;
                IM2.HIGH = "";
                IR_MATKL[0] = IM2;
                imp.IR_MATKL = IR_MATKL;
            }
            //imp.IR_MTART = IR_MTART;
            responce_ZMOV_QUERY_MATERIAL obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}