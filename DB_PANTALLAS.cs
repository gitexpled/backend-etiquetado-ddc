using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_PANTALLAS
    {
        public Array run(request_pantallas datos)
        {
            List<responce_pantallas> List = new List<responce_pantallas>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select * from pantallas where centro = '" + datos.Solicitud + "' order by Salida";
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
                    responce_pantallas res = new responce_pantallas();
                    res.ip_pan = dataReader[0].ToString();
                    res.ip_imp = dataReader[1].ToString();
                    res.linea = dataReader[2].ToString();
                    res.centro = dataReader[3].ToString();
                    res.salida = dataReader[4].ToString();
                    res.propiedad = dataReader[5].ToString();
                    res.tipo = dataReader[6].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_pantallas
    {
        public String ip_pan;
        public String ip_imp;
        public String centro;
        public String linea;
        public String salida;
        public String propiedad;
        public String tipo;
    }
    public class request_pantallas
    {
        public String Solicitud;
    }
}