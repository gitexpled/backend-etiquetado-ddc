using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public partial class JSON_ZMOV_QUERY_HU_INFO_ARRAY : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String datos = Request["DATOS"].ToString();

            String jss = datos;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Data"];
            JObject item;
            ZMOV_QUERY_HU_INFO sap = new ZMOV_QUERY_HU_INFO();
            request_ZMOV_QUERY_HU_INFO imp = new request_ZMOV_QUERY_HU_INFO();
            ZMOV_QUERY_HU_INFO_IR_EXIDV[] dat = new ZMOV_QUERY_HU_INFO_IR_EXIDV[items.Count];
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                dat[i] = new ZMOV_QUERY_HU_INFO_IR_EXIDV();
                dat[i].HIGH = "";
                dat[i].LOW = item["PALLET"].ToString().PadLeft(20, '0');
                dat[i].OPTION = "EQ";
                dat[i].SIGN = "I";
                imp.IR_EXIDV = dat;
            }
            
            
            
            responce_ZMOV_QUERY_HU_INFO obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();


        }
    }
}