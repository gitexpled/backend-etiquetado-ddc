using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10037
    {
        public responce_ZMOV_10037 sapRun(request_ZMOV_10037 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10041");

            IRfcTable rfcTable_IT_NUMTRA_I = rfcFunction.GetTable("IT_NUMTRA");
            if (import.IT_NUMTRA != null)
            {
                foreach (ZMOV_10037_IT_NUMTRA row in import.IT_NUMTRA)
                {
                    rfcTable_IT_NUMTRA_I.Append();
                    ZMOV_10037_IT_NUMTRA datoTabla = new ZMOV_10037_IT_NUMTRA();
                    rfcTable_IT_NUMTRA_I.SetValue("ZZ_NUMTRA", row.ZZ_NUMTRA);
                }
            }           
            rfcFunction.SetValue("IT_NUMTRA", rfcTable_IT_NUMTRA_I);

            IRfcTable rfcTable_IT_FECTRA_I = rfcFunction.GetTable("IT_FECTRA");
            if (import.IT_FECTRA != null)
            {
                foreach (ZMOV_10037_IT_FECTRA row in import.IT_FECTRA)
                {
                    rfcTable_IT_FECTRA_I.Append();
                    ZMOV_10037_IT_FECTRA datoTabla = new ZMOV_10037_IT_FECTRA();
                    rfcTable_IT_FECTRA_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IT_FECTRA_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IT_FECTRA_I.SetValue("LOW", row.LOW);
                    rfcTable_IT_FECTRA_I.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("IT_FECTRA", rfcTable_IT_FECTRA_I);

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10037 res = new responce_ZMOV_10037();
            IRfcTable rfcTable_ET_HU = rfcFunction.GetTable("ET_HU");
            res.ET_HU = new ZMOV_10037_ET_HU[rfcTable_ET_HU.RowCount];
            int i_ET_HU = 0;
            foreach (IRfcStructure row in rfcTable_ET_HU)
            {
                ZMOV_10037_ET_HU datoTabla = new ZMOV_10037_ET_HU();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.VENUM = row.GetString("VENUM");
                datoTabla.ZZ_TRATAM = row.GetString("ZZ_TRATAM");
                datoTabla.ZZ_NUMTRA = row.GetString("ZZ_NUMTRA");
                datoTabla.ZZ_FECTRA = row.GetString("ZZ_FECTRA");
                datoTabla.ZZ_MOTTRA = row.GetString("ZZ_MOTTRA");
                datoTabla.ZZ_PROD = row.GetString("ZZ_PROD");
                res.ET_HU[i_ET_HU] = datoTabla; ++i_ET_HU;
            }
            IRfcTable rfcTable_IT_NUMTRA = rfcFunction.GetTable("IT_NUMTRA");
            res.IT_NUMTRA = new ZMOV_10037_IT_NUMTRA[rfcTable_IT_NUMTRA.RowCount];
            int i_IT_NUMTRA = 0;
            foreach (IRfcStructure row in rfcTable_IT_NUMTRA)
            {
                ZMOV_10037_IT_NUMTRA datoTabla = new ZMOV_10037_IT_NUMTRA();
                datoTabla.ZZ_NUMTRA = row.GetString("ZZ_NUMTRA");
                res.IT_NUMTRA[i_IT_NUMTRA] = datoTabla; ++i_IT_NUMTRA;
            }

            return res;
        }
    }
    public class request_ZMOV_10037
    {
        public ZMOV_10037_IT_NUMTRA[] IT_NUMTRA;
        public ZMOV_10037_IT_FECTRA[] IT_FECTRA;
    }
    public class responce_ZMOV_10037
    {
        public ZMOV_10037_ET_HU[] ET_HU;
        public ZMOV_10037_IT_NUMTRA[] IT_NUMTRA;
    }
    public class ZMOV_10037_ET_HU
    {
        public String EXIDV;
        public String VENUM;
        public String ZZ_TRATAM;
        public String ZZ_NUMTRA;
        public String ZZ_FECTRA;
        public String ZZ_MOTTRA;
        public String ZZ_PROD;
    }
    public class ZMOV_10037_IT_NUMTRA
    {
        public String ZZ_NUMTRA;
    }

    public class ZMOV_10037_IT_FECTRA
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }

}