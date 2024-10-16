using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_UPDATE_HU_CABECERA
    {
        public responce_ZMOV_UPDATE_HU_CABECERA sapRun(request_ZMOV_UPDATE_HU_CABECERA import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_UPDATE_HU_CABECERA");

            RfcStructureMetadata obj_ZMOV_ST_HDR_HU_MOD = SapRfcRepository.GetStructureMetadata("ZMOV_ST_HDR_HU_MOD");
            IRfcStructure datos_ZMOV_ST_HDR_HU_MOD = obj_ZMOV_ST_HDR_HU_MOD.CreateStructure();
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("EXT_ID_HU_2", import.HUCHANGED.EXT_ID_HU_2);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("CONTENT", import.HUCHANGED.CONTENT);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("PACK_MAT_CUSTOMER", import.HUCHANGED.PACK_MAT_CUSTOMER);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("PACKAGE_CAT", import.HUCHANGED.PACKAGE_CAT);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("KZGVH", import.HUCHANGED.KZGVH);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("HU_GRP1", import.HUCHANGED.HU_GRP1);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("HU_GRP2", import.HUCHANGED.HU_GRP2);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("HU_GRP3", import.HUCHANGED.HU_GRP3);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("HU_GRP4", import.HUCHANGED.HU_GRP4);
            datos_ZMOV_ST_HDR_HU_MOD.SetValue("HU_GRP5", import.HUCHANGED.HU_GRP5);
            rfcFunction.SetValue("HUCHANGED", datos_ZMOV_ST_HDR_HU_MOD);
            rfcFunction.SetValue("HUKEY", import.HUKEY);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_UPDATE_HU_CABECERA res = new responce_ZMOV_UPDATE_HU_CABECERA();
            IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
            res.RETURN = new ZMOV_UPDATE_HU_CABECERA_RETURN[rfcTable_RETURN.RowCount];
            int i_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_RETURN)
            {
                ZMOV_UPDATE_HU_CABECERA_RETURN datoTabla = new ZMOV_UPDATE_HU_CABECERA_RETURN();
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
                res.RETURN[i_RETURN] = datoTabla; ++i_RETURN;
            }

            return res;
        }
    }
    public class request_ZMOV_UPDATE_HU_CABECERA
    {
        public ZMOV_UPDATE_HU_CABECERA_HUCHANGED HUCHANGED;
        public String HUKEY;
    }
    public class responce_ZMOV_UPDATE_HU_CABECERA
    {
        public ZMOV_UPDATE_HU_CABECERA_RETURN[] RETURN;
    }
    public class ZMOV_UPDATE_HU_CABECERA_HUCHANGED
    {
        public String EXT_ID_HU_2;
        public String CONTENT;
        public String PACK_MAT_CUSTOMER;
        public String PACKAGE_CAT;
        public String KZGVH;
        public String HU_GRP1;
        public String HU_GRP2;
        public String HU_GRP3;
        public String HU_GRP4;
        public String HU_GRP5;
    }
    public class ZMOV_UPDATE_HU_CABECERA_RETURN
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