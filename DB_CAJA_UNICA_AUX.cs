using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_CAJA_UNICA_AUX
    {
        public Array run(request_CAJA_UNICA_AUX datos)
        {
            List<responce_CAJA_UNICA_AUX> List = new List<responce_CAJA_UNICA_AUX>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("CAJA_UNICA_SUPPORT", connection);
                cmd.Parameters.Add(new SqlParameter("@numero", int.Parse(datos.Numero)));
                cmd.Parameters.Add(new SqlParameter("@planta",datos.planta));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        responce_CAJA_UNICA_AUX res = new responce_CAJA_UNICA_AUX();
                        res.planta = dataReader[0].ToString();
                        res.Numero = dataReader[1].ToString();
                        List.Add(res);
                    }
                }
            }
            catch (Exception e)
            {
                responce_CAJA_UNICA_AUX res = new responce_CAJA_UNICA_AUX();
                res.ERROR = e.ToString();
                List.Add(res);
            }
            connection.Close();
            connection.Dispose();
            return List.ToArray();
        }
    }
    public class responce_CAJA_UNICA_AUX
    {
        public String Numero;
        public String planta;
        public String ERROR;
    }
    public class request_CAJA_UNICA_AUX
    {
        public String Numero;
        public String planta;
    }
}