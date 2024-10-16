using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_GRUPO_CATE
    {
        public responce_ZMOV_QUERY_GRUPO_CATE sapRun(request_ZMOV_QUERY_GRUPO_CATE import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_GRUPO_CATE");

            rfcFunction.SetValue("ATKLA", import.ATKLA);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_GRUPO_CATE res = new responce_ZMOV_QUERY_GRUPO_CATE();
            IRfcTable rfcTable_ET_CARCAT = rfcFunction.GetTable("ET_CARCAT");
            res.ET_CARCAT = new ZMOV_QUERY_GRUPO_CATE_ET_CARCAT[rfcTable_ET_CARCAT.RowCount];
            int i_ET_CARCAT = 0;
            foreach (IRfcStructure row in rfcTable_ET_CARCAT)
            {
                ZMOV_QUERY_GRUPO_CATE_ET_CARCAT datoTabla = new ZMOV_QUERY_GRUPO_CATE_ET_CARCAT();
                datoTabla.ATNAM = row.GetString("ATNAM");
                datoTabla.ATBEZ = row.GetString("ATBEZ");
                datoTabla.VALUE_CHAR = row.GetString("VALUE_CHAR");
                datoTabla.DESCRIPTION = row.GetString("DESCRIPTION");
                res.ET_CARCAT[i_ET_CARCAT] = datoTabla; ++i_ET_CARCAT;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_GRUPO_CATE
    {
        public String ATKLA;
    }
    public class responce_ZMOV_QUERY_GRUPO_CATE
    {
        public ZMOV_QUERY_GRUPO_CATE_ET_CARCAT[] ET_CARCAT;
    }
    public class ZMOV_QUERY_GRUPO_CATE_ET_CARCAT
    {
        public String ATNAM;
        public String ATBEZ;
        public String VALUE_CHAR;
        public String DESCRIPTION;
    }

}