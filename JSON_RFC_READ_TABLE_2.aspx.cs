using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_RFC_READ_TABLE_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String TABLA = Request["TABLA"].ToString();
            String SEPARADOR = Request["SEPARADOR"].ToString();
            String OPTIONS_S = ((Request["OPTIONS"] != null) ? Request["OPTIONS"].ToString() : "[]");
            String FIELDS_S = ((Request["FIELDS"] != null) ? Request["FIELDS"].ToString() : "[]");
            dynamic OPTIONS = JsonConvert.DeserializeObject(OPTIONS_S);
            dynamic FIELDS = JsonConvert.DeserializeObject(FIELDS_S);
            RFC_READ_TABLE_2 sap = new RFC_READ_TABLE_2();
            request_RFC_READ_TABLE_2 imp = new request_RFC_READ_TABLE_2();
            responce_RFC_READ_TABLE_2 obj = null;
            imp.DELIMITER = SEPARADOR;
            imp.QUERY_TABLE = TABLA;
            imp.OPTIONS = new RFC_READ_TABLE_OPTIONS_2[OPTIONS.Count];
            imp.FIELDS = new RFC_READ_TABLE_FIELDS_2[FIELDS.Count];
            int x = 0;
            foreach (dynamic item in OPTIONS)
            {
                imp.OPTIONS[x] = new RFC_READ_TABLE_OPTIONS_2();
                imp.OPTIONS[x].TEXT = item.TEXT;
                x++;
            }
            int i = 0;
            foreach (dynamic item in FIELDS)
            {
                imp.FIELDS[i] = new RFC_READ_TABLE_FIELDS_2();
                imp.FIELDS[i].FIELDNAME = item.FIELDNAME;
                imp.FIELDS[i].OFFSET = item.OFFSET;
                imp.FIELDS[i].LENGTH = item.LENGTH;
                imp.FIELDS[i].TYPE = item.TYPE;
                imp.FIELDS[i].FIELDTEXT = item.FIELDTEXT;
                i++;
            }
            obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}