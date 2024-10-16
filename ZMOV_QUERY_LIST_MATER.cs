using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_LIST_MATER
    {
        public responce_ZMOV_QUERY_LIST_MATER sapRun(request_ZMOV_QUERY_LIST_MATER import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_LIST_MATER");

            rfcFunction.SetValue("I_MATNR", import.I_MATNR);
            rfcFunction.SetValue("I_WERKS", import.I_WERKS);
            IRfcTable rfcTable_LT_LIST_MAT_I = rfcFunction.GetTable("LT_LIST_MAT");
            if (import.LT_LIST_MAT != null)
            {
                foreach (ZMOV_QUERY_LIST_MATER_LT_LIST_MAT row in import.LT_LIST_MAT)
                {
                    rfcTable_LT_LIST_MAT_I.Append();
                    ZMOV_QUERY_LIST_MATER_LT_LIST_MAT datoTabla = new ZMOV_QUERY_LIST_MATER_LT_LIST_MAT();
                    rfcTable_LT_LIST_MAT_I.SetValue("MATNR", row.MATNR);
                    rfcTable_LT_LIST_MAT_I.SetValue("WERKS", row.WERKS);
                    rfcTable_LT_LIST_MAT_I.SetValue("STLAL", row.STLAL);
                    rfcTable_LT_LIST_MAT_I.SetValue("STKTX", row.STKTX);
                }
            }
            rfcFunction.SetValue("LT_LIST_MAT", rfcTable_LT_LIST_MAT_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_LIST_MATER res = new responce_ZMOV_QUERY_LIST_MATER();
            IRfcTable rfcTable_LT_LIST_MAT = rfcFunction.GetTable("LT_LIST_MAT");
            res.LT_LIST_MAT = new ZMOV_QUERY_LIST_MATER_LT_LIST_MAT[rfcTable_LT_LIST_MAT.RowCount];
            int i_LT_LIST_MAT = 0;
            foreach (IRfcStructure row in rfcTable_LT_LIST_MAT)
            {
                ZMOV_QUERY_LIST_MATER_LT_LIST_MAT datoTabla = new ZMOV_QUERY_LIST_MATER_LT_LIST_MAT();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.STLAL = row.GetString("STLAL");
                datoTabla.STKTX = row.GetString("STKTX");
                res.LT_LIST_MAT[i_LT_LIST_MAT] = datoTabla; ++i_LT_LIST_MAT;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_LIST_MATER
    {
        public String I_MATNR;
        public String I_WERKS;
        public ZMOV_QUERY_LIST_MATER_LT_LIST_MAT[] LT_LIST_MAT;
    }
    public class responce_ZMOV_QUERY_LIST_MATER
    {
        public ZMOV_QUERY_LIST_MATER_LT_LIST_MAT[] LT_LIST_MAT;
    }
    public class ZMOV_QUERY_LIST_MATER_LT_LIST_MAT
    {
        public String MATNR;
        public String WERKS;
        public String STLAL;
        public String STKTX;
    }

}