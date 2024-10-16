using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_ELIMINAR_ET
    {
        public responce_eliminar_et run(request_eliminar_et datos)
        {
            responce_eliminar_et res = new responce_eliminar_et();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("ELIMINAR_ET", connection);
                cmd.Parameters.Add(new SqlParameter("@proceso", datos.PROCESO));
                cmd.Parameters.Add(new SqlParameter("@id_posicion", Convert.ToInt32(datos.ID_POSICION)));
                cmd.Parameters.Add(new SqlParameter("@id_etiqueta", Convert.ToInt32(datos.ID_ETIQUETA)));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    res.resp = dr[0].ToString();


                }
            }
            catch (Exception e)
            {
                res.resp = e.ToString();
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return res;
        }
    }

    public class responce_eliminar_et
    {
        public String resp;
    }
    public class request_eliminar_et
    {
        public String PROCESO;
        public String ID_POSICION;
        public String ID_ETIQUETA;
    }
}