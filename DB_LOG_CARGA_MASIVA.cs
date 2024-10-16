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
    public class DB_LOG_CARGA_MASIVA
    {
        public responce_LOG_CARGA_MASIVA run(request_LOG_CARGA_MASIVA datos)
        {
            responce_LOG_CARGA_MASIVA res = new responce_LOG_CARGA_MASIVA();
            String _connectionString = ConfigurationManager.ConnectionStrings["DDCTEST"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String jss = datos.Data;
            JObject root = JObject.Parse(jss);
            JArray items = (JArray)root["Data"];
            JObject item;
            int aux = items.Count - 1;
            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                item = (JObject)items[i];
                //JObject Semana = (JObject)item["valoresSemana"];

                //Convert.ToInt32();
                try
                {

                    JObject rootError = JObject.Parse(item["arrRespuestas"].ToString());
                    JArray itemsError = (JArray)rootError["arrRespuestas"];
                    JObject itemError;
                    for (int y = 0; y < itemsError.Count; y++) //loop through rows
                    {
                        itemError = (JObject)itemsError[y][0];
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = connection;
                        SqlCommand cmd = new SqlCommand();
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd = new SqlCommand("INSERT_LOG_CARGA_MASIVA", connection);
                        cmd.Parameters.Add(new SqlParameter("@CENTRO", item["CENTRO"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@PRODUCTOR", item["PRODUCTOR"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@FCONTAB", item["FECHACONTABILIZACION"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@PALLET", item["UM"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@MATERIAL", item["CODMATERIAL"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@VARIEDAD", item["VARIEDAD"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@CANTIDAD", Convert.ToInt32(item["CANTIDAD"].ToString())));
                        cmd.Parameters.Add(new SqlParameter("@PALLETCOMPLETO", item["PALLETCOMPLETO"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@MOV_311", item["mov_311"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@MOV_101", item["e_material"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@MOV_543", item["material"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@MOV_543_PALLET", item["materialPallet"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@PEDIDO", item["pedido"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@PEDIDO_PALLET", item["pedidoPallet"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@MOV_541", item["mov_541"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@MOV_541_PALLET", item["mov_541Pallet"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@RESPUESTA", item["respuestas"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@TIPO", item["tipo"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@MATERIAL_RESP", itemError["material_resp"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@CANTIDAD_RESP", itemError["cantidad_resp"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@UNIDAD_RESP", itemError["unidad_resp"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@ALMACEN_RESP", itemError["almacen_resp"].ToString()));
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();



                        dr.Close();
                        res.ok = "Todo Bien ";
                    }
                }
                catch (Exception e)
                {
                    res.error = e.ToString();
                }
                
            }
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class responce_LOG_CARGA_MASIVA
    {
        public String error;
        public String ok;
    }
    public class request_LOG_CARGA_MASIVA
    {
        public String Data;
    }
}