using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_GET_PRODUCTOR_USER
    {
        public Array run(request_ECO_GET_PRODUCTOR_USER datos)
        {
            List<responce_ECO_GET_PRODUCTOR_USER> List = new List<responce_ECO_GET_PRODUCTOR_USER>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT ESPECIE, PRODUCTOR FROM usuario_esp_prd WHERE ID_USUARIO = '" + datos.ID_USUARIO + "' ";
            
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
                    responce_ECO_GET_PRODUCTOR_USER res = new responce_ECO_GET_PRODUCTOR_USER();
                    res.ESPECIE = dataReader[0].ToString();
                    res.PRODUCTOR = dataReader[1].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_GET_PRODUCTOR_USER
    {
        public String ESPECIE;
        public String PRODUCTOR;
       
    }
    public class request_ECO_GET_PRODUCTOR_USER
    {
        public String ID_USUARIO;
        
    }
}