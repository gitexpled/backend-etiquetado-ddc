using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_PROCESO_RANGO_PRZ
    {
        public responce_ZMOV_PROCESO_RANGO_PRZ sapRun(request_ZMOV_PROCESO_RANGO_PRZ import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_PROCESO_RANGO_PRZ");

            //rfcFunction.SetValue("CHARG", import.CHARG);
            IRfcTable rfcTable_CHARG_I = rfcFunction.GetTable("CHARG");
            foreach (ZMOV_PROCESO_RANGO_PRZ_CHARG row in import.CHARG)
            {
                rfcTable_CHARG_I.Append();
                ZMOV_PROCESO_RANGO_PRZ_CHARG datoTabla = new ZMOV_PROCESO_RANGO_PRZ_CHARG();
                rfcTable_CHARG_I.SetValue("SIGN", row.SIGN);
                rfcTable_CHARG_I.SetValue("OPTION", row.OPTION);
                rfcTable_CHARG_I.SetValue("LOW", row.LOW);
                rfcTable_CHARG_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("CHARG", rfcTable_CHARG_I);
            rfcFunction.SetValue("IR_MATNR", import.IR_MATNR);
            rfcFunction.SetValue("MJAHR_F", import.MJAHR_F);
            rfcFunction.SetValue("MJAHR_I", import.MJAHR_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_PROCESO_RANGO_PRZ res = new responce_ZMOV_PROCESO_RANGO_PRZ();
            IRfcTable rfcTable_CHARG = rfcFunction.GetTable("CHARG");
            res.CHARG = new ZMOV_PROCESO_RANGO_PRZ_CHARG[rfcTable_CHARG.RowCount];
            int i_CHARG = 0;
            foreach (IRfcStructure row in rfcTable_CHARG)
            {
                ZMOV_PROCESO_RANGO_PRZ_CHARG datoTabla = new ZMOV_PROCESO_RANGO_PRZ_CHARG();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.CHARG[i_CHARG] = datoTabla; ++i_CHARG;
            }
            IRfcTable rfcTable_IR_MATNR = rfcFunction.GetTable("IR_MATNR");
            res.IR_MATNR = new ZMOV_PROCESO_RANGO_PRZ_IR_MATNR[rfcTable_IR_MATNR.RowCount];
            int i_IR_MATNR = 0;
            foreach (IRfcStructure row in rfcTable_IR_MATNR)
            {
                ZMOV_PROCESO_RANGO_PRZ_IR_MATNR datoTabla = new ZMOV_PROCESO_RANGO_PRZ_IR_MATNR();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MATNR[i_IR_MATNR] = datoTabla; ++i_IR_MATNR;
            }
            IRfcTable rfcTable_INGRESO_PROCESO = rfcFunction.GetTable("INGRESO_PROCESO");
            res.INGRESO_PROCESO = new ZMOV_PROCESO_RANGO_PRZ_INGRESO_PROCESO[rfcTable_INGRESO_PROCESO.RowCount];
            int i_INGRESO_PROCESO = 0;
            foreach (IRfcStructure row in rfcTable_INGRESO_PROCESO)
            {
                ZMOV_PROCESO_RANGO_PRZ_INGRESO_PROCESO datoTabla = new ZMOV_PROCESO_RANGO_PRZ_INGRESO_PROCESO();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.MBLNR = row.GetString("MBLNR");
                datoTabla.XBLNR = row.GetString("XBLNR");
                datoTabla.BUDAT = row.GetString("BUDAT");
                datoTabla.ERFMG = row.GetDecimal("ERFMG");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.NAME1 = row.GetString("NAME1");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.PORCENTAJE = row.GetDecimal("PORCENTAJE");
                datoTabla.CATEGORIA = row.GetString("CATEGORIA");
                datoTabla.FORMATO = row.GetString("FORMATO");
                datoTabla.TIPO = row.GetString("TIPO");
                datoTabla.CLASE = row.GetString("CLASE");
                datoTabla.UMCHA_I = row.GetString("UMCHA_I");
                datoTabla.KILOS_PROCESO = row.GetDecimal("KILOS_PROCESO");
                datoTabla.KILOS_RESULTADO = row.GetDecimal("KILOS_RESULTADO");
                res.INGRESO_PROCESO[i_INGRESO_PROCESO] = datoTabla; ++i_INGRESO_PROCESO;
            }
            IRfcTable rfcTable_SALIDA_PROCESO = rfcFunction.GetTable("SALIDA_PROCESO");
            res.SALIDA_PROCESO = new ZMOV_PROCESO_RANGO_PRZ_SALIDA_PROCESO[rfcTable_SALIDA_PROCESO.RowCount];
            int i_SALIDA_PROCESO = 0;
            foreach (IRfcStructure row in rfcTable_SALIDA_PROCESO)
            {
                ZMOV_PROCESO_RANGO_PRZ_SALIDA_PROCESO datoTabla = new ZMOV_PROCESO_RANGO_PRZ_SALIDA_PROCESO();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.MBLNR = row.GetString("MBLNR");
                datoTabla.XBLNR = row.GetString("XBLNR");
                datoTabla.BUDAT = row.GetString("BUDAT");
                datoTabla.ZEILE = row.GetInt("ZEILE");
                datoTabla.LINE_ID = row.GetInt("LINE_ID");
                datoTabla.PARENT_ID = row.GetInt("PARENT_ID");
                datoTabla.MENGE = row.GetDecimal("MENGE");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.ERFMG = row.GetDecimal("ERFMG");
                datoTabla.ERFME = row.GetString("ERFME");
                datoTabla.BPMNG = row.GetDecimal("BPMNG");
                datoTabla.BPRME = row.GetString("BPRME");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.COD_VARIEDAD = row.GetString("COD_VARIEDAD");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.COD_VARIEDAD_ET = row.GetString("COD_VARIEDAD_ET");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.PORCENTAJE = row.GetDecimal("PORCENTAJE");
                datoTabla.TIPO = row.GetString("TIPO");
                datoTabla.FORMATO = row.GetString("FORMATO");
                datoTabla.CLASE = row.GetString("CLASE");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CATEGORIA = row.GetString("CATEGORIA");
                datoTabla.UMCHA_I = row.GetString("UMCHA_I");
                datoTabla.KILOS_PROCESO = row.GetDecimal("KILOS_PROCESO");
                datoTabla.KILOS_RESULTADO = row.GetDecimal("KILOS_RESULTADO");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.TIP_CALIBRE = row.GetString("TIP_CALIBRE");
                datoTabla.LINEA = row.GetString("LINEA");
                datoTabla.TURNO = row.GetString("TURNO");
                datoTabla.TFRIO = row.GetString("TFRIO");
                res.SALIDA_PROCESO[i_SALIDA_PROCESO] = datoTabla; ++i_SALIDA_PROCESO;
            }

            return res;
        }
    }
    public class request_ZMOV_PROCESO_RANGO_PRZ
    {
        //public String CHARG;
        public ZMOV_PROCESO_RANGO_PRZ_CHARG[] CHARG;
        public String IR_MATNR;
        public Int32 MJAHR_F;
        public Int32 MJAHR_I;
    }
    public class responce_ZMOV_PROCESO_RANGO_PRZ
    {
        public ZMOV_PROCESO_RANGO_PRZ_CHARG[] CHARG;
        public ZMOV_PROCESO_RANGO_PRZ_IR_MATNR[] IR_MATNR;
        public ZMOV_PROCESO_RANGO_PRZ_INGRESO_PROCESO[] INGRESO_PROCESO;
        public ZMOV_PROCESO_RANGO_PRZ_SALIDA_PROCESO[] SALIDA_PROCESO;
    }
    public class ZMOV_PROCESO_RANGO_PRZ_CHARG
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_PROCESO_RANGO_PRZ_IR_MATNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_PROCESO_RANGO_PRZ_INGRESO_PROCESO
    {
        public String MATNR;
        public String ESPECIE;
        public String CHARG;
        public String MBLNR;
        public String XBLNR;
        public String BUDAT;
        public Decimal ERFMG;
        public String MAKTX;
        public String LIFNR;
        public String NAME1;
        public String VARIEDAD;
        public Decimal PORCENTAJE;
        public String CATEGORIA;
        public String FORMATO;
        public String TIPO;
        public String CLASE;
        public String UMCHA_I;
        public Decimal KILOS_PROCESO;
        public Decimal KILOS_RESULTADO;
    }
    public class ZMOV_PROCESO_RANGO_PRZ_SALIDA_PROCESO
    {
        public String MATNR;
        public String ESPECIE;
        public String CHARG;
        public String MBLNR;
        public String XBLNR;
        public String BUDAT;
        public Int32 ZEILE;
        public Int32 LINE_ID;
        public Int32 PARENT_ID;
        public Decimal MENGE;
        public String MEINS;
        public Decimal ERFMG;
        public String ERFME;
        public Decimal BPMNG;
        public String BPRME;
        public String MAKTX;
        public String LIFNR;
        public String COD_VARIEDAD;
        public String VARIEDAD;
        public String COD_VARIEDAD_ET;
        public String VARIEDAD_ET;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
        public Decimal PORCENTAJE;
        public String TIPO;
        public String FORMATO;
        public String CLASE;
        public String CALIBRE;
        public String CATEGORIA;
        public String UMCHA_I;
        public Decimal KILOS_PROCESO;
        public Decimal KILOS_RESULTADO;
        public String CALIDAD;
        public String TIP_CALIBRE;
        public String LINEA;
        public String TURNO;
        public String TFRIO;
    }

}