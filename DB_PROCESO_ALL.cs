using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_PROCESO_ALL
    {
        public Array run(request_Proceso datos)
        {
            List<responce_Proceso> List = new List<responce_Proceso>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select * from proceso";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_Proceso res = new responce_Proceso();
                    res.proceso = dataReader[0].ToString();
                    res.estado = dataReader[1].ToString();
                    res.Kilos_etiqueta = dataReader[2].ToString();
                    res.centro = dataReader[3].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
    }
    public class responce_Proceso
    {
        public String proceso;
        public String estado;
        public String Kilos_etiqueta;
        public String centro;
    }
    public class request_Proceso
    {
        public String centro;
    }
}