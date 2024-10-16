using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMF_GET_MOVIMIENTOS
    {
        public responce_ZMF_GET_MOVIMIENTOS sapRun(request_ZMF_GET_MOVIMIENTOS import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMF_GET_MOVIMIENTOS");

            rfcFunction.SetValue("IR_BUDAT", import.IR_BUDAT);
            rfcFunction.SetValue("IR_BWART", import.IR_BWART);
            rfcFunction.SetValue("IR_CHARG", import.IR_CHARG);
            rfcFunction.SetValue("IR_MATNR", import.IR_MATNR);
            rfcFunction.SetValue("IR_MBLNR", import.IR_MBLNR);
            rfcFunction.SetValue("IR_MJAHR", import.IR_MJAHR);
            rfcFunction.SetValue("IR_WERKS", import.IR_WERKS);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMF_GET_MOVIMIENTOS res = new responce_ZMF_GET_MOVIMIENTOS();
            IRfcTable rfcTable_IR_BUDAT = rfcFunction.GetTable("IR_BUDAT");
            res.IR_BUDAT = new ZMF_GET_MOVIMIENTOS_IR_BUDAT[rfcTable_IR_BUDAT.RowCount];
            int i_IR_BUDAT = 0;
            foreach (IRfcStructure row in rfcTable_IR_BUDAT)
            {
                ZMF_GET_MOVIMIENTOS_IR_BUDAT datoTabla = new ZMF_GET_MOVIMIENTOS_IR_BUDAT();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_BUDAT[i_IR_BUDAT] = datoTabla; ++i_IR_BUDAT;
            }
            IRfcTable rfcTable_IR_BWART = rfcFunction.GetTable("IR_BWART");
            res.IR_BWART = new ZMF_GET_MOVIMIENTOS_IR_BWART[rfcTable_IR_BWART.RowCount];
            int i_IR_BWART = 0;
            foreach (IRfcStructure row in rfcTable_IR_BWART)
            {
                ZMF_GET_MOVIMIENTOS_IR_BWART datoTabla = new ZMF_GET_MOVIMIENTOS_IR_BWART();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_BWART[i_IR_BWART] = datoTabla; ++i_IR_BWART;
            }
            IRfcTable rfcTable_IR_CHARG = rfcFunction.GetTable("IR_CHARG");
            res.IR_CHARG = new ZMF_GET_MOVIMIENTOS_IR_CHARG[rfcTable_IR_CHARG.RowCount];
            int i_IR_CHARG = 0;
            foreach (IRfcStructure row in rfcTable_IR_CHARG)
            {
                ZMF_GET_MOVIMIENTOS_IR_CHARG datoTabla = new ZMF_GET_MOVIMIENTOS_IR_CHARG();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_CHARG[i_IR_CHARG] = datoTabla; ++i_IR_CHARG;
            }
            IRfcTable rfcTable_IR_MATNR = rfcFunction.GetTable("IR_MATNR");
            res.IR_MATNR = new ZMF_GET_MOVIMIENTOS_IR_MATNR[rfcTable_IR_MATNR.RowCount];
            int i_IR_MATNR = 0;
            foreach (IRfcStructure row in rfcTable_IR_MATNR)
            {
                ZMF_GET_MOVIMIENTOS_IR_MATNR datoTabla = new ZMF_GET_MOVIMIENTOS_IR_MATNR();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MATNR[i_IR_MATNR] = datoTabla; ++i_IR_MATNR;
            }
            IRfcTable rfcTable_IR_MBLNR = rfcFunction.GetTable("IR_MBLNR");
            res.IR_MBLNR = new ZMF_GET_MOVIMIENTOS_IR_MBLNR[rfcTable_IR_MBLNR.RowCount];
            int i_IR_MBLNR = 0;
            foreach (IRfcStructure row in rfcTable_IR_MBLNR)
            {
                ZMF_GET_MOVIMIENTOS_IR_MBLNR datoTabla = new ZMF_GET_MOVIMIENTOS_IR_MBLNR();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_MBLNR[i_IR_MBLNR] = datoTabla; ++i_IR_MBLNR;
            }
            IRfcTable rfcTable_IR_MJAHR = rfcFunction.GetTable("IR_MJAHR");
            res.IR_MJAHR = new ZMF_GET_MOVIMIENTOS_IR_MJAHR[rfcTable_IR_MJAHR.RowCount];
            int i_IR_MJAHR = 0;
            foreach (IRfcStructure row in rfcTable_IR_MJAHR)
            {
                ZMF_GET_MOVIMIENTOS_IR_MJAHR datoTabla = new ZMF_GET_MOVIMIENTOS_IR_MJAHR();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetInt("LOW");
                datoTabla.HIGH = row.GetInt("HIGH");
                res.IR_MJAHR[i_IR_MJAHR] = datoTabla; ++i_IR_MJAHR;
            }
            IRfcTable rfcTable_IR_WERKS = rfcFunction.GetTable("IR_WERKS");
            res.IR_WERKS = new ZMF_GET_MOVIMIENTOS_IR_WERKS[rfcTable_IR_WERKS.RowCount];
            int i_IR_WERKS = 0;
            foreach (IRfcStructure row in rfcTable_IR_WERKS)
            {
                ZMF_GET_MOVIMIENTOS_IR_WERKS datoTabla = new ZMF_GET_MOVIMIENTOS_IR_WERKS();
                datoTabla.SIGN = row.GetString("SIGN");
                datoTabla.OPTION = row.GetString("OPTION");
                datoTabla.LOW = row.GetString("LOW");
                datoTabla.HIGH = row.GetString("HIGH");
                res.IR_WERKS[i_IR_WERKS] = datoTabla; ++i_IR_WERKS;
            }
            IRfcTable rfcTable_ET_MSEG = rfcFunction.GetTable("ET_MSEG");
            res.ET_MSEG = new ZMF_GET_MOVIMIENTOS_ET_MSEG[rfcTable_ET_MSEG.RowCount];
            int i_ET_MSEG = 0;
            foreach (IRfcStructure row in rfcTable_ET_MSEG)
            {
                ZMF_GET_MOVIMIENTOS_ET_MSEG datoTabla = new ZMF_GET_MOVIMIENTOS_ET_MSEG();
                datoTabla.MANDT = row.GetString("MANDT");
                datoTabla.MBLNR = row.GetString("MBLNR");
                datoTabla.MJAHR = row.GetInt("MJAHR");
                datoTabla.MANDT_I = row.GetString("MANDT_I");
                datoTabla.MBLNR_I = row.GetString("MBLNR_I");
                datoTabla.MJAHR_I = row.GetInt("MJAHR_I");
                datoTabla.ZEILE_I = row.GetInt("ZEILE_I");
                datoTabla.VGART = row.GetString("VGART");
                datoTabla.BLART = row.GetString("BLART");
                datoTabla.BLAUM = row.GetString("BLAUM");
                datoTabla.BLDAT = row.GetString("BLDAT");
                datoTabla.BUDAT = row.GetString("BUDAT");
                datoTabla.CPUDT = row.GetString("CPUDT");
                datoTabla.CPUTM = row.GetString("CPUTM");
                datoTabla.AEDAT = row.GetString("AEDAT");
                datoTabla.USNAM = row.GetString("USNAM");
                datoTabla.TCODE = row.GetString("TCODE");
                datoTabla.XBLNR = row.GetString("XBLNR");
                datoTabla.BKTXT = row.GetString("BKTXT");
                datoTabla.FRATH = row.GetDecimal("FRATH");
                datoTabla.FRBNR = row.GetString("FRBNR");
                datoTabla.WEVER = row.GetString("WEVER");
                datoTabla.XABLN = row.GetString("XABLN");
                datoTabla.AWSYS = row.GetString("AWSYS");
                datoTabla.BLA2D = row.GetString("BLA2D");
                datoTabla.TCODE2 = row.GetString("TCODE2");
                datoTabla.BFWMS = row.GetString("BFWMS");
                datoTabla.EXNUM = row.GetString("EXNUM");
                datoTabla.LINE_ID_I = row.GetInt("LINE_ID_I");
                datoTabla.PARENT_ID_I = row.GetInt("PARENT_ID_I");
                datoTabla.LINE_DEPTH_I = row.GetInt("LINE_DEPTH_I");
                datoTabla.BWART_I = row.GetString("BWART_I");
                datoTabla.XAUTO_I = row.GetString("XAUTO_I");
                datoTabla.MATNR_I = row.GetString("MATNR_I");
                datoTabla.WERKS_I = row.GetString("WERKS_I");
                datoTabla.LGORT_I = row.GetString("LGORT_I");
                datoTabla.CHARG_I = row.GetString("CHARG_I");
                datoTabla.INSMK_I = row.GetString("INSMK_I");
                datoTabla.ZUSCH_I = row.GetString("ZUSCH_I");
                datoTabla.ZUSTD_I = row.GetString("ZUSTD_I");
                datoTabla.SOBKZ_I = row.GetString("SOBKZ_I");
                datoTabla.LIFNR_I = row.GetString("LIFNR_I");
                datoTabla.KUNNR_I = row.GetString("KUNNR_I");
                datoTabla.KDAUF_I = row.GetString("KDAUF_I");
                datoTabla.KDPOS_I = row.GetInt("KDPOS_I");
                datoTabla.KDEIN_I = row.GetInt("KDEIN_I");
                datoTabla.PLPLA_I = row.GetString("PLPLA_I");
                datoTabla.SHKZG_I = row.GetString("SHKZG_I");
                datoTabla.WAERS_I = row.GetString("WAERS_I");
                datoTabla.DMBTR_I = row.GetDecimal("DMBTR_I");
                datoTabla.BNBTR_I = row.GetDecimal("BNBTR_I");
                datoTabla.BUALT_I = row.GetDecimal("BUALT_I");
                datoTabla.SHKUM_I = row.GetString("SHKUM_I");
                datoTabla.DMBUM_I = row.GetDecimal("DMBUM_I");
                datoTabla.BWTAR_I = row.GetString("BWTAR_I");
                datoTabla.MENGE_I = row.GetDecimal("MENGE_I");
                datoTabla.MEINS_I = row.GetString("MEINS_I");
                datoTabla.ERFMG_I = row.GetDecimal("ERFMG_I");
                datoTabla.ERFME_I = row.GetString("ERFME_I");
                datoTabla.BPMNG_I = row.GetDecimal("BPMNG_I");
                datoTabla.BPRME_I = row.GetString("BPRME_I");
                datoTabla.EBELN_I = row.GetString("EBELN_I");
                datoTabla.EBELP_I = row.GetInt("EBELP_I");
                datoTabla.LFBJA_I = row.GetInt("LFBJA_I");
                datoTabla.LFBNR_I = row.GetString("LFBNR_I");
                datoTabla.LFPOS_I = row.GetInt("LFPOS_I");
                datoTabla.SJAHR_I = row.GetInt("SJAHR_I");
                datoTabla.SMBLN_I = row.GetString("SMBLN_I");
                datoTabla.SMBLP_I = row.GetInt("SMBLP_I");
                datoTabla.ELIKZ_I = row.GetString("ELIKZ_I");
                datoTabla.SGTXT_I = row.GetString("SGTXT_I");
                datoTabla.EQUNR_I = row.GetString("EQUNR_I");
                datoTabla.WEMPF_I = row.GetString("WEMPF_I");
                datoTabla.ABLAD_I = row.GetString("ABLAD_I");
                datoTabla.GSBER_I = row.GetString("GSBER_I");
                datoTabla.KOKRS_I = row.GetString("KOKRS_I");
                datoTabla.PARGB_I = row.GetString("PARGB_I");
                datoTabla.PARBU_I = row.GetString("PARBU_I");
                datoTabla.KOSTL_I = row.GetString("KOSTL_I");
                datoTabla.PROJN_I = row.GetString("PROJN_I");
                datoTabla.AUFNR_I = row.GetString("AUFNR_I");
                datoTabla.ANLN1_I = row.GetString("ANLN1_I");
                datoTabla.ANLN2_I = row.GetString("ANLN2_I");
                datoTabla.XSKST_I = row.GetString("XSKST_I");
                datoTabla.XSAUF_I = row.GetString("XSAUF_I");
                datoTabla.XSPRO_I = row.GetString("XSPRO_I");
                datoTabla.XSERG_I = row.GetString("XSERG_I");
                datoTabla.GJAHR_I = row.GetInt("GJAHR_I");
                datoTabla.XRUEM_I = row.GetString("XRUEM_I");
                datoTabla.XRUEJ_I = row.GetString("XRUEJ_I");
                datoTabla.BUKRS_I = row.GetString("BUKRS_I");
                datoTabla.BELNR_I = row.GetString("BELNR_I");
                datoTabla.BUZEI_I = row.GetInt("BUZEI_I");
                datoTabla.BELUM_I = row.GetString("BELUM_I");
                datoTabla.BUZUM_I = row.GetInt("BUZUM_I");
                datoTabla.RSNUM_I = row.GetInt("RSNUM_I");
                datoTabla.RSPOS_I = row.GetInt("RSPOS_I");
                datoTabla.KZEAR_I = row.GetString("KZEAR_I");
                datoTabla.PBAMG_I = row.GetDecimal("PBAMG_I");
                datoTabla.KZSTR_I = row.GetString("KZSTR_I");
                datoTabla.UMMAT_I = row.GetString("UMMAT_I");
                datoTabla.UMWRK_I = row.GetString("UMWRK_I");
                datoTabla.UMLGO_I = row.GetString("UMLGO_I");
                datoTabla.UMCHA_I = row.GetString("UMCHA_I");
                datoTabla.UMZST_I = row.GetString("UMZST_I");
                datoTabla.UMZUS_I = row.GetString("UMZUS_I");
                datoTabla.UMBAR_I = row.GetString("UMBAR_I");
                datoTabla.UMSOK_I = row.GetString("UMSOK_I");
                datoTabla.KZBEW_I = row.GetString("KZBEW_I");
                datoTabla.KZVBR_I = row.GetString("KZVBR_I");
                datoTabla.KZZUG_I = row.GetString("KZZUG_I");
                datoTabla.WEUNB_I = row.GetString("WEUNB_I");
                datoTabla.PALAN_I = row.GetDecimal("PALAN_I");
                datoTabla.LGNUM_I = row.GetString("LGNUM_I");
                datoTabla.LGTYP_I = row.GetString("LGTYP_I");
                datoTabla.LGPLA_I = row.GetString("LGPLA_I");
                datoTabla.BESTQ_I = row.GetString("BESTQ_I");
                datoTabla.BWLVS_I = row.GetInt("BWLVS_I");
                datoTabla.TBNUM_I = row.GetInt("TBNUM_I");
                datoTabla.TBPOS_I = row.GetInt("TBPOS_I");
                datoTabla.XBLVS_I = row.GetString("XBLVS_I");
                datoTabla.VSCHN_I = row.GetString("VSCHN_I");
                datoTabla.NSCHN_I = row.GetString("NSCHN_I");
                datoTabla.DYPLA_I = row.GetString("DYPLA_I");
                datoTabla.UBNUM_I = row.GetInt("UBNUM_I");
                datoTabla.TBPRI_I = row.GetString("TBPRI_I");
                datoTabla.TANUM_I = row.GetInt("TANUM_I");
                datoTabla.WEANZ_I = row.GetInt("WEANZ_I");
                datoTabla.GRUND_I = row.GetInt("GRUND_I");
                datoTabla.EVERS_I = row.GetString("EVERS_I");
                datoTabla.EVERE_I = row.GetString("EVERE_I");
                datoTabla.IMKEY_I = row.GetString("IMKEY_I");
                datoTabla.KSTRG_I = row.GetString("KSTRG_I");
                datoTabla.PAOBJNR_I = row.GetInt("PAOBJNR_I");
                datoTabla.PRCTR_I = row.GetString("PRCTR_I");
                datoTabla.PS_PSP_PNR_I = row.GetInt("PS_PSP_PNR_I");
                datoTabla.NPLNR_I = row.GetString("NPLNR_I");
                datoTabla.AUFPL_I = row.GetInt("AUFPL_I");
                datoTabla.APLZL_I = row.GetInt("APLZL_I");
                datoTabla.AUFPS_I = row.GetInt("AUFPS_I");
                datoTabla.VPTNR_I = row.GetString("VPTNR_I");
                datoTabla.FIPOS_I = row.GetString("FIPOS_I");
                datoTabla.SAKTO_I = row.GetString("SAKTO_I");
                datoTabla.BSTMG_I = row.GetDecimal("BSTMG_I");
                datoTabla.BSTME_I = row.GetString("BSTME_I");
                datoTabla.XWSBR_I = row.GetString("XWSBR_I");
                datoTabla.EMLIF_I = row.GetString("EMLIF_I");
                datoTabla.EXBWR_I = row.GetDecimal("EXBWR_I");
                datoTabla.VKWRT_I = row.GetDecimal("VKWRT_I");
                datoTabla.AKTNR_I = row.GetString("AKTNR_I");
                datoTabla.ZEKKN_I = row.GetInt("ZEKKN_I");
                datoTabla.VFDAT_I = row.GetString("VFDAT_I");
                datoTabla.CUOBJ_CH_I = row.GetInt("CUOBJ_CH_I");
                datoTabla.EXVKW_I = row.GetDecimal("EXVKW_I");
                datoTabla.PPRCTR_I = row.GetString("PPRCTR_I");
                datoTabla.RSART_I = row.GetString("RSART_I");
                datoTabla.GEBER_I = row.GetString("GEBER_I");
                datoTabla.FISTL_I = row.GetString("FISTL_I");
                datoTabla.MATBF_I = row.GetString("MATBF_I");
                datoTabla.UMMAB_I = row.GetString("UMMAB_I");
                datoTabla.BUSTM_I = row.GetString("BUSTM_I");
                datoTabla.BUSTW_I = row.GetString("BUSTW_I");
                datoTabla.MENGU_I = row.GetString("MENGU_I");
                datoTabla.WERTU_I = row.GetString("WERTU_I");
                datoTabla.LBKUM_I = row.GetDecimal("LBKUM_I");
                datoTabla.SALK3_I = row.GetDecimal("SALK3_I");
                datoTabla.VPRSV_I = row.GetString("VPRSV_I");
                datoTabla.FKBER_I = row.GetString("FKBER_I");
                datoTabla.DABRBZ_I = row.GetString("DABRBZ_I");
                datoTabla.VKWRA_I = row.GetDecimal("VKWRA_I");
                datoTabla.DABRZ_I = row.GetString("DABRZ_I");
                datoTabla.XBEAU_I = row.GetString("XBEAU_I");
                datoTabla.LSMNG_I = row.GetDecimal("LSMNG_I");
                datoTabla.LSMEH_I = row.GetString("LSMEH_I");
                datoTabla.KZBWS_I = row.GetString("KZBWS_I");
                datoTabla.QINSPST_I = row.GetString("QINSPST_I");
                datoTabla.URZEI_I = row.GetInt("URZEI_I");
                datoTabla.J_1BEXBASE_I = row.GetDecimal("J_1BEXBASE_I");
                datoTabla.MWSKZ_I = row.GetString("MWSKZ_I");
                datoTabla.TXJCD_I = row.GetString("TXJCD_I");
                datoTabla.EMATN_I = row.GetString("EMATN_I");
                datoTabla.J_1AGIRUPD_I = row.GetString("J_1AGIRUPD_I");
                datoTabla.VKMWS_I = row.GetString("VKMWS_I");
                datoTabla.HSDAT_I = row.GetString("HSDAT_I");
                datoTabla.BERKZ_I = row.GetString("BERKZ_I");
                datoTabla.MAT_KDAUF_I = row.GetString("MAT_KDAUF_I");
                datoTabla.MAT_KDPOS_I = row.GetInt("MAT_KDPOS_I");
                datoTabla.MAT_PSPNR_I = row.GetInt("MAT_PSPNR_I");
                datoTabla.XWOFF_I = row.GetString("XWOFF_I");
                datoTabla.BEMOT_I = row.GetString("BEMOT_I");
                datoTabla.PRZNR_I = row.GetString("PRZNR_I");
                datoTabla.LLIEF_I = row.GetString("LLIEF_I");
                datoTabla.LSTAR_I = row.GetString("LSTAR_I");
                datoTabla.XOBEW_I = row.GetString("XOBEW_I");
                res.ET_MSEG[i_ET_MSEG] = datoTabla; ++i_ET_MSEG;
            }
            IRfcTable rfcTable_LT_QUERY_LOTE = rfcFunction.GetTable("LT_QUERY_LOTE");
            res.LT_QUERY_LOTE = new ZMF_GET_MOVIMIENTOS_LT_QUERY_LOTE[rfcTable_LT_QUERY_LOTE.RowCount];
            int i_LT_QUERY_LOTE = 0;
            foreach (IRfcStructure row in rfcTable_LT_QUERY_LOTE)
            {
                ZMF_GET_MOVIMIENTOS_LT_QUERY_LOTE datoTabla = new ZMF_GET_MOVIMIENTOS_LT_QUERY_LOTE();
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
                res.LT_QUERY_LOTE[i_LT_QUERY_LOTE] = datoTabla; ++i_LT_QUERY_LOTE;
            }

            return res;
        }
    }
    public class request_ZMF_GET_MOVIMIENTOS
    {
        public String IR_BUDAT;
        public String IR_BWART;
        public String IR_CHARG;
        public String IR_MATNR;
        public String IR_MBLNR;
        public String IR_MJAHR;
        public String IR_WERKS;
    }
    public class responce_ZMF_GET_MOVIMIENTOS
    {
        public ZMF_GET_MOVIMIENTOS_IR_BUDAT[] IR_BUDAT;
        public ZMF_GET_MOVIMIENTOS_IR_BWART[] IR_BWART;
        public ZMF_GET_MOVIMIENTOS_IR_CHARG[] IR_CHARG;
        public ZMF_GET_MOVIMIENTOS_IR_MATNR[] IR_MATNR;
        public ZMF_GET_MOVIMIENTOS_IR_MBLNR[] IR_MBLNR;
        public ZMF_GET_MOVIMIENTOS_IR_MJAHR[] IR_MJAHR;
        public ZMF_GET_MOVIMIENTOS_IR_WERKS[] IR_WERKS;
        public ZMF_GET_MOVIMIENTOS_ET_MSEG[] ET_MSEG;
        public ZMF_GET_MOVIMIENTOS_LT_QUERY_LOTE[] LT_QUERY_LOTE;
    }
    public class ZMF_GET_MOVIMIENTOS_IR_BUDAT
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMF_GET_MOVIMIENTOS_IR_BWART
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMF_GET_MOVIMIENTOS_IR_CHARG
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMF_GET_MOVIMIENTOS_IR_MATNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMF_GET_MOVIMIENTOS_IR_MBLNR
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMF_GET_MOVIMIENTOS_IR_MJAHR
    {
        public String SIGN;
        public String OPTION;
        public Int32 LOW;
        public Int32 HIGH;
    }
    public class ZMF_GET_MOVIMIENTOS_IR_WERKS
    {
        public String SIGN;
        public String OPTION;
        public String LOW;
        public String HIGH;
    }
    public class ZMF_GET_MOVIMIENTOS_ET_MSEG
    {
        public String MANDT;
        public String MBLNR;
        public Int32 MJAHR;
        public String MANDT_I;
        public String MBLNR_I;
        public Int32 MJAHR_I;
        public Int32 ZEILE_I;
        public String VGART;
        public String BLART;
        public String BLAUM;
        public String BLDAT;
        public String BUDAT;
        public String CPUDT;
        public String CPUTM;
        public String AEDAT;
        public String USNAM;
        public String TCODE;
        public String XBLNR;
        public String BKTXT;
        public Decimal FRATH;
        public String FRBNR;
        public String WEVER;
        public String XABLN;
        public String AWSYS;
        public String BLA2D;
        public String TCODE2;
        public String BFWMS;
        public String EXNUM;
        public Int32 LINE_ID_I;
        public Int32 PARENT_ID_I;
        public Int32 LINE_DEPTH_I;
        public String BWART_I;
        public String XAUTO_I;
        public String MATNR_I;
        public String WERKS_I;
        public String LGORT_I;
        public String CHARG_I;
        public String INSMK_I;
        public String ZUSCH_I;
        public String ZUSTD_I;
        public String SOBKZ_I;
        public String LIFNR_I;
        public String KUNNR_I;
        public String KDAUF_I;
        public Int32 KDPOS_I;
        public Int32 KDEIN_I;
        public String PLPLA_I;
        public String SHKZG_I;
        public String WAERS_I;
        public Decimal DMBTR_I;
        public Decimal BNBTR_I;
        public Decimal BUALT_I;
        public String SHKUM_I;
        public Decimal DMBUM_I;
        public String BWTAR_I;
        public Decimal MENGE_I;
        public String MEINS_I;
        public Decimal ERFMG_I;
        public String ERFME_I;
        public Decimal BPMNG_I;
        public String BPRME_I;
        public String EBELN_I;
        public Int32 EBELP_I;
        public Int32 LFBJA_I;
        public String LFBNR_I;
        public Int32 LFPOS_I;
        public Int32 SJAHR_I;
        public String SMBLN_I;
        public Int32 SMBLP_I;
        public String ELIKZ_I;
        public String SGTXT_I;
        public String EQUNR_I;
        public String WEMPF_I;
        public String ABLAD_I;
        public String GSBER_I;
        public String KOKRS_I;
        public String PARGB_I;
        public String PARBU_I;
        public String KOSTL_I;
        public String PROJN_I;
        public String AUFNR_I;
        public String ANLN1_I;
        public String ANLN2_I;
        public String XSKST_I;
        public String XSAUF_I;
        public String XSPRO_I;
        public String XSERG_I;
        public Int32 GJAHR_I;
        public String XRUEM_I;
        public String XRUEJ_I;
        public String BUKRS_I;
        public String BELNR_I;
        public Int32 BUZEI_I;
        public String BELUM_I;
        public Int32 BUZUM_I;
        public Int32 RSNUM_I;
        public Int32 RSPOS_I;
        public String KZEAR_I;
        public Decimal PBAMG_I;
        public String KZSTR_I;
        public String UMMAT_I;
        public String UMWRK_I;
        public String UMLGO_I;
        public String UMCHA_I;
        public String UMZST_I;
        public String UMZUS_I;
        public String UMBAR_I;
        public String UMSOK_I;
        public String KZBEW_I;
        public String KZVBR_I;
        public String KZZUG_I;
        public String WEUNB_I;
        public Decimal PALAN_I;
        public String LGNUM_I;
        public String LGTYP_I;
        public String LGPLA_I;
        public String BESTQ_I;
        public Int32 BWLVS_I;
        public Int32 TBNUM_I;
        public Int32 TBPOS_I;
        public String XBLVS_I;
        public String VSCHN_I;
        public String NSCHN_I;
        public String DYPLA_I;
        public Int32 UBNUM_I;
        public String TBPRI_I;
        public Int32 TANUM_I;
        public Int32 WEANZ_I;
        public Int32 GRUND_I;
        public String EVERS_I;
        public String EVERE_I;
        public String IMKEY_I;
        public String KSTRG_I;
        public Int32 PAOBJNR_I;
        public String PRCTR_I;
        public Int32 PS_PSP_PNR_I;
        public String NPLNR_I;
        public Int32 AUFPL_I;
        public Int32 APLZL_I;
        public Int32 AUFPS_I;
        public String VPTNR_I;
        public String FIPOS_I;
        public String SAKTO_I;
        public Decimal BSTMG_I;
        public String BSTME_I;
        public String XWSBR_I;
        public String EMLIF_I;
        public Decimal EXBWR_I;
        public Decimal VKWRT_I;
        public String AKTNR_I;
        public Int32 ZEKKN_I;
        public String VFDAT_I;
        public Int32 CUOBJ_CH_I;
        public Decimal EXVKW_I;
        public String PPRCTR_I;
        public String RSART_I;
        public String GEBER_I;
        public String FISTL_I;
        public String MATBF_I;
        public String UMMAB_I;
        public String BUSTM_I;
        public String BUSTW_I;
        public String MENGU_I;
        public String WERTU_I;
        public Decimal LBKUM_I;
        public Decimal SALK3_I;
        public String VPRSV_I;
        public String FKBER_I;
        public String DABRBZ_I;
        public Decimal VKWRA_I;
        public String DABRZ_I;
        public String XBEAU_I;
        public Decimal LSMNG_I;
        public String LSMEH_I;
        public String KZBWS_I;
        public String QINSPST_I;
        public Int32 URZEI_I;
        public Decimal J_1BEXBASE_I;
        public String MWSKZ_I;
        public String TXJCD_I;
        public String EMATN_I;
        public String J_1AGIRUPD_I;
        public String VKMWS_I;
        public String HSDAT_I;
        public String BERKZ_I;
        public String MAT_KDAUF_I;
        public Int32 MAT_KDPOS_I;
        public Int32 MAT_PSPNR_I;
        public String XWOFF_I;
        public String BEMOT_I;
        public String PRZNR_I;
        public String LLIEF_I;
        public String LSTAR_I;
        public String XOBEW_I;
    }
    public class ZMF_GET_MOVIMIENTOS_LT_QUERY_LOTE
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
    }

}