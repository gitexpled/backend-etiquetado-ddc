using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_CREATE_RECEP_HU_FRESCOUAT
    {
        public responce_ZMOV_CREATE_RECEP_HU_FRESCOUAT sapRun(request_ZMOV_CREATE_RECEP_HU_FRESCOUAT import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_CREATE_RECEP_HU_FRESCOUAT");

            RfcStructureMetadata obj_ZMOV_ST_HEADER = SapRfcRepository.GetStructureMetadata("ZMOV_ST_HEADER");
            IRfcStructure datos_ZMOV_ST_HEADER = obj_ZMOV_ST_HEADER.CreateStructure();
            datos_ZMOV_ST_HEADER.SetValue("BUKRS", import.HEADER.BUKRS);
            datos_ZMOV_ST_HEADER.SetValue("EKORG", import.HEADER.EKORG);
            datos_ZMOV_ST_HEADER.SetValue("EKGRP", import.HEADER.EKGRP);
            datos_ZMOV_ST_HEADER.SetValue("BSART", import.HEADER.BSART);
            datos_ZMOV_ST_HEADER.SetValue("BUDAT", import.HEADER.BUDAT);
            datos_ZMOV_ST_HEADER.SetValue("LIFNR", import.HEADER.LIFNR);
            datos_ZMOV_ST_HEADER.SetValue("XBLNR", import.HEADER.XBLNR);
            datos_ZMOV_ST_HEADER.SetValue("BKTXT", import.HEADER.BKTXT);
            rfcFunction.SetValue("HEADER", datos_ZMOV_ST_HEADER);
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
            rfcFunction.SetValue("I_COPEQUEN", import.I_COPEQUEN);
            rfcFunction.SetValue("I_UAT", import.I_UAT);
            IRfcTable rfcTable_LOG_I = rfcFunction.GetTable("LOG");
            foreach (ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG row in import.LOG)
            {
                rfcTable_LOG_I.Append();
                ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG datoTabla = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG();
                rfcTable_LOG_I.SetValue("TYPE", row.TYPE);
                rfcTable_LOG_I.SetValue("ID", row.ID);
                rfcTable_LOG_I.SetValue("NUMBER", row.NUMBER);
                rfcTable_LOG_I.SetValue("MESSAGE", row.MESSAGE);
                rfcTable_LOG_I.SetValue("LOG_NO", row.LOG_NO);
                rfcTable_LOG_I.SetValue("LOG_MSG_NO", row.LOG_MSG_NO);
                rfcTable_LOG_I.SetValue("MESSAGE_V1", row.MESSAGE_V1);
                rfcTable_LOG_I.SetValue("MESSAGE_V2", row.MESSAGE_V2);
                rfcTable_LOG_I.SetValue("MESSAGE_V3", row.MESSAGE_V3);
                rfcTable_LOG_I.SetValue("MESSAGE_V4", row.MESSAGE_V4);
                rfcTable_LOG_I.SetValue("PARAMETER", row.PARAMETER);
                rfcTable_LOG_I.SetValue("ROW", row.ROW);
                rfcTable_LOG_I.SetValue("FIELD", row.FIELD);
                rfcTable_LOG_I.SetValue("SYSTEM", row.SYSTEM);
            }
            rfcFunction.SetValue("LOG", rfcTable_LOG_I);
            IRfcTable rfcTable_LT_CARACT_I = rfcFunction.GetTable("LT_CARACT");
            foreach (ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT row in import.LT_CARACT)
            {
                rfcTable_LT_CARACT_I.Append();
                ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT datoTabla = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT();
                rfcTable_LT_CARACT_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_LT_CARACT_I.SetValue("BATCH", row.BATCH);
                rfcTable_LT_CARACT_I.SetValue("CHARACT", row.CHARACT);
                rfcTable_LT_CARACT_I.SetValue("VALUE_CHAR", row.VALUE_CHAR);
            }
            rfcFunction.SetValue("LT_CARACT", rfcTable_LT_CARACT_I);
            IRfcTable rfcTable_LT_ITEMS_I = rfcFunction.GetTable("LT_ITEMS");
            foreach (ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS row in import.LT_ITEMS)
            {
                rfcTable_LT_ITEMS_I.Append();
                ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS datoTabla = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS();
                rfcTable_LT_ITEMS_I.SetValue("STCK_TYPE", row.STCK_TYPE);
                rfcTable_LT_ITEMS_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_LT_ITEMS_I.SetValue("BATCH", row.BATCH);
                rfcTable_LT_ITEMS_I.SetValue("QUANTITY", row.QUANTITY);
                rfcTable_LT_ITEMS_I.SetValue("PO_UNIT", row.PO_UNIT);
                rfcTable_LT_ITEMS_I.SetValue("HSDAT", row.HSDAT);
                rfcTable_LT_ITEMS_I.SetValue("PLANT", row.PLANT);
                rfcTable_LT_ITEMS_I.SetValue("STGE_LOC", row.STGE_LOC);
                rfcTable_LT_ITEMS_I.SetValue("FREE_ITEM", row.FREE_ITEM);
                rfcTable_LT_ITEMS_I.SetValue("ITEM_CAT", row.ITEM_CAT);
                rfcTable_LT_ITEMS_I.SetValue("MOVE_BATCH", row.MOVE_BATCH);
                rfcTable_LT_ITEMS_I.SetValue("BATCH_GRANEL", row.BATCH_GRANEL);
                rfcTable_LT_ITEMS_I.SetValue("ACCTASSCAT", row.ACCTASSCAT);
            }
            rfcFunction.SetValue("LT_ITEMS", rfcTable_LT_ITEMS_I);
            IRfcTable rfcTable_LT_ITEM_DEST_I = rfcFunction.GetTable("LT_ITEM_DEST");
            foreach (ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST row in import.LT_ITEM_DEST)
            {
                rfcTable_LT_ITEM_DEST_I.Append();
                ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST datoTabla = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST();
                rfcTable_LT_ITEM_DEST_I.SetValue("LFPOS", row.LFPOS);
                rfcTable_LT_ITEM_DEST_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_LT_ITEM_DEST_I.SetValue("QUANTITY", row.QUANTITY);
                rfcTable_LT_ITEM_DEST_I.SetValue("PO_UNIT", row.PO_UNIT);
                rfcTable_LT_ITEM_DEST_I.SetValue("WERKS", row.WERKS);
                rfcTable_LT_ITEM_DEST_I.SetValue("LGORT", row.LGORT);
            }
            rfcFunction.SetValue("LT_ITEM_DEST", rfcTable_LT_ITEM_DEST_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_CREATE_RECEP_HU_FRESCOUAT res = new responce_ZMOV_CREATE_RECEP_HU_FRESCOUAT();
            res.E_EXIDV = rfcFunction.GetString("E_EXIDV");
            res.E_MATDOC_COS = rfcFunction.GetString("E_MATDOC_COS");
            res.E_MATDOC_FRU = rfcFunction.GetString("E_MATDOC_FRU");
            res.E_MATDOC_TRA = rfcFunction.GetString("E_MATDOC_TRA");
            res.E_MATERIALDOCUMENT = rfcFunction.GetString("E_MATERIALDOCUMENT");
            res.MATERIALDOCUMENT = rfcFunction.GetString("MATERIALDOCUMENT");
            res.MATERIALDOCUMENT_BD = rfcFunction.GetString("MATERIALDOCUMENT_BD");
            res.PEDIDO = rfcFunction.GetString("PEDIDO");
            IRfcTable rfcTable_LOG = rfcFunction.GetTable("LOG");
            res.LOG = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG[rfcTable_LOG.RowCount];
            int i_LOG = 0;
            foreach (IRfcStructure row in rfcTable_LOG)
            {
                ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG datoTabla = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG();
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
                res.LOG[i_LOG] = datoTabla; ++i_LOG;
            }
            IRfcTable rfcTable_LT_CARACT = rfcFunction.GetTable("LT_CARACT");
            res.LT_CARACT = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT[rfcTable_LT_CARACT.RowCount];
            int i_LT_CARACT = 0;
            foreach (IRfcStructure row in rfcTable_LT_CARACT)
            {
                ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT datoTabla = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT();
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.CHARACT = row.GetString("CHARACT");
                datoTabla.VALUE_CHAR = row.GetString("VALUE_CHAR");
                res.LT_CARACT[i_LT_CARACT] = datoTabla; ++i_LT_CARACT;
            }
            IRfcTable rfcTable_LT_ITEMS = rfcFunction.GetTable("LT_ITEMS");
            res.LT_ITEMS = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS[rfcTable_LT_ITEMS.RowCount];
            int i_LT_ITEMS = 0;
            foreach (IRfcStructure row in rfcTable_LT_ITEMS)
            {
                ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS datoTabla = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS();
                datoTabla.STCK_TYPE = row.GetString("STCK_TYPE");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.FREE_ITEM = row.GetString("FREE_ITEM");
                datoTabla.ITEM_CAT = row.GetString("ITEM_CAT");
                datoTabla.MOVE_BATCH = row.GetString("MOVE_BATCH");
                datoTabla.BATCH_GRANEL = row.GetString("BATCH_GRANEL");
                datoTabla.ACCTASSCAT = row.GetString("ACCTASSCAT");
                res.LT_ITEMS[i_LT_ITEMS] = datoTabla; ++i_LT_ITEMS;
            }
            IRfcTable rfcTable_LT_ITEM_DEST = rfcFunction.GetTable("LT_ITEM_DEST");
            res.LT_ITEM_DEST = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST[rfcTable_LT_ITEM_DEST.RowCount];
            int i_LT_ITEM_DEST = 0;
            foreach (IRfcStructure row in rfcTable_LT_ITEM_DEST)
            {
                ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST datoTabla = new ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST();
                datoTabla.LFPOS = row.GetInt("LFPOS");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                res.LT_ITEM_DEST[i_LT_ITEM_DEST] = datoTabla; ++i_LT_ITEM_DEST;
            }

            return res;
        }
    }
    public class request_ZMOV_CREATE_RECEP_HU_FRESCOUAT
    {
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_HEADER HEADER;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_HEADER_HU HEADER_HU;
        public String I_COPEQUEN;
        public String I_UAT;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG[] LOG;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT[] LT_CARACT;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS[] LT_ITEMS;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST[] LT_ITEM_DEST;
    }
    public class responce_ZMOV_CREATE_RECEP_HU_FRESCOUAT
    {
        public String E_EXIDV;
        public String E_MATDOC_COS;
        public String E_MATDOC_FRU;
        public String E_MATDOC_TRA;
        public String E_MATERIALDOCUMENT;
        public String MATERIALDOCUMENT;
        public String MATERIALDOCUMENT_BD;
        public String PEDIDO;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG[] LOG;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT[] LT_CARACT;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS[] LT_ITEMS;
        public ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST[] LT_ITEM_DEST;
    }
    public class ZMOV_CREATE_RECEP_HU_FRESCOUAT_HEADER
    {
        public String BUKRS;
        public String EKORG;
        public String EKGRP;
        public String BSART;
        public String BUDAT;
        public String LIFNR;
        public String XBLNR;
        public String BKTXT;
    }
    public class ZMOV_CREATE_RECEP_HU_FRESCOUAT_HEADER_HU
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
    public class ZMOV_CREATE_RECEP_HU_FRESCOUAT_LOG
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
    public class ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_CARACT
    {
        public String MATERIAL;
        public String BATCH;
        public String CHARACT;
        public String VALUE_CHAR;
    }
    public class ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEMS
    {
        public String STCK_TYPE;
        public String MATERIAL;
        public String BATCH;
        public Decimal QUANTITY;
        public String PO_UNIT;
        public String HSDAT;
        public String PLANT;
        public String STGE_LOC;
        public String FREE_ITEM;
        public String ITEM_CAT;
        public String MOVE_BATCH;
        public String BATCH_GRANEL;
        public String ACCTASSCAT;
    }
    public class ZMOV_CREATE_RECEP_HU_FRESCOUAT_LT_ITEM_DEST
    {
        public Int32 LFPOS;
        public String MATERIAL;
        public Decimal QUANTITY;
        public String PO_UNIT;
        public String WERKS;
        public String LGORT;
    }

}