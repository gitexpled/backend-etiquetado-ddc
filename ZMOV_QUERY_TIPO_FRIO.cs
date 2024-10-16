using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_TIPO_FRIO
    {
        public responce_ZMOV_QUERY_TIPO_FRIO sapRun(request_ZMOV_QUERY_TIPO_FRIO import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_TIPO_FRIO");

            rfcFunction.SetValue("ATKLA", import.ATKLA);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_TIPO_FRIO res = new responce_ZMOV_QUERY_TIPO_FRIO();
            IRfcTable rfcTable_TIPO_FRIO = rfcFunction.GetTable("TIPO_FRIO");
            res.TIPO_FRIO = new ZMOV_QUERY_TIPO_FRIO_TIPO_FRIO[rfcTable_TIPO_FRIO.RowCount];
            int i_TIPO_FRIO = 0;
            foreach (IRfcStructure row in rfcTable_TIPO_FRIO)
            {
                ZMOV_QUERY_TIPO_FRIO_TIPO_FRIO datoTabla = new ZMOV_QUERY_TIPO_FRIO_TIPO_FRIO();
                datoTabla.ATNAM = row.GetString("ATNAM");
                datoTabla.ATBEZ = row.GetString("ATBEZ");
                datoTabla.VALUE_CHAR = row.GetString("VALUE_CHAR");
                datoTabla.DESCRIPTION = row.GetString("DESCRIPTION");
                res.TIPO_FRIO[i_TIPO_FRIO] = datoTabla; ++i_TIPO_FRIO;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_TIPO_FRIO
    {
        public String ATKLA;
    }
    public class responce_ZMOV_QUERY_TIPO_FRIO
    {
        public ZMOV_QUERY_TIPO_FRIO_TIPO_FRIO[] TIPO_FRIO;
    }
    public class ZMOV_QUERY_TIPO_FRIO_TIPO_FRIO
    {
        public String ATNAM;
        public String ATBEZ;
        public String VALUE_CHAR;
        public String DESCRIPTION;
    }

}