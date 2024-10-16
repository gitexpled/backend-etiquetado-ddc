﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_INSERTA_PROCESO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String centro = Request["c"].ToString();
            String proceso = Request["p"].ToString();
            String estado = Request["e"].ToString();
            String Consulta = Request["con"].ToString();
            String planta = Request["pl"].ToString();
            String productor = Request["pr"].ToString();
            String especie = Request["es"].ToString();
            String variedad = Request["var"].ToString();
            String material = Request["ma"].ToString();
            String kilos = "0";
            DB_INSERTA_PROCESO etiq = new DB_INSERTA_PROCESO();
            request_DB_INSERTA_PROCESO consulta = new request_DB_INSERTA_PROCESO();
            consulta.centro = centro;
            consulta.estado = estado;
            consulta.proceso = proceso;
            consulta.kilos = kilos;
            consulta.Consulta = Consulta;
            consulta.planta = planta;
            consulta.productor = productor;
            consulta.especie = especie;
            consulta.variedad = variedad;
            consulta.material = material;
            responce_DB_INSERTA_PROCESO res = etiq.run(consulta);
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }
    }
}