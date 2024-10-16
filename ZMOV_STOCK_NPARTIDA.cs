using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_STOCK_NPARTIDA
    {
        public responce_ZMOV_STOCK_NPARTIDA sapRun(request_ZMOV_STOCK_NPARTIDA import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_STOCK_NPARTIDA");

            rfcFunction.SetValue("I_ATNAM", import.I_ATNAM);
            rfcFunction.SetValue("I_ATWRT", import.I_ATWRT);
            rfcFunction.SetValue("I_BUKRS", import.I_BUKRS);

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_STOCK_NPARTIDA res = new responce_ZMOV_STOCK_NPARTIDA();
            //res.ET_LOTES = rfcFunction.GetString("ET_LOTES");
            IRfcTable rfcTable_ET_LOTES = rfcFunction.GetTable("ET_LOTES");
            res.ET_LOTES = new ZMOV_STOCK_NPARTIDA_ET_LOTES[rfcTable_ET_LOTES.RowCount];
            int i_ET_LOTES = 0;
            foreach (IRfcStructure row in rfcTable_ET_LOTES)
            {
                ZMOV_STOCK_NPARTIDA_ET_LOTES datoTabla = new ZMOV_STOCK_NPARTIDA_ET_LOTES();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.CLABS = row.GetDecimal("CLABS");
                datoTabla.CINSM = row.GetDecimal("CINSM");
                datoTabla.CSPEM = row.GetDecimal("CSPEM");
                datoTabla.MEINS = row.GetString("MEINS");
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
    public class request_ZMOV_STOCK_NPARTIDA
    {
        public ZMOV_STOCK_NPARTIDA_ET_LOTES[] ET_LOTES;
        public String I_ATNAM;
        public String I_ATWRT;
        public String I_BUKRS;
    }
    public class responce_ZMOV_STOCK_NPARTIDA
    {
        //public String ET_LOTES;
        public ZMOV_STOCK_NPARTIDA_ET_LOTES[] ET_LOTES;
    }
    public class ZMOV_STOCK_NPARTIDA_ET_LOTES
    {
        public String MATNR;
        public String MAKTX;
        public String WERKS;
        public String LGORT;
        public String CHARG;
        public Decimal CLABS;
        public Decimal CINSM;
        public Decimal CSPEM;
        public String MEINS;
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