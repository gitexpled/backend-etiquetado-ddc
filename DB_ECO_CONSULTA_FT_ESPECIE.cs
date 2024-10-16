using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_FT_ESPECIE
    {
        public Array run(request_ECO_CONSULTA_FT_ESPECIE datos)
        {
            List<responce_ECO_CONSULTA_FT_ESPECIE> List = new List<responce_ECO_CONSULTA_FT_ESPECIE>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT * FROM prd_especie ";
            
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
                    responce_ECO_CONSULTA_FT_ESPECIE res = new responce_ECO_CONSULTA_FT_ESPECIE();
                    res.id = dataReader[0].ToString();
                    res.id_padre = dataReader[1].ToString();
                    res.especie = dataReader[2].ToString();
                    res.cuartel = dataReader[3].ToString();
                    res.tipo_certificacion = dataReader[4].ToString();
                    res.gobla_gap_number = dataReader[5].ToString();
                    res.ggn_desde = dataReader[6].ToString();
                    res.ggn_hasta = dataReader[7].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_FT_ESPECIE
    {
        public String id;
        public String id_padre;
        public String especie;
        public String cuartel;
        public String tipo_certificacion;
        public String gobla_gap_number;
        public String ggn_desde;
        public String ggn_hasta;
       
    }
    public class request_ECO_CONSULTA_FT_ESPECIE
    {


    }
}