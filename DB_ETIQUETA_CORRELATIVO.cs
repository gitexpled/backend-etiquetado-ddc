using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public class DB_ETIQUETA_CORRELATIVO
    {
        public responce_DB_ETIQUETA_CORRELATIVO run(request_DB_ETIQUETA_CORRELATIVO datos)
        {
            responce_DB_ETIQUETA_CORRELATIVO response = new  responce_DB_ETIQUETA_CORRELATIVO();

            String _connectionString = ConfigurationManager.ConnectionStrings["DDC_ETIQUETADO"].ToString();// DDC_ETIQUETADO(PRD) - CSPORTAL (PRD)
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "get_CorrelativoEtiqueta";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id",datos.Id));
            cmd.Parameters.Add(new SqlParameter("@ip",datos.Ip));
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_DB_ETIQUETA_CORRELATIVO res = new responce_DB_ETIQUETA_CORRELATIVO();
                    response.correlativo = dataReader[0].ToString();
                    response.tipo = dataReader[1].ToString();                
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return response;
        }
        /*public List<DATA_DB_MANZANA> getDataEtiquetasProcesadas(String correlativo)
        {
            List<DATA_DB_MANZANA> resultList = new List<DATA_DB_MANZANA>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                
                string QUERY = "select * from [etiquetas_procesadas] where codCaja=" + correlativo + ";";
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                connection.Open();
                comm.CommandType = CommandType.Text;
                comm.CommandText = QUERY;
                SqlDataReader dataReader = comm.ExecuteReader();

                //res.DATA_UNITEC = new DATA_DB_UNITEC[cantidad_registros];

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DATA_DB_MANZANA data_deb_unitec = new DATA_DB_MANZANA();
                        data_deb_unitec.codCaja = dataReader["codCaja"].ToString().Trim();
                        data_deb_unitec.FechaHoraProduccion = dataReader["fecha_prd"].ToString().Trim();
                        data_deb_unitec.FechaTimbrada = dataReader["fecha_prd"].ToString().Trim();
                        data_deb_unitec.Proceso = dataReader["proceso"].ToString().Trim();
                        data_deb_unitec.Lote = dataReader["Lote"].ToString().Trim();
                        data_deb_unitec.codLinea = dataReader["linea"].ToString();
                        data_deb_unitec.Linea = dataReader["linea"].ToString().Trim();
                        data_deb_unitec.Salida = dataReader["salida"].ToString().Trim();
                        data_deb_unitec.codEspecie = dataReader["especie"].ToString().Trim();
                        data_deb_unitec.Especie = dataReader["especie"].ToString().Trim();
                        data_deb_unitec.codVariedadReal = dataReader["variedad_value"].ToString().Trim();
                        data_deb_unitec.VariedadReal = dataReader["variedad"].ToString().Trim();
                        data_deb_unitec.codVariedadTimbrada = dataReader["variedad_value"].ToString().Trim();
                        data_deb_unitec.VariedadTimbrada = dataReader["variedad"].ToString().Trim();
                        data_deb_unitec.codConfeccion = dataReader["codigo_material"].ToString().Trim();
                        data_deb_unitec.Confeccion = dataReader["codigo_material"].ToString().Trim();
                        data_deb_unitec.PesoTimbrado = dataReader["kilos"].ToString().Trim();
                        data_deb_unitec.codMarca = dataReader["codMarca"].ToString().Trim();
                        data_deb_unitec.Marca = dataReader["Marca"].ToString().Trim();
                        data_deb_unitec.codClaseCalibreColor = dataReader["calibre"].ToString().Trim();
                        data_deb_unitec.CalibreTimbrado = dataReader["calibre"].ToString().Trim();
                        data_deb_unitec.codCAT = dataReader["calidad"].ToString().Trim();
                        data_deb_unitec.CAT = dataReader["calidad"].ToString().Trim();
                        data_deb_unitec.codExportadora = dataReader["exportadora"].ToString().Trim();
                        data_deb_unitec.Exportadora = dataReader["exportadora"].ToString().Trim();
                        data_deb_unitec.codProductorReal = dataReader["productor"].ToString().Trim();
                        data_deb_unitec.ProductorReal = dataReader["productor"].ToString().Trim();
                        data_deb_unitec.codProductorTimbrado = dataReader["productor"].ToString().Trim();
                        data_deb_unitec.ProductorTimbrado = dataReader["productor"].ToString().Trim();

                        resultList.Add(data_deb_unitec);
                    }

                }
                dataReader.Close();
                connection.Close();

                setDataDBUnitec(resultList, correlativo);
                setDataDBEtiquetasProcesadas(resultList, correlativo);

            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
            return resultList;
        }
        public List<DATA_DB_MANZANA> setDataDBUnitec(List<DATA_DB_MANZANA> datos, String correlativo)
        {
            List<DATA_DB_MANZANA> resultList = new List<DATA_DB_MANZANA>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {
                foreach (dynamic row in datos)
                {

                        cmd = new SqlCommand();
                        cmd.CommandText = getQuery("INT_uout_ext_cl");
                        cmd.Connection = connection;
                        cmd.Connection.Open();
                        cmd.Parameters.Add(new SqlParameter("@codCaja", correlativo)); // tengo
                        cmd.Parameters.Add(new SqlParameter("@FechaHoraProduccion", row.FechaHoraProduccion));
                        cmd.Parameters.Add(new SqlParameter("@FechaTimbrada", row.FechaTimbrada));
                        cmd.Parameters.Add(new SqlParameter("@Proceso", row.Proceso));
                        cmd.Parameters.Add(new SqlParameter("@Lote", row.Lote));
                        cmd.Parameters.Add(new SqlParameter("@codLinea", row.codLinea));
                        cmd.Parameters.Add(new SqlParameter("@Linea", row.Linea));
                        cmd.Parameters.Add(new SqlParameter("@Salida", row.Salida));
                        cmd.Parameters.Add(new SqlParameter("@codEspecie", row.codEspecie));
                        cmd.Parameters.Add(new SqlParameter("@Especie", row.Especie));
                        cmd.Parameters.Add(new SqlParameter("@codVariedadReal", row.codVariedadReal));
                        cmd.Parameters.Add(new SqlParameter("@VariedadReal", row.VariedadReal));
                        cmd.Parameters.Add(new SqlParameter("@codVariedadTimbrada", row.codVariedadTimbrada));
                        cmd.Parameters.Add(new SqlParameter("@VariedadTimbrada", row.VariedadTimbrada));
                        cmd.Parameters.Add(new SqlParameter("@codConfeccion", row.codConfeccion));
                        cmd.Parameters.Add(new SqlParameter("@Confeccion", row.Confeccion));
                        cmd.Parameters.Add(new SqlParameter("@PesoTimbrado", row.PesoTimbrado));
                        cmd.Parameters.Add(new SqlParameter("@codMarca", row.codMarca));
                        cmd.Parameters.Add(new SqlParameter("@Marca", row.Marca));
                        cmd.Parameters.Add(new SqlParameter("@codClaseCalibreColor", row.codClaseCalibreColor));
                        cmd.Parameters.Add(new SqlParameter("@CalibreTimbrado", row.CalibreTimbrado));
                        cmd.Parameters.Add(new SqlParameter("@codCAT", row.codCAT));
                        cmd.Parameters.Add(new SqlParameter("@CAT", row.CAT));
                        cmd.Parameters.Add(new SqlParameter("@codExportadora", row.codExportadora));
                        cmd.Parameters.Add(new SqlParameter("@Exportadora", row.Exportadora));
                        cmd.Parameters.Add(new SqlParameter("@codProductorReal", row.codProductorReal));
                        cmd.Parameters.Add(new SqlParameter("@ProductorReal", row.ProductorReal));
                        cmd.Parameters.Add(new SqlParameter("@codProductorTimbrado", row.codProductorTimbrado));
                        cmd.Parameters.Add(new SqlParameter("@ProductorTimbrado", row.ProductorTimbrado));
                        cmd.CommandType = CommandType.Text;
                        int result2 = cmd.ExecuteNonQuery();
                        cmd.Connection.Close();                   

                }
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            connection.Close();
            connection.Dispose();

            return resultList;
        }
        public List<DATA_DB_MANZANA> setDataDBEtiquetasProcesadas(List<DATA_DB_MANZANA> datos, String correlativo)
        {
            List<DATA_DB_MANZANA> resultList = new List<DATA_DB_MANZANA>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {
                foreach (dynamic row in datos)
                {

                    cmd = new SqlCommand();
                    cmd.CommandText = getQuery("etiquetas_procesadas");
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter("@codCaja", correlativo)); // tengo
                    cmd.Parameters.Add(new SqlParameter("@FechaHoraProduccion", row.FechaHoraProduccion));
                    cmd.Parameters.Add(new SqlParameter("@FechaTimbrada", row.FechaTimbrada));
                    cmd.Parameters.Add(new SqlParameter("@Proceso", row.Proceso));
                    cmd.Parameters.Add(new SqlParameter("@Lote", row.Lote));
                    cmd.Parameters.Add(new SqlParameter("@codLinea", row.codLinea));
                    cmd.Parameters.Add(new SqlParameter("@Linea", row.Linea));
                    cmd.Parameters.Add(new SqlParameter("@Salida", row.Salida));
                    cmd.Parameters.Add(new SqlParameter("@codEspecie", row.codEspecie));
                    cmd.Parameters.Add(new SqlParameter("@Especie", row.Especie));
                    cmd.Parameters.Add(new SqlParameter("@codVariedadReal", row.codVariedadReal));
                    cmd.Parameters.Add(new SqlParameter("@VariedadReal", row.VariedadReal));
                    cmd.Parameters.Add(new SqlParameter("@codVariedadTimbrada", row.codVariedadTimbrada));
                    cmd.Parameters.Add(new SqlParameter("@VariedadTimbrada", row.VariedadTimbrada));
                    cmd.Parameters.Add(new SqlParameter("@codConfeccion", row.codConfeccion));
                    cmd.Parameters.Add(new SqlParameter("@Confeccion", row.Confeccion));
                    cmd.Parameters.Add(new SqlParameter("@PesoTimbrado", row.PesoTimbrado));
                    cmd.Parameters.Add(new SqlParameter("@codMarca", row.codMarca));
                    cmd.Parameters.Add(new SqlParameter("@Marca", row.Marca));
                    cmd.Parameters.Add(new SqlParameter("@codClaseCalibreColor", row.codClaseCalibreColor));
                    cmd.Parameters.Add(new SqlParameter("@CalibreTimbrado", row.CalibreTimbrado));
                    cmd.Parameters.Add(new SqlParameter("@codCAT", row.codCAT));
                    cmd.Parameters.Add(new SqlParameter("@CAT", row.CAT));
                    cmd.Parameters.Add(new SqlParameter("@codExportadora", row.codExportadora));
                    cmd.Parameters.Add(new SqlParameter("@Exportadora", row.Exportadora));
                    cmd.Parameters.Add(new SqlParameter("@codProductorReal", row.codProductorReal));
                    cmd.Parameters.Add(new SqlParameter("@ProductorReal", row.ProductorReal));
                    cmd.Parameters.Add(new SqlParameter("@codProductorTimbrado", row.codProductorTimbrado));
                    cmd.Parameters.Add(new SqlParameter("@ProductorTimbrado", row.ProductorTimbrado));
                    cmd.CommandType = CommandType.Text;
                    int result2 = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                }
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
            }

            connection.Close();
            connection.Dispose();

            return resultList;
        }
        
        public String getQuery(string table)
        {

            String query = "insert into [" + table + "] ("
                        + "[codCaja],[FechaHoraProduccion],[FechaTimbrada],[Proceso],[Lote],[codLinea],[Linea],[Salida]"
                  + ",[codEspecie],[Especie],[codVariedadReal],[VariedadReal],[codVariedadTimbrada],[VariedadTimbrada]"
                  + ",[codConfeccion],[Confeccion],[PesoTimbrado],[codMarca],[Marca],[codClaseCalibreColor],[CalibreTimbrado]"
                  + ",[codCAT],[CAT],[codExportadora],[Exportadora],[codProductorReal],[ProductorReal],[codProductorTimbrado]"
                  + ",[ProductorTimbrado])"
                  + "values(@codCaja,CONVERT(DATETIME, @FechaHoraProduccion, 102),CONVERT(DATETIME, @FechaTimbrada, 102),@Proceso,@Lote, @codLinea,@Linea, @Salida, @codEspecie,"
                  + "@Especie,@codVariedadReal,@VariedadReal,@codVariedadTimbrada,@VariedadTimbrada,@codConfeccion,@Confeccion,"
                  + "@PesoTimbrado,@codMarca,@Marca,@codClaseCalibreColor,@CalibreTimbrado,@codCAT,@CAT,@codExportadora,"
                  + "@Exportadora,@codProductorReal,@ProductorReal,@codProductorTimbrado,@ProductorTimbrado)";

            return query;
        }
        */
    }
    public class responce_DB_ETIQUETA_CORRELATIVO
    {
        public String correlativo;
        public String tipo;
        
    }
    public class request_DB_ETIQUETA_CORRELATIVO
    {
        public String Ip;
        public String Id;
    }
    public class DATA_DB_MANZANA
    {
        public String codCaja;
        public String FechaHoraProduccion;
        public String FechaTimbrada;
        public String Proceso;
        public String Lote;
        public String codLinea;
        public String Linea;
        public String Salida;
        public String codEspecie;
        public String Especie;
        public String codVariedadReal;
        public String VariedadReal;
        public String codVariedadTimbrada;
        public String VariedadTimbrada;
        public String codConfeccion;
        public String Confeccion;
        public String PesoTimbrado;
        public String codMarca;
        public String Marca;
        public String codClaseCalibreColor;
        public String CalibreTimbrado;
        public String codCAT;
        public String CAT;
        public String codExportadora;
        public String Exportadora;
        public String codProductorReal;
        public String ProductorReal;
        public String codProductorTimbrado;
        public String ProductorTimbrado;
        public String Empresa;
        public String Temporada;
    }

}