using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;

namespace rfcBaika
{
    public partial class JSON_BAPI_MIGO_GENERAL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String PARAMETRO = Request["PARAMETRO"].ToString();
            dynamic Objeto = JsonConvert.DeserializeObject(PARAMETRO);

            ArrayList response = new ArrayList(); 
            responce_BAPI_GOODSMVT_CREATE migo_101 = Ejecuta_BAPI_MIGO(Objeto[0]);
            response.Add(migo_101);
            if (migo_101.MATERIALDOCUMENT != "")
            {
                responce_BAPI_GOODSMVT_GETDETAIL get_detail_migo = BAPI_GOODSMVT_GETDETAIL(migo_101.MATERIALDOCUMENT);
                string lote_101 = get_detail_migo.GOODSMVT_ITEMS[0].BATCH;
                responce_BAPI_GOODSMVT_CREATE migo_309 = Ejecuta_BAPI_MIGO(Objeto[1], lote_101);
                response.Add(migo_309);
                if (migo_309.MATERIALDOCUMENT != "")
                {
                    responce_BAPI_GOODSMVT_CREATE migo_541 = Ejecuta_BAPI_MIGO(Objeto[2]);
                    response.Add(migo_541);
                    if (migo_541.MATERIALDOCUMENT == "")
                    {
                        responce_BAPI_GOODSMVT_CANCEL migo_cancel_101 = Ejecuta_BAPI_MIGO_CANCEL(migo_101.MATERIALDOCUMENT);
                        response.Add(migo_cancel_101);
                        responce_BAPI_GOODSMVT_CANCEL migo_cancel_309 = Ejecuta_BAPI_MIGO_CANCEL(migo_309.MATERIALDOCUMENT);
                        response.Add(migo_cancel_309);
                    }
                }
                else {
                    responce_BAPI_GOODSMVT_CANCEL migo_cancel_309 = Ejecuta_BAPI_MIGO_CANCEL(migo_309.MATERIALDOCUMENT);
                    response.Add(migo_cancel_309);
                }
            }


