using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_STOCK_CONSULTA_ZPL2
    {
        public responce_DB_STOCK_CONSULTA_ZPL2 run(request_DB_CONSULTA_STOCK_ZPL2 datos)
        {
            responce_DB_STOCK_CONSULTA_ZPL2 res = new responce_DB_STOCK_CONSULTA_ZPL2();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "";
            if (datos.consulta == "insert")
            {
                sql = "INSERT INTO zpl_ventana (id_zpl, zpl,stock,id_posicion,proceso,kilos_material,line,ip_zebra,salida,calibre,tipo_material,id_etiqueta) VALUES (" + datos.id + ", '" + datos.zpl + "'," + datos.stock + "," + datos.posicion + ",'" + datos.proceso + "'," + datos.kilos + ", " + datos.line + ",'" + datos.ip_zebra + "','" + datos.exit + "','" + datos.Calibre + "','" + datos.T_material + "'," + datos.id_etiqueta + ");";
            }
            if (datos.consulta == "modific")
            {
                sql = "UPDATE zpl_ventana SET id_zpl = " + datos.id + ", stock = " + datos.stock + ", zpl = '" + datos.zpl + "', kilos_material = " + datos.kilos + ", calibre= '" + datos.Calibre + "',id_etiqueta = " + datos.id_etiqueta + ", Line= " + datos.line + "  where ip_zebra = '" + datos.ip_zebra + "' and id_posicion = " + datos.posicion + "";
            }
            try
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Connection = connection;
                SqlDataReader dataReader = cmd.ExecuteReader();
                //cmd.CommandTimeout = 0;
                if (datos.consulta == "insert")
                {
                    res.resp = "Guardado con exito";
                }
                if (datos.consulta == "modific")
                {
                    res.resp = "Modificado con exito";
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
    public class responce_DB_STOCK_CONSULTA_ZPL2
    {
            public String resp;
    }
    public class request_DB_CONSULTA_STOCK_ZPL2
    {
        public String id;
        public String zpl;
        public String stock;
        public String posicion;
        public String proceso;
        public String kilos;
        public String consulta;
        public String line;
        public String ip_zebra;
        public String exit;
        public String Calibre;
        public String T_material;
        public String id_etiqueta;
    }
}
