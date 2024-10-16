
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Data;

namespace rfcBaika
{
    public class DB_GET_LOTE_NEW
    {
        public int run(String USER, String CENTRO)
        {
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            int res = 0;
            try
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd = new SqlCommand("GET_NEW_LOTE", connection);
                cmd.Parameters.Add(new SqlParameter("@USER", USER));
                cmd.Parameters.Add(new SqlParameter("@CENTRO", CENTRO));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 950;
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        res = Convert.ToInt32(dataReader[0].ToString());
                    }
                }

                connection.Close();
                connection.Dispose();
                cmd.Dispose();
                
            }
            catch (Exception e)
            {
                
            }
                
            
            connection.Close();
            connection.Dispose();
            return res;

        }
    }

}