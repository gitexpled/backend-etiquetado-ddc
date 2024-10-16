using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class BAPI_TRANSACTION
    {
        public static responce_BAPI_TRANSACTION_COMMIT Commit(RfcDestination configSap)
        {
            //configSap = RfcDestinationManager.GetDestination("SCLEM");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("BAPI_TRANSACTION_COMMIT");

            rfcFunction.SetValue("WAIT", "X");
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_BAPI_TRANSACTION_COMMIT res = new responce_BAPI_TRANSACTION_COMMIT();


            IRfcStructure row = rfcFunction.GetStructure("RETURN");
            //res.RETURN = new BAPI_RESERVATION_CREATE1_RETURN[rfcTable_RETURN.RowCount];
            //int i_RETURN = 0;

            BAPI_TRANSACTION_COMMIT_RETURN datoTabla = new BAPI_TRANSACTION_COMMIT_RETURN();
            datoTabla.TYPE = row.GetString("TYPE");
            datoTabla.ID = row.GetString("ID");
            datoTabla.NUMBER = row.GetInt("NUMBER");
            datoTabla.MESSAGE = row.GetString("MESSAGE");
            datoTabla.LOG_NO = row.GetString("LOG_NO");
            datoTabla.LOG_MSG_NO = row.GetInt("LOG_MSG_NO");
            datoTabla.MESSAGE_V1 = row.GetString("MESSAGE_V1");
            datoTabla.MESSAGE_V2 = row.GetString("MESSAGE_V2");
            datoTabla.MESSAGE_V3 = row.GetString("MESSAGE_V3");
            datoTabla.MESSAGE_V4 = row.GetString("MESSAGE_V4");
            datoTabla.PARAMETER = row.GetString("PARAMETER");
            datoTabla.ROW = row.GetInt("ROW");
            datoTabla.FIELD = row.GetString("FIELD");
            datoTabla.SYSTEM = row.GetString("SYSTEM");


            return res;
        }

        public static void Rollback(RfcDestination configSap)
        {

            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("BAPI_TRANSACTION_ROLLBACK");

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();

        }
    }
    public class request_BAPI_TRANSACTION_COMMIT
    {
        public String WAIT;
    }
    public class responce_BAPI_TRANSACTION_COMMIT
    {
    }

    public class BAPI_TRANSACTION_COMMIT_RETURN
    {
        public String TYPE;
        public String ID;
        public Int32 NUMBER;
        public String MESSAGE;
        public String LOG_NO;
        public Int32 LOG_MSG_NO;
        public String MESSAGE_V1;
        public String MESSAGE_V2;
        public String MESSAGE_V3;
        public String MESSAGE_V4;
        public String PARAMETER;
        public Int32 ROW;
        public String FIELD;
        public String SYSTEM;
    }

}
