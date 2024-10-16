using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_50001
    {
        public responce_ZMOV_50001 sapRun(request_ZMOV_50001 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_50001");

            RfcStructureMetadata obj_ZMOV_ST_HDR_HU_CREA = SapRfcRepository.GetStructureMetadata("ZMOV_ST_HDR_HU_CREA");
            IRfcStructure datos_ZMOV_ST_HDR_HU_CREA = obj_ZMOV_ST_HDR_HU_CREA.CreateStructure();
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("PACK_MAT", import.IS_HEADER_HU_DEST.PACK_MAT);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_EXID", import.IS_HEADER_HU_DEST.HU_EXID.PadLeft(20,'0'));
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("EXT_ID_HU_2", import.IS_HEADER_HU_DEST.EXT_ID_HU_2);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("CONTENT", import.IS_HEADER_HU_DEST.CONTENT);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("PACK_MAT_CUSTOMER", import.IS_HEADER_HU_DEST.PACK_MAT_CUSTOMER);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("PACKAGE_CAT", import.IS_HEADER_HU_DEST.PACKAGE_CAT);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("KZGVH", import.IS_HEADER_HU_DEST.KZGVH);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP1", import.IS_HEADER_HU_DEST.HU_GRP1);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP2", import.IS_HEADER_HU_DEST.HU_GRP2);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP3", import.IS_HEADER_HU_DEST.HU_GRP3);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP4", import.IS_HEADER_HU_DEST.HU_GRP4);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP5", import.IS_HEADER_HU_DEST.HU_GRP5);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("LGORT_DS", import.IS_HEADER_HU_DEST.LGORT_DS);
            rfcFunction.SetValue("IS_HEADER_HU_DEST", datos_ZMOV_ST_HDR_HU_CREA);
            //rfcFunction.SetValue("IT_EXIDV_ORI", import.IT_EXIDV_ORI);
            IRfcTable rfcTable_IT_EXIDV_ORI_I = rfcFunction.GetTable("IT_EXIDV_ORI");
            foreach (ZMOV_50001_IT_EXIDV_ORI row in import.IT_EXIDV_ORI)
            {
                rfcTable_IT_EXIDV_ORI_I.Append();
                ZMOV_50001_IT_EXIDV_ORI datoTabla = new ZMOV_50001_IT_EXIDV_ORI();
                rfcTable_IT_EXIDV_ORI_I.SetValue("EXIDV", row.EXIDV.PadLeft(20,'0'));
            }
            rfcFunction.SetValue("IT_EXIDV_ORI", rfcTable_IT_EXIDV_ORI_I);
            rfcFunction.SetValue("IV_EXIDV_DEST", import.IV_EXIDV_DEST.PadLeft(20, '0'));
            IRfcTable rfcTable_LT_ITEM_UNPACK_I = rfcFunction.GetTable("LT_ITEM_UNPACK");
            foreach (ZMOV_50001_LT_ITEM_UNPACK row in import.LT_ITEM_UNPACK)
            {
                rfcTable_LT_ITEM_UNPACK_I.Append();
                ZMOV_50001_LT_ITEM_UNPACK datoTabla = new ZMOV_50001_LT_ITEM_UNPACK();
                rfcTable_LT_ITEM_UNPACK_I.SetValue("EXIDV", row.EXIDV.PadLeft(20, '0'));
                rfcTable_LT_ITEM_UNPACK_I.SetValue("HU_ITEM_TYPE", row.HU_ITEM_TYPE);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("HU_ITEM_NUMBER", row.HU_ITEM_NUMBER);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("UNPACK_EXID", row.UNPACK_EXID);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("BATCH", row.BATCH);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("PACK_QTY", row.PACK_QTY);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("BASE_UNIT_QTY_ISO", row.BASE_UNIT_QTY_ISO);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("BASE_UNIT_QTY", row.BASE_UNIT_QTY);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("PLANT", row.PLANT);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("STGE_LOC", row.STGE_LOC);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("STOCK_CAT", row.STOCK_CAT);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("SPEC_STOCK", row.SPEC_STOCK);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("SP_STCK_NO", row.SP_STCK_NO);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("MATERIAL_EXTERNAL", row.MATERIAL_EXTERNAL);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("MATERIAL_GUID", row.MATERIAL_GUID);
                rfcTable_LT_ITEM_UNPACK_I.SetValue("MATERIAL_VERSION", row.MATERIAL_VERSION);
            }
            rfcFunction.SetValue("LT_ITEM_UNPACK", rfcTable_LT_ITEM_UNPACK_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_50001 res = new responce_ZMOV_50001();
            //res.ET_RETURN = rfcFunction.GetString("ET_RETURN");
            IRfcTable rfcTable_ET_RETURN = rfcFunction.GetTable("ET_RETURN");
            res.ET_RETURN = new ZMOV_50001_ET_RETURN[rfcTable_ET_RETURN.RowCount];
            int i_ET_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_ET_RETURN)
            {
                ZMOV_50001_ET_RETURN datoTabla = new ZMOV_50001_ET_RETURN();
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
                res.ET_RETURN[i_ET_RETURN] = datoTabla; ++i_ET_RETURN;
            }
            IRfcTable rfcTable_IT_EXIDV_ORI = rfcFunction.GetTable("IT_EXIDV_ORI");
            res.IT_EXIDV_ORI = new ZMOV_50001_IT_EXIDV_ORI[rfcTable_IT_EXIDV_ORI.RowCount];
            int i_IT_EXIDV_ORI = 0;
            foreach (IRfcStructure row in rfcTable_IT_EXIDV_ORI)
            {
                ZMOV_50001_IT_EXIDV_ORI datoTabla = new ZMOV_50001_IT_EXIDV_ORI();
                datoTabla.EXIDV = row.GetString("EXIDV");
                res.IT_EXIDV_ORI[i_IT_EXIDV_ORI] = datoTabla; ++i_IT_EXIDV_ORI;
            }
            IRfcTable rfcTable_LT_ITEM_UNPACK = rfcFunction.GetTable("LT_ITEM_UNPACK");
            res.LT_ITEM_UNPACK = new ZMOV_50001_LT_ITEM_UNPACK[rfcTable_LT_ITEM_UNPACK.RowCount];
            int i_LT_ITEM_UNPACK = 0;
            foreach (IRfcStructure row in rfcTable_LT_ITEM_UNPACK)
            {
                ZMOV_50001_LT_ITEM_UNPACK datoTabla = new ZMOV_50001_LT_ITEM_UNPACK();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.HU_ITEM_TYPE = row.GetString("HU_ITEM_TYPE");
                datoTabla.HU_ITEM_NUMBER = row.GetInt("HU_ITEM_NUMBER");
                datoTabla.UNPACK_EXID = row.GetString("UNPACK_EXID");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.PACK_QTY = row.GetDecimal("PACK_QTY");
                datoTabla.BASE_UNIT_QTY_ISO = row.GetString("BASE_UNIT_QTY_ISO");
                datoTabla.BASE_UNIT_QTY = row.GetString("BASE_UNIT_QTY");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.STOCK_CAT = row.GetString("STOCK_CAT");
                datoTabla.SPEC_STOCK = row.GetString("SPEC_STOCK");
                datoTabla.SP_STCK_NO = row.GetString("SP_STCK_NO");
                datoTabla.MATERIAL_EXTERNAL = row.GetString("MATERIAL_EXTERNAL");
                datoTabla.MATERIAL_GUID = row.GetString("MATERIAL_GUID");
                datoTabla.MATERIAL_VERSION = row.GetString("MATERIAL_VERSION");
                res.LT_ITEM_UNPACK[i_LT_ITEM_UNPACK] = datoTabla; ++i_LT_ITEM_UNPACK;
            }
            IRfcTable rfcTable_LT_RETURN = rfcFunction.GetTable("LT_RETURN");
            res.LT_RETURN = new ZMOV_50001_LT_RETURN[rfcTable_LT_RETURN.RowCount];
            int i_LT_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_LT_RETURN)
            {
                ZMOV_50001_LT_RETURN datoTabla = new ZMOV_50001_LT_RETURN();
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
                res.LT_RETURN[i_LT_RETURN] = datoTabla; ++i_LT_RETURN;
            }

            return res;
        }
    }
    public class request_ZMOV_50001
    {
        public ZMOV_50001_IS_HEADER_HU_DEST IS_HEADER_HU_DEST;
        //public String IT_EXIDV_ORI;
        public ZMOV_50001_IT_EXIDV_ORI[] IT_EXIDV_ORI;
        public String IV_EXIDV_DEST;
        public ZMOV_50001_LT_ITEM_UNPACK[] LT_ITEM_UNPACK;
    }
    public class responce_ZMOV_50001
    {
        //public String ET_RETURN;
        public ZMOV_50001_ET_RETURN[] ET_RETURN;
        public ZMOV_50001_IT_EXIDV_ORI[] IT_EXIDV_ORI;
        public ZMOV_50001_LT_ITEM_UNPACK[] LT_ITEM_UNPACK;
        public ZMOV_50001_LT_RETURN[] LT_RETURN;
    }
    public class ZMOV_50001_IS_HEADER_HU_DEST
    {
        public String PACK_MAT;
        public String HU_EXID;
        public String EXT_ID_HU_2;
        public String CONTENT;
        public String PACK_MAT_CUSTOMER;
        public String PACKAGE_CAT;
        public String KZGVH;
        public String HU_GRP1;
        public String HU_GRP2;
        public String HU_GRP3;
        public String HU_GRP4;
        public String HU_GRP5;
        public String LGORT_DS;
    }
    public class ZMOV_50001_ET_RETURN
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
    public class ZMOV_50001_IT_EXIDV_ORI
    {
        public String EXIDV;
    }
    public class ZMOV_50001_LT_ITEM_UNPACK
    {
        public String EXIDV;
        public String HU_ITEM_TYPE;
        public Int32 HU_ITEM_NUMBER;
        public String UNPACK_EXID;
        public String MATERIAL;
        public String BATCH;
        public Decimal PACK_QTY;
        public String BASE_UNIT_QTY_ISO;
        public String BASE_UNIT_QTY;
        public String PLANT;
        public String STGE_LOC;
        public String STOCK_CAT;
        public String SPEC_STOCK;
        public String SP_STCK_NO;
        public String MATERIAL_EXTERNAL;
        public String MATERIAL_GUID;
        public String MATERIAL_VERSION;
    }
    public class ZMOV_50001_LT_RETURN
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