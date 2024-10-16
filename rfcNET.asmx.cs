using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Text;

namespace rfcBaika
{
    /// <summary>
    /// Descripción breve de rfcNET
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class rfcNET : System.Web.Services.WebService
    {
        [WebMethod]
        public responce_ZMOV_QUERY_HU_ALMACEN ZMOV_QUERY_HU_ALMACEN(request_ZMOV_QUERY_HU_ALMACEN valor)
        {

            ZMOV_QUERY_HU_ALMACEN sap = new ZMOV_QUERY_HU_ALMACEN();


            responce_ZMOV_QUERY_HU_ALMACEN obj = sap.sapRun(valor);


            return obj;
        }
        [WebMethod]
        public responce_ZMOV_QUERY_HU_DATOADICIONAL ZMOV_QUERY_HU_DATOADICIONAL(request_ZMOV_QUERY_HU_DATOADICIONAL valor)
        {

            ZMOV_QUERY_HU_DATOADICIONAL sap = new ZMOV_QUERY_HU_DATOADICIONAL();


            responce_ZMOV_QUERY_HU_DATOADICIONAL obj = sap.sapRun(valor);


            return obj;
        }

        [WebMethod]
        public responce_ZCALIDAD_CARACT_LOTES ZCALIDAD_CARACT_LOTES(request_ZCALIDAD_CARACT_LOTES valor)
        {
            
            ZCALIDAD_CARACT_LOTES sap = new ZCALIDAD_CARACT_LOTES();
            

            responce_ZCALIDAD_CARACT_LOTES obj = sap.sapRun(valor);


            return obj;
        }

        [WebMethod]
        public responce_ZMOV_UPDATE_HU_ZFIELDS ZMOV_UPDATE_HU_ZFIELDS(request_ZMOV_UPDATE_HU_ZFIELDS valor)
        {

            ZMOV_UPDATE_HU_ZFIELDS sap = new ZMOV_UPDATE_HU_ZFIELDS();


            responce_ZMOV_UPDATE_HU_ZFIELDS obj = sap.sapRun(valor);


            return obj;
        }

        public responce_ZMOV_UPDATE_HU_HEADER_N ZMOV_UPDATE_HU_HEADER_ESTADO(string tipo, string[] pallet, string valor)
        {



            ZMOV_UPDATE_HU_HEADER_N sap = new ZMOV_UPDATE_HU_HEADER_N();
            request_ZMOV_UPDATE_HU_HEADER_N imp = new request_ZMOV_UPDATE_HU_HEADER_N();

            imp.HUCHANGED = new ZMOV_UPDATE_HU_HEADER_N_HUCHANGED();

            if (tipo == "SAG")
            {
                imp.HUCHANGED.EXT_ID_HU_2 = valor;
            }

            imp.IT_HU = new ZMOV_UPDATE_HU_HEADER_N_IT_HU[pallet.Length];

            for (int i = 0; i < pallet.Length; i++)
            {
                imp.IT_HU[i] = new ZMOV_UPDATE_HU_HEADER_N_IT_HU();
                imp.IT_HU[i].HU_EXID = pallet[i];
            }


            responce_ZMOV_UPDATE_HU_HEADER_N obj = sap.sapRun(imp);



            return obj;
        }

       
       

        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_GRANEL ZMOV_CREATE_RECEP_GRANEL(request_ZMOV_CREATE_RECEP_GRANEL datos)
        {
            ZMOV_CREATE_RECEP_GRANEL sap = new ZMOV_CREATE_RECEP_GRANEL();
            responce_ZMOV_CREATE_RECEP_GRANEL respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_GRANEL(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_GRANEL(respuesta);
            o.insert("ZMOV_CREATE_RECEP_GRANEL", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_UPDATE_CRT_CALIDAD ZMOV_UPDATE_CRT_CALIDAD(request_ZMOV_UPDATE_CRT_CALIDAD datos)
        {
            ZMOV_UPDATE_CRT_CALIDAD sap = new ZMOV_UPDATE_CRT_CALIDAD();
            responce_ZMOV_UPDATE_CRT_CALIDAD respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_UPDATE_CRT_CALIDAD(datos);
            XmlDocument res = o.responce_ZMOV_UPDATE_CRT_CALIDAD(respuesta);
            o.insert("ZMOV_UPDATE_CRT_CALIDAD", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

        [WebMethod]
        public responce_ZMOV_CREATE_AGRUPALOTE ZMOV_CREATE_AGRUPALOTE(request_ZMOV_CREATE_AGRUPALOTE datos)
        {
            ZMOV_CREATE_AGRUPALOTE sap = new ZMOV_CREATE_AGRUPALOTE();
            responce_ZMOV_CREATE_AGRUPALOTE respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_AGRUPALOTE(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_AGRUPALOTE(respuesta);
            o.insert("ZMOV_CREATE_AGRUPALOTE", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_GR_FRESCO ZMOV_CREATE_RECEP_GR_FRESCO(request_ZMOV_CREATE_RECEP_GR_FRESCO datos)
        {
            ZMOV_CREATE_RECEP_GR_FRESCO sap = new ZMOV_CREATE_RECEP_GR_FRESCO();
            responce_ZMOV_CREATE_RECEP_GR_FRESCO respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_GR_FRESCO(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_GR_FRESCO(respuesta);
            o.insert("ZMOV_CREATE_RECEP_GR_FRESCO", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        //ZMOV_20031
        [WebMethod]
        public responce_ZMOV_20031 ZMOV_20031(request_ZMOV_20031 datos)
        {
            ZMOV_20031 sap = new ZMOV_20031();
            responce_ZMOV_20031 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_20031(datos);
            XmlDocument res = o.responce_ZMOV_20031(respuesta);
            o.insert("ZMOV_20031", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

        //ZMOV_20036
        [WebMethod]
        public responce_ZMOV_20036 ZMOV_20036(request_ZMOV_20036 datos)
        {
            ZMOV_20036 sap = new ZMOV_20036();
            responce_ZMOV_20036 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_20036(datos);
            XmlDocument res = o.responce_ZMOV_20036(respuesta);
            o.insert("ZMOV_20036", imp.InnerXml, res.InnerXml);
            return respuesta;
        }



        //ZMOV_20031_SERVICE
        [WebMethod]
        public responce_ZMOV_20031 ZMOV_20031_SERVICE(request_ZMOV_20031 datos)
        {
            ZMOV_20031 sap = new ZMOV_20031();
            BAPI_GOODSMVT_CREATE sap2 = new BAPI_GOODSMVT_CREATE();

            request_BAPI_GOODSMVT_CREATE mov501 = new request_BAPI_GOODSMVT_CREATE();
            mov501.GOODSMVT_HEADER = new BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER();
            mov501.GOODSMVT_HEADER.PSTNG_DATE = datos.HEADER.BUDAT;
            mov501.GOODSMVT_HEADER.DOC_DATE = datos.HEADER.BUDAT;
            mov501.GOODSMVT_HEADER.REF_DOC_NO = datos.HEADER.XBLNR;
            mov501.GOODSMVT_HEADER.REF_DOC_NO_LONG = datos.HEADER.XBLNR;
            mov501.GOODSMVT_CODE = new BAPI_GOODSMVT_CREATE_GOODSMVT_CODE();
            mov501.GOODSMVT_CODE.GM_CODE="01";

            mov501.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[datos.LT_ITEMS.Length];
            int x = 0;
            foreach (ZMOV_20031_LT_ITEMS item in datos.LT_ITEMS)
            {
                mov501.GOODSMVT_ITEM[x] = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();
                mov501.GOODSMVT_ITEM[x].BATCH = item.BATCH;
                mov501.GOODSMVT_ITEM[x].MATERIAL = item.MATERIAL;
                mov501.GOODSMVT_ITEM[x].PLANT = item.PLANT;
                mov501.GOODSMVT_ITEM[x].STGE_LOC = item.STGE_LOC;
                mov501.GOODSMVT_ITEM[x].MOVE_TYPE = "501";
                mov501.GOODSMVT_ITEM[x].PROD_DATE = datos.HEADER.BUDAT;
                mov501.GOODSMVT_ITEM[x].VENDOR = datos.HEADER.LIFNR;
                mov501.GOODSMVT_ITEM[x].ENTRY_QNT = item.QUANTITY;
                mov501.GOODSMVT_ITEM[x].ENTRY_UOM = item.PO_UNIT;
                //mov501.GOODSMVT_ITEM[x].EXPIRYDATE = datos.HEADER.BUDAT;
                x++;
            }

            responce_BAPI_GOODSMVT_CREATE res2 = sap2.sapRun(mov501);

            //responce_ZMOV_20031 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_20031(datos);
            responce_ZMOV_20031 respuesta = new responce_ZMOV_20031();
            respuesta.LOG = new ZMOV_20031_LOG[res2.RETURN.Length];
            int z = 0;
            foreach (BAPI_GOODSMVT_CREATE_RETURN item in res2.RETURN)
            {
                respuesta.LOG[0] = new ZMOV_20031_LOG();
                respuesta.LOG[0].MESSAGE = res2.RETURN[z].MESSAGE;
                z++;
            }
            respuesta.E_MATERIALDOCUMENT = res2.MATERIALDOCUMENT;
            if (respuesta.E_MATERIALDOCUMENT != "")
            {
                ZMOV_40003 sap3 = new ZMOV_40003();
                request_ZMOV_40003 imp3 = new request_ZMOV_40003();
                ArrayList charg = new ArrayList();
                ArrayList mat = new ArrayList();
                foreach (ZMOV_20031_LT_CARACT lote in datos.LT_CARACT)
                {
                    if (!charg.Contains(lote.BATCH))
                    {
                        charg.Add(lote.BATCH);
                    }
                    if (!mat.Contains(lote.MATERIAL))
                    {
                        mat.Add(lote.MATERIAL);
                    }
                }
                imp3.IT_CHARG = new ZMOV_40003_IT_CHARG[charg.Count];
                imp3.IR_MATNR = new ZMOV_40003_IR_MATNR[mat.Count];
                imp3.LT_CARACT = new ZMOV_40003_LT_CARACT[datos.LT_CARACT.Length];
                int j = 0;
                int a = 0;
                int k = 0;
                mat = new ArrayList();
                charg = new ArrayList();
                foreach (ZMOV_20031_LT_CARACT lote in datos.LT_CARACT)
                {
                    if (!charg.Contains(lote.BATCH))
                    {
                        imp3.IT_CHARG[j] = new ZMOV_40003_IT_CHARG();
                        imp3.IT_CHARG[j].CHARG = lote.BATCH;
                        charg.Add(lote.BATCH);
                        j++;
                    }
                    if (!mat.Contains(lote.MATERIAL))
                    {
                        imp3.IR_MATNR[a] = new ZMOV_40003_IR_MATNR();
                        imp3.IR_MATNR[a].SIGN = "I";
                        imp3.IR_MATNR[a].OPTION = "EQ";
                        imp3.IR_MATNR[a].LOW = lote.MATERIAL;
                        mat.Add(lote.MATERIAL);
                        a++;
                    }
                    imp3.LT_CARACT[k] = new ZMOV_40003_LT_CARACT();
                    imp3.LT_CARACT[k].BATCH = lote.BATCH;
                    imp3.LT_CARACT[k].CHARACT = lote.CHARACT;
                    imp3.LT_CARACT[k].VALUE_CHAR = lote.VALUE_CHAR;
                    k++;
                }
                responce_ZMOV_40003 res3 = sap3.sapRun(imp3);
                ZMOV_CREATE_HU sap4 = new ZMOV_CREATE_HU();

                request_ZMOV_CREATE_HU imp4 = new request_ZMOV_CREATE_HU();
                imp4.HEADER_HU = new ZMOV_CREATE_HU_HEADER_HU();

                imp4.HEADER_HU.PACK_MAT = datos.HEADER_HU.PACK_MAT;
                imp4.HEADER_HU.HU_GRP4 = datos.HEADER_HU.HU_GRP4;
                imp4.HEADER_HU.LGORT_DS = datos.HEADER_HU.LGORT_DS;
                imp4.HEADER_HU.HU_EXID = datos.HEADER_HU.HU_EXID;
                imp4.ITEM_HU = new ZMOV_CREATE_HU_ITEM_HU[datos.LT_ITEMS.Length];
                x = 0;
                foreach (ZMOV_20031_LT_ITEMS item in datos.LT_ITEMS)
                {
                    imp4.ITEM_HU[x] = new ZMOV_CREATE_HU_ITEM_HU();
                    imp4.ITEM_HU[x].HU_ITEM_TYPE = "1";
                    imp4.ITEM_HU[x].PACK_QTY = item.QUANTITY;
                    imp4.ITEM_HU[x].BASE_UNIT_QTY = item.PO_UNIT;
                    imp4.ITEM_HU[x].MATERIAL = item.MATERIAL;
                    imp4.ITEM_HU[x].BATCH = item.BATCH;
                    imp4.ITEM_HU[x].PLANT = item.PLANT;
                    imp4.ITEM_HU[x].STGE_LOC = item.STGE_LOC;
                    x++;

                }

                respuesta.E_EXIDV = imp4.HEADER_HU.HU_EXID;
                responce_ZMOV_CREATE_HU resp4 = sap4.sapRun(imp4);
            }
            XmlDocument res = o.responce_ZMOV_20031(respuesta);
            o.insert("ZMOV_20031", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        //NOTA CALIDAD
        public responce_ZMOV_UPDATE_CALIDAD_LOTE ZMOV_UPDATE_CALIDAD_LOTE(request_ZMOV_UPDATE_CALIDAD_LOTE datos)
        {
            String mesAnterior = DateTime.Now.AddDays(-60).ToString("dd.MM.yyyy");
            DateTime DateMA = DateTime.ParseExact(mesAnterior, "dd.MM.yyyy", null);

            for (int i = 0; i < datos.LT_CARACT.Length; i++)
            {
                /*if (datos.LT_CARACT[i].CHARACT == "ZFCOSECHA")
                {
                    String fecha = datos.LT_CARACT[i].VALUE_CHAR;
                    DateTime DateObject = DateTime.ParseExact(fecha, "dd.MM.yyyy", null);
                    if (DateObject < DateMA)
                    {
                        datos.LT_CARACT[i].VALUE_CHAR = DateTime.Now.ToString("dd.MM.yyyy");
                    }
                }*/
                if (datos.LT_CARACT[i].CHARACT == "FECHAINICIOPROCESO")
                {
                    String fecha = datos.LT_CARACT[i].VALUE_CHAR;
                    DateTime DateObject = DateTime.ParseExact(fecha, "dd.MM.yyyy", null);
                    if (DateObject < DateMA)
                    {
                        //datos.LT_CARACT[i].VALUE_CHAR = DateTime.Now.ToString("dd.MM.yyyy");
                        //datos.LT_CARACT[i + 1].VALUE_CHAR = DateTime.Now.ToString("HH:mm:ss");
                    }
                }
            }
            
            ZMOV_UPDATE_CALIDAD_LOTE sap = new ZMOV_UPDATE_CALIDAD_LOTE();
            responce_ZMOV_UPDATE_CALIDAD_LOTE respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
           

            


            XmlDocument imp = o.request_ZMOV_UPDATE_CALIDAD_LOTE(datos);
            XmlDocument res = o.responce_ZMOV_UPDATE_CALIDAD_LOTE(respuesta);
            o.insert("ZMOV_UPDATE_CALIDAD_LOTE", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

        [WebMethod]
        public responce_ZMOV_QUERY_STOCK_LOTE ZMOV_QUERY_STOCK_LOTE(string LOTE)
        {
            ZMOV_QUERY_STOCK_LOTE sap = new ZMOV_QUERY_STOCK_LOTE();
            request_ZMOV_QUERY_STOCK_LOTE imp = new request_ZMOV_QUERY_STOCK_LOTE();


            imp.LOTE = LOTE;


            responce_ZMOV_QUERY_STOCK_LOTE obj = sap.sapRun(imp);



            return obj;
        }
        [WebMethod]
        public responce_ZMOV_QUERY_HU_INFO ZMOV_QUERY_HU_INFO(string HU)
        {
            ZMOV_QUERY_HU_INFO sap = new ZMOV_QUERY_HU_INFO();
            request_ZMOV_QUERY_HU_INFO imp = new request_ZMOV_QUERY_HU_INFO();

            imp.IR_EXIDV = new ZMOV_QUERY_HU_INFO_IR_EXIDV[1];
            imp.IR_EXIDV[0] = new ZMOV_QUERY_HU_INFO_IR_EXIDV();

            imp.IR_EXIDV[0].HIGH = "";
            imp.IR_EXIDV[0].LOW = HU.PadLeft(20, '0');
            imp.IR_EXIDV[0].OPTION = "EQ";
            imp.IR_EXIDV[0].SIGN = "I";

            
            responce_ZMOV_QUERY_HU_INFO obj = sap.sapRun(imp);
            obj.HoraServidor = DateTime.Now;
            
            return obj;
        }
       [WebMethod]
        public responce_ZMOV_STOCK_NPARTIDA ZMOV_STOCK_NPARTIDA(string LOTE)
        {
            ZMOV_STOCK_NPARTIDA sap = new ZMOV_STOCK_NPARTIDA();
            request_ZMOV_STOCK_NPARTIDA imp = new request_ZMOV_STOCK_NPARTIDA();


            imp.I_BUKRS = "DC01";
            imp.I_ATNAM = "ZNPARTIDA";
            imp.I_ATWRT = LOTE;


            responce_ZMOV_STOCK_NPARTIDA obj = sap.sapRun(imp);



            return obj;
        }

        [WebMethod]
        public responce_ZMOV_QUERY_STOCK_PROCESO ZMOV_QUERY_STOCK_PROCESO(string LOTE)
        {
            ZMOV_QUERY_STOCK_PROCESO sap = new ZMOV_QUERY_STOCK_PROCESO();
            request_ZMOV_QUERY_STOCK_PROCESO imp = new request_ZMOV_QUERY_STOCK_PROCESO();


            imp.LOTEPROCESO = LOTE;


            responce_ZMOV_QUERY_STOCK_PROCESO obj = sap.sapRun(imp);



            return obj;
        }
             [WebMethod]
        public responce_ZRFC_QM_LOTEINFO_C ZRFC_QM_LOTEINFO_C(string CARACT, string LOTE)
        {
            ZRFC_QM_LOTEINFO_C sap = new ZRFC_QM_LOTEINFO_C();
            request_ZRFC_QM_LOTEINFO_C imp = new request_ZRFC_QM_LOTEINFO_C();


            imp.I_ATNAM = CARACT;
            imp.I_BUKRS = "DC01";
            imp.I_ATWRT = LOTE;

            responce_ZRFC_QM_LOTEINFO_C obj = sap.sapRun(imp);



            return obj;
        }

        

        [WebMethod]
        public responce_ZDDCRP_PROCESO ZDDCRP_PROCESO(string loteProceso, string material, int agnoI, int agnoF)
        {
            ZDDCRP_PROCESO sap = new ZDDCRP_PROCESO();
            request_ZDDCRP_PROCESO imp = new request_ZDDCRP_PROCESO();


            imp.CHARG = loteProceso;
            imp.MATNR = material;
            //imp.MJAHR_F = agnoF;
            //imp.MJAHR_I = agnoI;
            imp.MJAHR_I = Convert.ToInt32(DateTime.Now.AddDays(-365).ToString("yyyy"));
            imp.MJAHR_F = Convert.ToInt32(DateTime.Now.AddDays(0).ToString("yyyy"));
            ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO[] dat = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO[5];
            /*dat[0] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[0].BWART = "309";
            dat[1] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[1].BWART = "310";*/
            dat[0] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[0].BWART = "261";
            dat[1] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[1].BWART = "262";
            dat[2] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[2].BWART = "541";
            dat[3] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[3].BWART = "542";
            dat[4] = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
            dat[4].BWART = "309";
            imp.ZRANGO_MOVIMIENTO = dat;

            responce_ZDDCRP_PROCESO obj = sap.sapRun(imp);



            return obj;
        }



        [WebMethod]
        public responce_ZMOV_CREATE_HU ZMOV_CREATE_HU(string HU_EXID, string BATCH, string PACK_QTY)
        {
            
            ZMOV_CREATE_HU sap = new ZMOV_CREATE_HU();

            request_ZMOV_CREATE_HU imp = new request_ZMOV_CREATE_HU();
            imp.HEADER_HU = new ZMOV_CREATE_HU_HEADER_HU();

            imp.HEADER_HU.PACK_MAT = "HUP01";

            imp.HEADER_HU.LGORT_DS = "PA04";
            imp.HEADER_HU.HU_EXID = HU_EXID; //"100200300401"; //Numero de pallet a escanear se escnea

            imp.ITEM_HU = new ZMOV_CREATE_HU_ITEM_HU[1];
            imp.ITEM_HU[0] = new ZMOV_CREATE_HU_ITEM_HU();


            imp.ITEM_HU[0].HU_ITEM_TYPE = "1";

            imp.ITEM_HU[0].PACK_QTY = decimal.Parse(PACK_QTY); //1; //Cantidad de cajas a informar se escanea

            imp.ITEM_HU[0].BASE_UNIT_QTY = "CS";


            imp.ITEM_HU[0].MATERIAL = "MANZANA_TERMINADO";

            imp.ITEM_HU[0].BATCH = BATCH;   //"LOTE1";     //Lote de proceso se escanea

            imp.ITEM_HU[0].PLANT = "DC10";
            imp.ITEM_HU[0].STGE_LOC = "PA03";


            responce_ZMOV_CREATE_HU obj = sap.sapRun(imp);


            return obj;
        }


        [WebMethod]
        public responce_DB_LOGIN DB_LOGIN(string user, string pass)
        {
            String User = user.ToString();
            String Pass = pass.ToString();
            String dataGranel = ""; //String dataGranel = (Request["dataGranel"] != null) ? Request["dataGranel"].ToString() : "";
            String Proceso =  "";//String Proceso = (Request["proceso"] != null) ? Request["proceso"].ToString() : "";
            // String WERKS = Request["WERKS"].ToString();

            DB_LOGIN sap = new DB_LOGIN();
            request_DB_LOGIN imp = new request_DB_LOGIN();
            imp.User = User;
            imp.Pass = Pass;
            imp.dataGranel = dataGranel;
            imp.Proceso = Proceso;
            responce_DB_LOGIN obj = sap.run(imp);
            
            return obj;

        }
        [WebMethod]
        public responce_DB_PRESIZER[] DB_PRESIZER(string batch)
        {
            String batchP = batch.ToString();

            DB_PRESIZER presizer = new DB_PRESIZER();
            request_DB_PRESIZER imp = new request_DB_PRESIZER();
            imp.batch = batchP;
            return presizer.run(imp);

        }
        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_HU_FRESCO ZMOV_CREATE_RECEP_HU_FRESCO(request_ZMOV_CREATE_RECEP_HU_FRESCO datos)
        {
            ZMOV_CREATE_RECEP_HU_FRESCO sap = new ZMOV_CREATE_RECEP_HU_FRESCO();
            responce_ZMOV_CREATE_RECEP_HU_FRESCO respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_HU_FRESCO(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_HU_FRESCO(respuesta);
            o.insert("ZMOV_CREATE_RECEP_HU_FRESCO", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_HU_FRESCO_V2 ZMOV_CREATE_RECEP_HU_FRESCO_V2(request_ZMOV_CREATE_RECEP_HU_FRESCO_V2 datos)
        {
            ZMOV_CREATE_RECEP_HU_FRESCO_V2 sap = new ZMOV_CREATE_RECEP_HU_FRESCO_V2();
            responce_ZMOV_CREATE_RECEP_HU_FRESCO_V2 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_HU_FRESCO_V2(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_HU_FRESCO_V2(respuesta);
            o.insert("ZMOV_CREATE_RECEP_HU_FRESCO_V2", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_FRESCO_UAT ZMOV_CREATE_RECEP_FRESCO_UAT(request_ZMOV_CREATE_RECEP_FRESCO_UAT datos)
        {
            ZMOV_CREATE_RECEP_FRESCO_UAT sap = new ZMOV_CREATE_RECEP_FRESCO_UAT();
            responce_ZMOV_CREATE_RECEP_FRESCO_UAT respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_FRESCO_UAT(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_FRESCO_UAT(respuesta);
            o.insert("ZMOV_CREATE_RECEP_FRESCO_UAT", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_GOODSMVT_CREATE ZMOV_GOODSMVT_CREATE(request_ZMOV_GOODSMVT_CREATE datos)
        {
            ZMOV_GOODSMVT_CREATE sap = new ZMOV_GOODSMVT_CREATE();
            responce_ZMOV_GOODSMVT_CREATE respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_GOODSMVT_CREATE(datos);
            XmlDocument res = o.responce_ZMOV_GOODSMVT_CREATE(respuesta);
            o.insert("ZMOV_GOODSMVT_CREATE", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_UPDATE_HU_PAISES ZMOV_UPDATE_HU_PAISES(request_ZMOV_UPDATE_HU_PAISES datos)
        {
            ZMOV_UPDATE_HU_PAISES sap = new ZMOV_UPDATE_HU_PAISES();
            responce_ZMOV_UPDATE_HU_PAISES respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_UPDATE_HU_PAISES(datos);
            XmlDocument res = o.responce_ZMOV_UPDATE_HU_PAISES(respuesta);
            o.insert("ZMOV_UPDATE_HU_PAISES", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_PT_FRESCO ZMOV_CREATE_RECEP_PT_FRESCO(request_ZMOV_CREATE_RECEP_PT_FRESCO datos)
        {
            ZMOV_CREATE_RECEP_PT_FRESCO sap = new ZMOV_CREATE_RECEP_PT_FRESCO();
            responce_ZMOV_CREATE_RECEP_PT_FRESCO respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_PT_FRESCO(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_PT_FRESCO(respuesta);
            o.insert("ZMOV_CREATE_RECEP_PT_FRESCO", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_PT_FRESCO_R ZMOV_CREATE_RECEP_PT_FRESCO_R(request_ZMOV_CREATE_RECEP_PT_FRESCO_R datos)
        {
            ZMOV_CREATE_RECEP_PT_FRESCO_R sap = new ZMOV_CREATE_RECEP_PT_FRESCO_R();
            responce_ZMOV_CREATE_RECEP_PT_FRESCO_R respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_PT_FRESCO_R(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_PT_FRESCO_R(respuesta);
            o.insert("ZMOV_CREATE_RECEP_PT_FRESCO_R", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_CREATE_HU_UNPACK ZMOV_CREATE_HU_UNPACK(request_ZMOV_CREATE_HU_UNPACK datos)
        {
            ZMOV_CREATE_HU_UNPACK sap = new ZMOV_CREATE_HU_UNPACK();
            responce_ZMOV_CREATE_HU_UNPACK respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_HU_UNPACK(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_HU_UNPACK(respuesta);
            o.insert("ZMOV_CREATE_HU_UNPACK", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_CREATE_HU_PACK ZMOV_CREATE_HU_PACK(request_ZMOV_CREATE_HU_PACK datos)
        {
            ZMOV_CREATE_HU_PACK sap = new ZMOV_CREATE_HU_PACK();
            responce_ZMOV_CREATE_HU_PACK respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_HU_PACK(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_HU_PACK(respuesta);
            o.insert("ZMOV_CREATE_HU_PACK", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_UPDATE_HU_CABECERA ZMOV_UPDATE_HU_CABECERA(request_ZMOV_UPDATE_HU_CABECERA datos)
        {
            ZMOV_UPDATE_HU_CABECERA sap = new ZMOV_UPDATE_HU_CABECERA();
            responce_ZMOV_UPDATE_HU_CABECERA respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_UPDATE_HU_CABECERA(datos);
            XmlDocument res = o.responce_ZMOV_UPDATE_HU_CABECERA(respuesta);
            o.insert("ZMOV_UPDATE_HU_CABECERA", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_HU_MOVER ZMOV_HU_MOVER(request_ZMOV_HU_MOVER datos)
        {
            ZMOV_HU_MOVER sap = new ZMOV_HU_MOVER();
            responce_ZMOV_HU_MOVER respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_HU_MOVER(datos);
            XmlDocument res = o.responce_ZMOV_HU_MOVER(respuesta);
            o.insert("ZMOV_HU_MOVER", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_UPDATE_HU_HEADER ZMOV_UPDATE_HU_HEADER(request_ZMOV_UPDATE_HU_HEADER datos)
        {
            ZMOV_UPDATE_HU_HEADER sap = new ZMOV_UPDATE_HU_HEADER();
            responce_ZMOV_UPDATE_HU_HEADER respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_UPDATE_HU_HEADER(datos);
            XmlDocument res = o.responce_ZMOV_UPDATE_HU_HEADER(respuesta);
            o.insert("ZMOV_UPDATE_HU_HEADER", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_UPDATE_HU_HEADER_N ZMOV_UPDATE_HU_HEADER_N(request_ZMOV_UPDATE_HU_HEADER_N datos)
        {
            ZMOV_UPDATE_HU_HEADER_N sap = new ZMOV_UPDATE_HU_HEADER_N();
            responce_ZMOV_UPDATE_HU_HEADER_N respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_UPDATE_HU_HEADER_N(datos);
            XmlDocument res = o.responce_ZMOV_UPDATE_HU_HEADER_N(respuesta);
            o.insert("ZMOV_UPDATE_HU_HEADER_N", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_UPDATE_HU_HEADER_N_APR ZMOV_UPDATE_HU_HEADER_N_APR(request_ZMOV_UPDATE_HU_HEADER_N_APR datos)
        {
            ZMOV_UPDATE_HU_HEADER_N_APR sap = new ZMOV_UPDATE_HU_HEADER_N_APR();
            responce_ZMOV_UPDATE_HU_HEADER_N_APR respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_UPDATE_HU_HEADER_N_APR(datos);
            XmlDocument res = o.responce_ZMOV_UPDATE_HU_HEADER_N_APR(respuesta);
            o.insert("ZMOV_UPDATE_HU_HEADER_N_APR", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_HU_FRESCOUAT ZMOV_CREATE_RECEP_HU_FRESCOUAT(request_ZMOV_CREATE_RECEP_HU_FRESCOUAT datos)
        {
            ZMOV_CREATE_RECEP_HU_FRESCOUAT sap = new ZMOV_CREATE_RECEP_HU_FRESCOUAT();
            responce_ZMOV_CREATE_RECEP_HU_FRESCOUAT respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_HU_FRESCOUAT(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_HU_FRESCOUAT(respuesta);
            o.insert("ZMOV_CREATE_RECEP_HU_FRESCOUAT", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMF_LEINT_HU_UPDATE ZMF_LEINT_HU_UPDATE(request_ZMF_LEINT_HU_UPDATE datos)
        {
            ZMF_LEINT_HU_UPDATE sap = new ZMF_LEINT_HU_UPDATE();
            responce_ZMF_LEINT_HU_UPDATE respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMF_LEINT_HU_UPDATE(datos);
            XmlDocument res = o.responce_ZMF_LEINT_HU_UPDATE(respuesta);
            o.insert("ZMF_LEINT_HU_UPDATE", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_PT_FRESCO_OR ZMOV_CREATE_RECEP_PT_FRESCO_OR(request_ZMOV_CREATE_RECEP_PT_FRESCO_OR datos)
        {
            ZMOV_CREATE_RECEP_PT_FRESCO_OR sap = new ZMOV_CREATE_RECEP_PT_FRESCO_OR();
            responce_ZMOV_CREATE_RECEP_PT_FRESCO_OR respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_PT_FRESCO_OR(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_PT_FRESCO_OR(respuesta);
            o.insert("ZMOV_CREATE_RECEP_PT_FRESCO_OR", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_PT_FRCO_C ZMOV_CREATE_RECEP_PT_FRCO_C(request_ZMOV_CREATE_RECEP_PT_FRCO_C datos)
        {
            ZMOV_CREATE_RECEP_PT_FRCO_C sap = new ZMOV_CREATE_RECEP_PT_FRCO_C();
            responce_ZMOV_CREATE_RECEP_PT_FRCO_C respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_PT_FRCO_C(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_PT_FRCO_C(respuesta);
            o.insert("ZMOV_CREATE_RECEP_PT_FRCO_C", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        //ZMOV_GET_PALLETS
        [WebMethod]
        public responce_ZMOV_GET_PALLETS ZMOV_GET_PALLETS(request_ZMOV_GET_PALLETS datos)
        {
            ZMOV_GET_PALLETS sap = new ZMOV_GET_PALLETS();
            responce_ZMOV_GET_PALLETS respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_GET_PALLETS(datos);
            XmlDocument res = o.responce_ZMOV_GET_PALLETS(respuesta);
            o.insert("ZMOV_GET_PALLETS", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_HU_FRESCO_C ZMOV_CREATE_RECEP_HU_FRESCO_C(request_ZMOV_CREATE_RECEP_HU_FRESCO_C datos)
        {
            ZMOV_CREATE_RECEP_HU_FRESCO_C sap = new ZMOV_CREATE_RECEP_HU_FRESCO_C();
            responce_ZMOV_CREATE_RECEP_HU_FRESCO_C respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_HU_FRESCO_C(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_HU_FRESCO_C(respuesta);
            o.insert("ZMOV_CREATE_RECEP_HU_FRESCO_C", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

         [WebMethod]
        public responce_CAJA_UNICA_AUX[] DB_CAJA_UNICA_AUX(request_CAJA_UNICA_AUX datos)
        {
            List<responce_CAJA_UNICA_AUX> List = new List<responce_CAJA_UNICA_AUX>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("CAJA_UNICA_SUPPORT", connection);
                cmd.Parameters.Add(new SqlParameter("@numero", int.Parse(datos.Numero)));
                cmd.Parameters.Add(new SqlParameter("@planta", datos.planta));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        responce_CAJA_UNICA_AUX res = new responce_CAJA_UNICA_AUX();
                        res.planta = dataReader[0].ToString();
                        res.Numero = dataReader[1].ToString();
                        List.Add(res);
                    }
                }
            }
            catch (Exception e)
            {
                responce_CAJA_UNICA_AUX res = new responce_CAJA_UNICA_AUX();
                res.ERROR = e.ToString();
                List.Add(res);
            }
            connection.Close();
            connection.Dispose();
            return List.ToArray();
        }
        [WebMethod]
        public responce_DB_ETIQUETA_VENTANA[] DB_ETIQUETA_VENTANA(request_DB_ETIQUETA_VENTANA datos)
        {

            GPLogger.CaptureHttpRequest("Request"+"_"+datos.Ip, Context.Request);
            
            /*
            List<responce_DB_ETIQUETA_VENTANA> List = new List<responce_DB_ETIQUETA_VENTANA>();

            String _connectionString = ConfigurationManager.ConnectionStrings["DDC_ETIQUETADO"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select pr.estado,pr.centro,pos.ip_pantalla, pos.pantalla_zpl,zv.tipo_material, zv.stock," +
                            "zv.calibre, zv.kilos_material, zv.ip_Zebra, zv.zpl, zv.proceso, zv.salida, et.calidad, zv.Line, "+
                            "et.correlativo,et.especie,et.turno,et.variedad,et.productor,et.fecha_prd,et.codigo_material,pr.planta,et.id" +
                            " from proceso pr" +
                            " join zpl_ventana zv on zv.proceso = pr.proceso" +
                            " join posicion_zpl pos on pos.id = zv.id_posicion" +
                            " join etiqueta et on et.id = zv.id_etiqueta" +
                            " where 1=1" +
                            " and pos.ip_pantalla = '" + datos.Ip + "'" +
                            " and (zv.stock > 0" +
                            " or pr.estado = 'VIGENTE')";
            //String sql = "";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
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
                    var date = DateTime.Now;
                    var HH = (date.Hour < 10) ? "0" + date.Hour.ToString() : date.Hour.ToString();
                    var MM = (date.Minute < 10) ? "0" + date.Minute.ToString() : date.Minute.ToString();
                    var hora = HH + ":" + MM;
                    var zpl = dataReader[9].ToString().Replace("@HORA", hora);
                    zpl = zpl.Replace("@hora", hora);
                    res.ZPL = zpl;
                    res.Proceso = dataReader[10].ToString();
                    res.Salida = dataReader[11].ToString();
                    res.Calidad = dataReader[12].ToString();
                    res.Linea = dataReader[13].ToString();
                    res.correlativo = dataReader[14].ToString();
                    res.especie = dataReader[15].ToString();
                    res.turno = dataReader[16].ToString();
                    res.variedad = dataReader[17].ToString();
                    res.codigo = dataReader[18].ToString();
                    res.fecha = dataReader[19].ToString();
                    res.Cod_Mat = dataReader[20].ToString();
                    res.planta = dataReader[21].ToString();
                    res.id = dataReader["id"].ToString();
                    res.Refresco = "10";
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
             * */

            List<responce_DB_ETIQUETA_VENTANA> List = new List<responce_DB_ETIQUETA_VENTANA>();
            DB_ETIQUETA_VENTANA DbEti = new DB_ETIQUETA_VENTANA();
            List = DbEti.run(datos);


            return List.ToArray();
        }


         [WebMethod]
         public responce_DB_CONSULTA_ETIQUETA_VENTANA[] DB_ETIQUETA_VENTANA_RE (request_CONSULTA_ETIQUETA_VENTANA datos)
         {
             List<responce_DB_CONSULTA_ETIQUETA_VENTANA> List = new List<responce_DB_CONSULTA_ETIQUETA_VENTANA>();

             String _connectionString = ConfigurationManager.ConnectionStrings["DDC_ETIQUETADO"].ToString();
             SqlConnection connection = new SqlConnection(_connectionString);
             connection.Open();
             String sql = "select pr.estado,pr.centro,pos.ip_pantalla, pos.pantalla_zpl,zv.tipo_material, zv.stock, zv.calibre, zv.kilos_material, zv.ip_Zebra, zv.zpl, zv.proceso, zv.salida, et.calidad, zv.Line, et.correlativo,et.especie,et.turno,et.variedad,et.productor,et.fecha_prd,et.codigo_material,pr.planta, et.id" +
                             " from proceso pr" +
                             " join zpl_ventana zv on zv.proceso = pr.proceso" +
                             " join posicion_re pos on pos.id = zv.id_posicion" +
                             " join etiqueta et on zv.id_etiqueta = et.id" +
                             " where 1=1" +
                             " and pos.ip_pantalla = '" + datos.Ip + "' and pr.reetiquetado = 'ACTIVO'";
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
                     var date = DateTime.Now;
                     var HH = (date.Hour < 10) ? "0" + date.Hour.ToString() : date.Hour.ToString();
                     var MM = (date.Minute < 10) ? "0" + date.Minute.ToString() : date.Minute.ToString();
                     var hora = HH + ":" + MM;
                     var zpl = dataReader[9].ToString().Replace("@HORA", hora);
                     zpl = zpl.Replace("@hora", hora);
                     res.ZPL = zpl;
                     res.Proceso = dataReader[10].ToString();
                     res.Salida = dataReader[11].ToString();
                     res.Calidad = dataReader[12].ToString();
                     res.Linea = dataReader[13].ToString();
                     res.correlativo = dataReader[14].ToString();
                     res.especie = dataReader[15].ToString();
                     res.turno = dataReader[16].ToString();
                     res.variedad = dataReader[17].ToString();
                     res.codigo = dataReader[18].ToString();
                     res.fecha = dataReader[19].ToString();
                     res.Cod_Mat = dataReader[20].ToString();
                     res.planta = dataReader[21].ToString();
                     res.id = dataReader["id"].ToString();
                     res.Refresco = "10";
                     List.Add(res);
                 }
             }
             connection.Close();
             connection.Dispose();
             cmd.Dispose();
             return List.ToArray();
         }


        [WebMethod]
         public responce_CAJA_UNICA CAJA_UNICA(request_CAJA_UNICA datos)
         {
             responce_CAJA_UNICA res = new responce_CAJA_UNICA();
             String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
             SqlConnection connection = new SqlConnection(_connectionString);
             connection.Open();
             SqlCommand cmd = new SqlCommand();
             SqlDataAdapter da = new SqlDataAdapter();
             try
             {
                 cmd = new SqlCommand("CAJA_UNICA_INSERT", connection);
                 cmd.Parameters.Add(new SqlParameter("@num", datos.NUM));
                 cmd.Parameters.Add(new SqlParameter("@lote", datos.LOTE));
                 cmd.Parameters.Add(new SqlParameter("@kilos", float.Parse(datos.KILOS)));
                 cmd.Parameters.Add(new SqlParameter("@calibre", datos.CALIBRE));
                 cmd.Parameters.Add(new SqlParameter("@linea", int.Parse(datos.LINEA)));
                 cmd.Parameters.Add(new SqlParameter("@turno", int.Parse(datos.TURNO)));
                 cmd.Parameters.Add(new SqlParameter("@salida", int.Parse(datos.SALIDA)));
                 cmd.Parameters.Add(new SqlParameter("@material", datos.MATERIAL));
                 cmd.Parameters.Add(new SqlParameter("@especie", datos.ESPECIE));
                 cmd.Parameters.Add(new SqlParameter("@variedad", datos.VARIEDAD));
                 cmd.Parameters.Add(new SqlParameter("@cod_p", datos.CODIGO_P));
                 DateTime itemDate = DateTime.ParseExact(datos.FECHA, "yyyy-MM-dd HH:mm:ss.fffffff", System.Globalization.CultureInfo.InvariantCulture);
                 cmd.Parameters.Add(new SqlParameter("@fecha", itemDate));
                 cmd.Parameters.Add(new SqlParameter("@hora", datos.HORA));
                 cmd.CommandType = CommandType.StoredProcedure;
                 SqlDataReader dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                     res.resp = dr[0].ToString();


                 }
             }
             catch (Exception e)
             {
                 res.resp = e.ToString();
             }
             connection.Close();
             connection.Dispose();
             return res;

         }

        [WebMethod]
        public responce_ZMOV_50001 ZMOV_50001(request_ZMOV_50001 datos)
        {
            ZMOV_50001 sap = new ZMOV_50001();
            responce_ZMOV_50001 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_50001(datos);
            XmlDocument res = o.responce_ZMOV_50001(respuesta);
            o.insert("ZMOV_50001", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        //ZMOV_50011
        [WebMethod]
        public responce_ZMOV_50011 ZMOV_50011(request_ZMOV_50011 datos)
        {
            ZMOV_50011 sap = new ZMOV_50011();
            responce_ZMOV_50011 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_50011(datos);
            XmlDocument res = o.responce_ZMOV_50011(respuesta);
            o.insert("ZMOV_50011", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        //ZMOV_20030
        [WebMethod]
        public responce_ZMOV_20030 ZMOV_20030(request_ZMOV_20030 datos)
        {
            ZMOV_20030 sap = new ZMOV_20030();
            responce_ZMOV_20030 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_20030(datos);
            XmlDocument res = o.responce_ZMOV_20030(respuesta);
            o.insert("ZMOV_20030", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        //ZMOV_20032
        [WebMethod]
        public responce_ZMOV_20032 ZMOV_20032(request_ZMOV_20032 datos)
        {
            ZMOV_20032 sap = new ZMOV_20032();
            responce_ZMOV_20032 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_20032(datos);
            XmlDocument res = o.responce_ZMOV_20032(respuesta);
            o.insert("ZMOV_20032", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_20033 ZMOV_20033(request_ZMOV_20033 datos)
        {
            ZMOV_20033 sap = new ZMOV_20033();
            responce_ZMOV_20033 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_20033(datos);
            XmlDocument res = o.responce_ZMOV_20033(respuesta);
            o.insert("ZMOV_20033", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
        public responce_ZMOV_20034 ZMOV_20034(request_ZMOV_20034 datos)
        {
            ZMOV_20034 sap = new ZMOV_20034();
            responce_ZMOV_20034 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_20034(datos);
            XmlDocument res = o.responce_ZMOV_20034(respuesta);
            o.insert("ZMOV_20034", imp.InnerXml, res.InnerXml);
            return respuesta;
        }
        [WebMethod]
         public responce_DB_PROCESO_MOD DB_PROCESO_MOD(request_DB_PROCESO_MOD datos)
         {
             responce_DB_PROCESO_MOD res = new responce_DB_PROCESO_MOD();
             String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
             SqlConnection connection = new SqlConnection(_connectionString);
             connection.Open(); 
             SqlCommand cmd = new SqlCommand();
             SqlDataAdapter da = new SqlDataAdapter();
             try
             {
                 cmd = new SqlCommand("PROCESO_MOD", connection);
                 cmd.Parameters.Add(new SqlParameter("@proceso", datos.Proceso));
                 cmd.Parameters.Add(new SqlParameter("@kilos", float.Parse(datos.kilos.ToString())));
                 cmd.Parameters.Add(new SqlParameter("@ip_pantalla", datos.ip_pantalla));
                 cmd.Parameters.Add(new SqlParameter("@posicion", datos.posicion));
                 cmd.CommandType = CommandType.StoredProcedure;
                 SqlDataReader dr = cmd.ExecuteReader();
                 if (dr.Read())
                 {
                     res.res = dr[0].ToString();


                 }
             }
             catch (Exception e)
             {
                 res.res = e.ToString();
             }
             /*String sql = "";
             int aux = 2;
             for (int i = 0; i < aux; i++)
             {

                 if (i == 0)
                 {
                     sql = "update proceso set kilos_etiquetas = kilos_etiquetas+" + datos.posicion + " where proceso = '" + datos.Proceso + "'";

                     SqlCommand cmd = new SqlCommand(sql, connection);
                     cmd.Connection = connection;
                     SqlDataReader dataReader = cmd.ExecuteReader();
                     dataReader.Close();
                     res.res = "ok-";
                 }
                 if (i == 1)
                 {
                     sql = "update zpl_ventana" +
                             " set stock = stock - 1" +
                             " where id_posicion = (select id from posicion_zpl where ip_pantalla = '" + datos.ip_pantalla + "' and pantalla_zpl = " + datos.posicion + ")" +
                             " and stock > 0";

                     SqlCommand cmd = new SqlCommand(sql, connection);
                     cmd.Connection = connection;
                     SqlDataReader dataReader = cmd.ExecuteReader();
                     dataReader.Close();
                     res.res = res.res + "ok";
                 }

             } */
             connection.Close();
             connection.Dispose();
             return res;

         }

        [WebMethod]
        public responce_ZMOV_QUERY_GRUPO_CATE ZMOV_QUERY_GRUPO_CATE(request_ZMOV_QUERY_GRUPO_CATE valor)
        {

            ZMOV_QUERY_GRUPO_CATE sap = new ZMOV_QUERY_GRUPO_CATE();


            responce_ZMOV_QUERY_GRUPO_CATE obj = sap.sapRun(valor);


            return obj;
        }

/*
        [WebMethod]
        public string GETEXCEL(string url, string informe, bool filtra)
        {
            string response = "";
            try
            {

                string Filename = "C:\\temp\\base.xlsx";
                Random r = new Random();

                string newFile = "C:\\temp\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + r.GetHashCode() + ".xlsx";

                File.Copy(Filename, newFile, true);


                object NullValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.DisplayAlerts = false;

                Microsoft.Office.Interop.Excel.Workbook book = excelApp.Workbooks.Open(
                newFile, NullValue, NullValue, NullValue, NullValue,
                NullValue, NullValue, NullValue, NullValue, NullValue,
                NullValue, NullValue, NullValue, NullValue, NullValue);

                foreach (Excel.WorkbookConnection wc in book.Connections)
                {
                   //response += "--" + wc.Type.ToString();
                    if (wc.Type.ToString() == "xlConnectionTypeDATAFEED")
                    { 
                        //response += "--" + wc.OLEDBConnection.Connection;


                        if (filtra)
                        {
                            //response += "--" + wc.DataFeedConnection.Connection;

                            wc.DataFeedConnection.Connection = "DATAFEED;Data Source=" + url + ";Namespaces to Include=*;Max Received Message Size=4398046511104;Integrated Security=SSPI;Keep Alive=true;Persist Security Info=false;Base Url=" + url;
                            wc.DataFeedConnection.CommandText = informe;
                        }
                        else
                        {
                            wc.DataFeedConnection.Connection = "DATAFEED;Data Source=" + url + ";Namespaces to Include=*;Max Received Message Size=4398046511104;Integrated Security=SSPI;Keep Alive=true;Persist Security Info=false;Service Document Url=" + url;
                            wc.DataFeedConnection.CommandText = informe;
                        }



                        break;

                    }

                }




                book.RefreshAll();
                System.Threading.Thread.Sleep(20000);
                book.Save();
                book.Close(true, newFile, null);
                excelApp.Quit();
                book = null;
                //KillpIDs("Excel");

                Byte[] bytes = File.ReadAllBytes(newFile);
                response = Convert.ToBase64String(bytes);

            }
            catch (Exception ex)
            {

                response = "NOK;" + ex.Message + "--Stack:" + ex.StackTrace;
            }
            return response;

        }
        */
        //ZMOV_CREATE_RECEP_PT_FRESCO_SE
        /*NUEVO*/
        [WebMethod]
        public responce_PTI_WS INSERT_PTI(request_PTI_WS datos)
        {
            PTI_WS sap = new PTI_WS();
            responce_PTI_WS respuesta = sap.run(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_pti(datos);
            XmlDocument res = o.responce_PTI(respuesta);
            o.insert("INSERT_PTI", imp.InnerXml, res.InnerXml);
            return respuesta;
        }​​​​
        [WebMethod]
        public responce_ZMOV_CREATE_RECEP_PT_FRESCO_SE ZMOV_CREATE_RECEP_PT_FRESCO_SE(request_ZMOV_CREATE_RECEP_PT_FRESCO_SE datos)
        {
            ZMOV_CREATE_RECEP_PT_FRESCO_SE sap = new ZMOV_CREATE_RECEP_PT_FRESCO_SE();
            responce_ZMOV_CREATE_RECEP_PT_FRESCO_SE respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_CREATE_RECEP_PT_FRESCO_SE(datos);
            XmlDocument res = o.responce_ZMOV_CREATE_RECEP_PT_FRESCO_SE(respuesta);
            o.insert("ZMOV_CREATE_RECEP_PT_FRESCO_SE", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

        [WebMethod]
        public responce_FECHA GET_FECHA_SERVER(responce_FECHA datos)
        {
            //PTI_WS sap = new PTI_WS();
            DB_PORTAL sap = new DB_PORTAL();
            responce_FECHA respuesta = sap.GET_FECHA();
            ObjectXml o = new ObjectXml();
            //XmlDocument imp = o.request_pti(datos);
            XmlDocument res = o.responce_FECHA(respuesta);
            o.insert("GET_FECHA", "", res.InnerXml);
            return respuesta;
        }

        [WebMethod]
        public responce_ZMOV_10001 ZMOV_10001(request_ZMOV_10001 datos)
        {
            ZMOV_10001 sap = new ZMOV_10001();
            responce_ZMOV_10001 respuesta = sap.sapRun(datos);
            ObjectXml o = new ObjectXml();
            XmlDocument imp = o.request_ZMOV_10001(datos);
            XmlDocument res = o.responce_ZMOV_10001(respuesta);
            o.insert("ZMOV_10001", imp.InnerXml, res.InnerXml);
            return respuesta;
        }

        [WebMethod]
        public responce_DB_ETIQUETA_CORRELATIVO DB_ETIQUETA_CORRELATIVO(request_DB_ETIQUETA_CORRELATIVO datos)
        {
            DB_ETIQUETA_CORRELATIVO sap = new DB_ETIQUETA_CORRELATIVO();
            responce_DB_ETIQUETA_CORRELATIVO respuesta = sap.run(datos);
           
            return respuesta;
        }

        [WebMethod]
        public string CallPTI(string[] parametros)
        {
            string respuesta = "NOK";
            try
            {


                cl.ptichile.sistema_test.WSDLService pti = new cl.ptichile.sistema_test.WSDLService();

                respuesta = pti.RecibeMaster(parametros[0],
                                parametros[1],
                                parametros[2],
                                parametros[3],
                                parametros[4],
                                parametros[5],
                                parametros[6],
                                parametros[7],
                                parametros[8],
                                parametros[9],
                                parametros[10],
                                parametros[11],
                                parametros[12],
                                DateTime.Parse(parametros[13]),
                                decimal.Parse(parametros[14]),
                                decimal.Parse(parametros[15]),
                                decimal.Parse(parametros[16]),
                                decimal.Parse(parametros[17]),
                                parametros[18],
                                parametros[19],
                                parametros[20]);


            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }


            return respuesta;
        }
        private static void KillpIDs(String appName)
        {
            Process[] currentP = Process.GetProcessesByName(appName);

            foreach (Process p in currentP)
            {
                if (p.MainWindowHandle.ToInt32() == 0)
                {
                    p.Kill();
                }
            }
        }

   
    }
       
        

}