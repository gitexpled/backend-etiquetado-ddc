using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class BAPI_INFORECORD_GETLIST
    {
        public responce_BAPI_INFORECORD_GETLIST sapRun(request_BAPI_INFORECORD_GETLIST import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("BAPI_INFORECORD_GETLIST");

            rfcFunction.SetValue("DELETED_INFORECORDS", import.DELETED_INFORECORDS);
            rfcFunction.SetValue("GENERAL_DATA", import.GENERAL_DATA);
            rfcFunction.SetValue("INFO_TYPE", import.INFO_TYPE);
            rfcFunction.SetValue("MATERIAL", import.MATERIAL);
            RfcStructureMetadata obj_BAPIMGVMATNR = SapRfcRepository.GetStructureMetadata("BAPIMGVMATNR");
            IRfcStructure datos_BAPIMGVMATNR = obj_BAPIMGVMATNR.CreateStructure();
            //datos_BAPIMGVMATNR.SetValue("MATERIAL_EXT", import.MATERIAL_EVG.MATERIAL_EXT);
            //datos_BAPIMGVMATNR.SetValue("MATERIAL_VERS", import.MATERIAL_EVG.MATERIAL_VERS);
            //datos_BAPIMGVMATNR.SetValue("MATERIAL_GUID", import.MATERIAL_EVG.MATERIAL_GUID);
            rfcFunction.SetValue("MATERIAL_EVG", datos_BAPIMGVMATNR);
            rfcFunction.SetValue("MAT_GRP", import.MAT_GRP);
            rfcFunction.SetValue("PLANT", import.PLANT);
            rfcFunction.SetValue("PURCHASINGINFOREC", import.PURCHASINGINFOREC);
            rfcFunction.SetValue("PURCHORG_DATA", import.PURCHORG_DATA);
            rfcFunction.SetValue("PURCHORG_VEND", import.PURCHORG_VEND);
            rfcFunction.SetValue("PURCH_ORG", import.PURCH_ORG);
            rfcFunction.SetValue("PUR_GROUP", import.PUR_GROUP);
            rfcFunction.SetValue("VENDOR", import.VENDOR);
            rfcFunction.SetValue("VEND_MAT", import.VEND_MAT);
            rfcFunction.SetValue("VEND_MATG", import.VEND_MATG);
            rfcFunction.SetValue("VEND_PART", import.VEND_PART);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_BAPI_INFORECORD_GETLIST res = new responce_BAPI_INFORECORD_GETLIST();
            IRfcTable rfcTable_INFORECORD_GENERAL = rfcFunction.GetTable("INFORECORD_GENERAL");
            res.INFORECORD_GENERAL = new BAPI_INFORECORD_GETLIST_INFORECORD_GENERAL[rfcTable_INFORECORD_GENERAL.RowCount];
            int i_INFORECORD_GENERAL = 0;
            foreach (IRfcStructure row in rfcTable_INFORECORD_GENERAL)
            {
                BAPI_INFORECORD_GETLIST_INFORECORD_GENERAL datoTabla = new BAPI_INFORECORD_GETLIST_INFORECORD_GENERAL();
                datoTabla.INFO_REC = row.GetString("INFO_REC");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.MAT_GRP = row.GetString("MAT_GRP");
                datoTabla.VENDOR = row.GetString("VENDOR");
                datoTabla.DELETE_IND = row.GetString("DELETE_IND");
                datoTabla.CREATED_AT = row.GetString("CREATED_AT");
                datoTabla.CREATED_BY = row.GetString("CREATED_BY");
                datoTabla.SHORT_TEXT = row.GetString("SHORT_TEXT");
                datoTabla.SORTED_BY = row.GetString("SORTED_BY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.CONV_NUM1 = row.GetDecimal("CONV_NUM1");
                datoTabla.CONV_DEN1 = row.GetDecimal("CONV_DEN1");
                datoTabla.VEND_MAT = row.GetString("VEND_MAT");
                datoTabla.SALES_PERS = row.GetString("SALES_PERS");
                datoTabla.TELEPHONE = row.GetString("TELEPHONE");
                datoTabla.REMINDER1 = row.GetDecimal("REMINDER1");
                datoTabla.REMINDER2 = row.GetDecimal("REMINDER2");
                datoTabla.REMINDER3 = row.GetDecimal("REMINDER3");
                datoTabla.CERT_NO = row.GetString("CERT_NO");
                datoTabla.CERT_VALID = row.GetString("CERT_VALID");
                datoTabla.CERT_CTRY = row.GetString("CERT_CTRY");
                datoTabla.CERT_TYPE = row.GetString("CERT_TYPE");
                datoTabla.CUST_NO = row.GetString("CUST_NO");
                datoTabla.BASE_UOM = row.GetString("BASE_UOM");
                datoTabla.REGION = row.GetString("REGION");
                datoTabla.VAR_ORD_UN = row.GetString("VAR_ORD_UN");
                datoTabla.VEND_PART = row.GetString("VEND_PART");
                datoTabla.SORT_NO = row.GetInt("SORT_NO");
                datoTabla.VEND_MATG = row.GetString("VEND_MATG");
                datoTabla.BACK_AGREE = row.GetString("BACK_AGREE");
                datoTabla.SUPPL_FROM = row.GetString("SUPPL_FROM");
                datoTabla.SUPPL_TO = row.GetString("SUPPL_TO");
                datoTabla.PRE_VENDOR = row.GetString("PRE_VENDOR");
                datoTabla.POINTS = row.GetDecimal("POINTS");
                datoTabla.POINT_UNIT = row.GetString("POINT_UNIT");
                datoTabla.NORM_VEND = row.GetString("NORM_VEND");
                datoTabla.PO_UNIT_ISO = row.GetString("PO_UNIT_ISO");
                datoTabla.BASE_UOM_ISO = row.GetString("BASE_UOM_ISO");
                datoTabla.MATERIAL_EXTERNAL = row.GetString("MATERIAL_EXTERNAL");
                datoTabla.MATERIAL_GUID = row.GetString("MATERIAL_GUID");
                datoTabla.MATERIAL_VERSION = row.GetString("MATERIAL_VERSION");
                res.INFORECORD_GENERAL[i_INFORECORD_GENERAL] = datoTabla; ++i_INFORECORD_GENERAL;
            }
            IRfcTable rfcTable_INFORECORD_PURCHORG = rfcFunction.GetTable("INFORECORD_PURCHORG");
            res.INFORECORD_PURCHORG = new BAPI_INFORECORD_GETLIST_INFORECORD_PURCHORG[rfcTable_INFORECORD_PURCHORG.RowCount];
            int i_INFORECORD_PURCHORG = 0;
            foreach (IRfcStructure row in rfcTable_INFORECORD_PURCHORG)
            {
                BAPI_INFORECORD_GETLIST_INFORECORD_PURCHORG datoTabla = new BAPI_INFORECORD_GETLIST_INFORECORD_PURCHORG();
                datoTabla.INFO_REC = row.GetString("INFO_REC");
                datoTabla.PURCH_ORG = row.GetString("PURCH_ORG");
                datoTabla.INFO_TYPE = row.GetString("INFO_TYPE");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.DELETE_IND = row.GetString("DELETE_IND");
                datoTabla.CREATED_AT = row.GetString("CREATED_AT");
                datoTabla.CREATED_BY = row.GetString("CREATED_BY");
                datoTabla.PUR_GROUP = row.GetString("PUR_GROUP");
                datoTabla.CURRENCY = row.GetString("CURRENCY");
                datoTabla.BONUS = row.GetString("BONUS");
                datoTabla.BONUS_QTY = row.GetString("BONUS_QTY");
                datoTabla.MIN_PO_QTY = row.GetDecimal("MIN_PO_QTY");
                datoTabla.NRM_PO_QTY = row.GetDecimal("NRM_PO_QTY");
                datoTabla.PLND_DELRY = row.GetDecimal("PLND_DELRY");
                datoTabla.OVERDELTOL = row.GetDecimal("OVERDELTOL");
                datoTabla.UNLIMITED = row.GetString("UNLIMITED");
                datoTabla.UNDER_TOL = row.GetDecimal("UNDER_TOL");
                datoTabla.QUOTATION = row.GetString("QUOTATION");
                datoTabla.QUOT_DATE = row.GetString("QUOT_DATE");
                datoTabla.RFQ_NO = row.GetString("RFQ_NO");
                datoTabla.RFQ_ITEM = row.GetInt("RFQ_ITEM");
                datoTabla.RFQ_CANC = row.GetString("RFQ_CANC");
                datoTabla.AMORT_FROM = row.GetString("AMORT_FROM");
                datoTabla.AMORT_TO = row.GetString("AMORT_TO");
                datoTabla.AMORT_QTY = row.GetDecimal("AMORT_QTY");
                datoTabla.AMORT_VAL = row.GetDecimal("AMORT_VAL");
                datoTabla.AMORT_TQTY = row.GetDecimal("AMORT_TQTY");
                datoTabla.AMORT_TVAL = row.GetDecimal("AMORT_TVAL");
                datoTabla.AMORT_RES = row.GetString("AMORT_RES");
                datoTabla.DOC_CAT = row.GetString("DOC_CAT");
                datoTabla.PO_NUMBER = row.GetString("PO_NUMBER");
                datoTabla.PO_ITEM = row.GetInt("PO_ITEM");
                datoTabla.LAST_PO = row.GetString("LAST_PO");
                datoTabla.NET_PRICE = row.GetDecimal("NET_PRICE");
                datoTabla.PRICE_UNIT = row.GetDecimal("PRICE_UNIT");
                datoTabla.ORDERPR_UN = row.GetString("ORDERPR_UN");
                datoTabla.PRICE_DATE = row.GetString("PRICE_DATE");
                datoTabla.CONV_NUM1 = row.GetDecimal("CONV_NUM1");
                datoTabla.CONV_DEN1 = row.GetDecimal("CONV_DEN1");
                datoTabla.NO_MATTEXT = row.GetString("NO_MATTEXT");
                datoTabla.GR_BASEDIV = row.GetString("GR_BASEDIV");
                datoTabla.EFF_PRICE = row.GetDecimal("EFF_PRICE");
                datoTabla.COND_GROUP = row.GetString("COND_GROUP");
                datoTabla.NO_DISCT = row.GetString("NO_DISCT");
                datoTabla.ACKN_REQD = row.GetString("ACKN_REQD");
                datoTabla.TAX_CODE = row.GetString("TAX_CODE");
                datoTabla.VAL_TYPE = row.GetString("VAL_TYPE");
                datoTabla.BON_GRP1 = row.GetString("BON_GRP1");
                datoTabla.SHIPPING = row.GetString("SHIPPING");
                datoTabla.EXP_IMP_P = row.GetString("EXP_IMP_P");
                datoTabla.CONF_CTRL = row.GetString("CONF_CTRL");
                datoTabla.PRICEDATE = row.GetString("PRICEDATE");
                datoTabla.INCOTERMS1 = row.GetString("INCOTERMS1");
                datoTabla.INCOTERMS2 = row.GetString("INCOTERMS2");
                datoTabla.NO_AUT_GR = row.GetString("NO_AUT_GR");
                datoTabla.BON_GRP2 = row.GetString("BON_GRP2");
                datoTabla.BON_GRP3 = row.GetString("BON_GRP3");
                datoTabla.NO_BON_ITM = row.GetString("NO_BON_ITM");
                datoTabla.MINREMLIFE = row.GetDecimal("MINREMLIFE");
                datoTabla.VERSION = row.GetString("VERSION");
                datoTabla.MAX_PO_QTY = row.GetDecimal("MAX_PO_QTY");
                datoTabla.ROUND_PROF = row.GetString("ROUND_PROF");
                datoTabla.UNIT_GROUP = row.GetString("UNIT_GROUP");
                datoTabla.BRAS_NBM = row.GetString("BRAS_NBM");
                datoTabla.CURRENCY_ISO = row.GetString("CURRENCY_ISO");
                datoTabla.ORDERPR_UN_ISO = row.GetString("ORDERPR_UN_ISO");
                datoTabla.VENDOR = row.GetString("VENDOR");
                datoTabla.INCOTERMSV = row.GetString("INCOTERMSV");
                datoTabla.INCOTERMS2L = row.GetString("INCOTERMS2L");
                datoTabla.INCOTERMS3L = row.GetString("INCOTERMS3L");
                res.INFORECORD_PURCHORG[i_INFORECORD_PURCHORG] = datoTabla; ++i_INFORECORD_PURCHORG;
            }
            IRfcTable rfcTable_INFORECORD_SEGMENT = rfcFunction.GetTable("INFORECORD_SEGMENT");
            res.INFORECORD_SEGMENT = new BAPI_INFORECORD_GETLIST_INFORECORD_SEGMENT[rfcTable_INFORECORD_SEGMENT.RowCount];
            int i_INFORECORD_SEGMENT = 0;
            foreach (IRfcStructure row in rfcTable_INFORECORD_SEGMENT)
            {
                BAPI_INFORECORD_GETLIST_INFORECORD_SEGMENT datoTabla = new BAPI_INFORECORD_GETLIST_INFORECORD_SEGMENT();
                datoTabla.INFO_REC = row.GetString("INFO_REC");
                datoTabla.PURCH_ORG = row.GetString("PURCH_ORG");
                datoTabla.ESOKZ = row.GetString("ESOKZ");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STK_SEGMENT = row.GetString("STK_SEGMENT");
                datoTabla.ROUND_PROF = row.GetString("ROUND_PROF");
                datoTabla.UNDER_TOL = row.GetDecimal("UNDER_TOL");
                datoTabla.OVERDELTOL = row.GetDecimal("OVERDELTOL");
                datoTabla.MAX_PO_QTY = row.GetDecimal("MAX_PO_QTY");
                datoTabla.MIN_PO_QTY = row.GetDecimal("MIN_PO_QTY");
                res.INFORECORD_SEGMENT[i_INFORECORD_SEGMENT] = datoTabla; ++i_INFORECORD_SEGMENT;
            }
            IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
            res.RETURN = new BAPI_INFORECORD_GETLIST_RETURN[rfcTable_RETURN.RowCount];
            int i_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_RETURN)
            {
                BAPI_INFORECORD_GETLIST_RETURN datoTabla = new BAPI_INFORECORD_GETLIST_RETURN();
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
    public class request_BAPI_INFORECORD_GETLIST
    {
        public String DELETED_INFORECORDS;
        public String GENERAL_DATA;
        public String INFO_TYPE;
        public String MATERIAL;
        public BAPI_INFORECORD_GETLIST_MATERIAL_EVG MATERIAL_EVG;
        public String MAT_GRP;
        public String PLANT;
        public String PURCHASINGINFOREC;
        public String PURCHORG_DATA;
        public String PURCHORG_VEND;
        public String PURCH_ORG;
        public String PUR_GROUP;
        public String VENDOR;
        public String VEND_MAT;
        public String VEND_MATG;
        public String VEND_PART;
    }
    public class responce_BAPI_INFORECORD_GETLIST
    {
        public BAPI_INFORECORD_GETLIST_INFORECORD_GENERAL[] INFORECORD_GENERAL;
        public BAPI_INFORECORD_GETLIST_INFORECORD_PURCHORG[] INFORECORD_PURCHORG;
        public BAPI_INFORECORD_GETLIST_INFORECORD_SEGMENT[] INFORECORD_SEGMENT;
        public BAPI_INFORECORD_GETLIST_RETURN[] RETURN;
    }
    public class BAPI_INFORECORD_GETLIST_MATERIAL_EVG
    {
        public String MATERIAL_EXT;
        public String MATERIAL_VERS;
        public String MATERIAL_GUID;
    }
    public class BAPI_INFORECORD_GETLIST_INFORECORD_GENERAL
    {
        public String INFO_REC;
        public String MATERIAL;
        public String MAT_GRP;
        public String VENDOR;
        public String DELETE_IND;
        public String CREATED_AT;
        public String CREATED_BY;
        public String SHORT_TEXT;
        public String SORTED_BY;
        public String PO_UNIT;
        public Decimal CONV_NUM1;
        public Decimal CONV_DEN1;
        public String VEND_MAT;
        public String SALES_PERS;
        public String TELEPHONE;
        public Decimal REMINDER1;
        public Decimal REMINDER2;
        public Decimal REMINDER3;
        public String CERT_NO;
        public String CERT_VALID;
        public String CERT_CTRY;
        public String CERT_TYPE;
        public String CUST_NO;
        public String BASE_UOM;
        public String REGION;
        public String VAR_ORD_UN;
        public String VEND_PART;
        public Int32 SORT_NO;
        public String VEND_MATG;
        public String BACK_AGREE;
        public String SUPPL_FROM;
        public String SUPPL_TO;
        public String PRE_VENDOR;
        public Decimal POINTS;
        public String POINT_UNIT;
        public String NORM_VEND;
        public String PO_UNIT_ISO;
        public String BASE_UOM_ISO;
        public String MATERIAL_EXTERNAL;
        public String MATERIAL_GUID;
        public String MATERIAL_VERSION;
    }
    public class BAPI_INFORECORD_GETLIST_INFORECORD_PURCHORG
    {
        public String INFO_REC;
        public String PURCH_ORG;
        public String INFO_TYPE;
        public String PLANT;
        public String DELETE_IND;
        public String CREATED_AT;
        public String CREATED_BY;
        public String PUR_GROUP;
        public String CURRENCY;
        public String BONUS;
        public String BONUS_QTY;
        public Decimal MIN_PO_QTY;
        public Decimal NRM_PO_QTY;
        public Decimal PLND_DELRY;
        public Decimal OVERDELTOL;
        public String UNLIMITED;
        public Decimal UNDER_TOL;
        public String QUOTATION;
        public String QUOT_DATE;
        public String RFQ_NO;
        public Int32 RFQ_ITEM;
        public String RFQ_CANC;
        public String AMORT_FROM;
        public String AMORT_TO;
        public Decimal AMORT_QTY;
        public Decimal AMORT_VAL;
        public Decimal AMORT_TQTY;
        public Decimal AMORT_TVAL;
        public String AMORT_RES;
        public String DOC_CAT;
        public String PO_NUMBER;
        public Int32 PO_ITEM;
        public String LAST_PO;
        public Decimal NET_PRICE;
        public Decimal PRICE_UNIT;
        public String ORDERPR_UN;
        public String PRICE_DATE;
        public Decimal CONV_NUM1;
        public Decimal CONV_DEN1;
        public String NO_MATTEXT;
        public String GR_BASEDIV;
        public Decimal EFF_PRICE;
        public String COND_GROUP;
        public String NO_DISCT;
        public String ACKN_REQD;
        public String TAX_CODE;
        public String VAL_TYPE;
        public String BON_GRP1;
        public String SHIPPING;
        public String EXP_IMP_P;
        public String CONF_CTRL;
        public String PRICEDATE;
        public String INCOTERMS1;
        public String INCOTERMS2;
        public String NO_AUT_GR;
        public String BON_GRP2;
        public String BON_GRP3;
        public String NO_BON_ITM;
        public Decimal MINREMLIFE;
        public String VERSION;
        public Decimal MAX_PO_QTY;
        public String ROUND_PROF;
        public String UNIT_GROUP;
        public String BRAS_NBM;
        public String CURRENCY_ISO;
        public String ORDERPR_UN_ISO;
        public String VENDOR;
        public String INCOTERMSV;
        public String INCOTERMS2L;
        public String INCOTERMS3L;
    }
    public class BAPI_INFORECORD_GETLIST_INFORECORD_SEGMENT
    {
        public String INFO_REC;
        public String PURCH_ORG;
        public String ESOKZ;
        public String PLANT;
        public String STK_SEGMENT;
        public String ROUND_PROF;
        public Decimal UNDER_TOL;
        public Decimal OVERDELTOL;
        public Decimal MAX_PO_QTY;
        public Decimal MIN_PO_QTY;
    }
    public class BAPI_INFORECORD_GETLIST_RETURN
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