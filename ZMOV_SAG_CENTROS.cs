using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_SAG_CENTROS
    {
        public responce_ZMOV_SAG_CENTROS sapRun(request_ZMOV_SAG_CENTROS import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_SAG_CENTROS");

            rfcFunction.SetValue("I_BUKRS", import.I_BUKRS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_SAG_CENTROS res = new responce_ZMOV_SAG_CENTROS();
            //res.ET_CENTROS = rfcFunction.GetString("ET_CENTROS");
            IRfcTable rfcTable_ET_CENTROS = rfcFunction.GetTable("ET_CENTROS");
            res.ET_CENTROS = new ZMOV_SAG_CENTROS_ET_CENTROS[rfcTable_ET_CENTROS.RowCount];
            int i_ET_CENTROS = 0;
            foreach (IRfcStructure row in rfcTable_ET_CENTROS)
            {
                ZMOV_SAG_CENTROS_ET_CENTROS datoTabla = new ZMOV_SAG_CENTROS_ET_CENTROS();
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.NAME1 = row.GetString("NAME1");
                datoTabla.NAME2 = row.GetString("NAME2");
                datoTabla.NAME3 = row.GetString("NAME3");
                datoTabla.NAME4 = row.GetString("NAME4");
                datoTabla.STREET = row.GetString("STREET");
                datoTabla.CITY1 = row.GetString("CITY1");
                datoTabla.CITY2 = row.GetString("CITY2");
                datoTabla.REGION = row.GetString("REGION");
                datoTabla.POST_CODE1 = row.GetString("POST_CODE1");
                datoTabla.NAME_CO = row.GetString("NAME_CO");
                datoTabla.HOUSE_NUM2 = row.GetString("HOUSE_NUM2");
                datoTabla.SORT1 = row.GetString("SORT1");
                datoTabla.SORT2 = row.GetString("SORT2");
                res.ET_CENTROS[i_ET_CENTROS] = datoTabla; ++i_ET_CENTROS;
            }

            return res;
        }
    }
    public class request_ZMOV_SAG_CENTROS
    {
        public String I_BUKRS;
    }
    public class responce_ZMOV_SAG_CENTROS
    {
        //public String ET_CENTROS;
        public ZMOV_SAG_CENTROS_ET_CENTROS[] ET_CENTROS;
    }
    public class ZMOV_SAG_CENTROS_ET_CENTROS
    {
        public String WERKS;
        public String NAME1;
        public String NAME2;
        public String NAME3;
        public String NAME4;
        public String STREET;
        public String CITY1;
        public String CITY2;
        public String REGION;
        public String POST_CODE1;
        public String NAME_CO;
        public String HOUSE_NUM2;
        public String SORT1;
        public String SORT2;
    }

}