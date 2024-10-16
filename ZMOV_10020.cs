using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10020
    {
        public responce_ZMOV_10020 sapRun(request_ZMOV_10020 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10020");

            rfcFunction.SetValue("IV_HU_GRP4", import.IV_HU_GRP4);
            rfcFunction.SetValue("IV_MATNR", import.IV_MATNR);
            rfcFunction.SetValue("IV_STLAL_PALLET", import.IV_STLAL_PALLET);
            rfcFunction.SetValue("IV_TIP_PACKING", import.IV_TIP_PACKING);
            rfcFunction.SetValue("IV_WERKS", import.IV_WERKS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10020 res = new responce_ZMOV_10020();
            IRfcTable rfcTable_LT_DETALLE = rfcFunction.GetTable("LT_DETALLE");
            res.LT_DETALLE = new ZMOV_10020_LT_DETALLE[rfcTable_LT_DETALLE.RowCount];
            int i_LT_DETALLE = 0;
            foreach (IRfcStructure row in rfcTable_LT_DETALLE)
            {
                ZMOV_10020_LT_DETALLE datoTabla = new ZMOV_10020_LT_DETALLE();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.CANTIDAD = row.GetDecimal("CANTIDAD");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.EDIT = row.GetString("EDIT");
                res.LT_DETALLE[i_LT_DETALLE] = datoTabla; ++i_LT_DETALLE;
            }

            return res;
        }
    }
    public class request_ZMOV_10020
    {
        public String IV_HU_GRP4;
        public String IV_MATNR;
        public String IV_STLAL_PALLET;
        public String IV_TIP_PACKING;
        public String IV_WERKS;
    }
    public class responce_ZMOV_10020
    {
        public ZMOV_10020_LT_DETALLE[] LT_DETALLE;
    }
    public class ZMOV_10020_LT_DETALLE
    {
        public String MATNR;
        public String MAKTX;
        public String WERKS;
        public Decimal CANTIDAD;
        public String MEINS;
        public String EDIT;
    }

}