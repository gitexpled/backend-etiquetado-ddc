using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public partial class LogWEB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string logsDirectory = @"E:\Desktop\david del curto rfc\rfcBaika\rfcBaika\Logs\";
            string outputFilePath = @"E:\Desktop\david del curto rfc\rfcBaika\rfcBaika\Logs\LogReport.html";

            var logReportGenerator = new LogReportGenerator();
            logReportGenerator.GenerateAndSaveReport(logsDirectory, outputFilePath);

            Console.WriteLine("Log report generated and saved at " + outputFilePath);

        }
    }
}