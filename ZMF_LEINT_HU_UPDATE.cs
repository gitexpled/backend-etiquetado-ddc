using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_LEINT_HU_UPDATE
    {
        public responce_ZMF_LEINT_HU_UPDATE sapRun(request_ZMF_LEINT_HU_UPDATE import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_LEINT_HU_UPDATE");

            IRfcTable rfcTable_CT_HU_VALUE_I = rfcFunction.GetTable("CT_HU_VALUE");
            foreach (ZMF_LEINT_HU_UPDATE_CT_HU_VALUE row in import.CT_HU_VALUE)
            {
                rfcTable_CT_HU_VALUE_I.Append();
                ZMF_LEINT_HU_UPDATE_CT_HU_VALUE datoTabla = new ZMF_LEINT_HU_UPDATE_CT_HU_VALUE();
                rfcTable_CT_HU_VALUE_I.SetValue("HDL_UNIT_ITID", row.HDL_UNIT_ITID);
                rfcTable_CT_HU_VALUE_I.SetValue("HDL_UNIT_EXID", row.HDL_UNIT_EXID);
                rfcTable_CT_HU_VALUE_I.SetValue("FIELD_NAME", row.FIELD_NAME);
                rfcTable_CT_HU_VALUE_I.SetValue("FIELD_VALUE", row.FIELD_VALUE);
            }
            rfcFunction.SetValue("CT_HU_VALUE", rfcTable_CT_HU_VALUE_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_LEINT_HU_UPDATE res = new responce_ZMF_LEINT_HU_UPDATE();
            IRfcTable rfcTable_CT_HU_VALUE = rfcFunction.GetTable("CT_HU_VALUE");
            res.CT_HU_VALUE = new ZMF_LEINT_HU_UPDATE_CT_HU_VALUE[rfcTable_CT_HU_VALUE.RowCount];
            int i_CT_HU_VALUE = 0;
            foreach (IRfcStructure row in rfcTable_CT_HU_VALUE)
            {
                ZMF_LEINT_HU_UPDATE_CT_HU_VALUE datoTabla = new ZMF_LEINT_HU_UPDATE_CT_HU_VALUE();
                datoTabla.HDL_UNIT_ITID = row.GetString("HDL_UNIT_ITID");
                datoTabla.HDL_UNIT_EXID = row.GetString("HDL_UNIT_EXID");
                datoTabla.FIELD_NAME = row.GetString("FIELD_NAME");
                datoTabla.FIELD_VALUE = row.GetString("FIELD_VALUE");
                res.CT_HU_VALUE[i_CT_HU_VALUE] = datoTabla; ++i_CT_HU_VALUE;
            }
            res.E_MSG = rfcFunction.GetString("E_MSG");

            return res;
        }
    }
    public class request_ZMF_LEINT_HU_UPDATE
    {
        public ZMF_LEINT_HU_UPDATE_CT_HU_VALUE[] CT_HU_VALUE;
    }
    public class responce_ZMF_LEINT_HU_UPDATE
    {
        public ZMF_LEINT_HU_UPDATE_CT_HU_VALUE[] CT_HU_VALUE;
        public String E_MSG;
    }
    public class ZMF_LEINT_HU_UPDATE_CT_HU_VALUE
    {
        public String HDL_UNIT_ITID;
        public String HDL_UNIT_EXID;
        public String FIELD_NAME;
        public String FIELD_VALUE;
    }

}