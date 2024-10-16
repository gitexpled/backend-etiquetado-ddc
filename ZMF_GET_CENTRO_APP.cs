using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_GET_CENTRO_APP
    {
        public responce_ZMF_GET_CENTRO_APP sapRun(request_ZMF_GET_CENTRO_APP import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_GET_CENTRO_APP");

            //rfcFunction.SetValue("IR_WERKS", import.IR_WERKS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_GET_CENTRO_APP res = new responce_ZMF_GET_CENTRO_APP();
            IRfcTable rfcTable_IR_WERKS = rfcFunction.GetTable("IR_WERKS");
            res.IR_WERKS = new ZMF_GET_CENTRO_APP_IR_WERKS[rfcTable_IR_WERKS.RowCount];
            int i_IR_WERKS = 0;
            foreach (IRfcStructure row in rfcTable_IR_WERKS)
            {
                ZMF_GET_CENTRO_APP_IR_WERKS datoTabla = new ZMF_GET_CENTRO_APP_IR_WERKS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_WERKS[i_IR_WERKS] = datoTabla; ++i_IR_WERKS;
            }
            IRfcTable rfcTable_LT_DET_CENTRO_APP = rfcFunction.GetTable("LT_DET_CENTRO_APP");
            res.LT_DET_CENTRO_APP = new ZMF_GET_CENTRO_APP_LT_DET_CENTRO_APP[rfcTable_LT_DET_CENTRO_APP.RowCount];
            int i_LT_DET_CENTRO_APP = 0;
            foreach (IRfcStructure row in rfcTable_LT_DET_CENTRO_APP)
            {
                ZMF_GET_CENTRO_APP_LT_DET_CENTRO_APP datoTabla = new ZMF_GET_CENTRO_APP_LT_DET_CENTRO_APP();
                datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.CARACT = row.GetString("CARACT");
                datoTabla.VALOR = row.GetString("VALOR");
                datoTabla.DENOM_CARACT = row.GetString("DENOM_CARACT");
                res.LT_DET_CENTRO_APP[i_LT_DET_CENTRO_APP] = datoTabla; ++i_LT_DET_CENTRO_APP;
            }

            return res;
        }
    }
    public class request_ZMF_GET_CENTRO_APP
    {
        public String IR_WERKS;
    }
    public class responce_ZMF_GET_CENTRO_APP
    {
        public ZMF_GET_CENTRO_APP_IR_WERKS[] IR_WERKS;
        public ZMF_GET_CENTRO_APP_LT_DET_CENTRO_APP[] LT_DET_CENTRO_APP;
    }
    public class ZMF_GET_CENTRO_APP_IR_WERKS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMF_GET_CENTRO_APP_LT_DET_CENTRO_APP
    {
        public String MANDT;
        public String WERKS;
        public String CARACT;
        public String VALOR;
        public String DENOM_CARACT;
    }

}