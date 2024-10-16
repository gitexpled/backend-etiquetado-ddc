using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMF_PRODUCTORES_CTACTE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String KTOKK = Request["KTOKK"].ToString();
            // String WERKS = Request["WERKS"].ToString();

            ZMF_PRODUCTORES_CTACTE sap = new ZMF_PRODUCTORES_CTACTE();
            request_ZMF_PRODUCTORES_CTACTE imp = new request_ZMF_PRODUCTORES_CTACTE();
            imp.I_DATE_FROM = "20150101";//Request["I_DATE_FROM"].ToString();
            imp.I_DATE_TO = "20190101"; //Request["I_DATE_TO"].ToString();
            imp.I_RUT = Request["I_RUT"].ToString();
            imp.I_TIPO = Request["I_TIPO"].ToString();
            imp.I_TEMPORADA = "T2017";

            responce_ZMF_PRODUCTORES_CTACTE obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}