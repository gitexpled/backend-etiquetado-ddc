using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_STOCK_PROCESO
    {
        public responce_ZMOV_QUERY_STOCK_PROCESO sapRun(request_ZMOV_QUERY_STOCK_PROCESO import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_STOCK_PROCESO");

            rfcFunction.SetValue("LOTEPROCESO", import.LOTEPROCESO);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_STOCK_PROCESO res = new responce_ZMOV_QUERY_STOCK_PROCESO();
            IRfcTable rfcTable_STOCKPROCESO = rfcFunction.GetTable("STOCKPROCESO");
            res.STOCKPROCESO = new ZMOV_QUERY_STOCK_PROCESO_STOCKPROCESO[rfcTable_STOCKPROCESO.RowCount];
            int i_STOCKPROCESO = 0;
            foreach (IRfcStructure row in rfcTable_STOCKPROCESO)
            {
                ZMOV_QUERY_STOCK_PROCESO_STOCKPROCESO datoTabla = new ZMOV_QUERY_STOCK_PROCESO_STOCKPROCESO();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.LBLAB = row.GetDecimal("LBLAB");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.NOMBRE_PRODUCTOR = row.GetString("NOMBRE_PRODUCTOR");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.COD_VARIEDAD = row.GetString("COD_VARIEDAD");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.GUIA = row.GetString("GUIA");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.NPARTIDA = row.GetString("NPARTIDA");
                datoTabla.SAG_SDP = row.GetString("SAG_SDP");
                datoTabla.COD_TIPIFICACION = row.GetString("COD_TIPIFICACION");
                datoTabla.TIPIFICACION = row.GetString("TIPIFICACION");
                datoTabla.ESTADO_PROCESO = row.GetString("ESTADO_PROCESO");
                datoTabla.TDFRIO = row.GetString("TFRIO");
                datoTabla.FCOSECHA = row.GetString("FCOSECHA");
                datoTabla.LINEA_PRD = row.GetString("LINEA_PRD");
                datoTabla.TURNO_PRD = row.GetString("TURNO_PRD");
                datoTabla.MOTIVO_REEM = row.GetString("MOTIVO_REEM");
                datoTabla.ACUENTA_REEM = row.GetString("ACUENTA_REEM");
                datoTabla.AUTORIZA_REEM = row.GetString("AUTORIZA_REEM");
                datoTabla.CAMARA = row.GetString("CAMARA");
                datoTabla.TIPO_PROCESO = row.GetString("TIPO_PROCESO");
                datoTabla.TIPIFICACION_ESPECIE = row.GetString("TIPIFICACION_ESPECIE");
                datoTabla.CLIENTE = row.GetString("CLIENTE");
                datoTabla.INTAD = row.GetString("INTAD");
                res.STOCKPROCESO[i_STOCKPROCESO] = datoTabla; ++i_STOCKPROCESO;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_STOCK_PROCESO
    {
        public String LOTEPROCESO;
    }
    public class responce_ZMOV_QUERY_STOCK_PROCESO
    {
        public ZMOV_QUERY_STOCK_PROCESO_STOCKPROCESO[] STOCKPROCESO;
    }
    public class ZMOV_QUERY_STOCK_PROCESO_STOCKPROCESO
    {
        public String MATNR;
        public String WERKS;
        public String CHARG;
        public Decimal LBLAB;
        public String MEINS;
        public String LIFNR;
        public String NOMBRE_PRODUCTOR;
        public String HSDAT;
        public String COD_VARIEDAD;
        public String VARIEDAD;
        public String GUIA;
        public String ESPECIE;
        public String NPARTIDA;
        public String SAG_SDP;
        public String COD_TIPIFICACION;
        public String TIPIFICACION;
        public String ESTADO_PROCESO;
        public String TDFRIO;
        public String FCOSECHA;
        public String LINEA_PRD;
        public String TURNO_PRD;
        public String MOTIVO_REEM;
        public String ACUENTA_REEM;
        public String AUTORIZA_REEM;
        public String CAMARA;
        public String TIPO_PROCESO;
        public String TIPIFICACION_ESPECIE;
        public String CLIENTE;
        public String INTAD;
    }

}