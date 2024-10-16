using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace rfcBaika
{
    public class DB_IMAGE
    {
        public Array run(request_IMAGE datos)
            {
                List<responce_IMAGE> List = new List<responce_IMAGE>();
                String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                String sql = "select id,zpl,ruta,nombre from zpl where ISNULL(estado,0) = 0";
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
                      responce_IMAGE res = new responce_IMAGE();
                        res.id = dataReader[0].ToString();
                        res.zpl = dataReader[1].ToString();
                        res.url = dataReader[2].ToString();
                        res.nombre = dataReader[3].ToString();
                        List.Add(res);
                    }
                }
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
                return List.ToArray();
            }
    }

    public class responce_IMAGE
    {
        public String id;
        public String zpl;
        public String url;
        public String nombre;
    }
    public class request_IMAGE
    {
       public String Solicitud;
    }
}