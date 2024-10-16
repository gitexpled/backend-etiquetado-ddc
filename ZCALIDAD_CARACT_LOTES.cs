using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZCALIDAD_CARACT_LOTES
    {
        public responce_ZCALIDAD_CARACT_LOTES sapRun(request_ZCALIDAD_CARACT_LOTES import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZCALIDAD_CARACT_LOTES");

          //  rfcFunction.SetValue("IT_CARACT", import.IT_CARACT);
            IRfcTable rfcTable_IT_CARACT_I = rfcFunction.GetTable("IT_CARACT");
            foreach (ZCALIDAD_CARACT_LOTES_IT_CARACT row in import.IT_CARACT)
            {
                rfcTable_IT_CARACT_I.Append();
                ZCALIDAD_CARACT_LOTES_IT_CARACT datoTabla = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                rfcTable_IT_CARACT_I.SetValue("CHARG", row.CHARG);
                rfcTable_IT_CARACT_I.SetValue("ESPECIE", row.ESPECIE);
                rfcTable_IT_CARACT_I.SetValue("CALIDAD", row.CALIDAD);
                rfcTable_IT_CARACT_I.SetValue("VALOR", row.VALOR);
            }
            rfcFunction.SetValue("IT_CARACT", rfcTable_IT_CARACT_I);
            rfcFunction.SetValue("I_SAVE", import.I_SAVE);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZCALIDAD_CARACT_LOTES res = new responce_ZCALIDAD_CARACT_LOTES();
             
            IRfcTable rfcTable_ET_CARACT = rfcFunction.GetTable("ET_CARACT");
            res.ET_CARACT = new ZCALIDAD_CARACT_LOTES_ET_CARACT[rfcTable_ET_CARACT.RowCount];
            int i_ET_CARACT = 0;
            foreach (IRfcStructure row in rfcTable_ET_CARACT)
            {
                ZCALIDAD_CARACT_LOTES_ET_CARACT datoTabla = new ZCALIDAD_CARACT_LOTES_ET_CARACT();
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.VALOR = row.GetString("VALOR");
                res.ET_CARACT[i_ET_CARACT] = datoTabla; ++i_ET_CARACT;
            }
            IRfcTable rfcTable_IT_CARACT = rfcFunction.GetTable("IT_CARACT");
            res.IT_CARACT = new ZCALIDAD_CARACT_LOTES_IT_CARACT[rfcTable_IT_CARACT.RowCount];
            int i_IT_CARACT = 0;
            foreach (IRfcStructure row in rfcTable_IT_CARACT)
            {
                ZCALIDAD_CARACT_LOTES_IT_CARACT datoTabla = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.VALOR = row.GetString("VALOR");
                res.IT_CARACT[i_IT_CARACT] = datoTabla; ++i_IT_CARACT;
            }

            return res;
        }
    }
    public class request_ZCALIDAD_CARACT_LOTES
    {
        
        public ZCALIDAD_CARACT_LOTES_IT_CARACT[] IT_CARACT;
        public String I_SAVE;
    }
    public class responce_ZCALIDAD_CARACT_LOTES
    {
         
        public ZCALIDAD_CARACT_LOTES_ET_CARACT[] ET_CARACT;
        public ZCALIDAD_CARACT_LOTES_IT_CARACT[] IT_CARACT;
    }
    public class ZCALIDAD_CARACT_LOTES_ET_CARACT
    {
        public String CHARG;
        public String ESPECIE;
        public String CALIDAD;
        public String VALOR;
    }
    public class ZCALIDAD_CARACT_LOTES_IT_CARACT
    {
        public String CHARG;
        public String ESPECIE;
        public String CALIDAD;
        public String VALOR;
    }

}