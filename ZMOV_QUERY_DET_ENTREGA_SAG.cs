using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_DET_ENTREGA_SAG
    {
        public responce_ZMOV_QUERY_DET_ENTREGA_SAG sapRun(request_ZMOV_QUERY_DET_ENTREGA_SAG import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_DET_ENTREGA_SAG");

            //rfcFunction.SetValue("I_VBELN", import.I_VBELN);
            IRfcTable rfcTable_I_VBELN_I = rfcFunction.GetTable("I_VBELN");
            foreach (ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN row in import.I_VBELN)
            {
                rfcTable_I_VBELN_I.Append();
                ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN datoTabla = new ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN();
                rfcTable_I_VBELN_I.SetValue("SIGN", row.SIGN);
                rfcTable_I_VBELN_I.SetValue("OPTION", row.OPTION);
                rfcTable_I_VBELN_I.SetValue("LOW", row.LOW);
                rfcTable_I_VBELN_I.SetValue("HIGH", row.HIGH);
            }
            //rfcFunction.SetValue("I_VBELN", rfcTable_I_VBELN_I);
            IRfcTable rfcTable_LT_DETALLE_I = rfcFunction.GetTable("LT_DETALLE");
            if (import.LT_DETALLE != null)
            {
                foreach (ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE row in import.LT_DETALLE)
                {
                    rfcTable_LT_DETALLE_I.Append();
                    ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE datoTabla = new ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE();
                    rfcTable_LT_DETALLE_I.SetValue("VBELN", row.VBELN);
                    rfcTable_LT_DETALLE_I.SetValue("POSNR", row.POSNR);
                    rfcTable_LT_DETALLE_I.SetValue("VEMNG", row.VEMNG);
                    rfcTable_LT_DETALLE_I.SetValue("VEMEH", row.VEMEH);
                    rfcTable_LT_DETALLE_I.SetValue("NTGEW", row.NTGEW);
                    rfcTable_LT_DETALLE_I.SetValue("GEWEI", row.GEWEI);
                    rfcTable_LT_DETALLE_I.SetValue("MATNR", row.MATNR);
                    rfcTable_LT_DETALLE_I.SetValue("MAKTX", row.MAKTX);
                    rfcTable_LT_DETALLE_I.SetValue("NTGEW_MAT", row.NTGEW_MAT);
                    rfcTable_LT_DETALLE_I.SetValue("GEWEI_MAT", row.GEWEI_MAT);
                    rfcTable_LT_DETALLE_I.SetValue("CHARG", row.CHARG);
                    rfcTable_LT_DETALLE_I.SetValue("WERKS", row.WERKS);
                    rfcTable_LT_DETALLE_I.SetValue("LGORT", row.LGORT);
                    rfcTable_LT_DETALLE_I.SetValue("NETWR", row.NETWR);
                    rfcTable_LT_DETALLE_I.SetValue("WAERK", row.WAERK);
                    rfcTable_LT_DETALLE_I.SetValue("NETWR_NC", row.NETWR_NC);
                    rfcTable_LT_DETALLE_I.SetValue("NETWR_ND", row.NETWR_ND);
                    rfcTable_LT_DETALLE_I.SetValue("VENUM", row.VENUM);
                    rfcTable_LT_DETALLE_I.SetValue("EXIDV", row.EXIDV);
                    rfcTable_LT_DETALLE_I.SetValue("EXIDV2", row.EXIDV2);
                    rfcTable_LT_DETALLE_I.SetValue("INHALT", row.INHALT);
                    rfcTable_LT_DETALLE_I.SetValue("VEGR1", row.VEGR1);
                    rfcTable_LT_DETALLE_I.SetValue("BEZEI_VEGR1", row.BEZEI_VEGR1);
                    rfcTable_LT_DETALLE_I.SetValue("VEGR2", row.VEGR2);
                    rfcTable_LT_DETALLE_I.SetValue("BEZEI_VEGR2", row.BEZEI_VEGR2);
                    rfcTable_LT_DETALLE_I.SetValue("VEGR3", row.VEGR3);
                    rfcTable_LT_DETALLE_I.SetValue("BEZEI_VEGR3", row.BEZEI_VEGR3);
                    rfcTable_LT_DETALLE_I.SetValue("VEGR4", row.VEGR4);
                    rfcTable_LT_DETALLE_I.SetValue("BEZEI_VEGR4", row.BEZEI_VEGR4);
                    rfcTable_LT_DETALLE_I.SetValue("VEGR5", row.VEGR5);
                    rfcTable_LT_DETALLE_I.SetValue("BEZEI_VEGR5", row.BEZEI_VEGR5);
                    rfcTable_LT_DETALLE_I.SetValue("ZZFEC_INSP", row.ZZFEC_INSP);
                    rfcTable_LT_DETALLE_I.SetValue("INCO1", row.INCO1);
                    rfcTable_LT_DETALLE_I.SetValue("INCO2", row.INCO2);
                    rfcTable_LT_DETALLE_I.SetValue("EXPKZ", row.EXPKZ);
                    rfcTable_LT_DETALLE_I.SetValue("ROUTE", row.ROUTE);
                    rfcTable_LT_DETALLE_I.SetValue("BEZEI_ROUTE", row.BEZEI_ROUTE);
                    rfcTable_LT_DETALLE_I.SetValue("VSTEL", row.VSTEL);
                    rfcTable_LT_DETALLE_I.SetValue("KUNNR", row.KUNNR);
                    rfcTable_LT_DETALLE_I.SetValue("NAME_KUNNR", row.NAME_KUNNR);
                    rfcTable_LT_DETALLE_I.SetValue("KUNAG", row.KUNAG);
                    rfcTable_LT_DETALLE_I.SetValue("NAME_KUNAG", row.NAME_KUNAG);
                    rfcTable_LT_DETALLE_I.SetValue("TRATY", row.TRATY);
                    rfcTable_LT_DETALLE_I.SetValue("NAME_TRATY", row.NAME_TRATY);
                    rfcTable_LT_DETALLE_I.SetValue("VTEXT_TRATY", row.VTEXT_TRATY);
                    rfcTable_LT_DETALLE_I.SetValue("WADAT_IST", row.WADAT_IST);
                    rfcTable_LT_DETALLE_I.SetValue("WEEK_WADAT_IST", row.WEEK_WADAT_IST);
                    rfcTable_LT_DETALLE_I.SetValue("WADAT", row.WADAT);
                    rfcTable_LT_DETALLE_I.SetValue("WEEK_WADAT", row.WEEK_WADAT);
                    rfcTable_LT_DETALLE_I.SetValue("VSART", row.VSART);
                    rfcTable_LT_DETALLE_I.SetValue("BEZEI_VSART", row.BEZEI_VSART);
                    rfcTable_LT_DETALLE_I.SetValue("SDABW", row.SDABW);
                    rfcTable_LT_DETALLE_I.SetValue("BEZEI_SDABW", row.BEZEI_SDABW);
                    rfcTable_LT_DETALLE_I.SetValue("ZZNUMSELLO", row.ZZNUMSELLO);
                    rfcTable_LT_DETALLE_I.SetValue("ZZCHOFER", row.ZZCHOFER);
                    rfcTable_LT_DETALLE_I.SetValue("ZZRUT", row.ZZRUT);
                    rfcTable_LT_DETALLE_I.SetValue("ZZNOTRACTOR", row.ZZNOTRACTOR);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPATENTE", row.ZZPATENTE);
                    rfcTable_LT_DETALLE_I.SetValue("ZZREFERENCIA", row.ZZREFERENCIA);
                    rfcTable_LT_DETALLE_I.SetValue("ZZDUS", row.ZZDUS);
                    rfcTable_LT_DETALLE_I.SetValue("ZZNCIF", row.ZZNCIF);
                    rfcTable_LT_DETALLE_I.SetValue("ZZMODOTRANSP", row.ZZMODOTRANSP);
                    rfcTable_LT_DETALLE_I.SetValue("DDTEXT_ZZMODOTRANSP", row.DDTEXT_ZZMODOTRANSP);
                    rfcTable_LT_DETALLE_I.SetValue("ZZADUANASALIDA", row.ZZADUANASALIDA);
                    rfcTable_LT_DETALLE_I.SetValue("DDTEXT_ZZADUANASALIDA", row.DDTEXT_ZZADUANASALIDA);
                    rfcTable_LT_DETALLE_I.SetValue("ZZMATEMB", row.ZZMATEMB);
                    rfcTable_LT_DETALLE_I.SetValue("ZZAGENTEADUANA", row.ZZAGENTEADUANA);
                    rfcTable_LT_DETALLE_I.SetValue("ZZDATADIC", row.ZZDATADIC);
                    rfcTable_LT_DETALLE_I.SetValue("ZZNAVE_EMB", row.ZZNAVE_EMB);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPUERTO_DES", row.ZZPUERTO_DES);
                    rfcTable_LT_DETALLE_I.SetValue("ZZCODAGENCIA", row.ZZCODAGENCIA);
                    rfcTable_LT_DETALLE_I.SetValue("ZZVGM", row.ZZVGM);
                    rfcTable_LT_DETALLE_I.SetValue("ZZCONSIGNATARIO", row.ZZCONSIGNATARIO);
                    rfcTable_LT_DETALLE_I.SetValue("ZZCONTENEDOR", row.ZZCONTENEDOR);
                    rfcTable_LT_DETALLE_I.SetValue("DDTEXT_ZZAGENTEADUANA", row.DDTEXT_ZZAGENTEADUANA);
                    rfcTable_LT_DETALLE_I.SetValue("RUT_AGEADU", row.RUT_AGEADU);
                    rfcTable_LT_DETALLE_I.SetValue("TKNUM", row.TKNUM);
                    rfcTable_LT_DETALLE_I.SetValue("XBLNR", row.XBLNR);
                    rfcTable_LT_DETALLE_I.SetValue("ESPECIE", row.ESPECIE);
                    rfcTable_LT_DETALLE_I.SetValue("VARIEDAD", row.VARIEDAD);
                    rfcTable_LT_DETALLE_I.SetValue("VARIEDAD_ET", row.VARIEDAD_ET);
                    rfcTable_LT_DETALLE_I.SetValue("CALIBRE", row.CALIBRE);
                    rfcTable_LT_DETALLE_I.SetValue("CALIDAD", row.CALIDAD);
                    rfcTable_LT_DETALLE_I.SetValue("PRODUCTOR", row.PRODUCTOR);
                    rfcTable_LT_DETALLE_I.SetValue("NOMBRE_PRODUCTOR", row.NOMBRE_PRODUCTOR);
                    rfcTable_LT_DETALLE_I.SetValue("PRODUCTOR_ET", row.PRODUCTOR_ET);
                    rfcTable_LT_DETALLE_I.SetValue("NOMBRE_PRODUCTOR_ET", row.NOMBRE_PRODUCTOR_ET);
                    rfcTable_LT_DETALLE_I.SetValue("LIFNR_PROVINCIA", row.LIFNR_PROVINCIA);
                    rfcTable_LT_DETALLE_I.SetValue("LIFNR_ET_PROVINCIA", row.LIFNR_ET_PROVINCIA);
                    rfcTable_LT_DETALLE_I.SetValue("LIFNR_COMUNA", row.LIFNR_COMUNA);
                    rfcTable_LT_DETALLE_I.SetValue("LIFNR_ET_COMUNA", row.LIFNR_ET_COMUNA);
                    rfcTable_LT_DETALLE_I.SetValue("SAG_SDP", row.SAG_SDP);
                    rfcTable_LT_DETALLE_I.SetValue("SAG_CSG", row.SAG_CSG);
                    rfcTable_LT_DETALLE_I.SetValue("HSDAT", row.HSDAT);
                    rfcTable_LT_DETALLE_I.SetValue("WERKS_NAME", row.WERKS_NAME);
                    rfcTable_LT_DETALLE_I.SetValue("WERKS_CSP", row.WERKS_CSP);
                    rfcTable_LT_DETALLE_I.SetValue("WERKS_PROVINCIA", row.WERKS_PROVINCIA);
                    rfcTable_LT_DETALLE_I.SetValue("WERKS_COMUNA", row.WERKS_COMUNA);
                    rfcTable_LT_DETALLE_I.SetValue("SAG_CSP_PACKING", row.SAG_CSP_PACKING);
                    rfcTable_LT_DETALLE_I.SetValue("SAG_CSP", row.SAG_CSP);
                    rfcTable_LT_DETALLE_I.SetValue("SAG_CSP_PROVINCIA", row.SAG_CSP_PROVINCIA);
                    rfcTable_LT_DETALLE_I.SetValue("SAG_CSP_COMUNA", row.SAG_CSP_COMUNA);
                    rfcTable_LT_DETALLE_I.SetValue("EMBALA", row.EMBALA);
                    rfcTable_LT_DETALLE_I.SetValue("NAME1", row.NAME1);
                    rfcTable_LT_DETALLE_I.SetValue("NAME1_ET", row.NAME1_ET);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP1", row.ZZPAIS_INSP1);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP2", row.ZZPAIS_INSP2);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP3", row.ZZPAIS_INSP3);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP4", row.ZZPAIS_INSP4);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP5", row.ZZPAIS_INSP5);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP6", row.ZZPAIS_INSP6);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP7", row.ZZPAIS_INSP7);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP8", row.ZZPAIS_INSP8);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP9", row.ZZPAIS_INSP9);
                    rfcTable_LT_DETALLE_I.SetValue("ZZPAIS_INSP10", row.ZZPAIS_INSP10);
                    rfcTable_LT_DETALLE_I.SetValue("GLOSA_PAIS", row.GLOSA_PAIS);
                    rfcTable_LT_DETALLE_I.SetValue("SIGNI", row.SIGNI);
                }
            }
            rfcFunction.SetValue("LT_DETALLE", rfcTable_LT_DETALLE_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_DET_ENTREGA_SAG res = new responce_ZMOV_QUERY_DET_ENTREGA_SAG();
            IRfcTable rfcTable_I_VBELN = rfcFunction.GetTable("I_VBELN");
            res.I_VBELN = new ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN[rfcTable_I_VBELN.RowCount];
            int i_I_VBELN = 0;
            foreach (IRfcStructure row in rfcTable_I_VBELN)
            {
                ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN datoTabla = new ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.I_VBELN[i_I_VBELN] = datoTabla; ++i_I_VBELN;
            }
            IRfcTable rfcTable_LOG = rfcFunction.GetTable("LOG");
            res.LOG = new ZMOV_QUERY_DET_ENTREGA_SAG_LOG[rfcTable_LOG.RowCount];
            int i_LOG = 0;
            foreach (IRfcStructure row in rfcTable_LOG)
            {
                ZMOV_QUERY_DET_ENTREGA_SAG_LOG datoTabla = new ZMOV_QUERY_DET_ENTREGA_SAG_LOG();
                datoTabla.TYPE = row.GetString("TYPE");
                datoTabla.ID = row.GetString("ID");
                datoTabla.NUMBER = row.GetInt("NUMBER");
                datoTabla.MESSAGE = row.GetString("MESSAGE");
                datoTabla.LOG_NO = row.GetString("LOG_NO");
                datoTabla.LOG_MSG_NO = row.GetInt("LOG_MSG_NO");
                datoTabla.MESSAGE_V1 = row.GetString("MESSAGE_V1");
                datoTabla.MESSAGE_V2 = row.GetString("MESSAGE_V2");
                datoTabla.MESSAGE_V3 = row.GetString("MESSAGE_V3");
                datoTabla.MESSAGE_V4 = row.GetString("MESSAGE_V4");
                datoTabla.PARAMETER = row.GetString("PARAMETER");
                datoTabla.ROW = row.GetInt("ROW");
                datoTabla.FIELD = row.GetString("FIELD");
                datoTabla.SYSTEM = row.GetString("SYSTEM");
                res.LOG[i_LOG] = datoTabla; ++i_LOG;
            }
            IRfcTable rfcTable_LT_DETALLE = rfcFunction.GetTable("LT_DETALLE");
            res.LT_DETALLE = new ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE[rfcTable_LT_DETALLE.RowCount];
            int i_LT_DETALLE = 0;
            foreach (IRfcStructure row in rfcTable_LT_DETALLE)
            {
                ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE datoTabla = new ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE();
                datoTabla.VBELN = row.GetString("VBELN");
                datoTabla.POSNR = row.GetInt("POSNR");
                datoTabla.VEMNG = row.GetDecimal("VEMNG");
                datoTabla.VEMEH = row.GetString("VEMEH");
                datoTabla.NTGEW = row.GetDecimal("NTGEW");
                datoTabla.GEWEI = row.GetString("GEWEI");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.NTGEW_MAT = row.GetDecimal("NTGEW_MAT");
                datoTabla.GEWEI_MAT = row.GetString("GEWEI_MAT");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.NETWR = row.GetDecimal("NETWR");
                datoTabla.WAERK = row.GetString("WAERK");
                datoTabla.NETWR_NC = row.GetDecimal("NETWR_NC");
                datoTabla.NETWR_ND = row.GetDecimal("NETWR_ND");
                datoTabla.VENUM = row.GetString("VENUM");
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.EXIDV2 = row.GetString("EXIDV2");
                datoTabla.INHALT = row.GetString("INHALT");
                datoTabla.VEGR1 = row.GetString("VEGR1");
                datoTabla.BEZEI_VEGR1 = row.GetString("BEZEI_VEGR1");
                datoTabla.VEGR2 = row.GetString("VEGR2");
                datoTabla.BEZEI_VEGR2 = row.GetString("BEZEI_VEGR2");
                datoTabla.VEGR3 = row.GetString("VEGR3");
                datoTabla.BEZEI_VEGR3 = row.GetString("BEZEI_VEGR3");
                datoTabla.VEGR4 = row.GetString("VEGR4");
                datoTabla.BEZEI_VEGR4 = row.GetString("BEZEI_VEGR4");
                datoTabla.VEGR5 = row.GetString("VEGR5");
                datoTabla.BEZEI_VEGR5 = row.GetString("BEZEI_VEGR5");
                datoTabla.ZZFEC_INSP = row.GetString("ZZFEC_INSP");
                datoTabla.INCO1 = row.GetString("INCO1");
                datoTabla.INCO2 = row.GetString("INCO2");
                datoTabla.EXPKZ = row.GetString("EXPKZ");
                datoTabla.ROUTE = row.GetString("ROUTE");
                datoTabla.BEZEI_ROUTE = row.GetString("BEZEI_ROUTE");
                datoTabla.VSTEL = row.GetString("VSTEL");
                datoTabla.KUNNR = row.GetString("KUNNR");
                datoTabla.NAME_KUNNR = row.GetString("NAME_KUNNR");
                datoTabla.KUNAG = row.GetString("KUNAG");
                datoTabla.NAME_KUNAG = row.GetString("NAME_KUNAG");
                datoTabla.TRATY = row.GetString("TRATY");
                datoTabla.NAME_TRATY = row.GetString("NAME_TRATY");
                datoTabla.VTEXT_TRATY = row.GetString("VTEXT_TRATY");
                datoTabla.WADAT_IST = row.GetString("WADAT_IST");
                datoTabla.WEEK_WADAT_IST = row.GetString("WEEK_WADAT_IST");
                datoTabla.WADAT = row.GetString("WADAT");
                datoTabla.WEEK_WADAT = row.GetString("WEEK_WADAT");
                datoTabla.VSART = row.GetString("VSART");
                datoTabla.BEZEI_VSART = row.GetString("BEZEI_VSART");
                datoTabla.SDABW = row.GetString("SDABW");
                datoTabla.BEZEI_SDABW = row.GetString("BEZEI_SDABW");
                datoTabla.ZZNUMSELLO = row.GetString("ZZNUMSELLO");
                datoTabla.ZZCHOFER = row.GetString("ZZCHOFER");
                datoTabla.ZZRUT = row.GetString("ZZRUT");
                datoTabla.ZZNOTRACTOR = row.GetString("ZZNOTRACTOR");
                datoTabla.ZZPATENTE = row.GetString("ZZPATENTE");
                datoTabla.ZZREFERENCIA = row.GetString("ZZREFERENCIA");
                datoTabla.ZZDUS = row.GetString("ZZDUS");
                datoTabla.ZZNCIF = row.GetInt("ZZNCIF");
                datoTabla.ZZMODOTRANSP = row.GetString("ZZMODOTRANSP");
                datoTabla.DDTEXT_ZZMODOTRANSP = row.GetString("DDTEXT_ZZMODOTRANSP");
                datoTabla.ZZADUANASALIDA = row.GetString("ZZADUANASALIDA");
                datoTabla.DDTEXT_ZZADUANASALIDA = row.GetString("DDTEXT_ZZADUANASALIDA");
                datoTabla.ZZMATEMB = row.GetInt("ZZMATEMB");
                datoTabla.ZZAGENTEADUANA = row.GetString("ZZAGENTEADUANA");
                datoTabla.ZZDATADIC = row.GetString("ZZDATADIC");
                datoTabla.ZZNAVE_EMB = row.GetString("ZZNAVE_EMB");
                datoTabla.ZZPUERTO_DES = row.GetString("ZZPUERTO_DES");
                datoTabla.ZZCODAGENCIA = row.GetString("ZZCODAGENCIA");
                datoTabla.ZZVGM = row.GetString("ZZVGM");
                datoTabla.ZZCONSIGNATARIO = row.GetString("ZZCONSIGNATARIO");
                datoTabla.ZZCONTENEDOR = row.GetString("ZZCONTENEDOR");
                datoTabla.DDTEXT_ZZAGENTEADUANA = row.GetString("DDTEXT_ZZAGENTEADUANA");
                datoTabla.RUT_AGEADU = row.GetString("RUT_AGEADU");
                datoTabla.TKNUM = row.GetString("TKNUM");
                datoTabla.XBLNR = row.GetString("XBLNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.LIFNR_PROVINCIA = row.GetString("LIFNR_PROVINCIA");
                datoTabla.LIFNR_ET_PROVINCIA = row.GetString("LIFNR_ET_PROVINCIA");
                datoTabla.LIFNR_COMUNA = row.GetString("LIFNR_COMUNA");
                datoTabla.LIFNR_ET_COMUNA = row.GetString("LIFNR_ET_COMUNA");
                datoTabla.SAG_SDP = row.GetString("SAG_SDP");
                datoTabla.SAG_CSG = row.GetString("SAG_CSG");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.WERKS_NAME = row.GetString("WERKS_NAME");
                datoTabla.WERKS_CSP = row.GetString("WERKS_CSP");
                datoTabla.WERKS_PROVINCIA = row.GetString("WERKS_PROVINCIA");
                datoTabla.WERKS_COMUNA = row.GetString("WERKS_COMUNA");
                datoTabla.SAG_CSP_PACKING = row.GetString("SAG_CSP_PACKING");
                datoTabla.SAG_CSP = row.GetString("SAG_CSP");
                datoTabla.SAG_CSP_PROVINCIA = row.GetString("SAG_CSP_PROVINCIA");
                datoTabla.SAG_CSP_COMUNA = row.GetString("SAG_CSP_COMUNA");
                datoTabla.EMBALA = row.GetString("EMBALA");
                datoTabla.NAME1 = row.GetString("NAME1");
                datoTabla.NAME1_ET = row.GetString("NAME1_ET");
                datoTabla.ZZPAIS_INSP1 = row.GetString("ZZPAIS_INSP1");
                datoTabla.ZZPAIS_INSP2 = row.GetString("ZZPAIS_INSP2");
                datoTabla.ZZPAIS_INSP3 = row.GetString("ZZPAIS_INSP3");
                datoTabla.ZZPAIS_INSP4 = row.GetString("ZZPAIS_INSP4");
                datoTabla.ZZPAIS_INSP5 = row.GetString("ZZPAIS_INSP5");
                datoTabla.ZZPAIS_INSP6 = row.GetString("ZZPAIS_INSP6");
                datoTabla.ZZPAIS_INSP7 = row.GetString("ZZPAIS_INSP7");
                datoTabla.ZZPAIS_INSP8 = row.GetString("ZZPAIS_INSP8");
                datoTabla.ZZPAIS_INSP9 = row.GetString("ZZPAIS_INSP9");
                datoTabla.ZZPAIS_INSP10 = row.GetString("ZZPAIS_INSP10");
                datoTabla.GLOSA_PAIS = row.GetString("GLOSA_PAIS");
                datoTabla.SIGNI = row.GetString("SIGNI");
                datoTabla.ZZRECIBIDOR = row.GetString("ZZRECIBIDOR");
                datoTabla.ZZBOOKING = row.GetString("ZZBOOKING");
                datoTabla.ZZNGUIA = row.GetString("ZZNGUIA");
                res.LT_DETALLE[i_LT_DETALLE] = datoTabla; ++i_LT_DETALLE;
            }
            IRfcTable rfcTable_LT_DETALLE_HU = rfcFunction.GetTable("LT_DETALLE_HU");
            res.LT_DETALLE_HU = new ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE_HU[rfcTable_LT_DETALLE_HU.RowCount];
            int i_LT_DETALLE_HU = 0;
            foreach (IRfcStructure row in rfcTable_LT_DETALLE_HU)
            {
                ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE_HU datoTabla = new ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE_HU();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.NTGEW = row.GetDecimal("NTGEW");
                datoTabla.VEMNG = row.GetDecimal("VEMNG");
                res.LT_DETALLE_HU[i_LT_DETALLE_HU] = datoTabla; ++i_LT_DETALLE_HU;
            }
            return res;
        }
    }
    public class request_ZMOV_QUERY_DET_ENTREGA_SAG
    {
        //public String I_VBELN;
        public ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN[] I_VBELN;
        public ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE[] LT_DETALLE;
    }
    public class responce_ZMOV_QUERY_DET_ENTREGA_SAG
    {
        public ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN[] I_VBELN;
        public ZMOV_QUERY_DET_ENTREGA_SAG_LOG[] LOG;
        public ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE[] LT_DETALLE;
        public ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE_HU[] LT_DETALLE_HU;
    }
    public class ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE_HU
    {
        public String EXIDV;
        public Decimal NTGEW;
        public Decimal VEMNG;
    }
    public class ZMOV_QUERY_DET_ENTREGA_SAG_I_VBELN
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_DET_ENTREGA_SAG_LOG
    {
        public String TYPE;
        public String ID;
        public Int32 NUMBER;
        public String MESSAGE;
        public String LOG_NO;
        public Int32 LOG_MSG_NO;
        public String MESSAGE_V1;
        public String MESSAGE_V2;
        public String MESSAGE_V3;
        public String MESSAGE_V4;
        public String PARAMETER;
        public Int32 ROW;
        public String FIELD;
        public String SYSTEM;
    }
    public class ZMOV_QUERY_DET_ENTREGA_SAG_LT_DETALLE
    {
        public String VBELN;
        public Int32 POSNR;
        public Decimal VEMNG;
        public String VEMEH;
        public Decimal NTGEW;
        public String GEWEI;
        public String MATNR;
        public String MAKTX;
        public Decimal NTGEW_MAT;
        public String GEWEI_MAT;
        public String CHARG;
        public String WERKS;
        public String LGORT;
        public Decimal NETWR;
        public String WAERK;
        public Decimal NETWR_NC;
        public Decimal NETWR_ND;
        public String VENUM;
        public String EXIDV;
        public String EXIDV2;
        public String INHALT;
        public String VEGR1;
        public String BEZEI_VEGR1;
        public String VEGR2;
        public String BEZEI_VEGR2;
        public String VEGR3;
        public String BEZEI_VEGR3;
        public String VEGR4;
        public String BEZEI_VEGR4;
        public String VEGR5;
        public String BEZEI_VEGR5;
        public String ZZFEC_INSP;
        public String INCO1;
        public String INCO2;
        public String EXPKZ;
        public String ROUTE;
        public String BEZEI_ROUTE;
        public String VSTEL;
        public String KUNNR;
        public String NAME_KUNNR;
        public String KUNAG;
        public String NAME_KUNAG;
        public String TRATY;
        public String NAME_TRATY;
        public String VTEXT_TRATY;
        public String WADAT_IST;
        public String WEEK_WADAT_IST;
        public String WADAT;
        public String WEEK_WADAT;
        public String VSART;
        public String BEZEI_VSART;
        public String SDABW;
        public String BEZEI_SDABW;
        public String ZZNUMSELLO;
        public String ZZCHOFER;
        public String ZZRUT;
        public String ZZNOTRACTOR;
        public String ZZPATENTE;
        public String ZZREFERENCIA;
        public String ZZDUS;
        public Int32 ZZNCIF;
        public String ZZMODOTRANSP;
        public String DDTEXT_ZZMODOTRANSP;
        public String ZZADUANASALIDA;
        public String DDTEXT_ZZADUANASALIDA;
        public Int32 ZZMATEMB;
        public String ZZAGENTEADUANA;
        public String ZZDATADIC;
        public String ZZNAVE_EMB;
        public String ZZPUERTO_DES;
        public String ZZCODAGENCIA;
        public String ZZVGM;
        public String ZZCONSIGNATARIO;
        public String ZZCONTENEDOR;
        public String DDTEXT_ZZAGENTEADUANA;
        public String RUT_AGEADU;
        public String TKNUM;
        public String XBLNR;
        public String ESPECIE;
        public String VARIEDAD;
        public String VARIEDAD_ET;
        public String CALIBRE;
        public String CALIDAD;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
        public String LIFNR_PROVINCIA;
        public String LIFNR_ET_PROVINCIA;
        public String LIFNR_COMUNA;
        public String LIFNR_ET_COMUNA;
        public String SAG_SDP;
        public String SAG_CSG;
        public String HSDAT;
        public String WERKS_NAME;
        public String WERKS_CSP;
        public String WERKS_PROVINCIA;
        public String WERKS_COMUNA;
        public String SAG_CSP_PACKING;
        public String SAG_CSP;
        public String SAG_CSP_PROVINCIA;
        public String SAG_CSP_COMUNA;
        public String EMBALA;
        public String NAME1;
        public String NAME1_ET;
        public String ZZPAIS_INSP1;
        public String ZZPAIS_INSP2;
        public String ZZPAIS_INSP3;
        public String ZZPAIS_INSP4;
        public String ZZPAIS_INSP5;
        public String ZZPAIS_INSP6;
        public String ZZPAIS_INSP7;
        public String ZZPAIS_INSP8;
        public String ZZPAIS_INSP9;
        public String ZZPAIS_INSP10;
        public String GLOSA_PAIS;
        public String SIGNI;
        public String ZZRECIBIDOR;
        public String ZZBOOKING;
        public String ZZNGUIA;
    }

}