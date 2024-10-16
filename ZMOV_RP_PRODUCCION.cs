using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class ZMOV_RP_PRODUCCION
    {
        public responce_ZMOV_RP_PRODUCCION sapRun(request_ZMOV_RP_PRODUCCION import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_RP_PRODUCCION");

            IRfcTable rfcTable_IR_CHARG_I = rfcFunction.GetTable("IR_CHARG");
            foreach (ZMOV_RP_PRODUCCION_IR_CHARG row in import.IR_CHARG)
            {
                rfcTable_IR_CHARG_I.Append();
                ZMOV_RP_PRODUCCION_IR_CHARG datoTabla = new ZMOV_RP_PRODUCCION_IR_CHARG();
                rfcTable_IR_CHARG_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_CHARG_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_CHARG_I.SetValue("LOW", row.LOW);
                rfcTable_IR_CHARG_I.SetValue("HIGH", row.HIGH);
            }
            

            IRfcTable rfcTable_IR_BUDAT_I = rfcFunction.GetTable("IR_BUDAT");
            foreach (ZMOV_RP_PRODUCCION_IR_BUDAT row in import.IR_BUDAT)
            {
                rfcTable_IR_BUDAT_I.Append();
                ZMOV_RP_PRODUCCION_IR_BUDAT datoTabla = new ZMOV_RP_PRODUCCION_IR_BUDAT();
                rfcTable_IR_BUDAT_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_BUDAT_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_BUDAT_I.SetValue("LOW", row.LOW);
                rfcTable_IR_BUDAT_I.SetValue("HIGH", row.HIGH);
            }
            
            
            IRfcTable rfcTable_IR_EXTWG_I = rfcFunction.GetTable("IR_EXTWG");
            foreach (ZMOV_RP_PRODUCCION_IR_EXTWG row in import.IR_EXTWG)
            {
                rfcTable_IR_EXTWG_I.Append();
                ZMOV_RP_PRODUCCION_IR_EXTWG datoTabla = new ZMOV_RP_PRODUCCION_IR_EXTWG();
                rfcTable_IR_EXTWG_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_EXTWG_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_EXTWG_I.SetValue("LOW", row.LOW);
                rfcTable_IR_EXTWG_I.SetValue("HIGH", row.HIGH);
            }
            
            //rfcFunction.SetValue("IR_LIFNR", import.IR_LIFNR);
            IRfcTable rfcTable_IR_LIFNR_I = rfcFunction.GetTable("IR_LIFNR");
            foreach (ZMOV_RP_PRODUCCION_IR_LIFNR row in import.IR_LIFNR)
            {
                rfcTable_IR_LIFNR_I.Append();
                ZMOV_RP_PRODUCCION_IR_LIFNR datoTabla = new ZMOV_RP_PRODUCCION_IR_LIFNR();
                rfcTable_IR_LIFNR_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_LIFNR_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_LIFNR_I.SetValue("LOW", row.LOW);
                rfcTable_IR_LIFNR_I.SetValue("HIGH", row.HIGH);
            }
            
            
            IRfcTable rfcTable_IR_WERKS_I = rfcFunction.GetTable("IR_WERKS");
            foreach (ZMOV_RP_PRODUCCION_IR_WERKS row in import.IR_WERKS)
            {
                rfcTable_IR_WERKS_I.Append();
                ZMOV_RP_PRODUCCION_IR_WERKS datoTabla = new ZMOV_RP_PRODUCCION_IR_WERKS();
                rfcTable_IR_WERKS_I.SetValue("SIGN", row.SIGN);
                rfcTable_IR_WERKS_I.SetValue("OPTION", row.OPTION);
                rfcTable_IR_WERKS_I.SetValue("LOW", row.LOW);
                rfcTable_IR_WERKS_I.SetValue("HIGH", row.HIGH);
            }
            rfcFunction.SetValue("IR_WERKS", rfcTable_IR_WERKS_I);
            rfcFunction.SetValue("IR_CHARG", rfcTable_IR_CHARG_I);
            rfcFunction.SetValue("IV_PRODUC", import.IV_PRODUC);
            rfcFunction.SetValue("IV_SATELITE", import.IV_SATELITE);


            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_RP_PRODUCCION res = new responce_ZMOV_RP_PRODUCCION();
            IRfcTable rfcTable_IR_BUDAT = rfcFunction.GetTable("IR_BUDAT");
            res.IR_BUDAT = new ZMOV_RP_PRODUCCION_IR_BUDAT[rfcTable_IR_BUDAT.RowCount];
            int i_IR_BUDAT = 0;
            foreach (IRfcStructure row in rfcTable_IR_BUDAT)
            {
                ZMOV_RP_PRODUCCION_IR_BUDAT datoTabla = new ZMOV_RP_PRODUCCION_IR_BUDAT();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_BUDAT[i_IR_BUDAT] = datoTabla; ++i_IR_BUDAT;
            }
            IRfcTable rfcTable_IR_EXTWG = rfcFunction.GetTable("IR_EXTWG");
            res.IR_EXTWG = new ZMOV_RP_PRODUCCION_IR_EXTWG[rfcTable_IR_EXTWG.RowCount];
            int i_IR_EXTWG = 0;
            foreach (IRfcStructure row in rfcTable_IR_EXTWG)
            {
                ZMOV_RP_PRODUCCION_IR_EXTWG datoTabla = new ZMOV_RP_PRODUCCION_IR_EXTWG();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_EXTWG[i_IR_EXTWG] = datoTabla; ++i_IR_EXTWG;
            }
            IRfcTable rfcTable_IR_LIFNR = rfcFunction.GetTable("IR_LIFNR");
            res.IR_LIFNR = new ZMOV_RP_PRODUCCION_IR_LIFNR[rfcTable_IR_LIFNR.RowCount];
            int i_IR_LIFNR = 0;
            foreach (IRfcStructure row in rfcTable_IR_LIFNR)
            {
                ZMOV_RP_PRODUCCION_IR_LIFNR datoTabla = new ZMOV_RP_PRODUCCION_IR_LIFNR();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_LIFNR[i_IR_LIFNR] = datoTabla; ++i_IR_LIFNR;
            }
            IRfcTable rfcTable_IR_WERKS = rfcFunction.GetTable("IR_WERKS");
            res.IR_WERKS = new ZMOV_RP_PRODUCCION_IR_WERKS[rfcTable_IR_WERKS.RowCount];
            int i_IR_WERKS = 0;
            foreach (IRfcStructure row in rfcTable_IR_WERKS)
            {
                ZMOV_RP_PRODUCCION_IR_WERKS datoTabla = new ZMOV_RP_PRODUCCION_IR_WERKS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_WERKS[i_IR_WERKS] = datoTabla; ++i_IR_WERKS;
            }
            IRfcTable rfcTable_LT_DETALLE = rfcFunction.GetTable("LT_DETALLE");
            res.LT_DETALLE = new ZMOV_RP_PRODUCCION_LT_DETALLE[rfcTable_LT_DETALLE.RowCount];
            int i_LT_DETALLE = 0;
            string[] ELIMINAR = new string[rfcTable_LT_DETALLE.RowCount];
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();

            foreach (IRfcStructure row in rfcTable_LT_DETALLE)
            {
                if (import.IV_PRODUC == "X")
                {
                    cmd = new SqlCommand("[LT_DETALLE_INSERT]", connection);
                }
                else
                {
                    cmd = new SqlCommand("[INSERT_SATELITE]", connection);
                }
                string variedad = row.GetString("VARIEDAD").ToString();
                cmd.Parameters.Add(new SqlParameter("@WERKS", row.GetString("WERKS").ToString()));//1
                cmd.Parameters.Add(new SqlParameter("@XBLNR", row.GetString("XBLNR").ToString()));//2
                cmd.Parameters.Add(new SqlParameter("@MATNR", row.GetString("MATNR").ToString()));//3
                cmd.Parameters.Add(new SqlParameter("@MAKTX", row.GetString("MAKTX").ToString()));//4
                cmd.Parameters.Add(new SqlParameter("@CHARG", row.GetString("CHARG").ToString()));//5
                cmd.Parameters.Add(new SqlParameter("@BUDAT", row.GetString("BUDAT").ToString()));//6
                cmd.Parameters.Add(new SqlParameter("@LIFNR", row.GetString("LIFNR").ToString()));//7
                if (row.GetString("VARIEDAD").ToString() == "D'AGEN")
                {
                    variedad = "DAGEN";
                }
                cmd.Parameters.Add(new SqlParameter("@VARIEDAD", variedad));//8
                cmd.Parameters.Add(new SqlParameter("@VARIEDAD_ET", row.GetString("VARIEDAD_ET").ToString()));//9
                cmd.Parameters.Add(new SqlParameter("@CALIBRE", row.GetString("CALIBRE").ToString()));//10
                cmd.Parameters.Add(new SqlParameter("@CALIDAD", row.GetString("CALIDAD").ToString()));//11
                cmd.Parameters.Add(new SqlParameter("@MENGE", row.GetString("MENGE").ToString()));//12
                cmd.Parameters.Add(new SqlParameter("@MEI", row.GetString("MEI").ToString()));//13
                cmd.Parameters.Add(new SqlParameter("@BPMNG", decimal.Parse(row.GetString("BPMNG"))));//14
                cmd.Parameters.Add(new SqlParameter("@ERFME", row.GetString("ERFME").ToString()));//15
                cmd.Parameters.Add(new SqlParameter("@EWBEZ", row.GetString("EWBEZ").ToString()));//16

                cmd.Parameters.Add(new SqlParameter("@ELIMINAR", Array.IndexOf(ELIMINAR, row.GetString("XBLNR"))));//17
                cmd.Parameters.Add(new SqlParameter("@HORAINICIOPROCESO", row.GetString("HORAINICIOPROCESO").ToString()));//18
                cmd.Parameters.Add(new SqlParameter("@HORATERMINOPROCESO", row.GetString("HORATERMINOPROCESO").ToString()));//19
                cmd.Parameters.Add(new SqlParameter("@FECHATERMINOPROCESO", row.GetString("FECHATERMINOPROCESO").ToString()));//20
                cmd.Parameters.Add(new SqlParameter("@HORACIERRECUAD", row.GetString("HORACIERRECUAD").ToString()));//21
                cmd.Parameters.Add(new SqlParameter("@FECHACIERRECUAD", row.GetString("FECHACIERRECUAD").ToString()));//22


                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Close();
                if (Array.IndexOf(ELIMINAR, row.GetString("XBLNR")) < 0)
                {
                    ELIMINAR[i_LT_DETALLE] = row.GetString("XBLNR");
                }
                ZMOV_RP_PRODUCCION_LT_DETALLE datoTabla = new ZMOV_RP_PRODUCCION_LT_DETALLE();
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.XBLNR = row.GetString("XBLNR");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.MAKTX = row.GetString("MAKTX");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.BUDAT = row.GetString("BUDAT");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.CALIBRE = row.GetString("CALIBRE");
                datoTabla.CALIDAD = row.GetString("CALIDAD");
                datoTabla.MENGE = row.GetDecimal("MENGE");
                datoTabla.MEI = row.GetString("MEI");
                datoTabla.BPMNG = row.GetDecimal("BPMNG");
                datoTabla.ERFME = row.GetString("ERFME");
                datoTabla.EWBEZ = row.GetString("EWBEZ");
                
                res.LT_DETALLE[i_LT_DETALLE] = datoTabla; ++i_LT_DETALLE;
            }

            return res;
        }
    }
    public class request_ZMOV_RP_PRODUCCION
    {
        
        public ZMOV_RP_PRODUCCION_IR_BUDAT[] IR_BUDAT;
        
        public ZMOV_RP_PRODUCCION_IR_EXTWG[] IR_EXTWG;
        
        public ZMOV_RP_PRODUCCION_IR_LIFNR[] IR_LIFNR;
        
        public ZMOV_RP_PRODUCCION_IR_WERKS[] IR_WERKS;

        public ZMOV_RP_PRODUCCION_IR_CHARG[] IR_CHARG;

        public string IV_PRODUC;
        public string IV_SATELITE;
    }
    public class responce_ZMOV_RP_PRODUCCION
    {
        public ZMOV_RP_PRODUCCION_IR_BUDAT[] IR_BUDAT;
        public ZMOV_RP_PRODUCCION_IR_EXTWG[] IR_EXTWG;
        public ZMOV_RP_PRODUCCION_IR_LIFNR[] IR_LIFNR;
        public ZMOV_RP_PRODUCCION_IR_WERKS[] IR_WERKS;
        
        public ZMOV_RP_PRODUCCION_LT_DETALLE[] LT_DETALLE;
    }
    public class ZMOV_RP_PRODUCCION_IR_BUDAT
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_RP_PRODUCCION_IR_EXTWG
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_RP_PRODUCCION_IR_LIFNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_RP_PRODUCCION_IR_WERKS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMOV_RP_PRODUCCION_IR_CHARG
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }

    public class ZMOV_RP_PRODUCCION_LT_DETALLE
    {
        public String WERKS;
        public String XBLNR;
        public String MATNR;
        public String MAKTX;
        public String CHARG;
        public String BUDAT;
        public String LIFNR;
        public String VARIEDAD;
        public String VARIEDAD_ET;
        public String CALIBRE;
        public String CALIDAD;
        public Decimal MENGE;
        public String MEI;
        public Decimal BPMNG;
        public String ERFME;
        public String EWBEZ;
    }

}