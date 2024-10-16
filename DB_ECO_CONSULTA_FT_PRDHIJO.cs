using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_FT_PRDHIJO
    {
        public Array run(request_ECO_CONSULTA_FT_PRDHIJO datos)
        {
            List<responce_ECO_CONSULTA_FT_PRDHIJO> List = new List<responce_ECO_CONSULTA_FT_PRDHIJO>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT * FROM prd_padre_hijo ";
            
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
                    responce_ECO_CONSULTA_FT_PRDHIJO res = new responce_ECO_CONSULTA_FT_PRDHIJO();
                    res.id = dataReader[0].ToString();
                    res.id_padre = dataReader[1].ToString();
                    res.prd_hijo = dataReader[2].ToString();
                    res.nombre = dataReader[3].ToString();
                    res.huerto = dataReader[4].ToString();
                    res.csg = dataReader[5].ToString();
                    res.idp = dataReader[6].ToString();
                    res.georeferenciacion = dataReader[7].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_FT_PRDHIJO
    {
        public String id;
        public String id_padre;
        public String prd_hijo;
        public String nombre;
        public String huerto;
        public String csg;
        public String idp;
        public String georeferenciacion;
       
    }
    public class request_ECO_CONSULTA_FT_PRDHIJO
    {


    }
}