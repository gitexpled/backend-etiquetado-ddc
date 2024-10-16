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
    public partial class JSON_ZMOV_10038 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String datos = Request["DATOS"].ToString();

            String jss = datos;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Data"];
            JObject item;
            String Lote = "";
            ZMOV_10038 sap = new ZMOV_10038();
            request_ZMOV_10038 imp = new request_ZMOV_10038();
            ZMOV_10038_IT_HU[] dat = new ZMOV_10038_IT_HU[items.Count];
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                dat[i] = new ZMOV_10038_IT_HU();
                dat[i].EXIDV = item["EXIDV"].ToString();
                dat[i].ZZ_NUMTRA = item["ZZ_NUMTRA"].ToString();
                dat[i].ZZ_TRATAM = item["ZZ_TRATAM"].ToString();
                //dat[i].ZZ_FECTRA = item["ZZ_FECTRA"].ToString();
                dat[i].ZZ_FECTRA = item["ZZ_FECTRA"].ToString();//DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
                dat[i].ZZ_MOTTRA = item["ZZ_MOTTRA"].ToString();
                dat[i].ZZ_PROD = item["ZZ_PROD"].ToString();
                imp.IT_HU = dat;
            }
            responce_ZMOV_10038 obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}