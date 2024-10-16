using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_TIPIFICACION
    {
        public Array run(request_ECO_CONSULTA_TIPIFICACION datos)
        {
            List<responce_ECO_CONSULTA_TIPIFICACION> List = new List<responce_ECO_CONSULTA_TIPIFICACION>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT ET.usuario, ET.productor, ET.especie, ET.variedad, ET.tipo, ET.valor, ET.estimacion, ET.centro, ET.ano ";
            sql += "FROM ECO_ANUAL EA left join eco_tipificacion ET  ON EA.Nombre = ET.estimacion  WHERE ET.usuario =" + datos.USUARIO;
            sql += " and (ET.productor = '" + datos.PRODUCTOR + "' OR '" + datos.PRODUCTOR + "' = '')";
            sql += " and (ET.especie = '" + datos.ESPECIE + "' OR '" + datos.ESPECIE + "' = '') ";
            sql += " and (ET.variedad = '" + datos.VARIEDAD.Replace("'", " ") + "' OR '" + datos.VARIEDAD.Replace("'", " ") + "' = '' )";
            sql += " and (ET.centro = '" + datos.CENTRO + "' OR '" + datos.CENTRO + "' = '') ";
            sql += " and (ET.estimacion = '" + datos.ESTIMACION + "' OR '" + datos.ESTIMACION + "' = '')";
            sql += " and (ET.semana = '" + datos.SEMANA + "' OR '" + datos.SEMANA + "' = '')";
            sql += " and (ET.editado = '" + datos.EDITADO + "' OR '" + datos.EDITADO + "' = '')";
            sql += " and (EA.productor = '" + datos.PRODUCTOR + "' OR '" + datos.PRODUCTOR + "' = '')";
            sql += " and (EA.especie = '" + datos.ESPECIE + "' OR '" + datos.ESPECIE + "' = '') ";
            sql += " and (EA.variedad = '" + datos.VARIEDAD.Replace("'", " ") + "' OR '" + datos.VARIEDAD.Replace("'", " ") + "' = '' )";
            sql += " and (EA.centro = '" + datos.CENTRO + "' OR '" + datos.CENTRO + "' = '') ";
            sql += " and (EA.nombre = '" + datos.ESTIMACION + "' OR '" + datos.ESTIMACION + "' = '')";
            sql += " and EA.tipo = 'ANUAL'   and ea.estado != 'PENDIENTE'  ";
            sql += " and EA.usuario = '" + datos.USUARIO + "'   ";
            sql += " and ET.ANUAL = '" + datos.ANUAL + "'";
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
                    responce_ECO_CONSULTA_TIPIFICACION res = new responce_ECO_CONSULTA_TIPIFICACION();
                    res.usuario = dataReader[0].ToString();
                    res.productor = dataReader[1].ToString();
                    res.especie = dataReader[2].ToString();
                    res.variedad = dataReader[3].ToString();
                    res.tipo = dataReader[4].ToString();
                    res.valor = dataReader[5].ToString();
                    res.estimacion = dataReader[6].ToString();
                    res.centro = dataReader[7].ToString();
                    res.ano = dataReader[8].ToString();    
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_TIPIFICACION
    {
        public String usuario;
        public String productor;
        public String centro;
        public String especie;
        public String variedad;
        public String tipo;
        public String valor;
        public String estimacion;
        public String ano;
    }
    public class request_ECO_CONSULTA_TIPIFICACION 
    {
        public String CENTRO;
        public String PRODUCTOR;
        public String ESPECIE; 
        public String USUARIO;
        public String VARIEDAD;
        public String ESTIMACION;
        public String ANUAL;
        public String SEMANA;
        public String EDITADO;
    }
}