using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SAP.Middleware.Connector;
using System.Web.Script.Serialization;

namespace rfcBaika
{
    public class reembalaje
    {
        static string PEDIDO = "";
        static string ORDEN_COGR = "";
        public static RESPUESTA EjecutaReembalaje(string Ingreso)
        {


            RESPUESTA response = new RESPUESTA();
            string DOCUMENTO;

            dynamic ObjetoIngreso = JsonConvert.DeserializeObject(Ingreso);

            JArray listaEjecuciones = JArray.Parse(ObjetoIngreso.OBJETOENTRADA.ToString());

            response.MENSAJES = new RESPUESTAS[listaEjecuciones.Count];

            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");

            RfcRepository SapRfcRepository = configSap.Repository;


            //sap.sapRun



            object respuestaBapi;

            int i = 0;

            //PEDIDO ok
            response.MENSAJES[i] = new RESPUESTAS();
            respuestaBapi = Ejecuta_BAPI_PO_CREATE1(null, false, listaEjecuciones[i].ToString(), configSap, SapRfcRepository, false);

            dynamic ObjetoSalida = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(respuestaBapi));

            if (ObjetoSalida.RESULTADO_BAPI == true)
            {
                response.MENSAJES[i].RESULTADO = true;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = true;
                BAPI_TRANSACTION.Commit(configSap);
                i++;
            }
            else
            {
                response.MENSAJES[i].RESULTADO = false;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = true;
                BAPI_TRANSACTION.Rollback(configSap);
                ORDEN_COGR = "";
                return response;

            }

            //541 ok

            response.MENSAJES[i] = new RESPUESTAS();
            respuestaBapi = Ejecuta_BAPI_MIGO_541_2(null, false, listaEjecuciones[i].ToString(), configSap, SapRfcRepository, false);

            ObjetoSalida = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(respuestaBapi));

            if (ObjetoSalida.RESULTADO_BAPI == true)
            {
                response.MENSAJES[i].RESULTADO = true;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = true;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                BAPI_TRANSACTION.Commit(configSap);
                DOCUMENTO = ObjetoSalida.DOCUMENTO;
                i++;
            }
            else
            {
                response.MENSAJES[i].RESULTADO = false;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = false;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                //ANULAR MIGOS
                try
                {
                    bool anulapedido = true;
                    for (int k = response.MENSAJES.Length - 1; k >= 0; k--)
                    {
                        if (response.MENSAJES[k] != null)
                        {

                            if (response.MENSAJES[k].DOCUMENTO != "" && response.MENSAJES[k].DOCUMENTO != null)
                            {
                                responce_BAPI_GOODSMVT_CANCEL respuestaAnulacion = (responce_BAPI_GOODSMVT_CANCEL)Ejecuta_BAPI_MIGO_CANCEL(response.MENSAJES[k].DOCUMENTO);

                                if (respuestaAnulacion.RESULTADO_BAPI == true)
                                {
                                    response.MENSAJES[k].COMPLEMENTO = new JavaScriptSerializer().Serialize(respuestaAnulacion);
                                }
                                else
                                {
                                    anulapedido = false;
                                }

                            }
                        }

                    }



                    //ANULA PEDIDO
                    try
                    {
                        if (anulapedido)
                        {
                            response.MENSAJES[0].COMPLEMENTO = new JavaScriptSerializer().Serialize(Ejecuta_BAPI_PO_CHANGE(null, false, PEDIDO));
                        }
                        else
                        {
                            response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO SE ANULO, DEBIDO A UN PROBLEMA A ANULAR DOCUMENTOS RELACIONADOS, FAVOR ANULAR";
                        }
                    }
                    catch (Exception ex)
                    {
                        response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR. ERROR: " + ex.ToString();
                    }

                }
                catch
                {


                    //  response.MENSAJES[i].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR";
                }
                response.RESULTADO = false;
                BAPI_TRANSACTION.Rollback(configSap);
                ORDEN_COGR = "";
                return response;

            }


            //101 CONTRA PEDIDO ok

            response.MENSAJES[i] = new RESPUESTAS();
            respuestaBapi = Ejecuta_BAPI_MIGO_543_PROCESO(null, false, listaEjecuciones[i].ToString(), configSap, SapRfcRepository, false);

