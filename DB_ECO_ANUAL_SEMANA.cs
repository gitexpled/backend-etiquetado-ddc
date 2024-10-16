using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;

namespace rfcBaika
{
    public class DB_ECO_ANUAL_SEMANA
    {
        public responce_ECO_ANUAL_SEMANA run(request_ECO_ANUAL_SEMANA datos)
        {
            responce_ECO_ANUAL_SEMANA res = new responce_ECO_ANUAL_SEMANA();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String jss = datos.Semana;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Data"];
            JObject item;
            int aux = items.Count - 1;

            //String[] calibre = datos.Calibre.Split(',');
            String[] ingresos = datos.Ingreso.Split(',');
            String[] tipofrio = datos.Tipofrio.Split(',');
            //String[] tipificacion = datos.Tipificacion.Split(',');
           
            // JToken jtoken;
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                if (i == 0)
                {
                    item = (JObject)items[i];
                    JObject Semana = (JObject)item["valoresSemana"];

                    //Convert.ToInt32();
                    try
                    {

                        SqlCommand comm = new SqlCommand();
                        comm.Connection = connection;
                        SqlCommand cmd = new SqlCommand();
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd = new SqlCommand("ECO_ANUAL_SEMANA", connection);
                        cmd.Parameters.Add(new SqlParameter("@Productor", item["Productor"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Especie", item["especie"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Variedad", (item["variedad"].ToString().Replace("'"," "))));
                        cmd.Parameters.Add(new SqlParameter("@centro", item["centro"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@fecha", item["Fecha"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@usuario", item["usuario"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@S1", Convert.ToInt32(Semana["s1"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S2", Convert.ToInt32(Semana["s2"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S3", Convert.ToInt32(Semana["s3"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S4", Convert.ToInt32(Semana["s4"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S5", Convert.ToInt32(Semana["s5"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S6", Convert.ToInt32(Semana["s6"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S7", Convert.ToInt32(Semana["s7"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S8", Convert.ToInt32(Semana["s8"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S9", Convert.ToInt32(Semana["s9"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S10", Convert.ToInt32(Semana["s10"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S11", Convert.ToInt32(Semana["s11"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S12", Convert.ToInt32(Semana["s12"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S13", Convert.ToInt32(Semana["s13"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S14", Convert.ToInt32(Semana["s14"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S15", Convert.ToInt32(Semana["s15"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S16", Convert.ToInt32(Semana["s16"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S17", Convert.ToInt32(Semana["s17"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S18", Convert.ToInt32(Semana["s18"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S19", Convert.ToInt32(Semana["s19"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S20", Convert.ToInt32(Semana["s20"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S21", Convert.ToInt32(Semana["s21"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S22", Convert.ToInt32(Semana["s22"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S23", Convert.ToInt32(Semana["s23"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S24", Convert.ToInt32(Semana["s24"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S25", Convert.ToInt32(Semana["s25"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S26", Convert.ToInt32(Semana["s26"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S27", Convert.ToInt32(Semana["s27"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S28", Convert.ToInt32(Semana["s28"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S29", Convert.ToInt32(Semana["s29"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S30", Convert.ToInt32(Semana["s30"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S31", Convert.ToInt32(Semana["s31"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S32", Convert.ToInt32(Semana["s32"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S33", Convert.ToInt32(Semana["s33"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S34", Convert.ToInt32(Semana["s34"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S35", Convert.ToInt32(Semana["s35"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S36", Convert.ToInt32(Semana["s36"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S37", Convert.ToInt32(Semana["s37"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S38", Convert.ToInt32(Semana["s38"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S39", Convert.ToInt32(Semana["s39"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S40", Convert.ToInt32(Semana["s40"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S41", Convert.ToInt32(Semana["s41"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S42", Convert.ToInt32(Semana["s42"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S43", Convert.ToInt32(Semana["s43"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S44", Convert.ToInt32(Semana["s44"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S45", Convert.ToInt32(Semana["s45"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S46", Convert.ToInt32(Semana["s46"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S47", Convert.ToInt32(Semana["s47"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S48", Convert.ToInt32(Semana["s48"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S49", Convert.ToInt32(Semana["s49"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S50", Convert.ToInt32(Semana["s50"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S51", Convert.ToInt32(Semana["s51"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@S52", Convert.ToInt32(Semana["s52"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@Nombre", item["nombre"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Estado", item["estado"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Consulta", item["CONSULTA"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(item["id"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@iExportacion", Convert.ToInt32(ingresos[1])));
                        cmd.Parameters.Add(new SqlParameter("@iMerma", Convert.ToInt32(ingresos[2])));
                        cmd.Parameters.Add(new SqlParameter("@iComercial", Convert.ToInt32(ingresos[3])));
                        cmd.Parameters.Add(new SqlParameter("@calibre", datos.Calibre.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@hcalibre", datos.HCalibre));
                        cmd.Parameters.Add(new SqlParameter("@tipificacion", datos.Tipificacion.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@htipificacion", datos.HTipificacion.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@kilo", datos.Kilo));
                        cmd.Parameters.Add(new SqlParameter("@ano", datos.Ano));
                        if (datos.Tipofrio != "")
                        {
                            
                            cmd.Parameters.Add(new SqlParameter("@itipofrio", "y"));
                            cmd.Parameters.Add(new SqlParameter("@tipofrio", Convert.ToInt32(tipofrio[1])));
                            cmd.Parameters.Add(new SqlParameter("@atm_cot", Convert.ToInt32(tipofrio[2])));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@itipofrio", "n"));
                            cmd.Parameters.Add(new SqlParameter("@tipofrio", 1));
                            cmd.Parameters.Add(new SqlParameter("@atm_cot", 1));

                        }
                        cmd.Parameters.Add(new SqlParameter("@SM1", datos.SM1));
                        cmd.Parameters.Add(new SqlParameter("@SM2", datos.SM2));
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();



                        dr.Close();
                        res.ok = "Todo Bien ";
                    }
                    catch (Exception e)
                    {
                        res.error = e.ToString();
                    }
                }
            }
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class responce_ECO_ANUAL_SEMANA
    {
        public String error;
        public String ok;
    }
    public class request_ECO_ANUAL_SEMANA
    {
        public String Semana;
        public String Calibre;
        public String HCalibre;
        public String Ingreso;
        public String Tipificacion;
        public String HTipificacion;
        public String Tipofrio;
        public String Kilo;
        public String Ano;
        public String SM1;
        public String SM2;
    }
}