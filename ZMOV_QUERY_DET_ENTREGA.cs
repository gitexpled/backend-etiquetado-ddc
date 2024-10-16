using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_DET_ENTREGA
    {
        public responce_ZMOV_QUERY_DET_ENTREGA sapRun(request_ZMOV_QUERY_DET_ENTREGA import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_DET_ENTREGA");

            //rfcFunction.SetValue("I_VBELN", import.I_VBELN);
            IRfcTable rfcTable_I_VBELN_I = rfcFunction.GetTable("I_VBELN");
            foreach (ZMOV_QUERY_DET_ENTREGA_I_VBELN row in import.I_VBELN)
            {
                rfcTable_I_VBELN_I.Append();
                ZMOV_QUERY_DET_ENTREGA_I_VBELN datoTabla = new ZMOV_QUERY_DET_ENTREGA_I_VBELN();
                rfcTable_I_VBELN_I.SetValue("SIGN", row.SIGN);
                rfcTable_I_VBELN_I.SetValue("OPTION", row.OPTION);
                rfcTable_I_VBELN_I.SetValue("LOW", row.LOW);
                rfcTable_I_VBELN_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("I_VBELN", rfcTable_I_VBELN_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_DET_ENTREGA res = new responce_ZMOV_QUERY_DET_ENTREGA();
            IRfcTable rfcTable_I_VBELN = rfcFunction.GetTable("I_VBELN");
            res.I_VBELN = new ZMOV_QUERY_DET_ENTREGA_I_VBELN[rfcTable_I_VBELN.RowCount];
            int i_I_VBELN = 0;
            foreach (IRfcStructure row in rfcTable_I_VBELN)
            {
                ZMOV_QUERY_DET_ENTREGA_I_VBELN datoTabla = new ZMOV_QUERY_DET_ENTREGA_I_VBELN();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.I_VBELN[i_I_VBELN] = datoTabla; ++i_I_VBELN;
            }
            IRfcTable rfcTable_LOG = rfcFunction.GetTable("LOG");
            res.LOG = new ZMOV_QUERY_DET_ENTREGA_LOG[rfcTable_LOG.RowCount];
            int i_LOG = 0;
            foreach (IRfcStructure row in rfcTable_LOG)
            {
                ZMOV_QUERY_DET_ENTREGA_LOG datoTabla = new ZMOV_QUERY_DET_ENTREGA_LOG();
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
            res.LT_DETALLE = new ZMOV_QUERY_DET_ENTREGA_LT_DETALLE[rfcTable_LT_DETALLE.RowCount];
            int i_LT_DETALLE = 0;
            foreach (IRfcStructure row in rfcTable_LT_DETALLE)
            {
                ZMOV_QUERY_DET_ENTREGA_LT_DETALLE datoTabla = new ZMOV_QUERY_DET_ENTREGA_LT_DETALLE();
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
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.NETWR = row.GetDecimal("NETWR");
                datoTabla.WAERK = row.GetString("WAERK");
                datoTabla.NETWR_NC = row.GetDecimal("NETWR_NC");
                datoTabla.NETWR_ND = row.GetDecimal("NETWR_ND");
                datoTabla.FLETE = row.GetDecimal("FLETE");
                datoTabla.SEGURO = row.GetDecimal("SEGURO");
                datoTabla.WAERS = row.GetString("WAERS");
                datoTabla.EXIDV = row.GetString("EXIDV");
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
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                res.LT_DETALLE[i_LT_DETALLE] = datoTabla; ++i_LT_DETALLE;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_DET_ENTREGA
    {
        //public String I_VBELN;
        public ZMOV_QUERY_DET_ENTREGA_I_VBELN[] I_VBELN;
    }
    public class responce_ZMOV_QUERY_DET_ENTREGA
    {
        public ZMOV_QUERY_DET_ENTREGA_I_VBELN[] I_VBELN;
        public ZMOV_QUERY_DET_ENTREGA_LOG[] LOG;
        public ZMOV_QUERY_DET_ENTREGA_LT_DETALLE[] LT_DETALLE;
    }
    public class ZMOV_QUERY_DET_ENTREGA_I_VBELN
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_DET_ENTREGA_LOG
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
    public class ZMOV_QUERY_DET_ENTREGA_LT_DETALLE
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
        public String WERKS;
        public String LGORT;
        public Decimal NETWR;
        public String WAERK;
        public Decimal NETWR_NC;
        public Decimal NETWR_ND;
        public Decimal FLETE;
        public Decimal SEGURO;
        public String WAERS;
        public String EXIDV;
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
        public String ESPECIE;
        public String VARIEDAD;
        public String VARIEDAD_ET;
        public String CALIBRE;
        public String CALIDAD;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
    }

}