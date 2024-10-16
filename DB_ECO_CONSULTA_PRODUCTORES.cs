using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_PRODUCTORES
    {
        public Array run(request_ECO_CONSULTA_PRODUCTORES datos)
        {
            List<responce_ECO_CONSULTA_PRODUCTORES> List = new List<responce_ECO_CONSULTA_PRODUCTORES>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT FT.[productor],FT.[nombre],FT.[rut] ";
            sql += " FROM [dbo].[prd_ficha_tecnica] FT ";
            sql += " LEFT JOIN prd_padre_hijo PH ON PH.ID_PADRE = FT.PRODUCTOR";
            sql += " WHERE (FT.PRODUCTOR = '" + datos.CODIGO + "' OR PH.prd_hijo = '" + datos.CODIGO + "' OR '" + datos.CODIGO + "' = '') ";
            sql += " AND (FT.NOMBRE LIKE '%" + datos.NOMBRE + "%' OR PH.NOMBRE LIKE '%" + datos.NOMBRE + "%')";
            sql += " AND (FT.RUT LIKE '%" + datos.RUT + "%' ) ";
            sql += " AND (FT.PLANTA = '" + datos.PLANTA + "'  OR '" + datos.PLANTA + "' = '')";
            sql += " AND (FT.USUARIO = '" + datos.USUARIO + "'  OR '" + datos.USUARIO + "' = '')";
            sql += " AND (FT.TEMPORADA = '" + datos.TEMPORADA + "'  OR '" + datos.TEMPORADA + "' = '')";
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
                    responce_ECO_CONSULTA_PRODUCTORES res = new responce_ECO_CONSULTA_PRODUCTORES();
                    res.PRODUCTOR = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    res.RUT = dataReader[2].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_PRODUCTORES
    {
        public String PRODUCTOR;
        public String NOMBRE;
        public String RUT;
        
    }
    public class request_ECO_CONSULTA_PRODUCTORES
    {
        public String TEMPORADA;
        public String CODIGO;
        public String NOMBRE;
        public String USUARIO;
        public String RUT;
        public String PLANTA;
    }
}