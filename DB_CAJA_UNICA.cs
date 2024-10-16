using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_CAJA_UNICA
    {
        public responce_CAJA_UNICA run(request_CAJA_UNICA datos)
        {
            responce_CAJA_UNICA res = new responce_CAJA_UNICA();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("CAJA_UNICA_INSERT", connection);
                cmd.Parameters.Add(new SqlParameter("@num", datos.NUM));
                cmd.Parameters.Add(new SqlParameter("@lote", datos.LOTE));
                cmd.Parameters.Add(new SqlParameter("@kilos", float.Parse(datos.KILOS)));
                cmd.Parameters.Add(new SqlParameter("@calibre", datos.CALIBRE));
                cmd.Parameters.Add(new SqlParameter("@linea", int.Parse(datos.LINEA)));
                cmd.Parameters.Add(new SqlParameter("@turno", int.Parse(datos.TURNO)));
                cmd.Parameters.Add(new SqlParameter("@salida", int.Parse(datos.SALIDA)));
                cmd.Parameters.Add(new SqlParameter("@material", datos.MATERIAL));
                cmd.Parameters.Add(new SqlParameter("@especie", datos.ESPECIE));
                cmd.Parameters.Add(new SqlParameter("@variedad", datos.VARIEDAD));
                cmd.Parameters.Add(new SqlParameter("@cod_p", datos.CODIGO_P));
                DateTime itemDate = DateTime.ParseExact(datos.FECHA, "yyyy-MM-dd HH:mm:ss.fffffff", System.Globalization.CultureInfo.InvariantCulture);
                cmd.Parameters.Add(new SqlParameter("@fecha", datos.FECHA));
                cmd.Parameters.Add(new SqlParameter("@hora", datos.HORA));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    res.resp = dr[0].ToString();


                }
            }
            catch (Exception e)
            {
                res.resp = e.ToString();
            }
            connection.Close();
            connection.Dispose();
            return res;

        }
    }
    public class responce_CAJA_UNICA
    {
        public String resp;
    }
    public class request_CAJA_UNICA
    {
        public String NUM;
        public String LOTE;
        public String KILOS;
        public String CALIBRE;
        public String LINEA;
        public String TURNO;
        public String SALIDA;
        public String MATERIAL;
        public String ESPECIE;
        public String VARIEDAD;
        public String CODIGO_P;
        public String FECHA;
        public String HORA;
    }
}