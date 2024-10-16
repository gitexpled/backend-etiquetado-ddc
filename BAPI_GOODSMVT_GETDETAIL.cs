using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class BAPI_GOODSMVT_GETDETAIL
    {
        public responce_BAPI_GOODSMVT_GETDETAIL sapRun(request_BAPI_GOODSMVT_GETDETAIL import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("BAPI_GOODSMVT_GETDETAIL");

            rfcFunction.SetValue("MATDOCUMENTYEAR", import.MATDOCUMENTYEAR);
            rfcFunction.SetValue("MATERIALDOCUMENT", import.MATERIALDOCUMENT);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_BAPI_GOODSMVT_GETDETAIL res = new responce_BAPI_GOODSMVT_GETDETAIL();
            IRfcTable rfcTable_GOODSMVT_ITEMS = rfcFunction.GetTable("GOODSMVT_ITEMS");
            res.GOODSMVT_ITEMS = new BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS[rfcTable_GOODSMVT_ITEMS.RowCount];
            int i_GOODSMVT_ITEMS = 0;
            foreach (IRfcStructure row in rfcTable_GOODSMVT_ITEMS)
            {
                BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS datoTabla = new BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS();
                datoTabla.MAT_DOC = row.GetString("MAT_DOC");
                datoTabla.DOC_YEAR = row.GetInt("DOC_YEAR");
                datoTabla.MATDOC_ITM = row.GetInt("MATDOC_ITM");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.MOVE_TYPE = row.GetString("MOVE_TYPE");
                datoTabla.STCK_TYPE = row.GetString("STCK_TYPE");
                datoTabla.SPEC_STOCK = row.GetString("SPEC_STOCK");
                datoTabla.VENDOR = row.GetString("VENDOR");
                datoTabla.CUSTOMER = row.GetString("CUSTOMER");
                datoTabla.SALES_ORD = row.GetString("SALES_ORD");
                datoTabla.S_ORD_ITEM = row.GetInt("S_ORD_ITEM");
                datoTabla.SCHED_LINE = row.GetInt("SCHED_LINE");
                datoTabla.VAL_TYPE = row.GetString("VAL_TYPE");
                datoTabla.ENTRY_QNT = row.GetDecimal("ENTRY_QNT");
                datoTabla.ENTRY_UOM = row.GetString("ENTRY_UOM");
                datoTabla.ENTRY_UOM_ISO = row.GetString("ENTRY_UOM_ISO");
                datoTabla.PO_PR_QNT = row.GetDecimal("PO_PR_QNT");
                datoTabla.ORDERPR_UN = row.GetString("ORDERPR_UN");
                datoTabla.ORDERPR_UN_ISO = row.GetString("ORDERPR_UN_ISO");
                datoTabla.PO_NUMBER = row.GetString("PO_NUMBER");
                datoTabla.PO_ITEM = row.GetInt("PO_ITEM");
                datoTabla.SHIPPING = row.GetString("SHIPPING");
                datoTabla.COMP_SHIP = row.GetString("COMP_SHIP");
                datoTabla.NO_MORE_GR = row.GetString("NO_MORE_GR");
                datoTabla.ITEM_TEXT = row.GetString("ITEM_TEXT");
                datoTabla.GR_RCPT = row.GetString("GR_RCPT");
                datoTabla.UNLOAD_PT = row.GetString("UNLOAD_PT");
                datoTabla.COSTCENTER = row.GetString("COSTCENTER");
                datoTabla.ORDERID = row.GetString("ORDERID");
                datoTabla.ORDER_ITNO = row.GetInt("ORDER_ITNO");
                datoTabla.CALC_MOTIVE = row.GetString("CALC_MOTIVE");
                datoTabla.ASSET_NO = row.GetString("ASSET_NO");
                datoTabla.SUB_NUMBER = row.GetString("SUB_NUMBER");
                datoTabla.RESERV_NO = row.GetInt("RESERV_NO");
                datoTabla.RES_ITEM = row.GetInt("RES_ITEM");
                datoTabla.RES_TYPE = row.GetString("RES_TYPE");
                datoTabla.WITHDRAWN = row.GetString("WITHDRAWN");
                datoTabla.MOVE_MAT = row.GetString("MOVE_MAT");
                datoTabla.MOVE_PLANT = row.GetString("MOVE_PLANT");
                datoTabla.MOVE_STLOC = row.GetString("MOVE_STLOC");
                datoTabla.MOVE_BATCH = row.GetString("MOVE_BATCH");
                datoTabla.MOVE_VAL_TYPE = row.GetString("MOVE_VAL_TYPE");
                datoTabla.MVT_IND = row.GetString("MVT_IND");
                datoTabla.MOVE_REAS = row.GetInt("MOVE_REAS");
                datoTabla.RL_EST_KEY = row.GetString("RL_EST_KEY");
                datoTabla.REF_DATE = row.GetString("REF_DATE");
                datoTabla.COST_OBJ = row.GetString("COST_OBJ");
                datoTabla.PROFIT_SEGM_NO = row.GetInt("PROFIT_SEGM_NO");
                datoTabla.PROFIT_CTR = row.GetString("PROFIT_CTR");
                datoTabla.WBS_ELEM = row.GetString("WBS_ELEM");
                datoTabla.NETWORK = row.GetString("NETWORK");
                datoTabla.ACTIVITY = row.GetString("ACTIVITY");
                datoTabla.PART_ACCT = row.GetString("PART_ACCT");
                datoTabla.AMOUNT_LC = row.GetDecimal("AMOUNT_LC");
                datoTabla.AMOUNT_SV = row.GetDecimal("AMOUNT_SV");
                datoTabla.CURRENCY = row.GetString("CURRENCY");
                datoTabla.CURRENCY_ISO = row.GetString("CURRENCY_ISO");
                datoTabla.REF_DOC_YR = row.GetInt("REF_DOC_YR");
                datoTabla.REF_DOC = row.GetString("REF_DOC");
                datoTabla.REF_DOC_IT = row.GetInt("REF_DOC_IT");
                datoTabla.EXPIRYDATE = row.GetString("EXPIRYDATE");
                datoTabla.PROD_DATE = row.GetString("PROD_DATE");
                datoTabla.FUND = row.GetString("FUND");
                datoTabla.FUNDS_CTR = row.GetString("FUNDS_CTR");
                datoTabla.CMMT_ITEM = row.GetString("CMMT_ITEM");
                datoTabla.VAL_SALES_ORD = row.GetString("VAL_SALES_ORD");
                datoTabla.VAL_S_ORD_ITEM = row.GetInt("VAL_S_ORD_ITEM");
                datoTabla.VAL_WBS_ELEM = row.GetString("VAL_WBS_ELEM");
                datoTabla.CO_BUSPROC = row.GetString("CO_BUSPROC");
                datoTabla.ACTTYPE = row.GetString("ACTTYPE");
                datoTabla.SUPPL_VEND = row.GetString("SUPPL_VEND");
                datoTabla.X_AUTO_CRE = row.GetString("X_AUTO_CRE");
                datoTabla.MATERIAL_EXTERNAL = row.GetString("MATERIAL_EXTERNAL");
                datoTabla.MATERIAL_GUID = row.GetString("MATERIAL_GUID");
                datoTabla.MATERIAL_VERSION = row.GetString("MATERIAL_VERSION");
                datoTabla.MOVE_MAT_EXTERNAL = row.GetString("MOVE_MAT_EXTERNAL");
                datoTabla.MOVE_MAT_GUID = row.GetString("MOVE_MAT_GUID");
                datoTabla.MOVE_MAT_VERSION = row.GetString("MOVE_MAT_VERSION");
                datoTabla.GRANT_NBR = row.GetString("GRANT_NBR");
                datoTabla.CMMT_ITEM_LONG = row.GetString("CMMT_ITEM_LONG");
                datoTabla.FUNC_AREA_LONG = row.GetString("FUNC_AREA_LONG");
                datoTabla.LINE_ID = row.GetInt("LINE_ID");
                datoTabla.PARENT_ID = row.GetInt("PARENT_ID");
                datoTabla.LINE_DEPTH = row.GetInt("LINE_DEPTH");
                datoTabla.BUDGET_PERIOD = row.GetString("BUDGET_PERIOD");
                datoTabla.EARMARKED_NUMBER = row.GetString("EARMARKED_NUMBER");
                datoTabla.EARMARKED_ITEM = row.GetInt("EARMARKED_ITEM");
                datoTabla.STK_SEGMENT = row.GetString("STK_SEGMENT");
                //datoTabla.MATERIAL_LONG = row.GetString("MATERIAL_LONG");
                //datoTabla.MOVE_MAT_LONG = row.GetString("MOVE_MAT_LONG");
                res.GOODSMVT_ITEMS[i_GOODSMVT_ITEMS] = datoTabla; ++i_GOODSMVT_ITEMS;
            }
            //IRfcTable rfcTable_GOODSMVT_ITEMS_CWM = rfcFunction.GetTable("GOODSMVT_ITEMS_CWM");
            //res.GOODSMVT_ITEMS_CWM = new BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS_CWM[rfcTable_GOODSMVT_ITEMS_CWM.RowCount];
            //int i_GOODSMVT_ITEMS_CWM = 0;
            //foreach (IRfcStructure row in rfcTable_GOODSMVT_ITEMS_CWM)
            //{
            //    BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS_CWM datoTabla = new BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS_CWM();
            //    datoTabla.MAT_DOC = row.GetString("MAT_DOC");
            //    datoTabla.DOC_YEAR = row.GetInt("DOC_YEAR");
            //    datoTabla.MATDOC_ITM = row.GetInt("MATDOC_ITM");
            //    datoTabla.QUANTITY_PME = row.GetDecimal("QUANTITY_PME");
            //    datoTabla.BASE_UOM_PME = row.GetString("BASE_UOM_PME");
            //    datoTabla.ENTRY_QNT_PME = row.GetDecimal("ENTRY_QNT_PME");
            //    datoTabla.ENTRY_UOM_PME = row.GetString("ENTRY_UOM_PME");
            //    res.GOODSMVT_ITEMS_CWM[i_GOODSMVT_ITEMS_CWM] = datoTabla; ++i_GOODSMVT_ITEMS_CWM;
            //}

            IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
            res.RETURN = new BAPI_GOODSMVT_GETDETAIL_RETURN[rfcTable_RETURN.RowCount];
            int i_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_RETURN)
            {
                BAPI_GOODSMVT_GETDETAIL_RETURN datoTabla = new BAPI_GOODSMVT_GETDETAIL_RETURN();
                datoTabla.TYPE = row.GetString("TYPE");
                datoTabla.ID = row.GetString("ID");
                datoTabla.NUMBER = row.GetInt("NUMBER");
                datoTabla.MESSAGE = row.GetString("MESSAGE");
                datoTabla.LOG_NO = row.GetString("LOG_NO");
                datoTabla.LOG_MSG_NO = row.GetInt("LOG_MSG_NO");
                datoTabla.MESSAGE_V1 = row.GetString("MESSAGE_V1");
                datoTabla.MESSAGE_V2 = row.GetString("MESSAGE_V2");
                datoTabla.MESSAGE_V3 = row.GetString("MESSAGE_V3");
                datoTabla.MESSAGE_V4 = row.GetString("MESSAGE_V4");
                datoTabla.PARAMETER = row.GetString("PARAMETER");
                datoTabla.ROW = row.GetInt("ROW");
                datoTabla.FIELD = row.GetString("FIELD");
                datoTabla.SYSTEM = row.GetString("SYSTEM");
                res.RETURN[i_RETURN] = datoTabla; ++i_RETURN;
            }

            return res;
        }
    }
    public class request_BAPI_GOODSMVT_GETDETAIL
    {
        public Int32 MATDOCUMENTYEAR;
        public String MATERIALDOCUMENT;
    }
    public class responce_BAPI_GOODSMVT_GETDETAIL
    {
        public BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS[] GOODSMVT_ITEMS;
        public BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS_CWM[] GOODSMVT_ITEMS_CWM;
        public BAPI_GOODSMVT_GETDETAIL_RETURN[] RETURN;
    }
    public class BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS
    {
        public String MAT_DOC;
        public Int32 DOC_YEAR;
        public Int32 MATDOC_ITM;
        public String MATERIAL;
        public String PLANT;
        public String STGE_LOC;
        public String BATCH;
        public String MOVE_TYPE;
        public String STCK_TYPE;
        public String SPEC_STOCK;
        public String VENDOR;
        public String CUSTOMER;
        public String SALES_ORD;
        public Int32 S_ORD_ITEM;
        public Int32 SCHED_LINE;
        public String VAL_TYPE;
        public Decimal ENTRY_QNT;
        public String ENTRY_UOM;
        public String ENTRY_UOM_ISO;
        public Decimal PO_PR_QNT;
        public String ORDERPR_UN;
        public String ORDERPR_UN_ISO;
        public String PO_NUMBER;
        public Int32 PO_ITEM;
        public String SHIPPING;
        public String COMP_SHIP;
        public String NO_MORE_GR;
        public String ITEM_TEXT;
        public String GR_RCPT;
        public String UNLOAD_PT;
        public String COSTCENTER;
        public String ORDERID;
        public Int32 ORDER_ITNO;
        public String CALC_MOTIVE;
        public String ASSET_NO;
        public String SUB_NUMBER;
        public Int32 RESERV_NO;
        public Int32 RES_ITEM;
        public String RES_TYPE;
        public String WITHDRAWN;
        public String MOVE_MAT;
        public String MOVE_PLANT;
        public String MOVE_STLOC;
        public String MOVE_BATCH;
        public String MOVE_VAL_TYPE;
        public String MVT_IND;
        public Int32 MOVE_REAS;
        public String RL_EST_KEY;
        public String REF_DATE;
        public String COST_OBJ;
        public Int32 PROFIT_SEGM_NO;
        public String PROFIT_CTR;
        public String WBS_ELEM;
        public String NETWORK;
        public String ACTIVITY;
        public String PART_ACCT;
        public Decimal AMOUNT_LC;
        public Decimal AMOUNT_SV;
        public String CURRENCY;
        public String CURRENCY_ISO;
        public Int32 REF_DOC_YR;
        public String REF_DOC;
        public Int32 REF_DOC_IT;
        public String EXPIRYDATE;
        public String PROD_DATE;
        public String FUND;
        public String FUNDS_CTR;
        public String CMMT_ITEM;
        public String VAL_SALES_ORD;
        public Int32 VAL_S_ORD_ITEM;
        public String VAL_WBS_ELEM;
        public String CO_BUSPROC;
        public String ACTTYPE;
        public String SUPPL_VEND;
        public String X_AUTO_CRE;
        public String MATERIAL_EXTERNAL;
        public String MATERIAL_GUID;
        public String MATERIAL_VERSION;
        public String MOVE_MAT_EXTERNAL;
        public String MOVE_MAT_GUID;
        public String MOVE_MAT_VERSION;
        public String GRANT_NBR;
        public String CMMT_ITEM_LONG;
        public String FUNC_AREA_LONG;
        public Int32 LINE_ID;
        public Int32 PARENT_ID;
        public Int32 LINE_DEPTH;
        public String BUDGET_PERIOD;
        public String EARMARKED_NUMBER;
        public Int32 EARMARKED_ITEM;
        public String STK_SEGMENT;
        public String MATERIAL_LONG;
        public String MOVE_MAT_LONG;
    }
    public class BAPI_GOODSMVT_GETDETAIL_GOODSMVT_ITEMS_CWM
    {
        public String MAT_DOC;
        public Int32 DOC_YEAR;
        public Int32 MATDOC_ITM;
        public Decimal QUANTITY_PME;
        public String BASE_UOM_PME;
        public Decimal ENTRY_QNT_PME;
        public String ENTRY_UOM_PME;
    }
    public class BAPI_GOODSMVT_GETDETAIL_RETURN
    {
        public String TYPE;
        public String ID;
        public Int32 NUMBER;
        public String MESSAGE;
        public String LOG_NO;
        public Int32 LOG_MSG_NO;
        public String MESSAGE_V1;
        public String MESSAGE_V2;
        public String MESSAGE_V3;
        public String MESSAGE_V4;
        public String PARAMETER;
        public Int32 ROW;
        public String FIELD;
        public String SYSTEM;
    }

}