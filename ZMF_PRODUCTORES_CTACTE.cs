using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_PRODUCTORES_CTACTE
    {
        public responce_ZMF_PRODUCTORES_CTACTE sapRun(request_ZMF_PRODUCTORES_CTACTE import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_PRODUCTORES_CTACTE");

            rfcFunction.SetValue("I_DATE_FROM", import.I_DATE_FROM);
            rfcFunction.SetValue("I_DATE_TO", import.I_DATE_TO);
            rfcFunction.SetValue("I_RUT", import.I_RUT);
            rfcFunction.SetValue("I_TIPO", import.I_TIPO);
            rfcFunction.SetValue("I_TEMPORADA", import.I_TEMPORADA);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_PRODUCTORES_CTACTE res = new responce_ZMF_PRODUCTORES_CTACTE();
            res.E_ERROR = rfcFunction.GetString("E_ERROR");
            res.E_MSG = rfcFunction.GetString("E_MSG");
            IRfcTable rfcTable_ET_DOCUMENTOS = rfcFunction.GetTable("ET_DOCUMENTOS");
            res.ET_DOCUMENTOS = new ZMF_PRODUCTORES_CTACTE_ET_DOCUMENTOS[rfcTable_ET_DOCUMENTOS.RowCount];
            int i_ET_DOCUMENTOS = 0;
            foreach (IRfcStructure row in rfcTable_ET_DOCUMENTOS)
            {
                ZMF_PRODUCTORES_CTACTE_ET_DOCUMENTOS datoTabla = new ZMF_PRODUCTORES_CTACTE_ET_DOCUMENTOS();
                datoTabla.BUKRS = row.GetString("BUKRS");
                datoTabla.RUT = row.GetString("RUT");
                datoTabla.FISC_YEAR = row.GetInt("FISC_YEAR");
                datoTabla.FIS_PERIOD = row.GetInt("FIS_PERIOD");
                datoTabla.PSTNG_DATE = row.GetString("PSTNG_DATE");
                datoTabla.REF_DOC_NO = row.GetString("REF_DOC_NO");
                datoTabla.DOC_TYPE = row.GetString("DOC_TYPE");
                datoTabla.CURRENCY = row.GetString("CURRENCY");
                datoTabla.AMT_DOCCUR = row.GetDecimal("AMT_DOCCUR");
                datoTabla.LOC_CURRCY = row.GetString("LOC_CURRCY");
                datoTabla.LC_AMOUNT = row.GetDecimal("LC_AMOUNT");
                datoTabla.DMBE2 = row.GetDecimal("DMBE2");
                datoTabla.ITEM_TEXT = row.GetString("ITEM_TEXT");
                datoTabla.HWAE2 = row.GetString("HWAE2");
                res.ET_DOCUMENTOS[i_ET_DOCUMENTOS] = datoTabla; ++i_ET_DOCUMENTOS;
            }
            IRfcTable rfcTable_ET_RESUMEN = rfcFunction.GetTable("ET_RESUMEN");
            res.ET_RESUMEN = new ZMF_PRODUCTORES_CTACTE_ET_RESUMEN[rfcTable_ET_RESUMEN.RowCount];
            int i_ET_RESUMEN = 0;
            foreach (IRfcStructure row in rfcTable_ET_RESUMEN)
            {
                ZMF_PRODUCTORES_CTACTE_ET_RESUMEN datoTabla = new ZMF_PRODUCTORES_CTACTE_ET_RESUMEN();
                datoTabla.TEMPORADA = row.GetString("TEMPORADA");
                datoTabla.NOMBRE_TEMPORADA = row.GetString("NOMBRE_TEMPORADA");
                datoTabla.CONCEPTO = row.GetString("CONCEPTO");
                datoTabla.NOMBRE_CONCEPTO = row.GetString("NOMBRE_CONCEPTO");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.NOMBRE_ESPECIE = row.GetString("NOMBRE_ESPECIE");
                datoTabla.CURRENCY = row.GetString("CURRENCY");
                datoTabla.AMT_DOCCUR = row.GetDecimal("AMT_DOCCUR");
                datoTabla.LOC_CURRCY = row.GetString("LOC_CURRCY");
                datoTabla.LC_AMOUNT = row.GetDecimal("LC_AMOUNT");
                datoTabla.DMBE2 = row.GetDecimal("DMBE2");
                datoTabla.HWAE2 = row.GetString("HWAE2");
                res.ET_RESUMEN[i_ET_RESUMEN] = datoTabla; ++i_ET_RESUMEN;
            }

            return res;
        }
    }
    public class request_ZMF_PRODUCTORES_CTACTE
    {
        public String I_DATE_FROM;
        public String I_DATE_TO;
        public String I_RUT;
        public String I_TIPO;
        public String I_TEMPORADA;
    }
    public class responce_ZMF_PRODUCTORES_CTACTE
    {
        public String E_ERROR;
        public String E_MSG;
        public ZMF_PRODUCTORES_CTACTE_ET_DOCUMENTOS[] ET_DOCUMENTOS;
        public ZMF_PRODUCTORES_CTACTE_ET_RESUMEN[] ET_RESUMEN;
    }
    public class ZMF_PRODUCTORES_CTACTE_ET_DOCUMENTOS
    {
        public String BUKRS;
        public String RUT;
        public Int32 FISC_YEAR;
        public Int32 FIS_PERIOD;
        public String PSTNG_DATE;
        public String REF_DOC_NO;
        public String DOC_TYPE;
        public String CURRENCY;
        public Decimal AMT_DOCCUR;
        public String LOC_CURRCY;
        public Decimal LC_AMOUNT;
        public Decimal DMBE2;
        public String ITEM_TEXT;
        public String HWAE2;
    }
    public class ZMF_PRODUCTORES_CTACTE_ET_RESUMEN
    {
        public String TEMPORADA;
        public String NOMBRE_TEMPORADA;
        public String CONCEPTO;
        public String NOMBRE_CONCEPTO;
        public String ESPECIE;
        public String NOMBRE_ESPECIE;
        public String CURRENCY;
        public Decimal AMT_DOCCUR;
        public String LOC_CURRCY;
        public Decimal LC_AMOUNT;
        public Decimal DMBE2;
        public String HWAE2;
    }

}