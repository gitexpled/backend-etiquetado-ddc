using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_CREATE_HU_UNPACK
    {
        public responce_ZMOV_CREATE_HU_UNPACK sapRun(request_ZMOV_CREATE_HU_UNPACK import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_CREATE_HU_UNPACK");

            rfcFunction.SetValue("HUKEY", import.HUKEY);
            IRfcTable rfcTable_IT_ITEMUNPACK_I = rfcFunction.GetTable("IT_ITEMUNPACK");
            foreach (ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK row in import.IT_ITEMUNPACK)
            {
                rfcTable_IT_ITEMUNPACK_I.Append();
                ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK datoTabla = new ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK();
                rfcTable_IT_ITEMUNPACK_I.SetValue("HU_ITEM_TYPE", row.HU_ITEM_TYPE);
                rfcTable_IT_ITEMUNPACK_I.SetValue("HU_ITEM_NUMBER", row.HU_ITEM_NUMBER);
                rfcTable_IT_ITEMUNPACK_I.SetValue("UNPACK_EXID", row.UNPACK_EXID);
                rfcTable_IT_ITEMUNPACK_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_IT_ITEMUNPACK_I.SetValue("BATCH", row.BATCH);
                rfcTable_IT_ITEMUNPACK_I.SetValue("PACK_QTY", row.PACK_QTY);
                rfcTable_IT_ITEMUNPACK_I.SetValue("BASE_UNIT_QTY_ISO", row.BASE_UNIT_QTY_ISO);
                rfcTable_IT_ITEMUNPACK_I.SetValue("BASE_UNIT_QTY", row.BASE_UNIT_QTY);
                rfcTable_IT_ITEMUNPACK_I.SetValue("PLANT", row.PLANT);
                rfcTable_IT_ITEMUNPACK_I.SetValue("STGE_LOC", row.STGE_LOC);
                rfcTable_IT_ITEMUNPACK_I.SetValue("STOCK_CAT", row.STOCK_CAT);
                rfcTable_IT_ITEMUNPACK_I.SetValue("SPEC_STOCK", row.SPEC_STOCK);
                rfcTable_IT_ITEMUNPACK_I.SetValue("SP_STCK_NO", row.SP_STCK_NO);
                rfcTable_IT_ITEMUNPACK_I.SetValue("MATERIAL_EXTERNAL", row.MATERIAL_EXTERNAL);
                rfcTable_IT_ITEMUNPACK_I.SetValue("MATERIAL_GUID", row.MATERIAL_GUID);
                rfcTable_IT_ITEMUNPACK_I.SetValue("MATERIAL_VERSION", row.MATERIAL_VERSION);
            }
            rfcFunction.SetValue("IT_ITEMUNPACK", rfcTable_IT_ITEMUNPACK_I);
            IRfcTable rfcTable_RETURN_UNPACK_I = rfcFunction.GetTable("RETURN_UNPACK");
            foreach (ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK row in import.RETURN_UNPACK)
            {
                rfcTable_RETURN_UNPACK_I.Append();
                ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK datoTabla = new ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK();
                rfcTable_RETURN_UNPACK_I.SetValue("TYPE", row.TYPE);
                rfcTable_RETURN_UNPACK_I.SetValue("ID", row.ID);
                rfcTable_RETURN_UNPACK_I.SetValue("NUMBER", row.NUMBER);
                rfcTable_RETURN_UNPACK_I.SetValue("MESSAGE", row.MESSAGE);
                rfcTable_RETURN_UNPACK_I.SetValue("LOG_NO", row.LOG_NO);
                rfcTable_RETURN_UNPACK_I.SetValue("LOG_MSG_NO", row.LOG_MSG_NO);
                rfcTable_RETURN_UNPACK_I.SetValue("MESSAGE_V1", row.MESSAGE_V1);
                rfcTable_RETURN_UNPACK_I.SetValue("MESSAGE_V2", row.MESSAGE_V2);
                rfcTable_RETURN_UNPACK_I.SetValue("MESSAGE_V3", row.MESSAGE_V3);
                rfcTable_RETURN_UNPACK_I.SetValue("MESSAGE_V4", row.MESSAGE_V4);
                rfcTable_RETURN_UNPACK_I.SetValue("PARAMETER", row.PARAMETER);
                rfcTable_RETURN_UNPACK_I.SetValue("ROW", row.ROW);
                rfcTable_RETURN_UNPACK_I.SetValue("FIELD", row.FIELD);
                rfcTable_RETURN_UNPACK_I.SetValue("SYSTEM", row.SYSTEM);
            }
            rfcFunction.SetValue("RETURN_UNPACK", rfcTable_RETURN_UNPACK_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_CREATE_HU_UNPACK res = new responce_ZMOV_CREATE_HU_UNPACK();
            IRfcTable rfcTable_IT_ITEMUNPACK = rfcFunction.GetTable("IT_ITEMUNPACK");
            res.IT_ITEMUNPACK = new ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK[rfcTable_IT_ITEMUNPACK.RowCount];
            int i_IT_ITEMUNPACK = 0;
            foreach (IRfcStructure row in rfcTable_IT_ITEMUNPACK)
            {
                ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK datoTabla = new ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK();
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
                res.IT_ITEMUNPACK[i_IT_ITEMUNPACK] = datoTabla; ++i_IT_ITEMUNPACK;
            }
            IRfcTable rfcTable_RETURN_UNPACK = rfcFunction.GetTable("RETURN_UNPACK");
            res.RETURN_UNPACK = new ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK[rfcTable_RETURN_UNPACK.RowCount];
            int i_RETURN_UNPACK = 0;
            foreach (IRfcStructure row in rfcTable_RETURN_UNPACK)
            {
                ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK datoTabla = new ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK();
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
                res.RETURN_UNPACK[i_RETURN_UNPACK] = datoTabla; ++i_RETURN_UNPACK;
            }

            return res;
        }
    }
    public class request_ZMOV_CREATE_HU_UNPACK
    {
        public String HUKEY;
        public ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK[] IT_ITEMUNPACK;
        public ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK[] RETURN_UNPACK;
    }
    public class responce_ZMOV_CREATE_HU_UNPACK
    {
        public ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK[] IT_ITEMUNPACK;
        public ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK[] RETURN_UNPACK;
    }
    public class ZMOV_CREATE_HU_UNPACK_IT_ITEMUNPACK
    {
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
    public class ZMOV_CREATE_HU_UNPACK_RETURN_UNPACK
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