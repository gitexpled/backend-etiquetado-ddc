using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_10022
    {
        public responce_ZMOV_10022 sapRun(request_ZMOV_10022 import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_10022");

            /*rfcFunction.SetValue("IR_ESPECIE", import.IR_ESPECIE);
            rfcFunction.SetValue("IR_VARIEDAD", import.IR_VARIEDAD);
            rfcFunction.SetValue("IR_WERKS", import.IR_WERKS);*/
            IRfcTable rfcTable_IR_ESPECIE_I = rfcFunction.GetTable("IR_ESPECIE");
            foreach (ZMOV_10022_IR_ESPECIE row in import.IR_ESPECIE)
            {
                rfcTable_IR_ESPECIE_I.Append();
                ZMOV_10022_IR_ESPECIE datoTabla = new ZMOV_10022_IR_ESPECIE();
                rfcTable_IR_ESPECIE_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_ESPECIE_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_ESPECIE_I.SetValue("LOW", row.LOW);
                rfcTable_IR_ESPECIE_I.SetValue("HIGH", row.HIGH);
            }
            IRfcTable rfcTable_IR_VARIEDAD_I = rfcFunction.GetTable("IR_VARIEDAD");
            foreach (ZMOV_10022_IR_VARIEDAD row in import.IR_VARIEDAD)
            {
                rfcTable_IR_VARIEDAD_I.Append();
                ZMOV_10022_IR_VARIEDAD datoTabla = new ZMOV_10022_IR_VARIEDAD();
                rfcTable_IR_VARIEDAD_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_VARIEDAD_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_VARIEDAD_I.SetValue("LOW", row.LOW);
                rfcTable_IR_VARIEDAD_I.SetValue("HIGH", row.HIGH);
            }
            IRfcTable rfcTable_IR_WERKS_I = rfcFunction.GetTable("IR_WERKS");
            foreach (ZMOV_10022_IR_WERKS row in import.IR_WERKS)
            {
                rfcTable_IR_WERKS_I.Append();
                ZMOV_10022_IR_WERKS datoTabla = new ZMOV_10022_IR_WERKS();
                rfcTable_IR_WERKS_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_WERKS_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_WERKS_I.SetValue("LOW", row.LOW);
                rfcTable_IR_WERKS_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("IR_WERKS", rfcTable_IR_WERKS_I);
            rfcFunction.SetValue("IR_VARIEDAD", rfcTable_IR_VARIEDAD_I);
            rfcFunction.SetValue("IR_ESPECIE", rfcTable_IR_ESPECIE_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_10022 res = new responce_ZMOV_10022();
            IRfcTable rfcTable_IR_ESPECIE = rfcFunction.GetTable("IR_ESPECIE");
            res.IR_ESPECIE = new ZMOV_10022_IR_ESPECIE[rfcTable_IR_ESPECIE.RowCount];
            int i_IR_ESPECIE = 0;
            foreach (IRfcStructure row in rfcTable_IR_ESPECIE)
            {
                ZMOV_10022_IR_ESPECIE datoTabla = new ZMOV_10022_IR_ESPECIE();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_ESPECIE[i_IR_ESPECIE] = datoTabla; ++i_IR_ESPECIE;
            }
            IRfcTable rfcTable_IR_VARIEDAD = rfcFunction.GetTable("IR_VARIEDAD");
            res.IR_VARIEDAD = new ZMOV_10022_IR_VARIEDAD[rfcTable_IR_VARIEDAD.RowCount];
            int i_IR_VARIEDAD = 0;
            foreach (IRfcStructure row in rfcTable_IR_VARIEDAD)
            {
                ZMOV_10022_IR_VARIEDAD datoTabla = new ZMOV_10022_IR_VARIEDAD();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_VARIEDAD[i_IR_VARIEDAD] = datoTabla; ++i_IR_VARIEDAD;
            }
            IRfcTable rfcTable_IR_WERKS = rfcFunction.GetTable("IR_WERKS");
            res.IR_WERKS = new ZMOV_10022_IR_WERKS[rfcTable_IR_WERKS.RowCount];
            int i_IR_WERKS = 0;
            foreach (IRfcStructure row in rfcTable_IR_WERKS)
            {
                ZMOV_10022_IR_WERKS datoTabla = new ZMOV_10022_IR_WERKS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_WERKS[i_IR_WERKS] = datoTabla; ++i_IR_WERKS;
            }
            IRfcTable rfcTable_ET_LAMPA = rfcFunction.GetTable("ET_LAMPA");
            res.ET_LAMPA = new ZMOV_10022_ET_LAMPA[rfcTable_ET_LAMPA.RowCount];
            int i_ET_LAMPA = 0;
            foreach (IRfcStructure row in rfcTable_ET_LAMPA)
            {
                ZMOV_10022_ET_LAMPA datoTabla = new ZMOV_10022_ET_LAMPA();
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.POR_APER = row.GetDecimal("POR_APER");
                datoTabla.CBM = row.GetString("CBM");
                res.ET_LAMPA[i_ET_LAMPA] = datoTabla; ++i_ET_LAMPA;
            }

            return res;
        }
    }
    public class request_ZMOV_10022
    {
       /* public String IR_ESPECIE;
        public String IR_VARIEDAD;
        public String IR_WERKS;*/
        public ZMOV_10022_IR_ESPECIE[] IR_ESPECIE;
        public ZMOV_10022_IR_VARIEDAD[] IR_VARIEDAD;
        public ZMOV_10022_IR_WERKS[] IR_WERKS;
    }
    public class responce_ZMOV_10022
    {
        public ZMOV_10022_IR_ESPECIE[] IR_ESPECIE;
        public ZMOV_10022_IR_VARIEDAD[] IR_VARIEDAD;
        public ZMOV_10022_IR_WERKS[] IR_WERKS;
        public ZMOV_10022_ET_LAMPA[] ET_LAMPA;
    }
    public class ZMOV_10022_IR_ESPECIE
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10022_IR_VARIEDAD
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10022_IR_WERKS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_10022_ET_LAMPA
    {
        public String WERKS;
        public String ESPECIE;
        public String VARIEDAD;
        public Decimal POR_APER;
        public String CBM;
    }

}