using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_ZMOV_CREATE_HU : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String HU_EXID = Request["HU_EXID"].ToString();
            String BATCH = Request["BATCH"].ToString();
            String PACK_QTY = Request["PACK_QTY"].ToString();
            

            ZMOV_CREATE_HU sap = new ZMOV_CREATE_HU();

            request_ZMOV_CREATE_HU imp = new request_ZMOV_CREATE_HU();
            imp.HEADER_HU = new ZMOV_CREATE_HU_HEADER_HU();

            imp.HEADER_HU.PACK_MAT = "HUP01";

            imp.HEADER_HU.LGORT_DS = "PA04";
            imp.HEADER_HU.HU_EXID = HU_EXID; //"100200300401"; //Numero de pallet a escanear se escnea

            imp.ITEM_HU = new ZMOV_CREATE_HU_ITEM_HU[1];
            imp.ITEM_HU[0] = new ZMOV_CREATE_HU_ITEM_HU();

            
            imp.ITEM_HU[0].HU_ITEM_TYPE = "1";
            
            imp.ITEM_HU[0].PACK_QTY = decimal.Parse(PACK_QTY); //1; //Cantidad de cajas a informar se escanea
            
            imp.ITEM_HU[0].BASE_UNIT_QTY = "CS";
            

            imp.ITEM_HU[0].MATERIAL = "MANZANA_TERMINADO";
            
            imp.ITEM_HU[0].BATCH = BATCH;   //"LOTE1";     //Lote de proceso se escanea
            
            imp.ITEM_HU[0].PLANT = "DC10";
            imp.ITEM_HU[0].STGE_LOC = "PA03";


            responce_ZMOV_CREATE_HU obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}