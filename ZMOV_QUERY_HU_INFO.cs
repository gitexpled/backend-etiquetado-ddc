using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_HU_INFO
    {
        public responce_ZMOV_QUERY_HU_INFO sapRun(request_ZMOV_QUERY_HU_INFO import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_HU_INFO");

            //rfcFunction.SetValue("IR_EXIDV", import.IR_EXIDV);
            IRfcTable rfcTable_IR_EXIDV_I = rfcFunction.GetTable("IR_EXIDV");
            foreach (ZMOV_QUERY_HU_INFO_IR_EXIDV row in import.IR_EXIDV)
            {
                rfcTable_IR_EXIDV_I.Append();
                ZMOV_QUERY_HU_INFO_IR_EXIDV datoTabla = new ZMOV_QUERY_HU_INFO_IR_EXIDV();
                rfcTable_IR_EXIDV_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_EXIDV_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_EXIDV_I.SetValue("LOW", row.LOW);
                rfcTable_IR_EXIDV_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("IR_EXIDV", rfcTable_IR_EXIDV_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_HU_INFO res = new responce_ZMOV_QUERY_HU_INFO();
            IRfcTable rfcTable_IR_EXIDV = rfcFunction.GetTable("IR_EXIDV");
            res.IR_EXIDV = new ZMOV_QUERY_HU_INFO_IR_EXIDV[rfcTable_IR_EXIDV.RowCount];
            int i_IR_EXIDV = 0;
            foreach (IRfcStructure row in rfcTable_IR_EXIDV)
            {
                ZMOV_QUERY_HU_INFO_IR_EXIDV datoTabla = new ZMOV_QUERY_HU_INFO_IR_EXIDV();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_EXIDV[i_IR_EXIDV] = datoTabla; ++i_IR_EXIDV;
            }
            IRfcTable rfcTable_LT_HU_CABECERA = rfcFunction.GetTable("LT_HU_CABECERA");
            res.LT_HU_CABECERA = new ZMOV_QUERY_HU_INFO_LT_HU_CABECERA[rfcTable_LT_HU_CABECERA.RowCount];
            int i_LT_HU_CABECERA = 0;
            foreach (IRfcStructure row in rfcTable_LT_HU_CABECERA)
            {
                ZMOV_QUERY_HU_INFO_LT_HU_CABECERA datoTabla = new ZMOV_QUERY_HU_INFO_LT_HU_CABECERA();
                datoTabla.EXIDV = row.GetString("EXIDV");
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
                datoTabla.VHILM = row.GetString("VHILM");
                datoTabla.INHALT = row.GetString("INHALT");
                datoTabla.EXIDV2 = row.GetString("EXIDV2");
                datoTabla.VPOBJ = row.GetString("VPOBJ");
                datoTabla.STATUS = row.GetString("STATUS");
                datoTabla.ZZFEC_INSP = row.GetString("ZZFEC_INSP");
                datoTabla.VEMNG = row.GetDecimal("VEMNG");
                datoTabla.VEMEH = row.GetString("VEMEH");
                //datoTabla.VENUM = row.GetString("VENUM");
                //datoTabla.VEPOS = row.GetInt("VEPOS");
                //datoTabla.VELIN = row.GetString("VELIN");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.STATUS_SYS = row.GetString("STATUS_SYS");
                datoTabla.ZCONS_PALLET = row.GetString("ZCONS_PALLET");
                //
                datoTabla.BRGEW = row.GetDecimal("BRGEW");
                datoTabla.NTGEW = row.GetDecimal("NTGEW");
                datoTabla.TARAG = row.GetDecimal("TARAG");
                datoTabla.ERDAT = row.GetString("ERDAT");
                datoTabla.KZGVH = row.GetString("KZGVH");
                datoTabla.ZZCLIENTE_DESTINO = row.GetString("ZZCLIENTE_DESTINO");
                datoTabla.ZZ_FINGFRI = row.GetString("ZZ_FINGFRI");
                datoTabla.ZZ_HINGFRI = row.GetString("ZZ_HINGFRI");
                datoTabla.ZZ_FSALFRI = row.GetString("ZZ_FSALFRI");
                datoTabla.ZZ_HSALFRI = row.GetString("ZZ_HSALFRI");
                datoTabla.ZZ_DURPRE = row.GetString("ZZ_DURPRE");
                datoTabla.ZZ_PREFRIO = row.GetString("ZZ_PREFRIO");

                res.LT_HU_CABECERA[i_LT_HU_CABECERA] = datoTabla; ++i_LT_HU_CABECERA;
            }
            IRfcTable rfcTable_LT_HU_POSICION = rfcFunction.GetTable("LT_HU_POSICION");
            res.LT_HU_POSICION = new ZMOV_QUERY_HU_INFO_LT_HU_POSICION[rfcTable_LT_HU_POSICION.RowCount];
            int i_LT_HU_POSICION = 0;
            foreach (IRfcStructure row in rfcTable_LT_HU_POSICION)
            {
                ZMOV_QUERY_HU_INFO_LT_HU_POSICION datoTabla = new ZMOV_QUERY_HU_INFO_LT_HU_POSICION();
                datoTabla.EXIDV = row.GetString("EXIDV");
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
                datoTabla.VHILM = row.GetString("VHILM");
                datoTabla.INHALT = row.GetString("INHALT");
                datoTabla.EXIDV2 = row.GetString("EXIDV2");
                datoTabla.VPOBJ = row.GetString("VPOBJ");
                datoTabla.STATUS = row.GetString("STATUS");
                datoTabla.ZZFEC_INSP = row.GetString("ZZFEC_INSP");
                datoTabla.VEMNG = row.GetDecimal("VEMNG");
                datoTabla.VEMEH = row.GetString("VEMEH");
                datoTabla.VENUM = row.GetString("VENUM");
                datoTabla.VEPOS = row.GetInt("VEPOS");
                datoTabla.VELIN = row.GetString("VELIN");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.SAG_CSP = row.GetString("SAG_CSP");
                datoTabla.FCOSECHA = row.GetString("FCOSECHA");
                res.LT_HU_POSICION[i_LT_HU_POSICION] = datoTabla; ++i_LT_HU_POSICION;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_HU_INFO
    {   
        public ZMOV_QUERY_HU_INFO_IR_EXIDV[] IR_EXIDV;
    }
    public class responce_ZMOV_QUERY_HU_INFO
    {
        public ZMOV_QUERY_HU_INFO_IR_EXIDV[] IR_EXIDV;
        public ZMOV_QUERY_HU_INFO_LT_HU_CABECERA[] LT_HU_CABECERA;
        public ZMOV_QUERY_HU_INFO_LT_HU_POSICION[] LT_HU_POSICION;
        public DateTime HoraServidor;
    }
    public class ZMOV_QUERY_HU_INFO_IR_EXIDV
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_HU_INFO_LT_HU_CABECERA
    {
        public String EXIDV;
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
        public String VHILM;
        public String INHALT;
        public String EXIDV2;
        public String VPOBJ;
        public String STATUS;
        public String ZZFEC_INSP;
        public Decimal VEMNG;
        public String VEMEH;
        public String VENUM;
        public Int32 VEPOS;
        public String VELIN;
        public String MATNR;
        public String MAKTX;
        public String WERKS;
        public String LGORT;
        public String VARIEDAD_ET;
        public String VARIEDAD;
        public String CALIBRE;
        public String CALIDAD;
        public String STATUS_SYS;
        public String ZCONS_PALLET;
        public Decimal BRGEW;
        public Decimal NTGEW;
        public Decimal TARAG;
        public String ERDAT;
        public String KZGVH;
        public String ZZCLIENTE_DESTINO;
        public String ZZ_FINGFRI;
        public String ZZ_HINGFRI;
        public String ZZ_FSALFRI;
        public String ZZ_HSALFRI;
        public String ZZ_DURPRE;
        public String ZZ_PREFRIO;
    }
    public class ZMOV_QUERY_HU_INFO_LT_HU_POSICION
    {
        public String EXIDV;
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
        public String VHILM;
        public String INHALT;
        public String EXIDV2;
        public String VPOBJ;
        public String STATUS;
        public String ZZFEC_INSP;
        public Decimal VEMNG;
        public String VEMEH;
        public String VENUM;
        public Int32 VEPOS;
        public String VELIN;
        public String MATNR;
        public String MAKTX;
        public String WERKS;
        public String LGORT;
        public String VARIEDAD_ET;
        public String VARIEDAD;
        public String CALIBRE;
        public String CALIDAD;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
        public String CHARG;
        public String HSDAT;
        public String SAG_CSP;
        public String FCOSECHA;
        public String ESPECIE;
    }

}