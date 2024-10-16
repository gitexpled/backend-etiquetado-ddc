using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_PAGOS_PRODUCTORES
    {
        public responce_ZMF_PAGOS_PRODUCTORES sapRun(request_ZMF_PAGOS_PRODUCTORES import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_PAGOS_PRODUCTORES");

            rfcFunction.SetValue("I_DATE_FROM", import.I_DATE_FROM);
            rfcFunction.SetValue("I_DATE_TO", import.I_DATE_TO);
            rfcFunction.SetValue("I_RUT", import.I_RUT);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_PAGOS_PRODUCTORES res = new responce_ZMF_PAGOS_PRODUCTORES();
            res.E_ERROR = rfcFunction.GetString("E_ERROR");
            res.E_MSG = rfcFunction.GetString("E_MSG");
            IRfcTable rfcTable_ET_DOCUMENTOS = rfcFunction.GetTable("ET_DOCUMENTOS");
            res.ET_DOCUMENTOS = new ZMF_PAGOS_PRODUCTORES_ET_DOCUMENTOS[rfcTable_ET_DOCUMENTOS.RowCount];
            int i_ET_DOCUMENTOS = 0;
            foreach (IRfcStructure row in rfcTable_ET_DOCUMENTOS)
            {
                ZMF_PAGOS_PRODUCTORES_ET_DOCUMENTOS datoTabla = new ZMF_PAGOS_PRODUCTORES_ET_DOCUMENTOS();
                datoTabla.BUKRS = row.GetString("BUKRS");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.DOC_TYPE = row.GetString("DOC_TYPE");
                datoTabla.CLEAR_DATE = row.GetString("CLEAR_DATE");
                datoTabla.PSTNG_DATE = row.GetString("PSTNG_DATE");
                datoTabla.AMT_DOCCUR = row.GetDecimal("AMT_DOCCUR");
                datoTabla.LOC_CURRCY = row.GetString("LOC_CURRCY");
                datoTabla.LC_AMOUNT = row.GetDecimal("LC_AMOUNT");
                res.ET_DOCUMENTOS[i_ET_DOCUMENTOS] = datoTabla; ++i_ET_DOCUMENTOS;
            }

            return res;
        }
    }
    public class request_ZMF_PAGOS_PRODUCTORES
    {
        public String I_DATE_FROM;
        public String I_DATE_TO;
        public String I_RUT;
    }
    public class responce_ZMF_PAGOS_PRODUCTORES
    {
        public String E_ERROR;
        public String E_MSG;
        public ZMF_PAGOS_PRODUCTORES_ET_DOCUMENTOS[] ET_DOCUMENTOS;
    }
    public class ZMF_PAGOS_PRODUCTORES_ET_DOCUMENTOS
    {
        public String BUKRS;
        public String LIFNR;
        public String DOC_TYPE;
        public String PSTNG_DATE;
        public String CLEAR_DATE;
        public Decimal AMT_DOCCUR;
        public String LOC_CURRCY;
        public Decimal LC_AMOUNT;
    }

}