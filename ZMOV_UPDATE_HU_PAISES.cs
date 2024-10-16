using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_UPDATE_HU_PAISES
    {
        public responce_ZMOV_UPDATE_HU_PAISES sapRun(request_ZMOV_UPDATE_HU_PAISES import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_UPDATE_HU_PAISES");

            RfcStructureMetadata obj_ZZSTR_VEKP = SapRfcRepository.GetStructureMetadata("ZZSTR_VEKP");
            IRfcStructure datos_ZZSTR_VEKP = obj_ZZSTR_VEKP.CreateStructure();
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP1", import.IS_PAISES.ZZPAIS_INSP1);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP2", import.IS_PAISES.ZZPAIS_INSP2);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP3", import.IS_PAISES.ZZPAIS_INSP3);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP4", import.IS_PAISES.ZZPAIS_INSP4);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP5", import.IS_PAISES.ZZPAIS_INSP5);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP6", import.IS_PAISES.ZZPAIS_INSP6);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP7", import.IS_PAISES.ZZPAIS_INSP7);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP8", import.IS_PAISES.ZZPAIS_INSP8);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP9", import.IS_PAISES.ZZPAIS_INSP9);
            datos_ZZSTR_VEKP.SetValue("ZZPAIS_INSP10", import.IS_PAISES.ZZPAIS_INSP10);
            datos_ZZSTR_VEKP.SetValue("ZZFEC_INSP", import.IS_PAISES.ZZFEC_INSP);
            datos_ZZSTR_VEKP.SetValue("ZZEST_INSP", import.IS_PAISES.ZZEST_INSP);
            rfcFunction.SetValue("IS_PAISES", datos_ZZSTR_VEKP);
            rfcFunction.SetValue("I_EST_INSP", import.I_EST_INSP);
            rfcFunction.SetValue("I_EXIDV2", import.I_EXIDV2);
            rfcFunction.SetValue("I_FECINSP", import.I_FECINSP);
            RfcStructureMetadata obj_ZZSTR_PAISES = SapRfcRepository.GetStructureMetadata("ZZSTR_PAISES");
            IRfcStructure datos_ZZSTR_PAISES = obj_ZZSTR_PAISES.CreateStructure();
            datos_ZZSTR_PAISES.SetValue("ZZPAIS_INSP11", import.IS_PAISES2.ZZPAIS_INSP11);
            datos_ZZSTR_PAISES.SetValue("ZZPAIS_INSP12", import.IS_PAISES2.ZZPAIS_INSP12);
            datos_ZZSTR_PAISES.SetValue("ZZPAIS_INSP13", import.IS_PAISES2.ZZPAIS_INSP13);
            datos_ZZSTR_PAISES.SetValue("ZZPAIS_INSP14", import.IS_PAISES2.ZZPAIS_INSP14);
            datos_ZZSTR_PAISES.SetValue("ZZPAIS_INSP15", import.IS_PAISES2.ZZPAIS_INSP15);
            rfcFunction.SetValue("IS_PAISES2", datos_ZZSTR_PAISES);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_UPDATE_HU_PAISES res = new responce_ZMOV_UPDATE_HU_PAISES();
            IRfcTable rfcTable_ET_RETURN = rfcFunction.GetTable("ET_RETURN");
            res.ET_RETURN = new ZMOV_UPDATE_HU_PAISES_ET_RETURN[rfcTable_ET_RETURN.RowCount];
            int i_ET_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_ET_RETURN)
            {
                ZMOV_UPDATE_HU_PAISES_ET_RETURN datoTabla = new ZMOV_UPDATE_HU_PAISES_ET_RETURN();
                datoTabla.TYPE = row.GetString("TYPE");
                datoTabla.ID = row.GetString("ID");
                datoTabla.NUMBER = row.GetInt("NUMBER");
                datoTabla.MESSAGE = row.GetString("MESSAGE");
                datoTabla.LOG_NO = row.GetString("LOG_NO");
                datoTabla.LOG_MSG_NO = row.GetInt("LOG_MSG_NO");
                datoTabla.MESSAGE_V1 = row.GetString("MESSAGE_V1");
                datoTabla.MESSAGE_V2 = row.GetString("MESSAGE_V2");
                datoTabla.MESSAGE_V3 = row.GetString("MESSAGE_V3");
                datoTabla.MESSAGE_V4 = row.GetString("MESSAGE_V4");
                datoTabla.PARAMETER = row.GetString("PARAMETER");
                datoTabla.ROW = row.GetInt("ROW");
                datoTabla.FIELD = row.GetString("FIELD");
                datoTabla.SYSTEM = row.GetString("SYSTEM");
                res.ET_RETURN[i_ET_RETURN] = datoTabla; ++i_ET_RETURN;
            }

            return res;
        }
    }
    public class request_ZMOV_UPDATE_HU_PAISES
    {
        public ZMOV_UPDATE_HU_PAISES_IS_PAISES IS_PAISES;
        public ZMOV_UPDATE_HU_PAISES_IS_PAISES2 IS_PAISES2;
        public String I_EST_INSP;
        public String I_EXIDV2;
        public String I_FECINSP;
    }
    public class responce_ZMOV_UPDATE_HU_PAISES
    {
        public ZMOV_UPDATE_HU_PAISES_ET_RETURN[] ET_RETURN;
    }
    public class ZMOV_UPDATE_HU_PAISES_IS_PAISES
    {
        public String ZZPAIS_INSP1;
        public String ZZPAIS_INSP2;
        public String ZZPAIS_INSP3;
        public String ZZPAIS_INSP4;
        public String ZZPAIS_INSP5;
        public String ZZPAIS_INSP6;
        public String ZZPAIS_INSP7;
        public String ZZPAIS_INSP8;
        public String ZZPAIS_INSP9;
        public String ZZPAIS_INSP10;
        public String ZZFEC_INSP;
        public String ZZEST_INSP;
    }

    public class ZMOV_UPDATE_HU_PAISES_IS_PAISES2
    {
        public String ZZPAIS_INSP11;
        public String ZZPAIS_INSP12;
        public String ZZPAIS_INSP13;
        public String ZZPAIS_INSP14;
        public String ZZPAIS_INSP15;
    }
    public class ZMOV_UPDATE_HU_PAISES_ET_RETURN
    {
        public String TYPE;
        public String ID;
        public Int32 NUMBER;
        public String MESSAGE;
        public String LOG_NO;
        public Int32 LOG_MSG_NO;
        public String MESSAGE_V1;
        public String MESSAGE_V2;
        public String MESSAGE_V3;
        public String MESSAGE_V4;
        public String PARAMETER;
        public Int32 ROW;
        public String FIELD;
        public String SYSTEM;
    }

}