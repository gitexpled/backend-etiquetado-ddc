﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_GET_TIPIFICACION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String especie = Request["e"].ToString();
            DB_ECO_GET_TIPIFICACION db = new DB_ECO_GET_TIPIFICACION();
            request_ECO_GET_TIPIFICACION req = new request_ECO_GET_TIPIFICACION();
            req.ESPECIE = especie;
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}