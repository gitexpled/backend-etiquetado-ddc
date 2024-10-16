
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
    public class DB_ECO_INSERT_FT_VARIEDAD
    {
        public responce_DB_ECO_INSERT_FT_VARIEDAD run(request_DB_ECO_INSERT_FT_VARIEDAD datos)
        {
            responce_DB_ECO_INSERT_FT_VARIEDAD res = new responce_DB_ECO_INSERT_FT_VARIEDAD();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("INSERT_VARIEDAD", connection);
                cmd.Parameters.Add(new SqlParameter("@id", datos.id));
                cmd.Parameters.Add(new SqlParameter("@id_especie", Convert.ToInt32(datos.id_especie)));
                cmd.Parameters.Add(new SqlParameter("@variedad", datos.variedad));
                cmd.Parameters.Add(new SqlParameter("@dis_entre_hileras", datos.dis_entre_hileras));
                cmd.Parameters.Add(new SqlParameter("@dis_sobre_hileras", datos.dis_sobre_hileras));
                cmd.Parameters.Add(new SqlParameter("@arb_productivos", datos.arb_productivos));
                cmd.Parameters.Add(new SqlParameter("@planta_por_ha", datos.planta_por_ha));
                cmd.Parameters.Add(new SqlParameter("@superficie", datos.superficie));
                cmd.Parameters.Add(new SqlParameter("@plantas_totales", datos.plantas_totales));
                cmd.Parameters.Add(new SqlParameter("@ano_plantacion", datos.ano_plantacion));
                cmd.Parameters.Add(new SqlParameter("@uniformidad", datos.uniformidad));
                cmd.Parameters.Add(new SqlParameter("@central_cargo", datos.central_cargo));
                cmd.Parameters.Add(new SqlParameter("@tipo_packing", datos.tipo_packing));
                cmd.Parameters.Add(new SqlParameter("@tipo_riesgo", datos.tipo_riesgo));
                cmd.Parameters.Add(new SqlParameter("@csp", datos.csp));
                cmd.Parameters.Add(new SqlParameter("@idp", datos.idp));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();



                dr.Close();
                res.ok = "Todo Bien ";
            }
            catch (Exception e)
            {
                res.error = e.ToString();
            }
                
            
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class responce_DB_ECO_INSERT_FT_VARIEDAD
    {
        public String error;
        public String ok;
    }
    public class request_DB_ECO_INSERT_FT_VARIEDAD
    {
        public String id;
        public String id_especie;
        public String variedad;
        public String dis_entre_hileras;
        public String dis_sobre_hileras;
        public String arb_productivos;
        public String planta_por_ha;
        public String superficie;
        public String plantas_totales;
        public String ano_plantacion;
        public String uniformidad;
        public String central_cargo;
        public String tipo_packing;
        public String tipo_riesgo;
        public String csp;
        public String idp;
    }
}