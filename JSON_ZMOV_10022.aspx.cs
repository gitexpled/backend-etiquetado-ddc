using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_10022 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String IR_ESPECIE = Request["IR_ESPECIE"].ToString();
            String IR_VARIEDAD = Request["IR_VARIEDAD"].ToString();
            String IR_WERKS = Request["IR_WERKS"].ToString();
            ZMOV_10022 rfc = new ZMOV_10022();
            request_ZMOV_10022 req = new request_ZMOV_10022();
            ZMOV_10022_IR_ESPECIE[] IR_ESPECIES = new ZMOV_10022_IR_ESPECIE[1];
            IR_ESPECIES[0] = new ZMOV_10022_IR_ESPECIE();
            IR_ESPECIES[0].HIGH = "";
            IR_ESPECIES[0].LOW = IR_ESPECIE;
            IR_ESPECIES[0].OPTION = "EQ";
            IR_ESPECIES[0].SIGN = "I";
            req.IR_ESPECIE = IR_ESPECIES;
            ZMOV_10022_IR_VARIEDAD[] IR_VARIEDADES = new ZMOV_10022_IR_VARIEDAD[1];
            IR_VARIEDADES[0] = new ZMOV_10022_IR_VARIEDAD();
            IR_VARIEDADES[0].HIGH = "";
            IR_VARIEDADES[0].LOW = IR_VARIEDAD;
            IR_VARIEDADES[0].OPTION = "EQ";
            IR_VARIEDADES[0].SIGN = "I";
            req.IR_VARIEDAD = IR_VARIEDADES;
            ZMOV_10022_IR_WERKS[] IR_CENTROS = new ZMOV_10022_IR_WERKS[1];
            IR_CENTROS[0] = new ZMOV_10022_IR_WERKS();
            IR_CENTROS[0].HIGH = "";
            IR_CENTROS[0].LOW = IR_WERKS;
            IR_CENTROS[0].OPTION = "EQ";
            IR_CENTROS[0].SIGN = "I";
            req.IR_WERKS = IR_CENTROS;
            responce_ZMOV_10022 obj = rfc.sapRun(req);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}