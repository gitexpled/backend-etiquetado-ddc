using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public partial class JSON_PORTAL_CONSULTA_CALIDAD_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_PORTAL db = new DB_PORTAL();
            String productor = Request["productor"].ToString();
            String temporada = Request["TEMPORADA"].ToString();
            string[] fechas = db.getFechasTemporada(temporada);
            String finicio = fechas[0];
            String ffin = fechas[1];

            string[] arrFinicio = new string[3];
            string[] arrFfin = new string[3];


            arrFinicio = finicio.Split('-');
            arrFfin = ffin.Split('-');
            string season = arrFinicio[0].Substring(2, 2) + arrFfin[0].Substring(2, 2);
            


            finicio = arrFinicio[0] + arrFinicio[1] + arrFinicio[2];

            ffin = arrFfin[0] + arrFfin[1] + arrFfin[2];

            
            String especie = Request["especie"].ToString();
            String tipoInspeccion = Request["tipoInspeccion"].ToString();
            String centro = Request["centro"].ToString();
            String codProductor = "";
            String cop = "";
           
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
                //condicion_in.Add(productor);
                codProductor += productor;
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

                //condicion_in = new ArrayList();
                

                foreach (ZMOV_QUERYS_PRODUCT_LT_DATA item in obj.LT_DATA)
                {
                    //condicion_in.Add(item.LIFNR);
                    codProductor += item.LIFNR + ";";

                }
            }

            String url = "http://10.20.1.123/hana/ddc/getLotesListHana.php?especie=" + especie + "&tipoInspeccion=" + tipoInspeccion + "&centro=" + centro + "&productor=" + codProductor + "&finicio=" + finicio + "&ffin=" + ffin + "&season=" + season;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            var response = (HttpWebResponse)request.GetResponse();
            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }
            var releases = JArray.Parse(content);

            //Array res = db.GetProduccionAcumulada(condicion_in);
            var json2 = releases;
            json.Text = json2.ToString();
        }
    }
}