using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_50011
    {
        public responce_ZMOV_50011 sapRun(request_ZMOV_50011 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_50011");

            //rfcFunction.SetValue("IT_EXIDV", import.IT_EXIDV);
            IRfcTable rfcTable_IT_EXIDV_I = rfcFunction.GetTable("IT_EXIDV");
            foreach (ZMOV_50011_IT_EXIDV row in import.IT_EXIDV)
            {
                rfcTable_IT_EXIDV_I.Append();
                ZMOV_50011_IT_EXIDV datoTabla = new ZMOV_50011_IT_EXIDV();
                rfcTable_IT_EXIDV_I.SetValue("EXIDV", row.EXIDV.PadLeft(20, '0'));
            }
            IRfcTable rfcTable_LT_HUM_UPDATE_HEADER_I = rfcFunction.GetTable("LT_HUM_UPDATE_HEADER");
            foreach (ZMOV_50011_LT_HUM_UPDATE_HEADER row in import.LT_HUM_UPDATE_HEADER)
            {
                rfcTable_LT_HUM_UPDATE_HEADER_I.Append();
                ZMOV_50011_LT_HUM_UPDATE_HEADER datoTabla = new ZMOV_50011_LT_HUM_UPDATE_HEADER();
                rfcTable_LT_HUM_UPDATE_HEADER_I.SetValue("EXIDV", row.EXIDV.PadLeft(20, '0'));
                rfcTable_LT_HUM_UPDATE_HEADER_I.SetValue("FIELD_NAME", row.FIELD_NAME);
                rfcTable_LT_HUM_UPDATE_HEADER_I.SetValue("FIELD_VALUE", row.FIELD_VALUE);
            }
            rfcFunction.SetValue("LT_HUM_UPDATE_HEADER", rfcTable_LT_HUM_UPDATE_HEADER_I);
            rfcFunction.SetValue("IT_EXIDV", rfcTable_IT_EXIDV_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_50011 res = new responce_ZMOV_50011();
            IRfcTable rfcTable_IT_EXIDV = rfcFunction.GetTable("IT_EXIDV");
            res.IT_EXIDV = new ZMOV_50011_IT_EXIDV[rfcTable_IT_EXIDV.RowCount];
            int i_IT_EXIDV = 0;
            foreach (IRfcStructure row in rfcTable_IT_EXIDV)
            {
                ZMOV_50011_IT_EXIDV datoTabla = new ZMOV_50011_IT_EXIDV();
                datoTabla.EXIDV = row.GetString("EXIDV");
                res.IT_EXIDV[i_IT_EXIDV] = datoTabla; ++i_IT_EXIDV;
            }
            IRfcTable rfcTable_LT_HUM_UPDATE_HEADER = rfcFunction.GetTable("LT_HUM_UPDATE_HEADER");
            res.LT_HUM_UPDATE_HEADER = new ZMOV_50011_LT_HUM_UPDATE_HEADER[rfcTable_LT_HUM_UPDATE_HEADER.RowCount];
            int i_LT_HUM_UPDATE_HEADER = 0;
            foreach (IRfcStructure row in rfcTable_LT_HUM_UPDATE_HEADER)
            {
                ZMOV_50011_LT_HUM_UPDATE_HEADER datoTabla = new ZMOV_50011_LT_HUM_UPDATE_HEADER();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.FIELD_NAME = row.GetString("FIELD_NAME");
                datoTabla.FIELD_VALUE = row.GetString("FIELD_VALUE");
                res.LT_HUM_UPDATE_HEADER[i_LT_HUM_UPDATE_HEADER] = datoTabla; ++i_LT_HUM_UPDATE_HEADER;
            }
            IRfcTable rfcTable_LT_MESSAGES = rfcFunction.GetTable("LT_MESSAGES");
            res.LT_MESSAGES = new ZMOV_50011_LT_MESSAGES[rfcTable_LT_MESSAGES.RowCount];
            int i_LT_MESSAGES = 0;
            foreach (IRfcStructure row in rfcTable_LT_MESSAGES)
            {
                ZMOV_50011_LT_MESSAGES datoTabla = new ZMOV_50011_LT_MESSAGES();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.POSNR = row.GetInt("POSNR");
                datoTabla.HU_ITEM = row.GetString("HU_ITEM");
                datoTabla.ZEILE = row.GetInt("ZEILE");
                datoTabla.MSGID = row.GetString("MSGID");
                datoTabla.MSGTY = row.GetString("MSGTY");
                datoTabla.MSGNO = row.GetInt("MSGNO");
                datoTabla.MSGV1 = row.GetString("MSGV1");
                datoTabla.MSGV2 = row.GetString("MSGV2");
                datoTabla.MSGV3 = row.GetString("MSGV3");
                datoTabla.MSGV4 = row.GetString("MSGV4");
                res.LT_MESSAGES[i_LT_MESSAGES] = datoTabla; ++i_LT_MESSAGES;
            }

            return res;
        }
    }
    public class request_ZMOV_50011
    {
        //public String IT_EXIDV;
        public ZMOV_50011_IT_EXIDV[] IT_EXIDV; 
        public ZMOV_50011_LT_HUM_UPDATE_HEADER[] LT_HUM_UPDATE_HEADER;
    }
    public class responce_ZMOV_50011
    {
        public ZMOV_50011_IT_EXIDV[] IT_EXIDV;
        public ZMOV_50011_LT_HUM_UPDATE_HEADER[] LT_HUM_UPDATE_HEADER;
        public ZMOV_50011_LT_MESSAGES[] LT_MESSAGES;
    }
    public class ZMOV_50011_IT_EXIDV
    {
        public String EXIDV;
    }
    public class ZMOV_50011_LT_HUM_UPDATE_HEADER
    {
        public String EXIDV;
        public String FIELD_NAME;
        public String FIELD_VALUE;
    }
    public class ZMOV_50011_LT_MESSAGES
    {
        public String EXIDV;
        public Int32 POSNR;
        public String HU_ITEM;
        public Int32 ZEILE;
        public String MSGID;
        public String MSGTY;
        public Int32 MSGNO;
        public String MSGV1;
        public String MSGV2;
        public String MSGV3;
        public String MSGV4;
    }

}