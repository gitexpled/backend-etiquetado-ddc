using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_HU_MOVER
    {
        public responce_ZMOV_HU_MOVER sapRun(request_ZMOV_HU_MOVER import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_HU_MOVER");

            rfcFunction.SetValue("ALMACEN", import.ALMACEN);
            rfcFunction.SetValue("CENTRO", import.CENTRO);
            //rfcFunction.SetValue("EXIDV", import.EXIDV);
            IRfcTable rfcTable_EXIDV_I = rfcFunction.GetTable("EXIDV");
            foreach (ZMOV_HU_MOVER_EXIDV row in import.EXIDV)
            {
                rfcTable_EXIDV_I.Append();
                ZMOV_HU_MOVER_EXIDV datoTabla = new ZMOV_HU_MOVER_EXIDV();
                rfcTable_EXIDV_I.SetValue("EXIDV", row.EXIDV);
            }
            rfcFunction.SetValue("EXIDV", rfcTable_EXIDV_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_HU_MOVER res = new responce_ZMOV_HU_MOVER();
            IRfcTable rfcTable_EXIDV = rfcFunction.GetTable("EXIDV");
            res.EXIDV = new ZMOV_HU_MOVER_EXIDV[rfcTable_EXIDV.RowCount];
            int i_EXIDV = 0;
            foreach (IRfcStructure row in rfcTable_EXIDV)
            {
                ZMOV_HU_MOVER_EXIDV datoTabla = new ZMOV_HU_MOVER_EXIDV();
                datoTabla.EXIDV = row.GetString("EXIDV");
                res.EXIDV[i_EXIDV] = datoTabla; ++i_EXIDV;
            }
            IRfcTable rfcTable_MENSAJE2 = rfcFunction.GetTable("MENSAJE2");
            res.MENSAJE2 = new ZMOV_HU_MOVER_MENSAJE2[rfcTable_MENSAJE2.RowCount];
            int i_MENSAJE2 = 0;
            foreach (IRfcStructure row in rfcTable_MENSAJE2)
            {
                ZMOV_HU_MOVER_MENSAJE2 datoTabla = new ZMOV_HU_MOVER_MENSAJE2();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.POSNR = row.GetInt("POSNR");
                datoTabla.HU_ITEM = row.GetString("HU_ITEM");
                datoTabla.ZEILE = row.GetInt("ZEILE");
                datoTabla.MSGID = row.GetString("MSGID");
                datoTabla.MSGTY = row.GetString("MSGTY");
                datoTabla.MSGNO = row.GetInt("MSGNO");
                datoTabla.MSGV1 = row.GetString("MSGV1");
                datoTabla.MSGV2 = row.GetString("MSGV2");
                datoTabla.MSGV3 = row.GetString("MSGV3");
                datoTabla.MSGV4 = row.GetString("MSGV4");
                res.MENSAJE2[i_MENSAJE2] = datoTabla; ++i_MENSAJE2;
            }

            return res;
        }
    }
    public class request_ZMOV_HU_MOVER
    {
        public String ALMACEN;
        public String CENTRO;
        //public String EXIDV;
        public ZMOV_HU_MOVER_EXIDV[] EXIDV;
    }
    public class responce_ZMOV_HU_MOVER
    {
        public ZMOV_HU_MOVER_EXIDV[] EXIDV;
        public ZMOV_HU_MOVER_MENSAJE2[] MENSAJE2;
    }
    public class ZMOV_HU_MOVER_EXIDV
    {
        public String EXIDV;
    }
    public class ZMOV_HU_MOVER_MENSAJE2
    {
        public String EXIDV;
        public Int32 POSNR;
        public String HU_ITEM;
        public Int32 ZEILE;
        public String MSGID;
        public String MSGTY;
        public Int32 MSGNO;
        public String MSGV1;
        public String MSGV2;
        public String MSGV3;
        public String MSGV4;
    }

}