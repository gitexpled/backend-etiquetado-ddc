using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class BAPI_GOODSMVT_CANCEL
    {
        public responce_BAPI_GOODSMVT_CANCEL sapRun(request_BAPI_GOODSMVT_CANCEL import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("BAPI_GOODSMVT_CANCEL");

            RfcSessionManager.BeginContext(configSap);

            rfcFunction.SetValue("DOCUMENTHEADER_TEXT", import.DOCUMENTHEADER_TEXT);
            rfcFunction.SetValue("GOODSMVT_PR_UNAME", import.GOODSMVT_PR_UNAME);
            rfcFunction.SetValue("GOODSMVT_PSTNG_DATE", import.GOODSMVT_PSTNG_DATE);
            rfcFunction.SetValue("MATDOCUMENTYEAR", import.MATDOCUMENTYEAR);
            rfcFunction.SetValue("MATERIALDOCUMENT", import.MATERIALDOCUMENT);
            rfcFunction.Invoke(configSap);
            responce_BAPI_GOODSMVT_CANCEL res = new responce_BAPI_GOODSMVT_CANCEL();
            try
            {
                string aa = rfcFunction.ToString();

                IRfcTable rfcTable_GOODSMVT_MATDOCITEM = rfcFunction.GetTable("GOODSMVT_MATDOCITEM");
                res.GOODSMVT_MATDOCITEM = new BAPI_GOODSMVT_CANCEL_GOODSMVT_MATDOCITEM[rfcTable_GOODSMVT_MATDOCITEM.RowCount];
                int i_GOODSMVT_MATDOCITEM = 0;
                foreach (IRfcStructure row in rfcTable_GOODSMVT_MATDOCITEM)
                {
                    BAPI_GOODSMVT_CANCEL_GOODSMVT_MATDOCITEM datoTabla = new BAPI_GOODSMVT_CANCEL_GOODSMVT_MATDOCITEM();
                    datoTabla.MATDOC_ITEM = row.GetInt("MATDOC_ITEM");
                    res.GOODSMVT_MATDOCITEM[i_GOODSMVT_MATDOCITEM] = datoTabla; ++i_GOODSMVT_MATDOCITEM;
                }

                IRfcStructure rfcStruct_HEADRET = rfcFunction.GetStructure("GOODSMVT_HEADRET");

                res.HEADRET = new rfcBaika.BAPI_GOODSMVT_CANCEL_GOODSMVT_HEADRET();


                res.HEADRET.MATDOC_ITEM = rfcStruct_HEADRET.GetString("MAT_DOC");
                res.HEADRET.MATDOC_YEAR = rfcStruct_HEADRET.GetInt("DOC_YEAR");

                IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
                res.RETURN = new BAPI_GOODSMVT_CANCEL_RETURN[rfcTable_RETURN.RowCount];
                int i_RETURN = 0;
                foreach (IRfcStructure row in rfcTable_RETURN)
                {
                    BAPI_GOODSMVT_CANCEL_RETURN datoTabla = new BAPI_GOODSMVT_CANCEL_RETURN();
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


                BAPI_TRANSACTION.Commit(configSap);
                RfcSessionManager.EndContext(configSap);
                return res;
            }
            catch (Exception)
            {
                BAPI_TRANSACTION.Rollback(configSap);
                RfcSessionManager.EndContext(configSap);
                return res;

            }
        }
    }
    public class request_BAPI_GOODSMVT_CANCEL
    {
        public String DOCUMENTHEADER_TEXT;
        public String GOODSMVT_PR_UNAME;
        public String GOODSMVT_PSTNG_DATE;
        public Int32 MATDOCUMENTYEAR;
        public String MATERIALDOCUMENT;
    }
    public class responce_BAPI_GOODSMVT_CANCEL
    {
        public BAPI_GOODSMVT_CANCEL_GOODSMVT_MATDOCITEM[] GOODSMVT_MATDOCITEM;
        public BAPI_GOODSMVT_CANCEL_RETURN[] RETURN;
        public BAPI_GOODSMVT_CANCEL_GOODSMVT_HEADRET HEADRET;
        public bool RESULTADO_BAPI = false;
        public string DOCUMENTO;


    }


    public class BAPI_GOODSMVT_CANCEL_GOODSMVT_HEADRET
    {
        public String MATDOC_ITEM;
        public Int32 MATDOC_YEAR;
    }

    public class BAPI_GOODSMVT_CANCEL_GOODSMVT_MATDOCITEM
    {
        public Int32 MATDOC_ITEM;
    }
    public class BAPI_GOODSMVT_CANCEL_RETURN
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