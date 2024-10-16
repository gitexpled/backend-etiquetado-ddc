using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_STOCK_CONSULTA
    {
        public Array run(request_DB_CONSULTA_STOCK datos)
        {
            List<responce_DB_STOCK_CONSULTA> List = new List<responce_DB_STOCK_CONSULTA>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select * from zpl_ventana where proceso=+'"+datos.Solicitud+"'";
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
                    responce_DB_STOCK_CONSULTA res = new responce_DB_STOCK_CONSULTA();
                    res.id_zpl = dataReader[0].ToString();
                    res.zpl = dataReader[1].ToString();
                    res.stock = dataReader[2].ToString();
                    res.id_posicion = dataReader[3].ToString();
                    res.proceso = dataReader[4].ToString();
                    res.kilos_material = dataReader[5].ToString();
                    res.line = dataReader[6].ToString();
                    res.ip_zebra = dataReader[7].ToString();
                    res.salida = dataReader[8].ToString();
                    res.calibre = dataReader[9].ToString();
                    res.tipo_material = dataReader[10].ToString();
                    res.id_etiqueta = dataReader[11].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_DB_STOCK_CONSULTA
    {
        public String id_zpl;
        public String zpl;
        public String stock;
        public String id_posicion;
        public String proceso;
        public String kilos_material;
        public String line;
        public String ip_zebra;
        public String salida;
        public String calibre;
        public String tipo_material;
        public String id_etiqueta;
    }
    public class request_DB_CONSULTA_STOCK
    {
        public String Solicitud;
    }
}