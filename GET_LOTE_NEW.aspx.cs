using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class GET_LOTE_NEW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DB_GET_LOTE_NEW lote_new = new DB_GET_LOTE_NEW();
            String USER = Request["USER"].ToString();
            String CENTRO = Request["CENTRO"].ToString();
            int resp = lote_new.run(USER, CENTRO);
            //var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = resp.ToString();
        }
    }
}