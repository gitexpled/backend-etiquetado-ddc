using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_STOCK_LOTE
    {
        public responce_ZMOV_QUERY_STOCK_LOTE sapRun(request_ZMOV_QUERY_STOCK_LOTE import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_STOCK_LOTE");

            rfcFunction.SetValue("LOTE", import.LOTE);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_STOCK_LOTE res = new responce_ZMOV_QUERY_STOCK_LOTE();
            IRfcTable rfcTable_STOCKLOTES = rfcFunction.GetTable("STOCKLOTES");
            res.STOCKLOTES = new ZMOV_QUERY_STOCK_LOTE_STOCKLOTES[rfcTable_STOCKLOTES.RowCount];
            int i_STOCKLOTES = 0;
            foreach (IRfcStructure row in rfcTable_STOCKLOTES)
            {
                ZMOV_QUERY_STOCK_LOTE_STOCKLOTES datoTabla = new ZMOV_QUERY_STOCK_LOTE_STOCKLOTES();
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
                datoTabla.TIPIFICACION = row.GetString("COD_TIPIFICACION");
                datoTabla.CAMARA = row.GetString("CAMARA");
                datoTabla.ESTADO_PROCESO = row.GetString("ESTADO_PROCESO");
                datoTabla.SAG_SDP = row.GetString("SAG_SDP");
                datoTabla.TIPO_FRIO = row.GetString("TIPO_FRIO");
                datoTabla.CLIENTE = row.GetString("CLIENTE");
                datoTabla.TIPIFICACION_ESPECIE = row.GetString("TIPIFICACION_ESPECIE");
                res.STOCKLOTES[i_STOCKLOTES] = datoTabla; ++i_STOCKLOTES;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_STOCK_LOTE
    {
        public String LOTE;
    }
    public class responce_ZMOV_QUERY_STOCK_LOTE
    {
        public ZMOV_QUERY_STOCK_LOTE_STOCKLOTES[] STOCKLOTES;
    }
    public class ZMOV_QUERY_STOCK_LOTE_STOCKLOTES
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
        public String TIPIFICACION;
        public String CAMARA;
        public String ESTADO_PROCESO;
        public String SAG_SDP;
        public String TIPO_FRIO;
        public String CLIENTE;
        public String TIPIFICACION_ESPECIE;
    }

}