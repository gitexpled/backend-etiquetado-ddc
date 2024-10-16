using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_MATERIAL
    {
        public responce_ZMOV_QUERY_MATERIAL sapRun(request_ZMOV_QUERY_MATERIAL import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_MATERIAL");
            
            IRfcTable rfcTable_IR_MATKL_I = rfcFunction.GetTable("IR_MATKL");
            if (import.IR_MATKL != null)
            {
                foreach (ZMOV_QUERY_MATERIAL_IR_MATKL row in import.IR_MATKL)
                {
                    rfcTable_IR_MATKL_I.Append();
                    ZMOV_QUERY_MATERIAL_IR_MATKL datoTabla = new ZMOV_QUERY_MATERIAL_IR_MATKL();
                    rfcTable_IR_MATKL_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IR_MATKL_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_MATKL_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_MATKL_I.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("IR_MATKL", rfcTable_IR_MATKL_I);
            IRfcTable rfcTable_IR_MTART_I = rfcFunction.GetTable("IR_MTART");
            if (import.IR_MTART != null)
            {
                foreach (ZMOV_QUERY_MATERIAL_IR_MTART row in import.IR_MTART)
                {
                    rfcTable_IR_MTART_I.Append();
                    ZMOV_QUERY_MATERIAL_IR_MTART datoTabla = new ZMOV_QUERY_MATERIAL_IR_MTART();
                    rfcTable_IR_MTART_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IR_MTART_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_MTART_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_MTART_I.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("IR_MTART", rfcTable_IR_MTART_I);
            IRfcTable rfcTable_IR_WERKS_I = rfcFunction.GetTable("IR_WERKS");
            if (import.IR_WERKS != null)
            {
                foreach (ZMOV_QUERY_MATERIAL_IR_WERKS row in import.IR_WERKS)
                {
                    rfcTable_IR_WERKS_I.Append();
                    ZMOV_QUERY_MATERIAL_IR_WERKS datoTabla = new ZMOV_QUERY_MATERIAL_IR_WERKS();
                    rfcTable_IR_WERKS_I.SetValue("SIGN", row.SIGN);
                    rfcTable_IR_WERKS_I.SetValue("OPTION", row.OPTION);
                    rfcTable_IR_WERKS_I.SetValue("LOW", row.LOW);
                    rfcTable_IR_WERKS_I.SetValue("HIGH", row.HIGH);
                }
            }
            rfcFunction.SetValue("IR_WERKS", rfcTable_IR_WERKS_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_MATERIAL res = new responce_ZMOV_QUERY_MATERIAL();
            IRfcTable rfcTable_IR_MATKL = rfcFunction.GetTable("IR_MATKL");
            res.IR_MATKL = new ZMOV_QUERY_MATERIAL_IR_MATKL[rfcTable_IR_MATKL.RowCount];
            int i_IR_MATKL = 0;
            foreach (IRfcStructure row in rfcTable_IR_MATKL)
            {
                ZMOV_QUERY_MATERIAL_IR_MATKL datoTabla = new ZMOV_QUERY_MATERIAL_IR_MATKL();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MATKL[i_IR_MATKL] = datoTabla; ++i_IR_MATKL;
            }
            IRfcTable rfcTable_IR_MTART = rfcFunction.GetTable("IR_MTART");
            res.IR_MTART = new ZMOV_QUERY_MATERIAL_IR_MTART[rfcTable_IR_MTART.RowCount];
            int i_IR_MTART = 0;
            foreach (IRfcStructure row in rfcTable_IR_MTART)
            {
                ZMOV_QUERY_MATERIAL_IR_MTART datoTabla = new ZMOV_QUERY_MATERIAL_IR_MTART();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MTART[i_IR_MTART] = datoTabla; ++i_IR_MTART;
            }
            IRfcTable rfcTable_IR_WERKS = rfcFunction.GetTable("IR_WERKS");
            res.IR_WERKS = new ZMOV_QUERY_MATERIAL_IR_WERKS[rfcTable_IR_WERKS.RowCount];
            int i_IR_WERKS = 0;
            foreach (IRfcStructure row in rfcTable_IR_WERKS)
            {
                ZMOV_QUERY_MATERIAL_IR_WERKS datoTabla = new ZMOV_QUERY_MATERIAL_IR_WERKS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_WERKS[i_IR_WERKS] = datoTabla; ++i_IR_WERKS;
            }
            IRfcTable rfcTable_MATERIALES = rfcFunction.GetTable("MATERIALES");
            res.MATERIALES = new ZMOV_QUERY_MATERIAL_MATERIALES[rfcTable_MATERIALES.RowCount];
            int i_MATERIALES = 0;
            foreach (IRfcStructure row in rfcTable_MATERIALES)
            {
                ZMOV_QUERY_MATERIAL_MATERIALES datoTabla = new ZMOV_QUERY_MATERIAL_MATERIALES();
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTG = row.GetString("MAKTG");
                datoTabla.MTART = row.GetString("MTART");
                datoTabla.MATKL = row.GetString("MATKL");
                datoTabla.MEINS = row.GetString("MEINS");
                datoTabla.BISMT = row.GetString("BISMT");
                datoTabla.BRGEW = row.GetDecimal("BRGEW");
                datoTabla.NTGEW = row.GetDecimal("NTGEW");
                datoTabla.GEWEI = row.GetString("GEWEI");
                datoTabla.ILOOS = row.GetString("ILOOS");
                datoTabla.ZMAT_ESPECIE = row.GetString("ZMAT_ESPECIE");
                datoTabla.ZMAT_PROCESO = row.GetString("ZMAT_PROCESO");
                datoTabla.ZMAT_TIPO = row.GetString("ZMAT_TIPO");
                datoTabla.ZMAT_FORMATO = row.GetString("ZMAT_FORMATO");
                datoTabla.ZMAT_CLASE = row.GetString("ZMAT_CLASE");
                datoTabla.ZMAT_AGRUPACION = row.GetString("ZMAT_AGRUPACION");
                datoTabla.ZMAT_VIGENTE = row.GetString("ZMAT_VIGENTE");
                datoTabla.ZMAT_EXPORTADORA = row.GetString("ZMAT_EXPORTADORA");
                datoTabla.ZMAT_EMBALAJE = row.GetString("ZMAT_EMBALAJE");
                datoTabla.ZMM_ESPECIE = row.GetString("ZMM_ESPECIE");
                datoTabla.ZMM_VARIEDAD = row.GetString("ZMM_VARIEDAD");
                datoTabla.ZMM_PORTA_INJERTO = row.GetString("ZMM_PORTA_INJERTO");
                datoTabla.ZMM_TIPO_PLANTA = row.GetString("ZMM_TIPO_PLANTA");
                datoTabla.ZMATERIAL_YEAR = row.GetString("ZMATERIAL_YEAR");
                res.MATERIALES[i_MATERIALES] = datoTabla; ++i_MATERIALES;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_MATERIAL
    {
        public ZMOV_QUERY_MATERIAL_IR_MATKL[] IR_MATKL;
        public ZMOV_QUERY_MATERIAL_IR_MTART[] IR_MTART;
        public ZMOV_QUERY_MATERIAL_IR_WERKS[] IR_WERKS;
    }
    public class responce_ZMOV_QUERY_MATERIAL
    {
        public ZMOV_QUERY_MATERIAL_IR_MATKL[] IR_MATKL;
        public ZMOV_QUERY_MATERIAL_IR_MTART[] IR_MTART;
        public ZMOV_QUERY_MATERIAL_IR_WERKS[] IR_WERKS;
        public ZMOV_QUERY_MATERIAL_MATERIALES[] MATERIALES;
    }
    public class ZMOV_QUERY_MATERIAL_IR_MATKL
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_MATERIAL_IR_MTART
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_MATERIAL_IR_WERKS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_QUERY_MATERIAL_MATERIALES
    {
        public String MATNR;
        public String MAKTG;
        public String MTART;
        public String MATKL;
        public String MEINS;
        public String BISMT;
        public Decimal BRGEW;
        public Decimal NTGEW;
        public String GEWEI;
        public String ILOOS;
        public String ZMAT_ESPECIE;
        public String ZMAT_PROCESO;
        public String ZMAT_TIPO;
        public String ZMAT_FORMATO;
        public String ZMAT_CLASE;
        public String ZMAT_AGRUPACION;
        public String ZMAT_VIGENTE;
        public String ZMAT_EXPORTADORA;
        public String ZMAT_EMBALAJE;
        public String ZMM_ESPECIE;
        public String ZMM_VARIEDAD;
        public String ZMM_PORTA_INJERTO;
        public String ZMM_TIPO_PLANTA;
        public String ZMATERIAL_YEAR;
    }

}