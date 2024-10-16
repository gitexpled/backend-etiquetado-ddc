using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_40003
    {
        public responce_ZMOV_40003 sapRun(request_ZMOV_40003 import, RfcDestination configSap = null, RfcRepository SapRfcRepository = null)
        {


            bool directo = false;
            IRfcFunction rfcFunction = null;
            if (configSap == null)
            {

                directo = true;
                configSap = RfcDestinationManager.GetDestination("DDC");
                if (import.USER != "" && import.USER != null)
                {

                    RfcDestination destFinal = GET_DESTINO.pingWithSAPUserLogon(import.USER, import.PASS);

                    SapRfcRepository = destFinal.Repository;
                    rfcFunction = SapRfcRepository.CreateFunction("ZMOV_40003");
                    configSap = destFinal;
                }
                else
                {
                    configSap = RfcDestinationManager.GetDestination("DDC");
                    SapRfcRepository = configSap.Repository;
                    SapRfcRepository = configSap.Repository;
                    rfcFunction = SapRfcRepository.CreateFunction("ZMOV_40003");
                }
                RfcSessionManager.BeginContext(configSap);

            }


            IRfcTable rfcTable_IT_CHARG_I = rfcFunction.GetTable("IT_CHARG");
            foreach (ZMOV_40003_IT_CHARG row in import.IT_CHARG)
            {
                rfcTable_IT_CHARG_I.Append();
                ZMOV_40003_IT_CHARG datoTabla = new ZMOV_40003_IT_CHARG();
                rfcTable_IT_CHARG_I.SetValue("CHARG", row.CHARG);
            }
            rfcFunction.SetValue("IT_CHARG", rfcTable_IT_CHARG_I);


            IRfcTable rfcTable_IR_MATNR_I = rfcFunction.GetTable("IR_MATNR");
            if (import.IR_MATNR != null)
            {
                foreach (ZMOV_40003_IR_MATNR row in import.IR_MATNR)
                {
                    rfcTable_IR_MATNR_I.Append();
                    ZMOV_40003_IR_MATNR datoTabla = new ZMOV_40003_IR_MATNR();
                    rfcTable_IR_MATNR_I.SetValue("HIGH", row.HIGH);
                    rfcTable_IR_MATNR_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_MATNR_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_MATNR_I.SetValue("SIGN", row.SIGN);
                }
            }
            rfcFunction.SetValue("IR_MATNR", rfcTable_IR_MATNR_I);



            IRfcTable rfcTable_LT_CARACT_I = rfcFunction.GetTable("LT_CARACT");
            foreach (ZMOV_40003_LT_CARACT row in import.LT_CARACT)
            {
                rfcTable_LT_CARACT_I.Append();
                ZMOV_40003_LT_CARACT datoTabla = new ZMOV_40003_LT_CARACT();
                rfcTable_LT_CARACT_I.SetValue("BATCH", row.BATCH);
                rfcTable_LT_CARACT_I.SetValue("CHARACT", row.CHARACT);
                rfcTable_LT_CARACT_I.SetValue("VALUE_CHAR", row.VALUE_CHAR);
            }
            rfcFunction.SetValue("LT_CARACT", rfcTable_LT_CARACT_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_40003 res = new responce_ZMOV_40003();
            IRfcTable rfcTable_IT_CHARG = rfcFunction.GetTable("IT_CHARG");
            res.IT_CHARG = new ZMOV_40003_IT_CHARG[rfcTable_IT_CHARG.RowCount];
            int i_IT_CHARG = 0;
            foreach (IRfcStructure row in rfcTable_IT_CHARG)
            {
                ZMOV_40003_IT_CHARG datoTabla = new ZMOV_40003_IT_CHARG();
                datoTabla.CHARG = row.GetString("CHARG");
                res.IT_CHARG[i_IT_CHARG] = datoTabla; ++i_IT_CHARG;
            }
            //
            IRfcTable rfcTable_IR_MATNR = rfcFunction.GetTable("IR_MATNR");
            res.IR_MATNR = new ZMOV_40003_IR_MATNR[rfcTable_IR_MATNR.RowCount];
            int i_IR_MATNR = 0;
            foreach (IRfcStructure row in rfcTable_IR_MATNR)
            {
                ZMOV_40003_IR_MATNR datoTabla = new ZMOV_40003_IR_MATNR();
                datoTabla.HIGH = row.GetString("HIGH");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.LOW = row.GetString("LOW");
                res.IR_MATNR[i_IR_MATNR] = datoTabla; ++i_IR_MATNR;
            }
            //
            IRfcTable rfcTable_LT_CARACT = rfcFunction.GetTable("LT_CARACT");
            res.LT_CARACT = new ZMOV_40003_LT_CARACT[rfcTable_LT_CARACT.RowCount];
            int i_LT_CARACT = 0;
            foreach (IRfcStructure row in rfcTable_LT_CARACT)
            {
                ZMOV_40003_LT_CARACT datoTabla = new ZMOV_40003_LT_CARACT();
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.CHARACT = row.GetString("CHARACT");
                datoTabla.VALUE_CHAR = row.GetString("VALUE_CHAR");
                res.LT_CARACT[i_LT_CARACT] = datoTabla; ++i_LT_CARACT;
            }
            IRfcTable rfcTable_RETTAB_CHG = rfcFunction.GetTable("RETTAB_CHG");
            res.RETTAB_CHG = new ZMOV_40003_RETTAB_CHG[rfcTable_RETTAB_CHG.RowCount];
            int i_RETTAB_CHG = 0;
            foreach (IRfcStructure row in rfcTable_RETTAB_CHG)
            {
                ZMOV_40003_RETTAB_CHG datoTabla = new ZMOV_40003_RETTAB_CHG();
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
                res.RETTAB_CHG[i_RETTAB_CHG] = datoTabla; ++i_RETTAB_CHG;
            }
            IRfcTable rfcTable_RETTAC = rfcFunction.GetTable("RETTAC");
            res.RETTAC = new ZMOV_40003_RETTAC[rfcTable_RETTAC.RowCount];
            int i_RETTAC = 0;
            foreach (IRfcStructure row in rfcTable_RETTAC)
            {
                ZMOV_40003_RETTAC datoTabla = new ZMOV_40003_RETTAC();
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
                res.RETTAC[i_RETTAC] = datoTabla; ++i_RETTAC;
            }
            IRfcTable rfcTable_RETURN_MODCARACT = rfcFunction.GetTable("RETURN_MODCARACT");
            res.RETURN_MODCARACT = new ZMOV_40003_RETURN_MODCARACT[rfcTable_RETURN_MODCARACT.RowCount];
            int i_RETURN_MODCARACT = 0;
            foreach (IRfcStructure row in rfcTable_RETURN_MODCARACT)
            {
                ZMOV_40003_RETURN_MODCARACT datoTabla = new ZMOV_40003_RETURN_MODCARACT();
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
                res.RETURN_MODCARACT[i_RETURN_MODCARACT] = datoTabla; ++i_RETURN_MODCARACT;
            }

            if (directo)
            {
                BAPI_TRANSACTION.Commit(configSap);
                RfcSessionManager.EndContext(configSap);
            }


            return res;
        }
    }
    public class request_ZMOV_40003
    {
        public ZMOV_40003_IT_CHARG[] IT_CHARG;
        public ZMOV_40003_LT_CARACT[] LT_CARACT;
        public ZMOV_40003_IR_MATNR[] IR_MATNR;
        public String USER;
        public String PASS;
    }
    public class responce_ZMOV_40003
    {
        public bool RESULTADO_BAPI;
        public ZMOV_40003_IR_MATNR[] IR_MATNR;
        public ZMOV_40003_IT_CHARG[] IT_CHARG;
        public ZMOV_40003_LT_CARACT[] LT_CARACT;
        public ZMOV_40003_RETTAB_CHG[] RETTAB_CHG;
        public ZMOV_40003_RETTAC[] RETTAC;
        public ZMOV_40003_RETURN_MODCARACT[] RETURN_MODCARACT;
    }
    public class ZMOV_40003_IR_MATNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_40003_IT_CHARG
    {
        public String CHARG;
    }
    public class ZMOV_40003_LT_CARACT
    {
        public String BATCH;
        public String CHARACT;
        public String VALUE_CHAR;
    }
    public class ZMOV_40003_RETTAB_CHG
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
    public class ZMOV_40003_RETTAC
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
    public class ZMOV_40003_RETURN_MODCARACT
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