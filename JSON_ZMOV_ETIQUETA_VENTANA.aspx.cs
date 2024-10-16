using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;

namespace rfcBaika
{
    public partial class JSON_ZMOV_ETIQUETA_VENTANA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ip = Request["ip"].ToString();
            CaptureHttpRequest(ip);
            DB_ETIQUETA_VENTANA ventana = new DB_ETIQUETA_VENTANA();
            request_DB_ETIQUETA_VENTANA req = new request_DB_ETIQUETA_VENTANA();
            req.Ip = ip;
            List<responce_DB_ETIQUETA_VENTANA> List = new List<responce_DB_ETIQUETA_VENTANA>();
            List = ventana.run(req);
            Array res = List.ToArray();
            var json2 = new JavaScriptSerializer().Serialize(res);
            json.Text = json2.ToString();
        }


        private void CaptureHttpRequest(string clientIp)
        {
            string url = Request.Url.ToString();
            string method = Request.HttpMethod;
            var logEntry = new StringBuilder();

            // Capturar información básica de la solicitud


            logEntry.AppendLine("Timestamp: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            logEntry.AppendLine("Client IP: " + clientIp);
            logEntry.AppendLine("Method: " + method);
            logEntry.AppendLine("URL: " + url);
            logEntry.AppendLine("Headers:");
            foreach (string key in Request.Headers)
            {
                logEntry.AppendLine(key + ": " + Request.Headers[key]);
            }


            // Capturar cuerpo de la solicitud (si existe)
            string requestBody = new StreamReader(Request.InputStream).ReadToEnd();
            if (!string.IsNullOrEmpty(requestBody))
            {
                logEntry.AppendLine("Body:");
                logEntry.AppendLine(requestBody);
            }

            logEntry.AppendLine(new string('-', 50));

            // Guardar el log en un archivo de texto
            SaveLogEntry(clientIp, logEntry.ToString());
        }

        private void SaveLogEntry(string clientIp, string logEntry)
        {
            string fileName = clientIp + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = Path.Combine(Server.MapPath("~/Logs"), fileName);


            if (!Directory.Exists(Server.MapPath("~/Logs")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Logs"));
            }

            File.AppendAllText(filePath, logEntry);
        }

    }
}