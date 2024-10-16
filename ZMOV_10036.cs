using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10036
    {
        public responce_ZMOV_10036 sapRun(request_ZMOV_10036 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10036");
            IRfcTable rfcTable_RG_KUNNR_I = rfcFunction.GetTable("RG_KUNNR");
            foreach (ZMOV_10036_RG_KUNNR row in import.RG_KUNNR)
            {
                rfcTable_RG_KUNNR_I.Append();
                ZMOV_10036_RG_KUNNR datoTabla = new ZMOV_10036_RG_KUNNR();
                rfcTable_RG_KUNNR_I.SetValue("SIGN", row.SIGN);
                rfcTable_RG_KUNNR_I.SetValue("OPTION", row.OPTION);
                rfcTable_RG_KUNNR_I.SetValue("LOW", row.LOW);
                rfcTable_RG_KUNNR_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("RG_KUNNR", rfcTable_RG_KUNNR_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10036 res = new responce_ZMOV_10036();
            IRfcTable rfcTable_E_RESULT = rfcFunction.GetTable("E_RESULT");
            res.E_RESULT = new ZMOV_10036_E_RESULT[rfcTable_E_RESULT.RowCount];
            int i_E_RESULT = 0;
            foreach (IRfcStructure row in rfcTable_E_RESULT)
            {
                ZMOV_10036_E_RESULT datoTabla = new ZMOV_10036_E_RESULT();
                datoTabla.KUNNR = row.GetString("KUNNR");
                datoTabla.NAME1 = row.GetString("NAME1");
                datoTabla.AUDAT = row.GetString("AUDAT");
                datoTabla.AUART = row.GetString("AUART");
                datoTabla.VBELN = row.GetString("VBELN");
                datoTabla.BSTKD = row.GetString("BSTKD");
                datoTabla.NETWR = row.GetDecimal("NETWR");
                datoTabla.WAERK = row.GetString("WAERK");
                datoTabla.GBSTK = row.GetString("GBSTK");
                res.E_RESULT[i_E_RESULT] = datoTabla; ++i_E_RESULT;
            }

            return res;
        }
    }
    public class request_ZMOV_10036
    {
        public ZMOV_10036_RG_KUNNR[] RG_KUNNR;
    }
    public class responce_ZMOV_10036
    {
        public ZMOV_10036_E_RESULT[] E_RESULT;
    }
    public class ZMOV_10036_RG_AUART
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10036_RG_AUDAT
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10036_RG_GBSTK
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10036_RG_KUNNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10036_RG_MATNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10036_RG_VBELN
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10036_E_RESULT
    {
        public String KUNNR;
        public String NAME1;
        public String AUDAT;
        public String AUART;
        public String VBELN;
        public String BSTKD;
        public Decimal NETWR;
        public String WAERK;
        public String GBSTK;
    }

}