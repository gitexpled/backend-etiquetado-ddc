using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_SEMANA
    {
        public Array run(request_ECO_CONSULTA_SEMANA datos)
        {
            List<responce_ECO_CONSULTA_SEMANA> List = new List<responce_ECO_CONSULTA_SEMANA>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select prd.id, prd.productor,prd.centro, prd.especie, prd.variedad, det.semana, det.valor_estimado "+
                         "from eco_prod_semana prd "+
                        "join eco_detalle det on det.id_prd_sem = prd.id "+
                        "where 1=1 "+
                        "and prd.productor = '" + datos.Productor + "' " +
                        "and prd.centro = '"+datos.Centro+"' "+
                        "and prd.especie = '"+datos.Especie+"' "+
                        "and prd.variedad = '"+datos.Variedad+"' "+
                        "and det.semana between "+datos.Semana1+" and "+datos.Semana2+" ";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ECO_CONSULTA_SEMANA res = new responce_ECO_CONSULTA_SEMANA();
                    res.id = dataReader[0].ToString();
                    res.productor = dataReader[1].ToString();
                    res.centro = dataReader[2].ToString();
                    res.especie = dataReader[3].ToString();
                    res.variedad = dataReader[4].ToString();
                    res.semana = dataReader[5].ToString();
                    res.valor_estimada = dataReader[6].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_SEMANA
    {
        public String id;
        public String productor;
        public String centro;
        public String especie;
        public String variedad;
        public String semana;
        public String valor_estimada;
    }
    public class request_ECO_CONSULTA_SEMANA
    {
        public String Centro;
        public String Especie;
        public String Variedad;
        public String Productor;
        public String Semana1;
        public String Semana2;
    }
}