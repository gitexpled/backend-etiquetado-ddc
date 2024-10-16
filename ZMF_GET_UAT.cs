using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_GET_UAT
    {
        public responce_ZMF_GET_UAT sapRun(request_ZMF_GET_UAT import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_GET_UAT");

            /*rfcFunction.SetValue("IT_AUT", import.IT_AUT);
            IRfcTable rfcTable_IT_AUT_I = rfcFunction.GetTable("IT_AUT");
            foreach (ZMF_GET_UAT_IT_AUT row in import.IT_AUT)
            {
                rfcTable_IT_AUT_I.Append();
                ZMF_GET_UAT_IT_AUT datoTabla = new ZMF_GET_UAT_IT_AUT();
                rfcTable_IT_AUT_I.SetValue("OBJNUM", row.OBJNUM);
            }
            rfcFunction.SetValue("IT_AUT", rfcTable_IT_AUT_I);*/
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_GET_UAT res = new responce_ZMF_GET_UAT();
            //res.ET_AUT = rfcFunction.GetTable("ET_AUT");
            IRfcTable rfcTable_ET_AUT = rfcFunction.GetTable("ET_AUT");
            res.ET_AUT = new ZMF_GET_UAT_ET_AUT[rfcTable_ET_AUT.RowCount];
            int i_ET_AUT = 0;
            foreach (IRfcStructure row in rfcTable_ET_AUT)
            {
                ZMF_GET_UAT_ET_AUT datoTabla = new ZMF_GET_UAT_ET_AUT();
                datoTabla.UAT = row.GetString("UAT");
                datoTabla.ATWRT = row.GetString("ATWRT");
                datoTabla.KLART = row.GetString("KLART");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.CROP = row.GetString("CROP");
                datoTabla.PROCESSING_PLANT = row.GetString("PROCESSING_PLANT");
                datoTabla.PROCESSING_STORAGE = row.GetString("PROCESSING_STORAGE");
                datoTabla.HARVEST_MATERIAL = row.GetString("HARVEST_MATERIAL");
                datoTabla.YARD_MATERIAL = row.GetString("YARD_MATERIAL");
                datoTabla.RECEIVER_MATERIAL = row.GetString("RECEIVER_MATERIAL");
                datoTabla.AUFNR_HM = row.GetString("AUFNR_HM");
                datoTabla.AUFNR_YM = row.GetString("AUFNR_YM");
                datoTabla.BUKRS_HM = row.GetString("BUKRS_HM");
                datoTabla.BUKRS_YM = row.GetString("BUKRS_YM");
                datoTabla.WERKS_HM = row.GetString("WERKS_HM");
                datoTabla.WERKS_YM = row.GetString("WERKS_YM");
                datoTabla.OBJNR = row.GetString("OBJNR");
                res.ET_AUT[i_ET_AUT] = datoTabla; ++i_ET_AUT;
            }
            IRfcTable rfcTable_IT_AUT = rfcFunction.GetTable("IT_AUT");
            res.IT_AUT = new ZMF_GET_UAT_IT_AUT[rfcTable_IT_AUT.RowCount];
            int i_IT_AUT = 0;
            foreach (IRfcStructure row in rfcTable_IT_AUT)
            {
                ZMF_GET_UAT_IT_AUT datoTabla = new ZMF_GET_UAT_IT_AUT();
                datoTabla.OBJNUM = row.GetString("OBJNUM");
                res.IT_AUT[i_IT_AUT] = datoTabla; ++i_IT_AUT;
            }

            return res;
        }
    }
    public class request_ZMF_GET_UAT
    {
        //public String IT_AUT;
        public ZMF_GET_UAT_IT_AUT[] IT_AUT;
    }
    public class responce_ZMF_GET_UAT
    {
        
        public ZMF_GET_UAT_ET_AUT[] ET_AUT;
        public ZMF_GET_UAT_IT_AUT[] IT_AUT;
    }
    public class ZMF_GET_UAT_ET_AUT
    {
        public String UAT;
        public String ATWRT;
        public String KLART;
        public String PRODUCTOR;
        public String CROP;
        public String PROCESSING_PLANT;
        public String PROCESSING_STORAGE;
        public String HARVEST_MATERIAL;
        public String YARD_MATERIAL;
        public String RECEIVER_MATERIAL;
        public String AUFNR_HM;
        public String AUFNR_YM;
        public String BUKRS_HM;
        public String BUKRS_YM;
        public String WERKS_HM;
        public String WERKS_YM;
        public String OBJNR;
    }
    public class ZMF_GET_UAT_IT_AUT
    {
        public String OBJNUM;
    }

}