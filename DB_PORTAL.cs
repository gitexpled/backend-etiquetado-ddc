using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

namespace rfcBaika
{
    public class DB_PORTAL
    {
        public Array GetProduccionAcumulada(ArrayList productor, String temporada)
        {
            List<responce_PRODUCCION> List = new List<responce_PRODUCCION>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("PORTAL_GET_PRODUCCION_ACUMULADA_NEW", connection);

            DataTable dt = new DataTable();
            dt.Columns.Add("Lifnr", typeof(string));

            foreach (var lifnr in productor)
            {
                dt.Rows.Add(new object[] { lifnr });
            }

            SqlParameter p = cmd.Parameters.AddWithValue("@VAR_PRODUCTOR", dt);
            cmd.Parameters.Add(new SqlParameter("@TEMPORADA", temporada));
            p.SqlDbType = SqlDbType.Structured;
            p.TypeName = "udt_Lifnr";


            //cmd.Parameters.Add(new SqlParameter("@VAR_PRODUCTOR", productor));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 950;

            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_PRODUCCION res = new responce_PRODUCCION();

                    res.Productor = dataReader[0].ToString();
                    res.Variedad = dataReader[1].ToString();
                    res.Especie = dataReader[2].ToString();
                    res.Unidad = dataReader[3].ToString();
                    res.Recibidos = decimal.Parse(dataReader[4].ToString());
                    res.Exportados = decimal.Parse(dataReader[5].ToString());
                    res.Procesados = decimal.Parse(dataReader[6].ToString());
                    res.Porcentaje = decimal.Parse(dataReader[7].ToString());
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public string[] getFechasTemporada(string temporada)
        {
            string[] fechas = new string[2];
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("GET_FECHAS_TEMPORADAS", connection);
            cmd.Parameters.Add(new SqlParameter("@TEMPORADA", temporada));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 950;

            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    fechas[0] = dataReader[0].ToString();
                    fechas[1] = dataReader[1].ToString();
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();

            return fechas;
        }

        public String getNameProductor(string productor, String lote, String Link, String fecha, String especie)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();

            cmd = new SqlCommand("[GET_MAIL_PRODUCTOR]", connection);
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            String nameproductor = productor;
            SqlDataReader dataReader = cmd.ExecuteReader();
            EmailAlert mail = new EmailAlert();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    nameproductor = dataReader[2].ToString() + "-" + dataReader[1].ToString();
                }
            }
            return nameproductor;

        }

        public List<responce_MAIL> SendMailCC(string productor, String lote, String Link, String fecha, String especie, String name)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_MAIL_ENCARGADO]", connection);
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));

            /*cmd = new SqlCommand("[GET_MAIL_PRODUCTOR]", connection);
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));*/
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            String mails = "";
            String asunto = "";
            String body = "";
            SqlDataReader dataReader = cmd.ExecuteReader();
            EmailAlert mail = new EmailAlert();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    mails += dataReader[0].ToString() + ",";
                    res.MAIL = dataReader[0].ToString()+";";
                    res.NOMBRE = dataReader[1].ToString();
                    res.PRODUCTOR = dataReader[2].ToString();
                    /*asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + especie + "; Productor: " + dataReader[2].ToString() + "-" + dataReader[1].ToString() + "; del " + fecha;
                    
                    body += "<table>";
                    body += "<tr>";
                    body += "<td>Señor (a) (es)</td>";
                    body += "</tr>";
                    body += "<tr>";
                    //body += "<td>" + dataReader[1].ToString() + "</td>"; //comment
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Saludos cordiales</td>";
                    body += "</tr>";
                    body += "</table>";

                    //mail.envioMail("reportes@ddc.cl", dataReader[0].ToString(), encargadoCC + especieCC + agroCC, asunto, body);

                    List.Add(res);*/
                }
            }
            asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + especie + "; Productor: " + name + "; del " + fecha;

            body += "<table>";
            body += "<tr>";
            body += "<td>Señor (a) (es)</td>";
            body += "</tr>";
            body += "<tr>";
            //body += "<td>" + dataReader[1].ToString() + "</td>"; //comment
            body += "</tr>";
            body += "<tr>";
            body += "<td style='height:20px'></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td style='height:20px'></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td>Saludos cordiales</td>";
            body += "</tr>";
            body += "</table>";
            String encargadoCC = getMailProductor(productor, lote, Link, fecha, especie);
            String especieCC = SendMailEncargadoEspecieCC(productor, lote, Link, fecha, especie, "");
            String agroCC = SendMailAgronomoCC(productor, lote, Link, fecha, especie, "");
            //mail.envioMail("reportes@ddc.cl", mails, encargadoCC + especieCC + agroCC, asunto, body);
            mail.envioMail("reportes@ddc.cl", mails + encargadoCC + especieCC + agroCC, "", asunto, body);
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List;

        }

        public String getMailProductor(string productor, String lote, String Link, String fecha, String especie)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_MAIL_PRODUCTOR]", connection);
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            String resCC = "";


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();

                    resCC += dataReader[0].ToString() + ",";
                    /*res.MAIL = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    res.PRODUCTOR = dataReader[2].ToString();
                    String encargadoCC = SendMailEncargadoCC(productor, lote, Link, fecha, especie, dataReader[1].ToString());
                    String especieCC = SendMailEncargadoEspecieCC(productor, lote, Link, fecha, especie, dataReader[1].ToString());
                    String agroCC = SendMailAgronomoCC(productor, lote, Link, fecha, especie, dataReader[1].ToString());
                    EmailAlert mail = new EmailAlert();
                    String asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + especie + "; Productor: " + dataReader[2].ToString() + "-" + dataReader[1].ToString() + "; del " + fecha;
                    String body = "";
                    body += "<table>";
                    body += "<tr>";
                    body += "<td>Señor (a) (es)</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>" + dataReader[1].ToString() + "</td>"; //comment
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Saludos cordiales</td>";
                    body += "</tr>";
                    body += "</table>";

                    mail.envioMail("reportes@ddc.cl", dataReader[0].ToString(), encargadoCC + especieCC + agroCC, asunto, body);

                    List.Add(res);*/
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return resCC;

        }

        public List<responce_MAIL> SendMail(string productor, String lote, String Link, String fecha, String especie)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_MAIL_PRODUCTOR]", connection);
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();

                    res.MAIL = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    res.PRODUCTOR = dataReader[2].ToString();
                    String encargadoCC = SendMailEncargadoCC(productor, lote, Link, fecha, especie, dataReader[1].ToString());
                    String especieCC = SendMailEncargadoEspecieCC(productor, lote, Link, fecha, especie, dataReader[1].ToString());
                    String agroCC = SendMailAgronomoCC(productor, lote, Link, fecha, especie, dataReader[1].ToString());
                    EmailAlert mail = new EmailAlert();
                    String asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + especie + "; Productor: " + dataReader[2].ToString() + "-" + dataReader[1].ToString() + "; del " + fecha;
                    String body = "";
                    body += "<table>";
                    body += "<tr>";
                    body += "<td>Señor (a) (es)</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>" + dataReader[1].ToString() + "</td>"; //comment
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día "+fecha+".</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Saludos cordiales</td>";
                    body += "</tr>";
                    body += "</table>";

                    mail.envioMail("reportes@ddc.cl", dataReader[0].ToString(), encargadoCC + especieCC + agroCC, asunto, body);

                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List;

        }
        public String SendMailEncargadoCC(string productor, String lote, String Link, String fecha, String especie, String nproductor)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_MAIL_ENCARGADO]", connection);
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            String resCC = "";


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    String asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + especie + "; Productor: " + productor + "-" + nproductor + "; del " + fecha;
                    res.MAIL = dataReader[0].ToString();
                    resCC += dataReader[0].ToString() + ";";
                    /*res.NOMBRE = dataReader[1].ToString();
                    EmailAlert mail = new EmailAlert();
                    String body = "";
                    body += "<table>";
                    body += "<tr>";
                    body += "<td>Señor (a) (es)</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>" + dataReader[1].ToString() + "</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Saludos cordiales</td>";
                    body += "</tr>";
                    body += "</table>";

                    mail.envioMail("reportes@ddc.cl", dataReader[0].ToString(), "", asunto, body);

                    List.Add(res);*/
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return resCC;

        }

        public String SendMailEncargadoEspecieCC(string productor, String lote, String Link, String fecha, String especie, String nproductor)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_MAIL_ENCARGADO_ESPECIE]", connection);
            cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            String resCC = "";


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    String asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + especie + "; Productor: " + productor + "-" + nproductor + "; del " + fecha;
                    res.MAIL = dataReader[0].ToString();
                    resCC += dataReader[0].ToString() + ",";
                    /*res.NOMBRE = dataReader[1].ToString();
                    EmailAlert mail = new EmailAlert();
                    String body = "";
                    body += "<table>";
                    body += "<tr>";
                    body += "<td>Señor (a) (es)</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>" + dataReader[1].ToString() + "</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Saludos cordiales</td>";
                    body += "</tr>";
                    body += "</table>";

                    mail.envioMail("reportes@ddc.cl", dataReader[0].ToString(), "", asunto, body);

                    List.Add(res);*/
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return resCC;

        }


        public String SendMailAgronomoCC(string productor, String lote, String Link, String fecha, String Especie, String nproductor)
        {
            ZMF_GET_DAT_PROD sap = new ZMF_GET_DAT_PROD();
            request_ZMF_GET_DAT_PROD imp = new request_ZMF_GET_DAT_PROD();
            imp.I_ESPECIE = Especie;
            imp.I_LIFNR = productor;

            String resCC = "";

            responce_ZMF_GET_DAT_PROD obj = sap.sapRun(imp);

            EmailAlert mail = new EmailAlert();
            /*String asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + Especie + "; Productor: " + productor + "-" + nproductor + "; del " + fecha;
            String body = "";
            body += "<table>";
            body += "<tr>";
            body += "<td>Señor (a) (es)</td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td>" + obj.ET_PRODUCT[0].USUARIO_RESP + "</td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td style='height:20px'></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td style='height:20px'></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td>Saludos cordiales</td>";
            body += "</tr>";
            body += "</table>";
            */
            if (obj.ET_PRODUCT.Length > 0)
            {
                resCC += obj.ET_PRODUCT[0].SMTP_ADDR;
            }
           

            //mail.envioMail("reportes@ddc.cl", obj.ET_PRODUCT[0].SMTP_ADDR, "", asunto, body);

            return resCC;

        }

        public Array SendMailEncargado(string productor, String lote, String Link, String fecha, String especie, String nproductor)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_MAIL_ENCARGADO]", connection);
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    String asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + especie + "; Productor: " + productor + "-" + nproductor + "; del " + fecha;
                    res.MAIL = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    EmailAlert mail = new EmailAlert();
                    String body = "";
                    body += "<table>";
                    body += "<tr>";
                    body += "<td>Señor (a) (es)</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>"+dataReader[1].ToString()+"</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Saludos cordiales</td>";
                    body += "</tr>";
                    body += "</table>";

                    mail.envioMail("reportes@ddc.cl", dataReader[0].ToString(), "", asunto, body);

                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array SendMailEncargadoEspecie(string productor, String lote, String Link, String fecha, String especie, String nproductor)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_MAIL_ENCARGADO_ESPECIE]", connection);
            cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    String asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + especie + "; Productor: " + productor + "-" + nproductor + "; del " + fecha;
                    res.MAIL = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    EmailAlert mail = new EmailAlert();
                    String body = "";
                    body += "<table>";
                    body += "<tr>";
                    body += "<td>Señor (a) (es)</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>" + dataReader[1].ToString() + "</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td style='height:20px'></td>";
                    body += "</tr>";
                    body += "<tr>";
                    body += "<td>Saludos cordiales</td>";
                    body += "</tr>";
                    body += "</table>";

                    mail.envioMail("reportes@ddc.cl", dataReader[0].ToString(), "", asunto, body);

                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public int SendMailAgronomo(string productor, String lote, String Link, String Especie, String fecha, String nproductor)
        {
            ZMF_GET_DAT_PROD sap = new ZMF_GET_DAT_PROD();
            request_ZMF_GET_DAT_PROD imp = new request_ZMF_GET_DAT_PROD();
            imp.I_ESPECIE = Especie;
            imp.I_LIFNR = productor;

            responce_ZMF_GET_DAT_PROD obj = sap.sapRun(imp);

            EmailAlert mail = new EmailAlert();
            String asunto = "Informe de Producción; Lote: " + lote + "; Especie: " + Especie + "; Productor: " + productor + "-" + nproductor + "; del " + fecha;
            String body = "";
            body += "<table>";
            body += "<tr>";
            body += "<td>Señor (a) (es)</td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td>" + obj.ET_PRODUCT[0].USUARIO_RESP+ "</td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td style='height:20px'></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td>Adjunto Informe de producción correspondiente al resultado del proceso " + lote + " del día " + fecha + ".</td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td> <a href='" + Link + "'>Ver Reporte</a></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td style='height:20px'></td>";
            body += "</tr>";
            body += "<tr>";
            body += "<td>Saludos cordiales</td>";
            body += "</tr>";
            body += "</table>";

            mail.envioMail("reportes@ddc.cl", obj.ET_PRODUCT[0].SMTP_ADDR, "", asunto, body);

            return 1;

        }


        public Array GET_MAIL_PRODUCTORES()
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_MAIL_PRODUCTORES]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    res.ID = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    res.MAIL = dataReader[2].ToString();
                    res.PRODUCTOR = dataReader[3].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GET_USUARIO_TOKEN()
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_USUARIO_TOKEN]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    res.ID = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    res.MAIL = dataReader[2].ToString();
                    res.PRODUCTOR = dataReader[3].ToString();
                    res.IP = dataReader[6].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public int INSERT_MAIL_PRODUCTOR(string mail, string nombre, string productor)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("INSERT_MAIL_PRODUCTOR", connection);
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@MAIL", mail));
            cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }

        public int INSERT_USUARIO_TOKEN(string pass, string usuario, string ipuser)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("INSERT_USUARIO_TOKEN", connection);
            cmd.Parameters.Add(new SqlParameter("@IPUSER", ipuser));
            cmd.Parameters.Add(new SqlParameter("@PASS", pass));
            cmd.Parameters.Add(new SqlParameter("@USUARIO", usuario));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }

        public int UPDATE_MAIL_PRODUCTOR(string id, string mail, string nombre, string productor)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("UPDATE_MAIL_PRODUCTOR", connection);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@MAIL", mail));
            cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }

        public int UPDATE_USUARIO_TOKEN(string id, string pass, string usuario, string ipuser)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("UPDATE_USUARIO_TOKEN", connection);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.Parameters.Add(new SqlParameter("@IPUSER", ipuser));
            cmd.Parameters.Add(new SqlParameter("@PASS", pass));
            cmd.Parameters.Add(new SqlParameter("@USUARIO", usuario));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }



        public int DELETE_MAIL_PRODUCTOR(string id)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("DELETE_MAIL_PRODUCTOR", connection);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }

        public int DELETE_USUARIO_TOKEN(string id)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("DELETE_USUARIO_TOKEN", connection);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }

        public Array LOGIN_USUARIO_TOKEN(String USUARIO, String PASSWORD, String IPUSER)
        {
            List<responce_MAIL> List = new List<responce_MAIL>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[LOGIN_USUARIO_TOKEN]", connection);
            cmd.Parameters.Add(new SqlParameter("@IPUSER", IPUSER));
            cmd.Parameters.Add(new SqlParameter("@PASS", PASSWORD));
            cmd.Parameters.Add(new SqlParameter("@USUARIO", USUARIO));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_MAIL res = new responce_MAIL();
                    res.ID = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    res.MAIL = dataReader[2].ToString();
                    res.PRODUCTOR = dataReader[3].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public responce_FECHA GET_FECHA()
        {
            responce_FECHA res = new responce_FECHA();
            res.HOY = DateTime.Now.AddDays(0).ToString("yyyy-MM-dd");
            res.AYER = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            return res;

        }


        public int AprobarLote(string lote, string user, string estado)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("APRUEBA_LOTE", connection);
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.Parameters.Add(new SqlParameter("@USER", user));
            cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));
            cmd.CommandType = CommandType.StoredProcedure;


            int  result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }
        public int AprobarCalidad(string lote, string usuario)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("APRUEBA_CALIDAD", connection);
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.Parameters.Add(new SqlParameter("@USUARIO", usuario));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }
        public int AprobarGuia(string guia, string user)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[APRUEBA_GUIA]", connection);
            cmd.Parameters.Add(new SqlParameter("@GUIA", guia));
            cmd.Parameters.Add(new SqlParameter("@USER", user));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;

            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }

        public Array GetProduccionDetalle(ArrayList productor, String temporada)
        {
            List<responce_PRODUCCIONDETALLE> List = new List<responce_PRODUCCIONDETALLE>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("PORTAL_GET_PRODUCCION_NEW", connection);


            DataTable dt = new DataTable();
            dt.Columns.Add("Lifnr", typeof(string));

            foreach (var lifnr in productor)
            {
                dt.Rows.Add(new object[] { lifnr });
            }

            SqlParameter p = cmd.Parameters.AddWithValue("@VAR_PRODUCTOR", dt);
            cmd.Parameters.Add(new SqlParameter("@TEMPORADA", temporada));
            p.SqlDbType = SqlDbType.Structured;
            p.TypeName = "udt_Lifnr";


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_PRODUCCIONDETALLE res = new responce_PRODUCCIONDETALLE();
                  
                    res.Fecha= dataReader[0].ToString();
                    res.LoteProceso = dataReader[1].ToString();
                    res.Productor = dataReader[2].ToString();
                    res.Variedad = dataReader[3].ToString();
                    res.Especie = dataReader[4].ToString();
                    res.Unidad = dataReader[5].ToString();
                    res.Recibidos = decimal.Parse(dataReader[6].ToString());
                    res.Exportados = decimal.Parse(dataReader[7].ToString());
                    res.Procesados = decimal.Parse(dataReader[8].ToString());
                    res.Merma = decimal.Parse(dataReader[9].ToString());
                    res.Desecho= decimal.Parse(dataReader[10].ToString());
                    res.Comercial= decimal.Parse(dataReader[11].ToString());
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
        public Array GetAcumuladoGrupoVariedadSinSem(string grupo, string productor, string lote)
        {
            List<responce_ACUMULADO_VARIEDAD> List = new List<responce_ACUMULADO_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_ACUMULADO_GRUPO_VARIEDAD_SIM_SEM]", connection);
            cmd.Parameters.Add(new SqlParameter("@GRUPO", grupo));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ACUMULADO_VARIEDAD res = new responce_ACUMULADO_VARIEDAD();

                    res.VARIEDAD = dataReader[0].ToString();
                    res.SEMANA = dataReader[1].ToString();
                    res.EXPORTADOS = dataReader[4].ToString();
                    res.PROCESADOS = dataReader[5].ToString();
                    res.RECIBIDO = dataReader[2].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GetAcumuladoGrupoVariedad(string grupo, string productor, string lote)
        {
            List<responce_ACUMULADO_VARIEDAD> List = new List<responce_ACUMULADO_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_ACUMULADO_GRUPO_VARIEDAD]", connection);
            cmd.Parameters.Add(new SqlParameter("@GRUPO", grupo));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ACUMULADO_VARIEDAD res = new responce_ACUMULADO_VARIEDAD();

                    res.VARIEDAD = dataReader[0].ToString();
                    res.SEMANA = dataReader[1].ToString();
                    res.EXPORTADOS = dataReader[4].ToString();
                    res.PROCESADOS = dataReader[5].ToString();
                    res.RECIBIDO = dataReader[2].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
        public Array GetAcumuladoVariedadSimSem(string variedad, string productor, string lote)
        {
            List<responce_ACUMULADO_VARIEDAD> List = new List<responce_ACUMULADO_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_ACUMULADO_VARIEDAD_SIN_SEM]", connection);
            cmd.Parameters.Add(new SqlParameter("@VARIEDAD", variedad));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ACUMULADO_VARIEDAD res = new responce_ACUMULADO_VARIEDAD();

                    res.VARIEDAD = dataReader[0].ToString();
                    res.SEMANA = dataReader[1].ToString();
                    res.EXPORTADOS = dataReader[4].ToString();
                    res.PROCESADOS = dataReader[5].ToString();
                    res.RECIBIDO = dataReader[3].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
        public Array GetAcumuladoVariedad(string variedad, string productor, string lote)
        {
            List<responce_ACUMULADO_VARIEDAD> List = new List<responce_ACUMULADO_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_ACUMULADO_VARIEDAD]", connection);
            cmd.Parameters.Add(new SqlParameter("@VARIEDAD", variedad));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ACUMULADO_VARIEDAD res = new responce_ACUMULADO_VARIEDAD();

                    res.VARIEDAD = dataReader[0].ToString();
                    res.SEMANA = dataReader[1].ToString();
                    res.EXPORTADOS = dataReader[4].ToString();
                    res.PROCESADOS = dataReader[5].ToString();
                    res.RECIBIDO = dataReader[3].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GET_ACUM_CALIBRE_VARIEDAD(string variedad, string productor, string lote)
        {
            List<responce_ACUMULADO_VARIEDAD> List = new List<responce_ACUMULADO_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_ACUM_CALIBRE_VARIEDAD]", connection);
            cmd.Parameters.Add(new SqlParameter("@VARIEDAD", variedad));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ACUMULADO_VARIEDAD res = new responce_ACUMULADO_VARIEDAD();

                    res.VARIEDAD = dataReader[0].ToString();
                    //res.SEMANA = dataReader[1].ToString();
                    res.EXPORTADOS = dataReader[4].ToString();
                    res.PROCESADOS = dataReader[5].ToString();
                    res.CALIBRE = dataReader[1].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GET_ACUM_CALIBRE_GRUPO_VARIEDAD(string variedad, string productor, string lote)
        {
            List<responce_ACUMULADO_VARIEDAD> List = new List<responce_ACUMULADO_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_ACUM_CALIBRE_GRUPO_VARIEDAD]", connection);
            cmd.Parameters.Add(new SqlParameter("@VARIEDAD", variedad));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ACUMULADO_VARIEDAD res = new responce_ACUMULADO_VARIEDAD();

                    res.VARIEDAD = dataReader[0].ToString();
                    //res.SEMANA = dataReader[1].ToString();
                    res.EXPORTADOS = dataReader[4].ToString();
                    res.PROCESADOS = dataReader[5].ToString();
                    res.CALIBRE = dataReader[1].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GET_ACUM_CAT_GRUPO_VARIEDAD(string variedad, string productor, string lote)
        {
            List<responce_ACUMULADO_VARIEDAD> List = new List<responce_ACUMULADO_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_ACUM_CAT_GRUPO_VARIEDAD]", connection);
            cmd.Parameters.Add(new SqlParameter("@VARIEDAD", variedad));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ACUMULADO_VARIEDAD res = new responce_ACUMULADO_VARIEDAD();

                    res.VARIEDAD = dataReader[0].ToString();
                    //res.SEMANA = dataReader[1].ToString();
                    res.EXPORTADOS = dataReader[4].ToString();
                    res.PROCESADOS = dataReader[5].ToString();
                    res.CATEGORIA = dataReader[1].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GET_ACUM_CAT_VARIEDAD(string variedad, string productor, string lote)
        {
            List<responce_ACUMULADO_VARIEDAD> List = new List<responce_ACUMULADO_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_ACUM_CAT_VARIEDAD]", connection);
            cmd.Parameters.Add(new SqlParameter("@VARIEDAD", variedad));
            cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ACUMULADO_VARIEDAD res = new responce_ACUMULADO_VARIEDAD();

                    res.VARIEDAD = dataReader[0].ToString();
                    //res.SEMANA = dataReader[1].ToString();
                    res.EXPORTADOS = dataReader[4].ToString();
                    res.PROCESADOS = dataReader[5].ToString();
                    res.CATEGORIA = dataReader[1].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GetProduccionDetalleAprobar(string productor, string centro)
        {
            List<responce_PRODUCCIONDETALLEAPROBAR> List = new List<responce_PRODUCCIONDETALLEAPROBAR>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[PORTAL_GET_APRUEBA_PRODUCCION]", connection);
            cmd.Parameters.Add(new SqlParameter("@VAR_PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@CENTRO", centro));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_PRODUCCIONDETALLEAPROBAR res = new responce_PRODUCCIONDETALLEAPROBAR();

                    res.Fecha = dataReader[0].ToString();
                    res.LoteProceso = dataReader[1].ToString();
                    res.Productor = dataReader[2].ToString();
                    res.Variedad = dataReader[3].ToString();
                    res.Especie = dataReader[4].ToString();
                    res.Unidad = dataReader[5].ToString();
                    res.Recibidos = decimal.Parse(dataReader[6].ToString());
                    res.Exportados = decimal.Parse(dataReader[7].ToString());
                    res.Procesados = decimal.Parse(dataReader[8].ToString());
                    res.Calibre = decimal.Parse(dataReader[9].ToString());
                    res.Precalibre = decimal.Parse(dataReader[10].ToString());
                    res.Sobrecalibre = decimal.Parse(dataReader[11].ToString());
                    res.Merma = decimal.Parse(dataReader[12].ToString());
                    res.Desecho = decimal.Parse(dataReader[13].ToString());
                    res.Comercial = decimal.Parse(dataReader[14].ToString());
                    res.Estado = dataReader[15].ToString();
                    res.Industrial = decimal.Parse(dataReader[17].ToString());
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GetInformeAprobado(string centro, string especie, string variedad, string fecha_desde, string fecha_hasta)
        {
            List<responce_INFORME_APROBADO> List = new List<responce_INFORME_APROBADO>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[INFORME_APROBACION]", connection);
            cmd.Parameters.Add(new SqlParameter("@CENTRO", centro));
            cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));
            cmd.Parameters.Add(new SqlParameter("@VARIEDAD", variedad));
            cmd.Parameters.Add(new SqlParameter("@FECHA_DESDE", fecha_desde));
            cmd.Parameters.Add(new SqlParameter("@FECHA_HASTA", fecha_hasta));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_INFORME_APROBADO res = new responce_INFORME_APROBADO();

                    res.PROCESO = dataReader[0].ToString();
                    res.FECHA_PROCESO = dataReader[1].ToString();
                    res.HORA_PROCESO = dataReader[2].ToString();
                    res.HORA_TERMINO = dataReader[3].ToString();
                    res.TERMINO_DEL_PROCESO = dataReader[4].ToString();
                    res.HORA_CIERRE_CUADRATURA = dataReader[5].ToString();
                    res.FECHA_CIERRE_CUADRATURA = dataReader[6].ToString();
                    res.HORA_APROBACION = dataReader[7].ToString();
                    res.FECHA_APROBACION = dataReader[8].ToString();
                    res.TOTAL_HORAS_APROBACION = dataReader[9].ToString();
                    res.TOTAL_HORAS_CUADRATURA = dataReader[10].ToString();
                    res.CUMPLE_PERIODO = dataReader[11].ToString();
                    res.CENTRO = dataReader[12].ToString();
                    res.ESPECIE = dataReader[13].ToString();
                    res.VARIEDAD = dataReader[14].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GetProduccioncCalidadAprobar(string lote)
        {
            List<responce_PRODUCCIONCALIDADAPROBAR> List = new List<responce_PRODUCCIONCALIDADAPROBAR>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[PORTAL_GET_APRUEBA_CALIDAD]", connection);
            cmd.Parameters.Add(new SqlParameter("@LOTE", lote));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;

            


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_PRODUCCIONCALIDADAPROBAR res = new responce_PRODUCCIONCALIDADAPROBAR();

                    res.Fecha = dataReader[3].ToString();
                    res.Lote = dataReader[1].ToString();
                    res.Usuario = dataReader[2].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GetProduccionSateliteAprobar(string productor, string centro)
        {
            List<responce_PRODUCCIONSATELITEAPROBAR> List = new List<responce_PRODUCCIONSATELITEAPROBAR>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[PORTAL_GET_APRUEBA_SATELITE]", connection);
            cmd.Parameters.Add(new SqlParameter("@VAR_PRODUCTOR", productor));
            cmd.Parameters.Add(new SqlParameter("@CENTRO", centro));
            cmd.CommandType = CommandType.StoredProcedure;



            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_PRODUCCIONSATELITEAPROBAR res = new responce_PRODUCCIONSATELITEAPROBAR();


		
                    res.Fecha = dataReader[0].ToString();
                    res.Guia = dataReader[1].ToString();
                    res.Productor = dataReader[2].ToString();
                    res.Variedad = dataReader[3].ToString();
                    res.Especie = dataReader[4].ToString();
                    res.Cajas = dataReader[6].ToString();                   
                    res.CodMat = dataReader[9].ToString();
                    res.Material = dataReader[10].ToString();
                    res.Calidad = dataReader[11].ToString();
                    res.Calibre = dataReader[12].ToString();
                    res.Estado = dataReader[7].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public Array GetProduccionSateliteGuia(string guia)
        {
            List<responce_PRODUCCIONSATELITEAPROBAR> List = new List<responce_PRODUCCIONSATELITEAPROBAR>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[PORTAL_GET_PRODUCCION_SATELITE]", connection);
            cmd.Parameters.Add(new SqlParameter("@GUIA", guia));
            cmd.CommandType = CommandType.StoredProcedure;



            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_PRODUCCIONSATELITEAPROBAR res = new responce_PRODUCCIONSATELITEAPROBAR();



                    res.Fecha = dataReader[0].ToString();
                    res.Guia = dataReader[1].ToString();
                    res.Productor = dataReader[2].ToString();
                    res.Variedad = dataReader[3].ToString();
                    res.Especie = dataReader[4].ToString();
                    res.Cajas = dataReader[5].ToString();
                    res.CodMat = dataReader[6].ToString();
                    res.Material = dataReader[7].ToString();
                    res.Calidad = dataReader[8].ToString();
                    res.Calibre = dataReader[9].ToString();
                    res.Estado = dataReader[10].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }


        public Array GetProduccionResumen(ArrayList productor, string especie, string variedad)
        {
            List<responce_PRODUCCIONRESUMEN> List = new List<responce_PRODUCCIONRESUMEN>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("PORTAL_GET_PRODUCCION_RESUMEN_NEW", connection);


            DataTable dt = new DataTable();
            dt.Columns.Add("Lifnr", typeof(string));

            foreach (var lifnr in productor)
            {
                dt.Rows.Add(new object[] { lifnr });
            }

            SqlParameter p = cmd.Parameters.AddWithValue("@VAR_PRODUCTOR", dt);
            p.SqlDbType = SqlDbType.Structured;
            p.TypeName = "udt_Lifnr";



            cmd.Parameters.Add(new SqlParameter("@VAR_ESPECIE", especie.ToUpper()));
            cmd.Parameters.Add(new SqlParameter("@VAR_VARIEDAD", variedad.ToUpper()));

            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_PRODUCCIONRESUMEN res = new responce_PRODUCCIONRESUMEN();

                    res.Productor = dataReader[0].ToString();
                    res.Especie = dataReader[1].ToString();
                    res.Variedad = dataReader[2].ToString();
                    res.Variedad_Timbrada = dataReader[3].ToString();
                    res.Calidad = dataReader[4].ToString();
                    res.Embalaje = dataReader[5].ToString();
                    res.Calibre = dataReader[6].ToString();
                    res.Unidad = dataReader[7].ToString();                    
                    res.Cantidad = decimal.Parse(dataReader[8].ToString());
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
        public int add_especie_variedad(string especie, string variedad, string desde, string hasta, string temporada)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("ADD_ESPECIE_VARIEDAD", connection);
            cmd.Parameters.Add(new SqlParameter("@especie", especie));
            cmd.Parameters.Add(new SqlParameter("@variedad", variedad));
            cmd.Parameters.Add(new SqlParameter("@desde", desde));
            cmd.Parameters.Add(new SqlParameter("@hasta", hasta));
            cmd.Parameters.Add(new SqlParameter("@temporada", temporada));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }
        public Array getEspVar(string especie, string temporada)
        {
            List<responce_ESPECIE_VARIEDAD> List = new List<responce_ESPECIE_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[PORTAL_GET_ESP_VAR]", connection);
            cmd.Parameters.Add(new SqlParameter("@ESPECIE", especie));
            cmd.Parameters.Add(new SqlParameter("@TEMPORADA", temporada));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ESPECIE_VARIEDAD res = new responce_ESPECIE_VARIEDAD();

                    res.Especie = dataReader[0].ToString();
                    res.Variedad = dataReader[1].ToString();
                    res.Desde = dataReader[2].ToString(); 
                    res.Hasta = dataReader[3].ToString();
                    res.temporada = dataReader[4].ToString();

                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
        public Array getTemporadas()
        {
            List<responce_ESPECIE_VARIEDAD> List = new List<responce_ESPECIE_VARIEDAD>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_TEMPORADAS]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;


            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ESPECIE_VARIEDAD res = new responce_ESPECIE_VARIEDAD();
                    res.codigo = dataReader[0].ToString();
                    res.temporada = dataReader[1].ToString();
                    res.estado = dataReader[2].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }

        public List<responce_LOTES> getLotesByDate(string desde, string hasta)
        {
            
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_LOTESPORFECHA]", connection);
            cmd.Parameters.Add(new SqlParameter("@fechadesde", desde));
            cmd.Parameters.Add(new SqlParameter("@fechahasta", hasta));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;

            
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<responce_LOTES> List = new List<responce_LOTES>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_LOTES l = new responce_LOTES();
                    l.LOTES = dataReader[0].ToString();
                    List.Add(l);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List;

        }


        public List<responce_TEMPORADA_ACTIVA> getTemporadaActiva()
        {
            
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("[GET_DETALLE_TEMPORADA_ACTIVA]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;

            
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<responce_TEMPORADA_ACTIVA> List = new List<responce_TEMPORADA_ACTIVA>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_TEMPORADA_ACTIVA l = new responce_TEMPORADA_ACTIVA();
                    l.ESPECIE = dataReader[0].ToString();
                    l.VARIEDAD = dataReader[1].ToString();
                    l.DESDE = dataReader[2].ToString();
                    l.HASTA = dataReader[3].ToString();
                    l.TEMPORADA = dataReader[4].ToString();
                    List.Add(l);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List;

        }
        public int del_especie_variedad(string especie, string variedad, string temporada)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("DEL_ESPECIE_VARIEDAD", connection);
            cmd.Parameters.Add(new SqlParameter("@especie", especie));
            cmd.Parameters.Add(new SqlParameter("@variedad", variedad));
            cmd.Parameters.Add(new SqlParameter("@temporada", temporada));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }

        public int del_temporada(string temporada)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("DEL_TEMPORADA", connection);
            cmd.Parameters.Add(new SqlParameter("@temporada", temporada));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;

        }

    }
    public class responce_PRODUCCION
    {
        public String Productor;
        public String Variedad;
        public String Especie;
        public String Unidad;
        public decimal Recibidos;
        public decimal Exportados;
        public decimal Procesados;
        public decimal Porcentaje;
    }

    public class responce_PRODUCCIONRESUMEN
    {
        public String Productor;
        public String Especie;
        public String Variedad;
        public String Variedad_Timbrada;
        public String Calidad;
        public String Embalaje;
        public String Calibre;
        public String Unidad;
        public decimal Cantidad;
    }

    public class responce_PRODUCCIONDETALLE
    {
        public string Fecha;
        public string LoteProceso;
        public String Productor;
        public String Variedad;
        public String Especie;
        public String Unidad;
        public decimal Recibidos;
        public decimal Exportados;
        public decimal Procesados;
        public decimal Merma;
        public decimal Desecho;
        public decimal Comercial;

    }

    public class responce_PRODUCCIONDETALLEAPROBAR
    {
        public string Fecha;
        public string LoteProceso;
        public String Productor;
        public String Variedad;
        public String Especie;
        public String Unidad;
        public decimal Recibidos;
        public decimal Exportados;
        public decimal Procesados;
        public decimal Calibre;
        public decimal Precalibre;
        public decimal Sobrecalibre;
        public decimal Merma;
        public decimal Desecho;
        public decimal Comercial;
        public decimal Industrial;
        public String Estado;

    }

    public class responce_PRODUCCIONSATELITEAPROBAR
    {
        public String Fecha;
        public String Guia;
        public String Productor;
        public String Variedad;
        public String Especie;
        public String Cajas;
        public String CodMat;
        public String Material;
        public String Calidad;
        public String Calibre;
        public String Estado;

        
                    
                   
    }
    public class responce_LOTES
    {
        public String LOTES;


    }
    public class responce_PRODUCCIONCALIDADAPROBAR
    {
        public String Fecha;
        public String Lote;
        public String Usuario;
    }
    public class responce_ESPECIE_VARIEDAD
    {
        public String Especie;
        public String Variedad;
        public String Desde;
        public String Hasta;
        public String temporada;
        public String estado;
        public String codigo;
    }
    public class responce_INFORME_APROBADO
    {
        public String PROCESO;
        public String FECHA_PROCESO;
        public String HORA_PROCESO;
        public String TERMINO_DEL_PROCESO;
        public String HORA_CIERRE_CUADRATURA;
        public String FECHA_CIERRE_CUADRATURA;
        public String HORA_APROBACION;
        public String FECHA_APROBACION;
        public String CUMPLE_PERIODO;
        public String TOTAL_HORAS_APROBACION;
        public String TOTAL_HORAS_CUADRATURA;
        public String CENTRO;
        public String ESPECIE;
        public String VARIEDAD;
        public String HORA_TERMINO;
    }

    public class responce_TEMPORADA_ACTIVA
    {
        public String ESPECIE;
        public String VARIEDAD;
        public String TEMPORADA;
        public String DESDE;
        public String HASTA;

    }

    public class responce_ACUMULADO_VARIEDAD
    {
        public String VARIEDAD;
        public String SEMANA;
        public String EXPORTADOS;
        public String PROCESADOS;
        public String CALIBRE;
        public String CATEGORIA;
        public String RECIBIDO;

    }

    public class responce_MAIL
    {
        public String MAIL;
        public String NOMBRE;
        public String ID;
        public String PRODUCTOR;
        public String IP;

    }

    public class responce_FECHA
    {
        public String HOY;
        public String AYER;

    }


}
