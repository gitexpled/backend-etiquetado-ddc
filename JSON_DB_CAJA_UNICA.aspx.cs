using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_CAJA_UNICA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Numero_Unico = Request["nu"].ToString();
            String Lote_Proceso = Request["lp"].ToString();
            String Kilos = Request["K"].ToString();
            String Calibre = Request["C"].ToString();
            String Linea = Request["L"].ToString();
            String Turno = Request["T"].ToString();
            String Salida = Request["S"].ToString();
            String Material = Request["M"].ToString();
            String Especie = Request["E"].ToString();
            String Variedad = Request["V"].ToString();
            String Codigo_Productor = Request["CP"].ToString();
            String Fecha_Creacion = Request["FC"].ToString();
            String Hora_Creacion = Request["HC"].ToString();
            DB_CAJA_UNICA caja = new DB_CAJA_UNICA();
            request_CAJA_UNICA req = new request_CAJA_UNICA();
            req.NUM = Numero_Unico;
            req.LOTE = Lote_Proceso;
            req.KILOS = Kilos;
            req.CALIBRE = Calibre;
            req.LINEA = Linea;
            req.TURNO = Turno;
            req.SALIDA = Salida;
            req.MATERIAL = Material;
            req.ESPECIE = Especie;
            req.VARIEDAD = Variedad;
            req.CODIGO_P = Codigo_Productor;
            req.FECHA = Fecha_Creacion;
            req.HORA = Hora_Creacion;
            responce_CAJA_UNICA obj = caja.run(req);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}