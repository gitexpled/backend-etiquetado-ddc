﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_20036
    {
        public responce_ZMOV_20036 sapRun(request_ZMOV_20036 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_20036");

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
            datos_ZMOV_ST_HEADER.SetValue("ALMACEN_CONSUMO", import.HEADER.ALMACEN_CONSUMO);
            rfcFunction.SetValue("HEADER", datos_ZMOV_ST_HEADER);
            RfcStructureMetadata obj_ZMOV_ST_HEADER_ADIC_LIST = SapRfcRepository.GetStructureMetadata("ZMOV_ST_HEADER_ADIC_LIST");
            IRfcStructure datos_ZMOV_ST_HEADER_ADIC_LIST = obj_ZMOV_ST_HEADER_ADIC_LIST.CreateStructure();
            datos_ZMOV_ST_HEADER_ADIC_LIST.SetValue("STLAL", import.HEADER_ADIC.STLAL);
            datos_ZMOV_ST_HEADER_ADIC_LIST.SetValue("EXTWG", import.HEADER_ADIC.EXTWG);
            datos_ZMOV_ST_HEADER_ADIC_LIST.SetValue("ZVARIEDAD", import.HEADER_ADIC.ZVARIEDAD);
            datos_ZMOV_ST_HEADER_ADIC_LIST.SetValue("TIP_PACKING", import.HEADER_ADIC.TIP_PACKING);
            datos_ZMOV_ST_HEADER_ADIC_LIST.SetValue("PALLET_COMPLE", import.HEADER_ADIC.PALLET_COMPLE);
            datos_ZMOV_ST_HEADER_ADIC_LIST.SetValue("TRASP_COMPL", import.HEADER_ADIC.TRASP_COMPL);
            datos_ZMOV_ST_HEADER_ADIC_LIST.SetValue("LGORT_TRASP", import.HEADER_ADIC.LGORT_TRASP);
            datos_ZMOV_ST_HEADER_ADIC_LIST.SetValue("STLAL_PALLET", import.HEADER_ADIC.STLAL_PALLET);
            rfcFunction.SetValue("HEADER_ADIC", datos_ZMOV_ST_HEADER_ADIC_LIST);
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
            //rfcFunction.SetValue("IR_MTART_NOT_541", import.IR_MTART_NOT_541);
            IRfcTable rfcTable_IR_MTART_NOT_541_I = rfcFunction.GetTable("IR_MTART_NOT_541");
            foreach (ZMOV_20036_IR_MTART_NOT_541 row in import.IR_MTART_NOT_541)
            {
                rfcTable_IR_MTART_NOT_541_I.Append();
                ZMOV_20036_IR_MTART_NOT_541 datoTabla = new ZMOV_20036_IR_MTART_NOT_541();
                rfcTable_IR_MTART_NOT_541_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_MTART_NOT_541_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_MTART_NOT_541_I.SetValue("LOW", row.LOW);
                rfcTable_IR_MTART_NOT_541_I.SetValue("HIGH", row.HIGH);
            }
            IRfcTable rfcTable_LT_CARACT_I = rfcFunction.GetTable("LT_CARACT");
            foreach (ZMOV_20036_LT_CARACT row in import.LT_CARACT)
            {
                rfcTable_LT_CARACT_I.Append();
                ZMOV_20036_LT_CARACT datoTabla = new ZMOV_20036_LT_CARACT();
                rfcTable_LT_CARACT_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_LT_CARACT_I.SetValue("BATCH", row.BATCH);
                rfcTable_LT_CARACT_I.SetValue("CHARACT", row.CHARACT);
                rfcTable_LT_CARACT_I.SetValue("VALUE_CHAR", row.VALUE_CHAR);
            }
            IRfcTable rfcTable_LT_ITEMS_I = rfcFunction.GetTable("LT_ITEMS");
            foreach (ZMOV_20036_LT_ITEMS row in import.LT_ITEMS)
            {
                rfcTable_LT_ITEMS_I.Append();
                ZMOV_20036_LT_ITEMS datoTabla = new ZMOV_20036_LT_ITEMS();
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
            IRfcTable rfcTable_LT_ITEM_DEST_I = rfcFunction.GetTable("LT_ITEM_DEST");
            foreach (ZMOV_20036_LT_ITEM_DEST row in import.LT_ITEM_DEST)
            {
                rfcTable_LT_ITEM_DEST_I.Append();
                ZMOV_20036_LT_ITEM_DEST datoTabla = new ZMOV_20036_LT_ITEM_DEST();
                rfcTable_LT_ITEM_DEST_I.SetValue("LFPOS", row.LFPOS);
                rfcTable_LT_ITEM_DEST_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_LT_ITEM_DEST_I.SetValue("QUANTITY", row.QUANTITY);
                rfcTable_LT_ITEM_DEST_I.SetValue("PO_UNIT", row.PO_UNIT);
                rfcTable_LT_ITEM_DEST_I.SetValue("WERKS", row.WERKS);
                rfcTable_LT_ITEM_DEST_I.SetValue("LGORT", row.LGORT);
            }
            IRfcTable rfcTable_LT_MATNR_PALLET_I = rfcFunction.GetTable("LT_MATNR_PALLET");
            foreach (ZMOV_20036_LT_MATNR_PALLET row in import.LT_MATNR_PALLET)
            {
                rfcTable_LT_MATNR_PALLET_I.Append();
                ZMOV_20036_LT_MATNR_PALLET datoTabla = new ZMOV_20036_LT_MATNR_PALLET();
                rfcTable_LT_MATNR_PALLET_I.SetValue("MATNR", row.MATNR);
            }
            IRfcTable rfcTable_LOG_I = rfcFunction.GetTable("LOG");
            foreach (ZMOV_20036_LOG row in import.LOG)
            {
                rfcTable_LOG_I.Append();
                ZMOV_20036_LOG datoTabla = new ZMOV_20036_LOG();
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

          

            rfcFunction.SetValue("LT_MATNR_PALLET", rfcTable_LT_MATNR_PALLET_I);
            rfcFunction.SetValue("LT_ITEM_DEST", rfcTable_LT_ITEM_DEST_I);
            rfcFunction.SetValue("LT_ITEMS", rfcTable_LT_ITEMS_I);
            rfcFunction.SetValue("LT_CARACT", rfcTable_LT_CARACT_I);
            rfcFunction.SetValue("IR_MTART_NOT_541", rfcTable_IR_MTART_NOT_541_I);
            rfcFunction.SetValue("I_COPEQUEN", import.I_COPEQUEN);
            rfcFunction.SetValue("I_UAT", import.I_UAT);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_20036 res = new responce_ZMOV_20036();
            res.E_EXIDV = rfcFunction.GetString("E_EXIDV");
            res.E_MATDOC_COS = rfcFunction.GetString("E_MATDOC_COS");
            res.E_MATDOC_FRU = rfcFunction.GetString("E_MATDOC_FRU");
            res.E_MATDOC_TRA = rfcFunction.GetString("E_MATDOC_TRA");
            res.E_MATERIALDOCUMENT = rfcFunction.GetString("E_MATERIALDOCUMENT");
            res.E_MATERIALDOCUMENT_PALLET = rfcFunction.GetString("E_MATERIALDOCUMENT_PALLET");
            res.E_MBLNR_311_PALLET = rfcFunction.GetString("E_MBLNR_311_PALLET");
            res.E_MBLNR_541 = rfcFunction.GetString("E_MBLNR_541");
            res.E_MBLNR_541_PALLET = rfcFunction.GetString("E_MBLNR_541_PALLET");
            res.MATERIALDOCUMENT = rfcFunction.GetString("MATERIALDOCUMENT");
            res.MATERIALDOCUMENT_BD = rfcFunction.GetString("MATERIALDOCUMENT_BD");
            res.PEDIDO = rfcFunction.GetString("PEDIDO");
            res.PEDIDO_PALLET = rfcFunction.GetString("PEDIDO_PALLET");
            IRfcTable rfcTable_IR_MTART_NOT_541 = rfcFunction.GetTable("IR_MTART_NOT_541");
            res.IR_MTART_NOT_541 = new ZMOV_20036_IR_MTART_NOT_541[rfcTable_IR_MTART_NOT_541.RowCount];
            int i_IR_MTART_NOT_541 = 0;
            foreach (IRfcStructure row in rfcTable_IR_MTART_NOT_541)
            {
                ZMOV_20036_IR_MTART_NOT_541 datoTabla = new ZMOV_20036_IR_MTART_NOT_541();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MTART_NOT_541[i_IR_MTART_NOT_541] = datoTabla; ++i_IR_MTART_NOT_541;
            }
            IRfcTable rfcTable_LOG = rfcFunction.GetTable("LOG");
            res.LOG = new ZMOV_20036_LOG[rfcTable_LOG.RowCount];
            int i_LOG = 0;
            foreach (IRfcStructure row in rfcTable_LOG)
            {
                ZMOV_20036_LOG datoTabla = new ZMOV_20036_LOG();
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
            

            IRfcTable rfcTable_LT_LOG_MAT_STOCK = rfcFunction.GetTable("LT_LOG_MAT_STOCK");
            res.LT_LOG_MAT_STOCK = new ZMOV_20036_LT_LOG_MAT_STOCK[rfcTable_LT_LOG_MAT_STOCK.RowCount];
            int i_LT_LOG_MAT_STOCK = 0;
            foreach (IRfcStructure row in rfcTable_LT_LOG_MAT_STOCK)
            {
                ZMOV_20036_LT_LOG_MAT_STOCK datoTabla = new ZMOV_20036_LT_LOG_MAT_STOCK();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.CANTIDAD = row.GetDecimal("CANTIDAD");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.MESSAGE = row.GetString("MESSAGE");
                res.LT_LOG_MAT_STOCK[i_LT_LOG_MAT_STOCK] = datoTabla; ++i_LT_LOG_MAT_STOCK;
            }

            IRfcTable rfcTable_LT_CARACT = rfcFunction.GetTable("LT_CARACT");
            res.LT_CARACT = new ZMOV_20036_LT_CARACT[rfcTable_LT_CARACT.RowCount];
            int i_LT_CARACT = 0;
            foreach (IRfcStructure row in rfcTable_LT_CARACT)
            {
                ZMOV_20036_LT_CARACT datoTabla = new ZMOV_20036_LT_CARACT();
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.CHARACT = row.GetString("CHARACT");
                datoTabla.VALUE_CHAR = row.GetString("VALUE_CHAR");
                res.LT_CARACT[i_LT_CARACT] = datoTabla; ++i_LT_CARACT;
            }
            IRfcTable rfcTable_LT_ITEMS = rfcFunction.GetTable("LT_ITEMS");
            res.LT_ITEMS = new ZMOV_20036_LT_ITEMS[rfcTable_LT_ITEMS.RowCount];
            int i_LT_ITEMS = 0;
            foreach (IRfcStructure row in rfcTable_LT_ITEMS)
            {
                ZMOV_20036_LT_ITEMS datoTabla = new ZMOV_20036_LT_ITEMS();
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
            res.LT_ITEM_DEST = new ZMOV_20036_LT_ITEM_DEST[rfcTable_LT_ITEM_DEST.RowCount];
            int i_LT_ITEM_DEST = 0;
            foreach (IRfcStructure row in rfcTable_LT_ITEM_DEST)
            {
                ZMOV_20036_LT_ITEM_DEST datoTabla = new ZMOV_20036_LT_ITEM_DEST();
                datoTabla.LFPOS = row.GetInt("LFPOS");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                res.LT_ITEM_DEST[i_LT_ITEM_DEST] = datoTabla; ++i_LT_ITEM_DEST;
            }
            IRfcTable rfcTable_LT_MATNR_PALLET = rfcFunction.GetTable("LT_MATNR_PALLET");
            res.LT_MATNR_PALLET = new ZMOV_20036_LT_MATNR_PALLET[rfcTable_LT_MATNR_PALLET.RowCount];
            int i_LT_MATNR_PALLET = 0;
            foreach (IRfcStructure row in rfcTable_LT_MATNR_PALLET)
            {
                ZMOV_20036_LT_MATNR_PALLET datoTabla = new ZMOV_20036_LT_MATNR_PALLET();
                datoTabla.MATNR = row.GetString("MATNR");
                res.LT_MATNR_PALLET[i_LT_MATNR_PALLET] = datoTabla; ++i_LT_MATNR_PALLET;
            }

            return res;
        }
    }
    public class request_ZMOV_20036
    {
        public ZMOV_20036_HEADER HEADER;
        public ZMOV_20036_HEADER_ADIC HEADER_ADIC;
        public ZMOV_20036_HEADER_HU HEADER_HU;
        //public String IR_MTART_NOT_541;
        public ZMOV_20036_IR_MTART_NOT_541[] IR_MTART_NOT_541;
        public ZMOV_20036_LT_CARACT[] LT_CARACT;
        public ZMOV_20036_LT_ITEMS[] LT_ITEMS;
        public ZMOV_20036_LT_ITEM_DEST[] LT_ITEM_DEST;
        public ZMOV_20036_LT_MATNR_PALLET[] LT_MATNR_PALLET;
        public String I_COPEQUEN;
        public String I_UAT;
        public ZMOV_20036_LOG[] LOG;
    }
    public class responce_ZMOV_20036
    {
        public String E_EXIDV;
        public String E_MATDOC_COS;
        public String E_MATDOC_FRU;
        public String E_MATDOC_TRA;
        public String E_MATERIALDOCUMENT;
        public String E_MATERIALDOCUMENT_PALLET;
        public String E_MBLNR_311_PALLET;
        public String E_MBLNR_541;
        public String E_MBLNR_541_PALLET;
        public String MATERIALDOCUMENT;
        public String MATERIALDOCUMENT_BD;
        public String PEDIDO;
        public String PEDIDO_PALLET;
        public ZMOV_20036_IR_MTART_NOT_541[] IR_MTART_NOT_541;
        public ZMOV_20036_LOG[] LOG;
        public ZMOV_20036_LT_LOG_MAT_STOCK[] LT_LOG_MAT_STOCK;
        public ZMOV_20036_LT_CARACT[] LT_CARACT;
        public ZMOV_20036_LT_ITEMS[] LT_ITEMS;
        public ZMOV_20036_LT_ITEM_DEST[] LT_ITEM_DEST;
        public ZMOV_20036_LT_MATNR_PALLET[] LT_MATNR_PALLET;
    }
    public class ZMOV_20036_HEADER
    {
        public String BUKRS;
        public String EKORG;
        public String EKGRP;
        public String BSART;
        public String BUDAT;
        public String LIFNR;
        public String XBLNR;
        public String BKTXT;
        public String ALMACEN_CONSUMO;
    }
    public class ZMOV_20036_HEADER_ADIC
    {
        public String STLAL;
        public String EXTWG;
        public String ZVARIEDAD;
        public String TIP_PACKING;
        public String PALLET_COMPLE;
        public String TRASP_COMPL;
        public String LGORT_TRASP;
        public String STLAL_PALLET;
    }
    public class ZMOV_20036_HEADER_HU
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
    public class ZMOV_20036_IR_MTART_NOT_541
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_20036_LOG
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

    public class ZMOV_20036_LT_LOG_MAT_STOCK
    {
        public String MATNR;
        public Decimal CANTIDAD;
        public String MEINS;
        public String WERKS;
        public String LGORT;
        public String MESSAGE;
    }

    public class ZMOV_20036_LT_CARACT
    {
        public String MATERIAL;
        public String BATCH;
        public String CHARACT;
        public String VALUE_CHAR;
    }
    public class ZMOV_20036_LT_ITEMS
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
    public class ZMOV_20036_LT_ITEM_DEST
    {
        public Int32 LFPOS;
        public String MATERIAL;
        public Decimal QUANTITY;
        public String PO_UNIT;
        public String WERKS;
        public String LGORT;
    }
    public class ZMOV_20036_LT_MATNR_PALLET
    {
        public String MATNR;
    }

}