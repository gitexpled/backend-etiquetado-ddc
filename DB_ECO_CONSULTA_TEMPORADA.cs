using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_TEMPORADA
    {
        public Array run(request_ECO_CONSULTA_TEMPORADA datos)
        {
            List<responce_ECO_CONSULTA_TEMPORADA> List = new List<responce_ECO_CONSULTA_TEMPORADA>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT INICIO ,FIN, ENVASE, PESO,PESO2,PESO3,HASTIPOFRIO FROM eco_temporada WHERE especie = '" + datos.ESPECIE + "' ";
            
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
                    responce_ECO_CONSULTA_TEMPORADA res = new responce_ECO_CONSULTA_TEMPORADA();
                    res.INICIO = dataReader[0].ToString();
                    res.FIN = dataReader[1].ToString();
                    res.ENVASE = dataReader[2].ToString();
                    res.PESO = dataReader[3].ToString();
                    res.PESO2 = dataReader[4].ToString();
                    res.PESO3 = dataReader[5].ToString();
                    res.hasTipoFrio = int.Parse(dataReader[6].ToString());
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_TEMPORADA
    {
        public String INICIO;
        public String FIN;
        public String ENVASE;
        public String PESO;
        public String PESO2;
        public String PESO3;
        public int hasTipoFrio;
    }
    public class request_ECO_CONSULTA_TEMPORADA
    {
        public String ESPECIE;
        
    }
}