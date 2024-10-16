using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class RFC_READ_TABLE
    {
        public responce_RFC_READ_TABLE sapRun(request_RFC_READ_TABLE import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("RFC_READ_TABLE");

            rfcFunction.SetValue("DELIMITER", import.DELIMITER);
            rfcFunction.SetValue("NO_DATA", import.NO_DATA);
            rfcFunction.SetValue("QUERY_TABLE", import.QUERY_TABLE);
            rfcFunction.SetValue("ROWCOUNT", import.ROWCOUNT);
            rfcFunction.SetValue("ROWSKIPS", import.ROWSKIPS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_RFC_READ_TABLE res = new responce_RFC_READ_TABLE();
            IRfcTable rfcTable_DATA = rfcFunction.GetTable("DATA");
            res.DATA = new RFC_READ_TABLE_DATA[rfcTable_DATA.RowCount];
            int i_DATA = 0;
            foreach (IRfcStructure row in rfcTable_DATA)
            {
                RFC_READ_TABLE_DATA datoTabla = new RFC_READ_TABLE_DATA();
                datoTabla.WA = row.GetString("WA");
                res.DATA[i_DATA] = datoTabla; ++i_DATA;
            }
            IRfcTable rfcTable_FIELDS = rfcFunction.GetTable("FIELDS");
            res.FIELDS = new RFC_READ_TABLE_FIELDS[rfcTable_FIELDS.RowCount];
            int i_FIELDS = 0;
            foreach (IRfcStructure row in rfcTable_FIELDS)
            {
                RFC_READ_TABLE_FIELDS datoTabla = new RFC_READ_TABLE_FIELDS();
                datoTabla.FIELDNAME = row.GetString("FIELDNAME");
                datoTabla.OFFSET = row.GetInt("OFFSET");
                datoTabla.LENGTH = row.GetInt("LENGTH");
                datoTabla.TYPE = row.GetString("TYPE");
                datoTabla.FIELDTEXT = row.GetString("FIELDTEXT");
                res.FIELDS[i_FIELDS] = datoTabla; ++i_FIELDS;
            }
            IRfcTable rfcTable_OPTIONS = rfcFunction.GetTable("OPTIONS");
            res.OPTIONS = new RFC_READ_TABLE_OPTIONS[rfcTable_OPTIONS.RowCount];
            int i_OPTIONS = 0;
            foreach (IRfcStructure row in rfcTable_OPTIONS)
            {
                RFC_READ_TABLE_OPTIONS datoTabla = new RFC_READ_TABLE_OPTIONS();
                datoTabla.TEXT = row.GetString("TEXT");
                res.OPTIONS[i_OPTIONS] = datoTabla; ++i_OPTIONS;
            }

            return res;
        }
    }
    public class request_RFC_READ_TABLE
    {
        public String DELIMITER;
        public String NO_DATA;
        public String QUERY_TABLE;
        public Int32 ROWCOUNT;
        public Int32 ROWSKIPS;
    }
    public class responce_RFC_READ_TABLE
    {
        public RFC_READ_TABLE_DATA[] DATA;
        public RFC_READ_TABLE_FIELDS[] FIELDS;
        public RFC_READ_TABLE_OPTIONS[] OPTIONS;
    }
    public class RFC_READ_TABLE_DATA
    {
        public String WA;
    }
    public class RFC_READ_TABLE_FIELDS
    {
        public String FIELDNAME;
        public Int32 OFFSET;
        public Int32 LENGTH;
        public String TYPE;
        public String FIELDTEXT;
    }
    public class RFC_READ_TABLE_OPTIONS
    {
        public String TEXT;
    }

}