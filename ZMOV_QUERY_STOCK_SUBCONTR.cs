using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_STOCK_SUBCONTR
    {
        public responce_ZMOV_QUERY_STOCK_SUBCONTR sapRun(request_ZMOV_QUERY_STOCK_SUBCONTR import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_STOCK_SUBCONTR");

            rfcFunction.SetValue("WERKS", import.WERKS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_STOCK_SUBCONTR res = new responce_ZMOV_QUERY_STOCK_SUBCONTR();
            IRfcTable rfcTable_WERKS = rfcFunction.GetTable("WERKS");
            res.WERKS = new ZMOV_QUERY_STOCK_SUBCONTR_WERKS[rfcTable_WERKS.RowCount];
            int i_WERKS = 0;
            foreach (IRfcStructure row in rfcTable_WERKS)
            {
                ZMOV_QUERY_STOCK_SUBCONTR_WERKS datoTabla = new ZMOV_QUERY_STOCK_SUBCONTR_WERKS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.WERKS[i_WERKS] = datoTabla; ++i_WERKS;
            }
            IRfcTable rfcTable_STOCKSUBC = rfcFunction.GetTable("STOCKSUBC");
            res.STOCKSUBC = new ZMOV_QUERY_STOCK_SUBCONTR_STOCKSUBC[rfcTable_STOCKSUBC.RowCount];
            int i_STOCKSUBC = 0;
            foreach (IRfcStructure row in rfcTable_STOCKSUBC)
            {
                ZMOV_QUERY_STOCK_SUBCONTR_STOCKSUBC datoTabla = new ZMOV_QUERY_STOCK_SUBCONTR_STOCKSUBC();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.LBLAB = row.GetDecimal("LBLAB");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.GUIA = row.GetString("GUIA");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                res.STOCKSUBC[i_STOCKSUBC] = datoTabla; ++i_STOCKSUBC;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_STOCK_SUBCONTR
    {
        public String WERKS;
    }
    public class responce_ZMOV_QUERY_STOCK_SUBCONTR
    {
        public ZMOV_QUERY_STOCK_SUBCONTR_WERKS[] WERKS;
        public ZMOV_QUERY_STOCK_SUBCONTR_STOCKSUBC[] STOCKSUBC;
    }
    public class ZMOV_QUERY_STOCK_SUBCONTR_WERKS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_STOCK_SUBCONTR_STOCKSUBC
    {
        public String MATNR;
        public String WERKS;
        public String CHARG;
        public Decimal LBLAB;
        public String MEINS;
        public String LIFNR;
        public String NOMBRE_PRODUCTOR;
        public String HSDAT;
        public String VARIEDAD;
        public String GUIA;
        public String ESPECIE;
    }

}