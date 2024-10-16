using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace rfcBaika
{
    public partial class JSON_BAPI_CARACT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String PARAMETRO = Request["PARAMETRO"].ToString();

            var json2 = new JavaScriptSerializer().Serialize(Ejecuta_BAPI_ACTUALIZA_LOTE(PARAMETRO));
            json.Text = json2.ToString();
        }
        public static object Ejecuta_BAPI_ACTUALIZA_LOTE(string ObjetoEntrada = "")
        {

            dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);
            dynamic ListaCaracteristicas = null;
            int Caracteristicas_Count = 0;
            ListaCaracteristicas = Objeto.PARAMETROS.CARACTERISTICAS;
            Caracteristicas_Count = ListaCaracteristicas.Count;
            ZMOV_UPDATE_CALIDAD_LOTE sap = new ZMOV_UPDATE_CALIDAD_LOTE();
            request_ZMOV_UPDATE_CALIDAD_LOTE imp = new request_ZMOV_UPDATE_CALIDAD_LOTE();
            String lote = "";
            List<String> cantidad_lotes = new List<String>();
            for (int p = 0; p < ListaCaracteristicas.Count; p++)
            {
                lote = ListaCaracteristicas[p].BATCH;
                if (!cantidad_lotes.Contains(lote))
                {
                    cantidad_lotes.Add(lote);
                }
            }
            imp.IT_CHARG = new ZMOV_UPDATE_CALIDAD_LOTE_IT_CHARG[cantidad_lotes.Count];
            imp.LT_CARACT = new ZMOV_UPDATE_CALIDAD_LOTE_LT_CARACT[Caracteristicas_Count];

            int contador = 0;
            lote = "";
            List<String> valida_lotes = new List<String>();
            for (int i = 0; i < Caracteristicas_Count; i++)
            {
                lote = ListaCaracteristicas[i].BATCH;
                if (!valida_lotes.Contains(lote))
                {
                    valida_lotes.Add(lote);
                    imp.IT_CHARG[contador] = new ZMOV_UPDATE_CALIDAD_LOTE_IT_CHARG();
                    imp.IT_CHARG[contador].CHARG = ListaCaracteristicas[i].BATCH;
                    contador++;
                }
               
                imp.LT_CARACT[i] = new ZMOV_UPDATE_CALIDAD_LOTE_LT_CARACT();
                imp.LT_CARACT[i].BATCH = ListaCaracteristicas[i].BATCH;
                imp.LT_CARACT[i].CHARACT = ListaCaracteristicas[i].CARACTERISTICA;
                imp.LT_CARACT[i].VALUE_CHAR = ListaCaracteristicas[i].VALUE_CHAR;

            }

            responce_ZMOV_UPDATE_CALIDAD_LOTE res = sap.sapRun(imp);
            res.RESULTADO_BAPI = true;

            return res;

        }
        
    }
}