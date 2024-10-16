using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10033
    {
        public responce_ZMOV_10033 sapRun(request_ZMOV_10033 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10033");

            rfcFunction.SetValue("I_LIFNR", import.I_LIFNR);
            rfcFunction.SetValue("I_XBLNR", import.I_XBLNR);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10033 res = new responce_ZMOV_10033();
            IRfcTable rfcTable_ET_PALLETS = rfcFunction.GetTable("ET_PALLETS");
            res.ET_PALLETS = new ZMOV_10033_ET_PALLETS[rfcTable_ET_PALLETS.RowCount];
            int i_ET_PALLETS = 0;
            foreach (IRfcStructure row in rfcTable_ET_PALLETS)
            {
                ZMOV_10033_ET_PALLETS datoTabla = new ZMOV_10033_ET_PALLETS();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.VENUM = row.GetString("VENUM");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                res.ET_PALLETS[i_ET_PALLETS] = datoTabla; ++i_ET_PALLETS;
            }

            return res;
        }
    }
    public class request_ZMOV_10033
    {
        public String I_LIFNR;
        public String I_XBLNR;
    }
    public class responce_ZMOV_10033
    {
        public ZMOV_10033_ET_PALLETS[] ET_PALLETS;
    }
    public class ZMOV_10033_ET_PALLETS
    {
        public String EXIDV;
        public String VENUM;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
        public String ESPECIE;
        public String VARIEDAD;
        public String VARIEDAD_ET;
    }

}