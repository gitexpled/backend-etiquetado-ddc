using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_UPDATE_HU_HEADER
    {
        public responce_ZMOV_UPDATE_HU_HEADER sapRun(request_ZMOV_UPDATE_HU_HEADER import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_UPDATE_HU_HEADER");

            RfcStructureMetadata obj_BAPIHUHEADER = SapRfcRepository.GetStructureMetadata("BAPIHUHEADER");
            IRfcStructure datos_BAPIHUHEADER = obj_BAPIHUHEADER.CreateStructure();
            datos_BAPIHUHEADER.SetValue("CLIENT", import.HUCHANGED.CLIENT);
            datos_BAPIHUHEADER.SetValue("HU_ID", import.HUCHANGED.HU_ID);
            datos_BAPIHUHEADER.SetValue("HU_EXID", import.HUCHANGED.HU_EXID);
            datos_BAPIHUHEADER.SetValue("HU_EXID_TYPE", import.HUCHANGED.HU_EXID_TYPE);
            datos_BAPIHUHEADER.SetValue("SHIP_POINT", import.HUCHANGED.SHIP_POINT);
            datos_BAPIHUHEADER.SetValue("LOADING_POINT", import.HUCHANGED.LOADING_POINT);
            datos_BAPIHUHEADER.SetValue("TOTAL_WGHT", import.HUCHANGED.TOTAL_WGHT);
            datos_BAPIHUHEADER.SetValue("LOAD_WGHT", import.HUCHANGED.LOAD_WGHT);
            datos_BAPIHUHEADER.SetValue("TARE_WGHT", import.HUCHANGED.TARE_WGHT);
            datos_BAPIHUHEADER.SetValue("UNIT_OF_WT_ISO", import.HUCHANGED.UNIT_OF_WT_ISO);
            datos_BAPIHUHEADER.SetValue("UNIT_OF_WT", import.HUCHANGED.UNIT_OF_WT);
            datos_BAPIHUHEADER.SetValue("ALLOWED_WGHT", import.HUCHANGED.ALLOWED_WGHT);
            datos_BAPIHUHEADER.SetValue("MAX_UNIT_OF_WGHT_ISO", import.HUCHANGED.MAX_UNIT_OF_WGHT_ISO);
            datos_BAPIHUHEADER.SetValue("MAX_UNIT_OF_WGHT", import.HUCHANGED.MAX_UNIT_OF_WGHT);
            datos_BAPIHUHEADER.SetValue("TOTAL_VOL", import.HUCHANGED.TOTAL_VOL);
            datos_BAPIHUHEADER.SetValue("LOAD_VOL", import.HUCHANGED.LOAD_VOL);
            datos_BAPIHUHEADER.SetValue("TARE_VOL", import.HUCHANGED.TARE_VOL);
            datos_BAPIHUHEADER.SetValue("VOLUMEUNIT_ISO", import.HUCHANGED.VOLUMEUNIT_ISO);
            datos_BAPIHUHEADER.SetValue("VOLUMEUNIT", import.HUCHANGED.VOLUMEUNIT);
            datos_BAPIHUHEADER.SetValue("ALLOWED_VOL", import.HUCHANGED.ALLOWED_VOL);
            datos_BAPIHUHEADER.SetValue("MAX_VOL_UNIT_ISO", import.HUCHANGED.MAX_VOL_UNIT_ISO);
            datos_BAPIHUHEADER.SetValue("MAX_VOL_UNIT", import.HUCHANGED.MAX_VOL_UNIT);
            datos_BAPIHUHEADER.SetValue("NO_SIMILAR_PACK_MAT", import.HUCHANGED.NO_SIMILAR_PACK_MAT);
            datos_BAPIHUHEADER.SetValue("CREATED_BY", import.HUCHANGED.CREATED_BY);
            datos_BAPIHUHEADER.SetValue("CREATED_DATE", import.HUCHANGED.CREATED_DATE);
            datos_BAPIHUHEADER.SetValue("CREATED_TIME", import.HUCHANGED.CREATED_TIME);
            datos_BAPIHUHEADER.SetValue("CHANGED_BY", import.HUCHANGED.CHANGED_BY);
            datos_BAPIHUHEADER.SetValue("CHANGED_DATE", import.HUCHANGED.CHANGED_DATE);
            datos_BAPIHUHEADER.SetValue("CHANGED_TIME", import.HUCHANGED.CHANGED_TIME);
            datos_BAPIHUHEADER.SetValue("SORT_FLD", import.HUCHANGED.SORT_FLD);
            datos_BAPIHUHEADER.SetValue("HU_GRP1", import.HUCHANGED.HU_GRP1);
            datos_BAPIHUHEADER.SetValue("HU_GRP2", import.HUCHANGED.HU_GRP2);
            datos_BAPIHUHEADER.SetValue("HU_GRP3", import.HUCHANGED.HU_GRP3);
            datos_BAPIHUHEADER.SetValue("HU_GRP4", import.HUCHANGED.HU_GRP4);
            datos_BAPIHUHEADER.SetValue("HU_GRP5", import.HUCHANGED.HU_GRP5);
            datos_BAPIHUHEADER.SetValue("PACK_MAT", import.HUCHANGED.PACK_MAT);
            datos_BAPIHUHEADER.SetValue("LENGHT", import.HUCHANGED.LENGHT);
            datos_BAPIHUHEADER.SetValue("WIDTH", import.HUCHANGED.WIDTH);
            datos_BAPIHUHEADER.SetValue("HEIGHT", import.HUCHANGED.HEIGHT);
            datos_BAPIHUHEADER.SetValue("UNIT_DIM_ISO", import.HUCHANGED.UNIT_DIM_ISO);
            datos_BAPIHUHEADER.SetValue("UNIT_DIM", import.HUCHANGED.UNIT_DIM);
            datos_BAPIHUHEADER.SetValue("STATUS_OBSOLET", import.HUCHANGED.STATUS_OBSOLET);
            datos_BAPIHUHEADER.SetValue("WGHT_TOL_HU", import.HUCHANGED.WGHT_TOL_HU);
            datos_BAPIHUHEADER.SetValue("VOL_TOL_HU", import.HUCHANGED.VOL_TOL_HU);
            datos_BAPIHUHEADER.SetValue("BASE_UOM_ISO", import.HUCHANGED.BASE_UOM_ISO);
            datos_BAPIHUHEADER.SetValue("BASE_UOM", import.HUCHANGED.BASE_UOM);
            datos_BAPIHUHEADER.SetValue("CONTENT", import.HUCHANGED.CONTENT);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_TYPE", import.HUCHANGED.PACK_MAT_TYPE);
            datos_BAPIHUHEADER.SetValue("MAT_GRP_SM", import.HUCHANGED.MAT_GRP_SM);
            datos_BAPIHUHEADER.SetValue("PLANT", import.HUCHANGED.PLANT);
            datos_BAPIHUHEADER.SetValue("ITEM_CATEG", import.HUCHANGED.ITEM_CATEG);
            datos_BAPIHUHEADER.SetValue("SALESORG", import.HUCHANGED.SALESORG);
            datos_BAPIHUHEADER.SetValue("DC_CUSTOM_MAT", import.HUCHANGED.DC_CUSTOM_MAT);
            datos_BAPIHUHEADER.SetValue("LGTH_LOAD", import.HUCHANGED.LGTH_LOAD);
            datos_BAPIHUHEADER.SetValue("LGTH_LOAD_UNIT_ISO", import.HUCHANGED.LGTH_LOAD_UNIT_ISO);
            datos_BAPIHUHEADER.SetValue("LGTH_LOAD_UNIT", import.HUCHANGED.LGTH_LOAD_UNIT);
            datos_BAPIHUHEADER.SetValue("TRAVEL_TIME", import.HUCHANGED.TRAVEL_TIME);
            datos_BAPIHUHEADER.SetValue("TRAVEL_TIME_UNIT_ISO", import.HUCHANGED.TRAVEL_TIME_UNIT_ISO);
            datos_BAPIHUHEADER.SetValue("TRAVEL_TIME_UNIT", import.HUCHANGED.TRAVEL_TIME_UNIT);
            datos_BAPIHUHEADER.SetValue("DISTANCE", import.HUCHANGED.DISTANCE);
            datos_BAPIHUHEADER.SetValue("UNIT_OF_DIST_ISO", import.HUCHANGED.UNIT_OF_DIST_ISO);
            datos_BAPIHUHEADER.SetValue("UNIT_OF_DIST", import.HUCHANGED.UNIT_OF_DIST);
            datos_BAPIHUHEADER.SetValue("STGE_LOC", import.HUCHANGED.STGE_LOC);
            datos_BAPIHUHEADER.SetValue("WGHT_VOL_FIX", import.HUCHANGED.WGHT_VOL_FIX);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_CAT", import.HUCHANGED.PACK_MAT_CAT);
            datos_BAPIHUHEADER.SetValue("EXT_ID_HU_2", import.HUCHANGED.EXT_ID_HU_2);
            datos_BAPIHUHEADER.SetValue("CNTRY_SHP_MAT_ISO", import.HUCHANGED.CNTRY_SHP_MAT_ISO);
            datos_BAPIHUHEADER.SetValue("CNTRY_SHP_MAT", import.HUCHANGED.CNTRY_SHP_MAT);
            datos_BAPIHUHEADER.SetValue("NATIONALITY_DRIVER_ISO", import.HUCHANGED.NATIONALITY_DRIVER_ISO);
            datos_BAPIHUHEADER.SetValue("NATIONALITY_DRIVER", import.HUCHANGED.NATIONALITY_DRIVER);
            datos_BAPIHUHEADER.SetValue("NAME_DRIVER", import.HUCHANGED.NAME_DRIVER);
            datos_BAPIHUHEADER.SetValue("NAME_CO_DRIVER", import.HUCHANGED.NAME_CO_DRIVER);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_CUSTOMER", import.HUCHANGED.PACK_MAT_CUSTOMER);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_OBJECT", import.HUCHANGED.PACK_MAT_OBJECT);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_OBJ_KEY", import.HUCHANGED.PACK_MAT_OBJ_KEY);
            datos_BAPIHUHEADER.SetValue("HANDLE", import.HUCHANGED.HANDLE);
            datos_BAPIHUHEADER.SetValue("CONTAINER_STAT", import.HUCHANGED.CONTAINER_STAT);
            datos_BAPIHUHEADER.SetValue("WAREHOUSE_NUMBER", import.HUCHANGED.WAREHOUSE_NUMBER);
            datos_BAPIHUHEADER.SetValue("CLOSED_BOX", import.HUCHANGED.CLOSED_BOX);
            datos_BAPIHUHEADER.SetValue("FLAG_PACKG_LV_DANG_GOODS", import.HUCHANGED.FLAG_PACKG_LV_DANG_GOODS);
            datos_BAPIHUHEADER.SetValue("FLAG_PACKG_LV_PRINT", import.HUCHANGED.FLAG_PACKG_LV_PRINT);
            datos_BAPIHUHEADER.SetValue("HIGHER_LEVEL_HU", import.HUCHANGED.HIGHER_LEVEL_HU);
            datos_BAPIHUHEADER.SetValue("PACKG_INSTRUCT", import.HUCHANGED.PACKG_INSTRUCT);
            datos_BAPIHUHEADER.SetValue("L_PACKG_STATUS_HU", import.HUCHANGED.L_PACKG_STATUS_HU);
            datos_BAPIHUHEADER.SetValue("FLAG_NO_EXT_LABLE", import.HUCHANGED.FLAG_NO_EXT_LABLE);
            datos_BAPIHUHEADER.SetValue("PERMISS_WORKLOAD", import.HUCHANGED.PERMISS_WORKLOAD);
            datos_BAPIHUHEADER.SetValue("HU_STOR_LOC", import.HUCHANGED.HU_STOR_LOC);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_NAME", import.HUCHANGED.PACK_MAT_NAME);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_EXTERNAL", import.HUCHANGED.PACK_MAT_EXTERNAL);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_GUID", import.HUCHANGED.PACK_MAT_GUID);
            datos_BAPIHUHEADER.SetValue("PACK_MAT_VERSION", import.HUCHANGED.PACK_MAT_VERSION);
            rfcFunction.SetValue("HUCHANGED", datos_BAPIHUHEADER);
            rfcFunction.SetValue("HUKEY", import.HUKEY);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_UPDATE_HU_HEADER res = new responce_ZMOV_UPDATE_HU_HEADER();
            IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
            res.RETURN = new ZMOV_UPDATE_HU_HEADER_RETURN[rfcTable_RETURN.RowCount];
            int i_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_RETURN)
            {
                ZMOV_UPDATE_HU_HEADER_RETURN datoTabla = new ZMOV_UPDATE_HU_HEADER_RETURN();
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
    public class request_ZMOV_UPDATE_HU_HEADER
    {
        public ZMOV_UPDATE_HU_HEADER_HUCHANGED HUCHANGED;
        public String HUKEY;
    }
    public class responce_ZMOV_UPDATE_HU_HEADER
    {
        public ZMOV_UPDATE_HU_HEADER_RETURN[] RETURN;
    }
    public class ZMOV_UPDATE_HU_HEADER_HUCHANGED
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
    public class ZMOV_UPDATE_HU_HEADER_RETURN
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