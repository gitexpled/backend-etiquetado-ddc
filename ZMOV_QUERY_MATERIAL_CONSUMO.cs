using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_MATERIAL_CONSUMO
    {
        public responce_ZMOV_QUERY_MATERIAL_CONSUMO sapRun(request_ZMOV_QUERY_MATERIAL_CONSUMO import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_MATERIAL_CONSUMO");

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_MATERIAL_CONSUMO res = new responce_ZMOV_QUERY_MATERIAL_CONSUMO();
            IRfcTable rfcTable_MATERIALES = rfcFunction.GetTable("MATERIALES");
            res.MATERIALES = new ZMOV_QUERY_MATERIAL_CONSUMO_MATERIALES[rfcTable_MATERIALES.RowCount];
            int i_MATERIALES = 0;
            foreach (IRfcStructure row in rfcTable_MATERIALES)
            {
                ZMOV_QUERY_MATERIAL_CONSUMO_MATERIALES datoTabla = new ZMOV_QUERY_MATERIAL_CONSUMO_MATERIALES();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTG = row.GetString("MAKTG");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.MTART = row.GetString("MTART");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.ZMAT_ESPECIE = row.GetString("ZMAT_ESPECIE");
                datoTabla.ZMAT_VIGENTE = row.GetString("ZMAT_VIGENTE");
                datoTabla.MENGE = row.GetString("MENGE");
                res.MATERIALES[i_MATERIALES] = datoTabla; ++i_MATERIALES;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_MATERIAL_CONSUMO
    {
    }
    public class responce_ZMOV_QUERY_MATERIAL_CONSUMO
    {
        public ZMOV_QUERY_MATERIAL_CONSUMO_MATERIALES[] MATERIALES;
    }
    public class ZMOV_QUERY_MATERIAL_CONSUMO_MATERIALES
    {
        public String MATNR;
        public String MAKTG;
        public String WERKS;
        public String MTART;
        public String MEINS;
        public String ZMAT_ESPECIE;
        public String ZMAT_VIGENTE;
        public String MENGE;
    }

}