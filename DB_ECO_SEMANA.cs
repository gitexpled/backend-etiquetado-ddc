using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Data;

namespace rfcBaika
{
    public class DB_ECO_SEMANA
    {
        public responce_ECO_VALOR_SEMANA run(request_ECO_VALOR_SEMANA datos)
        {
            responce_ECO_VALOR_SEMANA res = new responce_ECO_VALOR_SEMANA();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            String id = datos.id;
            String kilo = datos.kilo;
            String[] tipofrio = datos.tipofrio.Split(',');
            String[] tipofrio2 = datos.tipofrio2.Split(',');
            //JObject root = JObject.Parse(jss);
            //JArray items = (JArray)root["Data"];
            //JObject item;
            //int aux = 0;
            String[] dato = datos.data.Split(',');
            int sm = Convert.ToInt32(datos.semana);
            int sm2 = sm + 1;
            int sm3 = sm + 2;
            int sm4 = sm + 3;
            int sm5 = sm + 4;
            int sm6 = sm + 5;
            int sm7 = sm + 6;
            if (sm == 52)
            {
                sm2 = 1;
                sm3 = 2;
                sm4 = 3;
                sm5 = 4;
                sm6 = 5;
                sm7 = 6;
            }
            if (sm == 51)
            {
                sm3 = 1;
                sm4 = 2;
                sm5 = 3;
                sm6 = 4;
                sm7 = 5;
            }
            if (sm == 50)
            {
                sm4 = 1;
                sm5 = 2;
                sm6 = 3;
                sm7 = 4;
            }
            if (sm == 49)
            {
                sm5 = 1;
                sm6 = 2;
                sm7 = 3;
            }
            if (sm == 48)
            {
                sm6 = 1;
                sm7 = 2;
            }
            if (sm == 49)
            {
                sm7 = 1;
            }

            //String sql = "";
            // JToken jtoken;
            //for (int i = 0; i < items.Count; i++) //loop through rows
            //{
                //item = (JObject)items[i];
                //JObject Semana = (JObject)item["valoresSemana"];
                //aux = Convert.ToInt32(item["Nsemana"]);
                //Convert.ToInt32();
                try
                {
                   // for (int x = 0; x < 4; x++)
                    //{
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = connection;
                        SqlCommand cmd = new SqlCommand();
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd = new SqlCommand("UPDATE_DETALLE_DIARIO", connection);
                        cmd.Parameters.Add(new SqlParameter("@IDANUAL", Convert.ToInt32(id) ));
                        cmd.Parameters.Add(new SqlParameter("@SM1", sm));
                        cmd.Parameters.Add(new SqlParameter("@SM2", sm2));
                        cmd.Parameters.Add(new SqlParameter("@SM3", sm3));
                        cmd.Parameters.Add(new SqlParameter("@SM4", sm4));
                        cmd.Parameters.Add(new SqlParameter("@SM5", sm5));
                        cmd.Parameters.Add(new SqlParameter("@SM6", sm6));
                        cmd.Parameters.Add(new SqlParameter("@SM7", sm7));

                        cmd.Parameters.Add(new SqlParameter("@L1", Convert.ToInt32(dato[1])));
                        cmd.Parameters.Add(new SqlParameter("@M1", Convert.ToInt32(dato[2])));
                        cmd.Parameters.Add(new SqlParameter("@MI1",Convert.ToInt32(dato[3])));
                        cmd.Parameters.Add(new SqlParameter("@J1", Convert.ToInt32(dato[4])));
                        cmd.Parameters.Add(new SqlParameter("@V1", Convert.ToInt32(dato[5])));
                        cmd.Parameters.Add(new SqlParameter("@S1", Convert.ToInt32(dato[6])));
                        cmd.Parameters.Add(new SqlParameter("@D1", Convert.ToInt32(dato[7])));
                        cmd.Parameters.Add(new SqlParameter("@T1", Convert.ToInt32(dato[8])));

                        cmd.Parameters.Add(new SqlParameter("@L2", Convert.ToInt32(dato[9])));
                        cmd.Parameters.Add(new SqlParameter("@M2", Convert.ToInt32(dato[10])));
                        cmd.Parameters.Add(new SqlParameter("@MI2",Convert.ToInt32(dato[11])));
                        cmd.Parameters.Add(new SqlParameter("@J2", Convert.ToInt32(dato[12])));
                        cmd.Parameters.Add(new SqlParameter("@V2", Convert.ToInt32(dato[13])));
                        cmd.Parameters.Add(new SqlParameter("@S2", Convert.ToInt32(dato[14])));
                        cmd.Parameters.Add(new SqlParameter("@D2", Convert.ToInt32(dato[15])));
                        cmd.Parameters.Add(new SqlParameter("@T2", Convert.ToInt32(dato[16])));

                        cmd.Parameters.Add(new SqlParameter("@L3", Convert.ToInt32(dato[17])));
                        cmd.Parameters.Add(new SqlParameter("@M3", Convert.ToInt32(dato[18])));
                        cmd.Parameters.Add(new SqlParameter("@MI3", Convert.ToInt32(dato[19])));
                        cmd.Parameters.Add(new SqlParameter("@J3", Convert.ToInt32(dato[20])));
                        cmd.Parameters.Add(new SqlParameter("@V3", Convert.ToInt32(dato[21])));
                        cmd.Parameters.Add(new SqlParameter("@S3", Convert.ToInt32(dato[22])));
                        cmd.Parameters.Add(new SqlParameter("@D3", Convert.ToInt32(dato[23])));
                        cmd.Parameters.Add(new SqlParameter("@T3", Convert.ToInt32(dato[24])));

                        cmd.Parameters.Add(new SqlParameter("@T4", Convert.ToInt32(dato[25])));
                        cmd.Parameters.Add(new SqlParameter("@T5", Convert.ToInt32(dato[26])));
                        cmd.Parameters.Add(new SqlParameter("@T6", Convert.ToInt32(dato[27])));
                        cmd.Parameters.Add(new SqlParameter("@T7", Convert.ToInt32(dato[28])));    
                        cmd.Parameters.Add(new SqlParameter("@kilo", kilo));
                        cmd.Parameters.Add(new SqlParameter("@calibre", datos.calibre));
                        cmd.Parameters.Add(new SqlParameter("@calibre2", datos.calibre2));
                        cmd.Parameters.Add(new SqlParameter("@hcalibre", datos.hcalibre));
                        cmd.Parameters.Add(new SqlParameter("@tipificacion", datos.tipificacion));
                        cmd.Parameters.Add(new SqlParameter("@tipificacion2", datos.tipificacion2));   
                        cmd.Parameters.Add(new SqlParameter("@htipificacion", datos.htipificacion));
                        if (datos.tipofrio != "")
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
                        if (datos.tipofrio2 != "")
                        {
                            cmd.Parameters.Add(new SqlParameter("@tipofrio2", Convert.ToInt32(tipofrio2[1])));
                            cmd.Parameters.Add(new SqlParameter("@atm_cot2", Convert.ToInt32(tipofrio2[2])));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@tipofrio2", 1));
                            cmd.Parameters.Add(new SqlParameter("@atm_cot2", 1));

                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Close();
                      
                    //}
                    res.ok = "Todo Bien ";
                }
                catch (Exception e)
                {
                    res.error = e.ToString();
                }

           // }
            connection.Close();
            connection.Dispose();
            return res;

            /*String jss = datos.Semana;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Data"];
            JObject item;
            int aux = 0;
            String aux2 = datos.mod;
            String sql = "";
            // JToken jtoken;
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                JObject Semana = (JObject)item["valoresSemana"];
                aux = Convert.ToInt32(item["Nsemana"]);
                //Convert.ToInt32();
                try
                {
                    for (int x = 0; x < 4; x++)
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = connection;
                        SqlCommand cmd = new SqlCommand();
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd = new SqlCommand("ECO_SEMANA", connection);
                        cmd.Parameters.Add(new SqlParameter("@Productor", item["Productor"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Especie", item["especie"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Variedad", item["variedad"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@centro", item["centro"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Semana", (aux+1)));
                        cmd.Parameters.Add(new SqlParameter("@usuario", item["usuario"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@Consulta", aux2));
                        cmd.Parameters.Add(new SqlParameter("@Valor_estimado", Convert.ToInt32(Semana["s" + (x + 1)]["total"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@Lun", Convert.ToInt32(Semana["s" + (x + 1)]["l"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@Mar", Convert.ToInt32(Semana["s" + (x + 1)]["m"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@MIER", Convert.ToInt32(Semana["s" + (x + 1)]["mi"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@JUE", Convert.ToInt32(Semana["s" + (x + 1)]["j"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@VIER", Convert.ToInt32(Semana["s" + (x + 1)]["v"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@SAB", Convert.ToInt32(Semana["s" + (x + 1)]["s"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@DOM", Convert.ToInt32(Semana["s" + (x + 1)]["d"].ToString())));
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Close();
                        aux = aux + 1;
                    }
                    res.ok = "Todo Bien ";
                }
                catch (Exception e)
                {
                    res.error = e.ToString();
                }

            }
            connection.Close();
            connection.Dispose();
            return res;*/

        }
    }
     public class responce_ECO_VALOR_SEMANA {
         public String error;
         public String ok; 
     }
     public class request_ECO_VALOR_SEMANA {
         public String id;
         public String data;
         public String semana;
         public String kilo;
         public String calibre;
         public String calibre2;
         public String tipificacion;
         public String tipofrio;
         public String tipificacion2;
         public String tipofrio2;
         public String hcalibre;
         public String htipificacion;
         public String htipofrio;
     }
}