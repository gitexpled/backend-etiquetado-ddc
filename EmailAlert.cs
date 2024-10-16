using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

namespace rfcBaika
{
    public class EmailAlert
    {
        public string envioMail(string sendFrom, string sendTo, string sendCc, string sendSubject, string sendBody)
        {
            try
            {
                //System.Net.Mail.SmtpClient _SmtpServer = new System.Net.Mail.SmtpClient
                //{
                /*Host = "10.20.1.35",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("reportes@baika.cl", "re2021RE")*/
                //Credentials = new NetworkCredential("imeneses@expled.cl", "qwerty123")
                // Credentials = new NetworkCredential("reportes@baika.cl", "re2021RE")
                /*Host = "smtp.sjfarms.cl",
                Port = 25,
                EnableSsl = false,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("notificaciones@sjfarms.cl", "SanJose*2019")*/
                //Host = "10.20.1.35",
                //Host = "172.16.10.96",
                //  Host = "smpt.office365.com",
                //Port = 587,
                //EnableSsl = true,
                //DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                //UseDefaultCredentials = false,
                //Credentials = new NetworkCredential("reportes@ddc.cl", "DDc,2019"),
                //      Timeout = 20000
                //Credentials = new NetworkCredential("iv.meneses.ga@gmail.com", "16ivaninho10")
                // Credentials = new NetworkCredential("reportes@baika.cl", "re2021RE")
                // };
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
                //smtpClient.Host = "smtp.office365.com";
                smtpClient.Host = "smtp-legacy.office365.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential("reportes@ddc.cl", "DDc,2019");


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(sendFrom);
                String[] addSend = sendTo.Split(',');
                for (int i = 0; i < addSend.Length; i++) {
                    if (addSend[i] != "")
                    {
                        mail.To.Add(addSend[i]);
                    }
                }
                /*String[] addSend2 = sendCc.Split(';');
                for (int i = 0; i < addSend2.Length; i++)
                {
                    if (addSend2[i] != "")
                    {
                        mail.CC.Add(addSend2[i]);
                    }
                }*/
               
                mail.Subject = sendSubject;
                mail.Body = sendBody;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;

                smtpClient.Send(mail);
                logEmailAlert(sendFrom, sendTo, "", sendSubject, sendBody, "", 1);

                return "OK";
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
                logEmailAlert(sendFrom, sendTo, sendCc, sendSubject, sendBody, e.Message, 0);
                return e.Message;
            }
        }

        public string logEmailAlert(string sendFrom, string sendTo, string sendCc, string sendSubject, string sendBody,
            string errorMessage, int enviado)
        {
            try
            {
                String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("INSERT_EMAIL_ALERT", connection);
                cmd.Parameters.Add(new SqlParameter("@sendFrom", sendFrom));
                cmd.Parameters.Add(new SqlParameter("@sendTo", sendTo));
                cmd.Parameters.Add(new SqlParameter("@sendCc", sendCc));
                cmd.Parameters.Add(new SqlParameter("@sendSubject", sendSubject));
                cmd.Parameters.Add(new SqlParameter("@sendBody", sendBody));
                cmd.Parameters.Add(new SqlParameter("@errorMessage", errorMessage));
                cmd.Parameters.Add(new SqlParameter("@enviado", enviado));
                cmd.CommandType = CommandType.StoredProcedure;


                int result = cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
                cmd.Dispose();

                return "OK";
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
                return e.Message;
            }
        }
    }
}