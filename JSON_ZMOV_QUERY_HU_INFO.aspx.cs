using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_HU_INFO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String IR_EXIDV = "";
            if (Request["IR_EXIDV"] != null)
            {
                IR_EXIDV = Request["IR_EXIDV"].ToString();
            }
            if (IR_EXIDV.Contains(";"))
            {
                string[] listaPallet = IR_EXIDV.Split(';');


                
                ZMOV_QUERY_HU_INFO sap = new ZMOV_QUERY_HU_INFO();
                request_ZMOV_QUERY_HU_INFO imp = new request_ZMOV_QUERY_HU_INFO();
                
                ZMOV_QUERY_HU_INFO_IR_EXIDV[] dat = new ZMOV_QUERY_HU_INFO_IR_EXIDV[listaPallet.Length];


                for (int i = 0; i < listaPallet.Length; i++ )
                {
                    dat[i] = new ZMOV_QUERY_HU_INFO_IR_EXIDV();
                    dat[i].HIGH = "";
                    dat[i].LOW = listaPallet[i].PadLeft(20, '0');
                    dat[i].OPTION = "EQ";
                    dat[i].SIGN = "I";
                }

                imp.IR_EXIDV = dat;
                responce_ZMOV_QUERY_HU_INFO obj = sap.sapRun(imp);
                var json2 = new JavaScriptSerializer().Serialize(obj);
                json.Text = json2.ToString();
            }
            else
            {
                ZMOV_QUERY_HU_INFO sap = new ZMOV_QUERY_HU_INFO();
                request_ZMOV_QUERY_HU_INFO imp = new request_ZMOV_QUERY_HU_INFO();
                ZMOV_QUERY_HU_INFO_IR_EXIDV[] dat = new ZMOV_QUERY_HU_INFO_IR_EXIDV[1];
                dat[0] = new ZMOV_QUERY_HU_INFO_IR_EXIDV();
                dat[0].HIGH = "";
                dat[0].LOW = IR_EXIDV.PadLeft(20, '0');
                dat[0].OPTION = "EQ";
                dat[0].SIGN = "I";
                imp.IR_EXIDV = dat;
                responce_ZMOV_QUERY_HU_INFO obj = sap.sapRun(imp);
                var json2 = new JavaScriptSerializer().Serialize(obj);
                json.Text = json2.ToString();
            }





        }
    }
}