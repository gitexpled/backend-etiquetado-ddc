﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_INFORME_ESTIMACION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_ECO_INFORME_ESTIMACION db = new DB_ECO_INFORME_ESTIMACION();
            request_ECO_INFORME_ESTIMACION req = new request_ECO_INFORME_ESTIMACION();
            req.TEMPORADA = Request["t"].ToString();
            req.ESTIMACION = Request["e"].ToString();
            req.PRODUCTOR = Request["p"].ToString();
            req.ESPECIE = Request["es"].ToString();
            req.VARIEDAD = Request["v"].ToString();
            Array resp = db.run(req);
            //var json2 = new JavaScriptSerializer().Serialize(resp);
            var json2 = new JavaScriptSerializer();
            json2.MaxJsonLength = Int32.MaxValue; 
            json.Text = json2.Serialize(resp).ToString();
        }

       
    }
}