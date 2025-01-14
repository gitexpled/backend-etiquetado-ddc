﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_CREATE_RECEP_NCC
    {
        public responce_ZMOV_CREATE_RECEP_NCC sapRun(request_ZMOV_CREATE_RECEP_NCC import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("PRO_router");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_CREATE_RECEP_NCC");

            RfcStructureMetadata obj_ZMOV_ST_HEADER_NCC = SapRfcRepository.GetStructureMetadata("ZMOV_ST_HEADER_NCC");
            IRfcStructure datos_ZMOV_ST_HEADER_NCC = obj_ZMOV_ST_HEADER_NCC.CreateStructure();
            datos_ZMOV_ST_HEADER_NCC.SetValue("BUKRS", import.HEADER.BUKRS);
            datos_ZMOV_ST_HEADER_NCC.SetValue("EKORG", import.HEADER.EKORG);
            datos_ZMOV_ST_HEADER_NCC.SetValue("EKGRP", import.HEADER.EKGRP);
            datos_ZMOV_ST_HEADER_NCC.SetValue("BSART", import.HEADER.BSART);
            datos_ZMOV_ST_HEADER_NCC.SetValue("BUDAT", import.HEADER.BUDAT);
            datos_ZMOV_ST_HEADER_NCC.SetValue("LIFNR", import.HEADER.LIFNR);
            datos_ZMOV_ST_HEADER_NCC.SetValue("XBLNR", import.HEADER.XBLNR);
            datos_ZMOV_ST_HEADER_NCC.SetValue("BKTXT", import.HEADER.BKTXT);
            datos_ZMOV_ST_HEADER_NCC.SetValue("ZNUEZ_VARIEDAD", import.HEADER.ZNUEZ_VARIEDAD);
            datos_ZMOV_ST_HEADER_NCC.SetValue("ZNUEZ_EST_FUMIGADO", import.HEADER.ZNUEZ_EST_FUMIGADO);
            datos_ZMOV_ST_HEADER_NCC.SetValue("ZNUEZ_CUARTEL", import.HEADER.ZNUEZ_CUARTEL);
            rfcFunction.SetValue("HEADER", datos_ZMOV_ST_HEADER_NCC);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_CREATE_RECEP_NCC res = new responce_ZMOV_CREATE_RECEP_NCC();
            res.MATERIALDOCUMENT = rfcFunction.GetString("MATERIALDOCUMENT");
            res.MATERIALDOCUMENT_BD = rfcFunction.GetString("MATERIALDOCUMENT_BD");
            res.PEDIDO = rfcFunction.GetString("PEDIDO");
            IRfcTable rfcTable_ITEM_DEST = rfcFunction.GetTable("ITEM_DEST");
            res.ITEM_DEST = new ZMOV_CREATE_RECEP_NCC_ITEM_DEST[rfcTable_ITEM_DEST.RowCount];
            int i_ITEM_DEST = 0;
            foreach (IRfcStructure row in rfcTable_ITEM_DEST)
            {
                ZMOV_CREATE_RECEP_NCC_ITEM_DEST datoTabla = new ZMOV_CREATE_RECEP_NCC_ITEM_DEST();
                datoTabla.LFPOS = row.GetInt("LFPOS");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                res.ITEM_DEST[i_ITEM_DEST] = datoTabla; ++i_ITEM_DEST;
            }
            IRfcTable rfcTable_ITEM_NCC = rfcFunction.GetTable("ITEM_NCC");
            res.ITEM_NCC = new ZMOV_CREATE_RECEP_NCC_ITEM_NCC[rfcTable_ITEM_NCC.RowCount];
            int i_ITEM_NCC = 0;
            foreach (IRfcStructure row in rfcTable_ITEM_NCC)
            {
                ZMOV_CREATE_RECEP_NCC_ITEM_NCC datoTabla = new ZMOV_CREATE_RECEP_NCC_ITEM_NCC();
                datoTabla.STCK_TYPE = row.GetString("STCK_TYPE");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.ZNUEZ_CATEGORIA = row.GetString("ZNUEZ_CATEGORIA");
                datoTabla.FREE_ITEM = row.GetString("FREE_ITEM");
                res.ITEM_NCC[i_ITEM_NCC] = datoTabla; ++i_ITEM_NCC;
            }
            /*IRfcTable rfcTable_RETURN_DEST = rfcFunction.GetTable("RETURN_DEST");
            res.RETURN_DEST = new ZMOV_CREATE_RECEP_NCC_RETURN_DEST[rfcTable_RETURN_DEST.RowCount];
            int i_RETURN_DEST = 0;
            foreach (IRfcStructure row in rfcTable_RETURN_DEST)
            {
                ZMOV_CREATE_RECEP_NCC_RETURN_DEST datoTabla = new ZMOV_CREATE_RECEP_NCC_RETURN_DEST();
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
                res.RETURN_DEST[i_RETURN_DEST] = datoTabla; ++i_RETURN_DEST;
            }
            IRfcTable rfcTable_RETURN_NCC = rfcFunction.GetTable("RETURN_NCC");
            res.RETURN_NCC = new ZMOV_CREATE_RECEP_NCC_RETURN_NCC[rfcTable_RETURN_NCC.RowCount];
            int i_RETURN_NCC = 0;
            foreach (IRfcStructure row in rfcTable_RETURN_NCC)
            {
                ZMOV_CREATE_RECEP_NCC_RETURN_NCC datoTabla = new ZMOV_CREATE_RECEP_NCC_RETURN_NCC();
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
                res.RETURN_NCC[i_RETURN_NCC] = datoTabla; ++i_RETURN_NCC;
            }
            IRfcTable rfcTable_RETURN_PO = rfcFunction.GetTable("RETURN_PO");
            res.RETURN_PO = new ZMOV_CREATE_RECEP_NCC_RETURN_PO[rfcTable_RETURN_PO.RowCount];
            int i_RETURN_PO = 0;
            foreach (IRfcStructure row in rfcTable_RETURN_PO)
            {
                ZMOV_CREATE_RECEP_NCC_RETURN_PO datoTabla = new ZMOV_CREATE_RECEP_NCC_RETURN_PO();
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
                res.RETURN_PO[i_RETURN_PO] = datoTabla; ++i_RETURN_PO;
            }*/

            return res;
        }
    }
    public class request_ZMOV_CREATE_RECEP_NCC
    {
        public ZMOV_CREATE_RECEP_NCC_HEADER HEADER;
    }
    public class responce_ZMOV_CREATE_RECEP_NCC
    {
        public String MATERIALDOCUMENT;
        public String MATERIALDOCUMENT_BD;
        public String PEDIDO;
        public ZMOV_CREATE_RECEP_NCC_ITEM_DEST[] ITEM_DEST;
        public ZMOV_CREATE_RECEP_NCC_ITEM_NCC[] ITEM_NCC;
        public ZMOV_CREATE_RECEP_NCC_RETURN_DEST[] RETURN_DEST;
        public ZMOV_CREATE_RECEP_NCC_RETURN_NCC[] RETURN_NCC;
        public ZMOV_CREATE_RECEP_NCC_RETURN_PO[] RETURN_PO;
    }
    public class ZMOV_CREATE_RECEP_NCC_HEADER
    {
        public String BUKRS;
        public String EKORG;
        public String EKGRP;
        public String BSART;
        public String BUDAT;
        public String LIFNR;
        public String XBLNR;
        public String BKTXT;
        public String ZNUEZ_VARIEDAD;
        public String ZNUEZ_EST_FUMIGADO;
        public String ZNUEZ_CUARTEL;
    }
    public class ZMOV_CREATE_RECEP_NCC_ITEM_DEST
    {
        public Int32 LFPOS;
        public String MATERIAL;
        public Decimal QUANTITY;
        public String PO_UNIT;
        public String WERKS;
        public String LGORT;
    }
    public class ZMOV_CREATE_RECEP_NCC_ITEM_NCC
    {
        public String STCK_TYPE;
        public String MATERIAL;
        public String BATCH;
        public Decimal QUANTITY;
        public String PO_UNIT;
        public String HSDAT;
        public String PLANT;
        public String STGE_LOC;
        public String ZNUEZ_CATEGORIA;
        public String FREE_ITEM;
    }
    public class ZMOV_CREATE_RECEP_NCC_RETURN_DEST
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
    public class ZMOV_CREATE_RECEP_NCC_RETURN_NCC
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
    public class ZMOV_CREATE_RECEP_NCC_RETURN_PO
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