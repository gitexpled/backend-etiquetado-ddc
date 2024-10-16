using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10001
    {
        public responce_ZMOV_10001 sapRun(request_ZMOV_10001 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10001");

            IRfcTable rfcTable_IR_ATKLA_I = rfcFunction.GetTable("IR_ATKLA");
            if (import.IR_ATKLA != null)
            {
                foreach (ZMOV_10001_IR_ATKLA row in import.IR_ATKLA)
                {
                    rfcTable_IR_ATKLA_I.Append();
                    ZMOV_10001_IR_ATKLA datoTabla = new ZMOV_10001_IR_ATKLA();
                    rfcTable_IR_ATKLA_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IR_ATKLA_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_ATKLA_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_ATKLA_I.SetValue("HIGH", row.HIGH);
                }   
            }
            
            rfcFunction.SetValue("IR_ATKLA", rfcTable_IR_ATKLA_I);

            IRfcTable rfcTable_IR_ATNAM_I = rfcFunction.GetTable("IR_ATNAM");
            if (import.IR_ATNAM != null)
            {
                foreach (ZMOV_10001_IR_ATNAM row in import.IR_ATNAM)
                {
                    rfcTable_IR_ATNAM_I.Append();
                    ZMOV_10001_IR_ATNAM datoTabla = new ZMOV_10001_IR_ATNAM();
                    rfcTable_IR_ATNAM_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IR_ATNAM_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_ATNAM_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_ATNAM_I.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("IR_ATNAM", rfcTable_IR_ATNAM_I);

            IRfcTable rfcTable_IR_CHARG_I = rfcFunction.GetTable("IR_CHARG");
            if (import.IR_CHARG != null)
            {
                foreach (ZMOV_10001_IR_CHARG row in import.IR_CHARG)
                {
                    rfcTable_IR_CHARG_I.Append();
                    ZMOV_10001_IR_CHARG datoTabla = new ZMOV_10001_IR_CHARG();
                    rfcTable_IR_CHARG_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IR_CHARG_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_CHARG_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_CHARG_I.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("IR_CHARG", rfcTable_IR_CHARG_I);

            IRfcTable rfcTable_IR_ESPECIE_I = rfcFunction.GetTable("IR_ESPECIE");
            if (import.IR_ESPECIE != null)
            {
                foreach (ZMOV_10001_IR_ESPECIE row in import.IR_ESPECIE)
                {
                    rfcTable_IR_ESPECIE_I.Append();
                    ZMOV_10001_IR_ESPECIE datoTabla = new ZMOV_10001_IR_ESPECIE();
                    rfcTable_IR_ESPECIE_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IR_ESPECIE_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_ESPECIE_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_ESPECIE_I.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("IR_ESPECIE", rfcTable_IR_ESPECIE_I);

            IRfcTable rfcTable_IR_ETIQUETA_I = rfcFunction.GetTable("IR_ETIQUETA");
            if (import.IR_ETIQUETA != null)
            {
                foreach (ZMOV_10001_IR_ETIQUETA row in import.IR_ETIQUETA)
                {
                    rfcTable_IR_ETIQUETA_I.Append();
                    ZMOV_10001_IR_ETIQUETA datoTabla = new ZMOV_10001_IR_ETIQUETA();
                    rfcTable_IR_ETIQUETA_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IR_ETIQUETA_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_ETIQUETA_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_ETIQUETA_I.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("IR_ETIQUETA", rfcTable_IR_ETIQUETA_I);

            IRfcTable rfcTable_IR_FORMATO_I = rfcFunction.GetTable("IR_FORMATO");
            rfcFunction.SetValue("IR_FORMATO", rfcTable_IR_FORMATO_I);

            IRfcTable rfcTable_IR_LGORT_I = rfcFunction.GetTable("IR_LGORT");
            rfcFunction.SetValue("IR_LGORT", rfcTable_IR_LGORT_I);

            IRfcTable rfcTable_IR_MANEJO_I = rfcFunction.GetTable("IR_MANEJO");
            rfcFunction.SetValue("IR_MANEJO", import.IR_MANEJO);

            IRfcTable rfcTable_IR_MATNR_I = rfcFunction.GetTable("IR_MATNR");
            rfcFunction.SetValue("IR_MATNR", rfcTable_IR_MATNR_I);

            IRfcTable rfcTable_IR_MTART_I = rfcFunction.GetTable("IR_MTART");
            rfcFunction.SetValue("IR_MTART", import.IR_MTART);

            IRfcTable rfcTable_IR_PAIS_I = rfcFunction.GetTable("IR_PAIS");
            rfcFunction.SetValue("IR_PAIS", rfcTable_IR_PAIS_I);

            IRfcTable rfcTable_IR_TIPO_I = rfcFunction.GetTable("IR_TIPO");
            rfcFunction.SetValue("IR_TIPO", rfcTable_IR_TIPO_I);

            IRfcTable rfcTable_IR_WERKS_I = rfcFunction.GetTable("IR_WERKS");
            rfcFunction.SetValue("IR_WERKS", rfcTable_IR_WERKS_I);

            rfcFunction.SetValue("IV_LIB_UTIL", import.IV_LIB_UTIL);
            rfcFunction.SetValue("IV_SPRAS", import.IV_SPRAS);
            rfcFunction.SetValue("I_CLASE", import.I_CLASE);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10001 res = new responce_ZMOV_10001();
            IRfcTable rfcTable_IR_ATKLA = rfcFunction.GetTable("IR_ATKLA");
            res.IR_ATKLA = new ZMOV_10001_IR_ATKLA[rfcTable_IR_ATKLA.RowCount];
            int i_IR_ATKLA = 0;
            foreach (IRfcStructure row in rfcTable_IR_ATKLA)
            {
                ZMOV_10001_IR_ATKLA datoTabla = new ZMOV_10001_IR_ATKLA();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_ATKLA[i_IR_ATKLA] = datoTabla; ++i_IR_ATKLA;
            }
            IRfcTable rfcTable_IR_ATNAM = rfcFunction.GetTable("IR_ATNAM");
            res.IR_ATNAM = new ZMOV_10001_IR_ATNAM[rfcTable_IR_ATNAM.RowCount];
            int i_IR_ATNAM = 0;
            foreach (IRfcStructure row in rfcTable_IR_ATNAM)
            {
                ZMOV_10001_IR_ATNAM datoTabla = new ZMOV_10001_IR_ATNAM();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_ATNAM[i_IR_ATNAM] = datoTabla; ++i_IR_ATNAM;
            }
            IRfcTable rfcTable_IR_CHARG = rfcFunction.GetTable("IR_CHARG");
            res.IR_CHARG = new ZMOV_10001_IR_CHARG[rfcTable_IR_CHARG.RowCount];
            int i_IR_CHARG = 0;
            foreach (IRfcStructure row in rfcTable_IR_CHARG)
            {
                ZMOV_10001_IR_CHARG datoTabla = new ZMOV_10001_IR_CHARG();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_CHARG[i_IR_CHARG] = datoTabla; ++i_IR_CHARG;
            }
            IRfcTable rfcTable_IR_ESPECIE = rfcFunction.GetTable("IR_ESPECIE");
            res.IR_ESPECIE = new ZMOV_10001_IR_ESPECIE[rfcTable_IR_ESPECIE.RowCount];
            int i_IR_ESPECIE = 0;
            foreach (IRfcStructure row in rfcTable_IR_ESPECIE)
            {
                ZMOV_10001_IR_ESPECIE datoTabla = new ZMOV_10001_IR_ESPECIE();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_ESPECIE[i_IR_ESPECIE] = datoTabla; ++i_IR_ESPECIE;
            }
            IRfcTable rfcTable_IR_ETIQUETA = rfcFunction.GetTable("IR_ETIQUETA");
            res.IR_ETIQUETA = new ZMOV_10001_IR_ETIQUETA[rfcTable_IR_ETIQUETA.RowCount];
            int i_IR_ETIQUETA = 0;
            foreach (IRfcStructure row in rfcTable_IR_ETIQUETA)
            {
                ZMOV_10001_IR_ETIQUETA datoTabla = new ZMOV_10001_IR_ETIQUETA();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_ETIQUETA[i_IR_ETIQUETA] = datoTabla; ++i_IR_ETIQUETA;
            }
            IRfcTable rfcTable_IR_FORMATO = rfcFunction.GetTable("IR_FORMATO");
            res.IR_FORMATO = new ZMOV_10001_IR_FORMATO[rfcTable_IR_FORMATO.RowCount];
            int i_IR_FORMATO = 0;
            foreach (IRfcStructure row in rfcTable_IR_FORMATO)
            {
                ZMOV_10001_IR_FORMATO datoTabla = new ZMOV_10001_IR_FORMATO();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_FORMATO[i_IR_FORMATO] = datoTabla; ++i_IR_FORMATO;
            }
            IRfcTable rfcTable_IR_LGORT = rfcFunction.GetTable("IR_LGORT");
            res.IR_LGORT = new ZMOV_10001_IR_LGORT[rfcTable_IR_LGORT.RowCount];
            int i_IR_LGORT = 0;
            foreach (IRfcStructure row in rfcTable_IR_LGORT)
            {
                ZMOV_10001_IR_LGORT datoTabla = new ZMOV_10001_IR_LGORT();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.STLOC_LOW = row.GetString("STLOC_LOW");
                datoTabla.STLOC_HIGH = row.GetString("STLOC_HIGH");
                res.IR_LGORT[i_IR_LGORT] = datoTabla; ++i_IR_LGORT;
            }
            IRfcTable rfcTable_IR_MANEJO = rfcFunction.GetTable("IR_MANEJO");
            res.IR_MANEJO = new ZMOV_10001_IR_MANEJO[rfcTable_IR_MANEJO.RowCount];
            int i_IR_MANEJO = 0;
            foreach (IRfcStructure row in rfcTable_IR_MANEJO)
            {
                ZMOV_10001_IR_MANEJO datoTabla = new ZMOV_10001_IR_MANEJO();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MANEJO[i_IR_MANEJO] = datoTabla; ++i_IR_MANEJO;
            }
            IRfcTable rfcTable_IR_MATNR = rfcFunction.GetTable("IR_MATNR");
            res.IR_MATNR = new ZMOV_10001_IR_MATNR[rfcTable_IR_MATNR.RowCount];
            int i_IR_MATNR = 0;
            foreach (IRfcStructure row in rfcTable_IR_MATNR)
            {
                ZMOV_10001_IR_MATNR datoTabla = new ZMOV_10001_IR_MATNR();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MATNR[i_IR_MATNR] = datoTabla; ++i_IR_MATNR;
            }
            IRfcTable rfcTable_IR_MTART = rfcFunction.GetTable("IR_MTART");
            res.IR_MTART = new ZMOV_10001_IR_MTART[rfcTable_IR_MTART.RowCount];
            int i_IR_MTART = 0;
            foreach (IRfcStructure row in rfcTable_IR_MTART)
            {
                ZMOV_10001_IR_MTART datoTabla = new ZMOV_10001_IR_MTART();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MTART[i_IR_MTART] = datoTabla; ++i_IR_MTART;
            }
            IRfcTable rfcTable_IR_PAIS = rfcFunction.GetTable("IR_PAIS");
            res.IR_PAIS = new ZMOV_10001_IR_PAIS[rfcTable_IR_PAIS.RowCount];
            int i_IR_PAIS = 0;
            foreach (IRfcStructure row in rfcTable_IR_PAIS)
            {
                ZMOV_10001_IR_PAIS datoTabla = new ZMOV_10001_IR_PAIS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_PAIS[i_IR_PAIS] = datoTabla; ++i_IR_PAIS;
            }
            IRfcTable rfcTable_IR_TIPO = rfcFunction.GetTable("IR_TIPO");
            res.IR_TIPO = new ZMOV_10001_IR_TIPO[rfcTable_IR_TIPO.RowCount];
            int i_IR_TIPO = 0;
            foreach (IRfcStructure row in rfcTable_IR_TIPO)
            {
                ZMOV_10001_IR_TIPO datoTabla = new ZMOV_10001_IR_TIPO();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_TIPO[i_IR_TIPO] = datoTabla; ++i_IR_TIPO;
            }
            IRfcTable rfcTable_IR_WERKS = rfcFunction.GetTable("IR_WERKS");
            res.IR_WERKS = new ZMOV_10001_IR_WERKS[rfcTable_IR_WERKS.RowCount];
            int i_IR_WERKS = 0;
            foreach (IRfcStructure row in rfcTable_IR_WERKS)
            {
                ZMOV_10001_IR_WERKS datoTabla = new ZMOV_10001_IR_WERKS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_WERKS[i_IR_WERKS] = datoTabla; ++i_IR_WERKS;
            }
            IRfcTable rfcTable_LT_DETALLE = rfcFunction.GetTable("LT_DETALLE");
            res.LT_DETALLE = new ZMOV_10001_LT_DETALLE[rfcTable_LT_DETALLE.RowCount];
            int i_LT_DETALLE = 0;
            foreach (IRfcStructure row in rfcTable_LT_DETALLE)
            {
                ZMOV_10001_LT_DETALLE datoTabla = new ZMOV_10001_LT_DETALLE();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.CLABS = row.GetDecimal("CLABS");
                datoTabla.CINSM = row.GetDecimal("CINSM");
                datoTabla.CSPEM = row.GetDecimal("CSPEM");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.NTGEW = row.GetDecimal("NTGEW");
                datoTabla.GEWEI = row.GetString("GEWEI");
                datoTabla.COD_EXTWG = row.GetString("COD_EXTWG");
                datoTabla.EXTWG = row.GetString("EXTWG");
                datoTabla.NORMT = row.GetString("NORMT");
                datoTabla.FERTH = row.GetString("FERTH");
                datoTabla.WRKST = row.GetString("WRKST");
                datoTabla.FORMT = row.GetString("FORMT");
                datoTabla.UMREN_KG = row.GetDecimal("UMREN_KG");
                datoTabla.UMREN_UN = row.GetDecimal("UMREN_UN");
                datoTabla.CAMPO1 = row.GetString("CAMPO1");
                datoTabla.CAMPO2 = row.GetString("CAMPO2");
                datoTabla.CAMPO3 = row.GetString("CAMPO3");
                datoTabla.CAMPO4 = row.GetString("CAMPO4");
                datoTabla.CAMPO5 = row.GetString("CAMPO5");
                datoTabla.CAMPO6 = row.GetString("CAMPO6");
                datoTabla.CAMPO7 = row.GetString("CAMPO7");
                datoTabla.CAMPO8 = row.GetString("CAMPO8");
                datoTabla.CAMPO9 = row.GetString("CAMPO9");
                datoTabla.CAMPO10 = row.GetString("CAMPO10");
                datoTabla.CAMPO11 = row.GetString("CAMPO11");
                datoTabla.CAMPO12 = row.GetString("CAMPO12");
                datoTabla.CAMPO13 = row.GetString("CAMPO13");
                datoTabla.CAMPO14 = row.GetString("CAMPO14");
                datoTabla.CAMPO15 = row.GetString("CAMPO15");
                datoTabla.CAMPO16 = row.GetString("CAMPO16");
                datoTabla.CAMPO17 = row.GetString("CAMPO17");
                datoTabla.CAMPO18 = row.GetString("CAMPO18");
                datoTabla.CAMPO19 = row.GetString("CAMPO19");
                datoTabla.CAMPO20 = row.GetString("CAMPO20");
                datoTabla.CAMPO21 = row.GetString("CAMPO21");
                datoTabla.CAMPO22 = row.GetString("CAMPO22");
                datoTabla.CAMPO23 = row.GetString("CAMPO23");
                datoTabla.CAMPO24 = row.GetString("CAMPO24");
                datoTabla.CAMPO25 = row.GetString("CAMPO25");
                datoTabla.CAMPO26 = row.GetString("CAMPO26");
                datoTabla.CAMPO27 = row.GetString("CAMPO27");
                datoTabla.CAMPO28 = row.GetString("CAMPO28");
                datoTabla.CAMPO29 = row.GetString("CAMPO29");
                datoTabla.CAMPO30 = row.GetString("CAMPO30");
                datoTabla.CAMPO31 = row.GetString("CAMPO31");
                datoTabla.CAMPO32 = row.GetString("CAMPO32");
                datoTabla.CAMPO33 = row.GetString("CAMPO33");
                datoTabla.CAMPO34 = row.GetString("CAMPO34");
                datoTabla.CAMPO35 = row.GetString("CAMPO35");
                datoTabla.CAMPO36 = row.GetString("CAMPO36");
                datoTabla.CAMPO37 = row.GetString("CAMPO37");
                datoTabla.CAMPO38 = row.GetString("CAMPO38");
                datoTabla.CAMPO40 = row.GetString("CAMPO40");
                datoTabla.CAMPO41 = row.GetString("CAMPO41");
                res.LT_DETALLE[i_LT_DETALLE] = datoTabla; ++i_LT_DETALLE;
            }
            IRfcTable rfcTable_STOCKLOTES = rfcFunction.GetTable("STOCKLOTES");
            res.STOCKLOTES = new ZMOV_10001_STOCKLOTES[rfcTable_STOCKLOTES.RowCount];
            int i_STOCKLOTES = 0;
            foreach (IRfcStructure row in rfcTable_STOCKLOTES)
            {
                ZMOV_10001_STOCKLOTES datoTabla = new ZMOV_10001_STOCKLOTES();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.CLABS = row.GetDecimal("CLABS");
                datoTabla.CINSM = row.GetDecimal("CINSM");
                datoTabla.CSPEM = row.GetDecimal("CSPEM");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.COD_VARIEDAD = row.GetString("COD_VARIEDAD");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.NTGEW = row.GetDecimal("NTGEW");
                datoTabla.GEWEI = row.GetString("GEWEI");
                datoTabla.COD_EXTWG = row.GetString("COD_EXTWG");
                datoTabla.EXTWG = row.GetString("EXTWG");
                datoTabla.NORMT = row.GetString("NORMT");
                datoTabla.FERTH = row.GetString("FERTH");
                datoTabla.WRKST = row.GetString("WRKST");
                datoTabla.FORMT = row.GetString("FORMT");
                datoTabla.UMREN_KG = row.GetDecimal("UMREN_KG");
                datoTabla.UMREN_UN = row.GetDecimal("UMREN_UN");
                datoTabla.COD_CALIBRE = row.GetString("COD_CALIBRE");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CONTENEDOR = row.GetString("CONTENEDOR");
                datoTabla.HU_ORIGEN = row.GetString("HU_ORIGEN");
                datoTabla.DECAY = row.GetString("DECAY");
                datoTabla.MOULD = row.GetString("MOULD");
                datoTabla.SENSITIVE = row.GetString("SENSITIVE");
                datoTabla.SHRIVEL = row.GetString("SHRIVEL");
                datoTabla.NOTACOLOR = row.GetString("NOTACOLOR");
                datoTabla.FECHA_ARRIBO = row.GetString("FECHA_ARRIBO");
                datoTabla.ANTIGUEDAD = row.GetInt("ANTIGUEDAD");
                datoTabla.HERKL = row.GetString("HERKL");
                datoTabla.COD_EXPORTADOR = row.GetString("COD_EXPORTADOR");
                datoTabla.EXPORTADOR = row.GetString("EXPORTADOR");
                datoTabla.SUMA_DEFECTOS = row.GetString("SUMA_DEFECTOS");
                datoTabla.UB_CALLE = row.GetString("UB_CALLE");
                datoTabla.UB_PISO = row.GetString("UB_PISO");
                res.STOCKLOTES[i_STOCKLOTES] = datoTabla; ++i_STOCKLOTES;
            }
            IRfcTable rfcTable_STOCK_HU = rfcFunction.GetTable("STOCK_HU");
            res.STOCK_HU = new ZMOV_10001_STOCK_HU[rfcTable_STOCK_HU.RowCount];
            int i_STOCK_HU = 0;
            foreach (IRfcStructure row in rfcTable_STOCK_HU)
            {
                ZMOV_10001_STOCK_HU datoTabla = new ZMOV_10001_STOCK_HU();
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.VEPOS = row.GetInt("VEPOS");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.LGORT = row.GetString("LGORT");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.VEMNG = row.GetDecimal("VEMNG");
                datoTabla.VEMEH = row.GetString("VEMEH");
                datoTabla.VEGR1 = row.GetString("VEGR1");
                datoTabla.VEGR2 = row.GetString("VEGR2");
                datoTabla.VEGR3 = row.GetString("VEGR3");
                datoTabla.VEGR4 = row.GetString("VEGR4");
                datoTabla.VEGR5 = row.GetString("VEGR5");
                datoTabla.ZMM_HU_V_CUARTEL = row.GetString("ZMM_HU_V_CUARTEL");
                datoTabla.ZMM_HU_V_HILERA = row.GetString("ZMM_HU_V_HILERA");
                res.STOCK_HU[i_STOCK_HU] = datoTabla; ++i_STOCK_HU;
            }
            IRfcTable rfcTable_TABLA_CARACTERISTICAS = rfcFunction.GetTable("TABLA_CARACTERISTICAS");
            res.TABLA_CARACTERISTICAS = new ZMOV_10001_TABLA_CARACTERISTICAS[rfcTable_TABLA_CARACTERISTICAS.RowCount];
            int i_TABLA_CARACTERISTICAS = 0;
            foreach (IRfcStructure row in rfcTable_TABLA_CARACTERISTICAS)
            {
                ZMOV_10001_TABLA_CARACTERISTICAS datoTabla = new ZMOV_10001_TABLA_CARACTERISTICAS();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.CARACTERISTICA = row.GetString("CARACTERISTICA");
                datoTabla.VALOR_TEXTO = row.GetString("VALOR_TEXTO");
                datoTabla.VALOR_ID = row.GetString("VALOR_ID");
                datoTabla.TIPO_DATO = row.GetString("TIPO_DATO");
                res.TABLA_CARACTERISTICAS[i_TABLA_CARACTERISTICAS] = datoTabla; ++i_TABLA_CARACTERISTICAS;
            }

            return res;
        }
    }
    public class request_ZMOV_10001
    {
       
        public ZMOV_10001_IR_ATKLA[] IR_ATKLA;
        public ZMOV_10001_IR_ATNAM[] IR_ATNAM;
        public ZMOV_10001_IR_CHARG[] IR_CHARG;
        public ZMOV_10001_IR_ESPECIE[] IR_ESPECIE;
        public ZMOV_10001_IR_ETIQUETA[] IR_ETIQUETA;
        public ZMOV_10001_IR_FORMATO[] IR_FORMATO;
        public ZMOV_10001_IR_LGORT[] IR_LGORT;
        public ZMOV_10001_IR_MANEJO[] IR_MANEJO;
        public ZMOV_10001_IR_MATNR[] IR_MATNR;
        public ZMOV_10001_IR_MTART[] IR_MTART;
        public ZMOV_10001_IR_PAIS[] IR_PAIS;
        public ZMOV_10001_IR_TIPO[] IR_TIPO;
        public ZMOV_10001_IR_WERKS[] IR_WERKS;
        
        public String IV_LIB_UTIL;
        public String IV_SPRAS;
        public String I_CLASE;
    }
    public class responce_ZMOV_10001
    {
        public ZMOV_10001_IR_ATKLA[] IR_ATKLA;
        public ZMOV_10001_IR_ATNAM[] IR_ATNAM;
        public ZMOV_10001_IR_CHARG[] IR_CHARG;
        public ZMOV_10001_IR_ESPECIE[] IR_ESPECIE;
        public ZMOV_10001_IR_ETIQUETA[] IR_ETIQUETA;
        public ZMOV_10001_IR_FORMATO[] IR_FORMATO;
        public ZMOV_10001_IR_LGORT[] IR_LGORT;
        public ZMOV_10001_IR_MANEJO[] IR_MANEJO;
        public ZMOV_10001_IR_MATNR[] IR_MATNR;
        public ZMOV_10001_IR_MTART[] IR_MTART;
        public ZMOV_10001_IR_PAIS[] IR_PAIS;
        public ZMOV_10001_IR_TIPO[] IR_TIPO;
        public ZMOV_10001_IR_WERKS[] IR_WERKS;
        public ZMOV_10001_LT_DETALLE[] LT_DETALLE;
        public ZMOV_10001_STOCKLOTES[] STOCKLOTES;
        public ZMOV_10001_STOCK_HU[] STOCK_HU;
        public ZMOV_10001_TABLA_CARACTERISTICAS[] TABLA_CARACTERISTICAS;
    }
    public class ZMOV_10001_IR_ATKLA
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_ATNAM
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_CHARG
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_ESPECIE
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_ETIQUETA
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_FORMATO
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_LGORT
    {
        public String SIGN;
        public String OPTION;
        public String STLOC_LOW;
        public String STLOC_HIGH;
    }
    public class ZMOV_10001_IR_MANEJO
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_MATNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_MTART
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_PAIS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_TIPO
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_IR_WERKS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10001_LT_DETALLE
    {
        public String MATNR;
        public String MAKTX;
        public String WERKS;
        public String LGORT;
        public String CHARG;
        public String MEINS;
        public Decimal CLABS;
        public Decimal CINSM;
        public Decimal CSPEM;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public Decimal NTGEW;
        public String GEWEI;
        public String COD_EXTWG;
        public String EXTWG;
        public String NORMT;
        public String FERTH;
        public String WRKST;
        public String FORMT;
        public Decimal UMREN_KG;
        public Decimal UMREN_UN;
        public String CAMPO1;
        public String CAMPO2;
        public String CAMPO3;
        public String CAMPO4;
        public String CAMPO5;
        public String CAMPO6;
        public String CAMPO7;
        public String CAMPO8;
        public String CAMPO9;
        public String CAMPO10;
        public String CAMPO11;
        public String CAMPO12;
        public String CAMPO13;
        public String CAMPO14;
        public String CAMPO15;
        public String CAMPO16;
        public String CAMPO17;
        public String CAMPO18;
        public String CAMPO19;
        public String CAMPO20;
        public String CAMPO21;
        public String CAMPO22;
        public String CAMPO23;
        public String CAMPO24;
        public String CAMPO25;
        public String CAMPO26;
        public String CAMPO27;
        public String CAMPO28;
        public String CAMPO29;
        public String CAMPO30;
        public String CAMPO31;
        public String CAMPO32;
        public String CAMPO33;
        public String CAMPO34;
        public String CAMPO35;
        public String CAMPO36;
        public String CAMPO37;
        public String CAMPO38;
        public String CAMPO40;
        public String CAMPO41;
    }
    public class ZMOV_10001_STOCKLOTES
    {
        public String MATNR;
        public String MAKTX;
        public String WERKS;
        public String LGORT;
        public String CHARG;
        public String MEINS;
        public Decimal CLABS;
        public Decimal CINSM;
        public Decimal CSPEM;
        public String LIFNR;
        public String NOMBRE_PRODUCTOR;
        public String COD_VARIEDAD;
        public String VARIEDAD;
        public Decimal NTGEW;
        public String GEWEI;
        public String COD_EXTWG;
        public String EXTWG;
        public String NORMT;
        public String FERTH;
        public String WRKST;
        public String FORMT;
        public Decimal UMREN_KG;
        public Decimal UMREN_UN;
        public String COD_CALIBRE;
        public String CALIBRE;
        public String CONTENEDOR;
        public String HU_ORIGEN;
        public String DECAY;
        public String MOULD;
        public String SENSITIVE;
        public String SHRIVEL;
        public String NOTACOLOR;
        public String FECHA_ARRIBO;
        public Int32 ANTIGUEDAD;
        public String HERKL;
        public String COD_EXPORTADOR;
        public String EXPORTADOR;
        public String SUMA_DEFECTOS;
        public String UB_CALLE;
        public String UB_PISO;
    }
    public class ZMOV_10001_STOCK_HU
    {
        public String EXIDV;
        public Int32 VEPOS;
        public String MATNR;
        public String WERKS;
        public String LGORT;
        public String CHARG;
        public Decimal VEMNG;
        public String VEMEH;
        public String VEGR1;
        public String VEGR2;
        public String VEGR3;
        public String VEGR4;
        public String VEGR5;
        public String ZMM_HU_V_CUARTEL;
        public String ZMM_HU_V_HILERA;
    }
    public class ZMOV_10001_TABLA_CARACTERISTICAS
    {
        public String MATNR;
        public String CHARG;
        public String CARACTERISTICA;
        public String VALOR_TEXTO;
        public String VALOR_ID;
        public String TIPO_DATO;
    }

}