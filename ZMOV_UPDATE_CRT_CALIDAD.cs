using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_UPDATE_CRT_CALIDAD
    {
        public responce_ZMOV_UPDATE_CRT_CALIDAD sapRun(request_ZMOV_UPDATE_CRT_CALIDAD import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_UPDATE_CRT_CALIDAD");

            rfcFunction.SetValue("CONDICION1", import.CONDICION1);
            rfcFunction.SetValue("CONDICION2", import.CONDICION2);
            rfcFunction.SetValue("CONDICION3", import.CONDICION3);
            rfcFunction.SetValue("LIFNR", import.LIFNR);
            rfcFunction.SetValue("XBLNR", import.XBLNR);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_UPDATE_CRT_CALIDAD res = new responce_ZMOV_UPDATE_CRT_CALIDAD();
            IRfcTable rfcTable_LOG = rfcFunction.GetTable("LOG");
            res.LOG = new ZMOV_UPDATE_CRT_CALIDAD_LOG[rfcTable_LOG.RowCount];
            int i_LOG = 0;
            foreach (IRfcStructure row in rfcTable_LOG)
            {
                ZMOV_UPDATE_CRT_CALIDAD_LOG datoTabla = new ZMOV_UPDATE_CRT_CALIDAD_LOG();
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
                res.LOG[i_LOG] = datoTabla; ++i_LOG;
            }

            return res;
        }
    }
    public class request_ZMOV_UPDATE_CRT_CALIDAD
    {
        public Decimal CONDICION1;
        public Decimal CONDICION2;
        public Decimal CONDICION3;
        public String LIFNR;
        public String XBLNR;
    }
    public class responce_ZMOV_UPDATE_CRT_CALIDAD
    {
        public ZMOV_UPDATE_CRT_CALIDAD_LOG[] LOG;
    }
    public class ZMOV_UPDATE_CRT_CALIDAD_LOG
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