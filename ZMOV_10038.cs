using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10038
    {
        public responce_ZMOV_10038 sapRun(request_ZMOV_10038 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10042");

            IRfcTable rfcTable_IT_HU_I = rfcFunction.GetTable("IT_HU");
            foreach (ZMOV_10038_IT_HU row in import.IT_HU)
            {
                rfcTable_IT_HU_I.Append();
                ZMOV_10038_IT_HU datoTabla = new ZMOV_10038_IT_HU();
                rfcTable_IT_HU_I.SetValue("EXIDV", row.EXIDV);
                rfcTable_IT_HU_I.SetValue("VENUM", row.VENUM);
                rfcTable_IT_HU_I.SetValue("ZZ_TRATAM", row.ZZ_TRATAM);
                rfcTable_IT_HU_I.SetValue("ZZ_NUMTRA", row.ZZ_NUMTRA);
                rfcTable_IT_HU_I.SetValue("ZZ_FECTRA", row.ZZ_FECTRA);
                rfcTable_IT_HU_I.SetValue("ZZ_MOTTRA", row.ZZ_MOTTRA);
                rfcTable_IT_HU_I.SetValue("ZZ_PROD", row.ZZ_PROD);
            }
            rfcFunction.SetValue("IT_HU", rfcTable_IT_HU_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10038 res = new responce_ZMOV_10038();
            IRfcTable rfcTable_ET_MSG = rfcFunction.GetTable("ET_MSG");
            res.ET_MSG = new ZMOV_10038_ET_MSG[rfcTable_ET_MSG.RowCount];
            int i_ET_MSG = 0;
            foreach (IRfcStructure row in rfcTable_ET_MSG)
            {
                ZMOV_10038_ET_MSG datoTabla = new ZMOV_10038_ET_MSG();
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
                res.ET_MSG[i_ET_MSG] = datoTabla; ++i_ET_MSG;
            }
            IRfcTable rfcTable_IT_HU = rfcFunction.GetTable("IT_HU");
            res.IT_HU = new ZMOV_10038_IT_HU[rfcTable_IT_HU.RowCount];
            int i_IT_HU = 0;
            foreach (IRfcStructure row in rfcTable_IT_HU)
            {
                ZMOV_10038_IT_HU datoTabla = new ZMOV_10038_IT_HU();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.VENUM = row.GetString("VENUM");
                datoTabla.ZZ_TRATAM = row.GetString("ZZ_TRATAM");
                datoTabla.ZZ_NUMTRA = row.GetString("ZZ_NUMTRA");
                res.IT_HU[i_IT_HU] = datoTabla; ++i_IT_HU;
            }

            return res;
        }
    }
    public class request_ZMOV_10038
    {
        public ZMOV_10038_IT_HU[] IT_HU;
    }
    public class responce_ZMOV_10038
    {
        public ZMOV_10038_ET_MSG[] ET_MSG;
        public ZMOV_10038_IT_HU[] IT_HU;
    }
    public class ZMOV_10038_ET_MSG
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
    public class ZMOV_10038_IT_HU
    {
        public String EXIDV;
        public String VENUM;
        public String ZZ_TRATAM;
        public String ZZ_NUMTRA;
        public String ZZ_FECTRA;
        public String ZZ_MOTTRA;
        public String ZZ_PROD;
    }

}