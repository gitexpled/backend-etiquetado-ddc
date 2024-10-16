using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_MOV_QUERY_LOTE
    {
        public responce_ZMF_MOV_QUERY_LOTE sapRun(request_ZMF_MOV_QUERY_LOTE import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_MOV_QUERY_LOTE");

            // rfcFunction.SetValue("IR_CHARG", import.IR_CHARG);
            IRfcTable rfcTable_IR_CHARG_I = rfcFunction.GetTable("IR_CHARG");
            foreach (ZMF_MOV_QUERY_LOTE_IR_CHARG row in import.IR_CHARG)
            {
                rfcTable_IR_CHARG_I.Append();
                ZMF_MOV_QUERY_LOTE_IR_CHARG datoTabla = new ZMF_MOV_QUERY_LOTE_IR_CHARG();
                rfcTable_IR_CHARG_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_CHARG_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_CHARG_I.SetValue("LOW", row.LOW);
                rfcTable_IR_CHARG_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("IR_CHARG", rfcTable_IR_CHARG_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_MOV_QUERY_LOTE res = new responce_ZMF_MOV_QUERY_LOTE();
            IRfcTable rfcTable_IR_CHARG = rfcFunction.GetTable("IR_CHARG");
            res.IR_CHARG = new ZMF_MOV_QUERY_LOTE_IR_CHARG[rfcTable_IR_CHARG.RowCount];
            int i_IR_CHARG = 0;
            foreach (IRfcStructure row in rfcTable_IR_CHARG)
            {
                ZMF_MOV_QUERY_LOTE_IR_CHARG datoTabla = new ZMF_MOV_QUERY_LOTE_IR_CHARG();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_CHARG[i_IR_CHARG] = datoTabla; ++i_IR_CHARG;
            }
            IRfcTable rfcTable_LT_QUERY_LOTE = rfcFunction.GetTable("LT_QUERY_LOTE");
            res.LT_QUERY_LOTE = new ZMF_MOV_QUERY_LOTE_LT_QUERY_LOTE[rfcTable_LT_QUERY_LOTE.RowCount];
            int i_LT_QUERY_LOTE = 0;
            foreach (IRfcStructure row in rfcTable_LT_QUERY_LOTE)
            {
                ZMF_MOV_QUERY_LOTE_LT_QUERY_LOTE datoTabla = new ZMF_MOV_QUERY_LOTE_LT_QUERY_LOTE();
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.COD_VARIEDAD = row.GetString("COD_VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.FABRICACION = row.GetString("FABRICACION");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CATEGORIA = row.GetString("CATEGORIA");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.FORMATO = row.GetString("FORMATO");
                datoTabla.TIPO = row.GetString("TIPO");
                datoTabla.CLASE = row.GetString("CLASE");
                datoTabla.EXPORTADORA = row.GetString("EXPORTADORA");
                datoTabla.NOMBRE_EXPORTADORA = row.GetString("NOMBRE_EXPORTADORA");
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.EMBALA = row.GetString("EMBALA");
                datoTabla.TRATAMIENTO = row.GetString("TRATAMIENTO");
                datoTabla.TP_FRIO = row.GetString("TP_FRIO");
                datoTabla.SAG_PRODUCTOR = row.GetString("SAG_PRODUCTOR");
                datoTabla.SAG_CSG = row.GetString("SAG_CSG");
                datoTabla.SAG_CSP = row.GetString("SAG_CSP");
                datoTabla.SAG_CSP_PACKING = row.GetString("SAG_CSP_PACKING");
                datoTabla.SAG_CSP_PROVINCIA = row.GetString("SAG_CSP_PROVINCIA");
                datoTabla.SAG_CSP_COMUNA = row.GetString("SAG_CSP_COMUNA");
                datoTabla.SAG_IDP = row.GetString("SAG_IDP");
                datoTabla.CONDICION1 = row.GetDecimal("CONDICION1");
                datoTabla.CONDICION2 = row.GetDecimal("CONDICION2");
                datoTabla.CONDICION3 = row.GetDecimal("CONDICION3");
                datoTabla.DDC_NEN = row.GetString("DDC_NEN");
                datoTabla.DDC_TEN = row.GetString("DDC_TEN");
                datoTabla.FCOSECHA = row.GetString("FCOSECHA");
                datoTabla.DDC_SEG = row.GetString("DDC_SEG");
                datoTabla.NPARTIDA = row.GetString("NPARTIDA");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.PLU = row.GetString("PLU");
                datoTabla.COLOR = row.GetString("COLOR");
                datoTabla.UAT = row.GetString("UAT");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.WERKS_NAME = row.GetString("WERKS_NAME");
                datoTabla.WERKS_COMUNA = row.GetString("WERKS_COMUNA");
                datoTabla.WERKS_PROVINCIA = row.GetString("WERKS_PROVINCIA");
                datoTabla.WERKS_CSP = row.GetString("WERKS_CSP");
                datoTabla.WERKS_FDA = row.GetString("WERKS_FDA");
                datoTabla.WERKS_IDP = row.GetString("WERKS_IDP");
                res.LT_QUERY_LOTE[i_LT_QUERY_LOTE] = datoTabla; ++i_LT_QUERY_LOTE;
            }

            return res;
        }
    }
    public class request_ZMF_MOV_QUERY_LOTE
    {
        //public String IR_CHARG;
        public ZMF_MOV_QUERY_LOTE_IR_CHARG[] IR_CHARG;
    }
    public class responce_ZMF_MOV_QUERY_LOTE
    {
        public ZMF_MOV_QUERY_LOTE_IR_CHARG[] IR_CHARG;
        public ZMF_MOV_QUERY_LOTE_LT_QUERY_LOTE[] LT_QUERY_LOTE;
    }
    public class ZMF_MOV_QUERY_LOTE_IR_CHARG
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMF_MOV_QUERY_LOTE_LT_QUERY_LOTE
    {
        public String CHARG;
        public String MATNR;
        public String MAKTX;
        public String VARIEDAD;
        public String COD_VARIEDAD;
        public String VARIEDAD_ET;
        public String FABRICACION;
        public String CALIBRE;
        public String CATEGORIA;
        public String ESPECIE;
        public String FORMATO;
        public String TIPO;
        public String CLASE;
        public String EXPORTADORA;
        public String NOMBRE_EXPORTADORA;
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
        public String EMBALA;
        public String TRATAMIENTO;
        public String TP_FRIO;
        public String SAG_PRODUCTOR;
        public String SAG_CSG;
        public String SAG_CSP;
        public String SAG_CSP_PACKING;
        public String SAG_CSP_PROVINCIA;
        public String SAG_CSP_COMUNA;
        public String SAG_IDP;
        public Decimal CONDICION1;
        public Decimal CONDICION2;
        public Decimal CONDICION3;
        public String DDC_NEN;
        public String DDC_TEN;
        public String FCOSECHA;
        public String DDC_SEG;
        public String NPARTIDA;
        public String CALIDAD;
        public String PLU;
        public String COLOR;
        public String UAT;
        public String WERKS;
        public String WERKS_NAME;
        public String WERKS_COMUNA;
        public String WERKS_PROVINCIA;
        public String WERKS_CSP;
        public String WERKS_FDA;
        public String WERKS_IDP;
    }

}