using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_PORTAL_MANTENEDORES : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String procedure = Request["PROCEDURE"].ToString();
            DB_PORTAL db = new DB_PORTAL();
            int res1 = 0;
            String MAIL = "";
            String NOMBRE = "";
            String PRODUCTOR = "";
            String ID = "";


            String PASS = "";
            String USUARIO = "";
            String IPUSER = "";
            switch (procedure)
            {
                case "GET_MAIL_PRODUCTORES":
                    Array res = db.GET_MAIL_PRODUCTORES();
                    var json2 = new JavaScriptSerializer().Serialize(res);
                    json.Text = json2.ToString();
                    break;

                case "INSERT_MAIL_PRODUCTOR":
                    MAIL = Request["MAIL"].ToString();
                    NOMBRE = Request["NOMBRE"].ToString();
                    PRODUCTOR = Request["PRODUCTOR"].ToString();
                    res1 = db.INSERT_MAIL_PRODUCTOR(MAIL, NOMBRE, PRODUCTOR);
                    json.Text = res1.ToString();
                    break;

                case "UPDATE_MAIL_PRODUCTOR":
                    MAIL = Request["MAIL"].ToString();
                    NOMBRE = Request["NOMBRE"].ToString();
                    PRODUCTOR = Request["PRODUCTOR"].ToString();
                    ID = Request["ID"].ToString();
                    res1 = db.UPDATE_MAIL_PRODUCTOR(ID, MAIL, NOMBRE, PRODUCTOR);
                    json.Text = res1.ToString();
                    break;
                case "DELETE_MAIL_PRODUCTOR":
                    ID = Request["ID"].ToString();
                    res1 = db.DELETE_MAIL_PRODUCTOR(ID);
                    json.Text = res1.ToString();
                    break;
                case "GET_USUARIO_TOKEN":
                    res = db.GET_USUARIO_TOKEN();
                    json2 = new JavaScriptSerializer().Serialize(res);
                    json.Text = json2.ToString();
                    break;
                case "INSERT_USUARIO_TOKEN":
                    PASS = Request["PASS"].ToString();
                    USUARIO = Request["USUARIO"].ToString();
                    IPUSER = Request["IPUSER"].ToString();
                    res1 = db.INSERT_USUARIO_TOKEN(PASS, USUARIO, IPUSER);
                    json.Text = res1.ToString();
                    break;
                case "UPDATE_USUARIO_TOKEN":
                    PASS = Request["PASS"].ToString();
                    USUARIO = Request["USUARIO"].ToString();
                    IPUSER = Request["IPUSER"].ToString();
                    ID = Request["ID"].ToString();
                    res1 = db.UPDATE_USUARIO_TOKEN(ID, PASS, USUARIO, IPUSER);
                    json.Text = res1.ToString();
                    break;
                case "DELETE_USUARIO_TOKEN":
                    ID = Request["ID"].ToString();
                    res1 = db.DELETE_USUARIO_TOKEN(ID);
                    json.Text = res1.ToString();
                    break;
                case "LOGIN_USUARIO_TOKEN":
                    PASS = Request["PASS"].ToString();
                    USUARIO = Request["USUARIO"].ToString();
                    IPUSER = Request["IPUSER"].ToString();
                    res = db.LOGIN_USUARIO_TOKEN(USUARIO, PASS, IPUSER);
                    json2 = new JavaScriptSerializer().Serialize(res);
                    json.Text = json2.ToString();
                    break;
               /* case "GET_FECHA":
                    res = db.GET_FECHA();
                    json2 = new JavaScriptSerializer().Serialize(res);
                    json.Text = json2.ToString();
                    break;*/
                default:
                    json.Text = res1.ToString();
                    break;
            }
           

           
           
            
           
        }
    }
}