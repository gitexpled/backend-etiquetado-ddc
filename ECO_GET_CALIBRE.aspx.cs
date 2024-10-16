using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class ECO_GET_CALIBRE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String especie = Request["e"].ToString();
            DB_ECO_GET_CALIBRE db = new DB_ECO_GET_CALIBRE();
            request_ECO_GET_CALIBRE req = new request_ECO_GET_CALIBRE();
            req.ESPECIE = especie;
            Array resp = db.run(req);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}