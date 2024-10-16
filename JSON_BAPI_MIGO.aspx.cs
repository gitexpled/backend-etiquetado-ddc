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
    public partial class JSON_BAPI_MIGO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String PARAMETRO = Request["PARAMETRO"].ToString();

            var json2 = new JavaScriptSerializer().Serialize(Ejecuta_BAPI_MIGO(PARAMETRO));
            json.Text = json2.ToString();
        }

        public static object Ejecuta_BAPI_MIGO(string ObjetoEntrada = "")
        {
            String MOVIMIENTO = "";
            String FECHA = "";
            String GM_CODE = "";

            JArray ListaMateriales = new JArray();


            dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);
            MOVIMIENTO = Objeto.PARAMETROS.MOVIMIENTO;
            
            ListaMateriales = Objeto.PARAMETROS.POSICIONES;
           
            GM_CODE = Objeto.PARAMETROS.HEADER.GM_CODE;

           
            
            BAPI_GOODSMVT_CREATE sap = new BAPI_GOODSMVT_CREATE();

            request_BAPI_GOODSMVT_CREATE imp = new request_BAPI_GOODSMVT_CREATE();

            imp.GOODSMVT_CODE = new BAPI_GOODSMVT_CREATE_GOODSMVT_CODE();
            imp.GOODSMVT_HEADER = new BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER();
            imp.GOODSMVT_CODE.GM_CODE = GM_CODE;


            imp.GOODSMVT_HEADER.PSTNG_DATE = DateTime.Now.ToString("yyyyMMdd");
            imp.GOODSMVT_HEADER.DOC_DATE = DateTime.Now.ToString("yyyyMMdd"); ;
            imp.GOODSMVT_HEADER.HEADER_TXT = Objeto.PARAMETROS.HEADER.HEADER_TXT;
            imp.GOODSMVT_HEADER.REF_DOC_NO = Objeto.PARAMETROS.HEADER.REF_DOC_NO;

            JArray MATERIAL_PT = new JArray();
            MATERIAL_PT = Objeto.PARAMETROS.MATERIALES;
            //String MATERIAL_PT = Objeto.PARAMETROS.MATERIALES;
            String TOTAL = Objeto.PARAMETROS.TOTAL;



            imp.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[ListaMateriales.Count];

            int i = 0;

            foreach (dynamic mat in ListaMateriales)
            {
                imp.GOODSMVT_ITEM[i] = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();

                imp.GOODSMVT_ITEM[i].MOVE_TYPE = mat.MOVE_TYPE.ToString(); ;
                imp.GOODSMVT_ITEM[i].MATERIAL = mat.MATERIAL.ToString();
                imp.GOODSMVT_ITEM[i].PLANT = mat.CENTRO.ToString();
                imp.GOODSMVT_ITEM[i].STGE_LOC = mat.ALMACEN.ToString();
                imp.GOODSMVT_ITEM[i].ENTRY_QNT = decimal.Parse(mat.ENTRY_QNT.ToString());
                //imp.GOODSMVT_ITEM[i].ENTRY_UOM = "KG";//mat.UNIDAD.ToString();
                //imp.GOODSMVT_ITEM[i].VENDOR = PRODUCTOR;
                imp.GOODSMVT_ITEM[i].BATCH = mat.BATCH;

                i++;
            }


            responce_BAPI_GOODSMVT_CREATE obj = new responce_BAPI_GOODSMVT_CREATE();


            //obj = sap.sapRun(imp, configSAP, SapRfcRepository);
            obj = sap.sapRun(imp);


            if (obj.MATERIALDOCUMENT != "")
            {
                obj.RESULTADO_BAPI = true;
                obj.DOCUMENTO = obj.MATERIALDOCUMENT;
            }
            else
                obj.RESULTADO_BAPI = false;

            return obj;
        }

    }
}