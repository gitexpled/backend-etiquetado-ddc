using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Net;
using WindowsFormsApplication1;
using Newtonsoft.Json.Linq;
using SelectPdf;

namespace rfcBaika
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string printTarja(int cant, string json, string IP, string centro = "DC02")
        {
            json = "{items:" + json + "}";
            JObject root = JObject.Parse(json);

            JArray items = (JArray)root["items"];

            JObject item;
            JToken jtoken;
            File.Copy(@"c:\temp\dc.html", @"c:\temp\dc1.html", true);
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                jtoken = item.First;
                while (jtoken != null)//loop through columns
                {
                    string text = File.ReadAllText(@"c:\temp\dc1.html");
                    text = text.Replace("{" + ((JProperty)jtoken).Name.ToString() + "}", ((JProperty)jtoken).Value.ToString());
                    File.WriteAllText(@"c:\temp\dc1.html", text);
                    //MessageBox.Show("{" + ((JProperty)jtoken).Name.ToString() + "}");
                    jtoken = jtoken.Next;


                }
            }
            File.Copy(@"c:\temp\dc1.html", @"c:\temp\dc2.html", true);
            File.Copy(@"c:\temp\dc1.html", @"c:\temp\dc3.html", true);

            string text1 = File.ReadAllText(@"c:\temp\dc1.html");
            text1 = text1.Replace("{copia}", "1");
            File.WriteAllText(@"c:\temp\dc1.html", text1);

            string text2 = File.ReadAllText(@"c:\temp\dc2.html");
            text2 = text2.Replace("{copia}", "2");
            File.WriteAllText(@"c:\temp\dc2.html", text2);

            string text3 = File.ReadAllText(@"c:\temp\dc3.html");
            text3 = text3.Replace("{copia}", "3");
            File.WriteAllText(@"c:\temp\dc3.html", text3);

            ConvertUrlToPdf(@"c:\temp\Document1.pdf", @"file:///C:/temp/dc1.html");
            ConvertUrlToPdf(@"c:\temp\Document2.pdf", @"file:///C:/temp/dc2.html");
            ConvertUrlToPdf(@"c:\temp\Document3.pdf", @"file:///C:/temp/dc3.html");

            try
            {
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.NoDelay = true;
                //"10.99.99.120"
                IPAddress ip = IPAddress.Parse(IP);
                IPEndPoint ipep = new IPEndPoint(ip, 9100);
                clientSocket.Connect(ipep);

                byte[] fileBytes1 = File.ReadAllBytes(@"c:\temp\Document1.pdf");
                clientSocket.Send(fileBytes1);

                byte[] fileBytes2 = File.ReadAllBytes(@"c:\temp\Document2.pdf");
                clientSocket.Send(fileBytes2);

                byte[] fileBytes3 = File.ReadAllBytes(@"c:\temp\Document3.pdf");
                clientSocket.Send(fileBytes3);

                clientSocket.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                
                //throw;

                try
                {
                    RawPrinterHelper.SendFileToPrinter(@IP, @"c:\temp\Document1.pdf");
                    Thread.Sleep(1000);

                    RawPrinterHelper.SendFileToPrinter(@IP, @"c:\temp\Document2.pdf");
                    Thread.Sleep(1000);

                    RawPrinterHelper.SendFileToPrinter(@IP, @"c:\temp\Document3.pdf");
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {
                    
                    throw ex;
                }

                return "OK";
            }
        }

        [WebMethod]
        public string print(int cant, string zpl, string IP, bool continuaLote, string centro = "ddc02", bool reimprime = false, bool impremeTodo = true, int correlativo = 0, string loteReimprime = "")
        {

            try
            {

                if (!continuaLote)
                {
                    string pathNumeroLote = @"c:\temp\" + centro + @"\SECUENCIA_LOTE_NO_BORRAR.txt";



                    string[] lines = System.IO.File.ReadAllLines(pathNumeroLote);



                    string loteStr = lines[0];

                    //loteStr = loteStr + "00";
                    string path = @"c:\temp\" + centro + "\\" + loteStr;

                    int lote = int.Parse(loteStr);
                    int nuevoLote = int.Parse(lines[0]);

                    // Delete the file if it exists.


                    // Create the file.
                    string lote2222 = loteStr;
                    int loteQ = 1;
                    for (int i = 1; i <= cant; i++)
                    {

                        if (loteQ > 0 && loteQ < 10)
                            loteStr = lote2222 + "-" + "0" + loteQ.ToString();
                        else
                        {
                            loteStr = lote2222 + "-" + loteQ.ToString();
                        }
                        loteQ++;

                        FileStream fs = File.Create(path);

                        string zplTemp = zpl.Replace("*VALORREMPLAZO*", loteStr.ToString());

                        Byte[] info = new UTF8Encoding(true).GetBytes(zplTemp);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                        fs.Close();
                        fs.Dispose();


                        RawPrinterHelper.SendFileToPrinter(@IP, path);
                        Thread.Sleep(1000);

                    }

                    FileStream fsLote = File.Create(pathNumeroLote);


                    nuevoLote++;

                    Byte[] infoLot = new UTF8Encoding(true).GetBytes(nuevoLote.ToString());
                    // Add some information to the file.
                    fsLote.Write(infoLot, 0, infoLot.Length);
                    fsLote.Close();
                    fsLote.Dispose();

                    return "OK;" + loteStr;
                }
                else
                {
                    string[] arrLote = loteReimprime.Split("-".ToCharArray());

                    loteReimprime = arrLote[0];

                    string lote2222 = loteReimprime;
                    int loteQ = 1;
                    string path = @"c:\temp\" + centro + "\\" + loteReimprime;

                    for (int i = 1; i <= cant; i++)
                    {

                        if (loteQ > 0 && loteQ < 10)
                            loteReimprime = lote2222 + "-" + "0" + loteQ.ToString();
                        else
                        {
                            loteReimprime = lote2222 + "-" + loteQ.ToString();
                        }
                        loteQ++;

                        FileStream fs = File.Create(path);

                        string zplTemp = zpl.Replace("*VALORREMPLAZO*", loteReimprime.ToString());

                        Byte[] info = new UTF8Encoding(true).GetBytes(zplTemp);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                        fs.Close();
                        fs.Dispose();


                        RawPrinterHelper.SendFileToPrinter(@IP, path);
                        Thread.Sleep(1000);


                    }

                    return "OK;" + loteReimprime;
                }


            }

            catch (Exception ex)
            {
                return "NOK;" + ex.Message + " traza " + ex.StackTrace;
            }
            /*}

            return "NOK;Error Inesperado";*/


        }



        public void ConvertUrlToPdf(string file, string url)
        {


            //string file = @"c:\temp\Document.pdf";

            try
            {
                // read parameters from the form
                //string url = @"file:///C:/temp/dc1.html";

                string pdf_page_size = "A4";
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                    pdf_page_size, true);

                string pdf_orientation = "Portrait";
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    pdf_orientation, true);

                int webPageWidth = 1024;
                try
                {
                    webPageWidth = Convert.ToInt32("1024");
                }
                catch { }

                int webPageHeight = 0;
                /* try
                 {
                     webPageHeight = Convert.ToInt32("");
                 }
                 catch { }*/

                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set converter options
                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                converter.Options.WebPageWidth = webPageWidth;
                converter.Options.WebPageHeight = webPageHeight;

                // create a new pdf document converting an url
                PdfDocument doc = converter.ConvertUrl(url);

                // save pdf document
                doc.Save(file);

                // close pdf document
                doc.Close();
            }
            catch (Exception ex)
            {

                throw ex;
                //MessageBox.Show(String.Format("Error: {0}", ex.Message),
                //    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                //Cursor = Cursors.Arrow;
            }

            // open generated pdf
            //try
            //{
            //    System.Diagnostics.Process.Start(file);
            //}
            //catch
            //{
            //    MessageBox.Show("Could not open generated pdf document",
            //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        [WebMethod]
        public string printPantalla(int cant, string zpl, string IP)
        {

            try
            {

                string path = Path.GetTempPath() + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                FileStream fs = File.Create(path);




                string zplTemp = zpl;

                Byte[] info = new UTF8Encoding(true).GetBytes(zplTemp);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
                fs.Close();
                fs.Dispose();







                try
                {
                    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.NoDelay = true;
                    //"10.99.99.120"
                    IPAddress ip = IPAddress.Parse(IP);
                    IPEndPoint ipep = new IPEndPoint(ip, 9100);
                    clientSocket.Connect(ipep);

                    byte[] fileBytes1 = File.ReadAllBytes(path);
                    clientSocket.Send(fileBytes1);



                    clientSocket.Close();
                }
                catch (Exception ex)
                {

                    try
                    {


                        RawPrinterHelper.SendFileToPrinter(@IP, path);
                        Thread.Sleep(1000);
                    }
                    catch (Exception exx)
                    {


                    }





                }





                return "OK;";




            }

            catch (Exception ex)
            {
                return "NOK;" + ex.Message + " traza " + ex.StackTrace;
            }
            /*}

            return "NOK;Error Inesperado";*/


        }


    }


}
