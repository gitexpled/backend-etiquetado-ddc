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
    public partial class JSON_ZMOV_QUERY_LIST_MATER : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String I_MATNR = "";
            if (Request["I_MATNR"] != null)
            {
                I_MATNR = Request["I_MATNR"].ToString();
            }
            String I_WERKS = "";
            if (Request["I_WERKS"] != null)
            {
                I_WERKS = Request["I_WERKS"].ToString();
            }

            ZMOV_QUERY_LIST_MATER sap = new ZMOV_QUERY_LIST_MATER();
            request_ZMOV_QUERY_LIST_MATER imp = new request_ZMOV_QUERY_LIST_MATER();
            imp.I_MATNR = I_MATNR;
            imp.I_WERKS = I_WERKS;
            responce_ZMOV_QUERY_LIST_MATER obj = sap.sapRun(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();
        }
    }
}