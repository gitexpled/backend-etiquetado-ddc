using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_TRATAMIENTO
    {
        public responce_ZMOV_QUERY_TRATAMIENTO sapRun(request_ZMOV_QUERY_TRATAMIENTO import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_TRATAMIENTO");

            rfcFunction.SetValue("ATKLA", import.ATKLA);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_TRATAMIENTO res = new responce_ZMOV_QUERY_TRATAMIENTO();
            IRfcTable rfcTable_TRATAMIENTO = rfcFunction.GetTable("TRATAMIENTO");
            res.TRATAMIENTO = new ZMOV_QUERY_TRATAMIENTO_TRATAMIENTO[rfcTable_TRATAMIENTO.RowCount];
            int i_TRATAMIENTO = 0;
            foreach (IRfcStructure row in rfcTable_TRATAMIENTO)
            {
                ZMOV_QUERY_TRATAMIENTO_TRATAMIENTO datoTabla = new ZMOV_QUERY_TRATAMIENTO_TRATAMIENTO();
                datoTabla.ATNAM = row.GetString("ATNAM");
                datoTabla.ATBEZ = row.GetString("ATBEZ");
                datoTabla.VALUE_CHAR = row.GetString("VALUE_CHAR");
                datoTabla.DESCRIPTION = row.GetString("DESCRIPTION");
                res.TRATAMIENTO[i_TRATAMIENTO] = datoTabla; ++i_TRATAMIENTO;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_TRATAMIENTO
    {
        public String ATKLA;
    }
    public class responce_ZMOV_QUERY_TRATAMIENTO
    {
        public ZMOV_QUERY_TRATAMIENTO_TRATAMIENTO[] TRATAMIENTO;
    }
    public class ZMOV_QUERY_TRATAMIENTO_TRATAMIENTO
    {
        public String ATNAM;
        public String ATBEZ;
        public String VALUE_CHAR;
        public String DESCRIPTION;
    }

}