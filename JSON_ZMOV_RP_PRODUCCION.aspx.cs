using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_RP_PRODUCCION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String FECHADESDE = Request["FECHADESDE"].ToString();
            String FECHAHASTA = Request["FECHAHASTA"].ToString();
            String TIPO = Request["TIPO"].ToString();
            
            ZMOV_RP_PRODUCCION sap = new ZMOV_RP_PRODUCCION();


            request_ZMOV_RP_PRODUCCION imp = new request_ZMOV_RP_PRODUCCION();          

            if (TIPO=="S")
                imp.IV_SATELITE="X";
                
                else
                imp.IV_PRODUC = "X";

          

            ZMOV_RP_PRODUCCION_IR_BUDAT[] IR_BUDAT = new ZMOV_RP_PRODUCCION_IR_BUDAT[0];

            IR_BUDAT = new ZMOV_RP_PRODUCCION_IR_BUDAT[1];
            IR_BUDAT[0] = new ZMOV_RP_PRODUCCION_IR_BUDAT();
            IR_BUDAT[0].LOW = FECHADESDE;
            IR_BUDAT[0].HIGH = FECHAHASTA;
            IR_BUDAT[0].SIGN = "I";
            IR_BUDAT[0].OPTION = "BT";
            imp.IR_BUDAT = IR_BUDAT;


            String CODPROD = Request["CODPROD"].ToString();

            ZMOV_RP_PRODUCCION_IR_LIFNR[] IR_LIFNR = new ZMOV_RP_PRODUCCION_IR_LIFNR[0];
            imp.IR_LIFNR = IR_LIFNR;
            if (CODPROD != "*")
            {
                IR_LIFNR = new ZMOV_RP_PRODUCCION_IR_LIFNR[1];
                IR_LIFNR[0] = new ZMOV_RP_PRODUCCION_IR_LIFNR();
                IR_LIFNR[0].LOW = CODPROD;
                IR_LIFNR[0].SIGN = "I";
                IR_LIFNR[0].OPTION = "EQ";
                imp.IR_LIFNR = IR_LIFNR;
            }
            String CHARG = Request["CHARG"].ToString();

            ZMOV_RP_PRODUCCION_IR_CHARG[] IR_CHARG = new ZMOV_RP_PRODUCCION_IR_CHARG[0];
            imp.IR_CHARG = IR_CHARG;
            if (CHARG != "*")
            {
                IR_CHARG = new ZMOV_RP_PRODUCCION_IR_CHARG[1];
                IR_CHARG[0] = new ZMOV_RP_PRODUCCION_IR_CHARG();
                IR_CHARG[0].LOW = CHARG;
                IR_CHARG[0].SIGN = "I";
                IR_CHARG[0].OPTION = "EQ";
                imp.IR_CHARG = IR_CHARG;
            }
            String ESPECIE = Request["ESPECIE"].ToString();

            ZMOV_RP_PRODUCCION_IR_EXTWG[] IR_EXTWG = new ZMOV_RP_PRODUCCION_IR_EXTWG[0];
            imp.IR_EXTWG = IR_EXTWG;
            if (ESPECIE != "*")
            {
                IR_EXTWG = new ZMOV_RP_PRODUCCION_IR_EXTWG[1];
                IR_EXTWG[0] = new ZMOV_RP_PRODUCCION_IR_EXTWG();
                IR_EXTWG[0].LOW = ESPECIE;
                IR_EXTWG[0].SIGN = "I";
                IR_EXTWG[0].OPTION = "EQ";
                imp.IR_EXTWG = IR_EXTWG;
            }

            String CENTRO = Request["CENTRO"].ToString();

            ZMOV_RP_PRODUCCION_IR_WERKS[] IR_WERKS = new ZMOV_RP_PRODUCCION_IR_WERKS[0];
            imp.IR_WERKS = IR_WERKS;
            if (CENTRO != "*")
            {
                IR_WERKS = new ZMOV_RP_PRODUCCION_IR_WERKS[1];
                IR_WERKS[0] = new ZMOV_RP_PRODUCCION_IR_WERKS();
                IR_WERKS[0].LOW = CENTRO;
                IR_WERKS[0].SIGN = "I";
                IR_WERKS[0].OPTION = "EQ";
                imp.IR_WERKS = IR_WERKS;
            }



           
            

            responce_ZMOV_RP_PRODUCCION obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}