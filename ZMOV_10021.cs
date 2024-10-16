using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10021
    {
        public responce_ZMOV_10021 sapRun(request_ZMOV_10021 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10021");

            rfcFunction.SetValue("IV_MATNR", import.IV_MATNR);
            rfcFunction.SetValue("IV_STLAL_PALLET", import.IV_STLAL_PALLET);
            rfcFunction.SetValue("IV_WERKS", import.IV_WERKS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10021 res = new responce_ZMOV_10021();
            IRfcTable rfcTable_LT_DETALLE = rfcFunction.GetTable("LT_DETALLE");
            res.LT_DETALLE = new ZMOV_10021_LT_DETALLE[rfcTable_LT_DETALLE.RowCount];
            int i_LT_DETALLE = 0;
            foreach (IRfcStructure row in rfcTable_LT_DETALLE)
            {
                ZMOV_10021_LT_DETALLE datoTabla = new ZMOV_10021_LT_DETALLE();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.TIPO_PALLET = row.GetString("TIPO_PALLET");
                res.LT_DETALLE[i_LT_DETALLE] = datoTabla; ++i_LT_DETALLE;
            }

            return res;
        }
    }
    public class request_ZMOV_10021
    {
        public String IV_MATNR;
        public String IV_STLAL_PALLET;
        public String IV_WERKS;
    }
    public class responce_ZMOV_10021
    {
        public ZMOV_10021_LT_DETALLE[] LT_DETALLE;
    }
    public class ZMOV_10021_LT_DETALLE
    {
        public String MATNR;
        public String TIPO_PALLET;
    }

}