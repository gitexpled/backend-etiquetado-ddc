using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections;

namespace rfcBaika
{
    public partial class JSON_PORTAL_CONSULTA_PRODUCCION_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String productor = Request["COD_PROD"].ToString();
            String temporada = Request["TEMPORADA"].ToString();
            String cop = "";
            DB_PORTAL db = new DB_PORTAL();
            try
            {
                cop = Request["COPEQUEN"].ToString();
            }
            catch 
            {

                cop = "FALSE";
            }

            ArrayList condicion_in = new ArrayList();
            if (cop == "TRUE")
            {
                condicion_in.Add(productor);
            }
            else
            {

                //productor = "79763350-K";

                

                ZMOV_QUERYS_PRODUCT sap = new ZMOV_QUERYS_PRODUCT();
                request_ZMOV_QUERYS_PRODUCT imp = new request_ZMOV_QUERYS_PRODUCT();

                String RUT = productor;

                ZMOV_QUERYS_PRODUCT_IV_SORTL[] I_VBELN = new ZMOV_QUERYS_PRODUCT_IV_SORTL[0];
                imp.IV_SORTL = I_VBELN;
                if (RUT != "*")
                {
                    I_VBELN = new ZMOV_QUERYS_PRODUCT_IV_SORTL[1];
                    I_VBELN[0] = new ZMOV_QUERYS_PRODUCT_IV_SORTL();
                    I_VBELN[0].LOW = RUT;
                    I_VBELN[0].SIGN = "I";
                    I_VBELN[0].OPTION = "EQ";
                    imp.IV_SORTL = I_VBELN;
                }

                responce_ZMOV_QUERYS_PRODUCT obj = sap.sapRun(imp);

                condicion_in = new ArrayList();

                foreach (ZMOV_QUERYS_PRODUCT_LT_DATA item in obj.LT_DATA)
                {
                    condicion_in.Add(item.LIFNR);

                }
            }


            Array res = db.GetProduccionAcumulada(condicion_in, temporada);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}