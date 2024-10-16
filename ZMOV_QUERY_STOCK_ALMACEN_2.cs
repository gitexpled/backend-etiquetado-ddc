using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_STOCK_ALMACEN_2
    {
        public responce_ZMOV_QUERY_STOCK_ALMACEN_2 sapRun(request_ZMOV_QUERY_STOCK_ALMACEN_2 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_STOCK_ALMACEN_2");

            IRfcTable rfcTable_MATNR_I = rfcFunction.GetTable("MATNR");
            foreach (ZMOV_QUERY_STOCK_ALMACEN_2_MATNR row in import.MATNR)
            {
                rfcTable_MATNR_I.Append();
                ZMOV_QUERY_STOCK_ALMACEN_2_MATNR datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_MATNR();
                rfcTable_MATNR_I.SetValue("SIGN", row.SIGN);
                rfcTable_MATNR_I.SetValue("OPTION", row.OPTION);
                rfcTable_MATNR_I.SetValue("LOW", row.LOW);
                rfcTable_MATNR_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("MATNR", rfcTable_MATNR_I);

            IRfcTable rfcTable_LIFNR = rfcFunction.GetTable("LIFNR");
            if (import.LIFNR[0] != null)
            {
                foreach (ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR row in import.LIFNR)
                {
                    rfcTable_LIFNR.Append();
                    ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR();
                    rfcTable_LIFNR.SetValue("SIGN", row.SIGN);
                    rfcTable_LIFNR.SetValue("OPTION", row.OPTION);
                    rfcTable_LIFNR.SetValue("LOW", row.LOW);
                    rfcTable_LIFNR.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("LIFNR", rfcTable_LIFNR);

            IRfcTable rfcTable_FABRICACION = rfcFunction.GetTable("FABRICACION");
            foreach (ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION row in import.FABRICACION)
            {
                rfcTable_FABRICACION.Append();
                ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION();
                rfcTable_FABRICACION.SetValue("SIGN", row.SIGN);
                rfcTable_FABRICACION.SetValue("OPTION", row.OPTION);
                rfcTable_FABRICACION.SetValue("LOW", row.LOW);
                rfcTable_FABRICACION.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("FABRICACION", rfcTable_FABRICACION);

            IRfcTable rfcTable_LGORT_I = rfcFunction.GetTable("LGORT");
             if (import.LGORT != null)
            {
            foreach (ZMOV_QUERY_STOCK_ALMACEN_2_LGORT row in import.LGORT)
            {
                rfcTable_LGORT_I.Append();
                ZMOV_QUERY_STOCK_ALMACEN_2_LGORT datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_LGORT();
                rfcTable_LGORT_I.SetValue("SIGN", row.SIGN);
                rfcTable_LGORT_I.SetValue("OPTION", row.OPTION);
                rfcTable_LGORT_I.SetValue("STLOC_LOW", row.STLOC_LOW);
                rfcTable_LGORT_I.SetValue("STLOC_HIGH", row.STLOC_HIGH);
            }
            }
     
            rfcFunction.SetValue("LGORT", rfcTable_LGORT_I);

            IRfcTable rfcTable_WERKS_I = rfcFunction.GetTable("WERKS");
            foreach (ZMOV_QUERY_STOCK_ALMACEN_2_WERKS row in import.WERKS)
            {
                rfcTable_WERKS_I.Append();
                ZMOV_QUERY_STOCK_ALMACEN_2_WERKS datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_WERKS();
                rfcTable_WERKS_I.SetValue("SIGN", row.SIGN);
                rfcTable_WERKS_I.SetValue("OPTION", row.OPTION);
                rfcTable_WERKS_I.SetValue("LOW", row.LOW);
                rfcTable_WERKS_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("WERKS", rfcTable_WERKS_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_STOCK_ALMACEN_2 res = new responce_ZMOV_QUERY_STOCK_ALMACEN_2();
            IRfcTable rfcTable_LGORT = rfcFunction.GetTable("LGORT");
            res.LGORT = new ZMOV_QUERY_STOCK_ALMACEN_2_LGORT[rfcTable_LGORT.RowCount];
            int i_LGORT = 0;
            foreach (IRfcStructure row in rfcTable_LGORT)
            {
                ZMOV_QUERY_STOCK_ALMACEN_2_LGORT datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_LGORT();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.STLOC_LOW = row.GetString("STLOC_LOW");
                datoTabla.STLOC_HIGH = row.GetString("STLOC_HIGH");
                res.LGORT[i_LGORT] = datoTabla; ++i_LGORT;
            }
            IRfcTable rfcTable_WERKS = rfcFunction.GetTable("WERKS");
            res.WERKS = new ZMOV_QUERY_STOCK_ALMACEN_2_WERKS[rfcTable_WERKS.RowCount];
            int i_WERKS = 0;
            foreach (IRfcStructure row in rfcTable_WERKS)
            {
                ZMOV_QUERY_STOCK_ALMACEN_2_WERKS datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_WERKS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.WERKS[i_WERKS] = datoTabla; ++i_WERKS;
            }
            IRfcTable rfcTable_STOCKLOTES = rfcFunction.GetTable("STOCKLOTES");
            res.STOCKLOTES = new ZMOV_QUERY_STOCK_ALMACEN_2_STOCKLOTES[rfcTable_STOCKLOTES.RowCount];
            int i_STOCKLOTES = 0;
            foreach (IRfcStructure row in rfcTable_STOCKLOTES)
            {
                ZMOV_QUERY_STOCK_ALMACEN_2_STOCKLOTES datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_STOCKLOTES();
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
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CATEGORIA = row.GetString("CATEGORIA");
                datoTabla.XHUPF = row.GetString("XHUPF");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.FABRICACION = row.GetString("FABRICACION");
                datoTabla.FCOSECHA = row.GetString("FCOSECHA");
                datoTabla.NPARTIDA = row.GetString("NPARTIDA");
                datoTabla.PLU = row.GetString("PLU");
                datoTabla.COLOR = row.GetString("COLOR");
                datoTabla.LINEA = row.GetString("LINEA");
                res.STOCKLOTES[i_STOCKLOTES] = datoTabla; ++i_STOCKLOTES;
            }
            //IRfcTable rfcTable_STOCKLOTES = rfcFunction.GetTable("STOCKLOTES");
            /*res.STOCKLOTES = new ZMOV_QUERY_STOCK_ALMACEN_2_STOCKLOTES[rfcTable_STOCKLOTES.RowCount];
            int i_STOCKLOTES = 0;
            foreach (IRfcStructure row in rfcTable_STOCKLOTES)
            {
                ZMOV_QUERY_STOCK_ALMACEN_2_STOCKLOTES datoTabla = new ZMOV_QUERY_STOCK_ALMACEN_2_STOCKLOTES();
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
                datoTabla.PRODUCTOR = row.GetString("PRODUCTOR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.PRODUCTOR_ET = row.GetString("PRODUCTOR_ET");
                datoTabla.NOMBRE_PRODUCTOR_ET = row.GetString("NOMBRE_PRODUCTOR_ET");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CATEGORIA = row.GetString("CATEGORIA");
                datoTabla.XHUPF = row.GetString("XHUPF");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.FABRICACION = row.GetString("FABRICACION");
                datoTabla.FCOSECHA = row.GetString("FCOSECHA");
                datoTabla.NPARTIDA = row.GetString("NPARTIDA");
                datoTabla.PLU = row.GetString("PLU");
                datoTabla.COLOR = row.GetString("COLOR");
                res.STOCKLOTES[i_STOCKLOTES] = datoTabla; ++i_STOCKLOTES;
            }*/

            return res;
        }
    }
    public class request_ZMOV_QUERY_STOCK_ALMACEN_2
    {
        //public String LGORT;
        public ZMOV_QUERY_STOCK_ALMACEN_2_LGORT[] LGORT;
        public ZMOV_QUERY_STOCK_ALMACEN_2_WERKS[] WERKS;
        public ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION[] FABRICACION;
        public ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR[] LIFNR;
        public ZMOV_QUERY_STOCK_ALMACEN_2_MATNR[] MATNR;
    }
    public class responce_ZMOV_QUERY_STOCK_ALMACEN_2
    {
        public ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION[] FABRICACION;
        public ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR[] LIFNR;
        public ZMOV_QUERY_STOCK_ALMACEN_2_MATNR[] MATNR;
        public ZMOV_QUERY_STOCK_ALMACEN_2_LGORT[] LGORT;
        public ZMOV_QUERY_STOCK_ALMACEN_2_WERKS[] WERKS;
        public ZMOV_QUERY_STOCK_ALMACEN_2_STOCKLOTES[] STOCKLOTES;
    }
    public class ZMOV_QUERY_STOCK_ALMACEN_2_MATNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_STOCK_ALMACEN_2_FABRICACION
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_STOCK_ALMACEN_2_LIFNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_STOCK_ALMACEN_2_LGORT
    {
        public String SIGN;
        public String OPTION;
        public String STLOC_LOW;
        public String STLOC_HIGH;
    }
    public class ZMOV_QUERY_STOCK_ALMACEN_2_WERKS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_STOCK_ALMACEN_2_STOCKLOTES
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
        public String PRODUCTOR;
        public String NOMBRE_PRODUCTOR;
        public String PRODUCTOR_ET;
        public String NOMBRE_PRODUCTOR_ET;
        public String ESPECIE;
        public String VARIEDAD;
        public String VARIEDAD_ET;
        public String CALIBRE;
        public String CATEGORIA;
        public String XHUPF;
        public String CALIDAD;
        public String FABRICACION;
        public String FCOSECHA;
        public String NPARTIDA;
        public String PLU;
        public String COLOR;
        public String LINEA;
    }

}