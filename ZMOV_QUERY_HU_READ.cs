using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_HU_READ
    {
        public responce_ZMOV_QUERY_HU_READ sapRun(request_ZMOV_QUERY_HU_READ import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_HU_READ");

            rfcFunction.SetValue("HUKEY", import.HUKEY);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_HU_READ res = new responce_ZMOV_QUERY_HU_READ();
            IRfcTable rfcTable_HUHEADER = rfcFunction.GetTable("HUHEADER");
            res.HUHEADER = new ZMOV_QUERY_HU_READ_HUHEADER[rfcTable_HUHEADER.RowCount];
            int i_HUHEADER = 0;
            foreach (IRfcStructure row in rfcTable_HUHEADER)
            {
                ZMOV_QUERY_HU_READ_HUHEADER datoTabla = new ZMOV_QUERY_HU_READ_HUHEADER();
                datoTabla.CLIENT = row.GetString("CLIENT");
                datoTabla.HU_ID = row.GetString("HU_ID");
                datoTabla.HU_EXID = row.GetString("HU_EXID");
                datoTabla.HU_EXID_TYPE = row.GetString("HU_EXID_TYPE");
                datoTabla.SHIP_POINT = row.GetString("SHIP_POINT");
                datoTabla.LOADING_POINT = row.GetString("LOADING_POINT");
                datoTabla.TOTAL_WGHT = row.GetDecimal("TOTAL_WGHT");
                datoTabla.LOAD_WGHT = row.GetDecimal("LOAD_WGHT");
                datoTabla.TARE_WGHT = row.GetDecimal("TARE_WGHT");
                datoTabla.UNIT_OF_WT_ISO = row.GetString("UNIT_OF_WT_ISO");
                datoTabla.UNIT_OF_WT = row.GetString("UNIT_OF_WT");
                datoTabla.ALLOWED_WGHT = row.GetDecimal("ALLOWED_WGHT");
                datoTabla.MAX_UNIT_OF_WGHT_ISO = row.GetString("MAX_UNIT_OF_WGHT_ISO");
                datoTabla.MAX_UNIT_OF_WGHT = row.GetString("MAX_UNIT_OF_WGHT");
                datoTabla.TOTAL_VOL = row.GetDecimal("TOTAL_VOL");
                datoTabla.LOAD_VOL = row.GetDecimal("LOAD_VOL");
                datoTabla.TARE_VOL = row.GetDecimal("TARE_VOL");
                datoTabla.VOLUMEUNIT_ISO = row.GetString("VOLUMEUNIT_ISO");
                datoTabla.VOLUMEUNIT = row.GetString("VOLUMEUNIT");
                datoTabla.ALLOWED_VOL = row.GetDecimal("ALLOWED_VOL");
                datoTabla.MAX_VOL_UNIT_ISO = row.GetString("MAX_VOL_UNIT_ISO");
                datoTabla.MAX_VOL_UNIT = row.GetString("MAX_VOL_UNIT");
                datoTabla.NO_SIMILAR_PACK_MAT = row.GetInt("NO_SIMILAR_PACK_MAT");
                datoTabla.CREATED_BY = row.GetString("CREATED_BY");
                datoTabla.CREATED_DATE = row.GetString("CREATED_DATE");
                datoTabla.CREATED_TIME = row.GetString("CREATED_TIME");
                datoTabla.CHANGED_BY = row.GetString("CHANGED_BY");
                datoTabla.CHANGED_DATE = row.GetString("CHANGED_DATE");
                datoTabla.CHANGED_TIME = row.GetString("CHANGED_TIME");
                datoTabla.SORT_FLD = row.GetString("SORT_FLD");
                datoTabla.HU_GRP1 = row.GetString("HU_GRP1");
                datoTabla.HU_GRP2 = row.GetString("HU_GRP2");
                datoTabla.HU_GRP3 = row.GetString("HU_GRP3");
                datoTabla.HU_GRP4 = row.GetString("HU_GRP4");
                datoTabla.HU_GRP5 = row.GetString("HU_GRP5");
                datoTabla.PACK_MAT = row.GetString("PACK_MAT");
                datoTabla.LENGHT = row.GetDecimal("LENGHT");
                datoTabla.WIDTH = row.GetDecimal("WIDTH");
                datoTabla.HEIGHT = row.GetDecimal("HEIGHT");
                datoTabla.UNIT_DIM_ISO = row.GetString("UNIT_DIM_ISO");
                datoTabla.UNIT_DIM = row.GetString("UNIT_DIM");
                datoTabla.STATUS_OBSOLET = row.GetString("STATUS_OBSOLET");
                datoTabla.WGHT_TOL_HU = row.GetDecimal("WGHT_TOL_HU");
                datoTabla.VOL_TOL_HU = row.GetDecimal("VOL_TOL_HU");
                datoTabla.BASE_UOM_ISO = row.GetString("BASE_UOM_ISO");
                datoTabla.BASE_UOM = row.GetString("BASE_UOM");
                datoTabla.CONTENT = row.GetString("CONTENT");
                datoTabla.PACK_MAT_TYPE = row.GetString("PACK_MAT_TYPE");
                datoTabla.MAT_GRP_SM = row.GetString("MAT_GRP_SM");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.ITEM_CATEG = row.GetString("ITEM_CATEG");
                datoTabla.SALESORG = row.GetString("SALESORG");
                datoTabla.DC_CUSTOM_MAT = row.GetString("DC_CUSTOM_MAT");
                datoTabla.LGTH_LOAD = row.GetDecimal("LGTH_LOAD");
                datoTabla.LGTH_LOAD_UNIT_ISO = row.GetString("LGTH_LOAD_UNIT_ISO");
                datoTabla.LGTH_LOAD_UNIT = row.GetString("LGTH_LOAD_UNIT");
                datoTabla.TRAVEL_TIME = row.GetDecimal("TRAVEL_TIME");
                datoTabla.TRAVEL_TIME_UNIT_ISO = row.GetString("TRAVEL_TIME_UNIT_ISO");
                datoTabla.TRAVEL_TIME_UNIT = row.GetString("TRAVEL_TIME_UNIT");
                datoTabla.DISTANCE = row.GetDecimal("DISTANCE");
                datoTabla.UNIT_OF_DIST_ISO = row.GetString("UNIT_OF_DIST_ISO");
                datoTabla.UNIT_OF_DIST = row.GetString("UNIT_OF_DIST");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.WGHT_VOL_FIX = row.GetString("WGHT_VOL_FIX");
                datoTabla.PACK_MAT_CAT = row.GetString("PACK_MAT_CAT");
                datoTabla.EXT_ID_HU_2 = row.GetString("EXT_ID_HU_2");
                datoTabla.CNTRY_SHP_MAT_ISO = row.GetString("CNTRY_SHP_MAT_ISO");
                datoTabla.CNTRY_SHP_MAT = row.GetString("CNTRY_SHP_MAT");
                datoTabla.NATIONALITY_DRIVER_ISO = row.GetString("NATIONALITY_DRIVER_ISO");
                datoTabla.NATIONALITY_DRIVER = row.GetString("NATIONALITY_DRIVER");
                datoTabla.NAME_DRIVER = row.GetString("NAME_DRIVER");
                datoTabla.NAME_CO_DRIVER = row.GetString("NAME_CO_DRIVER");
                datoTabla.PACK_MAT_CUSTOMER = row.GetString("PACK_MAT_CUSTOMER");
                datoTabla.PACK_MAT_OBJECT = row.GetString("PACK_MAT_OBJECT");
                datoTabla.PACK_MAT_OBJ_KEY = row.GetString("PACK_MAT_OBJ_KEY");
                datoTabla.HANDLE = row.GetString("HANDLE");
                datoTabla.CONTAINER_STAT = row.GetString("CONTAINER_STAT");
                datoTabla.WAREHOUSE_NUMBER = row.GetString("WAREHOUSE_NUMBER");
                datoTabla.CLOSED_BOX = row.GetString("CLOSED_BOX");
                datoTabla.FLAG_PACKG_LV_DANG_GOODS = row.GetString("FLAG_PACKG_LV_DANG_GOODS");
                datoTabla.FLAG_PACKG_LV_PRINT = row.GetString("FLAG_PACKG_LV_PRINT");
                datoTabla.HIGHER_LEVEL_HU = row.GetString("HIGHER_LEVEL_HU");
                datoTabla.PACKG_INSTRUCT = row.GetString("PACKG_INSTRUCT");
                datoTabla.L_PACKG_STATUS_HU = row.GetString("L_PACKG_STATUS_HU");
                datoTabla.FLAG_NO_EXT_LABLE = row.GetString("FLAG_NO_EXT_LABLE");
                datoTabla.PERMISS_WORKLOAD = row.GetDecimal("PERMISS_WORKLOAD");
                datoTabla.HU_STOR_LOC = row.GetString("HU_STOR_LOC");
                datoTabla.PACK_MAT_NAME = row.GetString("PACK_MAT_NAME");
                datoTabla.PACK_MAT_EXTERNAL = row.GetString("PACK_MAT_EXTERNAL");
                datoTabla.PACK_MAT_GUID = row.GetString("PACK_MAT_GUID");
                datoTabla.PACK_MAT_VERSION = row.GetString("PACK_MAT_VERSION");
                res.HUHEADER[i_HUHEADER] = datoTabla; ++i_HUHEADER;
            }
            IRfcTable rfcTable_HUITEM = rfcFunction.GetTable("HUITEM");
            res.HUITEM = new ZMOV_QUERY_HU_READ_HUITEM[rfcTable_HUITEM.RowCount];
            int i_HUITEM = 0;
            foreach (IRfcStructure row in rfcTable_HUITEM)
            {
                ZMOV_QUERY_HU_READ_HUITEM datoTabla = new ZMOV_QUERY_HU_READ_HUITEM();
                datoTabla.CLIENT = row.GetString("CLIENT");
                datoTabla.HU_ITEM_NUMBER = row.GetInt("HU_ITEM_NUMBER");
                datoTabla.HU_ITEM_TYPE = row.GetString("HU_ITEM_TYPE");
                datoTabla.OBJECT_DOC = row.GetString("OBJECT_DOC");
                datoTabla.OBJ_ITEM_NUMBER = row.GetInt("OBJ_ITEM_NUMBER");
                datoTabla.PACK_QTY = row.GetDecimal("PACK_QTY");
                datoTabla.PACK_QTY_FLOAT = row.GetDouble("PACK_QTY_FLOAT");
                datoTabla.BASE_UNIT_QTY_ISO = row.GetString("BASE_UNIT_QTY_ISO");
                datoTabla.BASE_UNIT_QTY = row.GetString("BASE_UNIT_QTY");
                datoTabla.ALT_UNIT_QTY_ISO = row.GetString("ALT_UNIT_QTY_ISO");
                datoTabla.LOWER_LEVEL_EXID = row.GetString("LOWER_LEVEL_EXID");
                datoTabla.ALT_UNIT_QTY = row.GetString("ALT_UNIT_QTY");
                datoTabla.NUMBER_PACK_MAT = row.GetInt("NUMBER_PACK_MAT");
                datoTabla.FLAG_SUPLMT_ITEM = row.GetString("FLAG_SUPLMT_ITEM");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.INT_OBJ_NO = row.GetInt("INT_OBJ_NO");
                datoTabla.STOCK_CAT = row.GetString("STOCK_CAT");
                datoTabla.SPEC_STOCK = row.GetString("SPEC_STOCK");
                datoTabla.SP_STCK_NO = row.GetString("SP_STCK_NO");
                datoTabla.INSPLOT = row.GetInt("INSPLOT");
                datoTabla.NO_OF_SERIAL_NUMBERS = row.GetInt("NO_OF_SERIAL_NUMBERS");
                datoTabla.SERNO_PROF = row.GetString("SERNO_PROF");
                datoTabla.ITEM_CATEG = row.GetString("ITEM_CATEG");
                datoTabla.MATERIAL_PARTNER = row.GetString("MATERIAL_PARTNER");
                datoTabla.PACK_MAT_TYPE = row.GetString("PACK_MAT_TYPE");
                datoTabla.PACK_MAT_NAME = row.GetString("PACK_MAT_NAME");
                datoTabla.EXPIRYDATE = row.GetString("EXPIRYDATE");
                datoTabla.GR_DATE = row.GetString("GR_DATE");
                datoTabla.HU_EXID = row.GetString("HU_EXID");
                datoTabla.MATERIAL_EXTERNAL = row.GetString("MATERIAL_EXTERNAL");
                datoTabla.MATERIAL_GUID = row.GetString("MATERIAL_GUID");
                datoTabla.MATERIAL_VERSION = row.GetString("MATERIAL_VERSION");
                datoTabla.STOCK_SEGMENT = row.GetString("STOCK_SEGMENT");
                res.HUITEM[i_HUITEM] = datoTabla; ++i_HUITEM;
            }
            IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
            res.RETURN = new ZMOV_QUERY_HU_READ_RETURN[rfcTable_RETURN.RowCount];
            int i_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_RETURN)
            {
                ZMOV_QUERY_HU_READ_RETURN datoTabla = new ZMOV_QUERY_HU_READ_RETURN();
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
    public class request_ZMOV_QUERY_HU_READ
    {
        public String HUKEY;
    }
    public class responce_ZMOV_QUERY_HU_READ
    {
        public ZMOV_QUERY_HU_READ_HUHEADER[] HUHEADER;
        public ZMOV_QUERY_HU_READ_HUITEM[] HUITEM;
        public ZMOV_QUERY_HU_READ_RETURN[] RETURN;
    }
    public class ZMOV_QUERY_HU_READ_HUHEADER
    {
        public String CLIENT;
        public String HU_ID;
        public String HU_EXID;
        public String HU_EXID_TYPE;
        public String SHIP_POINT;
        public String LOADING_POINT;
        public Decimal TOTAL_WGHT;
        public Decimal LOAD_WGHT;
        public Decimal TARE_WGHT;
        public String UNIT_OF_WT_ISO;
        public String UNIT_OF_WT;
        public Decimal ALLOWED_WGHT;
        public String MAX_UNIT_OF_WGHT_ISO;
        public String MAX_UNIT_OF_WGHT;
        public Decimal TOTAL_VOL;
        public Decimal LOAD_VOL;
        public Decimal TARE_VOL;
        public String VOLUMEUNIT_ISO;
        public String VOLUMEUNIT;
        public Decimal ALLOWED_VOL;
        public String MAX_VOL_UNIT_ISO;
        public String MAX_VOL_UNIT;
        public Int32 NO_SIMILAR_PACK_MAT;
        public String CREATED_BY;
        public String CREATED_DATE;
        public String CREATED_TIME;
        public String CHANGED_BY;
        public String CHANGED_DATE;
        public String CHANGED_TIME;
        public String SORT_FLD;
        public String HU_GRP1;
        public String HU_GRP2;
        public String HU_GRP3;
        public String HU_GRP4;
        public String HU_GRP5;
        public String PACK_MAT;
        public Decimal LENGHT;
        public Decimal WIDTH;
        public Decimal HEIGHT;
        public String UNIT_DIM_ISO;
        public String UNIT_DIM;
        public String STATUS_OBSOLET;
        public Decimal WGHT_TOL_HU;
        public Decimal VOL_TOL_HU;
        public String BASE_UOM_ISO;
        public String BASE_UOM;
        public String CONTENT;
        public String PACK_MAT_TYPE;
        public String MAT_GRP_SM;
        public String PLANT;
        public String ITEM_CATEG;
        public String SALESORG;
        public String DC_CUSTOM_MAT;
        public Decimal LGTH_LOAD;
        public String LGTH_LOAD_UNIT_ISO;
        public String LGTH_LOAD_UNIT;
        public Decimal TRAVEL_TIME;
        public String TRAVEL_TIME_UNIT_ISO;
        public String TRAVEL_TIME_UNIT;
        public Decimal DISTANCE;
        public String UNIT_OF_DIST_ISO;
        public String UNIT_OF_DIST;
        public String STGE_LOC;
        public String WGHT_VOL_FIX;
        public String PACK_MAT_CAT;
        public String EXT_ID_HU_2;
        public String CNTRY_SHP_MAT_ISO;
        public String CNTRY_SHP_MAT;
        public String NATIONALITY_DRIVER_ISO;
        public String NATIONALITY_DRIVER;
        public String NAME_DRIVER;
        public String NAME_CO_DRIVER;
        public String PACK_MAT_CUSTOMER;
        public String PACK_MAT_OBJECT;
        public String PACK_MAT_OBJ_KEY;
        public String HANDLE;
        public String CONTAINER_STAT;
        public String WAREHOUSE_NUMBER;
        public String CLOSED_BOX;
        public String FLAG_PACKG_LV_DANG_GOODS;
        public String FLAG_PACKG_LV_PRINT;
        public String HIGHER_LEVEL_HU;
        public String PACKG_INSTRUCT;
        public String L_PACKG_STATUS_HU;
        public String FLAG_NO_EXT_LABLE;
        public Decimal PERMISS_WORKLOAD;
        public String HU_STOR_LOC;
        public String PACK_MAT_NAME;
        public String PACK_MAT_EXTERNAL;
        public String PACK_MAT_GUID;
        public String PACK_MAT_VERSION;
    }
    public class ZMOV_QUERY_HU_READ_HUITEM
    {
        public String CLIENT;
        public Int32 HU_ITEM_NUMBER;
        public String HU_ITEM_TYPE;
        public String OBJECT_DOC;
        public Int32 OBJ_ITEM_NUMBER;
        public Decimal PACK_QTY;
        public Double PACK_QTY_FLOAT;
        public String BASE_UNIT_QTY_ISO;
        public String BASE_UNIT_QTY;
        public String ALT_UNIT_QTY_ISO;
        public String LOWER_LEVEL_EXID;
        public String ALT_UNIT_QTY;
        public Int32 NUMBER_PACK_MAT;
        public String FLAG_SUPLMT_ITEM;
        public String MATERIAL;
        public String BATCH;
        public String PLANT;
        public String STGE_LOC;
        public Int32 INT_OBJ_NO;
        public String STOCK_CAT;
        public String SPEC_STOCK;
        public String SP_STCK_NO;
        public Int32 INSPLOT;
        public Int32 NO_OF_SERIAL_NUMBERS;
        public String SERNO_PROF;
        public String ITEM_CATEG;
        public String MATERIAL_PARTNER;
        public String PACK_MAT_TYPE;
        public String PACK_MAT_NAME;
        public String EXPIRYDATE;
        public String GR_DATE;
        public String HU_EXID;
        public String MATERIAL_EXTERNAL;
        public String MATERIAL_GUID;
        public String MATERIAL_VERSION;
        public String STOCK_SEGMENT;
    }
    public class ZMOV_QUERY_HU_READ_RETURN
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