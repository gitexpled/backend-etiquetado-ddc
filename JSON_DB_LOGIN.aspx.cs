using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class JSON_DB_LOGIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String User = Request["User"].ToString();
            String Pass = Request["Pass"].ToString();
            String dataGranel = (Request["dataGranel"]!=null)?Request["dataGranel"].ToString():"";
            String Proceso = (Request["proceso"]!=null)?Request["proceso"].ToString():"";
            // String WERKS = Request["WERKS"].ToString();


            DB_LOGIN sap = new DB_LOGIN();
            request_DB_LOGIN imp = new request_DB_LOGIN();
            imp.User = User;
            imp.Pass = Pass;
            imp.dataGranel = dataGranel;
            imp.Proceso = Proceso;
            responce_DB_LOGIN obj = sap.run(imp);
            var json2 = new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
    }
}