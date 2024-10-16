using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Collections;
using System.Net;
using System.Text;
using System.IO;

namespace rfcBaika
{
    public class PTI_WS
    {
        public responce_PTI_WS run(request_PTI_WS datos)
        {
            responce_PTI_WS res = new responce_PTI_WS();
            try
            {
                datos.cabecera.peso_muestra = datos.cabecera.peso_muestra * 1000;

                var json2 = new JavaScriptSerializer().Serialize(datos);

                string text = json2.ToString();

                // WriteAllText creates a file, writes the specified string to the file,
                // and then closes the file.    You do NOT need to call Flush() or Close().
                System.IO.File.WriteAllText(@"C:\temp\PTI\RECIBIDOS\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt", text);

                //OBTENER LISTADO DE LOTES
                // ZRFC_QM_LOTEINFO_C.aspx?I_BUKRS=DC01&I_ATNAM=ZNPARTIDA&I_ATWRT=1002349PP

                ZRFC_QM_LOTEINFO_C consulta_lotes = new ZRFC_QM_LOTEINFO_C();
                request_ZRFC_QM_LOTEINFO_C req_consulta_lotes = new request_ZRFC_QM_LOTEINFO_C();
                req_consulta_lotes.I_ATNAM = "ZNPARTIDA";
                req_consulta_lotes.I_BUKRS = "DC01";
                req_consulta_lotes.I_ATWRT = datos.cabecera.lote.ToString();


                responce_ZRFC_QM_LOTEINFO_C res_consulta_lote = consulta_lotes.sapRun(req_consulta_lotes);

                ArrayList lotespartida = new ArrayList();

                foreach (ZRFC_QM_LOTEINFO_C_ET_LOTES item in res_consulta_lote.ET_LOTES)
                {
                    if (item.CHARG.StartsWith(datos.cabecera.lote.ToString()) && item.MATNR.Contains("CEREZAS") && (item.BWART.Equals("101") || item.BWART.Equals("501")))
                    {
                        lotespartida.Add(item);

                    }
                }



                if (lotespartida.Count <= 0)
                {
                    res.resultado = "NOK";
                    res.mensaje = "NO EXISTEN LOTES ASOCIADOS A PARTIDA ENVIADA";
                    return res;
                }



                ZMOV_UPDATE_CALIDAD_LOTE up_cal = new ZMOV_UPDATE_CALIDAD_LOTE();

                request_ZMOV_UPDATE_CALIDAD_LOTE req_up_cal = new request_ZMOV_UPDATE_CALIDAD_LOTE();

                req_up_cal.IT_CHARG = new ZMOV_UPDATE_CALIDAD_LOTE_IT_CHARG[lotespartida.Count];

                int i = 0;



                ZCALIDAD_CARACT_LOTES update_z_calidad = new ZCALIDAD_CARACT_LOTES();
                request_ZCALIDAD_CARACT_LOTES req_update_z_calidad = new request_ZCALIDAD_CARACT_LOTES();
                req_update_z_calidad.I_SAVE = "X";


                req_update_z_calidad.IT_CARACT = new ZCALIDAD_CARACT_LOTES_IT_CARACT[lotespartida.Count * 32];
                req_up_cal.LT_CARACT = new ZMOV_UPDATE_CALIDAD_LOTE_LT_CARACT[lotespartida.Count * 2];
                int j = 0;
                int k = 0;
                foreach (ZRFC_QM_LOTEINFO_C_ET_LOTES item in lotespartida)
                {

                    req_up_cal.IT_CHARG[i] = new ZMOV_UPDATE_CALIDAD_LOTE_IT_CHARG();

                    req_up_cal.IT_CHARG[i].CHARG = item.CHARG;


                    req_up_cal.LT_CARACT[0 + j] = new ZMOV_UPDATE_CALIDAD_LOTE_LT_CARACT();
                    req_up_cal.LT_CARACT[0 + j].BATCH = item.CHARG;
                    req_up_cal.LT_CARACT[0 + j].CHARACT = "ZCEREZAS_TIPIFICACION";

                    string nota = "Aprobado";

                    if (datos.resumen.segregacion.Contains("PREMIUM"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "PREMIUM";
                    else if (datos.resumen.segregacion.Contains("ASIA 1"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "ASIA 1";
                    else if (datos.resumen.segregacion.Contains("ASIA 2"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "ASIA 2";
                    //else if (datos.resumen.segregacion.Contains("AEREO"))
                    //    req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "CORTO";
                    else if (datos.resumen.segregacion.Contains("MEDIO"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "MEDIO";
                    //nuevos
                    else if (datos.resumen.segregacion.Contains("P1"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "PREMIUM 1";
                    else if (datos.resumen.segregacion.Contains("P2"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "PREMIUM 2";
                    else if (datos.resumen.segregacion.Contains("E1"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "ESTANDAR 1";
                    else if (datos.resumen.segregacion.Contains("E2"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "ESTANDAR 2";
                    else if (datos.resumen.segregacion.Contains("AEREO"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "AEREO";
                    else if (datos.resumen.segregacion.Contains("OBJETADO"))
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "OBJETADO";

                    //fin nuevo

                    else if (datos.resumen.segregacion.Contains("RECHAZADO"))
                    {
                        req_up_cal.LT_CARACT[0 + j].VALUE_CHAR = "RECHAZADO";
                        nota = "Objetado";
                    }
                    else
                    {
                        res.resultado = "NOK";
                        res.mensaje = "SEGREGACION NO COINCIDE CON TIPIFICACION DDC";
                        return res;
                    }



                    req_up_cal.LT_CARACT[1 + j] = new ZMOV_UPDATE_CALIDAD_LOTE_LT_CARACT();
                    req_up_cal.LT_CARACT[1 + j].BATCH = item.CHARG;
                    req_up_cal.LT_CARACT[1 + j].CHARACT = "ZTFRIO";

                    //TIPO FRIO FIJO FC
                    req_up_cal.LT_CARACT[1 + j].VALUE_CHAR = "FC";

                    int x = 0;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_3J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J3.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "PRECALIBRE";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.PCAL.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_L";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.L.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_XL";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.XL.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_2J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J2.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_3J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J3.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_4J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J4.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_5J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J5.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "DUROFEL_PROMEDIO";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.firmeza.durofel.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "FALTA_DE_COLOR";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.falta_color.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "NEGRO";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.negro.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "ROJO_CLARO";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.rojo_claro.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;


                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "ROJO_CAOBA_OSCURO";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.caoba_oscuro.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "ROJO_";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.rojo.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "ROJO_SANTINA";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.rojo_claro_35.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "ROJO_CAOBA";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.rojo_caoba_3.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "ROJO_CAOBA_38";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.rojo_caoba_38.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    /*req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CAOBA_33";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.color.caoba_33.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;
                     * */

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "FRUTOS_BLANDOS";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.firmeza.blando.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "FRUTOS_BLANDOS";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.firmeza.blando.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "PUDRICION";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.condicion.pudricion.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "SOLIDOS_SOLUBLES";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.cabecera.solidos_solubles.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_EXPORTACION";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = (100 - (datos.resumen.total_def_calidad) - datos.resumen.total_def_condicion).ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "NOTA_CLASIFICACION";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = nota;
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;



                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_PRE_CALIBRE";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.PCAL.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_L";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.L.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_XL";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.XL.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_2J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J2.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_3J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J3.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_4J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J4.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_5J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J5.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";

                   /* req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_4J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J4.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_PRE_CALIBRE";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.PCAL.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_L";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.L.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_XL";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.XL.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "P_CAL_5J";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.J5.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;

                    
                    req_update_z_calidad.IT_CARACT[x + k] = new ZCALIDAD_CARACT_LOTES_IT_CARACT();
                    req_update_z_calidad.IT_CARACT[x + k].CHARG = item.CHARG;
                    req_update_z_calidad.IT_CARACT[x + k].CALIDAD = "CALIBRE_G";
                    req_update_z_calidad.IT_CARACT[x + k].VALOR = datos.calibre.G.ToString();
                    req_update_z_calidad.IT_CARACT[x + k].ESPECIE = "CEREZA";
                    x++;
                    */

                    /*

NOTA_CALIDAD
NOTA_CONDICION




                     */


                    i++;
                    k = 32 * i;
                    j = 2 * i;

                }


                responce_ZMOV_UPDATE_CALIDAD_LOTE res_1 = up_cal.sapRun(req_up_cal);
                responce_ZCALIDAD_CARACT_LOTES res_2 = update_z_calidad.sapRun(req_update_z_calidad);

                //return res;
                //

                try
                {
                    var request = (HttpWebRequest)WebRequest.Create("http://10.20.1.123/hana/ddc/saveReportFromIIS.php");

                    var postData = "data=" + Uri.EscapeDataString(text);
                    //postData += "&thing2=" + Uri.EscapeDataString("world");
                    var data = Encoding.ASCII.GetBytes(postData);

                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    string respuesta = responseString.ToString();

                    if (!respuesta.Contains("Correctamente"))
                    {
                        res.resultado = "NOK";
                        res.mensaje = "ERROR AL GRABAR EN SIMPLEAGRO: " + respuesta;
                        return res;
 
                    }



                }
                catch (Exception ex)
                {
                    res.resultado = "NOK";
                    res.mensaje = "ERROR AL GRABAR EN SIMPLEAGRO: " + ex.Message;
                    return res;
                   
                }

                res.resultado = "OK";
            }
            catch (Exception ex)
            {

                res.resultado = "NOK";
                res.mensaje = ex.Message;
            }

            return res;
        }
    }
    public class request_PTI_WS
    {
        public request_CABECERA cabecera;
        public request_DIS_COLOR color;
        public request_DIS_CALIBRE calibre;
        public request_DIS_FIRMEZA firmeza;
        public request_DEF_CONDICION condicion;
        public request_DEF_CALIDAD calidad;
        public request_RESUMEN resumen;



    }
    public class responce_PTI_WS
    {
        public String resultado;
        public String mensaje;

    }

    public class request_CABECERA
    {   
        public String exportadora;
        public String central;
        public String variedad;
        public String productor;
        public String huerto;
        public DateTime fecha_hora_recepcion;
        public int lote;
        public decimal temp_pulpa;
        public int numero_bandejas;
        public decimal kilos_netos;
        public String estiba_camion;
        public String esponjas_cloradas;
        public decimal solidos_solubles;    
        public decimal peso_muestra;

    }


    public class request_DIS_COLOR
    {
        public decimal falta_color;
        public decimal rojo_claro;
        public decimal rojo;
        public decimal rojo_caoba_3;
        public decimal rojo_claro_35;
        public decimal caoba_oscuro;
        public decimal negro;
        public decimal rojo_caoba_38;
        public decimal caoba_33;
    }

    public class request_DIS_CALIBRE
    {
        public decimal PCAL;
        public decimal L;
        public decimal XL;
        public decimal J;
        public decimal J2;
        public decimal J3;
        public decimal J4;
        public decimal J5;
    }
        public class request_DIS_FIRMEZA
    {
        public decimal blando;
        public decimal sensible;
        public decimal firme;
        public decimal muyfirme;
        public decimal N;
        public decimal durofel;
    }

    public class request_DEF_CONDICION
    {
        public decimal pudricion;
        public decimal mancha_parda;
        public decimal pitting;
        public decimal fruto_deshidratado;
        public decimal sobremadurez;
        public decimal machucon;
        public decimal machucon_hombro;
        public decimal fruta_blanda;
        public decimal heridas_abiertas;
        public decimal partidura_lateral;
        public decimal partidura_apical;
        public decimal medialuna;
        public decimal herida_insecto;
        public decimal otros;
        public decimal pudricion_seca;

    }

    public class request_DEF_CALIDAD
    {
        public decimal manchas;
        public decimal fruto_sin_pedicelo;
        public decimal pedicelo_deshidratado;
        public decimal frutos_doble;
        public decimal frutos_deformes;
        public decimal russet;
        public decimal heridas_cicatrizadas;
        public decimal golpe_sol;
        public decimal falta_color;
        public decimal danno_insecto;
        public decimal precalibre;
        public decimal tierra_residuos;
        public decimal virosis;
        public decimal otros;

    }

    public class request_RESUMEN
    {
        public decimal total_def_condicion;
        public decimal total_machucon;
        public String dano_cosecha;
        public String sensibilidad_partiduria;
        public String cuarentenario;
        public decimal total_def_calidad;
        public String nota_pedicelo;
        public String clasifica_proceso;
        public String segregacion;
        public String observaciones;


    }


}
