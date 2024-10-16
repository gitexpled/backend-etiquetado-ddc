using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_HU_ALMACEN
    {
        public responce_ZMOV_QUERY_HU_ALMACEN sapRun(request_ZMOV_QUERY_HU_ALMACEN import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_HU_ALMACEN");

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_HU_ALMACEN res = new responce_ZMOV_QUERY_HU_ALMACEN();
            IRfcTable rfcTable_HU_ALMACEN = rfcFunction.GetTable("HU_ALMACEN");
            res.HU_ALMACEN = new ZMOV_QUERY_HU_ALMACEN_HU_ALMACEN[rfcTable_HU_ALMACEN.RowCount];
            int i_HU_ALMACEN = 0;
            foreach (IRfcStructure row in rfcTable_HU_ALMACEN)
            {
                ZMOV_QUERY_HU_ALMACEN_HU_ALMACEN datoTabla = new ZMOV_QUERY_HU_ALMACEN_HU_ALMACEN();
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.NAME1_W = row.GetString("NAME1_W");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.NAME1_D = row.GetString("NAME1_D");
                datoTabla.XHUPF = row.GetString("XHUPF");
                res.HU_ALMACEN[i_HU_ALMACEN] = datoTabla; ++i_HU_ALMACEN;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_HU_ALMACEN
    {
    }
    public class responce_ZMOV_QUERY_HU_ALMACEN
    {
        public ZMOV_QUERY_HU_ALMACEN_HU_ALMACEN[] HU_ALMACEN;
    }
    public class ZMOV_QUERY_HU_ALMACEN_HU_ALMACEN
    {
        public String WERKS;
        public String NAME1_W;
        public String LGORT;
        public String NAME1_D;
        public String XHUPF;
    }

}