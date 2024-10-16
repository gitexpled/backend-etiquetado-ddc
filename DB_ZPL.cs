using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace rfcBaika
{
    public class DB_ZPL
    {

        public responce_DB_ZPL run(request_DB_ZPL datos)
        {
            
            responce_DB_ZPL res = new responce_DB_ZPL();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "";
            try
            {
                if(datos.Consulta == "Actualizar"){
                    sql = "update zpl set zpl = '" + datos.zpl + "', fecha_ingreso=getdate(), densidad = '" + datos.densidad + "', tamanio = '" + datos.Tamanio + "', ruta = '" + datos.ruta + "' where nombre = '" + datos.nombre + "' and id = " + datos.id + ";";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    res.resp = "Actualizado con exito";

                }
                else if (datos.Consulta == "eliminar")
                {
                    sql = "delete from zpl where id = "+datos.id;
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    res.resp = "Eliminado con exito";
                }else{
                    sql = "INSERT INTO zpl (zpl, fecha_ingreso, densidad,tamanio, stock , ruta, nombre) VALUES ('"+datos.zpl+"',getdate(),'"+datos.densidad+"','"+datos.Tamanio+"','0','"+datos.ruta+"', '"+datos.nombre+"');";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Connection = connection;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    res.resp = "Guardado con exito";
                }
            }
            catch (Exception e)
            {
                res.resp = e.Message;
            }
            finally {
                
            }
            connection.Close();
            connection.Dispose();
            return res;
                
        }
    }
    public class request_DB_ZPL
    {
        public String zpl;
        public String densidad;
        public String Tamanio;
        public String ipZebra;
        public String ruta;
        public String nombre;
        public String Consulta;
        public String id;
    }
    public class responce_DB_ZPL
    {
        public String resp;
    }
}