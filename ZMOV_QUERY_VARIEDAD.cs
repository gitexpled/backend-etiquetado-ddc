using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_VARIEDAD
    {
        public responce_ZMOV_QUERY_VARIEDAD sapRun(request_ZMOV_QUERY_VARIEDAD import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_VARIEDAD");

            rfcFunction.SetValue("ATKLA", import.ATKLA);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_VARIEDAD res = new responce_ZMOV_QUERY_VARIEDAD();
            IRfcTable rfcTable_VARIEDAD = rfcFunction.GetTable("VARIEDAD");
            res.VARIEDAD = new ZMOV_QUERY_VARIEDAD_VARIEDAD[rfcTable_VARIEDAD.RowCount];
            int i_VARIEDAD = 0;
            foreach (IRfcStructure row in rfcTable_VARIEDAD)
            {
                ZMOV_QUERY_VARIEDAD_VARIEDAD datoTabla = new ZMOV_QUERY_VARIEDAD_VARIEDAD();
                datoTabla.ATNAM = row.GetString("ATNAM");
                datoTabla.ATBEZ = row.GetString("ATBEZ");
                datoTabla.VALUE_CHAR = row.GetString("VALUE_CHAR");
                datoTabla.DESCRIPTION = row.GetString("DESCRIPTION");
                res.VARIEDAD[i_VARIEDAD] = datoTabla; ++i_VARIEDAD;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_VARIEDAD
    {
        public String ATKLA;
    }
    public class responce_ZMOV_QUERY_VARIEDAD
    {
        public ZMOV_QUERY_VARIEDAD_VARIEDAD[] VARIEDAD;
    }
    public class ZMOV_QUERY_VARIEDAD_VARIEDAD
    {
        public String ATNAM;
        public String ATBEZ;
        public String VALUE_CHAR;
        public String DESCRIPTION;
    }

}