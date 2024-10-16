using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_SELECCION_ETIQUETA
    {
        public Array run(request_SELECCION_ETIQUETA datos)
        {
            List<responce_SELECCION_ETIQUETA> List = new List<responce_SELECCION_ETIQUETA>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select * from zpl where ISNULL(estado,0) = 0";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            Int16 i = 0;
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_SELECCION_ETIQUETA res = new responce_SELECCION_ETIQUETA();
                    res.id = dataReader[0].ToString();
                    res.zpl = dataReader[1].ToString();
                    res.fecha = dataReader[2].ToString();
                    res.densidad = dataReader[3].ToString();
                    res.tamanio = dataReader[4].ToString();
                    res.stock = dataReader[5].ToString();
                    res.url = dataReader[6].ToString();
                    res.nombre = dataReader[7].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }

        public int update_estado_etiqueta(String id)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd = new SqlCommand("UPDATE_ESTADO_ETIQUETA", connection);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.CommandType = CommandType.StoredProcedure;


            int result = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return result;
        }
    }

    
    public class responce_SELECCION_ETIQUETA
    {
        public String id;
        public String zpl;
        public String fecha;
        public String densidad;
        public String tamanio;
        public String stock;
        public String url;
        public String nombre;
    }
    public class request_SELECCION_ETIQUETA
    {
        public String Solicitud;
    }
}