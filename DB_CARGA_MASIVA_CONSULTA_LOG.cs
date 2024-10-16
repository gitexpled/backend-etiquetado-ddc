using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB__CARGA_MASIVA_CONSULA_LOG
    {
        public Array run(request_CARGA_MASIVA_CONSULA_LOG datos)
        {
            List<responce_CARGA_MASIVA_CONSULA_LOG> List = new List<responce_CARGA_MASIVA_CONSULA_LOG>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT [CENTRO] ";
              sql += ",[PRODUCTOR] ";
              sql += ",[FCONTAB] ";
              sql += ",[PALLET] ";
              sql += ",[MATERIAL] ";
              sql += ",[VARIEDAD] ";
              sql += ",[CANTIDAD] ";
              sql += ",[PALLETCOMPLETO] ";
              sql += ",[MOV_311] ";
              sql += ",[MOV_101] ";
              sql += ",[MOV_543] ";
              sql += ",[MOV_543_PALLET] ";
              sql += ",[PEDIDO] ";
              sql += ",[PEDIDO_PALLET] ";
              sql += ",[MOV_541] ";
              sql += ",[MOV_541_PALLET] ";
              sql += ",[RESPUESTA] ";
              sql += ",[MATERIAL_RESP] ";
              sql += ",[CANTIDAD_RESP] ";
              sql += ",[UNIDAD_RESP] ";
              sql += ",[ALMACEN_RESP] ";
              sql += "FROM [dbo].[LOG_CARGAMASIVA] ";
              sql += " where [FCONTAB] between '" + datos.fecha_desde + "' and '" + datos.fecha_hasta + "' AND tipo = '"+datos.tipo+"'";
            
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 120;
            SqlDataReader dataReader = cmd.ExecuteReader();
            Int16 i = 0;
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_CARGA_MASIVA_CONSULA_LOG res = new responce_CARGA_MASIVA_CONSULA_LOG();
                    res.CENTRO = dataReader[0].ToString();
                    res.PRODUCTOR = dataReader[1].ToString();
                    res.FCONTAB = dataReader[2].ToString();
                    res.PALLET = dataReader[3].ToString();
                    res.MATERIAL = dataReader[4].ToString();
                    res.VARIEDAD = dataReader[5].ToString();
                    res.CANTIDAD = dataReader[6].ToString();
                    res.PALLETCOMPLETO = dataReader[7].ToString();
                    res.MOV_311 = dataReader[8].ToString();
                    res.MOV_101 = dataReader[9].ToString();
                    res.MOV_543 = dataReader[10].ToString();
                    res.MOV_543_PALLET = dataReader[11].ToString();
                    res.PEDIDO = dataReader[12].ToString();
                    res.PEDIDO_PALLET = dataReader[13].ToString();
                    res.MOV_541 = dataReader[14].ToString();
                    res.MOV_541_PALLET = dataReader[15].ToString();
                    res.RESPUESTA = dataReader[16].ToString();
                    res.MATERIAL_RESP = dataReader[17].ToString();
                    res.CANTIDAD_RESP = dataReader[18].ToString();
                    res.UNIDAD_RESP = dataReader[19].ToString();
                    res.ALMACEN_RESP = dataReader[20].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_CARGA_MASIVA_CONSULA_LOG
    {
        public String CENTRO;
        public String PRODUCTOR;
        public String FCONTAB;
        public String PALLET;
        public String MATERIAL;
        public String VARIEDAD;
        public String CANTIDAD;
        public String PALLETCOMPLETO;
        public String MOV_311;
        public String MOV_101;
        public String MOV_543;
        public String MOV_543_PALLET;
        public String PEDIDO;
        public String PEDIDO_PALLET;
        public String MOV_541;
        public String MOV_541_PALLET;
        public String RESPUESTA;
        public String MATERIAL_RESP;
        public String CANTIDAD_RESP;
        public String UNIDAD_RESP;
        public String ALMACEN_RESP;
       
    }
    public class request_CARGA_MASIVA_CONSULA_LOG
    {
        public String fecha_desde;
        public String fecha_hasta;
        public String tipo;

    }
}