            var json2 = new JavaScriptSerializer().Serialize(response);
            json.Text = json2.ToString();
        }

        public static responce_BAPI_GOODSMVT_CREATE Ejecuta_BAPI_MIGO(dynamic ObjetoEntrada, string BATCH = "")
        {

            dynamic Objeto = ObjetoEntrada;

            string GM_CODE = Objeto.GOODSMVT_CODE.GM_CODE;
            string PSTNG_DATE = Objeto.GOODSMVT_HEADER.PSTNG_DATE;
            string DOC_DATE = Objeto.GOODSMVT_HEADER.DOC_DATE;
            string HEADER_TXT = Objeto.GOODSMVT_HEADER.HEADER_TXT;
            string REF_DOC_NO = Objeto.GOODSMVT_HEADER.REF_DOC_NO;

            JArray ListaMateriales = new JArray();
            ListaMateriales = Objeto.GOODSMVT_ITEM;          

            request_BAPI_GOODSMVT_CREATE imp = new request_BAPI_GOODSMVT_CREATE();

            imp.GOODSMVT_CODE = new BAPI_GOODSMVT_CREATE_GOODSMVT_CODE();
            imp.GOODSMVT_CODE.GM_CODE = GM_CODE;
            imp.GOODSMVT_HEADER = new BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER();
            imp.GOODSMVT_HEADER.PSTNG_DATE = PSTNG_DATE;
            imp.GOODSMVT_HEADER.DOC_DATE = DOC_DATE;
            imp.GOODSMVT_HEADER.HEADER_TXT = HEADER_TXT;
            imp.GOODSMVT_HEADER.REF_DOC_NO = REF_DOC_NO;

            imp.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[ListaMateriales.Count];

            int i = 0;

            foreach (dynamic mat in ListaMateriales)
            {
                imp.GOODSMVT_ITEM[i] = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();
                imp.GOODSMVT_ITEM[i].MATERIAL = mat.MATERIAL.ToString();
                imp.GOODSMVT_ITEM[i].MOVE_MAT = (mat.MOVE_MAT != null ? mat.MOVE_MAT.ToString(): "");
                imp.GOODSMVT_ITEM[i].BATCH = (BATCH== ""? mat.BATCH : BATCH);
                imp.GOODSMVT_ITEM[i].MOVE_BATCH = (mat.MOVE_BATCH != null ? mat.MOVE_BATCH.ToString() : "");
                imp.GOODSMVT_ITEM[i].PLANT = mat.PLANT.ToString();
                imp.GOODSMVT_ITEM[i].MOVE_PLANT = (mat.MOVE_PLANT != null ? mat.MOVE_PLANT.ToString() : "");
                imp.GOODSMVT_ITEM[i].STGE_LOC = mat.STGE_LOC.ToString();
                imp.GOODSMVT_ITEM[i].MOVE_STLOC = (mat.MOVE_STLOC != null ? mat.MOVE_STLOC.ToString() : "");
                imp.GOODSMVT_ITEM[i].MVT_IND = (mat.MVT_IND != null ? mat.MVT_IND : "");
                imp.GOODSMVT_ITEM[i].MOVE_TYPE = mat.MOVE_TYPE.ToString(); ;
                imp.GOODSMVT_ITEM[i].ENTRY_QNT = decimal.Parse(mat.ENTRY_QNT.ToString());
                //imp.GOODSMVT_ITEM[i].PO_PR_QNT = decimal.Parse(mat.PO_PR_QNT.ToString());
                imp.GOODSMVT_ITEM[i].PO_NUMBER = (mat.PO_NUMBER != null ? mat.PO_NUMBER : "");
                imp.GOODSMVT_ITEM[i].PO_ITEM = (mat.PO_ITEM != null ? mat.PO_ITEM : 10);
                imp.GOODSMVT_ITEM[i].VENDOR = (mat.VENDOR != null ? mat.VENDOR : "");
                i++;
            }

            BAPI_GOODSMVT_CREATE sap = new BAPI_GOODSMVT_CREATE();

            responce_BAPI_GOODSMVT_CREATE obj = sap.sapRun(imp);

            if (obj.MATERIALDOCUMENT != "")
            {
                obj.RESULTADO_BAPI = true;
                obj.DOCUMENTO = obj.MATERIALDOCUMENT;

            }
            else
                obj.RESULTADO_BAPI = false;

            return obj;
        }
        public static responce_BAPI_GOODSMVT_GETDETAIL BAPI_GOODSMVT_GETDETAIL(string DOCUMENTO = "")
        {
            BAPI_GOODSMVT_GETDETAIL SAPLOTE = new BAPI_GOODSMVT_GETDETAIL();
            request_BAPI_GOODSMVT_GETDETAIL lote = new request_BAPI_GOODSMVT_GETDETAIL();
            lote.MATDOCUMENTYEAR = DateTime.Now.Year;
            lote.MATERIALDOCUMENT = DOCUMENTO;
            responce_BAPI_GOODSMVT_GETDETAIL RESPONSELOTE = SAPLOTE.sapRun(lote);

            return RESPONSELOTE;
        }
        public static responce_BAPI_GOODSMVT_CANCEL Ejecuta_BAPI_MIGO_CANCEL(string documentoMaterial)
        {

            BAPI_GOODSMVT_CANCEL sap = new BAPI_GOODSMVT_CANCEL();

            request_BAPI_GOODSMVT_CANCEL imp = new request_BAPI_GOODSMVT_CANCEL();
            imp.MATERIALDOCUMENT = documentoMaterial;
            imp.MATDOCUMENTYEAR = DateTime.Now.Year;
            responce_BAPI_GOODSMVT_CANCEL obj = new responce_BAPI_GOODSMVT_CANCEL();
            obj = sap.sapRun(imp);


            if (obj.HEADRET.MATDOC_ITEM != "")
            {
                obj.RESULTADO_BAPI = true;
                obj.DOCUMENTO = obj.HEADRET.MATDOC_ITEM.ToString();
            }
            else
                obj.RESULTADO_BAPI = false;

            return obj;
        }

    }
}