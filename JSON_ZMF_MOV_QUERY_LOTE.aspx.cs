﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public partial class JSON_ZMF_MOV_QUERY_LOTE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String IR_CHARG = "";
            if (Request["IR_CHARG"] != null)
            {
                IR_CHARG = Request["IR_CHARG"].ToString();
            }

            ZMF_MOV_QUERY_LOTE sap = new ZMF_MOV_QUERY_LOTE();
            request_ZMF_MOV_QUERY_LOTE imp = new request_ZMF_MOV_QUERY_LOTE();
            ZMF_MOV_QUERY_LOTE_IR_CHARG[] dat = new ZMF_MOV_QUERY_LOTE_IR_CHARG[1];
            dat[0] = new ZMF_MOV_QUERY_LOTE_IR_CHARG();
            dat[0].HIGH = "";
            dat[0].LOW = IR_CHARG;
            dat[0].OPTION = "EQ";
            dat[0].SIGN = "I";
            imp.IR_CHARG = dat;
            responce_ZMF_MOV_QUERY_LOTE obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}