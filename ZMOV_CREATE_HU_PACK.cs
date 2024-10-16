using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_CREATE_HU_PACK
    {
        public responce_ZMOV_CREATE_HU_PACK sapRun(request_ZMOV_CREATE_HU_PACK import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_CREATE_HU_PACK");

            rfcFunction.SetValue("HUKEY", import.HUKEY);
            IRfcTable rfcTable_IT_ITEMPROPOSAL_I = rfcFunction.GetTable("IT_ITEMPROPOSAL");
            foreach (ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL row in import.IT_ITEMPROPOSAL)
            {
                rfcTable_IT_ITEMPROPOSAL_I.Append();
                ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL datoTabla = new ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL();
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("HU_ITEM_TYPE", row.HU_ITEM_TYPE);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("LOWER_LEVEL_EXID", row.LOWER_LEVEL_EXID);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("PACK_QTY", row.PACK_QTY);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("BASE_UNIT_QTY_ISO", row.BASE_UNIT_QTY_ISO);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("BASE_UNIT_QTY", row.BASE_UNIT_QTY);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("NUMBER_PACK_MAT", row.NUMBER_PACK_MAT);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("FLAG_SUPLMT_ITEM", row.FLAG_SUPLMT_ITEM);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("BATCH", row.BATCH);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("PLANT", row.PLANT);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("STGE_LOC", row.STGE_LOC);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("STOCK_CAT", row.STOCK_CAT);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("SPEC_STOCK", row.SPEC_STOCK);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("SP_STCK_NO", row.SP_STCK_NO);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("NO_OF_SERIAL_NUMBERS", row.NO_OF_SERIAL_NUMBERS);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("MATERIAL_PARTNER", row.MATERIAL_PARTNER);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("EXPIRYDATE", row.EXPIRYDATE);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("GR_DATE", row.GR_DATE);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("MATERIAL_EXTERNAL", row.MATERIAL_EXTERNAL);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("MATERIAL_GUID", row.MATERIAL_GUID);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("MATERIAL_VERSION", row.MATERIAL_VERSION);
                rfcTable_IT_ITEMPROPOSAL_I.SetValue("STK_SEGMENT", row.STK_SEGMENT);
            }
            rfcFunction.SetValue("IT_ITEMPROPOSAL", rfcTable_IT_ITEMPROPOSAL_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_CREATE_HU_PACK res = new responce_ZMOV_CREATE_HU_PACK();
            IRfcTable rfcTable_IT_ITEMPROPOSAL = rfcFunction.GetTable("IT_ITEMPROPOSAL");
            res.IT_ITEMPROPOSAL = new ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL[rfcTable_IT_ITEMPROPOSAL.RowCount];
            int i_IT_ITEMPROPOSAL = 0;
            foreach (IRfcStructure row in rfcTable_IT_ITEMPROPOSAL)
            {
                ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL datoTabla = new ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL();
                datoTabla.HU_ITEM_TYPE = row.GetString("HU_ITEM_TYPE");
                datoTabla.LOWER_LEVEL_EXID = row.GetString("LOWER_LEVEL_EXID");
                datoTabla.PACK_QTY = row.GetDecimal("PACK_QTY");
                datoTabla.BASE_UNIT_QTY_ISO = row.GetString("BASE_UNIT_QTY_ISO");
                datoTabla.BASE_UNIT_QTY = row.GetString("BASE_UNIT_QTY");
                datoTabla.NUMBER_PACK_MAT = row.GetInt("NUMBER_PACK_MAT");
                datoTabla.FLAG_SUPLMT_ITEM = row.GetString("FLAG_SUPLMT_ITEM");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.STOCK_CAT = row.GetString("STOCK_CAT");
                datoTabla.SPEC_STOCK = row.GetString("SPEC_STOCK");
                datoTabla.SP_STCK_NO = row.GetString("SP_STCK_NO");
                datoTabla.NO_OF_SERIAL_NUMBERS = row.GetInt("NO_OF_SERIAL_NUMBERS");
                datoTabla.MATERIAL_PARTNER = row.GetString("MATERIAL_PARTNER");
                datoTabla.EXPIRYDATE = row.GetString("EXPIRYDATE");
                datoTabla.GR_DATE = row.GetString("GR_DATE");
                datoTabla.MATERIAL_EXTERNAL = row.GetString("MATERIAL_EXTERNAL");
                datoTabla.MATERIAL_GUID = row.GetString("MATERIAL_GUID");
                datoTabla.MATERIAL_VERSION = row.GetString("MATERIAL_VERSION");
                datoTabla.STK_SEGMENT = row.GetString("STK_SEGMENT");
                res.IT_ITEMPROPOSAL[i_IT_ITEMPROPOSAL] = datoTabla; ++i_IT_ITEMPROPOSAL;
            }
            IRfcTable rfcTable_RETURN_PACK = rfcFunction.GetTable("RETURN_PACK");
            res.RETURN_PACK = new ZMOV_CREATE_HU_PACK_RETURN_PACK[rfcTable_RETURN_PACK.RowCount];
            int i_RETURN_PACK = 0;
            foreach (IRfcStructure row in rfcTable_RETURN_PACK)
            {
                ZMOV_CREATE_HU_PACK_RETURN_PACK datoTabla = new ZMOV_CREATE_HU_PACK_RETURN_PACK();
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
                res.RETURN_PACK[i_RETURN_PACK] = datoTabla; ++i_RETURN_PACK;
            }

            return res;
        }
    }
    public class request_ZMOV_CREATE_HU_PACK
    {
        public String HUKEY;
        public ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL[] IT_ITEMPROPOSAL;
    }
    public class responce_ZMOV_CREATE_HU_PACK
    {
        public ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL[] IT_ITEMPROPOSAL;
        public ZMOV_CREATE_HU_PACK_RETURN_PACK[] RETURN_PACK;
    }
    public class ZMOV_CREATE_HU_PACK_IT_ITEMPROPOSAL
    {
        public String HU_ITEM_TYPE;
        public String LOWER_LEVEL_EXID;
        public Decimal PACK_QTY;
        public String BASE_UNIT_QTY_ISO;
        public String BASE_UNIT_QTY;
        public Int32 NUMBER_PACK_MAT;
        public String FLAG_SUPLMT_ITEM;
        public String MATERIAL;
        public String BATCH;
        public String PLANT;
        public String STGE_LOC;
        public String STOCK_CAT;
        public String SPEC_STOCK;
        public String SP_STCK_NO;
        public Int32 NO_OF_SERIAL_NUMBERS;
        public String MATERIAL_PARTNER;
        public String EXPIRYDATE;
        public String GR_DATE;
        public String MATERIAL_EXTERNAL;
        public String MATERIAL_GUID;
        public String MATERIAL_VERSION;
        public String STK_SEGMENT;
    }
    public class ZMOV_CREATE_HU_PACK_RETURN_PACK
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