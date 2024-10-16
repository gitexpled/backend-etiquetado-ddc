using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace rfcBaika
{
    public class DB_ETIQUETA_STOCK
    {
        public Array run(request_ETIQUETA_STOCK datos)
        {
            List<responce_ETIQUETA_STOCK> List = new List<responce_ETIQUETA_STOCK>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql =  sql = "select * from proceso where centro = '" + datos.centro + "'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        responce_ETIQUETA_STOCK res = new responce_ETIQUETA_STOCK();

                        if (res.centro == "10"){
                            this.insertProc();
                        }
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

        public void  insertProc() {
            
            return ;
        }
    }
    public class responce_ETIQUETA_STOCK
    {
        public String proceso;
        public String estado;
        public String Kilos_etiqueta;
        public String centro;
    }
    public class request_ETIQUETA_STOCK
    {
        public String centro;
        public String consulta;
        public String proceso;
        public String estado;
        public String kilos;
    }
}
