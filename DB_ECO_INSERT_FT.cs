
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
    public class DB_ECO_INSERT_FT
    {
        public responce_DB_ECO_INSERT_FT run(request_DB_ECO_INSERT_FT datos)
        {
            responce_DB_ECO_INSERT_FT res = new responce_DB_ECO_INSERT_FT();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("INSERT_FICHA_TECNICA", connection);
                cmd.Parameters.Add(new SqlParameter("@idft", datos.idft));
                cmd.Parameters.Add(new SqlParameter("@productor", datos.productor));
                cmd.Parameters.Add(new SqlParameter("@nombre", datos.nombre));
                cmd.Parameters.Add(new SqlParameter("@huerto", datos.huerto));
                cmd.Parameters.Add(new SqlParameter("@csg", datos.csg));
                cmd.Parameters.Add(new SqlParameter("@idp", datos.idp));
                cmd.Parameters.Add(new SqlParameter("@georeferenciacion", datos.georeferenciacion));
                cmd.Parameters.Add(new SqlParameter("@usuario", datos.usuario));
                cmd.Parameters.Add(new SqlParameter("@temporada", datos.temporada));
                cmd.Parameters.Add(new SqlParameter("@especie", datos.especie));
                cmd.Parameters.Add(new SqlParameter("@cuartel", datos.cuartel));
                cmd.Parameters.Add(new SqlParameter("@tipo_cert", datos.tipo_cert));
                cmd.Parameters.Add(new SqlParameter("@ggn", datos.ggn));
                cmd.Parameters.Add(new SqlParameter("@ggnd", datos.ggnd));
                cmd.Parameters.Add(new SqlParameter("@ggnh", datos.ggnh));
                cmd.Parameters.Add(new SqlParameter("@variedad", datos.variedad));
                cmd.Parameters.Add(new SqlParameter("@diss", datos.diss));
                cmd.Parameters.Add(new SqlParameter("@dise", datos.dise));
                cmd.Parameters.Add(new SqlParameter("@arb", datos.arb));
                cmd.Parameters.Add(new SqlParameter("@plantas_ha", datos.plantas_ha));
                cmd.Parameters.Add(new SqlParameter("@superficie", datos.superficie));
                cmd.Parameters.Add(new SqlParameter("@plan_totales", datos.plan_totales));
                cmd.Parameters.Add(new SqlParameter("@ano_plan", datos.ano_plan));
                cmd.Parameters.Add(new SqlParameter("@uniformidad", datos.uniformidad));
                cmd.Parameters.Add(new SqlParameter("@central_cargo", datos.central_cargo));
                cmd.Parameters.Add(new SqlParameter("@tipo_packing", datos.tipo_packing));
                cmd.Parameters.Add(new SqlParameter("@tipo_riesgo", datos.tipo_riesgo));
                cmd.Parameters.Add(new SqlParameter("@cspv", datos.cspv));
                cmd.Parameters.Add(new SqlParameter("@idpv", datos.idpv));
  
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
    public class responce_DB_ECO_INSERT_FT
    {
        public String error;
        public String ok;
    }
    public class request_DB_ECO_INSERT_FT
    {
        public String idft;
        public String productor;
        public String nombre;
        public String huerto;
        public String csg;
        public String idp;
        public String georeferenciacion;
        public String usuario;
        public String temporada;

        public String especie;
        public String cuartel;
        public String tipo_cert;
        public String ggn;
        public String ggnd;
        public String ggnh;

        public String variedad;
        public String dise;
        public String diss;
        public String arb;
        public String plantas_ha;
        public String superficie;
        public String plan_totales;
        public String ano_plan;
        public String uniformidad;
        public String central_cargo;
        public String tipo_packing;
        public String tipo_riesgo;
        public String cspv;
        public String idpv;
    
    
    }
}