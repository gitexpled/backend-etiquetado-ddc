using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZRFC_QM_LOTEINFO
    {
        public responce_ZRFC_QM_LOTEINFO sapRun(request_ZRFC_QM_LOTEINFO import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZRFC_QM_LOTEINFO");

            rfcFunction.SetValue("I_BUKRS", import.I_BUKRS);
            rfcFunction.SetValue("I_CHARG", import.I_CHARG);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZRFC_QM_LOTEINFO res = new responce_ZRFC_QM_LOTEINFO();

            IRfcStructure str = rfcFunction.GetStructure("E_LOTEINFO");
            res.MBLNR = str.GetString("MBLNR");
            res.MJAHR = str.GetString("MJAHR");
            res.BLART = str.GetString("BLART");
            res.BUDAT = str.GetString("BUDAT");
            res.USNAM = str.GetString("USNAM");
            res.XBLNR = str.GetString("XBLNR");
            res.BKTXT = str.GetString("BKTXT");
            res.BUKRS = str.GetString("BUKRS");
            res.ZEILE = str.GetInt("ZEILE");
            res.BWART = str.GetString("BWART");
            res.MATNR = str.GetString("MATNR");
            res.SGTXT = str.GetString("SGTXT");
            res.WERKS = str.GetString("WERKS");
            res.WERKS_NAME = str.GetString("WERKS_NAME");
            res.LGORT = str.GetString("LGORT");
            res.CHARG = str.GetString("CHARG");
            res.LIFNR = str.GetString("LIFNR");
            res.LIFNR_NAME = str.GetString("LIFNR_NAME");
            res.HSDAT = str.GetString("HSDAT");
            res.MENGE = str.GetDecimal("MENGE");
            res.MEINS = str.GetString("MEINS");
            res.BPMNG = str.GetString("BPMNG");
            res.BPRME = str.GetString("BPRME");
            res.LFBJA = str.GetInt("LFBJA");
            res.LFBNR = str.GetString("LFBNR");
            res.SJAHR = str.GetInt("SJAHR");
            res.SMBLP = str.GetInt("SMBLP");
            res.CODVAR = str.GetString("CODVAR");
            res.VARIEDAD = str.GetString("VARIEDAD");
            res.CUARTEL = str.GetInt("CUARTEL");
            res.HUERTO = str.GetString("HUERTO");
            res.SECTOR = str.GetString("SECTOR");
            res.ZMAT_ESPECIE = str.GetString("ZMAT_ESPECIE");
            res.ZMAT_MANEJO = str.GetString("ZMAT_MANEJO");
            res.ZMAT_MERCADO = str.GetString("ZMAT_MERCADO");
            res.DDC_NEN = str.GetString("DDC_NEN");
            res.DDC_TEN = str.GetString("DDC_TEN");
            res.CONDICION1 = str.GetDecimal("CONDICION1");
            res.CONDICION2 = str.GetDecimal("CONDICION2");
            res.CONDICION3 = str.GetDecimal("CONDICION3");
            res.PRODUCTOR_ET = str.GetString("PRODUCTOR_ET");
            res.NOMBRE_PRODUCTOR_ET = str.GetString("NOMBRE_PRODUCTOR_ET");


            return res;
        }
    }
    public class request_ZRFC_QM_LOTEINFO
    {
        public String I_BUKRS;
        public String I_CHARG;
    }
    public class responce_ZRFC_QM_LOTEINFO
    {

        public String MBLNR;
        public String MJAHR;
        public String BLART;
        public String BUDAT; //0000-00-00 
        public String USNAM;
        public String XBLNR;
        public String BKTXT;
        public String BUKRS;
        public Int32 ZEILE;//0000 
        public String BWART;
        public String MATNR;
        public String SGTXT;
        public String WERKS;
        public String WERKS_NAME;
        public String LGORT;
        public String CHARG;
        public String LIFNR;
        public String LIFNR_NAME;
        public String HSDAT;//0000-00-00 
        public Decimal MENGE;//0,000 
        public String MEINS;
        public String BPMNG;//0,000 
        public String BPRME;
        public Int32 LFBJA;//0000 
        public String LFBNR;
        public Int32 SJAHR;//0000 
        public Int32 SMBLP;//0000 
        public String CODVAR;
        public String VARIEDAD;
        public Int32 CUARTEL;//0000 
        public String HUERTO;
        public String SECTOR;
        public String ZMAT_ESPECIE;
        public String ZMAT_MANEJO;
        public String ZMAT_MERCADO;
        public String DDC_NEN;
        public String DDC_TEN;
        public Decimal CONDICION1;//0,00 
        public Decimal CONDICION2;//0,00 
        public Decimal CONDICION3;//0,00
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
    }

}