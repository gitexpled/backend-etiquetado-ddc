using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10019
    {
        public responce_ZMOV_10019 sapRun(request_ZMOV_10019 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10019");

            rfcFunction.SetValue("I_MATNR", import.I_MATNR);
            rfcFunction.SetValue("I_WERKS", import.I_WERKS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10019 res = new responce_ZMOV_10019();
            //res.ET_ORDERS = rfcFunction.GetString("ET_ORDERS");
            IRfcTable rfcTable_ET_ORDERS = rfcFunction.GetTable("ET_ORDERS");
            res.ET_ORDERS = new ZMOV_10019_ET_ORDERS[rfcTable_ET_ORDERS.RowCount];
            int i_ET_ORDERS = 0;
            foreach (IRfcStructure row in rfcTable_ET_ORDERS)
            {
                ZMOV_10019_ET_ORDERS datoTabla = new ZMOV_10019_ET_ORDERS();
                datoTabla.AUFNR = row.GetString("AUFNR");
                datoTabla.KTEXT = row.GetString("KTEXT");
                datoTabla.OBJNR = row.GetString("OBJNR");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.ISTAT = row.GetString("ISTAT");
                res.ET_ORDERS[i_ET_ORDERS] = datoTabla; ++i_ET_ORDERS;
            }

            return res;
        }
    }
    public class request_ZMOV_10019
    {
        public String I_MATNR;
        public String I_WERKS;
    }
    public class responce_ZMOV_10019
    {
        public String ET_ORDER;
        public ZMOV_10019_ET_ORDERS[] ET_ORDERS;
    }
    public class ZMOV_10019_ET_ORDERS
    {
        public String AUFNR;
        public String KTEXT;
        public String OBJNR;
        public String MATNR;
        public String ISTAT;
    }

}