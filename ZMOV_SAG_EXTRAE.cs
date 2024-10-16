using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_SAG_EXTRAE
    {
        public responce_ZMOV_SAG_EXTRAE sapRun(request_ZMOV_SAG_EXTRAE import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_SAG_EXTRAE");

            rfcFunction.SetValue("EXIDV2", import.EXIDV2);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_SAG_EXTRAE res = new responce_ZMOV_SAG_EXTRAE();
            IRfcTable rfcTable_IT_SAG = rfcFunction.GetTable("IT_SAG");
            res.IT_SAG = new ZMOV_SAG_EXTRAE_IT_SAG[rfcTable_IT_SAG.RowCount];
            int i_IT_SAG = 0;
            foreach (IRfcStructure row in rfcTable_IT_SAG)
            {
                ZMOV_SAG_EXTRAE_IT_SAG datoTabla = new ZMOV_SAG_EXTRAE_IT_SAG();
                datoTabla.VENUM = row.GetString("VENUM");
                datoTabla.EXIDV = row.GetString("EXIDV");
                datoTabla.EXIDV2 = row.GetString("EXIDV2");
                datoTabla.ZZFEC_INSP = row.GetString("ZZFEC_INSP");
                datoTabla.VELIN = row.GetString("VELIN");
                datoTabla.KZGVH = row.GetString("KZGVH");
                datoTabla.VEGR1 = row.GetString("VEGR1");
                datoTabla.VEGR2 = row.GetString("VEGR2");
                datoTabla.VEGR3 = row.GetString("VEGR3");
                datoTabla.VEGR4 = row.GetString("VEGR4");
                datoTabla.VEGR5 = row.GetString("VEGR5");
                datoTabla.INHALT = row.GetString("INHALT");
                datoTabla.STATUS = row.GetString("STATUS");
                datoTabla.EMBALA = row.GetString("EMBALA");
                datoTabla.MATNR = row.GetString("MATNR");
                datoTabla.CHARG = row.GetString("CHARG");
                datoTabla.VEMNG = row.GetDecimal("VEMNG");
                datoTabla.VEMEH = row.GetString("VEMEH");
                datoTabla.VARIEDAD = row.GetString("VARIEDAD");
                datoTabla.VARIEDAD_ET = row.GetString("VARIEDAD_ET");
                datoTabla.HSDAT = row.GetString("HSDAT");
                datoTabla.FCOSECHA = row.GetString("FCOSECHA");
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.LIFNR_ET = row.GetString("LIFNR_ET");
                datoTabla.NAME1 = row.GetString("NAME1");
                datoTabla.NAME1_ET = row.GetString("NAME1_ET");
                datoTabla.LIFNR_COMUNA = row.GetString("LIFNR_COMUNA");
                datoTabla.LIFNR_PROVINCIA = row.GetString("LIFNR_PROVINCIA");
                datoTabla.LIFNR_ET_COMUNA = row.GetString("LIFNR_ET_COMUNA");
                datoTabla.LIFNR_ET_PROVINCIA = row.GetString("LIFNR_ET_PROVINCIA");
                datoTabla.ESPECIE = row.GetString("ESPECIE");
                datoTabla.SAG_ESPECIE = row.GetString("SAG_ESPECIE");
                datoTabla.SAG_SDP = row.GetString("SAG_SDP");
                datoTabla.SAG_CSG = row.GetString("SAG_CSG");
                datoTabla.SAG_CSG_PROVINCIA = row.GetString("SAG_CSG_PROVINCIA");
                datoTabla.SAG_CSG_COMUNA = row.GetString("SAG_CSG_COMUNA");
                datoTabla.SAG_CSP = row.GetString("SAG_CSP");
                datoTabla.SAG_CSP_PACKING = row.GetString("SAG_CSP_PACKING");
                datoTabla.SAG_CSP_PROVINCIA = row.GetString("SAG_CSP_PROVINCIA");
                datoTabla.SAG_CSP_COMUNA = row.GetString("SAG_CSP_COMUNA");
                datoTabla.SAG_IDP = row.GetString("SAG_IDP");
                datoTabla.SAG_IDP_PROVINCIA = row.GetString("SAG_IDP_PROVINCIA");
                datoTabla.SAG_IDP_COMUNA = row.GetString("SAG_IDP_COMUNA");
                datoTabla.SAG_IDG = row.GetString("SAG_IDG");
                datoTabla.SAG_IDG_PROVINCIA = row.GetString("SAG_IDG_PROVINCIA");
                datoTabla.SAG_IDG_COMUNA = row.GetString("SAG_IDG_COMUNA");
                datoTabla.WERKS = row.GetString("WERKS");
                datoTabla.WERKS_NAME = row.GetString("WERKS_NAME");
                datoTabla.WERKS_COMUNA = row.GetString("WERKS_COMUNA");
                datoTabla.WERKS_PROVINCIA = row.GetString("WERKS_PROVINCIA");
                datoTabla.WERKS_CSP = row.GetString("WERKS_CSP");
                datoTabla.WERKS_FDA = row.GetString("WERKS_FDA");
                datoTabla.ZZPAIS_INSP1 = row.GetString("ZZPAIS_INSP1");
                datoTabla.ZZPAIS_INSP2 = row.GetString("ZZPAIS_INSP2");
                datoTabla.ZZPAIS_INSP3 = row.GetString("ZZPAIS_INSP3");
                datoTabla.ZZPAIS_INSP4 = row.GetString("ZZPAIS_INSP4");
                datoTabla.ZZPAIS_INSP5 = row.GetString("ZZPAIS_INSP5");
                datoTabla.ZZPAIS_INSP6 = row.GetString("ZZPAIS_INSP6");
                datoTabla.ZZPAIS_INSP7 = row.GetString("ZZPAIS_INSP7");
                datoTabla.ZZPAIS_INSP8 = row.GetString("ZZPAIS_INSP8");
                datoTabla.ZZPAIS_INSP9 = row.GetString("ZZPAIS_INSP9");
                datoTabla.ZZPAIS_INSP10 = row.GetString("ZZPAIS_INSP10");
                datoTabla.LOTE_PROCESO = row.GetString("LOTE_PROCESO");

                //datoTabla.ZZPAIS_INSP11 = row.GetString("ZZPAIS_INSP11");
                //datoTabla.ZZPAIS_INSP12 = row.GetString("ZZPAIS_INSP12");
                //datoTabla.ZZPAIS_INSP13 = row.GetString("ZZPAIS_INSP13");
                //datoTabla.ZZPAIS_INSP14 = row.GetString("ZZPAIS_INSP14");
                //datoTabla.ZZPAIS_INSP15 = row.GetString("ZZPAIS_INSP15");
                res.IT_SAG[i_IT_SAG] = datoTabla; ++i_IT_SAG;
            }

            return res;
        }
    }
    public class request_ZMOV_SAG_EXTRAE
    {
        public String EXIDV2;
    }
    public class responce_ZMOV_SAG_EXTRAE
    {
        public ZMOV_SAG_EXTRAE_IT_SAG[] IT_SAG;
    }
    public class ZMOV_SAG_EXTRAE_IT_SAG
    {
        public String VENUM;
        public String EXIDV;
        public String EXIDV2;
        public String ZZFEC_INSP;
        public String VELIN;
        public String KZGVH;
        public String VEGR1;
        public String VEGR2;
        public String VEGR3;
        public String VEGR4;
        public String VEGR5;
        public String INHALT;
        public String STATUS;
        public String EMBALA;
        public String MATNR;
        public String CHARG;
        public Decimal VEMNG;
        public String VEMEH;
        public String VARIEDAD;
        public String VARIEDAD_ET;
        public String HSDAT;
        public String FCOSECHA;
        public String LIFNR;
        public String LIFNR_ET;
        public String NAME1;
        public String NAME1_ET;
        public String LIFNR_COMUNA;
        public String LIFNR_PROVINCIA;
        public String LIFNR_ET_COMUNA;
        public String LIFNR_ET_PROVINCIA;
        public String ESPECIE;
        public String SAG_ESPECIE;
        public String SAG_SDP;
        public String SAG_CSG;
        public String SAG_CSG_PROVINCIA;
        public String SAG_CSG_COMUNA;
        public String SAG_CSP;
        public String SAG_CSP_PACKING;
        public String SAG_CSP_PROVINCIA;
        public String SAG_CSP_COMUNA;
        public String SAG_IDP;
        public String SAG_IDP_PROVINCIA;
        public String SAG_IDP_COMUNA;
        public String SAG_IDG;
        public String SAG_IDG_PROVINCIA;
        public String SAG_IDG_COMUNA;
        public String WERKS;
        public String WERKS_NAME;
        public String WERKS_COMUNA;
        public String WERKS_PROVINCIA;
        public String WERKS_CSP;
        public String WERKS_FDA;
        public String ZZPAIS_INSP1;
        public String ZZPAIS_INSP2;
        public String ZZPAIS_INSP3;
        public String ZZPAIS_INSP4;
        public String ZZPAIS_INSP5;
        public String ZZPAIS_INSP6;
        public String ZZPAIS_INSP7;
        public String ZZPAIS_INSP8;
        public String ZZPAIS_INSP9;
        public String ZZPAIS_INSP10;
        public String ZZPAIS_INSP11;
        public String ZZPAIS_INSP12;
        public String ZZPAIS_INSP13;
        public String ZZPAIS_INSP14;
        public String ZZPAIS_INSP15;
        public String LOTE_PROCESO;
    }

}