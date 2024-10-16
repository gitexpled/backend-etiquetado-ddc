
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
    public class DB_UNITEC
    {
        public dynamic run(String cmd, dynamic array_pallet)
        {
            List<DATA_DB_UNITEC> lista_db = new List<DATA_DB_UNITEC>();
            List<DATA_DB_MANZANAS> lista_db_m = new List<DATA_DB_MANZANAS>();
            dynamic res = null;
            String _connectionStringUnitec = ConfigurationManager.ConnectionStrings["CS_UNITEC"].ToString();// CS_UNITEC(PRD) - DDCTEST (QAS) 
            SqlConnection connectionUnitec = new SqlConnection(_connectionStringUnitec);

            String _connectionStringUnitec2 = ConfigurationManager.ConnectionStrings["CS_UNITEC2"].ToString();// SQL(PRD) - DDCTEST (QAS) 
            SqlConnection connectionUnitec2 = new SqlConnection(_connectionStringUnitec2);

            String _connectionString = ConfigurationManager.ConnectionStrings["DDC_ETIQUETADO"].ToString();// DDC_ETIQUETADO(PRD) - CSPORTAL (QAS)
            SqlConnection connection = new SqlConnection(_connectionString);

            String _connectionString_connection_ddc_prd = ConfigurationManager.ConnectionStrings["DDC_PRD"].ToString();// DDC_PRD(PRD) -  (QAS)
            SqlConnection connection_ddc_prd = new SqlConnection(_connectionString_connection_ddc_prd);

            try
            {
                responce_DB_LOGIN data_user = getUserBD();

                switch (cmd)
                {
                    case "get_set_unitec":
                        lista_db = getDataUnitec(connectionUnitec);
                        if (lista_db.Count == 0)
                        {
                            res = "Sin datos obtenidos desde unitec";
                            return res;
                        }
                        List<DATA_DB_UNITEC> response_bd_interna = setDataDBGoplicity(connection_ddc_prd, lista_db);
                        List<dynamic> lista_by_row = new List<dynamic>();
                        foreach (dynamic row in response_bd_interna)
                        {

                            if (row.Kilos_Subprod.ToString() == "" || row.Material_Destare_Subp.ToString() == "")
                            {

                                responce_ZMOV_QUERY_STOCK_PROCESO data_lote_proceso = getLoteProceso(row.Lote_Proceso.ToString());
                                if (data_lote_proceso.STOCKPROCESO.Length > 0)
                                {
                                    string MATNR = data_lote_proceso.STOCKPROCESO[0].MATNR;
                                    dynamic respuesta = null;
                                    if (MATNR.Contains("SEP-"))
                                    {
                                        respuesta = notificacion_ZMOV_20034(row, data_user, data_lote_proceso);
                                    }
                                    else
                                    {
                                        respuesta = notificacion_ZMOV_20030(row, data_user, data_lote_proceso);
                                    }

                                    if (respuesta.Count > 0)
                                    {
                                        lista_by_row.Add(respuesta[0]);
                                    }
                                }

                            }
                            if (row.Kilos_Subprod.ToString() != "" && row.Material_Destare_Subp.ToString() != "")
                            {
                                dynamic respuesta = notificacion_CREATE_RECEP_PT_FRESCO(row, data_user);
                                if (respuesta.Count > 0)
                                {
                                    lista_by_row.Add(respuesta[0]);
                                }
                            }
                        }
                        res = lista_by_row;
                        break;
                    case "get_all":
                        res = getDataGoplicity(connection_ddc_prd, cmd);
                        break;
                    case "get_error":
                        res = getDataGoplicity(connection_ddc_prd, cmd);
                        break;
                    case "set_unitec_web":
                        if (array_pallet[0].Kilos_Subprod.ToString() == "" || array_pallet[0].Material_Destare_Subp.ToString() == "")
                        {
                            responce_ZMOV_QUERY_STOCK_PROCESO data_lote_proceso = getLoteProceso(array_pallet[0].Lote_Proceso.ToString());
                            string MATNR = "";
                            dynamic respuesta = null;
                            if (data_lote_proceso.STOCKPROCESO.Length == 0)
                            {
                                respuesta = "Sin datos obtenidos desde ZMOV_QUERY_STOCK_PROCESO";
                            }
                            else
                            {
                                MATNR = data_lote_proceso.STOCKPROCESO[0].MATNR;
                                if (MATNR.Contains("SEP-"))
                                {
                                    respuesta = notificacion_ZMOV_20034(array_pallet[0], data_user, data_lote_proceso);
                                }
                                else
                                {
                                    respuesta = notificacion_ZMOV_20030(array_pallet[0], data_user, data_lote_proceso);
                                }
                            }                       
                            
                            res = respuesta;
                        }
                        if (array_pallet[0].Kilos_Subprod.ToString() != "" && array_pallet[0].Material_Destare_Subp.ToString() != "")
                        {
                            dynamic respuesta = notificacion_CREATE_RECEP_PT_FRESCO(array_pallet[0], data_user);
                            res = respuesta;
                        }
                        break;
                    case "delete_row":
                        res = updateEstado(array_pallet[0], "ELIMINADO");
                        break;
                    case "get_data_etiqueta":
                        lista_db_m = getDataEtiquetas(connection);
                        if (lista_db_m.Count == 0)
                        {
                            res = "Sin datos obtenidos desde unitec";
                            return res;
                        }
                        List<DATA_DB_MANZANAS> response_bd_etiquetas_procesadas = setDataDBEtiquetaProcesadas(connection, lista_db_m, connectionUnitec2);
                        res = response_bd_etiquetas_procesadas;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                res = e.Message.ToString();
            }
            return res;
        }
        public List<DATA_DB_UNITEC> getDataUnitec(SqlConnection connection)
        {
            List<DATA_DB_UNITEC> resultList = new List<DATA_DB_UNITEC>();
            try
            {
                String QUERY = ConfigurationManager.AppSettings["QUERY"];
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                connection.Open();
                //cmd.Parameters.Add(new SqlParameter());
                comm.CommandType = CommandType.Text;
                comm.CommandText = QUERY; // "select * from [VW_SAP_Pallet];";
                SqlDataReader dataReader = comm.ExecuteReader();

                //res.DATA_UNITEC = new DATA_DB_UNITEC[cantidad_registros];

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DATA_DB_UNITEC data_deb_unitec = new DATA_DB_UNITEC();
                        data_deb_unitec.CodPallet = dataReader["CodPallet"].ToString().Trim();
                        data_deb_unitec.FechaProduccion_UM = dataReader["FechaProduccion UM"].ToString().Trim();
                        data_deb_unitec.TipoPallet = dataReader["TipoPallet"].ToString().Trim();
                        data_deb_unitec.Altura = dataReader["Altura"].ToString().Trim();
                        data_deb_unitec.TipoTarja = dataReader["TipoTarja"].ToString().Trim();
                        data_deb_unitec.Lote = dataReader["Lote"].ToString().Trim();
                        data_deb_unitec.Cantidad = dataReader["Cantidad"].ToString();
                        data_deb_unitec.Fecha_Produccion = dataReader["Fecha Produccion"].ToString().Trim();
                        data_deb_unitec.Lote_Proceso = dataReader["Lote Proceso"].ToString().Trim();
                        data_deb_unitec.Linea_Produccion = dataReader["Linea Produccion"].ToString().Trim();
                        data_deb_unitec.Turno_Produccion = dataReader["Turno Produccion"].ToString().Trim();
                        data_deb_unitec.Cod_Especie = dataReader["Cod.Especie"].ToString().Trim();
                        data_deb_unitec.Variedad = dataReader["Variedad"].ToString().Trim();
                        data_deb_unitec.Variedad_Rotulada = dataReader["Variedad Rotulada"].ToString().Trim();
                        data_deb_unitec.Cod_Embalaje = dataReader["Cod.Embalaje"].ToString().Trim();
                        data_deb_unitec.Calibre = dataReader["Calibre"].ToString().Trim();
                        data_deb_unitec.Calidad = dataReader["Calidad"].ToString().Trim();
                        data_deb_unitec.Productor = dataReader["Productor"].ToString().Trim();
                        data_deb_unitec.Protulado = dataReader["Protulado"].ToString().Trim();
                        data_deb_unitec.Kilos_Subprod = dataReader["Kilos Subprod."].ToString().Trim();
                        data_deb_unitec.Material_Destare_Subp = dataReader["Material Destare Subp."].ToString().Trim();
                        data_deb_unitec.estado = ""; // dataReader["estado"].ToString().Trim();
                        data_deb_unitec.Respuesta_sap = "";//dataReader["Respuesta_sap"].ToString().Trim();
                        resultList.Add(data_deb_unitec);
                    }

                }
                dataReader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
            return resultList;
        }
        public List<DATA_DB_UNITEC> getDataGoplicity(SqlConnection connection, String cmd)
        {
            List<DATA_DB_UNITEC> resultList = new List<DATA_DB_UNITEC>();
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                connection.Open();
                comm = new SqlCommand("unitec_procedure", connection);
                comm.Parameters.Add(new SqlParameter("@cmd", cmd));
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = comm.ExecuteReader();

                //res.DATA_UNITEC = new DATA_DB_UNITEC[cantidad_registros];

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DATA_DB_UNITEC data_deb_unitec = new DATA_DB_UNITEC();
                        data_deb_unitec.CodPallet = dataReader["CodPallet"].ToString().Trim();
                        data_deb_unitec.FechaProduccion_UM = dataReader["FechaProduccion UM"].ToString().Trim();
                        data_deb_unitec.TipoPallet = dataReader["TipoPallet"].ToString().Trim();
                        data_deb_unitec.Altura = dataReader["Altura"].ToString().Trim();
                        data_deb_unitec.TipoTarja = dataReader["TipoTarja"].ToString().Trim();
                        data_deb_unitec.Lote = dataReader["Lote"].ToString().Trim();
                        data_deb_unitec.Cantidad = dataReader["Cantidad"].ToString();
                        data_deb_unitec.Fecha_Produccion = dataReader["Fecha Produccion"].ToString().Trim();
                        data_deb_unitec.Lote_Proceso = dataReader["Lote Proceso"].ToString().Trim();
                        data_deb_unitec.Linea_Produccion = dataReader["Linea Produccion"].ToString().Trim();
                        data_deb_unitec.Turno_Produccion = dataReader["Turno Produccion"].ToString().Trim();
                        data_deb_unitec.Cod_Especie = dataReader["Cod.Especie"].ToString().Trim();
                        data_deb_unitec.Variedad = dataReader["Variedad"].ToString().Trim();
                        data_deb_unitec.Variedad_Rotulada = dataReader["Variedad Rotulada"].ToString().Trim();
                        data_deb_unitec.Cod_Embalaje = dataReader["Cod.Embalaje"].ToString().Trim();
                        data_deb_unitec.Calibre = dataReader["Calibre"].ToString().Trim();
                        data_deb_unitec.Calidad = dataReader["Calidad"].ToString().Trim();
                        data_deb_unitec.Productor = dataReader["Productor"].ToString().Trim();
                        data_deb_unitec.Protulado = dataReader["Protulado"].ToString().Trim();
                        data_deb_unitec.Kilos_Subprod = dataReader["Kilos Subprod."].ToString().Trim();
                        data_deb_unitec.Material_Destare_Subp = dataReader["Material Destare Subp."].ToString().Trim();
                        data_deb_unitec.estado = dataReader["estado"].ToString().Trim();
                        data_deb_unitec.Envio_Sap = dataReader["Envio_Sap"].ToString().Trim();
                        data_deb_unitec.Respuesta_sap = dataReader["Respuesta_sap"].ToString().Trim();
                        resultList.Add(data_deb_unitec);
                    }

                }
                dataReader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
            return resultList;
        }
        public List<DATA_DB_UNITEC> setDataDBGoplicity(SqlConnection connection, List<DATA_DB_UNITEC> datos)
        {
            List<DATA_DB_UNITEC> resultList = new List<DATA_DB_UNITEC>();


            SqlDataAdapter da = new SqlDataAdapter();
            SqlDataReader dataReader = null;
            try
            {
                connection.Open();
                foreach (dynamic row in datos)
                {
                    resultList.Clear(); // limpio la lita para q solo guarde el ultimo select obtenido del sp, si no, se duplica la informacion.

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd = new SqlCommand("unitec_procedure", connection);
                    cmd.Parameters.Add(new SqlParameter("@cmd", "set_bdgoplicity"));
                    cmd.Parameters.Add(new SqlParameter("@CodPallet", row.CodPallet));
                    cmd.Parameters.Add(new SqlParameter("@FechaProduccion_UM", row.FechaProduccion_UM));
                    cmd.Parameters.Add(new SqlParameter("@TipoPallet", row.TipoPallet));
                    cmd.Parameters.Add(new SqlParameter("@Altura", row.Altura));
                    cmd.Parameters.Add(new SqlParameter("@TipoTarja", row.TipoTarja));
                    cmd.Parameters.Add(new SqlParameter("@Lote", row.Lote));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", Int32.Parse(row.Cantidad)));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Produccion", row.Fecha_Produccion));
                    cmd.Parameters.Add(new SqlParameter("@Lote_Proceso", row.Lote_Proceso));
                    cmd.Parameters.Add(new SqlParameter("@Linea_Produccion", row.Linea_Produccion));
                    cmd.Parameters.Add(new SqlParameter("@Turno_Produccion", row.Turno_Produccion));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Especie", row.Cod_Especie));
                    cmd.Parameters.Add(new SqlParameter("@Variedad", row.Variedad));
                    cmd.Parameters.Add(new SqlParameter("@Variedad_Rotulada", row.Variedad_Rotulada));
                    cmd.Parameters.Add(new SqlParameter("@Cod_Embalaje", row.Cod_Embalaje));
                    cmd.Parameters.Add(new SqlParameter("@Calibre", row.Calibre));
                    cmd.Parameters.Add(new SqlParameter("@Calidad", row.Calidad));
                    cmd.Parameters.Add(new SqlParameter("@Productor", row.Productor));
                    cmd.Parameters.Add(new SqlParameter("@Protulado", row.Protulado));
                    cmd.Parameters.Add(new SqlParameter("@Kilos_Subprod", row.Kilos_Subprod));
                    cmd.Parameters.Add(new SqlParameter("@Material_Destare_Subp", row.Material_Destare_Subp));
                    cmd.CommandType = CommandType.StoredProcedure;
                    dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            DATA_DB_UNITEC data_deb_unitec = new DATA_DB_UNITEC();
                            data_deb_unitec.CodPallet = dataReader["CodPallet"].ToString().Trim();
                            data_deb_unitec.FechaProduccion_UM = dataReader["FechaProduccion UM"].ToString().Trim();
                            data_deb_unitec.TipoPallet = dataReader["TipoPallet"].ToString().Trim();
                            data_deb_unitec.Altura = dataReader["Altura"].ToString().Trim();
                            data_deb_unitec.TipoTarja = dataReader["TipoTarja"].ToString().Trim();
                            data_deb_unitec.Lote = dataReader["Lote"].ToString().Trim();
                            data_deb_unitec.Cantidad = dataReader["Cantidad"].ToString();
                            data_deb_unitec.Fecha_Produccion = dataReader["Fecha Produccion"].ToString().Trim();
                            data_deb_unitec.Lote_Proceso = dataReader["Lote Proceso"].ToString().Trim();
                            data_deb_unitec.Linea_Produccion = dataReader["Linea Produccion"].ToString().Trim();
                            data_deb_unitec.Turno_Produccion = dataReader["Turno Produccion"].ToString().Trim();
                            data_deb_unitec.Cod_Especie = dataReader["Cod.Especie"].ToString().Trim();
                            data_deb_unitec.Variedad = dataReader["Variedad"].ToString().Trim();
                            data_deb_unitec.Variedad_Rotulada = dataReader["Variedad Rotulada"].ToString().Trim();
                            data_deb_unitec.Cod_Embalaje = dataReader["Cod.Embalaje"].ToString().Trim();
                            data_deb_unitec.Calibre = dataReader["Calibre"].ToString().Trim();
                            data_deb_unitec.Calidad = dataReader["Calidad"].ToString().Trim();
                            data_deb_unitec.Productor = dataReader["Productor"].ToString().Trim();
                            data_deb_unitec.Protulado = dataReader["Protulado"].ToString().Trim();
                            data_deb_unitec.Kilos_Subprod = dataReader["Kilos Subprod."].ToString().Trim();
                            data_deb_unitec.Material_Destare_Subp = dataReader["Material Destare Subp."].ToString().Trim();
                            data_deb_unitec.estado = dataReader["estado"].ToString().Trim();
                            data_deb_unitec.Envio_Sap = dataReader["Envio_Sap"].ToString().Trim();
                            data_deb_unitec.Respuesta_sap = dataReader["Respuesta_sap"].ToString().Trim();
                            resultList.Add(data_deb_unitec);
                        }
                    }
                    dataReader.Close();
                }


                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }

            connection.Close();
            connection.Dispose();

            return resultList;
        }
        public responce_ZMOV_QUERY_STOCK_PROCESO getLoteProceso(string lote_proceso)
        {

            ZMOV_QUERY_STOCK_PROCESO sap = new ZMOV_QUERY_STOCK_PROCESO();
            request_ZMOV_QUERY_STOCK_PROCESO req = new request_ZMOV_QUERY_STOCK_PROCESO();
            req.LOTEPROCESO = lote_proceso.ToUpper();
            responce_ZMOV_QUERY_STOCK_PROCESO respuesta = sap.sapRun(req);
            return respuesta;
        }
        public responce_ZMF_GET_DAT_PROD getProductor(string productor, string especie)
        {

            ZMF_GET_DAT_PROD sap = new ZMF_GET_DAT_PROD();
            request_ZMF_GET_DAT_PROD req = new request_ZMF_GET_DAT_PROD();
            req.I_ESPECIE = especie;
            req.I_LIFNR = productor;
            responce_ZMF_GET_DAT_PROD respuesta = sap.sapRun(req);
            return respuesta;
        }
        public List<responce_ZMOV_20030> notificacion_ZMOV_20030(dynamic row, responce_DB_LOGIN data_user, responce_ZMOV_QUERY_STOCK_PROCESO data_lote_proceso)
        {
            List<responce_ZMOV_20030> lista_result = new List<responce_ZMOV_20030>();
            ZMOV_20030 zmov_20030 = new ZMOV_20030();
            request_ZMOV_20030 req = new request_ZMOV_20030();

            string especie = data_lote_proceso.STOCKPROCESO[0].ESPECIE;
            responce_ZMF_GET_DAT_PROD data_productor = getProductor(row.Productor.ToString().ToUpper(), especie);
            if (data_productor.ET_PRODUCT.Length == 0)
            {
                return lista_result;
            }

            string[] datefrombd = null;
            string[] datefrombd2 = null;
            string datetosend = "";
            string datetosend2 = "";
            try
            {
                datefrombd = row.FechaProduccion_UM.ToString().Split('.');
                datetosend = datefrombd[2] + "-" + datefrombd[1] + "-" + datefrombd[0];
                datefrombd2 = row.Fecha_Produccion.ToString().Split('.');
                datetosend2 = datefrombd2[2] + "-" + datefrombd2[1] + "-" + datefrombd2[0];
            }
            catch (Exception e)
            {
                datetosend = row.FechaProduccion_UM.ToString();
                datetosend2 = row.Fecha_Produccion.ToString();
            }

            req.HEADER = new ZMOV_20030_HEADER();
            req.HEADER.BUKRS = data_user.sociedad;
            req.HEADER.EKORG = data_user.organizacion;
            req.HEADER.EKGRP = data_user.grupoCompra;
            req.HEADER.BSART = data_user.clasePedido;
            req.HEADER.BUDAT = datetosend;
            req.HEADER.LIFNR = row.Productor;
            req.HEADER.XBLNR = row.Lote_Proceso;
            req.HEADER.BKTXT = data_user.usuario;

            req.HEADER_ADIC = new ZMOV_20030_HEADER_ADIC();
            req.HEADER_ADIC.STLAL = "01";
            req.HEADER_ADIC.EXTWG = row.Cod_Especie;
            req.HEADER_ADIC.ZVARIEDAD = row.Variedad_Rotulada;
            req.HEADER_ADIC.TIP_PACKING = "C"; // usuario $rootScope.userData.mail === 'recepcionPallet') ? 'S' : 'C'
            req.HEADER_ADIC.LGORT_TRASP = "PA02"; // usuario $rootScope.userData.mail === 'recepcionPallet') ? '' : 'PA02'
            req.HEADER_ADIC.STLAL_PALLET = "";
            req.HEADER_ADIC.SERVICIO = "";  // usuario $rootScope.userData.mail === 'servicio') ? 'X' : ''
            req.HEADER_ADIC.REEMBALAJE = ""; // usuario  $rootScope.dataSeleccion.reembalaje) ? 'X' : ''

            req.HEADER_HU = new ZMOV_20030_HEADER_HU();
            req.HEADER_HU.PACK_MAT = "PALLET";
            req.HEADER_HU.HU_EXID = row.CodPallet.ToString().PadLeft(20, '0');
            req.HEADER_HU.EXT_ID_HU_2 = "";
            req.HEADER_HU.CONTENT = row.TipoPallet;
            req.HEADER_HU.KZGVH = "X"; // "X"
            req.HEADER_HU.HU_GRP4 = row.Altura;
            req.HEADER_HU.LGORT_DS = data_user.almacenPallet;

            req.IR_MTART_NOT_541 = new ZMOV_20030_IR_MTART_NOT_541[1];
            req.IR_MTART_NOT_541[0] = new ZMOV_20030_IR_MTART_NOT_541();
            req.IR_MTART_NOT_541[0].SIGN = "I";
            req.IR_MTART_NOT_541[0].OPTION = "NE";
            req.IR_MTART_NOT_541[0].LOW = "ROH";

            req.LT_ITEMS = new ZMOV_20030_LT_ITEMS[1];
            req.LT_ITEMS[0] = new ZMOV_20030_LT_ITEMS();
            req.LT_ITEMS[0].MATERIAL = row.Cod_Embalaje;
            req.LT_ITEMS[0].QUANTITY = Decimal.Parse(row.Cantidad.ToString());
            //req.LT_ITEMS[0].PO_UNIT = "material.MEINS";
            req.LT_ITEMS[0].HSDAT = datetosend;
            req.LT_ITEMS[0].PLANT = data_user.centro;
            req.LT_ITEMS[0].STGE_LOC = data_user.almacenGranel;
            req.LT_ITEMS[0].FREE_ITEM = "X";
            req.LT_ITEMS[0].ITEM_CAT = "L";
            req.LT_ITEMS[0].BATCH = row.Lote;
            req.LT_ITEMS[0].BATCH_GRANEL = row.Lote_Proceso;
            req.LT_ITEMS[0].ACCTASSCAT = "F"; // DEFINIR
            req.LT_ITEMS[0].ALMAC_TRASP = data_user.planta;
            req.LT_ITEMS[0].AUFEX = "";

            req.LT_CARACT = new ZMOV_20030_LT_CARACT[18];  // 27
            int pos = 0;
            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_VARIEDAD";
            req.LT_CARACT[pos].VALUE_CHAR = row.Variedad;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZLINEA";
            req.LT_CARACT[pos].VALUE_CHAR = row.Linea_Produccion;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZTURNO";
            req.LT_CARACT[pos].VALUE_CHAR = row.Turno_Produccion;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZGGN";
            req.LT_CARACT[pos].VALUE_CHAR = data_productor.ET_PRODUCT[0].VIGENCIA.ToUpper() == "SI" ? data_productor.ET_PRODUCT[0].NUM_GGN : "NA";
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_VARIEDAD_ET";
            req.LT_CARACT[pos].VALUE_CHAR = row.Variedad_Rotulada;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_CALIBRE";
            req.LT_CARACT[pos].VALUE_CHAR = row.Calibre;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_CALIDAD";
            req.LT_CARACT[pos].VALUE_CHAR = row.Calidad;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZPRODUCTOR_ET";
            req.LT_CARACT[pos].VALUE_CHAR = row.Protulado;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZSAG_CSP";
            // de 87292 a 87290 modifcado el 24-01-2024 Conversado con Rodrigo Muñoz
            req.LT_CARACT[pos].VALUE_CHAR = "87290"; // usuario // 87292 modifcado el 24-01-2024 Conversado con Rodrigo Muñoz
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZFCOSECHA";
            req.LT_CARACT[pos].VALUE_CHAR = row.Fecha_Produccion.ToString();
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZNPARTIDA";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].NPARTIDA;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZPRODUCTOR";
            req.LT_CARACT[pos].VALUE_CHAR = row.Productor;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_TIPIFICACION";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TIPIFICACION;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZTFRIO";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TDFRIO;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZCAMARA";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].CAMARA;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZSAG_SDP";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].SAG_SDP;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z_TIPO_PROCESO";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TIPO_PROCESO;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20030_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZLOTE_PROCESO";
            req.LT_CARACT[pos].VALUE_CHAR = row.Lote_Proceso;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            responce_ZMOV_20030 respuesta = zmov_20030.sapRun(req);
            lista_result.Add(respuesta);
            string estado = "ENVIADO OK";
            if (respuesta.LOG.Length > 0)
            {
                estado = "ERROR"; // ACMODAR TAMANO VCHAR SQL A 20 PARA PODER SETEAR "ENVIADO ERROR"
            }
            var json2 = new JavaScriptSerializer().Serialize(req);
            var json3 = new JavaScriptSerializer().Serialize(respuesta);
            updateRegister(row, estado, json2.ToString(), json3.ToString());

            return lista_result;
        }
        public List<responce_ZMOV_20034> notificacion_ZMOV_20034(dynamic row, responce_DB_LOGIN data_user, responce_ZMOV_QUERY_STOCK_PROCESO data_lote_proceso)
        {

            List<responce_ZMOV_20034> lista_result = new List<responce_ZMOV_20034>();
            ZMOV_20034 zmov_20034 = new ZMOV_20034();
            request_ZMOV_20034 req = new request_ZMOV_20034();

            string especie = data_lote_proceso.STOCKPROCESO[0].ESPECIE;
            responce_ZMF_GET_DAT_PROD data_productor = getProductor(row.Productor.ToString().ToUpper(), especie);
            if (data_productor.ET_PRODUCT.Length == 0)
            {
                return lista_result;
            }

            string[] datefrombd = null;
            string[] datefrombd2 = null;
            string datetosend = "";
            string datetosend2 = "";
            try
            {
                datefrombd = row.FechaProduccion_UM.ToString().Split('.');
                datetosend = datefrombd[2] + "-" + datefrombd[1] + "-" + datefrombd[0];
                datefrombd2 = row.Fecha_Produccion.ToString().Split('.');
                datetosend2 = datefrombd2[2] + "-" + datefrombd2[1] + "-" + datefrombd2[0];
            }
            catch (Exception e)
            {
                datetosend = row.FechaProduccion_UM.ToString();
                datetosend2 = row.Fecha_Produccion.ToString();
            }


            req.HEADER = new ZMOV_20034_HEADER();
            req.HEADER.BUKRS = data_user.sociedad;
            req.HEADER.EKORG = data_user.organizacion;
            req.HEADER.EKGRP = "115"; //data_user.grupoCompra;
            req.HEADER.BSART = "ZFRS"; //data_user.clasePedido;
            req.HEADER.BUDAT = datetosend;
            req.HEADER.LIFNR = row.Productor;
            req.HEADER.XBLNR = row.Lote_Proceso;
            req.HEADER.BKTXT = data_user.usuario;

            req.HEADER_ADIC = new ZMOV_20034_HEADER_ADIC();
            req.HEADER_ADIC.STLAL = "01";
            req.HEADER_ADIC.EXTWG = row.Cod_Especie;
            req.HEADER_ADIC.ZVARIEDAD = row.Variedad_Rotulada;
            req.HEADER_ADIC.TIP_PACKING = "C"; // usuario $rootScope.userData.mail === 'recepcionPallet') ? 'S' : 'C'
            req.HEADER_ADIC.LGORT_TRASP = "PA02"; // usuario $rootScope.userData.mail === 'recepcionPallet') ? '' : 'PA02'
            req.HEADER_ADIC.STLAL_PALLET = "";
            req.HEADER_ADIC.SERVICIO = "X";  // usuario $rootScope.userData.mail === 'servicio') ? 'X' : ''
            req.HEADER_ADIC.REEMBALAJE = ""; // usuario  $rootScope.dataSeleccion.reembalaje) ? 'X' : ''

            req.HEADER_HU = new ZMOV_20034_HEADER_HU();
            req.HEADER_HU.PACK_MAT = "PALLET";
            req.HEADER_HU.HU_EXID = row.CodPallet.ToString().PadLeft(20, '0');
            req.HEADER_HU.EXT_ID_HU_2 = "";
            req.HEADER_HU.CONTENT = row.TipoPallet;
            req.HEADER_HU.KZGVH = "X"; // "X"
            req.HEADER_HU.HU_GRP4 = row.Altura;
            req.HEADER_HU.LGORT_DS = data_user.almacenPallet;

            req.IR_MTART_NOT_541 = new ZMOV_20034_IR_MTART_NOT_541[1];
            req.IR_MTART_NOT_541[0] = new ZMOV_20034_IR_MTART_NOT_541();
            req.IR_MTART_NOT_541[0].SIGN = "I";
            req.IR_MTART_NOT_541[0].OPTION = "NE";
            req.IR_MTART_NOT_541[0].LOW = "ROH";

            req.LT_ITEMS = new ZMOV_20034_LT_ITEMS[1];
            req.LT_ITEMS[0] = new ZMOV_20034_LT_ITEMS();
            req.LT_ITEMS[0].MATERIAL = row.Cod_Embalaje;
            req.LT_ITEMS[0].QUANTITY = Decimal.Parse(row.Cantidad.ToString());
            //req.LT_ITEMS[0].PO_UNIT = "material.MEINS";
            req.LT_ITEMS[0].HSDAT = datetosend;
            req.LT_ITEMS[0].PLANT = data_user.centro;
            req.LT_ITEMS[0].STGE_LOC = data_user.almacenGranel;
            req.LT_ITEMS[0].FREE_ITEM = "X";
            req.LT_ITEMS[0].ITEM_CAT = "L";
            req.LT_ITEMS[0].BATCH = row.Lote;
            req.LT_ITEMS[0].BATCH_GRANEL = row.Lote_Proceso;
            req.LT_ITEMS[0].ACCTASSCAT = "F"; // DEFINIR
            req.LT_ITEMS[0].ALMAC_TRASP = data_user.planta;
            req.LT_ITEMS[0].AUFEX = "";

            req.LT_CARACT = new ZMOV_20034_LT_CARACT[19];  // 27
            int pos = 0;
            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_VARIEDAD";
            req.LT_CARACT[pos].VALUE_CHAR = row.Variedad;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZLINEA";
            req.LT_CARACT[pos].VALUE_CHAR = row.Linea_Produccion;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZTURNO";
            req.LT_CARACT[pos].VALUE_CHAR = row.Turno_Produccion;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZGGN";
            req.LT_CARACT[pos].VALUE_CHAR = data_productor.ET_PRODUCT[0].VIGENCIA.ToUpper() == "SI" ? data_productor.ET_PRODUCT[0].NUM_GGN : "NA";
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_VARIEDAD_ET";
            req.LT_CARACT[pos].VALUE_CHAR = row.Variedad_Rotulada;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_CALIBRE";
            req.LT_CARACT[pos].VALUE_CHAR = row.Calibre;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_CALIDAD";
            req.LT_CARACT[pos].VALUE_CHAR = row.Calidad;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZPRODUCTOR_ET";
            req.LT_CARACT[pos].VALUE_CHAR = row.Protulado;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZSAG_CSP";
            // de 87292 a 87290 modifcado el 24-01-2024 Conversado con Rodrigo Muñoz
            req.LT_CARACT[pos].VALUE_CHAR = "87290"; // usuario
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZFCOSECHA";
            req.LT_CARACT[pos].VALUE_CHAR = row.Fecha_Produccion.ToString();
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZNPARTIDA";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].NPARTIDA;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZPRODUCTOR";
            req.LT_CARACT[pos].VALUE_CHAR = row.Productor;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_TIPIFICACION";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TIPIFICACION;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZTFRIO";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TDFRIO;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZCAMARA";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].CAMARA;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZSAG_SDP";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].SAG_SDP;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z_TIPO_PROCESO";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TIPO_PROCESO;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZLOTE_PROCESO";
            req.LT_CARACT[pos].VALUE_CHAR = row.Lote_Proceso;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_20034_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZCLIENTE";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].CLIENTE;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            responce_ZMOV_20034 respuesta = zmov_20034.sapRun(req);
            lista_result.Add(respuesta);
            string estado = "ENVIADO OK";
            if (respuesta.LOG.Length > 0)
            {
                estado = "ERROR"; // ACMODAR TAMANO VCHAR SQL A 20 PARA PODER SETEAR "ENVIADO ERROR"
            }
            var json2 = new JavaScriptSerializer().Serialize(req);
            var json3 = new JavaScriptSerializer().Serialize(respuesta);
            updateRegister(row, estado, json2.ToString(), json3.ToString());

            return lista_result;
        }
        public List<responce_ZMOV_CREATE_RECEP_PT_FRESCO> notificacion_CREATE_RECEP_PT_FRESCO(dynamic row, responce_DB_LOGIN data_user)
        {
            List<responce_ZMOV_CREATE_RECEP_PT_FRESCO> lista_result = new List<responce_ZMOV_CREATE_RECEP_PT_FRESCO>();
            ZMOV_CREATE_RECEP_PT_FRESCO sap = new ZMOV_CREATE_RECEP_PT_FRESCO();
            request_ZMOV_CREATE_RECEP_PT_FRESCO req = new request_ZMOV_CREATE_RECEP_PT_FRESCO();

            responce_ZMOV_QUERY_STOCK_PROCESO data_lote_proceso = getLoteProceso(row.Lote_Proceso.ToString());

            if (data_lote_proceso.STOCKPROCESO.Length == 0)
            {
                return lista_result;
            }
            string especie = data_lote_proceso.STOCKPROCESO[0].ESPECIE;
            responce_ZMF_GET_DAT_PROD data_productor = getProductor(row.Productor.ToString(), especie);

            string[] datefrombd = null;
            string[] datefrombd2 = null;
            string datetosend = "";
            string datetosend2 = "";

            try
            {
                datefrombd = row.FechaProduccion_UM.ToString().Split('.');
                datetosend = datefrombd[2] + "-" + datefrombd[1] + "-" + datefrombd[0];
                datefrombd2 = row.Fecha_Produccion.ToString().Split('.');
                datetosend2 = datefrombd2[2] + "-" + datefrombd2[1] + "-" + datefrombd2[0];
            }
            catch (Exception e)
            {
                datetosend = row.FechaProduccion_UM.ToString();
                datetosend2 = row.Fecha_Produccion.ToString();
            }

            if (data_productor.ET_PRODUCT.Length == 0)
            {
                return lista_result;
            }
            req.HEADER = new ZMOV_CREATE_RECEP_PT_FRESCO_HEADER();
            req.HEADER.BUKRS = data_user.sociedad;
            req.HEADER.EKORG = data_user.organizacion;
            req.HEADER.EKGRP = data_user.grupoCompra;
            req.HEADER.BSART = data_user.clasePedido;
            req.HEADER.BUDAT = datetosend;
            req.HEADER.LIFNR = row.Productor;
            req.HEADER.XBLNR = row.Lote_Proceso;
            req.HEADER.BKTXT = data_user.usuario;

            req.LT_ITEMS = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_ITEMS[1];
            req.LT_ITEMS[0] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_ITEMS();
            req.LT_ITEMS[0].MATERIAL = row.Cod_Embalaje;
            req.LT_ITEMS[0].QUANTITY = Decimal.Parse(row.Cantidad.ToString());
            //req.LT_ITEMS[0].PO_UNIT = "material.MEINS";
            req.LT_ITEMS[0].HSDAT = datetosend;
            req.LT_ITEMS[0].PLANT = data_user.centro;
            req.LT_ITEMS[0].STGE_LOC = data_user.almacenGranel;
            req.LT_ITEMS[0].FREE_ITEM = "X";
            req.LT_ITEMS[0].ITEM_CAT = "L";
            req.LT_ITEMS[0].BATCH_GRANEL = row.Lote_Proceso;
            req.LT_ITEMS[0].BATCH = row.Lote;
            req.LT_ITEMS[0].ACCTASSCAT = "F"; // DEFINIR

            req.LT_CARACT = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT[12];
            int pos = 0;
            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_CALIBRE";
            req.LT_CARACT[pos].VALUE_CHAR = row.Calibre;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZEMBALA";
            req.LT_CARACT[pos].VALUE_CHAR = "";
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            //req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            //req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            //req.LT_CARACT[pos].CHARACT = "ZTIPOENVASE";
            //req.LT_CARACT[pos].VALUE_CHAR = "";
            //req.LT_CARACT[pos].BATCH = row.Lote;
            //pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_VARIEDAD";
            req.LT_CARACT[pos].VALUE_CHAR = row.Variedad;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZPRODUCTOR";
            req.LT_CARACT[pos].VALUE_CHAR = row.Productor;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZTFRIO";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TDFRIO;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZTURNO";
            req.LT_CARACT[pos].VALUE_CHAR = row.Turno_Produccion;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZLINEA";
            req.LT_CARACT[pos].VALUE_CHAR = row.Linea_Produccion;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZSAG_CSP";
            req.LT_CARACT[pos].VALUE_CHAR = "87290"; // usuario
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZFCOSECHA";
            req.LT_CARACT[pos].VALUE_CHAR = row.Fecha_Produccion.ToString();
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "ZNENVASES";
            req.LT_CARACT[pos].VALUE_CHAR = "";
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z_TIPO_PROCESO";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TIPO_PROCESO;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            req.LT_CARACT[pos] = new ZMOV_CREATE_RECEP_PT_FRESCO_LT_CARACT();
            req.LT_CARACT[pos].MATERIAL = row.Cod_Embalaje;
            req.LT_CARACT[pos].CHARACT = "Z" + especie + "_TIPIFICACION";
            req.LT_CARACT[pos].VALUE_CHAR = data_lote_proceso.STOCKPROCESO[0].TIPIFICACION;
            req.LT_CARACT[pos].BATCH = row.Lote;
            pos++;

            responce_ZMOV_CREATE_RECEP_PT_FRESCO respuesta = sap.sapRun(req);
            lista_result.Add(respuesta);
            string estado = "ENVIADO OK";
            if (respuesta.LOG.Length > 0)
            {
                estado = "ERROR"; // ACMODAR TAMANO VCHAR SQL A 20 PARA PODER SETEAR "ENVIADO ERROR"
            }
            var json2 = new JavaScriptSerializer().Serialize(req);
            var json3 = new JavaScriptSerializer().Serialize(respuesta);
            updateRegister(row, estado, json2.ToString(), json3.ToString());

            return lista_result;
        }
        public List<DATA_DB_UNITEC> updateRegister(dynamic row, string Estado, string Envio_Sap, string Respuesta_sap)
        {
            List<DATA_DB_UNITEC> resultList = new List<DATA_DB_UNITEC>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd = new SqlCommand("unitec_procedure", connection);
            try
            {
                connection.Open();
                sqlcmd.Parameters.Add(new SqlParameter("@cmd", "update_registro"));
                sqlcmd.Parameters.Add(new SqlParameter("@Lote", row.Lote.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@CodPallet", row.CodPallet.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Estado", Estado));
                sqlcmd.Parameters.Add(new SqlParameter("@Envio_Sap", Envio_Sap));
                sqlcmd.Parameters.Add(new SqlParameter("@Respuesta_sap", Respuesta_sap));

                sqlcmd.Parameters.Add(new SqlParameter("@FechaProduccion_UM", row.FechaProduccion_UM.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@TipoPallet", row.TipoPallet.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Altura", row.Altura.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@TipoTarja", row.TipoTarja.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Cantidad", Int32.Parse(row.Cantidad.ToString())));
                sqlcmd.Parameters.Add(new SqlParameter("@Fecha_Produccion", row.Fecha_Produccion.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Lote_Proceso", row.Lote_Proceso.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Linea_Produccion", row.Linea_Produccion.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Turno_Produccion", row.Turno_Produccion.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Cod_Especie", row.Cod_Especie.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Variedad", row.Variedad.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Variedad_Rotulada", row.Variedad_Rotulada.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Cod_Embalaje", row.Cod_Embalaje.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Calibre", row.Calibre.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Calidad", row.Calidad.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Productor", row.Productor.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Protulado", row.Protulado.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Kilos_Subprod", row.Kilos_Subprod.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Material_Destare_Subp", row.Material_Destare_Subp.ToString()));

                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DATA_DB_UNITEC data_deb_unitec = new DATA_DB_UNITEC();
                        data_deb_unitec.msj = dataReader["msj"].ToString().Trim();
                        resultList.Add(data_deb_unitec);
                    }
                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }

            connection.Close();
            connection.Dispose();

            return resultList;
        }
        public List<DATA_DB_UNITEC> updateEstado(dynamic row, string Estado)
        {
            List<DATA_DB_UNITEC> resultList = new List<DATA_DB_UNITEC>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS3"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand comm = new SqlCommand();
            comm.Connection = connection;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd = new SqlCommand("unitec_procedure", connection);
            try
            {
                connection.Open();
                sqlcmd.Parameters.Add(new SqlParameter("@cmd", "delete_row"));
                sqlcmd.Parameters.Add(new SqlParameter("@Lote", row.Lote.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@CodPallet", row.CodPallet.ToString()));
                sqlcmd.Parameters.Add(new SqlParameter("@Estado", Estado));
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlcmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DATA_DB_UNITEC data_deb_unitec = new DATA_DB_UNITEC();
                        data_deb_unitec.msj = dataReader["msj"].ToString().Trim();
                        resultList.Add(data_deb_unitec);
                    }
                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }

            connection.Close();
            connection.Dispose();

            return resultList;
        }
        public responce_DB_LOGIN getUserBD()
        {

            DB_LOGIN sap = new DB_LOGIN();
            request_DB_LOGIN imp = new request_DB_LOGIN();
            imp.User = "dc0501";
            imp.Pass = "dc0501.21";
            imp.dataGranel = "";
            imp.Proceso = "";
            responce_DB_LOGIN obj = sap.run(imp);
            return obj;
        }
        // ---------------------------------- MANZANAS -----------------------------
        public List<DATA_DB_MANZANAS> getDataEtiquetas(SqlConnection connection)
        {
            List<DATA_DB_MANZANAS> resultList = new List<DATA_DB_MANZANAS>();
            try
            {
                string QUERY = ConfigurationManager.AppSettings["QUERY2"];
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                connection.Open();
                //cmd.Parameters.Add(new SqlParameter());
                comm.CommandType = CommandType.Text;
                comm.CommandText = QUERY; // "select * from [VW_SAP_Pallet];";
                SqlDataReader dataReader = comm.ExecuteReader();

                //res.DATA_UNITEC = new DATA_DB_UNITEC[cantidad_registros];

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DATA_DB_MANZANAS data_deb_unitec = new DATA_DB_MANZANAS();
                        data_deb_unitec.codCaja = dataReader["id"].ToString().Trim();
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
                        data_deb_unitec.codMarca = "DDC"; //dataReader["codMarca"].ToString().Trim();
                        data_deb_unitec.Marca = "DDC"; //dataReader["Marca"].ToString().Trim();
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
                        data_deb_unitec.correlativo = dataReader["cor"].ToString().Trim();
                        data_deb_unitec.Turno = dataReader["turno"].ToString().Trim();

                        resultList.Add(data_deb_unitec);
                    }

                }
                dataReader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                DATA_DB_MANZANAS data_deb_unitec = new DATA_DB_MANZANAS();
                data_deb_unitec.msj = e.Message.ToString();
                resultList.Add(data_deb_unitec);
                return resultList;
                throw e;
            }
            return resultList;
        }
        public List<DATA_DB_MANZANAS> setDataDBEtiquetaProcesadas(SqlConnection connection, List<DATA_DB_MANZANAS> datos, SqlConnection connectionUnite)
        {
            List<DATA_DB_MANZANAS> resultList = new List<DATA_DB_MANZANAS>();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd_unitec = new SqlCommand();
            string correlativos = "";
            try
            {
                string FechaHoraProduccion = "";
                string FechaHoraProduccion1 = "";
                string FechaTimbrada = "";
                string FechaTimbrada1 = "";
                foreach (dynamic row in datos)
                {

                    responce_ZMOV_QUERY_STOCK_PROCESO data_lote_proceso = getLoteProceso(row.Proceso);
                    string codProductorReal = "";
                    string ProductorReal = "";
                    string VariedadReal = "";
                    string codVariedadReal = "";
                    string especie = "";
                    string HSDAT = "";
                    string fecha_cosecha = "";
                    if (data_lote_proceso.STOCKPROCESO.Length > 0)
                    {
                        especie = data_lote_proceso.STOCKPROCESO[0].ESPECIE;
                        codProductorReal = data_lote_proceso.STOCKPROCESO[0].LIFNR;
                        ProductorReal = data_lote_proceso.STOCKPROCESO[0].NOMBRE_PRODUCTOR;
                        VariedadReal = data_lote_proceso.STOCKPROCESO[0].VARIEDAD;
                        codVariedadReal = data_lote_proceso.STOCKPROCESO[0].COD_VARIEDAD;
                        HSDAT = data_lote_proceso.STOCKPROCESO[0].HSDAT;
                        if (!HSDAT.Equals(""))
                        {
                            fecha_cosecha = HSDAT.Substring(5, 2) + "-" + HSDAT.Substring(8) + "-" + HSDAT.Substring(0, 4) + " 00:00:00";
                        }

                    }

                    //responce_ZMF_GET_DAT_PROD data_productor = getProductor(codProductorReal, especie);
                    //string PROVINCIA = data_productor.ET_PRODUCT[0].PROVINCIA;
                    //string COMUNA = data_productor.ET_PRODUCT[0].COMUNA;
                    //string REGION = data_productor.ET_PRODUCT[0].REGION;

                    resultList.Clear(); // limpio la lita para q solo guarde el ultimo select obtenido del sp, si no, se duplica la informacion.

                    cmd_unitec = new SqlCommand();
                    cmd_unitec.CommandText = getQuery("INT_uout_ext_cl");
                    cmd_unitec.Connection = connectionUnite;
                    cmd_unitec.Connection.Open();

                    FechaHoraProduccion = row.FechaHoraProduccion;
                    FechaHoraProduccion1 = FechaHoraProduccion.Substring(6) + "-" + FechaHoraProduccion.Substring(3, 2) + "-" + FechaHoraProduccion.Substring(0, 2);
                    FechaTimbrada = row.FechaHoraProduccion;
                    FechaTimbrada1 = FechaTimbrada.Substring(6) + "-" + FechaTimbrada.Substring(3, 2) + "-" + FechaTimbrada.Substring(0, 2);

                    cmd_unitec.Parameters.Add(new SqlParameter("@codCaja", row.correlativo));
                    cmd_unitec.Parameters.Add(new SqlParameter("@FechaHoraProduccion", FechaHoraProduccion1));
                    cmd_unitec.Parameters.Add(new SqlParameter("@FechaTimbrada", FechaTimbrada1));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Proceso", row.Proceso));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Lote", row.Lote));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codLinea", row.codLinea));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Linea", "LIN_0" + row.codLinea));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Salida", row.Salida));

                    cmd_unitec.Parameters.Add(new SqlParameter("@codTurno", row.Turno));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Turno", row.Turno.ToString() == "1" ? "DIA" : "NOCHE"));

                    cmd_unitec.Parameters.Add(new SqlParameter("@codEspecie", "11")); // Fijo 11 por ahora q es solo Manzanas
                    cmd_unitec.Parameters.Add(new SqlParameter("@Especie", especie));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codVariedadReal", codVariedadReal));
                    cmd_unitec.Parameters.Add(new SqlParameter("@VariedadReal", VariedadReal));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codVariedadTimbrada", row.codVariedadTimbrada));
                    cmd_unitec.Parameters.Add(new SqlParameter("@VariedadTimbrada", row.VariedadTimbrada));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codConfeccion", row.codConfeccion));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Confeccion", row.Confeccion));

                    cmd_unitec.Parameters.Add(new SqlParameter("@codEmbalaje", row.codConfeccion));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Embalaje", row.Confeccion));

                    cmd_unitec.Parameters.Add(new SqlParameter("@PesoTimbrado", row.PesoTimbrado));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codMarca", row.codMarca));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Marca", row.Marca));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codClaseCalibreColor", row.codClaseCalibreColor));
                    cmd_unitec.Parameters.Add(new SqlParameter("@CalibreTimbrado", row.CalibreTimbrado));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codCAT", row.codCAT));
                    cmd_unitec.Parameters.Add(new SqlParameter("@CAT", row.CAT));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codExportadora", row.codExportadora));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Exportadora", row.Exportadora));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codProductorReal", codProductorReal));
                    cmd_unitec.Parameters.Add(new SqlParameter("@ProductorReal", ProductorReal));
                    cmd_unitec.Parameters.Add(new SqlParameter("@codProductorTimbrado", row.codProductorTimbrado));
                    cmd_unitec.Parameters.Add(new SqlParameter("@ProductorTimbrado", row.ProductorTimbrado));
                    cmd_unitec.Parameters.Add(new SqlParameter("@CampoExtra1", fecha_cosecha)); // Aqui se guarda Fecha de cosecha
                    cmd_unitec.Parameters.Add(new SqlParameter("@Empresa", "0000"));
                    cmd_unitec.Parameters.Add(new SqlParameter("@Temporada", "00"));
                    cmd_unitec.CommandType = CommandType.Text;

                    int result = cmd_unitec.ExecuteNonQuery();
                    cmd_unitec.Connection.Close();
                    if (result > 0)
                    {
                        cmd = new SqlCommand();
                        cmd.CommandText = getQuery("etiquetas_procesadas");
                        cmd.Connection = connection;
                        cmd.Connection.Open();
                        cmd.Parameters.Add(new SqlParameter("@codCaja", row.correlativo));
                        cmd.Parameters.Add(new SqlParameter("@FechaHoraProduccion", FechaHoraProduccion1));
                        cmd.Parameters.Add(new SqlParameter("@FechaTimbrada", FechaTimbrada1));
                        cmd.Parameters.Add(new SqlParameter("@Proceso", row.Proceso));
                        cmd.Parameters.Add(new SqlParameter("@Lote", row.Lote));
                        cmd.Parameters.Add(new SqlParameter("@codLinea", row.codLinea));
                        cmd.Parameters.Add(new SqlParameter("@Linea", row.Linea));
                        cmd.Parameters.Add(new SqlParameter("@Salida", row.Salida));
                        cmd.Parameters.Add(new SqlParameter("@codEspecie", "11")); // Fijo 11 por ahora q es solo Manzanas
                        cmd.Parameters.Add(new SqlParameter("@Especie", especie));
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

                        if (result2 > 0)
                        {
                            if (correlativos == "")
                            {
                                correlativos += row.correlativo;
                            }
                            else 
                            {
                                correlativos += ("," + row.correlativo);
                            }                            
                        }

                    }

                }
                delete_Correlativo_EtiqeutasProcesadas(connection, correlativos, "0");
                delete_Correlativo_EtiqeutasProcesadas(connection, correlativos, "1");
            }
            catch (Exception e)
            {
                cmd.Connection.Close();
                cmd_unitec.Connection.Close();
                DATA_DB_MANZANAS data_deb_unitec = new DATA_DB_MANZANAS();
                data_deb_unitec.msj = e.Message.ToString();
                resultList.Add(data_deb_unitec);
                return resultList;
            }

            connection.Close();
            connection.Dispose();

            return resultList;
        }
        public String getQuery(string table)
        {
            String query = "";
            if (table == "etiquetas_procesadas")
            {
                query = "insert into [" + table + "] ("
                            + "[codCaja],[FechaHoraProduccion],[FechaTimbrada],[Proceso],[Lote],[codLinea],[Linea],[Salida]"
                      + ",[codEspecie],[Especie],[codVariedadReal],[VariedadReal],[codVariedadTimbrada],[VariedadTimbrada]"
                      + ",[codConfeccion],[Confeccion],[PesoTimbrado],[codMarca],[Marca],[codClaseCalibreColor],[CalibreTimbrado]"
                      + ",[codCAT],[CAT],[codExportadora],[Exportadora],[codProductorReal],[ProductorReal],[codProductorTimbrado]"
                      + ",[ProductorTimbrado])"
                      + "values(@codCaja,CONVERT(DATETIME, @FechaHoraProduccion, 102),CONVERT(DATETIME, @FechaTimbrada, 102),@Proceso,@Lote, @codLinea,@Linea, @Salida, @codEspecie,"
                      + "@Especie,@codVariedadReal,@VariedadReal,@codVariedadTimbrada,@VariedadTimbrada,@codConfeccion,@Confeccion,"
                      + "@PesoTimbrado,@codMarca,@Marca,@codClaseCalibreColor,@CalibreTimbrado,@codCAT,@CAT,@codExportadora,"
                      + "@Exportadora,@codProductorReal,@ProductorReal,@codProductorTimbrado,@ProductorTimbrado)";
            }
            if (table == "INT_uout_ext_cl")
            {
                query = "insert into [" + table + "] ("
                           + "[codCaja],[FechaHoraProduccion],[FechaTimbrada],[Proceso],[Lote],[codLinea],[Linea],[Salida]"
                     + ",[codEspecie],[Especie],[codVariedadReal],[VariedadReal],[codVariedadTimbrada],[VariedadTimbrada]"
                     + ",[codConfeccion],[Confeccion],[PesoTimbrado],[codMarca],[Marca],[codClaseCalibreColor],[CalibreTimbrado]"
                     + ",[codCAT],[CAT],[codExportadora],[Exportadora],[codProductorReal],[ProductorReal],[codProductorTimbrado]"
                     + ",[ProductorTimbrado],[Empresa],[Temporada],[codEmbalaje],[Embalaje],[codTurno],[Turno],[CampoExtra1])"
                     + "values(@codCaja,CONVERT(DATETIME, @FechaHoraProduccion, 102),CONVERT(DATETIME, @FechaTimbrada, 102),"
                     + "@Proceso,@Lote, @codLinea,@Linea, @Salida, @codEspecie,@Especie,@codVariedadReal,@VariedadReal,"
                     + "@codVariedadTimbrada,@VariedadTimbrada,@codConfeccion,@Confeccion,@PesoTimbrado,@codMarca,@Marca,"
                     + "@codClaseCalibreColor,@CalibreTimbrado,@codCAT,@CAT,@codExportadora,@Exportadora,@codProductorReal,"
                     + "@ProductorReal,@codProductorTimbrado,@ProductorTimbrado,@Empresa,@Temporada,@codEmbalaje,@Embalaje,"
                     + "@codTurno,@Turno,@CampoExtra1)";
            }
            return query;
        }
        public List<DATA_DB_MANZANAS> delete_Correlativo_EtiqeutasProcesadas(SqlConnection connection, string correlativos, string query_selected)
        {
            List<DATA_DB_MANZANAS> resultList = new List<DATA_DB_MANZANAS>();
            try
            {
                string QUERY = "";
                if (query_selected.Equals("0"))
                {
                    QUERY = "delete correlativos where correlativo in(" + correlativos + ");";
                }
                if (query_selected.Equals("1"))
                {
                    QUERY = "delete etiquetas_procesadas where codCaja in(" + correlativos + ");";
                }

                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                connection.Open();
                comm.CommandType = CommandType.Text;
                comm.CommandText = QUERY; // "select * from [VW_SAP_Pallet];";
                SqlDataReader dataReader = comm.ExecuteReader();


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                    }

                }
                dataReader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                DATA_DB_MANZANAS data_deb_unitec = new DATA_DB_MANZANAS();
                data_deb_unitec.msj = e.Message.ToString();
                resultList.Add(data_deb_unitec);
                return resultList;
                throw e;
            }
            return resultList;
        }

        // -------------------------------- FIN  MANZANAS --------------------------
    }
    public class request_DB_UNITEC
    {
        public DATA_DB_UNITEC [] DATA_UNITEC;
    }
    public class responce_DB_UNITEC
    {
        public DATA_DB_UNITEC [] DATA_UNITEC;
        public String error;
        public String ok;
    }
    public class DATA_DB_UNITEC
    {
        public String msj;
        public String CodPallet;
        public String FechaProduccion_UM;
        public String TipoPallet;
        public String Altura;
        public String TipoTarja;
        public String Lote;
        public String Cantidad;
        public String Fecha_Produccion;
        public String Lote_Proceso;
        public String Linea_Produccion;
        public String Turno_Produccion;
        public String Cod_Especie;
        public String Variedad;
        public String Variedad_Rotulada;
        public String Cod_Embalaje;
        public String Calibre;
        public String Calidad;
        public String Productor;
        public String Protulado;
        public String Kilos_Subprod;
        public String Material_Destare_Subp;
        public String estado;
        public String Respuesta_sap;
        public String Envio_Sap;
    }
    public class DATA_DB_MANZANAS
    {
        public String msj;
        public String Turno;
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
        public String correlativo;
    }

}