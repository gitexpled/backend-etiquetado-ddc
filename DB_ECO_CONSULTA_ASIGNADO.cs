using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_ASIGNADO
    {
        public Array run(request_ECO_CONSULTA_ASIGNADO datos)
        {
            List<responce_ECO_CONSULTA_ASIGNADO> List = new List<responce_ECO_CONSULTA_ASIGNADO>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT uep.*,us.usuario FROM usuario_esp_prd uep left join usuario us on us.idUsuario = uep.id_usuario where uep.especie = '" + datos.ESPECIE + "' and uep.productor " + datos.PRODUCTOR;
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
                    responce_ECO_CONSULTA_ASIGNADO res = new responce_ECO_CONSULTA_ASIGNADO();
                    res.USUARIO = dataReader[4].ToString();
                    res.ESPECIE = dataReader[2].ToString();
                    res.PRODUCTOR = dataReader[3].ToString();                    
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_ASIGNADO
    {
        public String USUARIO;
        public String PRODUCTOR;
        public String ESPECIE;
       
    }
    public class request_ECO_CONSULTA_ASIGNADO
    {
        public String USUARIO;
        public String PRODUCTOR;
        public String ESPECIE;

    }
}