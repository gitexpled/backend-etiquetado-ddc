using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10006
    {
        public responce_ZMOV_10006 sapRun(request_ZMOV_10006 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10006");

          
            rfcFunction.SetValue("MATERIAL", import.MATERIAL);
                    
            rfcFunction.SetValue("PLANT", import.PLANT);
            
            rfcFunction.SetValue("PURCHASEORDER", import.PURCHASEORDER);
            rfcFunction.SetValue("WITH_PO_HEADERS", "X");
            rfcFunction.SetValue("ITEMS_OPEN_FOR_RECEIPT", import.ITEMS_OPEN_FOR_RECEIPT);
            rfcFunction.SetValue("VENDOR", import.VENDOR);
            
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10006 res = new responce_ZMOV_10006();
            IRfcTable rfcTable_PO_CONSUMO = rfcFunction.GetTable("PO_CONSUMO");
            res.PO_CONSUMO = new ZMOV_10006_PO_CONSUMO[rfcTable_PO_CONSUMO.RowCount];
            int i_PO_CONSUMO = 0;
            foreach (IRfcStructure row in rfcTable_PO_CONSUMO)
            {
                ZMOV_10006_PO_CONSUMO datoTabla = new ZMOV_10006_PO_CONSUMO();
                datoTabla.EBELN = row.GetString("EBELN");
                datoTabla.EBELP = row.GetInt("EBELP");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MENGE = row.GetDecimal("MENGE");
                res.PO_CONSUMO[i_PO_CONSUMO] = datoTabla; ++i_PO_CONSUMO;
            }
            IRfcTable rfcTable_PO_HEADERS = rfcFunction.GetTable("PO_HEADERS");
            res.PO_HEADERS = new ZMOV_10006_PO_HEADERS[rfcTable_PO_HEADERS.RowCount];
            int i_PO_HEADERS = 0;
            foreach (IRfcStructure row in rfcTable_PO_HEADERS)
            {
                ZMOV_10006_PO_HEADERS datoTabla = new ZMOV_10006_PO_HEADERS();
                datoTabla.PO_NUMBER = row.GetString("PO_NUMBER");
                datoTabla.CO_CODE = row.GetString("CO_CODE");
                datoTabla.DOC_CAT = row.GetString("DOC_CAT");
                datoTabla.DOC_TYPE = row.GetString("DOC_TYPE");
                datoTabla.CNTRL_IND = row.GetString("CNTRL_IND");
                datoTabla.DELETE_IND = row.GetString("DELETE_IND");
                datoTabla.STATUS = row.GetString("STATUS");
                datoTabla.CREATED_ON = row.GetString("CREATED_ON");
                datoTabla.CREATED_BY = row.GetString("CREATED_BY");
                datoTabla.ITEM_INTVL = row.GetInt("ITEM_INTVL");
                datoTabla.LAST_ITEM = row.GetInt("LAST_ITEM");
                datoTabla.VENDOR = row.GetString("VENDOR");
                datoTabla.LANGUAGE = row.GetString("LANGUAGE");
                datoTabla.PMNTTRMS = row.GetString("PMNTTRMS");
                datoTabla.DSCNT1_TO = row.GetDecimal("DSCNT1_TO");
                datoTabla.DSCNT2_TO = row.GetDecimal("DSCNT2_TO");
                datoTabla.DSCNT3_TO = row.GetDecimal("DSCNT3_TO");
                datoTabla.CASH_DISC1 = row.GetDecimal("CASH_DISC1");
                datoTabla.CASH_DISC2 = row.GetDecimal("CASH_DISC2");
                datoTabla.PURCH_ORG = row.GetString("PURCH_ORG");
                datoTabla.PUR_GROUP = row.GetString("PUR_GROUP");
                datoTabla.CURRENCY = row.GetString("CURRENCY");
                datoTabla.EXCH_RATE = row.GetDecimal("EXCH_RATE");
                datoTabla.EX_RATE_FX = row.GetString("EX_RATE_FX");
                datoTabla.DOC_DATE = row.GetString("DOC_DATE");
                datoTabla.VPER_START = row.GetString("VPER_START");
                datoTabla.VPER_END = row.GetString("VPER_END");
                datoTabla.APPLIC_BY = row.GetString("APPLIC_BY");
                datoTabla.QUOT_DEAD = row.GetString("QUOT_DEAD");
                datoTabla.BINDG_PER = row.GetString("BINDG_PER");
                datoTabla.WARRANTY = row.GetString("WARRANTY");
                datoTabla.BIDINV_NO = row.GetString("BIDINV_NO");
                datoTabla.QUOTATION = row.GetString("QUOTATION");
                datoTabla.QUOT_DATE = row.GetString("QUOT_DATE");
                datoTabla.REF_1 = row.GetString("REF_1");
                datoTabla.SALES_PERS = row.GetString("SALES_PERS");
                datoTabla.TELEPHONE = row.GetString("TELEPHONE");
                datoTabla.SUPPL_VEND = row.GetString("SUPPL_VEND");
                datoTabla.CUSTOMER = row.GetString("CUSTOMER");
                datoTabla.AGREEMENT = row.GetString("AGREEMENT");
                datoTabla.REJ_REASON = row.GetString("REJ_REASON");
                datoTabla.COMPL_DLV = row.GetString("COMPL_DLV");
                datoTabla.GR_MESSAGE = row.GetString("GR_MESSAGE");
                datoTabla.SUPPL_PLNT = row.GetString("SUPPL_PLNT");
                datoTabla.RCVG_VEND = row.GetString("RCVG_VEND");
                datoTabla.INCOTERMS1 = row.GetString("INCOTERMS1");
                datoTabla.INCOTERMS2 = row.GetString("INCOTERMS2");
                datoTabla.TARGET_VAL = row.GetDecimal("TARGET_VAL");
                datoTabla.COLL_NO = row.GetString("COLL_NO");
                datoTabla.DOC_COND = row.GetString("DOC_COND");
                datoTabla.PROCEDURE = row.GetString("PROCEDURE");
                datoTabla.UPDATE_GRP = row.GetString("UPDATE_GRP");
                datoTabla.DIFF_INV = row.GetString("DIFF_INV");
                datoTabla.EXPORT_NO = row.GetString("EXPORT_NO");
                datoTabla.OUR_REF = row.GetString("OUR_REF");
                datoTabla.LOGSYSTEM = row.GetString("LOGSYSTEM");
                datoTabla.SUBITEMINT = row.GetInt("SUBITEMINT");
                datoTabla.MAST_COND = row.GetString("MAST_COND");
                datoTabla.REL_GROUP = row.GetString("REL_GROUP");
                datoTabla.REL_STRAT = row.GetString("REL_STRAT");
                datoTabla.REL_IND = row.GetString("REL_IND");
                datoTabla.REL_STATUS = row.GetString("REL_STATUS");
                datoTabla.SUBJ_TO_R = row.GetString("SUBJ_TO_R");
                datoTabla.TAXR_CNTRY = row.GetString("TAXR_CNTRY");
                datoTabla.SCHED_IND = row.GetString("SCHED_IND");
                datoTabla.VEND_NAME = row.GetString("VEND_NAME");
                datoTabla.CURRENCY_ISO = row.GetString("CURRENCY_ISO");
                datoTabla.EXCH_RATE_CM = row.GetDecimal("EXCH_RATE_CM");
                datoTabla.HOLD = row.GetString("HOLD");
                datoTabla.ZZTIPPED = row.GetString("ZZTIPPED");
                datoTabla.ZZDES_TIPPED = row.GetString("ZZDES_TIPPED");
                //datoTabla.ZZCUOTAS = row.GetInt("ZZCUOTAS");
                datoTabla.ZZVALCUO = row.GetDecimal("ZZVALCUO");
                res.PO_HEADERS[i_PO_HEADERS] = datoTabla; ++i_PO_HEADERS;
            }
            IRfcTable rfcTable_PO_ITEMS = rfcFunction.GetTable("PO_ITEMS");
            res.PO_ITEMS = new ZMOV_10006_PO_ITEMS[rfcTable_PO_ITEMS.RowCount];
            int i_PO_ITEMS = 0;
            foreach (IRfcStructure row in rfcTable_PO_ITEMS)
            {
                ZMOV_10006_PO_ITEMS datoTabla = new ZMOV_10006_PO_ITEMS();
                datoTabla.PO_NUMBER = row.GetString("PO_NUMBER");
                datoTabla.PO_ITEM = row.GetInt("PO_ITEM");
                datoTabla.ADDRESS = row.GetString("ADDRESS");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.PUR_MAT = row.GetString("PUR_MAT");
                datoTabla.INFO_REC = row.GetString("INFO_REC");
                datoTabla.ITEM_CAT = row.GetString("ITEM_CAT");
                datoTabla.ACCTASSCAT = row.GetString("ACCTASSCAT");
                datoTabla.AGREEMENT = row.GetString("AGREEMENT");
                datoTabla.AGMT_ITEM = row.GetInt("AGMT_ITEM");
                datoTabla.STORE_LOC = row.GetString("STORE_LOC");
                datoTabla.MAT_GRP = row.GetString("MAT_GRP");
                datoTabla.SHORT_TEXT = row.GetString("SHORT_TEXT");
                datoTabla.DISTRIB = row.GetString("DISTRIB");
                datoTabla.PART_INV = row.GetString("PART_INV");
                datoTabla.KANBAN_IND = row.GetString("KANBAN_IND");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.ALLOC_TBL = row.GetString("ALLOC_TBL");
                datoTabla.AT_ITEM = row.GetInt("AT_ITEM");
                datoTabla.UNIT = row.GetString("UNIT");
                datoTabla.NET_PRICE = row.GetDecimal("NET_PRICE");
                datoTabla.PRICE_UNIT = row.GetDecimal("PRICE_UNIT");
                datoTabla.CONV_NUM1 = row.GetDecimal("CONV_NUM1");
                datoTabla.CONV_DEN1 = row.GetDecimal("CONV_DEN1");
                datoTabla.ORDERPR_UN = row.GetString("ORDERPR_UN");
                datoTabla.PCKG_NO = row.GetInt("PCKG_NO");
                datoTabla.PROMOTION = row.GetString("PROMOTION");
                datoTabla.ACKN_REQD = row.GetString("ACKN_REQD");
                datoTabla.TRACKINGNO = row.GetString("TRACKINGNO");
                datoTabla.PLAN_DEL = row.GetDecimal("PLAN_DEL");
                datoTabla.RET_ITEM = row.GetString("RET_ITEM");
                datoTabla.AT_RELEV = row.GetString("AT_RELEV");
                datoTabla.VEND_MAT = row.GetString("VEND_MAT");
                datoTabla.MANUF_PROF = row.GetString("MANUF_PROF");
                datoTabla.MANU_MAT = row.GetString("MANU_MAT");
                datoTabla.MFR_NO = row.GetString("MFR_NO");
                datoTabla.MFR_NO_EXT = row.GetString("MFR_NO_EXT");
                datoTabla.PO_PRICE = row.GetString("PO_PRICE");
                datoTabla.SHIPPING = row.GetString("SHIPPING");
                datoTabla.ITEM_CAT_EXT = row.GetString("ITEM_CAT_EXT");
                datoTabla.PO_UNIT_ISO = row.GetString("PO_UNIT_ISO");
                datoTabla.ORDERPR_UN_ISO = row.GetString("ORDERPR_UN_ISO");
                datoTabla.PREQ_NAME = row.GetString("PREQ_NAME");
                datoTabla.DISP_QUAN = row.GetDecimal("DISP_QUAN");
                datoTabla.QUAL_INSP = row.GetString("QUAL_INSP");
                datoTabla.NO_MORE_GR = row.GetString("NO_MORE_GR");
                datoTabla.DELETE_IND = row.GetString("DELETE_IND");
                datoTabla.NO_ROUNDING = row.GetString("NO_ROUNDING");
                datoTabla.TAX_CODE = row.GetString("TAX_CODE");
                datoTabla.MATERIAL_EXTERNAL = row.GetString("MATERIAL_EXTERNAL");
                datoTabla.MATERIAL_GUID = row.GetString("MATERIAL_GUID");
                datoTabla.MATERIAL_VERSION = row.GetString("MATERIAL_VERSION");
                datoTabla.PUR_MAT_EXTERNAL = row.GetString("PUR_MAT_EXTERNAL");
                datoTabla.PUR_MAT_GUID = row.GetString("PUR_MAT_GUID");
                datoTabla.PUR_MAT_VERSION = row.GetString("PUR_MAT_VERSION");
                datoTabla.VAL_TYPE = row.GetString("VAL_TYPE");
                datoTabla.PR_CLOSED = row.GetString("PR_CLOSED");
                datoTabla.ACKNOWL_NO = row.GetString("ACKNOWL_NO");
                datoTabla.REQ_SEGMENT = row.GetString("REQ_SEGMENT");
                datoTabla.STK_SEGMENT = row.GetString("STK_SEGMENT");
                datoTabla.ZZOPCION = row.GetString("ZZOPCION");
                datoTabla.ZZCALIBRE = row.GetString("ZZCALIBRE");
                datoTabla.ZZCATEGORIA = row.GetString("ZZCATEGORIA");
                res.PO_ITEMS[i_PO_ITEMS] = datoTabla; ++i_PO_ITEMS;
            }
            IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
            res.RETURN = new ZMOV_10006_RETURN[rfcTable_RETURN.RowCount];
            int i_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_RETURN)
            {
                ZMOV_10006_RETURN datoTabla = new ZMOV_10006_RETURN();
                datoTabla.TYPE = row.GetString("TYPE");
                datoTabla.CODE = row.GetString("CODE");
                datoTabla.MESSAGE = row.GetString("MESSAGE");
                datoTabla.LOG_NO = row.GetString("LOG_NO");
                datoTabla.LOG_MSG_NO = row.GetInt("LOG_MSG_NO");
                datoTabla.MESSAGE_V1 = row.GetString("MESSAGE_V1");
                datoTabla.MESSAGE_V2 = row.GetString("MESSAGE_V2");
                datoTabla.MESSAGE_V3 = row.GetString("MESSAGE_V3");
                datoTabla.MESSAGE_V4 = row.GetString("MESSAGE_V4");
                res.RETURN[i_RETURN] = datoTabla; ++i_RETURN;
            }

            return res;
        }
    }
    public class request_ZMOV_10006
    {
        public String ACCTASSCAT;
        public String CREATED_BY;
        public String DELETED_ITEMS;
        public String DOC_DATE;
        public String DOC_TYPE;
        public String ITEMS_OPEN_FOR_RECEIPT;
        public String ITEM_CAT;
        public String MATERIAL;
        public ZMOV_10006_MATERIAL_EVG MATERIAL_EVG;
        public String MAT_GRP;
        public String NO_MORE_GR;
        public String PLANT;
        public String PREQ_NAME;
        public String PURCHASEORDER;
        public String PURCH_ORG;
        public String PUR_GROUP;
        public String PUR_MAT;
        public ZMOV_10006_PUR_MAT_EVG PUR_MAT_EVG;
        public String SHORT_TEXT;
        public String SUPPL_PLANT;
        public String TRACKINGNO;
        public String VENDOR;
        public String WITH_PO_HEADERS;
    }
    public class responce_ZMOV_10006
    {
        public ZMOV_10006_PO_CONSUMO[] PO_CONSUMO;
        public ZMOV_10006_PO_HEADERS[] PO_HEADERS;
        public ZMOV_10006_PO_ITEMS[] PO_ITEMS;
        public ZMOV_10006_RETURN[] RETURN;
    }
    public class ZMOV_10006_MATERIAL_EVG
    {
        public String MATERIAL_EXT;
        public String MATERIAL_VERS;
        public String MATERIAL_GUID;
    }
    public class ZMOV_10006_PUR_MAT_EVG
    {
        public String MATERIAL_EXT;
        public String MATERIAL_VERS;
        public String MATERIAL_GUID;
    }
    public class ZMOV_10006_PO_CONSUMO
    {
        public String EBELN;
        public Int32 EBELP;
        public String MATNR;
        public Decimal MENGE;
    }
    public class ZMOV_10006_PO_HEADERS
    {
        public String PO_NUMBER;
        public String CO_CODE;
        public String DOC_CAT;
        public String DOC_TYPE;
        public String CNTRL_IND;
        public String DELETE_IND;
        public String STATUS;
        public String CREATED_ON;
        public String CREATED_BY;
        public Int32 ITEM_INTVL;
        public Int32 LAST_ITEM;
        public String VENDOR;
        public String LANGUAGE;
        public String PMNTTRMS;
        public Decimal DSCNT1_TO;
        public Decimal DSCNT2_TO;
        public Decimal DSCNT3_TO;
        public Decimal CASH_DISC1;
        public Decimal CASH_DISC2;
        public String PURCH_ORG;
        public String PUR_GROUP;
        public String CURRENCY;
        public Decimal EXCH_RATE;
        public String EX_RATE_FX;
        public String DOC_DATE;
        public String VPER_START;
        public String VPER_END;
        public String APPLIC_BY;
        public String QUOT_DEAD;
        public String BINDG_PER;
        public String WARRANTY;
        public String BIDINV_NO;
        public String QUOTATION;
        public String QUOT_DATE;
        public String REF_1;
        public String SALES_PERS;
        public String TELEPHONE;
        public String SUPPL_VEND;
        public String CUSTOMER;
        public String AGREEMENT;
        public String REJ_REASON;
        public String COMPL_DLV;
        public String GR_MESSAGE;
        public String SUPPL_PLNT;
        public String RCVG_VEND;
        public String INCOTERMS1;
        public String INCOTERMS2;
        public Decimal TARGET_VAL;
        public String COLL_NO;
        public String DOC_COND;
        public String PROCEDURE;
        public String UPDATE_GRP;
        public String DIFF_INV;
        public String EXPORT_NO;
        public String OUR_REF;
        public String LOGSYSTEM;
        public Int32 SUBITEMINT;
        public String MAST_COND;
        public String REL_GROUP;
        public String REL_STRAT;
        public String REL_IND;
        public String REL_STATUS;
        public String SUBJ_TO_R;
        public String TAXR_CNTRY;
        public String SCHED_IND;
        public String VEND_NAME;
        public String CURRENCY_ISO;
        public Decimal EXCH_RATE_CM;
        public String HOLD;
        public String ZZTIPPED;
        public String ZZDES_TIPPED;
        public Int16 ZZCUOTAS;
        public Decimal ZZVALCUO;
    }
    public class ZMOV_10006_PO_ITEMS
    {
        public String PO_NUMBER;
        public Int32 PO_ITEM;
        public String ADDRESS;
        public String MATERIAL;
        public String PUR_MAT;
        public String INFO_REC;
        public String ITEM_CAT;
        public String ACCTASSCAT;
        public String AGREEMENT;
        public Int32 AGMT_ITEM;
        public String STORE_LOC;
        public String MAT_GRP;
        public String SHORT_TEXT;
        public String DISTRIB;
        public String PART_INV;
        public String KANBAN_IND;
        public String PLANT;
        public String ALLOC_TBL;
        public Int32 AT_ITEM;
        public String UNIT;
        public Decimal NET_PRICE;
        public Decimal PRICE_UNIT;
        public Decimal CONV_NUM1;
        public Decimal CONV_DEN1;
        public String ORDERPR_UN;
        public Int32 PCKG_NO;
        public String PROMOTION;
        public String ACKN_REQD;
        public String TRACKINGNO;
        public Decimal PLAN_DEL;
        public String RET_ITEM;
        public String AT_RELEV;
        public String VEND_MAT;
        public String MANUF_PROF;
        public String MANU_MAT;
        public String MFR_NO;
        public String MFR_NO_EXT;
        public String PO_PRICE;
        public String SHIPPING;
        public String ITEM_CAT_EXT;
        public String PO_UNIT_ISO;
        public String ORDERPR_UN_ISO;
        public String PREQ_NAME;
        public Decimal DISP_QUAN;
        public String QUAL_INSP;
        public String NO_MORE_GR;
        public String DELETE_IND;
        public String NO_ROUNDING;
        public String TAX_CODE;
        public String MATERIAL_EXTERNAL;
        public String MATERIAL_GUID;
        public String MATERIAL_VERSION;
        public String PUR_MAT_EXTERNAL;
        public String PUR_MAT_GUID;
        public String PUR_MAT_VERSION;
        public String VAL_TYPE;
        public String PR_CLOSED;
        public String ACKNOWL_NO;
        public String REQ_SEGMENT;
        public String STK_SEGMENT;
        public String ZZOPCION;
        public String ZZCALIBRE;
        public String ZZCATEGORIA;
    }
    public class ZMOV_10006_RETURN
    {
        public String TYPE;
        public String CODE;
        public String MESSAGE;
        public String LOG_NO;
        public Int32 LOG_MSG_NO;
        public String MESSAGE_V1;
        public String MESSAGE_V2;
        public String MESSAGE_V3;
        public String MESSAGE_V4;
    }

}