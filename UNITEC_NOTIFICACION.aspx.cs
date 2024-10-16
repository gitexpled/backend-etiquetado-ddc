using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace rfcBaika
{
    public partial class UNITEC_NOTIFICACION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PARAMETRO="{"cmd": "get_set_unitec", "array_pallet":[]}"
            DB_UNITEC unitec = new DB_UNITEC();
            String PARAMETRO = Request["PARAMETRO"].ToString();
            dynamic OBJ_PARAMETRO = JsonConvert.DeserializeObject(PARAMETRO);
            string cmd = OBJ_PARAMETRO.cmd;
            dynamic array_pallet = OBJ_PARAMETRO.array_pallet;
            dynamic resp = unitec.run(cmd, array_pallet);
            var json2 = new JavaScriptSerializer().Serialize(resp);
            json.Text = json2.ToString();
        }
    }
}