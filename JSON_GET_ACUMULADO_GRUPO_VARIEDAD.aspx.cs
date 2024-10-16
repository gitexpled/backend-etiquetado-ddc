﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_GET_ACUMULADO_GRUPO_VARIEDAD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String variedad = Request["GRUPO"].ToString();
            String productor = Request["PRODUCTOR"].ToString();
            String lote = Request["LOTE"].ToString();
            DB_PORTAL db = new DB_PORTAL();

            Array res = db.GetAcumuladoGrupoVariedad(variedad, productor, lote);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}