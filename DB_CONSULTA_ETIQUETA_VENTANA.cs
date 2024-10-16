using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_CONSULTA_ETIQUETA_VENTANA
    {
        public Array run(request_CONSULTA_ETIQUETA_VENTANA datos)
        {
            List<responce_DB_CONSULTA_ETIQUETA_VENTANA> List = new List<responce_DB_CONSULTA_ETIQUETA_VENTANA>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select pr.estado,pr.centro,pos.ip_pantalla,pos.pantalla_zpl,zv.tipo_material, zv.stock, zv.calibre, zv.kilos_material, zv.ip_Zebra, zv.zpl, zv.proceso, zv.salida, et.calidad, zv.Line" +
                            " from proceso pr" +
                            " join zpl_ventana zv on zv.proceso = pr.proceso" +
                            " join posicion_re pos on pos.id = zv.id_posicion" +
                            " join etiqueta et on pr.proceso = et.proceso" +
                            " where 1=1" +
                            " and pos.ip_pantalla = '" + datos.Ip + "'" +
                            " and (zv.stock > 0" +
                            " or pr.estado = 'VIGENTE')";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_DB_CONSULTA_ETIQUETA_VENTANA res = new responce_DB_CONSULTA_ETIQUETA_VENTANA();
                    res.Estado = dataReader[0].ToString();
                    res.Centro = dataReader[1].ToString();
                    res.ip_Pantalla = dataReader[2].ToString();
                    res.Pantalla_zpl = dataReader[3].ToString();
                    res.Tipo_Material = dataReader[4].ToString();
                    res.Stock = dataReader[5].ToString();
                    res.Calibre = dataReader[6].ToString();
                    res.Kilos_Materiales = dataReader[7].ToString();
                    res.Ip_Zebra = dataReader[8].ToString();
                    res.ZPL = dataReader[9].ToString();
                    res.Proceso = dataReader[10].ToString();
                    res.Salida = dataReader[11].ToString();
                    res.Calidad = dataReader[12].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_DB_CONSULTA_ETIQUETA_VENTANA
    {
        public String Estado;
        public String Centro;
        public String ip_Pantalla;
        public String Pantalla_zpl;
        public String Tipo_Material;
        public String Stock;
        public String Calibre;
        public String Kilos_Materiales;
        public String Ip_Zebra;
        public String ZPL;
        public String Proceso;
        public String Salida;
        public String Calidad;
        public String Linea;
        public String Refresco;
        public String correlativo;
        public String especie;
        public String turno;
        public String variedad;
        public String codigo;
        public String fecha;
        public String Cod_Mat;
        public String planta;
        public String id;

    }
    public class request_CONSULTA_ETIQUETA_VENTANA
    {
        public String Ip;
    }
}