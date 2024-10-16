using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZDDCRP_PROCESO_PRZ
    {
        public responce_ZDDCRP_PROCESO_PRZ sapRun(request_ZDDCRP_PROCESO_PRZ import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZDDCRP_PROCESO_PRZ");

            rfcFunction.SetValue("CHARG", import.CHARG);
            rfcFunction.SetValue("MATNR", import.MATNR);
            rfcFunction.SetValue("MJAHR_F", import.MJAHR_F);
            rfcFunction.SetValue("MJAHR_I", import.MJAHR_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZDDCRP_PROCESO_PRZ res = new responce_ZDDCRP_PROCESO_PRZ();
            //res.EXPORT = rfcFunction.GetString("EXPORT");
            IRfcTable rfcTable_EXPORT = rfcFunction.GetTable("EXPORT");
            res.EXPORT = new ZDDCRP_PROCESO_PRZ_EXPORT[rfcTable_EXPORT.RowCount];
            int i_EXPORT = 0;
            foreach (IRfcStructure row in rfcTable_EXPORT)
            {
                ZDDCRP_PROCESO_PRZ_EXPORT datoTabla = new ZDDCRP_PROCESO_PRZ_EXPORT();
                datoTabla.PROCESADORA = row.GetString("PROCESADORA");
                datoTabla.TIPO_PROCESO = row.GetString("TIPO_PROCESO");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.BUDAT = row.GetString("BUDAT");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.KILOS_PROCESO = row.GetDecimal("KILOS_PROCESO");
                datoTabla.KILOS_RESULTADO = row.GetDecimal("KILOS_RESULTADO");
                datoTabla.KILOS_DESCARTE = row.GetDecimal("KILOS_DESCARTE");
                datoTabla.PORC_RESULTADO = row.GetDecimal("PORC_RESULTADO");
                res.EXPORT[i_EXPORT] = datoTabla; ++i_EXPORT;
            }
            IRfcTable rfcTable_INGRESO_PROCESO = rfcFunction.GetTable("INGRESO_PROCESO");
            res.INGRESO_PROCESO = new ZDDCRP_PROCESO_PRZ_INGRESO_PROCESO[rfcTable_INGRESO_PROCESO.RowCount];
            int i_INGRESO_PROCESO = 0;
            foreach (IRfcStructure row in rfcTable_INGRESO_PROCESO)
            {
                ZDDCRP_PROCESO_PRZ_INGRESO_PROCESO datoTabla = new ZDDCRP_PROCESO_PRZ_INGRESO_PROCESO();
                datoTabla.MATNR = row.GetString("MATNR");
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
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                res.INGRESO_PROCESO[i_INGRESO_PROCESO] = datoTabla; ++i_INGRESO_PROCESO;
            }
            IRfcTable rfcTable_SALIDA_PROCESO_RE = rfcFunction.GetTable("SALIDA_PROCESO_RE");
            res.SALIDA_PROCESO_RE = new ZDDCRP_PROCESO_PRZ_SALIDA_PROCESO_RE[rfcTable_SALIDA_PROCESO_RE.RowCount];
            int i_SALIDA_PROCESO_RE = 0;
            foreach (IRfcStructure row in rfcTable_SALIDA_PROCESO_RE)
            {
                ZDDCRP_PROCESO_PRZ_SALIDA_PROCESO_RE datoTabla = new ZDDCRP_PROCESO_PRZ_SALIDA_PROCESO_RE();
                datoTabla.MATNR = row.GetString("MATNR");
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
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.PORCENTAJE = row.GetDecimal("PORCENTAJE");
                datoTabla.TIPO = row.GetString("TIPO");
                datoTabla.FORMATO = row.GetString("FORMATO");
                datoTabla.CLASE = row.GetString("CLASE");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CATEGORIA = row.GetString("CATEGORIA");
                datoTabla.ZNUEZ_CLASIF_BDJA = row.GetString("ZNUEZ_CLASIF_BDJA");
                datoTabla.ZNUEZ_CLASIF_ENV = row.GetString("ZNUEZ_CLASIF_ENV");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                res.SALIDA_PROCESO_RE[i_SALIDA_PROCESO_RE] = datoTabla; ++i_SALIDA_PROCESO_RE;
            }

            return res;
        }
    }
    public class request_ZDDCRP_PROCESO_PRZ
    {
        public String CHARG;
        public String MATNR;
        public Int32 MJAHR_F;
        public Int32 MJAHR_I;
    }
    public class responce_ZDDCRP_PROCESO_PRZ
    {
        //public String EXPORT;
        public ZDDCRP_PROCESO_PRZ_EXPORT[] EXPORT;
        public ZDDCRP_PROCESO_PRZ_INGRESO_PROCESO[] INGRESO_PROCESO;
        public ZDDCRP_PROCESO_PRZ_SALIDA_PROCESO_RE[] SALIDA_PROCESO_RE;
    }
    public class ZDDCRP_PROCESO_PRZ_EXPORT
    {
        public String PROCESADORA;
        public String TIPO_PROCESO;
        public String CHARG;
        public String BUDAT;
        public String ESPECIE;
        public String VARIEDAD;
        public Decimal KILOS_PROCESO;
        public Decimal KILOS_RESULTADO;
        public Decimal KILOS_DESCARTE;
        public Decimal PORC_RESULTADO;
    }
    public class ZDDCRP_PROCESO_PRZ_INGRESO_PROCESO
    {
        public String MATNR;
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
        public String CALIDAD;
    }
    public class ZDDCRP_PROCESO_PRZ_SALIDA_PROCESO_RE
    {
        public String MATNR;
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
        public String VARIEDAD;
        public String VARIEDAD_ET;
        public Decimal PORCENTAJE;
        public String TIPO;
        public String FORMATO;
        public String CLASE;
        public String CALIBRE;
        public String CATEGORIA;
        public String ZNUEZ_CLASIF_BDJA;
        public String ZNUEZ_CLASIF_ENV;
        public String CALIDAD;
    }

}