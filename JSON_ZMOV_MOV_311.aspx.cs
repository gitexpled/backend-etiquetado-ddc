using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public partial class JSON_ZMOV_MOV_311 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dynamic Datos = JsonConvert.DeserializeObject(((Request["DATA"] != null) ? Request["DATA"].ToString() : ""));
            JArray ITEMS = JArray.Parse((Datos.ITEMS != null) ? Datos.ITEMS.ToString() : "[]");
            BAPI_GOODSMVT_CREATE sap = new BAPI_GOODSMVT_CREATE();
            request_BAPI_GOODSMVT_CREATE req = new request_BAPI_GOODSMVT_CREATE();
            req.GOODSMVT_HEADER = new BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER();
            req.GOODSMVT_HEADER.PSTNG_DATE = Datos.FECHA;
            req.GOODSMVT_HEADER.DOC_DATE = Datos.FECHA;
            req.GOODSMVT_CODE = new BAPI_GOODSMVT_CREATE_GOODSMVT_CODE();
            req.GOODSMVT_CODE.GM_CODE = "04";
            int cont = 0;
            req.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[ITEMS.Count];
            foreach (dynamic item in ITEMS)
            {
                req.GOODSMVT_ITEM[cont] = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();
                req.GOODSMVT_ITEM[cont].MATERIAL = item.MATERIAL;
                req.GOODSMVT_ITEM[cont].PLANT = item.CENTRO;
                req.GOODSMVT_ITEM[cont].STGE_LOC = item.ALMACEM;
                req.GOODSMVT_ITEM[cont].BATCH = item.LOTE;
                req.GOODSMVT_ITEM[cont].MOVE_TYPE = "311";
                req.GOODSMVT_ITEM[cont].ENTRY_UOM_ISO = item.UNIDAD;
                req.GOODSMVT_ITEM[cont].ENTRY_QNT = item.CANTIDAD;
                req.GOODSMVT_ITEM[cont].MOVE_BATCH = item.LOTE;
                req.GOODSMVT_ITEM[cont].MOVE_PLANT = item.CENTRO;
                req.GOODSMVT_ITEM[cont].MOVE_STLOC = item.ALMACEN_DESTINO;
                cont++;
            }
            responce_BAPI_GOODSMVT_CREATE obj = sap.sapRun(req);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}