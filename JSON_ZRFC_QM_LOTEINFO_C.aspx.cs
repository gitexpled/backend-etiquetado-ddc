using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZRFC_QM_LOTEINFO_C : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string I_ATNAM = Request["I_ATNAM"].ToString();
            string I_ATWRT = Request["I_ATWRT"].ToString();
            string I_BUKRS = Request["I_BUKRS"].ToString();


            ZRFC_QM_LOTEINFO_C sap = new ZRFC_QM_LOTEINFO_C();
            request_ZRFC_QM_LOTEINFO_C imp = new request_ZRFC_QM_LOTEINFO_C();
            //imp.ET_LOTES = new ZRFC_QM_LOTEINFO_C_ET_LOTES[1];
            ZRFC_QM_LOTEINFO_C_ET_LOTES lg = new ZRFC_QM_LOTEINFO_C_ET_LOTES();
            //imp.ET_LOTES[0] = lg;
            imp.I_ATNAM = I_ATNAM;
            imp.I_ATWRT = I_ATWRT;
            imp.I_BUKRS = I_BUKRS;
            responce_ZRFC_QM_LOTEINFO_C obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}