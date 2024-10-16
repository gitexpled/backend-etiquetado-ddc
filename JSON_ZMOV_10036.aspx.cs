using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10036 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String KUNNR = Request["KUNNR"].ToString();
            String KUNNR_S = ((Request["KUNNR"] != null) ? Request["KUNNR"].ToString() : "[]");
            dynamic KUNNR = JsonConvert.DeserializeObject(KUNNR_S);
            ZMOV_10036 sap = new ZMOV_10036();
            request_ZMOV_10036 req = new request_ZMOV_10036();
            req.RG_KUNNR = new ZMOV_10036_RG_KUNNR[KUNNR.Count];
            int x = 0;
            foreach (dynamic item in KUNNR)
            {
                req.RG_KUNNR[x] = new ZMOV_10036_RG_KUNNR();
                req.RG_KUNNR[x].SIGN = "I";
                req.RG_KUNNR[x].OPTION = "EQ";
                req.RG_KUNNR[x].LOW = item.KUNNR;
                //req.RG_KUNNR[x].LOW = "0010003528";
                req.RG_KUNNR[x].HIGH = "";
                x++;
            }
            responce_ZMOV_10036 obj = sap.sapRun(req);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}