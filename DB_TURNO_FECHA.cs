using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_TURNO_FECHA
    {
        public Array run(request_TURNO_FECHA datos)
        {
            List<responce_TURNO_FECHA> List = new List<responce_TURNO_FECHA>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("Turno_Fecha", connection);
                cmd.Parameters.Add(new SqlParameter("@planta", datos.PLANTA));
                cmd.Parameters.Add(new SqlParameter("@f1", datos.FECHA1));
                cmd.Parameters.Add(new SqlParameter("@f2", datos.FECHA2));
                cmd.Parameters.Add(new SqlParameter("@f3", datos.FECHA3));
                cmd.Parameters.Add(new SqlParameter("@f4", datos.FECHA4));
                cmd.Parameters.Add(new SqlParameter("@consulta", datos.CONSULTA));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        responce_TURNO_FECHA res = new responce_TURNO_FECHA();
                        res.planta = dr[0].ToString();
                        res.fecha1 = dr[1].ToString();
                        res.fecha2 = dr[2].ToString();
                        res.fecha3 = dr[3].ToString();
                        res.fecha4 = dr[4].ToString();
                        List.Add(res);
                    }

                }
            }
            catch (Exception e)
            {

                responce_TURNO_FECHA resp = new responce_TURNO_FECHA();
                resp.error = e.ToString();
                List.Add(resp);
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_TURNO_FECHA
    {
        public String planta;
        public String fecha1;
        public String fecha2;
        public String fecha3;
        public String fecha4;
        public String error;
    }
    public class request_TURNO_FECHA
    {
        public String PLANTA;
        public String FECHA1;
        public String FECHA2;
        public String FECHA3;
        public String FECHA4;
        public String CONSULTA;
    }
}