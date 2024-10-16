
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Collections.Generic;

namespace rfcBaika
{

    public class GPLogger
    {

        public static string CaptureConnectionDetails(string connectionString, DateTime start, DateTime end, string status)
        {
            var logEntry = new StringBuilder();
            logEntry.AppendLine("Timestamp: " + start.ToString("yyyy-MM-dd HH:mm:ss"));
            logEntry.AppendLine("Connection Status: " + status);
            logEntry.AppendLine("Connection String: " + connectionString);
            logEntry.AppendLine("Connection Time: " + (end - start).TotalMilliseconds + " ms");
            logEntry.AppendLine(new string('-', 50));
            return logEntry.ToString();
        }

        public static string CaptureCommandDetails(string query, DateTime start, DateTime end)
        {
            var logEntry = new StringBuilder();
            logEntry.AppendLine("Timestamp: " + start.ToString("yyyy-MM-dd HH:mm:ss"));
            logEntry.AppendLine("SQL Command: " + query);
            logEntry.AppendLine("Execution Time: " + (end - start).TotalMilliseconds + " ms");
            logEntry.AppendLine(new string('-', 50));
            return logEntry.ToString();
        }

        public static string CaptureQueryResults(SqlDataReader reader)
        {
            var logEntry = new StringBuilder();
            logEntry.AppendLine("Query Results:");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                logEntry.AppendLine(reader.GetName(i) + ": " + reader[i]);
            }
            logEntry.AppendLine(new string('-', 50));
            return logEntry.ToString();
        }

        public static string CaptureSqlError(SqlException ex)
        {
            var logEntry = new StringBuilder();
            logEntry.AppendLine("Timestamp: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            logEntry.AppendLine("SQL Error:");
            logEntry.AppendLine("Message: " + ex.Message);
            logEntry.AppendLine("Error Code: " + ex.ErrorCode);
            logEntry.AppendLine("Stack Trace: " + ex.StackTrace);
            logEntry.AppendLine(new string('-', 50));
            return logEntry.ToString();
        }

        public static string CaptureError(Exception ex)
        {
            var logEntry = new StringBuilder();
            logEntry.AppendLine("Timestamp: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            logEntry.AppendLine("Error General:");
            logEntry.AppendLine("Message: " + ex.Message);
            logEntry.AppendLine("Stack Trace: " + ex.StackTrace);
            logEntry.AppendLine(new string('-', 50));
            return logEntry.ToString();
        }



        public static void SaveLogEntry(string logEntry, string type)
        {
            


            string fileName = type + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", fileName);
           
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"));
            }

            File.AppendAllText(filePath, logEntry);
        }

        public static void CaptureHttpRequest(string clientIp, HttpRequest requ)
        {
            string url = requ.Url.ToString();
            string method = requ.HttpMethod;
            var logEntry = new StringBuilder();

            // Capturar información básica de la solicitud


            logEntry.AppendLine("Timestamp: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            logEntry.AppendLine("Client IP: " + requ.UserHostAddress);
            logEntry.AppendLine("Method: " + method);
            logEntry.AppendLine("URL: " + url);
            logEntry.AppendLine("Headers:");
            foreach (string key in requ.Headers)
            {
                logEntry.AppendLine(key + ": " + requ.Headers[key]);
            }


            // Capturar cuerpo de la solicitud (si existe)
            string requestBody = new StreamReader(requ.InputStream).ReadToEnd();
            if (!string.IsNullOrEmpty(requestBody))
            {
                logEntry.AppendLine("Body:");
                logEntry.AppendLine(requestBody);
            }

            logEntry.AppendLine(new string('-', 50));

            // Guardar el log en un archivo de texto
            SaveLogEntry(logEntry.ToString(), clientIp);
        }

       

    }

    public class LogReportGenerator
    {
        public void GenerateAndSaveReport(string logsDirectory, string outputFilePath)
        {
            var dbLogs = new List<string>();
            var requestLogs = new List<string>();

            // Leer todos los archivos .txt en la carpeta de logs
            string[] logFiles = Directory.GetFiles(logsDirectory, "*.txt");

            foreach (var file in logFiles)
            {
                // Leer el contenido del archivo
                var lines = File.ReadAllLines(file);

                // Clasificar los logs en base de datos o solicitudes HTTP
                if (file.Contains("Database"))
                {
                    dbLogs.AddRange(lines);
                }
                else if (file.Contains("Request"))
                {
                    requestLogs.AddRange(lines);
                }
            }

            // Generar el reporte en HTML
            var htmlContent = GenerateReport(dbLogs, requestLogs);

            // Guardar el reporte en un archivo HTML
            SaveReportToFile(htmlContent, outputFilePath);
        }

        private string GenerateReport(List<string> dbLogs, List<string> requestLogs)
        {
            var htmlBuilder = new StringBuilder();

            // Iniciar HTML
            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine("<head><title>Log Report</title></head>");
            htmlBuilder.AppendLine("<body>");
            htmlBuilder.AppendLine("<h1>Log Report</h1>");

            // Tabla para Logs de Base de Datos
            htmlBuilder.AppendLine("<h2>Database Logs</h2>");
            htmlBuilder.AppendLine("<table border='1' cellpadding='5' cellspacing='0'>");
            htmlBuilder.AppendLine("<tr><th>Timestamp</th><th>Details</th></tr>");
            htmlBuilder.AppendLine(FormatLogs(dbLogs));
            htmlBuilder.AppendLine("</table>");

            // Tabla para Logs de Solicitudes HTTP
            htmlBuilder.AppendLine("<h2>Request Logs</h2>");
            htmlBuilder.AppendLine("<table border='1' cellpadding='5' cellspacing='0'>");
            htmlBuilder.AppendLine("<tr><th>Timestamp</th><th>Details</th></tr>");
            htmlBuilder.AppendLine(FormatLogs(requestLogs));
            htmlBuilder.AppendLine("</table>");

            // Finalizar HTML
            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");

            return htmlBuilder.ToString();
        }

        private string FormatLogs(List<string> logs)
        {
            var formattedLogs = new StringBuilder();
            string currentTimestamp = string.Empty;

            foreach (var log in logs)
            {
                if (log.StartsWith("Timestamp"))
                {
                    currentTimestamp = log.Substring("Timestamp: ".Length);
                }
                else if (log.StartsWith("--------------------------------------------------"))
                {
                    formattedLogs.AppendLine("</td></tr>");
                    currentTimestamp = string.Empty;
                }
                else
                {
                    if (string.IsNullOrEmpty(currentTimestamp))
                    {
                        formattedLogs.AppendLine("<tr><td></td><td>" + log + "</td></tr>");
                    }
                    else
                    {
                        formattedLogs.AppendLine("<tr><td>" + currentTimestamp + "</td><td>" + log + "</td>");
                        currentTimestamp = string.Empty;
                    }
                }
            }

            return formattedLogs.ToString();
        }

        private void SaveReportToFile(string htmlContent, string filePath)
        {
            File.WriteAllText(filePath, htmlContent);
        }
    }
}
