using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_GET_USER
    {
        public responce_ZMF_GET_USER sapRun(request_ZMF_GET_USER import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_GET_USER");

            rfcFunction.SetValue("I_UNAME", import.I_UNAME);
            IRfcTable rfcTable_LT_DET_USER_I = rfcFunction.GetTable("LT_DET_USER");
            foreach (ZMF_GET_USER_LT_DET_USER row in import.LT_DET_USER)
            {
                rfcTable_LT_DET_USER_I.Append();
                ZMF_GET_USER_LT_DET_USER datoTabla = new ZMF_GET_USER_LT_DET_USER();
                rfcTable_LT_DET_USER_I.SetValue("MANDT", row.MANDT);
                rfcTable_LT_DET_USER_I.SetValue("UNAME", row.UNAME);
                rfcTable_LT_DET_USER_I.SetValue("WERKS", row.WERKS);
                rfcTable_LT_DET_USER_I.SetValue("LGORT", row.LGORT);
                rfcTable_LT_DET_USER_I.SetValue("ACCION", row.ACCION);
            }
            rfcFunction.SetValue("LT_DET_USER", rfcTable_LT_DET_USER_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_GET_USER res = new responce_ZMF_GET_USER();
            IRfcTable rfcTable_LT_DET_USER = rfcFunction.GetTable("LT_DET_USER");
            res.LT_DET_USER = new ZMF_GET_USER_LT_DET_USER[rfcTable_LT_DET_USER.RowCount];
            int i_LT_DET_USER = 0;
            foreach (IRfcStructure row in rfcTable_LT_DET_USER)
            {
                ZMF_GET_USER_LT_DET_USER datoTabla = new ZMF_GET_USER_LT_DET_USER();
                datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.UNAME = row.GetString("UNAME");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.ACCION = row.GetString("ACCION");
                res.LT_DET_USER[i_LT_DET_USER] = datoTabla; ++i_LT_DET_USER;
            }

            return res;
        }
    }
    public class request_ZMF_GET_USER
    {
        public String I_UNAME;
        public ZMF_GET_USER_LT_DET_USER[] LT_DET_USER;
    }
    public class responce_ZMF_GET_USER
    {
        public ZMF_GET_USER_LT_DET_USER[] LT_DET_USER;
    }
    public class ZMF_GET_USER_LT_DET_USER
    {
        public String MANDT;
        public String UNAME;
        public String WERKS;
        public String LGORT;
        public String ACCION;
    }

}