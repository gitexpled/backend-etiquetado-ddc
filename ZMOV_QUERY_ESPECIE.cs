using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_ESPECIE
    {
        public responce_ZMOV_QUERY_ESPECIE sapRun(request_ZMOV_QUERY_ESPECIE import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_ESPECIE");

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_ESPECIE res = new responce_ZMOV_QUERY_ESPECIE();
            IRfcTable rfcTable_ESPECIE = rfcFunction.GetTable("ESPECIE");
            res.ESPECIE = new ZMOV_QUERY_ESPECIE_ESPECIE[rfcTable_ESPECIE.RowCount];
            int i_ESPECIE = 0;
            foreach (IRfcStructure row in rfcTable_ESPECIE)
            {
                ZMOV_QUERY_ESPECIE_ESPECIE datoTabla = new ZMOV_QUERY_ESPECIE_ESPECIE();
                datoTabla.ATNAM = row.GetString("ATNAM");
                datoTabla.ATBEZ = row.GetString("ATBEZ");
                res.ESPECIE[i_ESPECIE] = datoTabla; ++i_ESPECIE;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_ESPECIE
    {
    }
    public class responce_ZMOV_QUERY_ESPECIE
    {
        public ZMOV_QUERY_ESPECIE_ESPECIE[] ESPECIE;
    }
    public class ZMOV_QUERY_ESPECIE_ESPECIE
    {
        public String ATNAM;
        public String ATBEZ;
    }

}