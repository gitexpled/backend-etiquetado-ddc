using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERYS_PRODUCT
    {
        public responce_ZMOV_QUERYS_PRODUCT sapRun(request_ZMOV_QUERYS_PRODUCT import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC2");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERYS_PRODUCT");
            
            IRfcTable rfcTable_IV_SORTL_I = rfcFunction.GetTable("IV_SORTL");
            foreach (ZMOV_QUERYS_PRODUCT_IV_SORTL row in import.IV_SORTL)
            {
                rfcTable_IV_SORTL_I.Append();
                ZMOV_QUERYS_PRODUCT_IV_SORTL datoTabla = new ZMOV_QUERYS_PRODUCT_IV_SORTL();
                rfcTable_IV_SORTL_I.SetValue("SIGN", row.SIGN);
                rfcTable_IV_SORTL_I.SetValue("OPTION", row.OPTION);
                rfcTable_IV_SORTL_I.SetValue("LOW", row.LOW);
                rfcTable_IV_SORTL_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("IV_SORTL", rfcTable_IV_SORTL_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERYS_PRODUCT res = new responce_ZMOV_QUERYS_PRODUCT();
            IRfcTable rfcTable_IV_SORTL = rfcFunction.GetTable("IV_SORTL");
            res.IV_SORTL = new ZMOV_QUERYS_PRODUCT_IV_SORTL[rfcTable_IV_SORTL.RowCount];
            int i_IV_SORTL = 0;
            foreach (IRfcStructure row in rfcTable_IV_SORTL)
            {
                ZMOV_QUERYS_PRODUCT_IV_SORTL datoTabla = new ZMOV_QUERYS_PRODUCT_IV_SORTL();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IV_SORTL[i_IV_SORTL] = datoTabla; ++i_IV_SORTL;
            }
            IRfcTable rfcTable_LT_DATA = rfcFunction.GetTable("LT_DATA");
            res.LT_DATA = new ZMOV_QUERYS_PRODUCT_LT_DATA[rfcTable_LT_DATA.RowCount];
            int i_LT_DATA = 0;
            foreach (IRfcStructure row in rfcTable_LT_DATA)
            {
                ZMOV_QUERYS_PRODUCT_LT_DATA datoTabla = new ZMOV_QUERYS_PRODUCT_LT_DATA();
                datoTabla.SORTL = row.GetString("SORTL");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.NAME = row.GetString("NAME");
                res.LT_DATA[i_LT_DATA] = datoTabla; ++i_LT_DATA;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERYS_PRODUCT
    {        
        public ZMOV_QUERYS_PRODUCT_IV_SORTL[] IV_SORTL;
    }
    public class responce_ZMOV_QUERYS_PRODUCT
    {
        public ZMOV_QUERYS_PRODUCT_IV_SORTL[] IV_SORTL;
        public ZMOV_QUERYS_PRODUCT_LT_DATA[] LT_DATA;
    }
    public class ZMOV_QUERYS_PRODUCT_IV_SORTL
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERYS_PRODUCT_LT_DATA
    {
        public String SORTL;
        public String LIFNR;
        public String NAME;
    }

}