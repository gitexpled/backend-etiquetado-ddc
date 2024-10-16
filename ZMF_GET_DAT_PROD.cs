using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_GET_DAT_PROD
    {
        public responce_ZMF_GET_DAT_PROD sapRun(request_ZMF_GET_DAT_PROD import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_GET_DAT_PROD");

            rfcFunction.SetValue("I_ESPECIE", import.I_ESPECIE);
            rfcFunction.SetValue("I_LIFNR", import.I_LIFNR);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_GET_DAT_PROD res = new responce_ZMF_GET_DAT_PROD();
            //res.ET_PRODUCT = rfcFunction.GetString("ET_PRODUCT");
            IRfcTable rfcTable_ET_PRODUCT = rfcFunction.GetTable("ET_PRODUCT");
            res.ET_PRODUCT = new ZMF_GET_DAT_PROD_ET_PRODUCT[rfcTable_ET_PRODUCT.RowCount];
            int i_ET_PRODUCT = 0;
            foreach (IRfcStructure row in rfcTable_ET_PRODUCT)
            {
                ZMF_GET_DAT_PROD_ET_PRODUCT datoTabla = new ZMF_GET_DAT_PROD_ET_PRODUCT();
                //datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.NAME1 = row.GetString("NAME1");
                datoTabla.RUT = row.GetString("RUT");
                datoTabla.PROVINCIA = row.GetString("PROVINCIA");
                datoTabla.COMUNA = row.GetString("COMUNA");
                datoTabla.REGION = row.GetString("REGION");
                datoTabla.DIRECCION = row.GetString("DIRECCION");
                datoTabla.COD_CSG = row.GetString("COD_CSG");
                datoTabla.NUM_GGN = row.GetString("NUM_GGN");
                datoTabla.FEC_VAL = row.GetString("FEC_VAL");
                datoTabla.OBS = row.GetString("OBS");
                datoTabla.REGSS = row.GetString("REGSS");
                datoTabla.PFACH = row.GetString("PFACH");
                datoTabla.P_LIFNR = row.GetString("P_LIFNR");
                datoTabla.NOM_PREDIO = row.GetString("NOM_PREDIO");
                datoTabla.ULT_INGREDIENTE = row.GetString("ULT_INGREDIENTE");
                datoTabla.USUARIO_RESP = row.GetString("USUARIO_RESP");
                datoTabla.SMTP_ADDR = row.GetString("SMTP_ADDR");
                datoTabla.BRSCH = row.GetString("BRSCH");
                datoTabla.BRTXT = row.GetString("BRTXT");
                datoTabla.VIGENCIA = row.GetString("VIGENCIA");
                res.ET_PRODUCT[i_ET_PRODUCT] = datoTabla; ++i_ET_PRODUCT;
            }
            //res.ET_PROD_CU = rfcFunction.GetString("ET_PROD_CU");
            IRfcTable rfcTable_ET_PROD_CU = rfcFunction.GetTable("ET_PROD_CU");
            res.ET_PROD_CU = new ZMF_GET_DAT_PROD_ET_PROD_CU[rfcTable_ET_PROD_CU.RowCount];
            int i_ET_PROD_CU = 0;
            foreach (IRfcStructure row in rfcTable_ET_PROD_CU)
            {
                ZMF_GET_DAT_PROD_ET_PROD_CU datoTabla = new ZMF_GET_DAT_PROD_ET_PROD_CU();
                datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.POS = row.GetInt("POS");
                datoTabla.CU01 = row.GetString("CU01");
                res.ET_PROD_CU[i_ET_PROD_CU] = datoTabla; ++i_ET_PROD_CU;
            }
            //res.ET_PROD_IDG = rfcFunction.GetString("ET_PROD_IDG");
            IRfcTable rfcTable_ET_PROD_IDG = rfcFunction.GetTable("ET_PROD_IDG");
            res.ET_PROD_IDG = new ZMF_GET_DAT_PROD_ET_PROD_IDG[rfcTable_ET_PROD_IDG.RowCount];
            int i_ET_PROD_IDG = 0;
            foreach (IRfcStructure row in rfcTable_ET_PROD_IDG)
            {
                ZMF_GET_DAT_PROD_ET_PROD_IDG datoTabla = new ZMF_GET_DAT_PROD_ET_PROD_IDG();
                datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.POS = row.GetInt("POS");
                datoTabla.IDG = row.GetString("IDG");
                res.ET_PROD_IDG[i_ET_PROD_IDG] = datoTabla; ++i_ET_PROD_IDG;
            }
            //res.ET_PROD_IDP = rfcFunction.GetString("ET_PROD_IDP");
            IRfcTable rfcTable_ET_PROD_IDP = rfcFunction.GetTable("ET_PROD_IDP");
            res.ET_PROD_IDP = new ZMF_GET_DAT_PROD_ET_PROD_IDP[rfcTable_ET_PROD_IDP.RowCount];
            int i_ET_PROD_IDP = 0;
            foreach (IRfcStructure row in rfcTable_ET_PROD_IDP)
            {
                ZMF_GET_DAT_PROD_ET_PROD_IDP datoTabla = new ZMF_GET_DAT_PROD_ET_PROD_IDP();
                datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.POS = row.GetInt("POS");
                datoTabla.IDP = row.GetString("IDP");
                res.ET_PROD_IDP[i_ET_PROD_IDP] = datoTabla; ++i_ET_PROD_IDP;
            }
            //res.ET_PROD_SDP = rfcFunction.GetString("ET_PROD_SDP");
            IRfcTable rfcTable_ET_PROD_SDP = rfcFunction.GetTable("ET_PROD_SDP");
            res.ET_PROD_SDP = new ZMF_GET_DAT_PROD_ET_PROD_SDP[rfcTable_ET_PROD_SDP.RowCount];
            int i_ET_PROD_SDP = 0;
            foreach (IRfcStructure row in rfcTable_ET_PROD_SDP)
            {
                ZMF_GET_DAT_PROD_ET_PROD_SDP datoTabla = new ZMF_GET_DAT_PROD_ET_PROD_SDP();
                datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.POS = row.GetInt("POS");
                datoTabla.SDP = row.GetString("SDP");
                res.ET_PROD_SDP[i_ET_PROD_SDP] = datoTabla; ++i_ET_PROD_SDP;
            }
            //res.ET_PROD_VAR = rfcFunction.GetString("ET_PROD_VAR");
            IRfcTable rfcTable_ET_PROD_VAR = rfcFunction.GetTable("ET_PROD_VAR");
            res.ET_PROD_VAR = new ZMF_GET_DAT_PROD_ET_PROD_VAR[rfcTable_ET_PROD_VAR.RowCount];
            int i_ET_PROD_VAR = 0;
            foreach (IRfcStructure row in rfcTable_ET_PROD_VAR)
            {
                ZMF_GET_DAT_PROD_ET_PROD_VAR datoTabla = new ZMF_GET_DAT_PROD_ET_PROD_VAR();
                datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.POS = row.GetInt("POS");
                datoTabla.COD_VAR = row.GetString("COD_VAR");
                datoTabla.VAR = row.GetString("VAR");
                res.ET_PROD_VAR[i_ET_PROD_VAR] = datoTabla; ++i_ET_PROD_VAR;
            }

            return res;
        }
    }
    public class request_ZMF_GET_DAT_PROD
    {
        public String I_ESPECIE;
        public String I_LIFNR;
    }
    public class responce_ZMF_GET_DAT_PROD
    {
        //public String ET_PRODUCT;
        public ZMF_GET_DAT_PROD_ET_PRODUCT[] ET_PRODUCT;
        //public String ET_PROD_CU;
        public ZMF_GET_DAT_PROD_ET_PROD_CU[] ET_PROD_CU;
        //public String ET_PROD_IDG;
        public ZMF_GET_DAT_PROD_ET_PROD_IDG[] ET_PROD_IDG;
        //public String ET_PROD_IDP;
        public ZMF_GET_DAT_PROD_ET_PROD_IDP[] ET_PROD_IDP;
        //public String ET_PROD_SDP;
        public ZMF_GET_DAT_PROD_ET_PROD_SDP[] ET_PROD_SDP;
        //public String ET_PROD_VAR;
        public ZMF_GET_DAT_PROD_ET_PROD_VAR[] ET_PROD_VAR;
    }
    public class ZMF_GET_DAT_PROD_ET_PRODUCT
    {
        public String LIFNR;
        public String ESPECIE;
        public String NAME1;
        public String RUT;
        public String PROVINCIA;
        public String COMUNA;
        public String REGION;
        public String DIRECCION;
        public String COD_CSG;
        public String NUM_GGN;
        public String FEC_VAL;
        public String OBS;
        public String REGSS;
        public String PFACH;
        public String P_LIFNR;
        public String NOM_PREDIO;
        public String ULT_INGREDIENTE;
        public String USUARIO_RESP;
        public String SMTP_ADDR;
        public String BRSCH;
        public String BRTXT;
        public String VIGENCIA;
    }
    public class ZMF_GET_DAT_PROD_ET_PROD_CU
    {
        public String MANDT;
        public String LIFNR;
        public String ESPECIE;
        public Int32 POS;
        public String CU01;
    }
    public class ZMF_GET_DAT_PROD_ET_PROD_IDG
    {
        public String MANDT;
        public String LIFNR;
        public String ESPECIE;
        public Int32 POS;
        public String IDG;
    }
    public class ZMF_GET_DAT_PROD_ET_PROD_IDP
    {
        public String MANDT;
        public String LIFNR;
        public String ESPECIE;
        public Int32 POS;
        public String IDP;
    }
    public class ZMF_GET_DAT_PROD_ET_PROD_SDP
    {
        public String MANDT;
        public String LIFNR;
        public String ESPECIE;
        public Int32 POS;
        public String SDP;
    }
    public class ZMF_GET_DAT_PROD_ET_PROD_VAR
    {
        public String MANDT;
        public String LIFNR;
        public String ESPECIE;
        public Int32 POS;
        public String COD_VAR;
        public String VAR;
    }
}