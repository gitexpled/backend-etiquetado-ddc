using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class RFC_READ_TABLE_2
    {
        public responce_RFC_READ_TABLE_2 sapRun(request_RFC_READ_TABLE_2 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("RFC_READ_TABLE");

            rfcFunction.SetValue("DELIMITER", import.DELIMITER);
            rfcFunction.SetValue("NO_DATA", import.NO_DATA);
            rfcFunction.SetValue("QUERY_TABLE", import.QUERY_TABLE);
            rfcFunction.SetValue("ROWCOUNT", import.ROWCOUNT);
            rfcFunction.SetValue("ROWSKIPS", import.ROWSKIPS);
            IRfcTable rfcTable_FIELDS_I = rfcFunction.GetTable("FIELDS");
            if (import.FIELDS != null)
            {
                foreach (RFC_READ_TABLE_FIELDS_2 row in import.FIELDS)
                {
                    rfcTable_FIELDS_I.Append();
                    RFC_READ_TABLE_FIELDS_2 datoTabla = new RFC_READ_TABLE_FIELDS_2();
                    rfcTable_FIELDS_I.SetValue("FIELDNAME", row.FIELDNAME);
                    rfcTable_FIELDS_I.SetValue("OFFSET", row.OFFSET);
                    rfcTable_FIELDS_I.SetValue("LENGTH", row.LENGTH);
                    rfcTable_FIELDS_I.SetValue("TYPE", row.TYPE);
                    rfcTable_FIELDS_I.SetValue("FIELDTEXT", row.FIELDTEXT);
                }
            }
            IRfcTable rfcTable_OPTIONS_I = rfcFunction.GetTable("OPTIONS");
            if (import.OPTIONS != null)
            {
                foreach (RFC_READ_TABLE_OPTIONS_2 row in import.OPTIONS)
                {
                    rfcTable_OPTIONS_I.Append();
                    RFC_READ_TABLE_OPTIONS_2 datoTabla = new RFC_READ_TABLE_OPTIONS_2();
                    rfcTable_OPTIONS_I.SetValue("TEXT", row.TEXT);
                }
            }


            rfcFunction.SetValue("OPTIONS", rfcTable_OPTIONS_I);
            rfcFunction.SetValue("FIELDS", rfcTable_FIELDS_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_RFC_READ_TABLE_2 res = new responce_RFC_READ_TABLE_2();
            IRfcTable rfcTable_DATA = rfcFunction.GetTable("DATA");
            res.DATA = new RFC_READ_TABLE_DATA_2[rfcTable_DATA.RowCount];
            int i_DATA = 0;


            foreach (IRfcStructure row in rfcTable_DATA)
            {
                RFC_READ_TABLE_DATA_2 datoTabla = new RFC_READ_TABLE_DATA_2();
                //datoTabla.WA = row.GetString("WA").Replace(" ", "").Split(char.Parse(import.DELIMITER));
                datoTabla.WA = row.GetString("WA").Split(char.Parse(import.DELIMITER));
                res.DATA[i_DATA] = datoTabla; ++i_DATA;
            }
            IRfcTable rfcTable_FIELDS = rfcFunction.GetTable("FIELDS");
            res.FIELDS = new RFC_READ_TABLE_FIELDS_2[rfcTable_FIELDS.RowCount];
            int i_FIELDS = 0;
            foreach (IRfcStructure row in rfcTable_FIELDS)
            {
                RFC_READ_TABLE_FIELDS_2 datoTabla = new RFC_READ_TABLE_FIELDS_2();
                datoTabla.FIELDNAME = row.GetString("FIELDNAME");
                datoTabla.OFFSET = row.GetInt("OFFSET");
                datoTabla.LENGTH = row.GetInt("LENGTH");
                datoTabla.TYPE = row.GetString("TYPE");
                datoTabla.FIELDTEXT = row.GetString("FIELDTEXT");
                res.FIELDS[i_FIELDS] = datoTabla; ++i_FIELDS;
            }
            IRfcTable rfcTable_OPTIONS = rfcFunction.GetTable("OPTIONS");
            res.OPTIONS = new RFC_READ_TABLE_OPTIONS_2[rfcTable_OPTIONS.RowCount];
            int i_OPTIONS = 0;
            foreach (IRfcStructure row in rfcTable_OPTIONS)
            {
                RFC_READ_TABLE_OPTIONS_2 datoTabla = new RFC_READ_TABLE_OPTIONS_2();
                datoTabla.TEXT = row.GetString("TEXT");
                res.OPTIONS[i_OPTIONS] = datoTabla; ++i_OPTIONS;
            }

            return res;
        }
    }
    public class request_RFC_READ_TABLE_2
    {
        public String DELIMITER;
        public String NO_DATA;
        public String QUERY_TABLE;
        public Int32 ROWCOUNT;
        public Int32 ROWSKIPS;
        public RFC_READ_TABLE_OPTIONS_2[] OPTIONS;
        public RFC_READ_TABLE_FIELDS_2[] FIELDS;
    }
    public class responce_RFC_READ_TABLE_2
    {
        public RFC_READ_TABLE_DATA_2[] DATA;
        public RFC_READ_TABLE_FIELDS_2[] FIELDS;
        public RFC_READ_TABLE_OPTIONS_2[] OPTIONS;
    }
    public class RFC_READ_TABLE_DATA_2
    {
        public String[] WA;
    }
    public class RFC_READ_TABLE_FIELDS_2
    {
        public String FIELDNAME;
        public Int32 OFFSET;
        public Int32 LENGTH;
        public String TYPE;
        public String FIELDTEXT;
    }
    public class RFC_READ_TABLE_OPTIONS_2
    {
        public String TEXT;
    }

}