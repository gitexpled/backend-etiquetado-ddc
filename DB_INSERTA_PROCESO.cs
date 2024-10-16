using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_INSERTA_PROCESO
    {
        public responce_DB_INSERTA_PROCESO run(request_DB_INSERTA_PROCESO datos)
        {
            responce_DB_INSERTA_PROCESO res = new responce_DB_INSERTA_PROCESO();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "";
            if (datos.Consulta == "Insert")
            {
                sql = "insert into proceso values('" + datos.proceso + "','" + datos.estado + "'," + datos.kilos + ",'" + datos.centro + "','"+datos.planta+"','"+datos.productor+"','"+datos.especie+"','"+datos.variedad+"','"+datos.material+"')";
            }
            if (datos.Consulta == "Modific")
            {

                sql = "update proceso set estado = '" + datos.estado + "' where proceso = '" + datos.proceso + "' and centro = '" + datos.centro + "'";
            }
            if (datos.Consulta == "RE")
            {

                sql = "update proceso set reetiquetado = '" + datos.estado + "' where proceso = '" + datos.proceso + "' and planta = '" + datos.centro + "'";
            }
            try
            {
                if (datos.Consulta == "Insert")
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    res.resp = "Insertado Correctamente";
                }
                if (datos.Consulta == "Modific" || datos.Consulta == "RE")
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    res.resp = "Modificado Correctamente ";
                }

            }
            catch (Exception e)
            {
                res.resp = e.Message;
            }
            finally
            {

            }
            connection.Close();
            connection.Dispose();
            return res;
        }
    }
    public class responce_DB_INSERTA_PROCESO
    {
        public String resp;
    }
    public class request_DB_INSERTA_PROCESO
    {
        public String centro;
        public String consulta;
        public String proceso;
        public String estado;
        public String kilos;
        public String Consulta;
        public String planta;
        public String productor;
        public String especie;
        public String variedad;
        public String material;
    }
}