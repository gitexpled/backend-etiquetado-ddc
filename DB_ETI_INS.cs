using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ETI_INS
    {
        public responce_DB_ETI_INS run(request_DB_ETI_INS datos)
        {
            responce_DB_ETI_INS res = new responce_DB_ETI_INS();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "";
            if (datos.Consulta == "Insert")
            {
                sql = "insert into proceso values(@PROCESO, @ESTADO, @KILOS, @CENTRO, @PLANTA, @PRODUCTOR, @ESPECIE, @VARIEDAD, @MATERIAL, 'DESACTIVO')";
                //sql = "insert into proceso values('" + datos.proceso + "','" + datos.estado + "'," + datos.kilos + ",'" + datos.centro + "','" + datos.planta + "','" + datos.productor + "','" + datos.especie + "','" + datos.variedad + "','" + datos.material + "','DESACTIVO')";
            }
            if (datos.Consulta == "Modific")
            {
                sql = "update proceso set estado = @ESTADO where proceso = @PROCESO and centro = @CENTRO";
                //sql = "update proceso set estado = '" + datos.estado + "' where proceso = '" + datos.proceso + "' and centro = '" + datos.centro + "'";
            }
            if (datos.Consulta == "RE")
            {
                sql = "update proceso set reetiquetado = @ESTADO where proceso = @PROCESO and planta = @CENTRO";
                //sql = "update proceso set reetiquetado = '" + datos.estado + "' where proceso = '" + datos.proceso + "' and planta = '" + datos.centro + "'";
            }
            try
            {
                if (datos.Consulta == "Insert")
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@PROCESO", datos.proceso.Replace("'", "")));
                    command.Parameters.Add(new SqlParameter("@ESTADO", datos.estado.Replace("'", "")));
                    command.Parameters.Add(new SqlParameter("@KILOS", datos.kilos.Replace("'", "")));
                    command.Parameters.Add(new SqlParameter("@CENTRO", datos.centro.Replace("'", "")));
                    command.Parameters.Add(new SqlParameter("@PLANTA", datos.planta.Replace("'", "")));
                    command.Parameters.Add(new SqlParameter("@PRODUCTOR", datos.productor.Replace("'", "")));
                    command.Parameters.Add(new SqlParameter("@ESPECIE", datos.especie.Replace("'", "")));
                    command.Parameters.Add(new SqlParameter("@VARIEDAD", datos.variedad.Replace("'", "")));
                    command.Parameters.Add(new SqlParameter("@MATERIAL", datos.material.Replace("'", "")));
                    command.Connection = connection;
                    SqlDataReader dataReader = command.ExecuteReader();
                    res.resp = "Insertado Correctamente";
                }
                if (datos.Consulta == "Modific" || datos.Consulta == "RE")
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@PROCESO", datos.proceso));
                    command.Parameters.Add(new SqlParameter("@ESTADO", datos.estado));
                    command.Parameters.Add(new SqlParameter("@CENTRO", datos.centro));
                    command.Connection = connection;
                    SqlDataReader dataReader = command.ExecuteReader();
                    res.resp = "Modificado Correctamente ";
                }
                /*if (datos.Consulta == "RE")
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add(new SqlParameter("@PROCESO", datos.proceso));
                    command.Parameters.Add(new SqlParameter("@ESTADO", datos.estado));
                    command.Parameters.Add(new SqlParameter("@PLANTA", datos.planta));
                    command.Connection = connection;
                    SqlDataReader dataReader = command.ExecuteReader();
                    res.resp = "Modificado Correctamente ";
                }*/
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
    public class responce_DB_ETI_INS
    {
        public String resp;
    }
    public class request_DB_ETI_INS
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