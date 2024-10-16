using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_HU_DATOADICIONAL
    {
        public responce_ZMOV_QUERY_HU_DATOADICIONAL sapRun(request_ZMOV_QUERY_HU_DATOADICIONAL import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_HU_DATOADICIONAL");

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_HU_DATOADICIONAL res = new responce_ZMOV_QUERY_HU_DATOADICIONAL();
            IRfcTable rfcTable_CAMBAND = rfcFunction.GetTable("CAMBAND");
            res.CAMBAND = new ZMOV_QUERY_HU_DATOADICIONAL_CAMBAND[rfcTable_CAMBAND.RowCount];
            int i_CAMBAND = 0;
            foreach (IRfcStructure row in rfcTable_CAMBAND)
            {
                ZMOV_QUERY_HU_DATOADICIONAL_CAMBAND datoTabla = new ZMOV_QUERY_HU_DATOADICIONAL_CAMBAND();
                datoTabla.VEGR5 = row.GetString("VEGR5");
                datoTabla.VEGR5_CAMARA = row.GetString("VEGR5_CAMARA");
                datoTabla.VEGR5_BANDA = row.GetString("VEGR5_BANDA");
                datoTabla.BEZEI = row.GetString("BEZEI");
                res.CAMBAND[i_CAMBAND] = datoTabla; ++i_CAMBAND;
            }
            IRfcTable rfcTable_INHALT = rfcFunction.GetTable("INHALT");
            res.INHALT = new ZMOV_QUERY_HU_DATOADICIONAL_INHALT[rfcTable_INHALT.RowCount];
            int i_INHALT = 0;
            foreach (IRfcStructure row in rfcTable_INHALT)
            {
                ZMOV_QUERY_HU_DATOADICIONAL_INHALT datoTabla = new ZMOV_QUERY_HU_DATOADICIONAL_INHALT();
                datoTabla.INHALT = row.GetString("INHALT");
                res.INHALT[i_INHALT] = datoTabla; ++i_INHALT;
            }
            IRfcTable rfcTable_VEGR1 = rfcFunction.GetTable("VEGR1");
            res.VEGR1 = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR1[rfcTable_VEGR1.RowCount];
            int i_VEGR1 = 0;
            foreach (IRfcStructure row in rfcTable_VEGR1)
            {
                ZMOV_QUERY_HU_DATOADICIONAL_VEGR1 datoTabla = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR1();
                datoTabla.VEGR1 = row.GetString("VEGR1");
                datoTabla.BEZEI = row.GetString("BEZEI");
                res.VEGR1[i_VEGR1] = datoTabla; ++i_VEGR1;
            }
            IRfcTable rfcTable_VEGR2 = rfcFunction.GetTable("VEGR2");
            res.VEGR2 = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR2[rfcTable_VEGR2.RowCount];
            int i_VEGR2 = 0;
            foreach (IRfcStructure row in rfcTable_VEGR2)
            {
                ZMOV_QUERY_HU_DATOADICIONAL_VEGR2 datoTabla = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR2();
                datoTabla.VEGR2 = row.GetString("VEGR2");
                datoTabla.BEZEI = row.GetString("BEZEI");
                res.VEGR2[i_VEGR2] = datoTabla; ++i_VEGR2;
            }
            IRfcTable rfcTable_VEGR3 = rfcFunction.GetTable("VEGR3");
            res.VEGR3 = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR3[rfcTable_VEGR3.RowCount];
            int i_VEGR3 = 0;
            foreach (IRfcStructure row in rfcTable_VEGR3)
            {
                ZMOV_QUERY_HU_DATOADICIONAL_VEGR3 datoTabla = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR3();
                datoTabla.VEGR3 = row.GetString("VEGR3");
                datoTabla.BEZEI = row.GetString("BEZEI");
                res.VEGR3[i_VEGR3] = datoTabla; ++i_VEGR3;
            }
            IRfcTable rfcTable_VEGR4 = rfcFunction.GetTable("VEGR4");
            res.VEGR4 = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR4[rfcTable_VEGR4.RowCount];
            int i_VEGR4 = 0;
            foreach (IRfcStructure row in rfcTable_VEGR4)
            {
                ZMOV_QUERY_HU_DATOADICIONAL_VEGR4 datoTabla = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR4();
                datoTabla.VEGR4 = row.GetString("VEGR4");
                datoTabla.BEZEI = row.GetString("BEZEI");
                res.VEGR4[i_VEGR4] = datoTabla; ++i_VEGR4;
            }
            IRfcTable rfcTable_VEGR5 = rfcFunction.GetTable("VEGR5");
            res.VEGR5 = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR5[rfcTable_VEGR5.RowCount];
            int i_VEGR5 = 0;
            foreach (IRfcStructure row in rfcTable_VEGR5)
            {
                ZMOV_QUERY_HU_DATOADICIONAL_VEGR5 datoTabla = new ZMOV_QUERY_HU_DATOADICIONAL_VEGR5();
                datoTabla.VEGR5 = row.GetString("VEGR5");
                datoTabla.BEZEI = row.GetString("BEZEI");
                res.VEGR5[i_VEGR5] = datoTabla; ++i_VEGR5;
            }
            IRfcTable rfcTable_VHILM = rfcFunction.GetTable("VHILM");
            res.VHILM = new ZMOV_QUERY_HU_DATOADICIONAL_VHILM[rfcTable_VHILM.RowCount];
            int i_VHILM = 0;
            foreach (IRfcStructure row in rfcTable_VHILM)
            {
                ZMOV_QUERY_HU_DATOADICIONAL_VHILM datoTabla = new ZMOV_QUERY_HU_DATOADICIONAL_VHILM();
                datoTabla.VHILM = row.GetString("VHILM");
                datoTabla.TEXT = row.GetString("TEXT");
                res.VHILM[i_VHILM] = datoTabla; ++i_VHILM;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_HU_DATOADICIONAL
    {
    }
    public class responce_ZMOV_QUERY_HU_DATOADICIONAL
    {
        public ZMOV_QUERY_HU_DATOADICIONAL_CAMBAND[] CAMBAND;
        public ZMOV_QUERY_HU_DATOADICIONAL_INHALT[] INHALT;
        public ZMOV_QUERY_HU_DATOADICIONAL_VEGR1[] VEGR1;
        public ZMOV_QUERY_HU_DATOADICIONAL_VEGR2[] VEGR2;
        public ZMOV_QUERY_HU_DATOADICIONAL_VEGR3[] VEGR3;
        public ZMOV_QUERY_HU_DATOADICIONAL_VEGR4[] VEGR4;
        public ZMOV_QUERY_HU_DATOADICIONAL_VEGR5[] VEGR5;
        public ZMOV_QUERY_HU_DATOADICIONAL_VHILM[] VHILM;
    }
    public class ZMOV_QUERY_HU_DATOADICIONAL_CAMBAND
    {
        public String VEGR5;
        public String VEGR5_CAMARA;
        public String VEGR5_BANDA;
        public String BEZEI;
    }
    public class ZMOV_QUERY_HU_DATOADICIONAL_INHALT
    {
        public String INHALT;
    }
    public class ZMOV_QUERY_HU_DATOADICIONAL_VEGR1
    {
        public String VEGR1;
        public String BEZEI;
    }
    public class ZMOV_QUERY_HU_DATOADICIONAL_VEGR2
    {
        public String VEGR2;
        public String BEZEI;
    }
    public class ZMOV_QUERY_HU_DATOADICIONAL_VEGR3
    {
        public String VEGR3;
        public String BEZEI;
    }
    public class ZMOV_QUERY_HU_DATOADICIONAL_VEGR4
    {
        public String VEGR4;
        public String BEZEI;
    }
    public class ZMOV_QUERY_HU_DATOADICIONAL_VEGR5
    {
        public String VEGR5;
        public String BEZEI;
    }
    public class ZMOV_QUERY_HU_DATOADICIONAL_VHILM
    {
        public String VHILM;
        public String TEXT;
    }

}