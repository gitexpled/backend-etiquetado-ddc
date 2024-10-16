using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_PORTAL_APRUEBALOTE_Token : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String lote = Request["LOTE"].ToString();
            String user = Request["USER"].ToString();
            String estado = Request["ESTADO"].ToString();
            int res = 0;
            DB_PORTAL db = new DB_PORTAL();
            if (estado == "3")
            {
                String link = Request["LINK"].ToString();
                String productor = Request["PRODUCTOR"].ToString();
                String especie = Request["ESPECIE"].ToString();
                String fecha = Request["FECHA"].ToString();
                String[] f = fecha.Split('-');
                fecha = f[2] + "/" + f[1] + "/" + f[0];
                String name = db.getNameProductor(productor, lote, link, fecha, especie);
                List<responce_MAIL> res2 = db.SendMailCC(productor, lote, link, fecha, especie, name);
                //List<responce_MAIL> res2 = db.SendMail(productor, lote, link, fecha, especie);

                /*db.SendMailEncargado(productor, lote, link, fecha, especie, res2[0].NOMBRE);
                db.SendMailEncargadoEspecie(productor, lote, link, fecha,especie, res2[0].NOMBRE);
                db.SendMailAgronomo(productor, lote, link, especie, fecha, res2[0].NOMBRE);*/

            }
            else
            {
                res = db.AprobarLote(lote, user, estado);
            }
           

            
           
            
            json.Text = res.ToString();
        }
    }
}