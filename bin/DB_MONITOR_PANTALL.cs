using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace rfcBaika
{
    public class DB_MONITOR_PANTALLA
    {
        public ArrayList run(string centro)
        {

            ArrayList respuesta = new ArrayList();
            string RANGO_ALERTA_PANTALLA = ConfigurationManager.AppSettings["RANGO_ALERTA_PANTALLA"];
            responce_DB_MONITOR_PANTALLA res = new responce_DB_MONITOR_PANTALLA();
            String _connectionString = ConfigurationManager.ConnectionStrings["DDC_ETIQUETADO"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "  select pu.* from [dbo].[pantallas_update] pu left join pantallas p on pu.ip_pantalla = p.ip_pantalla where [centro]  ='" + centro + "' ;";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                double rango_alerta = double.Parse(RANGO_ALERTA_PANTALLA);

                while (dataReader.Read())
                {
                    res = new responce_DB_MONITOR_PANTALLA();

                    res.ippantalla = dataReader[0].ToString();

                    DateTime actualizacion = DateTime.Parse(dataReader[1].ToString());

                    TimeSpan diferencia = DateTime.Now - actualizacion;

                    // Obtener la diferencia en minutos
                    double minutos = diferencia.TotalMinutes;


                    if (minutos > rango_alerta)
                    {
                        res.estado = 1;
                    }
                    else
                    {
                        res.estado = 0;
                    }
                    
                    
                    respuesta.Add(res);
                    
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return respuesta;
        }


        public bool InsertLog(string ip)
        {
            responce_DB_ETIQUETA_CORRELATIVO response = new responce_DB_ETIQUETA_CORRELATIVO();

            String _connectionString = ConfigurationManager.ConnectionStrings["DDC_ETIQUETADO"].ToString();// DDC_ETIQUETADO(PRD) - CSPORTAL (PRD)
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "set_logpantalla";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;            
            cmd.Parameters.Add(new SqlParameter("@ip_pantalla", ip));
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            string resp = "";
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    
                    resp = dataReader[0].ToString();
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return true;
        }
    }
    
    public class responce_DB_MONITOR_PANTALLA
    {
        public String ippantalla;
        public int estado;

    }
}