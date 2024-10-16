using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace rfcBaika
{
    public class DB_ETIQUETA_VENTANA
    {
        /* public Array    run(request_DB_ETIQUETA_VENTANA datos)
         {
            
             string logEntry = string.Empty;

             List<responce_DB_ETIQUETA_VENTANA> List = new List<responce_DB_ETIQUETA_VENTANA>();

             String _connectionString = ConfigurationManager.ConnectionStrings["DDC_ETIQUETADO"].ToString();
             SqlConnection connection = new SqlConnection(_connectionString);
            
             //connection.Open();

             DateTime startConnectionTime = DateTime.Now;
             connection.Open();
             DateTime endConnectionTime = DateTime.Now;

             logEntry = GPLogger.CaptureConnectionDetails(_connectionString, startConnectionTime, endConnectionTime, "Connection Opened");



             String sql = "select pr.estado,pr.centro,pos.ip_pantalla,pos.pantalla_zpl,zv.tipo_material, zv.stock, zv.calibre, zv.kilos_material, zv.ip_Zebra, zv.zpl, zv.proceso, zv.salida, et.calidad, zv.Line, et.id" + 
                             " from proceso pr"+
                             " join zpl_ventana zv on zv.proceso = pr.proceso"+
                             " join posicion_zpl pos on pos.id = zv.id_posicion"+
                             " join etiqueta et on pr.proceso = et.proceso  and et.id = zv.id_etiqueta " +
                             " where 1=1"+
                             " and pos.ip_pantalla = '"+datos.Ip+"'"+ 
                             " and (zv.stock > 0"+
                             " or pr.estado = 'VIGENTE')";
             SqlCommand cmd = new SqlCommand(sql, connection);
             cmd.Connection = connection;
             cmd.CommandTimeout = 0;
             DateTime startCommandTime = DateTime.Now;
             SqlDataReader dataReader = cmd.ExecuteReader();
             DateTime endCommandTime = DateTime.Now;

             logEntry += GPLogger.CaptureCommandDetails(sql, startCommandTime, endCommandTime);


             //Read the data and store them in the list
             if (dataReader.HasRows)
             {
                 while (dataReader.Read())
                 {
                     logEntry += GPLogger.CaptureQueryResults(dataReader);

                     responce_DB_ETIQUETA_VENTANA res = new responce_DB_ETIQUETA_VENTANA();
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
                     res.id = dataReader["id"].ToString();
                     //res.id = dataReader[14].ToString();
                     List.Add(res);
                 }
             }
             connection.Close();
            
             logEntry += "Timestamp: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\nConnection Closed\n";


             connection.Dispose();
             cmd.Dispose();
             return List.ToArray();
         }

         */
        public List<responce_DB_ETIQUETA_VENTANA> run(request_DB_ETIQUETA_VENTANA datos)
        {
            string logEntry = string.Empty;
            List<responce_DB_ETIQUETA_VENTANA> List = new List<responce_DB_ETIQUETA_VENTANA>();

            String _connectionString = ConfigurationManager.ConnectionStrings["DDC_ETIQUETADO"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            string methodName = "";
            string fileName = "";
            try
            {



                var stackTrace = new StackTrace();
                var frame = stackTrace.GetFrame(0); // 0 indica el frame actual
                var method = frame.GetMethod();
                methodName = method.Name;
                fileName = method.ReflectedType != null ? method.ReflectedType.Name : "Unknown File";



                DateTime startConnectionTime = DateTime.Now;
                connection.Open();
                DateTime endConnectionTime = DateTime.Now;

                logEntry = GPLogger.CaptureConnectionDetails(_connectionString, startConnectionTime, endConnectionTime, "Connection Opened");


                DB_MONITOR_PANTALLA monitor = new DB_MONITOR_PANTALLA();

                monitor.InsertLog(datos.Ip);

                String sql = "select pr.estado, pr.centro, pos.ip_pantalla, pos.pantalla_zpl, zv.tipo_material, zv.stock, " +
                             "zv.calibre, zv.kilos_material, zv.ip_Zebra, zv.zpl, zv.proceso, zv.salida, et.calidad, zv.Line, et.id " +
                             "from proceso pr " +
                             "join zpl_ventana zv on zv.proceso = pr.proceso " +
                             "join posicion_zpl pos on pos.id = zv.id_posicion " +
                             "join etiqueta et on pr.proceso = et.proceso and et.id = zv.id_etiqueta " +
                             "where pos.ip_pantalla = @Ip " +
                             "and (zv.stock > 0 or pr.estado = 'VIGENTE')";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Ip", datos.Ip);
                cmd.CommandTimeout = 0;
                

                DateTime startCommandTime = DateTime.Now;
                SqlDataReader dataReader = cmd.ExecuteReader();
                DateTime endCommandTime = DateTime.Now;

                logEntry += GPLogger.CaptureCommandDetails(sql, startCommandTime, endCommandTime);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        logEntry += GPLogger.CaptureQueryResults(dataReader);

                        var date = DateTime.Now;
                        var HH = (date.Hour < 10) ? "0" + date.Hour.ToString() : date.Hour.ToString();
                        var MM = (date.Minute < 10) ? "0" + date.Minute.ToString() : date.Minute.ToString();
                        var hora = HH + ":" + MM;
                        var zpl = dataReader[9].ToString().Replace("@HORA", hora);

                        responce_DB_ETIQUETA_VENTANA res = new responce_DB_ETIQUETA_VENTANA
                        {
                            Estado = dataReader[0].ToString(),
                            Centro = dataReader[1].ToString(),
                            ip_Pantalla = dataReader[2].ToString(),
                            Pantalla_zpl = dataReader[3].ToString(),
                            Tipo_Material = dataReader[4].ToString(),
                            Stock = dataReader[5].ToString(),
                            Calibre = dataReader[6].ToString(),
                            Kilos_Materiales = dataReader[7].ToString(),
                            Ip_Zebra = dataReader[8].ToString(),
                            ZPL = zpl,
                            Proceso = dataReader[10].ToString(),
                            Salida = dataReader[11].ToString(),
                            Calidad = dataReader[12].ToString(),
                            id = dataReader["id"].ToString()
                        };
                        List.Add(res);
                    }
                }
            }
            catch (SqlException ex)
            {
                logEntry += GPLogger.CaptureSqlError(ex);
                // Aquí puedes agregar más lógica de manejo de errores si es necesario.
                throw; // Opcional: relanzar la excepción si necesitas manejarla a un nivel superior.
            }
            catch (Exception ex)
            {
                logEntry += GPLogger.CaptureError(ex);
                // Aquí puedes agregar más lógica de manejo de errores si es necesario.

            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    logEntry += "Timestamp: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\nConnection Closed\n";
                }
                connection.Dispose();

                GPLogger.SaveLogEntry(logEntry, "Database_" + fileName + methodName);
            }
            
            return List;
        }
    }
    public class responce_DB_ETIQUETA_VENTANA
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
    public class request_DB_ETIQUETA_VENTANA
    {
        public String Ip;
    }
}