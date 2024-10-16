using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_USUARIOS
    {
        public Array run()
        {
            List<responce_ECO_CONSULTA_USUARIOS> List = new List<responce_ECO_CONSULTA_USUARIOS>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT * FROM [dbo].[usuario] where mail = 'ECO' order by nombre";
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
                    responce_ECO_CONSULTA_USUARIOS res = new responce_ECO_CONSULTA_USUARIOS();
                    res.id = dataReader[0].ToString();
                    res.usuario = dataReader[1].ToString();
                    res.nombre = dataReader[3].ToString();
                    res.apellido = dataReader[4].ToString();
                    res.perfil = dataReader[5].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_USUARIOS
    {
        public String id;
        public String usuario;
        public String nombre;
        public String apellido;
        public String perfil;
    }
    
}