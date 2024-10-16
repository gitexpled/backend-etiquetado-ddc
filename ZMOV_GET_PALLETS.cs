using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_GET_PALLETS
    {
        public responce_ZMOV_GET_PALLETS sapRun(request_ZMOV_GET_PALLETS import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_GET_PALLETS");

            rfcFunction.SetValue("I_XBLNR", import.I_XBLNR);
            IRfcTable rfcTable_ET_PALLETS_I = rfcFunction.GetTable("ET_PALLETS");
            foreach (ZMOV_GET_PALLETS_ET_PALLETS row in import.ET_PALLETS)
            {
                rfcTable_ET_PALLETS_I.Append();
                ZMOV_GET_PALLETS_ET_PALLETS datoTabla = new ZMOV_GET_PALLETS_ET_PALLETS();
                rfcTable_ET_PALLETS_I.SetValue("EXIDV", row.EXIDV);
                rfcTable_ET_PALLETS_I.SetValue("VENUM", row.VENUM);
                rfcTable_ET_PALLETS_I.SetValue("PRODUCTOR", row.PRODUCTOR);
                rfcTable_ET_PALLETS_I.SetValue("NOMBRE_PRODUCTOR", row.NOMBRE_PRODUCTOR);
                rfcTable_ET_PALLETS_I.SetValue("PRODUCTOR_ET", row.PRODUCTOR_ET);
                rfcTable_ET_PALLETS_I.SetValue("NOMBRE_PRODUCTOR_ET", row.NOMBRE_PRODUCTOR_ET);
            }
            rfcFunction.SetValue("ET_PALLETS", rfcTable_ET_PALLETS_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_GET_PALLETS res = new responce_ZMOV_GET_PALLETS();
            IRfcTable rfcTable_ET_PALLETS = rfcFunction.GetTable("ET_PALLETS");
            res.ET_PALLETS = new ZMOV_GET_PALLETS_ET_PALLETS[rfcTable_ET_PALLETS.RowCount];
            int i_ET_PALLETS = 0;
            foreach (IRfcStructure row in rfcTable_ET_PALLETS)
            {
                ZMOV_GET_PALLETS_ET_PALLETS datoTabla = new ZMOV_GET_PALLETS_ET_PALLETS();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.VENUM = row.GetString("VENUM");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                res.ET_PALLETS[i_ET_PALLETS] = datoTabla; ++i_ET_PALLETS;
            }

            return res;
        }
    }
    public class request_ZMOV_GET_PALLETS
    {
        public String I_XBLNR;
        public ZMOV_GET_PALLETS_ET_PALLETS[] ET_PALLETS;
    }
    public class responce_ZMOV_GET_PALLETS
    {
        public ZMOV_GET_PALLETS_ET_PALLETS[] ET_PALLETS;
    }
    public class ZMOV_GET_PALLETS_ET_PALLETS
    {
        public String EXIDV;
        public String VENUM;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
    }

}