            ObjetoSalida = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(respuestaBapi));

            if (ObjetoSalida.RESULTADO_BAPI == true)
            {
                response.MENSAJES[i].RESULTADO = true;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = true;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                BAPI_TRANSACTION.Commit(configSap);
                DOCUMENTO = ObjetoSalida.DOCUMENTO;
                i++;
            }
            else
            {
                response.MENSAJES[i].RESULTADO = false;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = false;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                //ANULAR MIGOS
                try
                {
                    bool anulapedido = true;
                    for (int k = response.MENSAJES.Length - 1; k >= 0; k--)
                    {
                        if (response.MENSAJES[k] != null)
                        {

                            if (response.MENSAJES[k].DOCUMENTO != "" && response.MENSAJES[k].DOCUMENTO != null)
                            {
                                responce_BAPI_GOODSMVT_CANCEL respuestaAnulacion = (responce_BAPI_GOODSMVT_CANCEL)Ejecuta_BAPI_MIGO_CANCEL(response.MENSAJES[k].DOCUMENTO);

                                if (respuestaAnulacion.RESULTADO_BAPI == true)
                                {
                                    response.MENSAJES[k].COMPLEMENTO = new JavaScriptSerializer().Serialize(respuestaAnulacion);
                                }
                                else
                                {
                                    anulapedido = false;
                                }

                            }
                        }

                    }



                    //ANULA PEDIDO
                    try
                    {
                        if (anulapedido)
                        {
                            response.MENSAJES[0].COMPLEMENTO = new JavaScriptSerializer().Serialize(Ejecuta_BAPI_PO_CHANGE(null, false, PEDIDO));
                        }
                        else
                        {
                            response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO SE ANULO, DEBIDO A UN PROBLEMA A ANULAR DOCUMENTOS RELACIONADOS, FAVOR ANULAR";
                        }
                    }
                    catch (Exception ex)
                    {
                        response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR. ERROR: " + ex.ToString();
                    }

                }
                catch
                {


                    //  response.MENSAJES[i].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR";
                }

                response.RESULTADO = false;
                BAPI_TRANSACTION.Rollback(configSap);
                ORDEN_COGR = "";
                return response;

            }


            //101 CONTRA ORDEN ok

            response.MENSAJES[i] = new RESPUESTAS();
            respuestaBapi = Ejecuta_BAPI_MIGO_101_PROCESO(null, false, listaEjecuciones[i].ToString(), configSap, SapRfcRepository, false);

            ObjetoSalida = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(respuestaBapi));

            if (ObjetoSalida.RESULTADO_BAPI == true)
            {
                response.MENSAJES[i].RESULTADO = true;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = true;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                BAPI_TRANSACTION.Commit(configSap);
                DOCUMENTO = ObjetoSalida.DOCUMENTO;
                i++;
            }
            else
            {
                response.MENSAJES[i].RESULTADO = false;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = false;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                //ANULAR MIGOS
                try
                {
                    bool anulapedido = true;
                    for (int k = response.MENSAJES.Length - 1; k >= 0; k--)
                    {
                        if (response.MENSAJES[k] != null)
                        {

                            if (response.MENSAJES[k].DOCUMENTO != "" && response.MENSAJES[k].DOCUMENTO != null)
                            {
                                responce_BAPI_GOODSMVT_CANCEL respuestaAnulacion = (responce_BAPI_GOODSMVT_CANCEL)Ejecuta_BAPI_MIGO_CANCEL(response.MENSAJES[k].DOCUMENTO);

                                if (respuestaAnulacion.RESULTADO_BAPI == true)
                                {
                                    response.MENSAJES[k].COMPLEMENTO = new JavaScriptSerializer().Serialize(respuestaAnulacion);
                                }
                                else
                                {
                                    anulapedido = false;
                                }

                            }
                        }

                    }



                    //ANULA PEDIDO
                    try
                    {
                        if (anulapedido)
                        {
                            response.MENSAJES[0].COMPLEMENTO = new JavaScriptSerializer().Serialize(Ejecuta_BAPI_PO_CHANGE(null, false, PEDIDO));
                        }
                        else
                        {
                            response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO SE ANULO, DEBIDO A UN PROBLEMA A ANULAR DOCUMENTOS RELACIONADOS, FAVOR ANULAR";
                        }
                    }
                    catch (Exception ex)
                    {
                        response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR. ERROR: " + ex.ToString();
                    }

                }
                catch
                {


                    //  response.MENSAJES[i].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR";
                }

                response.RESULTADO = false;
                BAPI_TRANSACTION.Rollback(configSap);
                ORDEN_COGR = "";
                return response;

            }
            
            response.MENSAJES[i] = new RESPUESTAS();
            respuestaBapi = Ejecuta_BAPI_MIGO_541_REPROCESO(null, false, listaEjecuciones[i].ToString(), configSap, SapRfcRepository, false);

            ObjetoSalida = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(respuestaBapi));

            if (ObjetoSalida.RESULTADO_BAPI == true)
            {
                response.MENSAJES[i].RESULTADO = true;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = true;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                BAPI_TRANSACTION.Commit(configSap);
                DOCUMENTO = ObjetoSalida.DOCUMENTO;
                i++;
            }
            else
            {
                response.MENSAJES[i].RESULTADO = false;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = false;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                //ANULAR MIGOS
                try
                {
                    bool anulapedido = true;
                    for (int k = response.MENSAJES.Length - 1; k >= 0; k--)
                    {
                        if (response.MENSAJES[k] != null)
                        {

                            if (response.MENSAJES[k].DOCUMENTO != "" && response.MENSAJES[k].DOCUMENTO != null)
                            {
                                responce_BAPI_GOODSMVT_CANCEL respuestaAnulacion = (responce_BAPI_GOODSMVT_CANCEL)Ejecuta_BAPI_MIGO_CANCEL(response.MENSAJES[k].DOCUMENTO);

                                if (respuestaAnulacion.RESULTADO_BAPI == true)
                                {
                                    response.MENSAJES[k].COMPLEMENTO = new JavaScriptSerializer().Serialize(respuestaAnulacion);
                                }
                                else
                                {
                                    anulapedido = false;
                                }

                            }
                        }

                    }
                    //ANULA PEDIDO
                    try
                    {
                        if (anulapedido)
                        {
                            response.MENSAJES[0].COMPLEMENTO = new JavaScriptSerializer().Serialize(Ejecuta_BAPI_PO_CHANGE(null, false, PEDIDO));
                        }
                        else
                        {
                            response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO SE ANULO, DEBIDO A UN PROBLEMA A ANULAR DOCUMENTOS RELACIONADOS, FAVOR ANULAR";
                        }
                    }
                    catch (Exception ex)
                    {
                        response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR. ERROR: " + ex.ToString();
                    }

                }
                catch
                {
                    //  response.MENSAJES[i].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR";
                }

                response.RESULTADO = false;
                BAPI_TRANSACTION.Rollback(configSap);
                ORDEN_COGR = "";
                return response;

            }

            // CARACTERISTICAS DE LOTE 
            // TODO ACTUALIZAR CARACTERISTICAS DEL LOTE DE MP (REDUCIR MATERIALES)

            response.MENSAJES[i] = new RESPUESTAS();
            respuestaBapi = Ejecuta_BAPI_ACTUALIZA_LOTE(null, false, listaEjecuciones[i].ToString(), configSap, SapRfcRepository, false);

            ObjetoSalida = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(respuestaBapi));

            if (ObjetoSalida.RESULTADO_BAPI == true)
            {
                response.MENSAJES[i].RESULTADO = true;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = true;
                BAPI_TRANSACTION.Commit(configSap);
                i++;
            }
            else
            {
                response.MENSAJES[i].RESULTADO = false;
                response.MENSAJES[i].MENSAJES = new JavaScriptSerializer().Serialize(respuestaBapi);
                response.RESULTADO = false;
                response.MENSAJES[i].DOCUMENTO = ObjetoSalida.DOCUMENTO;
                //ANULAR MIGOS
                try
                {
                    bool anulapedido = true;
                    for (int k = response.MENSAJES.Length - 1; k >= 0; k--)
                    {
                        if (response.MENSAJES[k] != null)
                        {

                            if (response.MENSAJES[k].DOCUMENTO != "" && response.MENSAJES[k].DOCUMENTO != null)
                            {
                                responce_BAPI_GOODSMVT_CANCEL respuestaAnulacion = (responce_BAPI_GOODSMVT_CANCEL)Ejecuta_BAPI_MIGO_CANCEL(response.MENSAJES[k].DOCUMENTO);

                                if (respuestaAnulacion.RESULTADO_BAPI == true)
                                {
                                    response.MENSAJES[k].COMPLEMENTO = new JavaScriptSerializer().Serialize(respuestaAnulacion);
                                }
                                else
                                {
                                    anulapedido = false;
                                }

                            }
                        }

                    }
                    //ANULA PEDIDO
                    try
                    {
                        if (anulapedido)
                        {
                            response.MENSAJES[0].COMPLEMENTO = new JavaScriptSerializer().Serialize(Ejecuta_BAPI_PO_CHANGE(null, false, PEDIDO));
                        }
                        else
                        {
                            response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO SE ANULO, DEBIDO A UN PROBLEMA A ANULAR DOCUMENTOS RELACIONADOS, FAVOR ANULAR";
                        }
                    }
                    catch (Exception ex)
                    {
                        response.MENSAJES[0].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR. ERROR: " + ex.ToString();
                    }

                }
                catch
                {


                    //  response.MENSAJES[i].COMPLEMENTO = "PEDIDO :" + PEDIDO + "NO PUDO SER ANULADO, FAVOR ANULAR";
                }

                BAPI_TRANSACTION.Rollback(configSap);
                ORDEN_COGR = "";
                return response;

            }

            RfcSessionManager.EndContext(configSap);
            PEDIDO = "";
            ORDEN_COGR = "";

            return response;
        }

        public static object Ejecuta_BAPI_MIGO_541_REPROCESO(HttpRequest Request = null, bool EjecucionDirecta = true, string ObjetoEntrada = "", RfcDestination configSAP = null, RfcRepository SapRfcRepository = null, bool test = false)
        {
            String FECHA = "";
            JArray ListaMateriales = new JArray();

            dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);
            BAPI_GOODSMVT_CREATE sap = new BAPI_GOODSMVT_CREATE();
            FECHA = Objeto.PARAMETROS.FECHA;
            ListaMateriales = Objeto.PARAMETROS.MATERIALES;
            request_BAPI_GOODSMVT_CREATE imp = new request_BAPI_GOODSMVT_CREATE();
            imp.GOODSMVT_CODE = new BAPI_GOODSMVT_CREATE_GOODSMVT_CODE();
            imp.GOODSMVT_HEADER = new BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER();

            imp.GOODSMVT_CODE.GM_CODE = "04";


            imp.GOODSMVT_HEADER.PSTNG_DATE = FECHA;
            imp.GOODSMVT_HEADER.DOC_DATE = FECHA;
            imp.GOODSMVT_HEADER.HEADER_TXT = "";

            imp.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[ListaMateriales.Count];

            int i = 0;

            foreach (dynamic mat in ListaMateriales)
            {
                imp.GOODSMVT_ITEM[i] = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();
                imp.GOODSMVT_ITEM[i].MATERIAL = mat.MATERIAL;
                imp.GOODSMVT_ITEM[i].PLANT = mat.CENTRO;
                imp.GOODSMVT_ITEM[i].STGE_LOC = mat.ALMACEN;
                imp.GOODSMVT_ITEM[i].BATCH = mat.LOTE;
                imp.GOODSMVT_ITEM[i].MOVE_TYPE = "541";
                imp.GOODSMVT_ITEM[i].VENDOR = mat.PRODUCTOR;
                if (i == 2)
                {
                    imp.GOODSMVT_ITEM[i].SPEC_STOCK = "O";
                }
                imp.GOODSMVT_ITEM[i].ENTRY_QNT = Decimal.Parse(mat.CANTIDAD.ToString());
                imp.GOODSMVT_ITEM[i].ENTRY_UOM = mat.UNIDAD;
                imp.GOODSMVT_ITEM[i].MOVE_MAT = mat.MATERIAL;
                imp.GOODSMVT_ITEM[i].MOVE_PLANT = mat.CENTRO;
                imp.GOODSMVT_ITEM[i].MOVE_BATCH = mat.LOTE;
                i++;

            } 
            responce_BAPI_GOODSMVT_CREATE obj = new rfcBaika.responce_BAPI_GOODSMVT_CREATE();


            obj = sap.sapRun(imp);
            if (obj.MATERIALDOCUMENT != "")
            {
                obj.RESULTADO_BAPI = true;
                obj.DOCUMENTO = obj.MATERIALDOCUMENT;
            }
            else
                obj.RESULTADO_BAPI = false;

            return obj;
        }
        public static object Ejecuta_BAPI_MIGO_543_PROCESO(HttpRequest Request = null, bool EjecucionDirecta = true, string ObjetoEntrada = "", RfcDestination configSAP = null, RfcRepository SapRfcRepository = null, bool test = false)
        {
            String MOVIMIENTO = "";
            String FECHA = "";
            String PRODUCTOR = "";
            String CENTRO = "";
            String ALMACEN = "";
            String CAJAS = "";

            String TIPO_STOCK = "";
            bool CONTRAPEDIDO = false;
            bool CONTRAORDEN = false;
            string LOTE = "";

            JArray ListaMateriales = new JArray();


            dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);
            MOVIMIENTO = Objeto.PARAMETROS.MOVIMIENTO;


            FECHA = Objeto.PARAMETROS.FECHA;
            CAJAS = Objeto.PARAMETROS.CAJAS;
            ListaMateriales = Objeto.PARAMETROS.MATERIALES;
            CENTRO = Objeto.PARAMETROS.CENTRO;
            ALMACEN = Objeto.PARAMETROS.ALMACEN;
            CONTRAPEDIDO = Objeto.PARAMETROS.CONTRAPEDIDO;
            CONTRAORDEN = Objeto.PARAMETROS.CONTRAORDEN;
            LOTE = Objeto.PARAMETROS.LOTE;
            PRODUCTOR = Objeto.PARAMETROS.PRODUCTOR;

            TIPO_STOCK = Objeto.PARAMETROS.TIPO_STOCK;

            try
            {
                if (Objeto.PARAMETROS.PEDIDO != null)
                { PEDIDO = Objeto.PARAMETROS.PEDIDO; }
            }
            catch
            {


            }






            BAPI_GOODSMVT_CREATE sap = new BAPI_GOODSMVT_CREATE();

            request_BAPI_GOODSMVT_CREATE imp = new request_BAPI_GOODSMVT_CREATE();

            if (test)
                imp.TESTRUN = "X";

            if (MOVIMIENTO == "101")
            {

                char pad = '0';

                imp.GOODSMVT_CODE = new BAPI_GOODSMVT_CREATE_GOODSMVT_CODE();
                imp.GOODSMVT_HEADER = new BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER();

                imp.GOODSMVT_CODE.GM_CODE = "01";


                imp.GOODSMVT_HEADER.PSTNG_DATE = FECHA;
                imp.GOODSMVT_HEADER.DOC_DATE = FECHA;
                imp.GOODSMVT_HEADER.HEADER_TXT = CAJAS;




                imp.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[ListaMateriales.Count];

                int i = 0;

                foreach (dynamic mat in ListaMateriales)
                {
                    imp.GOODSMVT_ITEM[i] = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();

                    imp.GOODSMVT_ITEM[i].MOVE_TYPE = mat.MOVIMIENTO;



                    imp.GOODSMVT_ITEM[i].PROD_DATE = FECHA;
                    imp.GOODSMVT_ITEM[i].MATERIAL = mat.COD.ToString();//.PadLeft(18, pad);
                    imp.GOODSMVT_ITEM[i].PLANT = CENTRO;
                    imp.GOODSMVT_ITEM[i].BATCH = mat.LOTE;
                    imp.GOODSMVT_ITEM[i].ENTRY_QNT = decimal.Parse(mat.CANTIDAD.ToString());
                    imp.GOODSMVT_ITEM[i].ITEM_TEXT = mat.ITEM_TEXT;

                    try
                    {
                        if (mat.UNIDAD.ToString() == "")
                            imp.GOODSMVT_ITEM[i].ENTRY_UOM = "KG";
                        else
                            imp.GOODSMVT_ITEM[i].ENTRY_UOM = mat.UNIDAD.ToString();
                    }
                    catch
                    {
                        imp.GOODSMVT_ITEM[i].ENTRY_UOM = "KG";
                    }



                    imp.GOODSMVT_ITEM[i].STCK_TYPE = TIPO_STOCK;
                    imp.GOODSMVT_ITEM[i].BATCH = mat.LOTE;

                    if (mat.MOVIMIENTO == "543")
                    {
                        imp.GOODSMVT_ITEM[i].MVT_IND = "O";
                        imp.GOODSMVT_ITEM[i].PARENT_ID = 1;

                        //imp.GOODSMVT_ITEM[i].VENDOR = PRODUCTOR.PadLeft(10, pad);
                        imp.GOODSMVT_ITEM[i].ORDERID = ORDEN_COGR.PadLeft(12, pad); ;
                        imp.GOODSMVT_ITEM[i].ORDER_ITNO = 1;
                        imp.GOODSMVT_ITEM[i].PO_PR_QNT = decimal.Parse(mat.CANTIDAD.ToString());


                        if (CONTRAPEDIDO == true)
                        {

                            if (mat.PEDIDO == null)
                            {
                                imp.GOODSMVT_ITEM[i].PO_NUMBER = PEDIDO;
                            }
                            else
                            {
                                imp.GOODSMVT_ITEM[i].PO_NUMBER = mat.PEDIDO;
                            }

                            if (mat.POSICION == null)
                            {
                                imp.GOODSMVT_ITEM[i].PO_ITEM = 10;
                            }
                            else
                            {
                                imp.GOODSMVT_ITEM[i].PO_ITEM = mat.POSICION;
                            }
                        }
                    }
                    else
                    {
                        imp.GOODSMVT_ITEM[i].PO_PR_QNT = decimal.Parse(mat.CANTIDAD.ToString());
                        imp.GOODSMVT_ITEM[i].MVT_IND = "B";
                        //imp.GOODSMVT_ITEM[i].NO_MORE_GR = "X";


                        if (CONTRAPEDIDO == true)
                        {

                            if (mat.PEDIDO == null)
                            {
                                imp.GOODSMVT_ITEM[i].PO_NUMBER = PEDIDO;
                            }
                            else
                            {
                                imp.GOODSMVT_ITEM[i].PO_NUMBER = mat.PEDIDO;
                            }

                            if (mat.POSICION == null)
                            {
                                imp.GOODSMVT_ITEM[i].PO_ITEM = 10;
                            }
                            else
                            {
                                imp.GOODSMVT_ITEM[i].PO_ITEM = mat.POSICION;
                            }
                        }
                    }


                    if (CONTRAORDEN == true)
                    {
                        imp.GOODSMVT_ITEM[i].BATCH = mat.LOTE;
                        imp.GOODSMVT_ITEM[i].ORDERID = ORDEN_COGR.PadLeft(12, pad); ;
                        imp.GOODSMVT_ITEM[i].ORDER_ITNO = 1;
                        imp.GOODSMVT_ITEM[i].MVT_IND = "F";
                        imp.GOODSMVT_CODE.GM_CODE = "02";
                        imp.GOODSMVT_ITEM[i].STGE_LOC = ALMACEN;

                    }





                    i++;
                }


            }


            responce_BAPI_GOODSMVT_CREATE obj = new rfcBaika.responce_BAPI_GOODSMVT_CREATE();


            obj = sap.sapRun(imp, configSAP, SapRfcRepository);
            //obj = sap.sapRun(imp);


            if (test)
            {
                if (obj.RETURN.Length == 0)
                {
                    obj.RESULTADO_BAPI = true;
                }
                else
                    obj.RESULTADO_BAPI = false;


            }
            else
            {

                if (obj.MATERIALDOCUMENT != "")
                {
                    obj.RESULTADO_BAPI = true;
                    obj.DOCUMENTO = obj.MATERIALDOCUMENT;
                }
                else
                    obj.RESULTADO_BAPI = false;
            }

            return obj;
        }
        public static object Ejecuta_BAPI_ACTUALIZA_LOTE(HttpRequest Request = null, bool EjecucionDirecta = true, string ObjetoEntrada = "", RfcDestination configSAP = null, RfcRepository SapRfcRepository = null, bool test = false)
        {

            dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);
            JArray ListaCaracteristicas = new JArray();
            JArray ListaLotes = new JArray();
            JArray materiales = new JArray();

            ListaLotes = Objeto.PARAMETROS.LOTES;
            materiales = Objeto.PARAMETROS.MATERIALES;

            ListaCaracteristicas = Objeto.PARAMETROS.CARACTERISTICAS;

            ZMOV_40003 sap = new ZMOV_40003();

            request_ZMOV_40003 imp = new request_ZMOV_40003();

            try
            {
                dynamic Usuario = JsonConvert.DeserializeObject(Objeto.PARAMETROS.USUARIO.ToString());
                imp.USER = Usuario.USUARIO;
                imp.PASS = Usuario.PASS;
            }
            catch (Exception ex)
            {


            }


            imp.IT_CHARG = new ZMOV_40003_IT_CHARG[ListaLotes.Count];
            int j = 0;
            foreach (dynamic lote in ListaLotes)
            {
                imp.IT_CHARG[j] = new ZMOV_40003_IT_CHARG();
                imp.IT_CHARG[j].CHARG = lote.LOTE;
                //imp.IT_CHARG[j].MANTR = lote.MATNR;
                j++;
            }
            if (materiales != null)
            {
                imp.IR_MATNR = new ZMOV_40003_IR_MATNR[materiales.Count];
                int m = 0;
                foreach (dynamic lote in materiales)
                {
                    if (lote.MATERIAL != null)
                    {
                        imp.IR_MATNR[m] = new ZMOV_40003_IR_MATNR();
                        imp.IR_MATNR[m].SIGN = "I";
                        imp.IR_MATNR[m].OPTION = "EQ";
                        imp.IR_MATNR[m].LOW = lote.MATERIAL;
                    }
                    m++;
                }
            }
            imp.LT_CARACT = new ZMOV_40003_LT_CARACT[ListaCaracteristicas.Count];
            int i = 0;



            foreach (dynamic caract in ListaCaracteristicas)
            {
                imp.LT_CARACT[i] = new ZMOV_40003_LT_CARACT();
                imp.LT_CARACT[i].BATCH = caract.LOTE;
                imp.LT_CARACT[i].CHARACT = caract.CARACTERISTICA;
                imp.LT_CARACT[i].VALUE_CHAR = caract.VALOR;

                i++;
            }

            responce_ZMOV_40003 res = sap.sapRun(imp);
            Boolean errorCaracteristicas = true;
            foreach (ZMOV_40003_RETURN_MODCARACT item in res.RETURN_MODCARACT)
            {
                if (item.TYPE == "E")
                {
                    errorCaracteristicas = false;
                }
            }
            res.RESULTADO_BAPI = errorCaracteristicas;

            return res;

        }
        public static object Ejecuta_BAPI_PO_CHANGE(HttpRequest Request = null, bool EjecucionDirecta = true, string ObjetoEntrada = "", RfcDestination configSAP = null, RfcRepository SapRfcRepository = null, bool test = false)
        {
            String PEDIDO = "";

            if (EjecucionDirecta)
            {
                try
                {
                    PEDIDO = Request["PEDIDO"].ToString();
                }
                catch
                {

                }
            }

            else
            {
                PEDIDO = ObjetoEntrada;
            }

            BAPI_PO_CHANGE sap = new BAPI_PO_CHANGE();

            request_BAPI_PO_CHANGE imp = new request_BAPI_PO_CHANGE();

            imp.POHEADER = new rfcBaika.BAPI_PO_CHANGE_POHEADER();
            imp.PURCHASEORDER = PEDIDO;


            imp.POITEM = new BAPI_PO_CHANGE_POITEM[1];
            imp.POITEM[0] = new BAPI_PO_CHANGE_POITEM();

            imp.POITEM[0].PO_ITEM = 10;

            imp.POITEM[0].DELETE_IND = "X";


            imp.POITEMX = new BAPI_PO_CHANGE_POITEMX[1];
            imp.POITEMX[0] = new BAPI_PO_CHANGE_POITEMX();

            imp.POITEMX[0].PO_ITEM = 10;
            imp.POITEMX[0].PO_ITEMX = "X";
            imp.POITEMX[0].DELETE_IND = "X";




            responce_BAPI_PO_CHANGE obj = sap.sapRun(imp);

            obj.RESULTADO_BAPI = true;

            return obj;
        }
        public static object Ejecuta_BAPI_MIGO_541_2(HttpRequest Request = null, bool EjecucionDirecta = true, string ObjetoEntrada = "", RfcDestination configSAP = null, RfcRepository SapRfcRepository = null, bool test = false)
        {
            String MOVIMIENTO = "";
            String FECHA = "";
            String CENTRO = "";
            String ALMACEN = "";
            string LOTE = "";
            string PRODUCTOR;

            JArray ListaMateriales = new JArray();


            dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);
            MOVIMIENTO = Objeto.PARAMETROS.MOVIMIENTO;


            FECHA = Objeto.PARAMETROS.FECHA;
            ListaMateriales = Objeto.PARAMETROS.MATERIALES;
            CENTRO = Objeto.PARAMETROS.CENTRO;
            ALMACEN = Objeto.PARAMETROS.ALMACEN;
            PRODUCTOR = Objeto.PARAMETROS.PRODUCTOR;




            BAPI_GOODSMVT_CREATE sap = new BAPI_GOODSMVT_CREATE();

            request_BAPI_GOODSMVT_CREATE imp = new request_BAPI_GOODSMVT_CREATE();


            try
            {
                dynamic Usuario = JsonConvert.DeserializeObject(Objeto.PARAMETROS.USUARIO.ToString());
                imp.USER = Usuario.USUARIO;
                imp.PASS = Usuario.PASS;
            }
            catch (Exception ex)
            {


            }


            imp.GOODSMVT_CODE = new BAPI_GOODSMVT_CREATE_GOODSMVT_CODE();
            imp.GOODSMVT_HEADER = new BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER();

            imp.GOODSMVT_CODE.GM_CODE = "04";


            imp.GOODSMVT_HEADER.PSTNG_DATE = FECHA;
            imp.GOODSMVT_HEADER.DOC_DATE = FECHA;
            imp.GOODSMVT_HEADER.HEADER_TXT = Objeto.PARAMETROS.DATOSADICIONALES;
            imp.GOODSMVT_HEADER.REF_DOC_NO = Objeto.PARAMETROS.GUIA;

            string PREDIO = Objeto.PARAMETROS.PREDIO;

            //imp.EXTENSIONIN = new BAPI_GOODSMVT_CREATE_EXTENSIONIN[0];
            //try
            //{
            //    imp.EXTENSIONIN = new BAPI_GOODSMVT_CREATE_EXTENSIONIN[1];
            //    imp.EXTENSIONIN[0] = new BAPI_GOODSMVT_CREATE_EXTENSIONIN();
            //    imp.EXTENSIONIN[0].STRUCTURE = "BAPI_TE_XMKPF-ZPREDIO";
            //    imp.EXTENSIONIN[0].VALUEPART1 = PREDIO;

            //}
            //catch
            //{

            //}



            imp.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[ListaMateriales.Count];

            int i = 0;

            foreach (dynamic mat in ListaMateriales)
            {
                imp.GOODSMVT_ITEM[i] = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();

                imp.GOODSMVT_ITEM[i].MOVE_TYPE = MOVIMIENTO;
                imp.GOODSMVT_ITEM[i].MATERIAL = mat.COD.ToString();
                imp.GOODSMVT_ITEM[i].PLANT = CENTRO;
                if (mat.ALMACEN != null)
                {
                    imp.GOODSMVT_ITEM[i].STGE_LOC = mat.ALMACEN;
                }
                else
                {
                    imp.GOODSMVT_ITEM[i].STGE_LOC = ALMACEN;
                }
                imp.GOODSMVT_ITEM[i].ENTRY_QNT = decimal.Parse(mat.CANTIDAD.ToString());


                try
                {
                    if (mat.UNIDAD.ToString() == "")
                        imp.GOODSMVT_ITEM[i].ENTRY_UOM = "KG";
                    else
                        imp.GOODSMVT_ITEM[i].ENTRY_UOM = mat.UNIDAD.ToString();
                }
                catch
                {
                    imp.GOODSMVT_ITEM[i].ENTRY_UOM = "KG";
                }
                char pad = '0';
                int v;
                if (int.TryParse(mat.PRODUCTOR.ToString().Trim(), out v))
                {
                    PRODUCTOR = PRODUCTOR.PadLeft(10, pad);
                }
                imp.GOODSMVT_ITEM[i].VENDOR = mat.PRODUCTOR;

                try
                {
                    if (mat.LOTE != null)
                    {
                        imp.GOODSMVT_ITEM[i].BATCH = mat.LOTE;
                        imp.GOODSMVT_ITEM[i].MOVE_BATCH = mat.LOTE;
                    }
                }
                catch
                {
                }


                i++;
            }



            responce_BAPI_GOODSMVT_CREATE obj = new rfcBaika.responce_BAPI_GOODSMVT_CREATE();


            //obj = sap.sapRun(imp, configSAP, SapRfcRepository);
            obj = sap.sapRun(imp);
            Boolean valida = true;
            foreach (BAPI_GOODSMVT_CREATE_RETURN item in obj.RETURN)
            {
                if (item.TYPE == "E")
                {
                    valida = false;
                }
            }
            if (valida)
            {
                obj.RESULTADO_BAPI = true;
                obj.DOCUMENTO = obj.MATERIALDOCUMENT;
            }
            else
                obj.RESULTADO_BAPI = false;

            return obj;
        }
        public static object Ejecuta_BAPI_PO_CREATE1(HttpRequest Request = null, bool EjecucionDirecta = true, string ObjetoEntrada = "", RfcDestination configSAP = null, RfcRepository SapRfcRepository = null, bool test = false, string Componentes = null)
        {
            dynamic Usuario = null;
            string FECHA = "";
            string CENTRO = "";
            string ALMACEN = "";
            string SOCIEDAD = "";
            string CLASE_PEDIDO = "";
            string PRODUCTOR = "";
            string ORG_COMPRA = "";
            string GRUPO_COMPRA = "";
            string PALLET_COMPLETO = "";
            string ORDEN_COGR2 = "";
            bool agregaComponentes = false;


            bool SUBCONTRATACION = false;

            JArray ListaMateriales = new JArray();
            JArray ListaComponentes = new JArray();

            BAPI_PO_CREATE1 sap = new BAPI_PO_CREATE1();

            request_BAPI_PO_CREATE1 imp = new request_BAPI_PO_CREATE1();


            if (EjecucionDirecta)
            {

            }

            else
            {
                dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);

                FECHA = Objeto.PARAMETROS.FECHA;
                ListaMateriales = Objeto.PARAMETROS.MATERIALES;
                ListaComponentes = Objeto.PARAMETROS.COMPONENTES;

                if (ListaComponentes == null)
                {
                    ListaComponentes = new JArray();
                    agregaComponentes = true;
                }

                CENTRO = Objeto.PARAMETROS.CENTRO;
                //ALMACEN = Objeto.PARAMETROS.ALMACEN;
                ORDEN_COGR2 = Objeto.ORDEN_COGR;
                SOCIEDAD = Objeto.PARAMETROS.SOCIEDAD;
                CLASE_PEDIDO = Objeto.PARAMETROS.CLASE_PEDIDO;
                char pad = '0';
                int v;
                if (int.TryParse(Objeto.PARAMETROS.PRODUCTOR.ToString().Trim(), out v))
                {
                    PRODUCTOR = Objeto.PARAMETROS.PRODUCTOR.ToString().PadLeft(10, pad);
                }
                else
                {
                    PRODUCTOR = Objeto.PARAMETROS.PRODUCTOR.ToString();
                }
                ORG_COMPRA = Objeto.PARAMETROS.ORG_COMPRA;
                GRUPO_COMPRA = Objeto.PARAMETROS.GRUPO_COMPRA;
                try
                {
                    PALLET_COMPLETO = Objeto.PARAMETROS.PALLET_COMPLETO.ToString();
                }
                catch
                {

                }


                SUBCONTRATACION = Objeto.PARAMETROS.SUBCONTRATACION;
                try
                {
                    Usuario = JsonConvert.DeserializeObject(Objeto.PARAMETROS.USUARIO.ToString());
                    imp.USER = Usuario.USUARIO;
                    imp.PASS = Usuario.PASS;
                }
                catch (Exception ex)
                {


                }


            }







            imp.NO_PRICE_FROM_PO = "X";
            imp.POHEADER = new rfcBaika.BAPI_PO_CREATE1_POHEADER();
            imp.POHEADERX = new rfcBaika.BAPI_PO_CREATE1_POHEADERX();



            imp.POHEADER.COMP_CODE = SOCIEDAD;
            imp.POHEADER.DOC_TYPE = CLASE_PEDIDO;
            imp.POHEADER.VENDOR = PRODUCTOR;
            imp.POHEADER.PURCH_ORG = ORG_COMPRA;
            imp.POHEADER.PUR_GROUP = GRUPO_COMPRA;
            imp.POHEADER.DOC_DATE = FECHA;

            imp.POHEADERX.COMP_CODE = "X";
            imp.POHEADERX.DOC_TYPE = "X";
            imp.POHEADERX.VENDOR = "X";
            imp.POHEADERX.PURCH_ORG = "X";
            imp.POHEADERX.PUR_GROUP = "X";
            imp.POHEADERX.DOC_DATE = "X";



            imp.POITEM = new BAPI_PO_CREATE1_POITEM[ListaMateriales.Count];
            imp.POITEMX = new BAPI_PO_CREATE1_POITEMX[ListaMateriales.Count];


            imp.POACCOUNT = new rfcBaika.BAPI_PO_CREATE1_POACCOUNT[ListaMateriales.Count];
            imp.POACCOUNTX = new rfcBaika.BAPI_PO_CREATE1_POACCOUNTX[ListaMateriales.Count];

            responce_BAPI_PO_CREATE1 obj = new rfcBaika.responce_BAPI_PO_CREATE1();
            int i = 0;

            foreach (dynamic mat in ListaMateriales)
            {

                if (ORDEN_COGR2 == "" || ORDEN_COGR2 == null)
                {
                    Ejecuta_ZMOV_10019(mat.COD.ToString(), CENTRO);
                    ORDEN_COGR2 = ORDEN_COGR;
                }
                if (ORDEN_COGR == "")
                {
                    obj.RESULTADO_BAPI = false;
                    obj.RETURN = new rfcBaika.BAPI_PO_CREATE1_RETURN[1];
                    obj.RETURN[0] = new rfcBaika.BAPI_PO_CREATE1_RETURN();
                    obj.RETURN[0].MESSAGE = "PARA EL CENTRO " + CENTRO + " Y EL MATERIAL " + mat.COD.ToString() + "NO SE PUDO DETERMINAR ORDEN CO";

                }


                imp.POACCOUNT[i] = new rfcBaika.BAPI_PO_CREATE1_POACCOUNT();
                imp.POACCOUNTX[i] = new rfcBaika.BAPI_PO_CREATE1_POACCOUNTX();

                imp.POITEM[i] = new BAPI_PO_CREATE1_POITEM();
                imp.POITEMX[i] = new BAPI_PO_CREATE1_POITEMX();

                imp.POACCOUNT[i].QUANTITY = decimal.Parse(mat.CANTIDAD.ToString()); ;
                imp.POACCOUNT[i].ORDERID = ORDEN_COGR2;
                imp.POACCOUNT[i].PO_ITEM = 10 + i;

                imp.POACCOUNTX[i].QUANTITY = "X";
                imp.POACCOUNTX[i].ORDERID = "X";
                imp.POACCOUNTX[i].PO_ITEM = 10 + i;

                imp.POITEM[i].PO_ITEM = 10 + i;
                imp.POITEM[i].MATERIAL = mat.COD.ToString();//.PadLeft(18, '0');
                imp.POITEM[i].PLANT = CENTRO;
                //imp.POITEM[i].STGE_LOC = ALMACEN;
                //imp.POITEM[i].SUPP_VENDOR = PRODUCTOR;
                imp.POITEM[i].QUANTITY = decimal.Parse(mat.CANTIDAD.ToString());
                imp.POITEM[i].PO_UNIT = "CJ";
                imp.POITEM[i].FREE_ITEM = "X";
                imp.POITEM[i].ACCTASSCAT = "F";


                imp.POITEMX[i].PO_ITEM = 10 + i;
                imp.POITEMX[i].PLANT = "X";
                imp.POITEMX[i].MATERIAL = "X";
                //imp.POITEMX[i].STGE_LOC = "X";
                //imp.POITEMX[i].SUPP_VENDOR = "X";
                imp.POITEMX[i].QUANTITY = "X";
                imp.POITEMX[i].PO_UNIT = "X";
                imp.POITEMX[i].FREE_ITEM = "X";
                imp.POITEMX[i].ACCTASSCAT = "X";

                if (SUBCONTRATACION)
                {
                    imp.POITEM[i].ITEM_CAT = "L";
                    imp.POITEMX[i].ITEM_CAT = "X";

                }

                try
                {
                    /*if (PALLET_COMPLETO== "Z1")
                    {*/
                    /*ZMOV_30007 sap2 = new ZMOV_30007();

                    request_ZMOV_30007 imp2 = new request_ZMOV_30007();
                    try
                    {
                        imp2.USER = Usuario.USUARIO;
                        imp2.PASS = Usuario.PASS;
                    }
                    catch (Exception ex)
                    {


                    }
                    imp2.I_MATERIAL = mat.COD.ToString();
                    if (mat.CALIBRE != null)
                    {
                        imp2.I_CALIBRE = mat.CALIBRE;
                    }
                    if (mat.VARIEDAD != null)
                    {
                        imp2.I_VARIEDAD = mat.VARIEDAD;
                    }

                    //responce_ZMOV_30007 resp = sap2.sapRun(imp2);
                    String palletCompelto = "NO";
                    if (PALLET_COMPLETO == "Z1")
                    {
                        palletCompelto = "SI";
                    }
                    */

                    /*foreach (ZMOV_30007_E_OUT_PLUBAND item in resp.E_OUT_PLUBAND)
                    {
                        if (item.ZPALLET == palletCompelto)
                        {
                            dynamic Mat = new JObject();


                            try
                            {
                                int temp = int.Parse(item.ZCOMP);
                                item.ZCOMP = item.ZCOMP.PadLeft(18, '0');
                            }
                            catch
                            { }
                            Decimal cantMat = Decimal.Parse(mat.CANTIDAD.ToString());
                            Decimal total = Math.Round(cantMat * item.ZCANTID, 2);
                            Mat.COD = item.ZCOMP;
                            Mat.CANTIDAD = total;
                            //Mat.MOVIMIENTO = "543";
                            Mat.UNIDAD = item.ZUMB2;

                            ListaComponentes.Add(Mat);
                        }
                        else
                        {

                        }

                    }*/

                    //}
                }
                catch (Exception exx)
                {


                }



                i++;
            }

            if (test)
                imp.TESTRUN = "X";



            //responce_BAPI_PO_CREATE1 obj = sap.sapRun(imp, configSAP,SapRfcRepository);
            obj = sap.sapRun(imp);
            if (test)
            {
                if (obj.RETURN.Length <= 2)
                {
                    obj.RESULTADO_BAPI = true;
                }
                else
                    obj.RESULTADO_BAPI = false;


            }
            else
            {

                if (obj.EXPPURCHASEORDER != "")
                {
                    try
                    {
                        //modifico pedido para hacerlo compatible con la lista de materiales de reembalaje

                        if (ListaComponentes.Count > 0)
                            Ejecuta_BAPI_PO_CHANGE_COMPONENTES(ListaComponentes, obj.EXPPURCHASEORDER, agregaComponentes);



                    }
                    catch
                    {


                    }

                    obj.RESULTADO_BAPI = true;

                    PEDIDO = obj.EXPPURCHASEORDER;

                }
                else
                    obj.RESULTADO_BAPI = false;
            }




            return obj;
        }
        public static object Ejecuta_ZMOV_10019(string material, string centro)
        {

            ORDEN_COGR = "";
            ZMOV_10019 sap = new ZMOV_10019();

            request_ZMOV_10019 imp = new request_ZMOV_10019();


            imp.I_MATNR = material;
            imp.I_WERKS = centro;



            responce_ZMOV_10019 obj = sap.sapRun(imp);


            if (obj.ET_ORDERS.Length > 0)
            {
                ORDEN_COGR = obj.ET_ORDERS[0].AUFNR;

            }
            //else
            //obj = sap.sapRun(imp, configSAP);

            //obj.RESULTADO_BAPI = true;



            return obj;
        }
        public static object Ejecuta_BAPI_PO_CHANGE_COMPONENTES(JArray componentes, string pedido, bool agregaComponentes = false)
        {
            String PEDIDO = "";

            PEDIDO = pedido;

            BAPI_PO_CHANGE sap = new BAPI_PO_CHANGE();

            request_BAPI_PO_CHANGE imp = new request_BAPI_PO_CHANGE();

            //imp.POHEADER = new rfcBaika.BAPI_PO_CHANGE_POHEADER();
            imp.PURCHASEORDER = PEDIDO;


            imp.POCOMPONENTS = new BAPI_PO_CHANGE_POCOMPONENTS[componentes.Count];
            imp.POCOMPONENTSX = new BAPI_PO_CHANGE_POCOMPONENTSX[componentes.Count];



            imp.POITEM = new BAPI_PO_CHANGE_POITEM[1];
            imp.POITEM[0] = new BAPI_PO_CHANGE_POITEM();

            imp.POITEM[0].PO_ITEM = 10;

            imp.POITEMX = new BAPI_PO_CHANGE_POITEMX[1];
            imp.POITEMX[0] = new BAPI_PO_CHANGE_POITEMX();

            imp.POITEMX[0].PO_ITEM = 10;
            //imp.POITEMX[0].PO_ITEMX = "X";
            //imp.POITEMX[0].DELETE_IND = "X";
            string change_id = "U";
            if (agregaComponentes)
            {
                change_id = "I";
            }


            int i = 0;
            int j = 1;
            foreach (dynamic mat in componentes)
            {


                imp.POCOMPONENTS[i] = new rfcBaika.BAPI_PO_CHANGE_POCOMPONENTS();
                imp.POCOMPONENTSX[i] = new rfcBaika.BAPI_PO_CHANGE_POCOMPONENTSX();

                imp.POCOMPONENTS[i].PO_ITEM = 10;
                imp.POCOMPONENTSX[i].PO_ITEM = 10;
                imp.POCOMPONENTSX[i].PO_ITEMX = "X";

                imp.POCOMPONENTS[i].SCHED_LINE = 1;
                imp.POCOMPONENTSX[i].SCHED_LINE = 1;
                imp.POCOMPONENTSX[i].SCHED_LINEX = "X";


                imp.POCOMPONENTS[i].ITEM_NO = int.Parse(j.ToString() + "0");
                imp.POCOMPONENTSX[i].ITEM_NO = int.Parse(j.ToString() + "0");
                imp.POCOMPONENTSX[i].ITEM_NOX = "X";

                imp.POCOMPONENTS[i].MATERIAL = mat.COD.ToString();
                imp.POCOMPONENTSX[i].MATERIAL = "X";

                imp.POCOMPONENTS[i].ENTRY_QUANTITY = decimal.Parse(mat.CANTIDAD.ToString());
                imp.POCOMPONENTSX[i].ENTRY_QUANTITY = "X";

                imp.POCOMPONENTS[i].ENTRY_UOM = mat.UNIDAD.ToString();
                imp.POCOMPONENTSX[i].ENTRY_UOM = "X";


                imp.POCOMPONENTS[i].CHANGE_ID = change_id;
                imp.POCOMPONENTSX[i].CHANGE_ID = "X";

                imp.POCOMPONENTS[i].ITEM_CAT = "L";
                imp.POCOMPONENTSX[i].ITEM_CAT = "X";

                change_id = "I";


                i++;
                j++;

            }


            responce_BAPI_PO_CHANGE obj = sap.sapRun(imp);

            obj.RESULTADO_BAPI = true;

            return obj;
        }
        public static responce_BAPI_GOODSMVT_CREATE Ejecuta_BAPI_MIGO_101_PROCESO(HttpRequest Request = null, bool EjecucionDirecta = true, string ObjetoEntrada = "", RfcDestination configSAP = null, RfcRepository SapRfcRepository = null, bool test = false)
        {
            String MOVIMIENTO = "";
            String FECHA = "";
            String PRODUCTOR = "";
            String CENTRO = "";
            String ALMACEN = "";

            String TIPO_STOCK = "";
            bool CONTRAPEDIDO = false;
            bool CONTRAORDEN = false;
            string LOTE = "";

            JArray ListaMateriales = new JArray();


            dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);
            MOVIMIENTO = Objeto.PARAMETROS.MOVIMIENTO;


            FECHA = Objeto.PARAMETROS.FECHA;
            ListaMateriales = Objeto.PARAMETROS.MATERIALES;
            CENTRO = Objeto.PARAMETROS.CENTRO;
            ALMACEN = Objeto.PARAMETROS.ALMACEN;
            CONTRAPEDIDO = Objeto.PARAMETROS.CONTRAPEDIDO;
            CONTRAORDEN = Objeto.PARAMETROS.CONTRAORDEN;
            LOTE = Objeto.PARAMETROS.LOTE;
            PRODUCTOR = Objeto.PARAMETROS.PRODUCTOR;

            TIPO_STOCK = Objeto.PARAMETROS.TIPO_STOCK;

            try
            {
                if (Objeto.PARAMETROS.PEDIDO != null)
                { PEDIDO = Objeto.PARAMETROS.PEDIDO; }
            }
            catch
            {


            }






            BAPI_GOODSMVT_CREATE sap = new BAPI_GOODSMVT_CREATE();

            request_BAPI_GOODSMVT_CREATE imp = new request_BAPI_GOODSMVT_CREATE();
            try
            {
                dynamic Usuario = JsonConvert.DeserializeObject(Objeto.PARAMETROS.USUARIO.ToString());
                imp.USER = Usuario.USUARIO;
                imp.PASS = Usuario.PASS;
            }
            catch (Exception ex)
            {


            }
            if (test)
                imp.TESTRUN = "X";

            if (MOVIMIENTO == "101")
            {

                char pad = '0';

                imp.GOODSMVT_CODE = new BAPI_GOODSMVT_CREATE_GOODSMVT_CODE();
                imp.GOODSMVT_HEADER = new BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER();

                imp.GOODSMVT_CODE.GM_CODE = "01";


                imp.GOODSMVT_HEADER.PSTNG_DATE = FECHA;
                imp.GOODSMVT_HEADER.DOC_DATE = FECHA;




                imp.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[ListaMateriales.Count];

                int i = 0;

                foreach (dynamic mat in ListaMateriales)
                {
                    imp.GOODSMVT_ITEM[i] = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();

                    imp.GOODSMVT_ITEM[i].MOVE_TYPE = mat.MOVIMIENTO;




                    imp.GOODSMVT_ITEM[i].MATERIAL = mat.COD.ToString();//.PadLeft(18, pad);
                    imp.GOODSMVT_ITEM[i].PLANT = CENTRO;
                    //imp.GOODSMVT_ITEM[i].STGE_LOC = ALMACEN;
                    imp.GOODSMVT_ITEM[i].ENTRY_QNT = decimal.Parse(mat.CANTIDAD.ToString());
                    imp.GOODSMVT_ITEM[i].ENTRY_UOM = mat.UNIDAD;

                    imp.GOODSMVT_ITEM[i].STCK_TYPE = TIPO_STOCK;


                    if (mat.MOVIMIENTO == "543")
                    {
                        imp.GOODSMVT_ITEM[i].MVT_IND = "O";
                        imp.GOODSMVT_ITEM[i].PARENT_ID = 1;
                        imp.GOODSMVT_ITEM[i].BATCH = mat.LOTE;
                        //imp.GOODSMVT_ITEM[i].VENDOR = PRODUCTOR.PadLeft(10, pad);
                        imp.GOODSMVT_ITEM[i].ORDERID = ORDEN_COGR.PadLeft(12, pad); ;
                        imp.GOODSMVT_ITEM[i].ORDER_ITNO = 1;
                    }
                    else
                    {
                        imp.GOODSMVT_ITEM[i].PO_PR_QNT = decimal.Parse(mat.CANTIDAD.ToString());
                        imp.GOODSMVT_ITEM[i].MVT_IND = "B";
                        //imp.GOODSMVT_ITEM[i].NO_MORE_GR = "X";


                        if (CONTRAPEDIDO == true)
                        {

                            if (mat.PEDIDO == null)
                            {
                                imp.GOODSMVT_ITEM[i].PO_NUMBER = PEDIDO;
                            }
                            else
                            {
                                imp.GOODSMVT_ITEM[i].PO_NUMBER = mat.PEDIDO;
                            }

                            if (mat.POSICION == null)
                            {
                                imp.GOODSMVT_ITEM[i].PO_ITEM = 10;
                            }
                            else
                            {
                                imp.GOODSMVT_ITEM[i].PO_ITEM = mat.POSICION;
                            }





                        }
                    }


                    if (CONTRAORDEN == true)
                    {
                        imp.GOODSMVT_ITEM[i].BATCH = mat.LOTE;
                        imp.GOODSMVT_ITEM[i].ORDERID = ORDEN_COGR.PadLeft(12, pad); ;
                        imp.GOODSMVT_ITEM[i].ORDER_ITNO = 1;
                        imp.GOODSMVT_ITEM[i].MVT_IND = "F";
                        imp.GOODSMVT_CODE.GM_CODE = "02";
                        imp.GOODSMVT_ITEM[i].STGE_LOC = ALMACEN;

                    }

                    i++;
                }


            }


            responce_BAPI_GOODSMVT_CREATE obj = new rfcBaika.responce_BAPI_GOODSMVT_CREATE();


            //obj = sap.sapRun(imp, configSAP, SapRfcRepository);
            obj = sap.sapRun(imp);


            if (test)
            {
                if (obj.RETURN.Length == 0)
                {
                    obj.RESULTADO_BAPI = true;
                }
                else
                    obj.RESULTADO_BAPI = false;


            }
            else
            {

                if (obj.MATERIALDOCUMENT != "")
                {
                    obj.RESULTADO_BAPI = true;
                    obj.DOCUMENTO = obj.MATERIALDOCUMENT;

                    BAPI_GOODSMVT_GETDETAIL sap2 = new BAPI_GOODSMVT_GETDETAIL();
                    request_BAPI_GOODSMVT_GETDETAIL imp2 = new request_BAPI_GOODSMVT_GETDETAIL();
                    responce_BAPI_GOODSMVT_GETDETAIL obj2 = null;

                    imp2.MATERIALDOCUMENT = obj.DOCUMENTO;
                    imp2.MATDOCUMENTYEAR = obj.MATDOCUMENTYEAR;
                    obj2 = sap2.sapRun(imp2);
                    obj.ITEMS_LOTE = obj2;
                    var i = 0;
                    Ejecuta_BAPI_ACTUALIZA_LOTE_MAT(obj2, Objeto);
                }
                else
                    obj.RESULTADO_BAPI = false;
            }

            return obj;
        }
        public static object Ejecuta_BAPI_ACTUALIZA_LOTE_MAT(responce_BAPI_GOODSMVT_GETDETAIL obj2, dynamic Objeto)
        {

            //dynamic Objeto = JsonConvert.DeserializeObject(ObjetoEntrada);
            JArray ListaCaracteristicas = new JArray();
            JArray ListaLotes = new JArray();
            JArray materiales = new JArray();

            ListaLotes = Objeto.PARAMETROS.LOTES;
            ListaCaracteristicas = Objeto.PARAMETROS.CARACT_LOTE;

            ZMOV_40003 sap = new ZMOV_40003();

            request_ZMOV_40003 imp = new request_ZMOV_40003();

            /*try
            {
                dynamic Usuario = JsonConvert.DeserializeObject(Objeto.PARAMETROS.USUARIO.ToString());
                imp.USER = Usuario.USUARIO;
                imp.PASS = Usuario.PASS;
            }
            catch (Exception ex)
            {


            }*/


            imp.IT_CHARG = new ZMOV_40003_IT_CHARG[obj2.GOODSMVT_ITEMS.Length];
            int j = 0;
            foreach (dynamic lote in obj2.GOODSMVT_ITEMS)
            {
                imp.IT_CHARG[j] = new ZMOV_40003_IT_CHARG();
                imp.IT_CHARG[j].CHARG = lote.BATCH;
                //imp.IT_CHARG[j].MANTR = lote.MATNR;
                j++;
            }
            if (materiales != null)
            {
                imp.IR_MATNR = new ZMOV_40003_IR_MATNR[obj2.GOODSMVT_ITEMS.Length];
                int m = 0;
                foreach (dynamic lote in obj2.GOODSMVT_ITEMS)
                {
                    if (lote.MATERIAL != null)
                    {
                        imp.IR_MATNR[m] = new ZMOV_40003_IR_MATNR();
                        imp.IR_MATNR[m].SIGN = "I";
                        imp.IR_MATNR[m].OPTION = "EQ";
                        imp.IR_MATNR[m].LOW = lote.MATERIAL;
                    }
                    m++;
                }
            }
            imp.LT_CARACT = new ZMOV_40003_LT_CARACT[ListaCaracteristicas.Count];
            int i = 0;
            int x = 0;
            int caracteristicasPorLote = ListaCaracteristicas.Count / obj2.GOODSMVT_ITEMS.Length;
            foreach (dynamic caract in ListaCaracteristicas)
            {
                imp.LT_CARACT[i] = new ZMOV_40003_LT_CARACT();
                imp.LT_CARACT[i].BATCH = obj2.GOODSMVT_ITEMS[x].BATCH;
                imp.LT_CARACT[i].CHARACT = caract.CARACTERISTICA;
                imp.LT_CARACT[i].VALUE_CHAR = caract.VALOR;
                i++;
            }

            responce_ZMOV_40003 res = sap.sapRun(imp);

            res.RESULTADO_BAPI = true;

            return res;

        }
        public static object Ejecuta_BAPI_MIGO_CANCEL(string documentoMaterial)
        {





            BAPI_GOODSMVT_CANCEL sap = new BAPI_GOODSMVT_CANCEL();

            request_BAPI_GOODSMVT_CANCEL imp = new request_BAPI_GOODSMVT_CANCEL();


            imp.DOCUMENTHEADER_TEXT = "ANULA MOVILIDAD";
            imp.MATERIALDOCUMENT = documentoMaterial;
            imp.MATDOCUMENTYEAR = DateTime.Now.Year;




            responce_BAPI_GOODSMVT_CANCEL obj = new rfcBaika.responce_BAPI_GOODSMVT_CANCEL();


            //obj = sap.sapRun(imp, configSAP, SapRfcRepository);
            obj = sap.sapRun(imp);


            if (obj.HEADRET.MATDOC_ITEM != "")
            {
                obj.RESULTADO_BAPI = true;
                obj.DOCUMENTO = obj.HEADRET.MATDOC_ITEM.ToString();
            }
            else
                obj.RESULTADO_BAPI = false;

            return obj;
        }
        public class RESPUESTA
        {
            public bool RESULTADO;
            //public string MOVIMIENTO;
            public RESPUESTAS[] MENSAJES;
        }
        public class RESPUESTAS
        {
            public bool RESULTADO;
            public String MENSAJES;
            public String DOCUMENTO;
            public String EXCEPCION;
            public String COMPLEMENTO;
            public String BAPI;
        }
        public class request_ZMOV_30007
        {
            public String I_CALIBRE;
            public String I_MATERIAL;
            public String I_VARIEDAD;
            public String USER;
            public String PASS;
        }
        public class responce_ZMOV_30007
        {
            public ZMOV_30007_E_OUT_PLUBAND[] E_OUT_PLUBAND;
        }
        public class ZMOV_30007_E_OUT_PLUBAND
        {
            public String ZMATERIAL;
            public String ZVARIEDAD;
            public String ZCALIBRE;
            public String ZCOMP;
            public Decimal ZCBASE;
            public String ZUMB;
            public Decimal ZCANTID;
            public String ZUMB2;
            public String ZPALLET;
        }
    }
}