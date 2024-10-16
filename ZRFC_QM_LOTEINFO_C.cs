﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZRFC_QM_LOTEINFO_C
    {
        public responce_ZRFC_QM_LOTEINFO_C sapRun(request_ZRFC_QM_LOTEINFO_C import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZRFC_QM_LOTEINFO_C");

            rfcFunction.SetValue("I_ATNAM", import.I_ATNAM);
            rfcFunction.SetValue("I_ATWRT", import.I_ATWRT);
            rfcFunction.SetValue("I_BUKRS", import.I_BUKRS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZRFC_QM_LOTEINFO_C res = new responce_ZRFC_QM_LOTEINFO_C();
            //res.ET_LOTES = rfcFunction.GetString("ET_LOTES");
            IRfcTable rfcTable_ET_LOTES = rfcFunction.GetTable("ET_LOTES");
            res.ET_LOTES = new ZRFC_QM_LOTEINFO_C_ET_LOTES[rfcTable_ET_LOTES.RowCount];
            int i_ET_LOTES = 0;
            foreach (IRfcStructure row in rfcTable_ET_LOTES)
            {
                ZRFC_QM_LOTEINFO_C_ET_LOTES datoTabla = new ZRFC_QM_LOTEINFO_C_ET_LOTES();
                datoTabla.MBLNR = row.GetString("MBLNR");
                datoTabla.MJAHR = row.GetInt("MJAHR");
                datoTabla.ZEILE = row.GetInt("ZEILE");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.MENGE = row.GetDecimal("MENGE");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.ERFMG = row.GetDecimal("ERFMG");
                datoTabla.ERFME = row.GetString("ERFME");
                datoTabla.BPMNG = row.GetDecimal("BPMNG");
                datoTabla.BPRME = row.GetString("BPRME");
                datoTabla.BUKRS = row.GetString("BUKRS");
                datoTabla.BWART = row.GetString("BWART");
                datoTabla.SHKZG = row.GetString("SHKZG");
                datoTabla.DDC_NEN = row.GetString("DDC_NEN");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.FABRICACION = row.GetString("FABRICACION");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.FCOSECHA = row.GetString("FCOSECHA");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.UAT = row.GetString("UAT");
                datoTabla.DDC_TEN = row.GetString("DDC_TEN");
                res.ET_LOTES[i_ET_LOTES] = datoTabla; ++i_ET_LOTES;
            }

            return res;
        }
    }
    public class request_ZRFC_QM_LOTEINFO_C
    {
        public String I_ATNAM;
        public String I_ATWRT;
        public String I_BUKRS;
    }
    public class responce_ZRFC_QM_LOTEINFO_C
    {
        //public String ET_LOTES;
        public ZRFC_QM_LOTEINFO_C_ET_LOTES[] ET_LOTES;
    }
    public class ZRFC_QM_LOTEINFO_C_ET_LOTES
    {
        public String MBLNR;
        public Int32 MJAHR;
        public Int32 ZEILE;
        public String MATNR;
        public String WERKS;
        public String LGORT;
        public String CHARG;
        public Decimal MENGE;
        public String MEINS;
        public Decimal ERFMG;
        public String ERFME;
        public Decimal BPMNG;
        public String BPRME;
        public String BUKRS;
        public String BWART;
        public String SHKZG;
        public String DDC_NEN;
        public String VARIEDAD;
        public String VARIEDAD_ET;
        public String FABRICACION;
        public String ESPECIE;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
        public String FCOSECHA;
        public String CALIBRE;
        public String UAT;
        public String DDC_TEN;
    }

}