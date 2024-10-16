using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_CREATE_RECEP_GRANEL
    {
        public responce_ZMOV_CREATE_RECEP_GRANEL sapRun(request_ZMOV_CREATE_RECEP_GRANEL import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_CREATE_RECEP_GRANEL");

            RfcStructureMetadata obj_ZMOV_ST_HEADER_GRANEL = SapRfcRepository.GetStructureMetadata("ZMOV_ST_HEADER_GRANEL");
            IRfcStructure datos_ZMOV_ST_HEADER_GRANEL = obj_ZMOV_ST_HEADER_GRANEL.CreateStructure();
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("BUKRS", import.HEADER.BUKRS);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("EKORG", import.HEADER.EKORG);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("EKGRP", import.HEADER.EKGRP);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("BSART", import.HEADER.BSART);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("BUDAT", import.HEADER.BUDAT);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("HSDAT", import.HEADER.HSDAT);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("LIFNR", import.HEADER.LIFNR);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("XBLNR", import.HEADER.XBLNR);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("BKTXT", import.HEADER.BKTXT);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("VARIEDAD", import.HEADER.VARIEDAD);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("LOTE", import.HEADER.LOTE);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("PRODUCTOR", import.HEADER.PRODUCTOR);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("PREDIO", import.HEADER.PREDIO);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("CUARTEL", import.HEADER.CUARTEL);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("ZPATENTE", import.HEADER.ZPATENTE);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("ZCONDUCTOR", import.HEADER.ZCONDUCTOR);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("TRATAMIENTO", import.HEADER.TRATAMIENTO);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("TIPO_FRIO", import.HEADER.TIPO_FRIO);
            datos_ZMOV_ST_HEADER_GRANEL.SetValue("QBINS", import.HEADER.QBINS);
            rfcFunction.SetValue("HEADER", datos_ZMOV_ST_HEADER_GRANEL);
            rfcFunction.SetValue("IV_PEDIDO", import.IV_PEDIDO);
            IRfcTable rfcTable_DESTARE_GRANEL_I = rfcFunction.GetTable("DESTARE_GRANEL");
            foreach (ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL row in import.DESTARE_GRANEL)
            {
                rfcTable_DESTARE_GRANEL_I.Append();
                ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL datoTabla = new ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL();
                rfcTable_DESTARE_GRANEL_I.SetValue("LFPOS", row.LFPOS);
                rfcTable_DESTARE_GRANEL_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_DESTARE_GRANEL_I.SetValue("QUANTITY", row.QUANTITY);
                rfcTable_DESTARE_GRANEL_I.SetValue("PO_UNIT", row.PO_UNIT);
                rfcTable_DESTARE_GRANEL_I.SetValue("WERKS", row.WERKS);
                rfcTable_DESTARE_GRANEL_I.SetValue("LGORT", row.LGORT);
            }
            rfcFunction.SetValue("DESTARE_GRANEL", rfcTable_DESTARE_GRANEL_I);
            IRfcTable rfcTable_ITEM_GRANEL_I = rfcFunction.GetTable("ITEM_GRANEL");
            foreach (ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL row in import.ITEM_GRANEL)
            {
                rfcTable_ITEM_GRANEL_I.Append();
                ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL datoTabla = new ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL();
                rfcTable_ITEM_GRANEL_I.SetValue("STCK_TYPE", row.STCK_TYPE);
                rfcTable_ITEM_GRANEL_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_ITEM_GRANEL_I.SetValue("BATCH", row.BATCH);
                rfcTable_ITEM_GRANEL_I.SetValue("QUANTITY", row.QUANTITY);
                rfcTable_ITEM_GRANEL_I.SetValue("PO_UNIT", row.PO_UNIT);
                rfcTable_ITEM_GRANEL_I.SetValue("HSDAT", row.HSDAT);
                rfcTable_ITEM_GRANEL_I.SetValue("PLANT", row.PLANT);
                rfcTable_ITEM_GRANEL_I.SetValue("STGE_LOC", row.STGE_LOC);
                rfcTable_ITEM_GRANEL_I.SetValue("FREE_ITEM", row.FREE_ITEM);
            }
            rfcFunction.SetValue("ITEM_GRANEL", rfcTable_ITEM_GRANEL_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_CREATE_RECEP_GRANEL res = new responce_ZMOV_CREATE_RECEP_GRANEL();
            res.MATERIALDOCUMENT = rfcFunction.GetString("MATERIALDOCUMENT");
            res.MATERIALDOCUMENT_BD = rfcFunction.GetString("MATERIALDOCUMENT_BD");
            res.PEDIDO = rfcFunction.GetString("PEDIDO");
            IRfcTable rfcTable_DESTARE_GRANEL = rfcFunction.GetTable("DESTARE_GRANEL");
            res.DESTARE_GRANEL = new ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL[rfcTable_DESTARE_GRANEL.RowCount];
            int i_DESTARE_GRANEL = 0;
            foreach (IRfcStructure row in rfcTable_DESTARE_GRANEL)
            {
                ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL datoTabla = new ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL();
                datoTabla.LFPOS = row.GetInt("LFPOS");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                res.DESTARE_GRANEL[i_DESTARE_GRANEL] = datoTabla; ++i_DESTARE_GRANEL;
            }
            IRfcTable rfcTable_ITEM_GRANEL = rfcFunction.GetTable("ITEM_GRANEL");
            res.ITEM_GRANEL = new ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL[rfcTable_ITEM_GRANEL.RowCount];
            int i_ITEM_GRANEL = 0;
            foreach (IRfcStructure row in rfcTable_ITEM_GRANEL)
            {
                ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL datoTabla = new ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL();
                datoTabla.STCK_TYPE = row.GetString("STCK_TYPE");
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.PO_UNIT = row.GetString("PO_UNIT");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.FREE_ITEM = row.GetString("FREE_ITEM");
                res.ITEM_GRANEL[i_ITEM_GRANEL] = datoTabla; ++i_ITEM_GRANEL;
            }
            IRfcTable rfcTable_LOG = rfcFunction.GetTable("LOG");
            res.LOG = new ZMOV_CREATE_RECEP_GRANEL_LOG[rfcTable_LOG.RowCount];
            int i_LOG = 0;
            foreach (IRfcStructure row in rfcTable_LOG)
            {
                ZMOV_CREATE_RECEP_GRANEL_LOG datoTabla = new ZMOV_CREATE_RECEP_GRANEL_LOG();
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

            return res;
        }
    }
    public class request_ZMOV_CREATE_RECEP_GRANEL
    {
        public ZMOV_CREATE_RECEP_GRANEL_HEADER HEADER;
        public String IV_PEDIDO;

        public ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL[] DESTARE_GRANEL;
        public ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL[] ITEM_GRANEL;
    }
    public class responce_ZMOV_CREATE_RECEP_GRANEL
    {
        public String MATERIALDOCUMENT;
        public String MATERIALDOCUMENT_BD;
        public String PEDIDO;
        public ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL[] DESTARE_GRANEL;
        public ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL[] ITEM_GRANEL;
        public ZMOV_CREATE_RECEP_GRANEL_LOG[] LOG;
    }
    public class ZMOV_CREATE_RECEP_GRANEL_HEADER
    {
        public String BUKRS;
        public String EKORG;
        public String EKGRP;
        public String BSART;
        public String BUDAT;
        public String HSDAT;
        public String LIFNR;
        public String XBLNR;
        public String BKTXT;
        public String VARIEDAD;
        public String LOTE;
        public String PRODUCTOR;
        public String PREDIO;
        public String CUARTEL;
        public String ZPATENTE;
        public String ZCONDUCTOR;
        public String TRATAMIENTO;
        public String TIPO_FRIO;
        public Decimal QBINS;
    }
    public class ZMOV_CREATE_RECEP_GRANEL_DESTARE_GRANEL
    {
        public Int32 LFPOS;
        public String MATERIAL;
        public Decimal QUANTITY;
        public String PO_UNIT;
        public String WERKS;
        public String LGORT;
    }
    public class ZMOV_CREATE_RECEP_GRANEL_ITEM_GRANEL
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
    }
    public class ZMOV_CREATE_RECEP_GRANEL_LOG
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