using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_20032
    {
        public responce_ZMOV_20032 sapRun(request_ZMOV_20032 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_20032");

            rfcFunction.SetValue("ALMACEN_HU", import.ALMACEN_HU);
            rfcFunction.SetValue("CENTRO_HU", import.CENTRO_HU);
           // rfcFunction.SetValue("EXIDV_HU", import.EXIDV_HU);
            //rfcFunction.SetValue("EXIDV_HU", import.EXIDV_HU);
            IRfcTable rfcTable_EXIDV_HU_I = rfcFunction.GetTable("EXIDV_HU");
            foreach (ZMOV_20032_EXIDV_HU row in import.EXIDV_HU)
            {
                rfcTable_EXIDV_HU_I.Append();
                ZMOV_20032_EXIDV_HU datoTabla = new ZMOV_20032_EXIDV_HU();
                rfcTable_EXIDV_HU_I.SetValue("EXIDV", row.EXIDV.PadLeft(20,'0'));
            }
            rfcFunction.SetValue("EXIDV_HU", rfcTable_EXIDV_HU_I);
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
            RfcStructureMetadata obj_ZMOV_ST_HEADER_ADIC_LIS_PALLET = SapRfcRepository.GetStructureMetadata("ZMOV_ST_HEADER_ADIC_LIS_PALLET");
            IRfcStructure datos_ZMOV_ST_HEADER_ADIC_LIS_PALLET = obj_ZMOV_ST_HEADER_ADIC_LIS_PALLET.CreateStructure();
            datos_ZMOV_ST_HEADER_ADIC_LIS_PALLET.SetValue("TIP_PACKING", import.HEADER_ADIC.TIP_PACKING);
            datos_ZMOV_ST_HEADER_ADIC_LIS_PALLET.SetValue("LGORT_TRASP", import.HEADER_ADIC.LGORT_TRASP);
            datos_ZMOV_ST_HEADER_ADIC_LIS_PALLET.SetValue("STLAL_PALLET", import.HEADER_ADIC.STLAL_PALLET);
            datos_ZMOV_ST_HEADER_ADIC_LIS_PALLET.SetValue("CONSUMOPALLET", import.HEADER_ADIC.CONSUMOPALLET);
            rfcFunction.SetValue("HEADER_ADIC", datos_ZMOV_ST_HEADER_ADIC_LIS_PALLET);
            IRfcTable rfcTable_LT_ITEMS_I = rfcFunction.GetTable("LT_ITEMS");
            foreach (ZMOV_20032_LT_ITEMS row in import.LT_ITEMS)
            {
                rfcTable_LT_ITEMS_I.Append();
                ZMOV_20032_LT_ITEMS datoTabla = new ZMOV_20032_LT_ITEMS();
                rfcTable_LT_ITEMS_I.SetValue("STCK_TYPE", row.STCK_TYPE);
                rfcTable_LT_ITEMS_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_LT_ITEMS_I.SetValue("QUANTITY", row.QUANTITY);
                rfcTable_LT_ITEMS_I.SetValue("PO_UNIT", row.PO_UNIT);
                rfcTable_LT_ITEMS_I.SetValue("HSDAT", row.HSDAT);
                rfcTable_LT_ITEMS_I.SetValue("PLANT", row.PLANT);
                rfcTable_LT_ITEMS_I.SetValue("STGE_LOC", row.STGE_LOC);
                rfcTable_LT_ITEMS_I.SetValue("FREE_ITEM", row.FREE_ITEM);
                rfcTable_LT_ITEMS_I.SetValue("ITEM_CAT", row.ITEM_CAT);
                rfcTable_LT_ITEMS_I.SetValue("ACCTASSCAT", row.ACCTASSCAT);
                rfcTable_LT_ITEMS_I.SetValue("ALMAC_TRASP", row.ALMAC_TRASP);
            }
            IRfcTable rfcTable_LT_MATNR_PALLET_I = rfcFunction.GetTable("LT_MATNR_PALLET");
            foreach (ZMOV_20032_LT_MATNR_PALLET row in import.LT_MATNR_PALLET)
            {
                rfcTable_LT_MATNR_PALLET_I.Append();
                ZMOV_20032_LT_MATNR_PALLET datoTabla = new ZMOV_20032_LT_MATNR_PALLET();
                rfcTable_LT_MATNR_PALLET_I.SetValue("MATNR", row.MATNR);
            }
            IRfcTable rfcTable_LT_LOG_I = rfcFunction.GetTable("LT_LOG");
            foreach (ZMOV_20032_LT_LOG row in import.LT_LOG)
            {
                rfcTable_LT_LOG_I.Append();
                ZMOV_20032_LT_LOG datoTabla = new ZMOV_20032_LT_LOG();
                rfcTable_LT_LOG_I.SetValue("TYPE", row.TYPE);
                rfcTable_LT_LOG_I.SetValue("ID", row.ID);
                rfcTable_LT_LOG_I.SetValue("NUMBER", row.NUMBER);
                rfcTable_LT_LOG_I.SetValue("MESSAGE", row.MESSAGE);
                rfcTable_LT_LOG_I.SetValue("LOG_NO", row.LOG_NO);
                rfcTable_LT_LOG_I.SetValue("LOG_MSG_NO", row.LOG_MSG_NO);
                rfcTable_LT_LOG_I.SetValue("MESSAGE_V1", row.MESSAGE_V1);
                rfcTable_LT_LOG_I.SetValue("MESSAGE_V2", row.MESSAGE_V2);
                rfcTable_LT_LOG_I.SetValue("MESSAGE_V3", row.MESSAGE_V3);
                rfcTable_LT_LOG_I.SetValue("MESSAGE_V4", row.MESSAGE_V4);
                rfcTable_LT_LOG_I.SetValue("PARAMETER", row.PARAMETER);
                rfcTable_LT_LOG_I.SetValue("ROW", row.ROW);
                rfcTable_LT_LOG_I.SetValue("FIELD", row.FIELD);
                rfcTable_LT_LOG_I.SetValue("SYSTEM", row.SYSTEM);
            }
            IRfcTable rfcTable_LT_LOG_HU_I = rfcFunction.GetTable("LT_LOG_HU");
            foreach (ZMOV_20032_LT_LOG_HU row in import.LT_LOG_HU)
            {
                rfcTable_LT_LOG_HU_I.Append();
                ZMOV_20032_LT_LOG_HU datoTabla = new ZMOV_20032_LT_LOG_HU();
                rfcTable_LT_LOG_HU_I.SetValue("EXIDV", row.EXIDV.PadLeft(20,'0'));
                rfcTable_LT_LOG_HU_I.SetValue("POSNR", row.POSNR);
                rfcTable_LT_LOG_HU_I.SetValue("HU_ITEM", row.HU_ITEM);
                rfcTable_LT_LOG_HU_I.SetValue("ZEILE", row.ZEILE);
                rfcTable_LT_LOG_HU_I.SetValue("MSGID", row.MSGID);
                rfcTable_LT_LOG_HU_I.SetValue("MSGTY", row.MSGTY);
                rfcTable_LT_LOG_HU_I.SetValue("MSGNO", row.MSGNO);
                rfcTable_LT_LOG_HU_I.SetValue("MSGV1", row.MSGV1);
                rfcTable_LT_LOG_HU_I.SetValue("MSGV2", row.MSGV2);
                rfcTable_LT_LOG_HU_I.SetValue("MSGV3", row.MSGV3);
                rfcTable_LT_LOG_HU_I.SetValue("MSGV4", row.MSGV4);
            }
            rfcFunction.SetValue("LT_LOG_HU", rfcTable_LT_LOG_HU_I);
            rfcFunction.SetValue("LT_LOG", rfcTable_LT_LOG_I);
            rfcFunction.SetValue("LT_MATNR_PALLET", rfcTable_LT_MATNR_PALLET_I);
            rfcFunction.SetValue("LT_ITEMS", rfcTable_LT_ITEMS_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_20032 res = new responce_ZMOV_20032();
            res.E_MATERIALDOCUMENT_PALLET = rfcFunction.GetString("E_MATERIALDOCUMENT_PALLET");
            res.E_MBLNR_311_PALLET = rfcFunction.GetString("E_MBLNR_311_PALLET");
            res.E_MBLNR_541_PALLET = rfcFunction.GetString("E_MBLNR_541_PALLET");
            res.PEDIDO_PALLET = rfcFunction.GetString("PEDIDO_PALLET");
            IRfcTable rfcTable_EXIDV_HU = rfcFunction.GetTable("EXIDV_HU");
            res.EXIDV_HU = new ZMOV_20032_EXIDV_HU[rfcTable_EXIDV_HU.RowCount];
            int i_EXIDV_HU = 0;
            foreach (IRfcStructure row in rfcTable_EXIDV_HU)
            {
                ZMOV_20032_EXIDV_HU datoTabla = new ZMOV_20032_EXIDV_HU();
                datoTabla.EXIDV = row.GetString("EXIDV");
                res.EXIDV_HU[i_EXIDV_HU] = datoTabla; ++i_EXIDV_HU;
            }
            IRfcTable rfcTable_LT_ITEMS = rfcFunction.GetTable("LT_ITEMS");
            res.LT_ITEMS = new ZMOV_20032_LT_ITEMS[rfcTable_LT_ITEMS.RowCount];
            int i_LT_ITEMS = 0;
            foreach (IRfcStructure row in rfcTable_LT_ITEMS)
            {
                ZMOV_20032_LT_ITEMS datoTabla = new ZMOV_20032_LT_ITEMS();
                datoTabla.STCK_TYPE = row.GetString("STCK_TYPE");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.FREE_ITEM = row.GetString("FREE_ITEM");
                datoTabla.ITEM_CAT = row.GetString("ITEM_CAT");
                datoTabla.ACCTASSCAT = row.GetString("ACCTASSCAT");
                datoTabla.ALMAC_TRASP = row.GetString("ALMAC_TRASP");
                res.LT_ITEMS[i_LT_ITEMS] = datoTabla; ++i_LT_ITEMS;
            }
            IRfcTable rfcTable_LT_LOG = rfcFunction.GetTable("LT_LOG");
            res.LT_LOG = new ZMOV_20032_LT_LOG[rfcTable_LT_LOG.RowCount];
            int i_LT_LOG = 0;
            foreach (IRfcStructure row in rfcTable_LT_LOG)
            {
                ZMOV_20032_LT_LOG datoTabla = new ZMOV_20032_LT_LOG();
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
                res.LT_LOG[i_LT_LOG] = datoTabla; ++i_LT_LOG;
            }
            IRfcTable rfcTable_LT_LOG_HU = rfcFunction.GetTable("LT_LOG_HU");
            res.LT_LOG_HU = new ZMOV_20032_LT_LOG_HU[rfcTable_LT_LOG_HU.RowCount];
            int i_LT_LOG_HU = 0;
            foreach (IRfcStructure row in rfcTable_LT_LOG_HU)
            {
                ZMOV_20032_LT_LOG_HU datoTabla = new ZMOV_20032_LT_LOG_HU();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.POSNR = row.GetInt("POSNR");
                datoTabla.HU_ITEM = row.GetString("HU_ITEM");
                datoTabla.ZEILE = row.GetInt("ZEILE");
                datoTabla.MSGID = row.GetString("MSGID");
                datoTabla.MSGTY = row.GetString("MSGTY");
                datoTabla.MSGNO = row.GetInt("MSGNO");
                datoTabla.MSGV1 = row.GetString("MSGV1");
                datoTabla.MSGV2 = row.GetString("MSGV2");
                datoTabla.MSGV3 = row.GetString("MSGV3");
                datoTabla.MSGV4 = row.GetString("MSGV4");
                res.LT_LOG_HU[i_LT_LOG_HU] = datoTabla; ++i_LT_LOG_HU;
            }
            IRfcTable rfcTable_LT_MATNR_PALLET = rfcFunction.GetTable("LT_MATNR_PALLET");
            res.LT_MATNR_PALLET = new ZMOV_20032_LT_MATNR_PALLET[rfcTable_LT_MATNR_PALLET.RowCount];
            int i_LT_MATNR_PALLET = 0;
            foreach (IRfcStructure row in rfcTable_LT_MATNR_PALLET)
            {
                ZMOV_20032_LT_MATNR_PALLET datoTabla = new ZMOV_20032_LT_MATNR_PALLET();
                datoTabla.MATNR = row.GetString("MATNR");
                res.LT_MATNR_PALLET[i_LT_MATNR_PALLET] = datoTabla; ++i_LT_MATNR_PALLET;
            }

            return res;
        }
    }
    public class request_ZMOV_20032
    {
        public String ALMACEN_HU;
        public String CENTRO_HU;
        public ZMOV_20032_EXIDV_HU[] EXIDV_HU;
        //public String EXIDV_HU;
        public ZMOV_20032_HEADER HEADER;
        public ZMOV_20032_HEADER_ADIC HEADER_ADIC;
        public ZMOV_20032_LT_ITEMS[] LT_ITEMS;
        public ZMOV_20032_LT_LOG[] LT_LOG;
        public ZMOV_20032_LT_LOG_HU[] LT_LOG_HU;
        public ZMOV_20032_LT_MATNR_PALLET[] LT_MATNR_PALLET;
    }
    public class responce_ZMOV_20032
    {
        public String E_MATERIALDOCUMENT_PALLET;
        public String E_MBLNR_311_PALLET;
        public String E_MBLNR_541_PALLET;
        public String PEDIDO_PALLET;
        public ZMOV_20032_EXIDV_HU[] EXIDV_HU;
        public ZMOV_20032_LT_ITEMS[] LT_ITEMS;
        public ZMOV_20032_LT_LOG[] LT_LOG;
        public ZMOV_20032_LT_LOG_HU[] LT_LOG_HU;
        public ZMOV_20032_LT_MATNR_PALLET[] LT_MATNR_PALLET;
    }
    public class ZMOV_20032_HEADER
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
    public class ZMOV_20032_HEADER_ADIC
    {
        public String TIP_PACKING;
        public String LGORT_TRASP;
        public String STLAL_PALLET;
        public String CONSUMOPALLET;
    }
    public class ZMOV_20032_EXIDV_HU
    {
        public String EXIDV;
    }
    public class ZMOV_20032_LT_ITEMS
    {
        public String STCK_TYPE;
        public String MATERIAL;
        public Decimal QUANTITY;
        public String PO_UNIT;
        public String HSDAT;
        public String PLANT;
        public String STGE_LOC;
        public String FREE_ITEM;
        public String ITEM_CAT;
        public String ACCTASSCAT;
        public String ALMAC_TRASP;
    }
    public class ZMOV_20032_LT_LOG
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
    public class ZMOV_20032_LT_LOG_HU
    {
        public String EXIDV;
        public Int32 POSNR;
        public String HU_ITEM;
        public Int32 ZEILE;
        public String MSGID;
        public String MSGTY;
        public Int32 MSGNO;
        public String MSGV1;
        public String MSGV2;
        public String MSGV3;
        public String MSGV4;
    }
    public class ZMOV_20032_LT_MATNR_PALLET
    {
        public String MATNR;
    }

}