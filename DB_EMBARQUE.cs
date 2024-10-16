using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace rfcBaika
{
    public class DB_EMBARQUE
    {

        public static RespBM EjecutaEmbarque(string param)
        {
            RespBM resp = new RespBM();
            dynamic obj = JsonConvert.DeserializeObject(param);
                List<responce_DB_EMBARQUE> List = new List<responce_DB_EMBARQUE>();
                List<responce_all_data> List2 = new List<responce_all_data>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("EMBARQUE_JSN", connection);
                cmd.Parameters.Add(new SqlParameter("@consulta", obj.consulta.ToString()));
                cmd.Parameters.Add(new SqlParameter("@contenedor", obj.contenedor.ToString()));
                cmd.Parameters.Add(new SqlParameter("@embarque", obj.embarque.ToString()));
                cmd.Parameters.Add(new SqlParameter("@centro", obj.centro.ToString()));
                cmd.Parameters.Add(new SqlParameter("@especie", obj.especie.ToString()));
                cmd.Parameters.Add(new SqlParameter("@variedad", obj.variedad.ToString()));
                cmd.Parameters.Add(new SqlParameter("@fecha", obj.fecha.ToString()));
                cmd.Parameters.Add(new SqlParameter("@jsn", obj.jsn.ToString()));
                cmd.Parameters.Add(new SqlParameter("@id", (obj.id == null)?"0":obj.id.ToString()));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (obj.consulta == "i" || obj.consulta == "s" || obj.consulta == "a")
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            responce_DB_EMBARQUE res = new responce_DB_EMBARQUE();
                            res.json = dr[7].ToString();
                            res.id = dr[0].ToString();
                            res.contenedor = dr[1].ToString();
                            res.centro = dr[3].ToString();
                            res.Status = "OK";
                            List.Add(res);
                        }

                    }
                    resp.resp = true;
                }
                else if( obj.consulta == "aa"){
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            responce_all_data res = new responce_all_data();
                            res.contenedor = dr[0].ToString();
                            res.embarque = dr[1].ToString();
                            res.centro = dr[2].ToString();
                            res.especie = dr[3].ToString();
                            res.variedad = dr[4].ToString();
                            res.fecha = dr[5].ToString();
                            res.json_data = dr[6].ToString();
                            res.json_salida = dr[7].ToString();
                            res.pdf = dr[8].ToString();
                            List2.Add(res);
                        }

                    }
                    resp.resp = true;
                }
                else
                {
                    responce_DB_EMBARQUE resp2 = new responce_DB_EMBARQUE();
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

                responce_DB_EMBARQUE resp2 = new responce_DB_EMBARQUE();
                resp2.Status = e.ToString();
                List.Add(resp2);
                resp.resp = false;
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            //resp.mensaje = (obj.consulta == "aa") ? List2 : List;
            if (obj.consulta == "aa")
            {
                resp.mensaje = List2;
            }
            else {
                resp.mensaje = List;
            }
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
    public class responce_DB_EMBARQUE
    {
        public String json;
        public String contenedor;
        public String centro;
        public String id;
        public String Status;
    }
    public class responce_all_data
    {
        public String contenedor;
        public String embarque;
        public String centro;
        public String especie;
        public String variedad;
        public String fecha;
        public String json_data;
        public String json_salida;
        public String pdf;
    }
}