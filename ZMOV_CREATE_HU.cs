using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_CREATE_HU
    {
        public responce_ZMOV_CREATE_HU sapRun(request_ZMOV_CREATE_HU import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_CREATE_HU");

            RfcStructureMetadata obj_ZMOV_ST_HDR_HU_CREA = SapRfcRepository.GetStructureMetadata("ZMOV_ST_HDR_HU_CREA");
            IRfcStructure datos_ZMOV_ST_HDR_HU_CREA = obj_ZMOV_ST_HDR_HU_CREA.CreateStructure();
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("PACK_MAT", import.HEADER_HU.PACK_MAT);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_EXID", import.HEADER_HU.HU_EXID);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("EXT_ID_HU_2", import.HEADER_HU.EXT_ID_HU_2);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("CONTENT", import.HEADER_HU.CONTENT);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("PACK_MAT_CUSTOMER", import.HEADER_HU.PACK_MAT_CUSTOMER);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("PACKAGE_CAT", import.HEADER_HU.PACKAGE_CAT);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("KZGVH", import.HEADER_HU.KZGVH);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP1", import.HEADER_HU.HU_GRP1);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP2", import.HEADER_HU.HU_GRP2);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP3", import.HEADER_HU.HU_GRP3);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP4", import.HEADER_HU.HU_GRP4);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("HU_GRP5", import.HEADER_HU.HU_GRP5);
            datos_ZMOV_ST_HDR_HU_CREA.SetValue("LGORT_DS", import.HEADER_HU.LGORT_DS);
            rfcFunction.SetValue("HEADER_HU", datos_ZMOV_ST_HDR_HU_CREA);
            IRfcTable rfcTable_ITEM_HU_I = rfcFunction.GetTable("ITEM_HU");
            foreach (ZMOV_CREATE_HU_ITEM_HU row in import.ITEM_HU)
            {
                rfcTable_ITEM_HU_I.Append();
                ZMOV_CREATE_HU_ITEM_HU datoTabla = new ZMOV_CREATE_HU_ITEM_HU();
                rfcTable_ITEM_HU_I.SetValue("HU_ITEM_TYPE", row.HU_ITEM_TYPE);
                rfcTable_ITEM_HU_I.SetValue("PACK_QTY", row.PACK_QTY);
                rfcTable_ITEM_HU_I.SetValue("BASE_UNIT_QTY", row.BASE_UNIT_QTY);
                rfcTable_ITEM_HU_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_ITEM_HU_I.SetValue("BATCH", row.BATCH);
                rfcTable_ITEM_HU_I.SetValue("PLANT", row.PLANT);
                rfcTable_ITEM_HU_I.SetValue("STGE_LOC", row.STGE_LOC);
                rfcTable_ITEM_HU_I.SetValue("STOCK_CAT", row.STOCK_CAT);
            }
            rfcFunction.SetValue("ITEM_HU", rfcTable_ITEM_HU_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_CREATE_HU res = new responce_ZMOV_CREATE_HU();
            res.HUKEY = rfcFunction.GetString("HUKEY");
            IRfcTable rfcTable_ITEM_HU = rfcFunction.GetTable("ITEM_HU");
            res.ITEM_HU = new ZMOV_CREATE_HU_ITEM_HU[rfcTable_ITEM_HU.RowCount];
            int i_ITEM_HU = 0;
            foreach (IRfcStructure row in rfcTable_ITEM_HU)
            {
                ZMOV_CREATE_HU_ITEM_HU datoTabla = new ZMOV_CREATE_HU_ITEM_HU();
                datoTabla.HU_ITEM_TYPE = row.GetString("HU_ITEM_TYPE");
                datoTabla.PACK_QTY = row.GetDecimal("PACK_QTY");
                datoTabla.BASE_UNIT_QTY = row.GetString("BASE_UNIT_QTY");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.STOCK_CAT = row.GetString("STOCK_CAT");
                res.ITEM_HU[i_ITEM_HU] = datoTabla; ++i_ITEM_HU;
            }
            IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
            res.RETURN = new ZMOV_CREATE_HU_RETURN[rfcTable_RETURN.RowCount];
            int i_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_RETURN)
            {
                ZMOV_CREATE_HU_RETURN datoTabla = new ZMOV_CREATE_HU_RETURN();
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
            IRfcTable rfcTable_RETURN_CREA = rfcFunction.GetTable("RETURN_CREA");
            res.RETURN_CREA = new ZMOV_CREATE_HU_RETURN_CREA[rfcTable_RETURN_CREA.RowCount];
            int i_RETURN_CREA = 0;
            foreach (IRfcStructure row in rfcTable_RETURN_CREA)
            {
                ZMOV_CREATE_HU_RETURN_CREA datoTabla = new ZMOV_CREATE_HU_RETURN_CREA();
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
                res.RETURN_CREA[i_RETURN_CREA] = datoTabla; ++i_RETURN_CREA;
            }

            return res;
        }
    }
    public class request_ZMOV_CREATE_HU
    {
        public ZMOV_CREATE_HU_HEADER_HU HEADER_HU;
        public ZMOV_CREATE_HU_ITEM_HU[] ITEM_HU;
    }
    public class responce_ZMOV_CREATE_HU
    {
        public String HUKEY;
        public ZMOV_CREATE_HU_ITEM_HU[] ITEM_HU;
        public ZMOV_CREATE_HU_RETURN[] RETURN;
        public ZMOV_CREATE_HU_RETURN_CREA[] RETURN_CREA;
    }
    public class ZMOV_CREATE_HU_HEADER_HU
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
    public class ZMOV_CREATE_HU_ITEM_HU
    {
        public String HU_ITEM_TYPE;
        public Decimal PACK_QTY;
        public String BASE_UNIT_QTY;
        public String MATERIAL;
        public String BATCH;
        public String PLANT;
        public String STGE_LOC;
        public String STOCK_CAT;
    }
    public class ZMOV_CREATE_HU_RETURN
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
    public class ZMOV_CREATE_HU_RETURN_CREA
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