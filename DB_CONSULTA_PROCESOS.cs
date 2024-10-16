using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_CONSULTA_PROCESOS
    {
        public Array run(request_CONSULTA_PROCESOS datos)
        {
            List<responce_CONSULTA_PROCESOS> List = new List<responce_CONSULTA_PROCESOS>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "";
            if(datos.Planta == "M"){
                sql = "select * from proceso";
            }else{
                sql = "select * from proceso where planta = '"+datos.Planta+"'";
            }
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_CONSULTA_PROCESOS res = new responce_CONSULTA_PROCESOS();
                    res.proceso = dataReader[0].ToString();
                    res.estado = dataReader[1].ToString();
                    res.Kilos_etiqueta = dataReader[2].ToString();
                    res.centro = dataReader[3].ToString();
                    res.planta = dataReader[4].ToString();
                    res.productor = dataReader[5].ToString();
                    res.especie = dataReader[6].ToString();
                    res.variedad = dataReader[7].ToString();
                    res.material = dataReader[8].ToString();
                    res.reetiquetado = dataReader[9].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
    }
    public class responce_CONSULTA_PROCESOS
    {
        public String proceso;
        public String estado;
        public String Kilos_etiqueta;
        public String centro;
        public String planta;
        public String productor;
        public String especie;
        public String variedad;
        public String material;
        public String reetiquetado;
    }
    public class request_CONSULTA_PROCESOS
    {
        public String Planta;
    }
}