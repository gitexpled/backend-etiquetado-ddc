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
    public class DB_EMBARQUE_CORREOS
    {
        public static RespBM EjecutaEmbarqueCorreos(string param)
        {
            RespBM resp = new RespBM();
            dynamic obj = JsonConvert.DeserializeObject(param);
            List<responce_DB_EMBARQUE_CORREOS> List = new List<responce_DB_EMBARQUE_CORREOS>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("EMBARQUE_CORREOS", connection);
                cmd.Parameters.Add(new SqlParameter("@consulta", obj.consulta.ToString()));
                cmd.Parameters.Add(new SqlParameter("@usuario", obj.usuario.ToString()));
                cmd.Parameters.Add(new SqlParameter("@email", obj.email.ToString()));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (obj.consulta != "d")
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            responce_DB_EMBARQUE_CORREOS res = new responce_DB_EMBARQUE_CORREOS();
                            res.usuario = dr[1].ToString();
                            res.correos = dr[2].ToString();
                            res.Status = "OK";
                            List.Add(res);
                        }

                    }
                    resp.resp = true;
                }
                else
                {
                    responce_DB_EMBARQUE_CORREOS resp2 = new responce_DB_EMBARQUE_CORREOS();
                    resp2.Status = "OK";
                    if (dr.Read())
                    {
                        //sresp2.json = dr[0].ToString();


                    }
                    resp.resp = true;
                    List.Add(resp2);
                }
            }
            catch (Exception e)
            {

                responce_DB_EMBARQUE_CORREOS resp2 = new responce_DB_EMBARQUE_CORREOS();
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
    public class responce_DB_EMBARQUE_CORREOS
    {
        public String usuario;
        public String correos;
        public String Status;
    }
}