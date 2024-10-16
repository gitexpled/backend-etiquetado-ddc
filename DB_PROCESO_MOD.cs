using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_PROCESO_MOD
    {
        public responce_DB_PROCESO_MOD run(request_DB_PROCESO_MOD datos)
        {
            responce_DB_PROCESO_MOD res = new responce_DB_PROCESO_MOD();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
                {
                cmd = new SqlCommand("PROCESO_MOD", connection);
                cmd.Parameters.Add(new SqlParameter("@proceso", datos.Proceso));
                cmd.Parameters.Add(new SqlParameter("@kilos", float.Parse(datos.kilos.ToString())));
                cmd.Parameters.Add(new SqlParameter("@ip_pantalla", datos.ip_pantalla));
                cmd.Parameters.Add(new SqlParameter("@posicion", datos.posicion));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    res.res = dr[0].ToString();


                }
                }
            catch (Exception e)
            {
                res.res = e.ToString();
            }
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class responce_DB_PROCESO_MOD
    {
        public String res;
    }
    public class request_DB_PROCESO_MOD
    {
        public String ip_pantalla;
        public String posicion;
        public String kilos;
        public String Proceso;
    }
}
/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_PROCESO_MOD
    {
        public responce_DB_PROCESO_MOD run(request_DB_PROCESO_MOD datos)
        {
            responce_DB_PROCESO_MOD res = new responce_DB_PROCESO_MOD();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "";
            int aux = 2;
            for (int i = 0; i < aux; i++)
            {

                if (i == 0)
                {
                    sql = "update proceso set kilos_etiquetas = kilos_etiquetas+" + datos.posicion + " where proceso = '" + datos.Proceso + "'";

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Close();
                    res.res = "ok-";
                }
                if (i == 1)
                {
                    sql = "update zpl_ventana" +
                            " set stock = stock - 1" +
                            " where id_posicion = (select id from posicion_zpl where ip_pantalla = '" + datos.ip_pantalla + "' and pantalla_zpl = " + datos.posicion + ")" +
                            " and stock > 0";

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Close();
                    res.res = res.res + "ok";
                }
                
            }   
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class responce_DB_PROCESO_MOD
    {
        public String res;
    }
    public class request_DB_PROCESO_MOD
    {
        public String ip_pantalla;
        public String posicion;
        public String kilos;
        public String Proceso;
    }
}
 */