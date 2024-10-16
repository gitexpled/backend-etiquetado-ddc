using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_GET_PRODUCTOR_USER : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String usuario = Request["u"].ToString();
            DB_ECO_GET_PRODUCTOR_USER db = new DB_ECO_GET_PRODUCTOR_USER();
            request_ECO_GET_PRODUCTOR_USER req = new request_ECO_GET_PRODUCTOR_USER();
            req.ID_USUARIO = usuario;
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}