using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.IO;

namespace rfcBaika
{
    public partial class JSON_ZPL_SAVE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            byte[] zpl = Encoding.UTF8.GetBytes(Request["key"]);
            String W = Request["w"];
            String H = Request["h"];
            String DP = Request["d"];
            DateTime thisDay = DateTime.Today;
            var h = DateTime.Now;
            String hora = h.ToString("HH:mm:ss");
            String Hora = hora.Replace(":", "-");
            var time = thisDay.ToString("d");
            var Ttima = time.Replace("/","-");
            var label = "Etiqueta_F_"+Ttima+"_H_"+Hora;
            var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/"+DP+"/labels/"+W+"x"+H+"/0/");
            request.Method = "POST";
            request.Accept = "image/png";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zpl.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(zpl, 0, zpl.Length);
            requestStream.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();
                var file = Server.MapPath("/DDC/ZPL/"+label+".png");
                var fileStream = File.Create(file);
                responseStream.CopyTo(fileStream);
                responseStream.Close();
                fileStream.Close();
                Console.WriteLine("Guardado con exito");
            }
            catch (WebException error)
            {
                Console.WriteLine("Error: {0}", error.Status);
            }
        }
    }
}