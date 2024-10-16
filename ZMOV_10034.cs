using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10034
    {
        public responce_ZMOV_10034 sapRun(request_ZMOV_10034 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10034");
            IRfcTable rfcTable_IR_EXIDV_I = rfcFunction.GetTable("IR_EXIDV");
            foreach (ZMOV_10034_IR_EXIDV row in import.IR_EXIDV)
            {
                rfcTable_IR_EXIDV_I.Append();
                ZMOV_10034_IR_EXIDV datoTabla = new ZMOV_10034_IR_EXIDV();
                rfcTable_IR_EXIDV_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_EXIDV_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_EXIDV_I.SetValue("LOW", row.LOW);
                rfcTable_IR_EXIDV_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("IR_EXIDV", rfcTable_IR_EXIDV_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10034 res = new responce_ZMOV_10034();
            IRfcTable rfcTable_IR_EXIDV = rfcFunction.GetTable("IR_EXIDV");
            res.IR_EXIDV = new ZMOV_10034_IR_EXIDV[rfcTable_IR_EXIDV.RowCount];
            int i_IR_EXIDV = 0;
            foreach (IRfcStructure row in rfcTable_IR_EXIDV)
            {
                ZMOV_10034_IR_EXIDV datoTabla = new ZMOV_10034_IR_EXIDV();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_EXIDV[i_IR_EXIDV] = datoTabla; ++i_IR_EXIDV;
            }
            IRfcTable rfcTable_LT_HU_CABECERA = rfcFunction.GetTable("LT_HU_CABECERA");
            res.LT_HU_CABECERA = new ZMOV_10034_LT_HU_CABECERA[rfcTable_LT_HU_CABECERA.RowCount];
            int i_LT_HU_CABECERA = 0;
            foreach (IRfcStructure row in rfcTable_LT_HU_CABECERA)
            {
                ZMOV_10034_LT_HU_CABECERA datoTabla = new ZMOV_10034_LT_HU_CABECERA();
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
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.STATUS_SYS = row.GetString("STATUS_SYS");
                datoTabla.ZZ_HU_GUIA = row.GetInt("ZZ_HU_GUIA");
                datoTabla.ZZ_HU_TEMP_A_PACK = row.GetString("ZZ_HU_TEMP_A_PACK");
                datoTabla.ZZ_HU_TEMP_PULP_PACK = row.GetString("ZZ_HU_TEMP_PULP_PACK");
                datoTabla.ZZ_HU_TIEMP_TRASL = row.GetString("ZZ_HU_TIEMP_TRASL");
                datoTabla.ZZ_HU_TEMP_RECEP = row.GetString("ZZ_HU_TEMP_RECEP");
                datoTabla.ZZ_HU_FECH_ING_TUNEL = row.GetString("ZZ_HU_FECH_ING_TUNEL");
                datoTabla.ZZ_HU_HR_ING_TUNEL = row.GetString("ZZ_HU_HR_ING_TUNEL");
                datoTabla.ZZ_HU_NRO_TUNEL = row.GetString("ZZ_HU_NRO_TUNEL");
                datoTabla.ZZ_HU_TEMP_ENT_TUNEL = row.GetString("ZZ_HU_TEMP_ENT_TUNEL");
                datoTabla.ZZ_HU_TEMP_SAL_TUNEL = row.GetString("ZZ_HU_TEMP_SAL_TUNEL");
                datoTabla.ZZ_HU_FECH_SAL_TUNEL = row.GetString("ZZ_HU_FECH_SAL_TUNEL");
                datoTabla.ZZ_HU_HR_SAL_TUNEL = row.GetString("ZZ_HU_HR_SAL_TUNEL");
                datoTabla.ZZ_HU_NRO_CAMARA = row.GetString("ZZ_HU_NRO_CAMARA");
                datoTabla.ZZ_HU_TEMP_AMB1 = row.GetString("ZZ_HU_TEMP_AMB1");
                datoTabla.ZZ_HU_TEMP_AMB2 = row.GetString("ZZ_HU_TEMP_AMB2");
                datoTabla.ZZ_HU_TEMP_AMB3 = row.GetString("ZZ_HU_TEMP_AMB3");
                datoTabla.ZZ_HU_TEMP_PULP1 = row.GetString("ZZ_HU_TEMP_PULP1");
                datoTabla.ZZ_HU_TEMP_PULP2 = row.GetString("ZZ_HU_TEMP_PULP2");
                datoTabla.ZZ_HU_TEMP_PULP3 = row.GetString("ZZ_HU_TEMP_PULP3");
                datoTabla.ZZ_HU_TIPO_CAMION = row.GetString("ZZ_HU_TIPO_CAMION");
                datoTabla.ZZ_HU_FECH_LLEG_CAM = row.GetString("ZZ_HU_FECH_LLEG_CAM");
                datoTabla.ZZ_HU_HR_LLEG_CAM = row.GetString("ZZ_HU_HR_LLEG_CAM");
                datoTabla.ZZ_HU_FECH_S_CAM = row.GetString("ZZ_HU_FECH_S_CAM");
                datoTabla.ZZ_HU_HR_S_CAM = row.GetString("ZZ_HU_HR_S_CAM");
                datoTabla.ZZ_HU_OBSERVACION = row.GetString("ZZ_HU_OBSERVACION");
                datoTabla.ZZ_HU_HR_INGR_PLANTA = row.GetString("ZZ_HU_HR_INGR_PLANTA");
                datoTabla.ZZ_HU_TEMP_3HR_TUNEL = row.GetString("ZZ_HU_TEMP_3HR_TUNEL");
                datoTabla.ZZ_HU_TEMP_DESP_INVER = row.GetString("ZZ_HU_TEMP_DESP_INVER");
                res.LT_HU_CABECERA[i_LT_HU_CABECERA] = datoTabla; ++i_LT_HU_CABECERA;
            }
            IRfcTable rfcTable_LT_HU_POSICION = rfcFunction.GetTable("LT_HU_POSICION");
            res.LT_HU_POSICION = new ZMOV_10034_LT_HU_POSICION[rfcTable_LT_HU_POSICION.RowCount];
            int i_LT_HU_POSICION = 0;
            foreach (IRfcStructure row in rfcTable_LT_HU_POSICION)
            {
                ZMOV_10034_LT_HU_POSICION datoTabla = new ZMOV_10034_LT_HU_POSICION();
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
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                res.LT_HU_POSICION[i_LT_HU_POSICION] = datoTabla; ++i_LT_HU_POSICION;
            }

            return res;
        }
    }
    public class request_ZMOV_10034
    {
        public ZMOV_10034_IR_EXIDV[] IR_EXIDV;
    }
    public class responce_ZMOV_10034
    {
        public ZMOV_10034_IR_EXIDV[] IR_EXIDV;
        public ZMOV_10034_LT_HU_CABECERA[] LT_HU_CABECERA;
        public ZMOV_10034_LT_HU_POSICION[] LT_HU_POSICION;
    }
    public class ZMOV_10034_IR_EXIDV
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10034_LT_HU_CABECERA
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
        public String MATNR;
        public String MAKTX;
        public String WERKS;
        public String LGORT;
        public String ESPECIE;
        public String VARIEDAD_ET;
        public String VARIEDAD;
        public String CALIBRE;
        public String CALIDAD;
        public String PRODUCTOR;
        public String PRODUCTOR_ET;
        public String STATUS_SYS;
        public Int32 ZZ_HU_GUIA;
        public String ZZ_HU_TEMP_A_PACK;
        public String ZZ_HU_TEMP_PULP_PACK;
        public String ZZ_HU_TIEMP_TRASL;
        public String ZZ_HU_TEMP_RECEP;
        public String ZZ_HU_FECH_ING_TUNEL;
        public String ZZ_HU_HR_ING_TUNEL;
        public String ZZ_HU_NRO_TUNEL;
        public String ZZ_HU_TEMP_ENT_TUNEL;
        public String ZZ_HU_TEMP_SAL_TUNEL;
        public String ZZ_HU_FECH_SAL_TUNEL;
        public String ZZ_HU_HR_SAL_TUNEL;
        public String ZZ_HU_NRO_CAMARA;
        public String ZZ_HU_TEMP_AMB1;
        public String ZZ_HU_TEMP_AMB2;
        public String ZZ_HU_TEMP_AMB3;
        public String ZZ_HU_TEMP_PULP1;
        public String ZZ_HU_TEMP_PULP2;
        public String ZZ_HU_TEMP_PULP3;
        public String ZZ_HU_TIPO_CAMION;
        public String ZZ_HU_FECH_LLEG_CAM;
        public String ZZ_HU_HR_LLEG_CAM;
        public String ZZ_HU_FECH_S_CAM;
        public String ZZ_HU_HR_S_CAM;
        public String ZZ_HU_OBSERVACION;
        public String ZZ_HU_HR_INGR_PLANTA;
        public String ZZ_HU_TEMP_3HR_TUNEL;
        public String ZZ_HU_TEMP_DESP_INVER;
    }
    public class ZMOV_10034_LT_HU_POSICION
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
        public String ESPECIE;
    }

}