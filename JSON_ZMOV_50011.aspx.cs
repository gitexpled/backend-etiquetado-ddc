using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_50011 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String EXIDV = ((Request["EXIDV"] != null) ? Request["EXIDV"].ToString() : "[]");
            dynamic Datos = JsonConvert.DeserializeObject(((Request["EXIDV"] != null) ? Request["EXIDV"].ToString() : "[]"));
            JArray EXIDV = JArray.Parse((Datos.IT_EXIDV != null) ? Datos.IT_EXIDV.ToString() : "[]");
            JArray HEADER = JArray.Parse((Datos.UPDATE_HEADER != null) ? Datos.UPDATE_HEADER.ToString() : "[]");
            ZMOV_50011 zmov = new ZMOV_50011();
            request_ZMOV_50011 req = new request_ZMOV_50011();
            req.IT_EXIDV = new ZMOV_50011_IT_EXIDV[EXIDV.Count];
            req.LT_HUM_UPDATE_HEADER = new ZMOV_50011_LT_HUM_UPDATE_HEADER[HEADER.Count];
            int x = 0;
            foreach (dynamic item in EXIDV)
            {
                req.IT_EXIDV[x] = new ZMOV_50011_IT_EXIDV();
                req.IT_EXIDV[x].EXIDV = item.EXIDV;
                x++;
            }
            int i = 0;
            foreach (dynamic item in HEADER)
            {
                req.LT_HUM_UPDATE_HEADER[i] = new ZMOV_50011_LT_HUM_UPDATE_HEADER();
                req.LT_HUM_UPDATE_HEADER[i].EXIDV = item.EXIDV;
                req.LT_HUM_UPDATE_HEADER[i].FIELD_NAME = item.FIELD_NAME;
                req.LT_HUM_UPDATE_HEADER[i].FIELD_VALUE = item.FIELD_VALUE;
                i++;
            }
            responce_ZMOV_50011 obj = zmov.sapRun(req);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}