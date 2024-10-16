using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_30007
    {
        public responce_ZMOV_30007 sapRun(request_ZMOV_30007 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_30007");

            rfcFunction.SetValue("I_CALIBRE", import.I_CALIBRE);
            rfcFunction.SetValue("I_MATERIAL", import.I_MATERIAL);
            rfcFunction.SetValue("I_VARIEDAD", import.I_VARIEDAD);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_30007 res = new responce_ZMOV_30007();

            IRfcTable rfcTable_E_OUT_PLUBAND = rfcFunction.GetTable("E_OUT_PLUBAND");
            res.E_OUT_PLUBAND = new ZMOV_30007_E_OUT_PLUBAND[rfcTable_E_OUT_PLUBAND.RowCount];
            int i_E_OUT_PLUBAND = 0;
            foreach (IRfcStructure row in rfcTable_E_OUT_PLUBAND)
            {
                ZMOV_30007_E_OUT_PLUBAND datoTabla = new ZMOV_30007_E_OUT_PLUBAND();
                datoTabla.ZMATERIAL = row.GetString("ZMATERIAL");
                datoTabla.ZVARIEDAD = row.GetString("ZVARIEDAD");
                datoTabla.ZCALIBRE = row.GetString("ZCALIBRE");
                datoTabla.ZCOMP = row.GetString("ZCOMP");
                datoTabla.ZCBASE = row.GetDecimal("ZCBASE");
                datoTabla.ZUMB = row.GetString("ZUMB");
                datoTabla.ZCANTID = row.GetDecimal("ZCANTID");
                datoTabla.ZUMB2 = row.GetString("ZUMB2");
                datoTabla.ZPALLET = row.GetString("ZPALLET");
                res.E_OUT_PLUBAND[i_E_OUT_PLUBAND] = datoTabla; ++i_E_OUT_PLUBAND;
            }

            return res;
        }
    }
    public class request_ZMOV_30007
    {
        public String I_CALIBRE;
        public String I_MATERIAL;
        public String I_VARIEDAD;
        public String USER;
        public String PASS;
    }
    public class responce_ZMOV_30007
    {

        public ZMOV_30007_E_OUT_PLUBAND[] E_OUT_PLUBAND;
    }
    public class ZMOV_30007_E_OUT_PLUBAND
    {
        public String ZMATERIAL;
        public String ZVARIEDAD;
        public String ZCALIBRE;
        public String ZCOMP;
        public Decimal ZCBASE;
        public String ZUMB;
        public Decimal ZCANTID;
        public String ZUMB2;
        public String ZPALLET;
    }

}