using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZDDCRP_PROCESO
    {
        public responce_ZDDCRP_PROCESO sapRun(request_ZDDCRP_PROCESO import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZDDCRP_PROCESO");

            rfcFunction.SetValue("CHARG", import.CHARG);
            rfcFunction.SetValue("MATNR", import.MATNR);
            rfcFunction.SetValue("MJAHR_F", import.MJAHR_F);
            rfcFunction.SetValue("MJAHR_I", import.MJAHR_I);
            //rfcFunction.SetValue("ZRANGO_MOVIMIENTO", import.ZRANGO_MOVIMIENTO);
            IRfcTable rfcTable_ZRANGO_MOVIMIENTO = rfcFunction.GetTable("ZRANGO_MOVIMIENTO");
            foreach (ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO row in import.ZRANGO_MOVIMIENTO)
            {
                rfcTable_ZRANGO_MOVIMIENTO.Append();
                ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO datoTabla = new ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO();
                rfcTable_ZRANGO_MOVIMIENTO.SetValue("BWART", row.BWART);
            }
            rfcFunction.SetValue("ZRANGO_MOVIMIENTO", rfcTable_ZRANGO_MOVIMIENTO);

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZDDCRP_PROCESO res = new responce_ZDDCRP_PROCESO();
            IRfcStructure export = rfcFunction.GetStructure("EXPORT");
            ZDDCRP_PROCESO_EXPORT structExport = new ZDDCRP_PROCESO_EXPORT();
            structExport.BUDAT = export.GetString("BUDAT");
            structExport.CHARG = export.GetString("CHARG");
            structExport.ESPECIE = export.GetString("ESPECIE");
            structExport.KILOS_DESCARTE = export.GetString("KILOS_DESCARTE");
            structExport.KILOS_PROCESO = export.GetString("KILOS_PROCESO");
            structExport.KILOS_RESULTADO = export.GetString("KILOS_RESULTADO");
            structExport.PORC_RESULTADO = export.GetString("PORC_RESULTADO");
            structExport.PROCESADORA = export.GetString("PROCESADORA");
            structExport.HORA_INICIO_PROCESO = export.GetString("HORA_INICIO_PROCESO");
            structExport.FECHA_INICIO_PROCESO = export.GetString("FECHA_INICIO_PROCESO");


            res.EXPORT = structExport;
            
            IRfcTable rfcTable_INGRESO_PROCESO = rfcFunction.GetTable("INGRESO_PROCESO");
            res.INGRESO_PROCESO = new ZDDCRP_PROCESO_INGRESO_PROCESO[rfcTable_INGRESO_PROCESO.RowCount];
            int i_INGRESO_PROCESO = 0;
            foreach (IRfcStructure row in rfcTable_INGRESO_PROCESO)
            {
                ZDDCRP_PROCESO_INGRESO_PROCESO datoTabla = new ZDDCRP_PROCESO_INGRESO_PROCESO();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.MBLNR = row.GetString("MBLNR");
                datoTabla.XBLNR = row.GetString("XBLNR");
                datoTabla.BUDAT = row.GetString("BUDAT");
                if (row.GetString("BWART") == "310" || row.GetString("BWART") == "262" || row.GetString("BWART") == "542")
                {
                    datoTabla.ERFMG = row.GetDecimal("ERFMG") * -1;
                    
                }
                else
                {
                    datoTabla.ERFMG = row.GetDecimal("ERFMG");
                }
                
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.NAME1 = row.GetString("NAME1");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                
                datoTabla.CATEGORIA = row.GetString("CATEGORIA");
                datoTabla.FORMATO = row.GetString("FORMATO");
                datoTabla.TIPO = row.GetString("TIPO");
                datoTabla.CLASE = row.GetString("CLASE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.BWART = row.GetString("BWART");
                res.INGRESO_PROCESO[i_INGRESO_PROCESO] = datoTabla; ++i_INGRESO_PROCESO;
            }
            IRfcTable rfcTable_SALIDA_PROCESO = rfcFunction.GetTable("SALIDA_PROCESO");
            res.SALIDA_PROCESO = new ZDDCRP_PROCESO_SALIDA_PROCESO[rfcTable_SALIDA_PROCESO.RowCount];
            int i_SALIDA_PROCESO = 0;
            foreach (IRfcStructure row in rfcTable_SALIDA_PROCESO)
            {
                ZDDCRP_PROCESO_SALIDA_PROCESO datoTabla = new ZDDCRP_PROCESO_SALIDA_PROCESO();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.MBLNR = row.GetString("MBLNR");
                datoTabla.XBLNR = row.GetString("XBLNR");
                datoTabla.BUDAT = row.GetString("BUDAT");
                datoTabla.ZEILE = row.GetInt("ZEILE");
                datoTabla.LINE_ID = row.GetInt("LINE_ID");
                datoTabla.PARENT_ID = row.GetInt("PARENT_ID");
                
                datoTabla.MEINS = row.GetString("MEINS");
                //datoTabla.ERFMG = row.GetDecimal("ERFMG");
                if (row.GetString("BWART") == "262" || row.GetString("BWART") == "544")
                {
                    datoTabla.ERFMG = row.GetDecimal("ERFMG") * -1;
                    datoTabla.PORCENTAJE = row.GetDecimal("PORCENTAJE") * -1;
                    datoTabla.BPMNG = row.GetDecimal("BPMNG") * -1;
                    datoTabla.MENGE = row.GetDecimal("MENGE") * -1;
                }
                else
                {
                    datoTabla.ERFMG = row.GetDecimal("ERFMG");
                    datoTabla.PORCENTAJE = row.GetDecimal("PORCENTAJE");
                    datoTabla.BPMNG = row.GetDecimal("BPMNG");
                    datoTabla.MENGE = row.GetDecimal("MENGE");
                }
                datoTabla.ERFME = row.GetString("ERFME");
                
                datoTabla.BPRME = row.GetString("BPRME");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                
                datoTabla.TIPO = row.GetString("TIPO");
                datoTabla.FORMATO = row.GetString("FORMATO");
                datoTabla.CLASE = row.GetString("CLASE");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CATEGORIA = row.GetString("CATEGORIA");
                datoTabla.ZNUEZ_CLASIF_BDJA = row.GetString("ZNUEZ_CLASIF_BDJA");
                datoTabla.ZNUEZ_CLASIF_ENV = row.GetString("ZNUEZ_CLASIF_ENV");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                res.SALIDA_PROCESO[i_SALIDA_PROCESO] = datoTabla; ++i_SALIDA_PROCESO;
            }


           
            
            return res;
        }
    }
    public class request_ZDDCRP_PROCESO
    {
        public ZDDCRP_PROCESO_EXPORT EXPORT;
        public String CHARG;
        public String MATNR;
        public Int32 MJAHR_F;
        public Int32 MJAHR_I;
        public ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO[] ZRANGO_MOVIMIENTO;
    }
    public class responce_ZDDCRP_PROCESO
    {
        //public ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO[] ZRANGO_MOVIMIENTO;
        public ZDDCRP_PROCESO_INGRESO_PROCESO[] INGRESO_PROCESO;
        public ZDDCRP_PROCESO_SALIDA_PROCESO[] SALIDA_PROCESO;
        public ZDDCRP_PROCESO_EXPORT EXPORT;
    }
    public class ZDDCRP_PROCESO_ZRANGO_MOVIMIENTO
    {
        public String BWART;
    }
    public class ZDDCRP_PROCESO_EXPORT
    {
        public String PROCESADORA;
        public String TIPO_PROCESO;
        public String CHARG;
        public String BUDAT;
        public String KILOS_PROCESO;
        public String KILOS_RESULTADO;
        public String KILOS_DESCARTE;
        public String PORC_RESULTADO;
        public String ESPECIE;
        public String VARIEDAD;
        public String HORA_INICIO_PROCESO;
        public String FECHA_INICIO_PROCESO;

            
    }
    public class ZDDCRP_PROCESO_INGRESO_PROCESO
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
        public String BWART;
    }
    public class ZDDCRP_PROCESO_SALIDA_PROCESO
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