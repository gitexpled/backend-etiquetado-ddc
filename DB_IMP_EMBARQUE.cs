using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_IMP_EMBARQUE
    {

        public static RespBM EjecutaIMPEmbarque(string param)
        {
            RespBM resp = new RespBM();
            dynamic obj = JsonConvert.DeserializeObject(param);
            List<responce_DB_IMP_EMBARQUE> List = new List<responce_DB_IMP_EMBARQUE>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("IMP_EMBARQUE_JSN", connection);
                cmd.Parameters.Add(new SqlParameter("@consulta", obj.consulta.ToString()));
                cmd.Parameters.Add(new SqlParameter("@contenedor", obj.contenedor.ToString()));
                cmd.Parameters.Add(new SqlParameter("@embarque", obj.embarque.ToString()));
                cmd.Parameters.Add(new SqlParameter("@jsn", obj.jsn.ToString()));
                cmd.Parameters.Add(new SqlParameter("@link", obj.link.ToString()));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (obj.consulta != "d")
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            responce_DB_IMP_EMBARQUE res = new responce_DB_IMP_EMBARQUE();
                            res.json = dr[3].ToString();
                            res.contenedor = dr[2].ToString();
                            res.embarque = dr[1].ToString();
                            res.link = dr[5].ToString();
                            res.Status = "OK";
                            List.Add(res);
                        }

                    }
                    resp.resp = true;
                }
                else
                {
                    responce_DB_IMP_EMBARQUE resp2 = new responce_DB_IMP_EMBARQUE();
                    resp2.Status = "OK";
                    if (dr.Read())
                    {
                        resp2.json = dr[0].ToString();


                    }
                    resp.resp = true;
                    List.Add(resp2);
                }
            }
            catch (Exception e)
            {

                responce_DB_IMP_EMBARQUE resp2 = new responce_DB_IMP_EMBARQUE();
                resp2.Status = e.ToString();
                List.Add(resp2);
                resp.resp = false;
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            resp.mensaje = List;
            resp.origen = "EMBARQUE_JSN";

            return resp;
        }
        public class RespBM
        {
            public Boolean resp;
            public dynamic mensaje;
            public String origen;
        }
    }
    public class responce_DB_IMP_EMBARQUE
    {
        public String json;
        public String contenedor;
        public String embarque;
        public String Status;
        public String link;
    }
}