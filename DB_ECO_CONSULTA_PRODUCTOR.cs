using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_PRODUCTOR
    {
        public Array run(request_ECO_CONSULTA_PRODUCTOR datos)
        {
            List<responce_ECO_CONSULTA_PRODUCTOR> List = new List<responce_ECO_CONSULTA_PRODUCTOR>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT [id_ficha],[productor],[nombre],[rut],[planta],[usuario],[direccion],[telefono],[temporada],[comuna] ";
            sql += "   FROM [dbo].[prd_ficha_tecnica] WHERE productor = '"+datos.CODIGO +"' ";
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
                    responce_ECO_CONSULTA_PRODUCTOR res = new responce_ECO_CONSULTA_PRODUCTOR();
                    res.PRODUCTOR = dataReader[1].ToString();
                    res.NOMBRE = dataReader[2].ToString();
                    res.RUT = dataReader[3].ToString();
                    res.DIRECCION = dataReader[6].ToString();
                    res.COMUNA = dataReader[9].ToString();
                    res.TELEFONO = dataReader[7].ToString();
                    res.TEMPORADA = dataReader[8].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_PRODUCTOR
    {
        public String PRODUCTOR;
        public String NOMBRE;
        public String RUT;
        public String TEMPORADA;
        public String DIRECCION;
        public String COMUNA;
        public String TELEFONO;
        
    }
    public class request_ECO_CONSULTA_PRODUCTOR
    {
        public String CODIGO;
    }
}