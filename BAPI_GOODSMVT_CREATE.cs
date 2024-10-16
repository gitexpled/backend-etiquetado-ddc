using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class BAPI_GOODSMVT_CREATE
    {
        public responce_BAPI_GOODSMVT_CREATE sapRun(request_BAPI_GOODSMVT_CREATE import, RfcDestination configSap = null, RfcRepository SapRfcRepository = null)
        {
            bool directo = false;
            configSap = RfcDestinationManager.GetDestination("DDC");
            SapRfcRepository = configSap.Repository;
            RfcSessionManager.BeginContext(configSap);
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("BAPI_GOODSMVT_CREATE");
            /*if (configSap == null)
            {
                directo = true;




                configSap = RfcDestinationManager.GetDestination("DDC");
                if (import.USER != "" && import.USER != null)
                {

                    RfcDestination destFinal = GET_DESTINO.pingWithSAPUserLogon(import.USER, import.PASS);

                    SapRfcRepository = destFinal.Repository;
                    rfcFunction = SapRfcRepository.CreateFunction("BAPI_GOODSMVT_CREATE");
                    configSap = destFinal;
                }
                else
                {
                    SapRfcRepository = configSap.Repository;
                }
                RfcSessionManager.BeginContext(configSap);

            }
            else
            {
                if (import.USER != "" && import.USER != null)
                {

                    RfcDestination destFinal = GET_DESTINO.pingWithSAPUserLogon(import.USER, import.PASS);

                    SapRfcRepository = destFinal.Repository;
                    rfcFunction = SapRfcRepository.CreateFunction("BAPI_GOODSMVT_CREATE");
                    configSap = destFinal;
                }
                else
                {
                    SapRfcRepository = configSap.Repository;
                }
            }*/





            rfcFunction = SapRfcRepository.CreateFunction("BAPI_GOODSMVT_CREATE");

            RfcStructureMetadata obj_BAPI2017_GM_CODE = SapRfcRepository.GetStructureMetadata("BAPI2017_GM_CODE");
            IRfcStructure datos_BAPI2017_GM_CODE = obj_BAPI2017_GM_CODE.CreateStructure();
            datos_BAPI2017_GM_CODE.SetValue("GM_CODE", import.GOODSMVT_CODE.GM_CODE);
            rfcFunction.SetValue("GOODSMVT_CODE", datos_BAPI2017_GM_CODE);
            RfcStructureMetadata obj_BAPI2017_GM_HEAD_01 = SapRfcRepository.GetStructureMetadata("BAPI2017_GM_HEAD_01");
            IRfcStructure datos_BAPI2017_GM_HEAD_01 = obj_BAPI2017_GM_HEAD_01.CreateStructure();
            datos_BAPI2017_GM_HEAD_01.SetValue("PSTNG_DATE", import.GOODSMVT_HEADER.PSTNG_DATE);
            datos_BAPI2017_GM_HEAD_01.SetValue("DOC_DATE", import.GOODSMVT_HEADER.DOC_DATE);
            datos_BAPI2017_GM_HEAD_01.SetValue("REF_DOC_NO", import.GOODSMVT_HEADER.REF_DOC_NO);
            datos_BAPI2017_GM_HEAD_01.SetValue("BILL_OF_LADING", import.GOODSMVT_HEADER.BILL_OF_LADING);
            datos_BAPI2017_GM_HEAD_01.SetValue("GR_GI_SLIP_NO", import.GOODSMVT_HEADER.GR_GI_SLIP_NO);
            datos_BAPI2017_GM_HEAD_01.SetValue("PR_UNAME", import.GOODSMVT_HEADER.PR_UNAME);
            datos_BAPI2017_GM_HEAD_01.SetValue("HEADER_TXT", import.GOODSMVT_HEADER.HEADER_TXT);
            datos_BAPI2017_GM_HEAD_01.SetValue("VER_GR_GI_SLIP", import.GOODSMVT_HEADER.VER_GR_GI_SLIP);
            datos_BAPI2017_GM_HEAD_01.SetValue("VER_GR_GI_SLIPX", import.GOODSMVT_HEADER.VER_GR_GI_SLIPX);
            datos_BAPI2017_GM_HEAD_01.SetValue("EXT_WMS", import.GOODSMVT_HEADER.EXT_WMS);
            datos_BAPI2017_GM_HEAD_01.SetValue("REF_DOC_NO_LONG", import.GOODSMVT_HEADER.REF_DOC_NO_LONG);
            datos_BAPI2017_GM_HEAD_01.SetValue("BILL_OF_LADING_LONG", import.GOODSMVT_HEADER.BILL_OF_LADING_LONG);
            datos_BAPI2017_GM_HEAD_01.SetValue("BAR_CODE", import.GOODSMVT_HEADER.BAR_CODE);
            rfcFunction.SetValue("GOODSMVT_HEADER", datos_BAPI2017_GM_HEAD_01);
            //RfcStructureMetadata obj_BAPI2017_GM_PRINT = SapRfcRepository.GetStructureMetadata("BAPI2017_GM_PRINT");
            //IRfcStructure datos_BAPI2017_GM_PRINT = obj_BAPI2017_GM_PRINT.CreateStructure();

            IRfcTable rfcTable_GOODSMVT_ITEM_I = rfcFunction.GetTable("GOODSMVT_ITEM");
            foreach (BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM row in import.GOODSMVT_ITEM)
            {
                rfcTable_GOODSMVT_ITEM_I.Append();
                BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM datoTabla = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();
                rfcTable_GOODSMVT_ITEM_I.SetValue("MATERIAL", row.MATERIAL);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PLANT", row.PLANT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STGE_LOC", row.STGE_LOC);
                rfcTable_GOODSMVT_ITEM_I.SetValue("BATCH", row.BATCH);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_TYPE", row.MOVE_TYPE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STCK_TYPE", row.STCK_TYPE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SPEC_STOCK", row.SPEC_STOCK);
                rfcTable_GOODSMVT_ITEM_I.SetValue("VENDOR", row.VENDOR);
                rfcTable_GOODSMVT_ITEM_I.SetValue("CUSTOMER", row.CUSTOMER);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SALES_ORD", row.SALES_ORD);
                rfcTable_GOODSMVT_ITEM_I.SetValue("S_ORD_ITEM", row.S_ORD_ITEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SCHED_LINE", row.SCHED_LINE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("VAL_TYPE", row.VAL_TYPE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ENTRY_QNT", row.ENTRY_QNT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ENTRY_UOM", row.ENTRY_UOM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ENTRY_UOM_ISO", row.ENTRY_UOM_ISO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PO_PR_QNT", row.PO_PR_QNT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ORDERPR_UN", row.ORDERPR_UN);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ORDERPR_UN_ISO", row.ORDERPR_UN_ISO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PO_NUMBER", row.PO_NUMBER);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PO_ITEM", row.PO_ITEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SHIPPING", row.SHIPPING);
                rfcTable_GOODSMVT_ITEM_I.SetValue("COMP_SHIP", row.COMP_SHIP);
                rfcTable_GOODSMVT_ITEM_I.SetValue("NO_MORE_GR", row.NO_MORE_GR);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ITEM_TEXT", row.ITEM_TEXT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("GR_RCPT", row.GR_RCPT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("UNLOAD_PT", row.UNLOAD_PT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("COSTCENTER", row.COSTCENTER);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ORDERID", row.ORDERID);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ORDER_ITNO", row.ORDER_ITNO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("CALC_MOTIVE", row.CALC_MOTIVE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ASSET_NO", row.ASSET_NO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SUB_NUMBER", row.SUB_NUMBER);
                rfcTable_GOODSMVT_ITEM_I.SetValue("RESERV_NO", row.RESERV_NO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("RES_ITEM", row.RES_ITEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("RES_TYPE", row.RES_TYPE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("WITHDRAWN", row.WITHDRAWN);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_MAT", row.MOVE_MAT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_PLANT", row.MOVE_PLANT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_STLOC", row.MOVE_STLOC);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_BATCH", row.MOVE_BATCH);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_VAL_TYPE", row.MOVE_VAL_TYPE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MVT_IND", row.MVT_IND);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_REAS", row.MOVE_REAS);
                rfcTable_GOODSMVT_ITEM_I.SetValue("RL_EST_KEY", row.RL_EST_KEY);
                rfcTable_GOODSMVT_ITEM_I.SetValue("REF_DATE", row.REF_DATE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("COST_OBJ", row.COST_OBJ);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PROFIT_SEGM_NO", row.PROFIT_SEGM_NO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PROFIT_CTR", row.PROFIT_CTR);
                rfcTable_GOODSMVT_ITEM_I.SetValue("WBS_ELEM", row.WBS_ELEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("NETWORK", row.NETWORK);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ACTIVITY", row.ACTIVITY);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PART_ACCT", row.PART_ACCT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("AMOUNT_LC", row.AMOUNT_LC);
                rfcTable_GOODSMVT_ITEM_I.SetValue("AMOUNT_SV", row.AMOUNT_SV);
                rfcTable_GOODSMVT_ITEM_I.SetValue("REF_DOC_YR", row.REF_DOC_YR);
                rfcTable_GOODSMVT_ITEM_I.SetValue("REF_DOC", row.REF_DOC);
                rfcTable_GOODSMVT_ITEM_I.SetValue("REF_DOC_IT", row.REF_DOC_IT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("EXPIRYDATE", row.EXPIRYDATE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PROD_DATE", row.PROD_DATE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("FUND", row.FUND);
                rfcTable_GOODSMVT_ITEM_I.SetValue("FUNDS_CTR", row.FUNDS_CTR);
                rfcTable_GOODSMVT_ITEM_I.SetValue("CMMT_ITEM", row.CMMT_ITEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("VAL_SALES_ORD", row.VAL_SALES_ORD);
                rfcTable_GOODSMVT_ITEM_I.SetValue("VAL_S_ORD_ITEM", row.VAL_S_ORD_ITEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("VAL_WBS_ELEM", row.VAL_WBS_ELEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("GL_ACCOUNT", row.GL_ACCOUNT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("IND_PROPOSE_QUANX", row.IND_PROPOSE_QUANX);
                rfcTable_GOODSMVT_ITEM_I.SetValue("XSTOB", row.XSTOB);
                rfcTable_GOODSMVT_ITEM_I.SetValue("EAN_UPC", row.EAN_UPC);
                rfcTable_GOODSMVT_ITEM_I.SetValue("DELIV_NUMB_TO_SEARCH", row.DELIV_NUMB_TO_SEARCH);
                rfcTable_GOODSMVT_ITEM_I.SetValue("DELIV_ITEM_TO_SEARCH", row.DELIV_ITEM_TO_SEARCH);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SERIALNO_AUTO_NUMBERASSIGNMENT", row.SERIALNO_AUTO_NUMBERASSIGNMENT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("VENDRBATCH", row.VENDRBATCH);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STGE_TYPE", row.STGE_TYPE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STGE_BIN", row.STGE_BIN);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SU_PL_STCK_1", row.SU_PL_STCK_1);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ST_UN_QTYY_1", row.ST_UN_QTYY_1);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ST_UN_QTYY_1_ISO", row.ST_UN_QTYY_1_ISO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("UNITTYPE_1", row.UNITTYPE_1);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SU_PL_STCK_2", row.SU_PL_STCK_2);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ST_UN_QTYY_2", row.ST_UN_QTYY_2);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ST_UN_QTYY_2_ISO", row.ST_UN_QTYY_2_ISO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("UNITTYPE_2", row.UNITTYPE_2);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STGE_TYPE_PC", row.STGE_TYPE_PC);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STGE_BIN_PC", row.STGE_BIN_PC);
                rfcTable_GOODSMVT_ITEM_I.SetValue("NO_PST_CHGNT", row.NO_PST_CHGNT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("GR_NUMBER", row.GR_NUMBER);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STGE_TYPE_ST", row.STGE_TYPE_ST);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STGE_BIN_ST", row.STGE_BIN_ST);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MATDOC_TR_CANCEL", row.MATDOC_TR_CANCEL);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MATITEM_TR_CANCEL", row.MATITEM_TR_CANCEL);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MATYEAR_TR_CANCEL", row.MATYEAR_TR_CANCEL);
                rfcTable_GOODSMVT_ITEM_I.SetValue("NO_TRANSFER_REQ", row.NO_TRANSFER_REQ);
                rfcTable_GOODSMVT_ITEM_I.SetValue("CO_BUSPROC", row.CO_BUSPROC);
                rfcTable_GOODSMVT_ITEM_I.SetValue("ACTTYPE", row.ACTTYPE);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SUPPL_VEND", row.SUPPL_VEND);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MATERIAL_EXTERNAL", row.MATERIAL_EXTERNAL);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MATERIAL_GUID", row.MATERIAL_GUID);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MATERIAL_VERSION", row.MATERIAL_VERSION);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_MAT_EXTERNAL", row.MOVE_MAT_EXTERNAL);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_MAT_GUID", row.MOVE_MAT_GUID);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_MAT_VERSION", row.MOVE_MAT_VERSION);
                rfcTable_GOODSMVT_ITEM_I.SetValue("FUNC_AREA", row.FUNC_AREA);
                rfcTable_GOODSMVT_ITEM_I.SetValue("TR_PART_BA", row.TR_PART_BA);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PAR_COMPCO", row.PAR_COMPCO);
                rfcTable_GOODSMVT_ITEM_I.SetValue("DELIV_NUMB", row.DELIV_NUMB);
                rfcTable_GOODSMVT_ITEM_I.SetValue("DELIV_ITEM", row.DELIV_ITEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("NB_SLIPS", row.NB_SLIPS);
                rfcTable_GOODSMVT_ITEM_I.SetValue("NB_SLIPSX", row.NB_SLIPSX);
                rfcTable_GOODSMVT_ITEM_I.SetValue("GR_RCPTX", row.GR_RCPTX);
                rfcTable_GOODSMVT_ITEM_I.SetValue("UNLOAD_PTX", row.UNLOAD_PTX);
                rfcTable_GOODSMVT_ITEM_I.SetValue("SPEC_MVMT", row.SPEC_MVMT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("GRANT_NBR", row.GRANT_NBR);
                rfcTable_GOODSMVT_ITEM_I.SetValue("CMMT_ITEM_LONG", row.CMMT_ITEM_LONG);
                rfcTable_GOODSMVT_ITEM_I.SetValue("FUNC_AREA_LONG", row.FUNC_AREA_LONG);
                rfcTable_GOODSMVT_ITEM_I.SetValue("LINE_ID", row.LINE_ID);
                rfcTable_GOODSMVT_ITEM_I.SetValue("PARENT_ID", row.PARENT_ID);
                rfcTable_GOODSMVT_ITEM_I.SetValue("LINE_DEPTH", row.LINE_DEPTH);
                rfcTable_GOODSMVT_ITEM_I.SetValue("QUANTITY", row.QUANTITY);
                rfcTable_GOODSMVT_ITEM_I.SetValue("BASE_UOM", row.BASE_UOM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("LONGNUM", row.LONGNUM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("BUDGET_PERIOD", row.BUDGET_PERIOD);
                rfcTable_GOODSMVT_ITEM_I.SetValue("EARMARKED_NUMBER", row.EARMARKED_NUMBER);
                rfcTable_GOODSMVT_ITEM_I.SetValue("EARMARKED_ITEM", row.EARMARKED_ITEM);
                rfcTable_GOODSMVT_ITEM_I.SetValue("STK_SEGMENT", row.STK_SEGMENT);
                rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_SEGMENT", row.MOVE_SEGMENT);
                //rfcTable_GOODSMVT_ITEM_I.SetValue("MATERIAL_LONG", row.MATERIAL_LONG);
                //rfcTable_GOODSMVT_ITEM_I.SetValue("MOVE_MAT_LONG", row.MOVE_MAT_LONG);
            }
            rfcFunction.SetValue("GOODSMVT_ITEM", rfcTable_GOODSMVT_ITEM_I);
            rfcFunction.SetValue("TESTRUN", import.TESTRUN);
            try
            {
                IRfcTable rfcTable_EXTENSIONIN_I = rfcFunction.GetTable("EXTENSIONIN");
                if (import.EXTENSIONIN != null)
                {
                    foreach (BAPI_GOODSMVT_CREATE_EXTENSIONIN row in import.EXTENSIONIN)
                    {
                        rfcTable_EXTENSIONIN_I.Append();
                        BAPI_GOODSMVT_CREATE_EXTENSIONIN datoTabla = new BAPI_GOODSMVT_CREATE_EXTENSIONIN();
                        rfcTable_EXTENSIONIN_I.SetValue("STRUCTURE", row.STRUCTURE);
                        rfcTable_EXTENSIONIN_I.SetValue("VALUEPART1", row.VALUEPART1);
                        rfcTable_EXTENSIONIN_I.SetValue("VALUEPART2", row.VALUEPART2);
                        rfcTable_EXTENSIONIN_I.SetValue("VALUEPART3", row.VALUEPART3);
                        rfcTable_EXTENSIONIN_I.SetValue("VALUEPART4", row.VALUEPART4);
                    }
                }
                rfcFunction.SetValue("EXTENSIONIN", rfcTable_EXTENSIONIN_I);
            }
            catch
            {

            }

            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_BAPI_GOODSMVT_CREATE res = new responce_BAPI_GOODSMVT_CREATE();
            res.MATDOCUMENTYEAR = rfcFunction.GetInt("MATDOCUMENTYEAR");
            res.MATERIALDOCUMENT = rfcFunction.GetString("MATERIALDOCUMENT");
            IRfcTable rfcTable_EXTENSIONIN = rfcFunction.GetTable("EXTENSIONIN");
            res.EXTENSIONIN = new BAPI_GOODSMVT_CREATE_EXTENSIONIN[rfcTable_EXTENSIONIN.RowCount];
            int i_EXTENSIONIN = 0;
            foreach (IRfcStructure row in rfcTable_EXTENSIONIN)
            {
                BAPI_GOODSMVT_CREATE_EXTENSIONIN datoTabla = new BAPI_GOODSMVT_CREATE_EXTENSIONIN();
                datoTabla.STRUCTURE = row.GetString("STRUCTURE");
                datoTabla.VALUEPART1 = row.GetString("VALUEPART1");
                datoTabla.VALUEPART2 = row.GetString("VALUEPART2");
                datoTabla.VALUEPART3 = row.GetString("VALUEPART3");
                datoTabla.VALUEPART4 = row.GetString("VALUEPART4");
                res.EXTENSIONIN[i_EXTENSIONIN] = datoTabla; ++i_EXTENSIONIN;
            }
            IRfcTable rfcTable_GOODSMVT_ITEM = rfcFunction.GetTable("GOODSMVT_ITEM");
            res.GOODSMVT_ITEM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[rfcTable_GOODSMVT_ITEM.RowCount];
            int i_GOODSMVT_ITEM = 0;
            foreach (IRfcStructure row in rfcTable_GOODSMVT_ITEM)
            {
                BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM datoTabla = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM();
                datoTabla.MATERIAL = row.GetString("MATERIAL");
                datoTabla.PLANT = row.GetString("PLANT");
                datoTabla.STGE_LOC = row.GetString("STGE_LOC");
                datoTabla.BATCH = row.GetString("BATCH");
                datoTabla.MOVE_TYPE = row.GetString("MOVE_TYPE");
                datoTabla.STCK_TYPE = row.GetString("STCK_TYPE");
                datoTabla.SPEC_STOCK = row.GetString("SPEC_STOCK");
                datoTabla.VENDOR = row.GetString("VENDOR");
                datoTabla.CUSTOMER = row.GetString("CUSTOMER");
                datoTabla.SALES_ORD = row.GetString("SALES_ORD");
                datoTabla.S_ORD_ITEM = row.GetInt("S_ORD_ITEM");
                datoTabla.SCHED_LINE = row.GetInt("SCHED_LINE");
                datoTabla.VAL_TYPE = row.GetString("VAL_TYPE");
                datoTabla.ENTRY_QNT = row.GetDecimal("ENTRY_QNT");
                datoTabla.ENTRY_UOM = row.GetString("ENTRY_UOM");
                datoTabla.ENTRY_UOM_ISO = row.GetString("ENTRY_UOM_ISO");
                datoTabla.PO_PR_QNT = row.GetDecimal("PO_PR_QNT");
                datoTabla.ORDERPR_UN = row.GetString("ORDERPR_UN");
                datoTabla.ORDERPR_UN_ISO = row.GetString("ORDERPR_UN_ISO");
                datoTabla.PO_NUMBER = row.GetString("PO_NUMBER");
                datoTabla.PO_ITEM = row.GetInt("PO_ITEM");
                datoTabla.SHIPPING = row.GetString("SHIPPING");
                datoTabla.COMP_SHIP = row.GetString("COMP_SHIP");
                datoTabla.NO_MORE_GR = row.GetString("NO_MORE_GR");
                datoTabla.ITEM_TEXT = row.GetString("ITEM_TEXT");
                datoTabla.GR_RCPT = row.GetString("GR_RCPT");
                datoTabla.UNLOAD_PT = row.GetString("UNLOAD_PT");
                datoTabla.COSTCENTER = row.GetString("COSTCENTER");
                datoTabla.ORDERID = row.GetString("ORDERID");
                datoTabla.ORDER_ITNO = row.GetInt("ORDER_ITNO");
                datoTabla.CALC_MOTIVE = row.GetString("CALC_MOTIVE");
                datoTabla.ASSET_NO = row.GetString("ASSET_NO");
                datoTabla.SUB_NUMBER = row.GetString("SUB_NUMBER");
                datoTabla.RESERV_NO = row.GetInt("RESERV_NO");
                datoTabla.RES_ITEM = row.GetInt("RES_ITEM");
                datoTabla.RES_TYPE = row.GetString("RES_TYPE");
                datoTabla.WITHDRAWN = row.GetString("WITHDRAWN");
                datoTabla.MOVE_MAT = row.GetString("MOVE_MAT");
                datoTabla.MOVE_PLANT = row.GetString("MOVE_PLANT");
                datoTabla.MOVE_STLOC = row.GetString("MOVE_STLOC");
                datoTabla.MOVE_BATCH = row.GetString("MOVE_BATCH");
                datoTabla.MOVE_VAL_TYPE = row.GetString("MOVE_VAL_TYPE");
                datoTabla.MVT_IND = row.GetString("MVT_IND");
                datoTabla.MOVE_REAS = row.GetInt("MOVE_REAS");
                datoTabla.RL_EST_KEY = row.GetString("RL_EST_KEY");
                datoTabla.REF_DATE = row.GetString("REF_DATE");
                datoTabla.COST_OBJ = row.GetString("COST_OBJ");
                datoTabla.PROFIT_SEGM_NO = row.GetInt("PROFIT_SEGM_NO");
                datoTabla.PROFIT_CTR = row.GetString("PROFIT_CTR");
                datoTabla.WBS_ELEM = row.GetString("WBS_ELEM");
                datoTabla.NETWORK = row.GetString("NETWORK");
                datoTabla.ACTIVITY = row.GetString("ACTIVITY");
                datoTabla.PART_ACCT = row.GetString("PART_ACCT");
                datoTabla.AMOUNT_LC = row.GetDecimal("AMOUNT_LC");
                datoTabla.AMOUNT_SV = row.GetDecimal("AMOUNT_SV");
                datoTabla.REF_DOC_YR = row.GetInt("REF_DOC_YR");
                datoTabla.REF_DOC = row.GetString("REF_DOC");
                datoTabla.REF_DOC_IT = row.GetInt("REF_DOC_IT");
                datoTabla.EXPIRYDATE = row.GetString("EXPIRYDATE");
                datoTabla.PROD_DATE = row.GetString("PROD_DATE");
                datoTabla.FUND = row.GetString("FUND");
                datoTabla.FUNDS_CTR = row.GetString("FUNDS_CTR");
                datoTabla.CMMT_ITEM = row.GetString("CMMT_ITEM");
                datoTabla.VAL_SALES_ORD = row.GetString("VAL_SALES_ORD");
                datoTabla.VAL_S_ORD_ITEM = row.GetInt("VAL_S_ORD_ITEM");
                datoTabla.VAL_WBS_ELEM = row.GetString("VAL_WBS_ELEM");
                datoTabla.GL_ACCOUNT = row.GetString("GL_ACCOUNT");
                datoTabla.IND_PROPOSE_QUANX = row.GetString("IND_PROPOSE_QUANX");
                datoTabla.XSTOB = row.GetString("XSTOB");
                datoTabla.EAN_UPC = row.GetString("EAN_UPC");
                datoTabla.DELIV_NUMB_TO_SEARCH = row.GetString("DELIV_NUMB_TO_SEARCH");
                datoTabla.DELIV_ITEM_TO_SEARCH = row.GetInt("DELIV_ITEM_TO_SEARCH");
                datoTabla.SERIALNO_AUTO_NUMBERASSIGNMENT = row.GetString("SERIALNO_AUTO_NUMBERASSIGNMENT");
                datoTabla.VENDRBATCH = row.GetString("VENDRBATCH");
                datoTabla.STGE_TYPE = row.GetString("STGE_TYPE");
                datoTabla.STGE_BIN = row.GetString("STGE_BIN");
                datoTabla.SU_PL_STCK_1 = row.GetDecimal("SU_PL_STCK_1");
                datoTabla.ST_UN_QTYY_1 = row.GetDecimal("ST_UN_QTYY_1");
                datoTabla.ST_UN_QTYY_1_ISO = row.GetString("ST_UN_QTYY_1_ISO");
                datoTabla.UNITTYPE_1 = row.GetString("UNITTYPE_1");
                datoTabla.SU_PL_STCK_2 = row.GetDecimal("SU_PL_STCK_2");
                datoTabla.ST_UN_QTYY_2 = row.GetDecimal("ST_UN_QTYY_2");
                datoTabla.ST_UN_QTYY_2_ISO = row.GetString("ST_UN_QTYY_2_ISO");
                datoTabla.UNITTYPE_2 = row.GetString("UNITTYPE_2");
                datoTabla.STGE_TYPE_PC = row.GetString("STGE_TYPE_PC");
                datoTabla.STGE_BIN_PC = row.GetString("STGE_BIN_PC");
                datoTabla.NO_PST_CHGNT = row.GetString("NO_PST_CHGNT");
                datoTabla.GR_NUMBER = row.GetString("GR_NUMBER");
                datoTabla.STGE_TYPE_ST = row.GetString("STGE_TYPE_ST");
                datoTabla.STGE_BIN_ST = row.GetString("STGE_BIN_ST");
                datoTabla.MATDOC_TR_CANCEL = row.GetString("MATDOC_TR_CANCEL");
                datoTabla.MATITEM_TR_CANCEL = row.GetInt("MATITEM_TR_CANCEL");
                datoTabla.MATYEAR_TR_CANCEL = row.GetInt("MATYEAR_TR_CANCEL");
                datoTabla.NO_TRANSFER_REQ = row.GetString("NO_TRANSFER_REQ");
                datoTabla.CO_BUSPROC = row.GetString("CO_BUSPROC");
                datoTabla.ACTTYPE = row.GetString("ACTTYPE");
                datoTabla.SUPPL_VEND = row.GetString("SUPPL_VEND");
                datoTabla.MATERIAL_EXTERNAL = row.GetString("MATERIAL_EXTERNAL");
                datoTabla.MATERIAL_GUID = row.GetString("MATERIAL_GUID");
                datoTabla.MATERIAL_VERSION = row.GetString("MATERIAL_VERSION");
                datoTabla.MOVE_MAT_EXTERNAL = row.GetString("MOVE_MAT_EXTERNAL");
                datoTabla.MOVE_MAT_GUID = row.GetString("MOVE_MAT_GUID");
                datoTabla.MOVE_MAT_VERSION = row.GetString("MOVE_MAT_VERSION");
                datoTabla.FUNC_AREA = row.GetString("FUNC_AREA");
                datoTabla.TR_PART_BA = row.GetString("TR_PART_BA");
                datoTabla.PAR_COMPCO = row.GetString("PAR_COMPCO");
                datoTabla.DELIV_NUMB = row.GetString("DELIV_NUMB");
                datoTabla.DELIV_ITEM = row.GetInt("DELIV_ITEM");
                datoTabla.NB_SLIPS = row.GetInt("NB_SLIPS");
                datoTabla.NB_SLIPSX = row.GetString("NB_SLIPSX");
                datoTabla.GR_RCPTX = row.GetString("GR_RCPTX");
                datoTabla.UNLOAD_PTX = row.GetString("UNLOAD_PTX");
                datoTabla.SPEC_MVMT = row.GetString("SPEC_MVMT");
                datoTabla.GRANT_NBR = row.GetString("GRANT_NBR");
                datoTabla.CMMT_ITEM_LONG = row.GetString("CMMT_ITEM_LONG");
                datoTabla.FUNC_AREA_LONG = row.GetString("FUNC_AREA_LONG");
                datoTabla.LINE_ID = row.GetInt("LINE_ID");
                datoTabla.PARENT_ID = row.GetInt("PARENT_ID");
                datoTabla.LINE_DEPTH = row.GetInt("LINE_DEPTH");
                datoTabla.QUANTITY = row.GetDecimal("QUANTITY");
                datoTabla.BASE_UOM = row.GetString("BASE_UOM");
                datoTabla.LONGNUM = row.GetString("LONGNUM");
                datoTabla.BUDGET_PERIOD = row.GetString("BUDGET_PERIOD");
                datoTabla.EARMARKED_NUMBER = row.GetString("EARMARKED_NUMBER");
                datoTabla.EARMARKED_ITEM = row.GetInt("EARMARKED_ITEM");
                datoTabla.STK_SEGMENT = row.GetString("STK_SEGMENT");
                datoTabla.MOVE_SEGMENT = row.GetString("MOVE_SEGMENT");
                //datoTabla.MATERIAL_LONG = row.GetString("MATERIAL_LONG");
                //datoTabla.MOVE_MAT_LONG = row.GetString("MOVE_MAT_LONG");
                res.GOODSMVT_ITEM[i_GOODSMVT_ITEM] = datoTabla; ++i_GOODSMVT_ITEM;
            }
            /*IRfcTable rfcTable_GOODSMVT_ITEM_CWM = rfcFunction.GetTable("GOODSMVT_ITEM_CWM");
            res.GOODSMVT_ITEM_CWM = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM_CWM[rfcTable_GOODSMVT_ITEM_CWM.RowCount];
            int i_GOODSMVT_ITEM_CWM = 0;
            foreach (IRfcStructure row in rfcTable_GOODSMVT_ITEM_CWM)
            {
                BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM_CWM datoTabla = new BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM_CWM();
                datoTabla.MATDOC_ITM = row.GetInt("MATDOC_ITM");
                datoTabla.QUANTITY_PME = row.GetDecimal("QUANTITY_PME");
                datoTabla.BASE_UOM_PME = row.GetString("BASE_UOM_PME");
                datoTabla.ENTRY_QNT_PME = row.GetDecimal("ENTRY_QNT_PME");
                datoTabla.ENTRY_UOM_PME = row.GetString("ENTRY_UOM_PME");
                res.GOODSMVT_ITEM_CWM[i_GOODSMVT_ITEM_CWM] = datoTabla; ++i_GOODSMVT_ITEM_CWM;
            }*/
            IRfcTable rfcTable_GOODSMVT_SERIALNUMBER = rfcFunction.GetTable("GOODSMVT_SERIALNUMBER");
            res.GOODSMVT_SERIALNUMBER = new BAPI_GOODSMVT_CREATE_GOODSMVT_SERIALNUMBER[rfcTable_GOODSMVT_SERIALNUMBER.RowCount];
            int i_GOODSMVT_SERIALNUMBER = 0;
            foreach (IRfcStructure row in rfcTable_GOODSMVT_SERIALNUMBER)
            {
                BAPI_GOODSMVT_CREATE_GOODSMVT_SERIALNUMBER datoTabla = new BAPI_GOODSMVT_CREATE_GOODSMVT_SERIALNUMBER();
                datoTabla.MATDOC_ITM = row.GetInt("MATDOC_ITM");
                datoTabla.SERIALNO = row.GetString("SERIALNO");
                datoTabla.UII = row.GetString("UII");
                res.GOODSMVT_SERIALNUMBER[i_GOODSMVT_SERIALNUMBER] = datoTabla; ++i_GOODSMVT_SERIALNUMBER;
            }
            IRfcTable rfcTable_GOODSMVT_SERV_PART_DATA = rfcFunction.GetTable("GOODSMVT_SERV_PART_DATA");
            res.GOODSMVT_SERV_PART_DATA = new BAPI_GOODSMVT_CREATE_GOODSMVT_SERV_PART_DATA[rfcTable_GOODSMVT_SERV_PART_DATA.RowCount];
            int i_GOODSMVT_SERV_PART_DATA = 0;
            foreach (IRfcStructure row in rfcTable_GOODSMVT_SERV_PART_DATA)
            {
                BAPI_GOODSMVT_CREATE_GOODSMVT_SERV_PART_DATA datoTabla = new BAPI_GOODSMVT_CREATE_GOODSMVT_SERV_PART_DATA();
                datoTabla.LINE_ID = row.GetInt("LINE_ID");
                datoTabla.RET_AUTH_NUMBER = row.GetString("RET_AUTH_NUMBER");
                datoTabla.DELIV_NUMBER = row.GetString("DELIV_NUMBER");
                datoTabla.DELIV_ITEM = row.GetInt("DELIV_ITEM");
                datoTabla.HU_NUMBER = row.GetString("HU_NUMBER");
                datoTabla.INSPOUT_GUID = row.GetString("INSPOUT_GUID");
                datoTabla.EVENT = row.GetString("EVENT");
                datoTabla.DATE = row.GetString("DATE");
                datoTabla.TIME = row.GetString("TIME");
                datoTabla.ZONLO = row.GetString("ZONLO");
                datoTabla.TIMESTAMP = row.GetDecimal("TIMESTAMP");
                datoTabla.SCRAP_INDICATOR = row.GetString("SCRAP_INDICATOR");
                datoTabla.KEEP_QUANTITY = row.GetDecimal("KEEP_QUANTITY");
                datoTabla.GTS_STOCK_TYPE = row.GetString("GTS_STOCK_TYPE");
                datoTabla.MOVE_GTS_STOCK_TYPE = row.GetString("MOVE_GTS_STOCK_TYPE");
                datoTabla.KEEP_QUANTITY_CONVERSION = row.GetString("KEEP_QUANTITY_CONVERSION");
                datoTabla.ZERO_QUANTITY = row.GetString("ZERO_QUANTITY");
                datoTabla.NUMERATOR = row.GetDecimal("NUMERATOR");
                datoTabla.DENOMINATR = row.GetDecimal("DENOMINATR");
                datoTabla.INSP_DOC_NUMB = row.GetString("INSP_DOC_NUMB");
                datoTabla.PCHG_TYPE = row.GetString("PCHG_TYPE");
                res.GOODSMVT_SERV_PART_DATA[i_GOODSMVT_SERV_PART_DATA] = datoTabla; ++i_GOODSMVT_SERV_PART_DATA;
            }
            IRfcTable rfcTable_RETURN = rfcFunction.GetTable("RETURN");
            res.RETURN = new BAPI_GOODSMVT_CREATE_RETURN[rfcTable_RETURN.RowCount];
            int i_RETURN = 0;
            foreach (IRfcStructure row in rfcTable_RETURN)
            {
                BAPI_GOODSMVT_CREATE_RETURN datoTabla = new BAPI_GOODSMVT_CREATE_RETURN();
                datoTabla.TYPE = row.GetString("TYPE");
                datoTabla.ID = row.GetString("ID");
                datoTabla.NUMBER = row.GetInt("NUMBER");
                datoTabla.MESSAGE = row.GetString("MESSAGE");
                datoTabla.LOG_NO = row.GetString("LOG_NO");
                datoTabla.LOG_MSG_NO = row.GetInt("LOG_MSG_NO");
                datoTabla.MESSAGE_V1 = row.GetString("MESSAGE_V1");
                datoTabla.MESSAGE_V2 = row.GetString("MESSAGE_V2");
                datoTabla.MESSAGE_V3 = row.GetString("MESSAGE_V3");
                datoTabla.MESSAGE_V4 = row.GetString("MESSAGE_V4");
                datoTabla.PARAMETER = row.GetString("PARAMETER");
                datoTabla.ROW = row.GetInt("ROW");
                datoTabla.FIELD = row.GetString("FIELD");
                datoTabla.SYSTEM = row.GetString("SYSTEM");
                res.RETURN[i_RETURN] = datoTabla; ++i_RETURN;
            }
           

            BAPI_TRANSACTION.Commit(configSap);
            RfcSessionManager.EndContext(configSap);

            return res;
        }
    }
    public class request_BAPI_GOODSMVT_CREATE
    {
        public BAPI_GOODSMVT_CREATE_GOODSMVT_CODE GOODSMVT_CODE;
        public BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER GOODSMVT_HEADER;
        public BAPI_GOODSMVT_CREATE_GOODSMVT_PRINT_CTRL GOODSMVT_PRINT_CTRL;
        public BAPI_GOODSMVT_CREATE_GOODSMVT_REF_EWM GOODSMVT_REF_EWM;
        public String TESTRUN;
        public BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[] GOODSMVT_ITEM;
        public BAPI_GOODSMVT_CREATE_EXTENSIONIN[] EXTENSIONIN;
        public String USER;
        public String PASS;
    }
    public class responce_BAPI_GOODSMVT_CREATE
    {
        public bool RESULTADO_BAPI = false;
        public responce_BAPI_GOODSMVT_GETDETAIL ITEMS_LOTE;
        public string DOCUMENTO;
        public Int32 MATDOCUMENTYEAR;
        public String MATERIALDOCUMENT;
        public BAPI_GOODSMVT_CREATE_EXTENSIONIN[] EXTENSIONIN;
        public BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM[] GOODSMVT_ITEM;
        public BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM_CWM[] GOODSMVT_ITEM_CWM;
        public BAPI_GOODSMVT_CREATE_GOODSMVT_SERIALNUMBER[] GOODSMVT_SERIALNUMBER;
        public BAPI_GOODSMVT_CREATE_GOODSMVT_SERV_PART_DATA[] GOODSMVT_SERV_PART_DATA;
        public BAPI_GOODSMVT_CREATE_RETURN[] RETURN;
    }
    public class BAPI_GOODSMVT_CREATE_GOODSMVT_CODE
    {
        public String GM_CODE;
    }
    public class BAPI_GOODSMVT_CREATE_GOODSMVT_HEADER
    {
        public String PSTNG_DATE;
        public String DOC_DATE;
        public String REF_DOC_NO;
        public String BILL_OF_LADING;
        public String GR_GI_SLIP_NO;
        public String PR_UNAME;
        public String HEADER_TXT;
        public String VER_GR_GI_SLIP;
        public String VER_GR_GI_SLIPX;
        public String EXT_WMS;
        public String REF_DOC_NO_LONG;
        public String BILL_OF_LADING_LONG;
        public String BAR_CODE;
    }
    public class BAPI_GOODSMVT_CREATE_GOODSMVT_PRINT_CTRL
    {
        public Int32 PR_PRINT;
    }
    public class BAPI_GOODSMVT_CREATE_GOODSMVT_REF_EWM
    {
        public String REF_DOC_EWM;
        public String LOGSYS;
        public String GTS_SCRAP_NO;
    }
    public class BAPI_GOODSMVT_CREATE_EXTENSIONIN
    {
        public String STRUCTURE;
        public String VALUEPART1;
        public String VALUEPART2;
        public String VALUEPART3;
        public String VALUEPART4;
    }
    public class BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM
    {
        public String MATERIAL;
        public String PLANT;
        public String STGE_LOC;
        public String BATCH;
        public String MOVE_TYPE;
        public String STCK_TYPE;
        public String SPEC_STOCK;
        public String VENDOR;
        public String CUSTOMER;
        public String SALES_ORD;
        public Int32 S_ORD_ITEM;
        public Int32 SCHED_LINE;
        public String VAL_TYPE;
        public Decimal ENTRY_QNT;
        public String ENTRY_UOM;
        public String ENTRY_UOM_ISO;
        public Decimal PO_PR_QNT;
        public String ORDERPR_UN;
        public String ORDERPR_UN_ISO;
        public String PO_NUMBER;
        public Int32 PO_ITEM;
        public String SHIPPING;
        public String COMP_SHIP;
        public String NO_MORE_GR;
        public String ITEM_TEXT;
        public String GR_RCPT;
        public String UNLOAD_PT;
        public String COSTCENTER;
        public String ORDERID;
        public Int32 ORDER_ITNO;
        public String CALC_MOTIVE;
        public String ASSET_NO;
        public String SUB_NUMBER;
        public Int32 RESERV_NO;
        public Int32 RES_ITEM;
        public String RES_TYPE;
        public String WITHDRAWN;
        public String MOVE_MAT;
        public String MOVE_PLANT;
        public String MOVE_STLOC;
        public String MOVE_BATCH;
        public String MOVE_VAL_TYPE;
        public String MVT_IND;
        public Int32 MOVE_REAS;
        public String RL_EST_KEY;
        public String REF_DATE;
        public String COST_OBJ;
        public Int32 PROFIT_SEGM_NO;
        public String PROFIT_CTR;
        public String WBS_ELEM;
        public String NETWORK;
        public String ACTIVITY;
        public String PART_ACCT;
        public Decimal AMOUNT_LC;
        public Decimal AMOUNT_SV;
        public Int32 REF_DOC_YR;
        public String REF_DOC;
        public Int32 REF_DOC_IT;
        public String EXPIRYDATE;
        public String PROD_DATE;
        public String FUND;
        public String FUNDS_CTR;
        public String CMMT_ITEM;
        public String VAL_SALES_ORD;
        public Int32 VAL_S_ORD_ITEM;
        public String VAL_WBS_ELEM;
        public String GL_ACCOUNT;
        public String IND_PROPOSE_QUANX;
        public String XSTOB;
        public String EAN_UPC;
        public String DELIV_NUMB_TO_SEARCH;
        public Int32 DELIV_ITEM_TO_SEARCH;
        public String SERIALNO_AUTO_NUMBERASSIGNMENT;
        public String VENDRBATCH;
        public String STGE_TYPE;
        public String STGE_BIN;
        public Decimal SU_PL_STCK_1;
        public Decimal ST_UN_QTYY_1;
        public String ST_UN_QTYY_1_ISO;
        public String UNITTYPE_1;
        public Decimal SU_PL_STCK_2;
        public Decimal ST_UN_QTYY_2;
        public String ST_UN_QTYY_2_ISO;
        public String UNITTYPE_2;
        public String STGE_TYPE_PC;
        public String STGE_BIN_PC;
        public String NO_PST_CHGNT;
        public String GR_NUMBER;
        public String STGE_TYPE_ST;
        public String STGE_BIN_ST;
        public String MATDOC_TR_CANCEL;
        public Int32 MATITEM_TR_CANCEL;
        public Int32 MATYEAR_TR_CANCEL;
        public String NO_TRANSFER_REQ;
        public String CO_BUSPROC;
        public String ACTTYPE;
        public String SUPPL_VEND;
        public String MATERIAL_EXTERNAL;
        public String MATERIAL_GUID;
        public String MATERIAL_VERSION;
        public String MOVE_MAT_EXTERNAL;
        public String MOVE_MAT_GUID;
        public String MOVE_MAT_VERSION;
        public String FUNC_AREA;
        public String TR_PART_BA;
        public String PAR_COMPCO;
        public String DELIV_NUMB;
        public Int32 DELIV_ITEM;
        public Int32 NB_SLIPS;
        public String NB_SLIPSX;
        public String GR_RCPTX;
        public String UNLOAD_PTX;
        public String SPEC_MVMT;
        public String GRANT_NBR;
        public String CMMT_ITEM_LONG;
        public String FUNC_AREA_LONG;
        public Int32 LINE_ID;
        public Int32 PARENT_ID;
        public Int32 LINE_DEPTH;
        public Decimal QUANTITY;
        public String BASE_UOM;
        public String LONGNUM;
        public String BUDGET_PERIOD;
        public String EARMARKED_NUMBER;
        public Int32 EARMARKED_ITEM;
        public String STK_SEGMENT;
        public String MOVE_SEGMENT;
        public String MATERIAL_LONG;
        public String MOVE_MAT_LONG;
    }
    public class BAPI_GOODSMVT_CREATE_GOODSMVT_ITEM_CWM
    {
        public Int32 MATDOC_ITM;
        public Decimal QUANTITY_PME;
        public String BASE_UOM_PME;
        public Decimal ENTRY_QNT_PME;
        public String ENTRY_UOM_PME;
    }
    public class BAPI_GOODSMVT_CREATE_GOODSMVT_SERIALNUMBER
    {
        public Int32 MATDOC_ITM;
        public String SERIALNO;
        public String UII;
    }
    public class BAPI_GOODSMVT_CREATE_GOODSMVT_SERV_PART_DATA
    {
        public Int32 LINE_ID;
        public String RET_AUTH_NUMBER;
        public String DELIV_NUMBER;
        public Int32 DELIV_ITEM;
        public String HU_NUMBER;
        public String INSPOUT_GUID;
        public String EVENT;
        public String DATE;
        public String TIME;
        public String ZONLO;
        public Decimal TIMESTAMP;
        public String SCRAP_INDICATOR;
        public Decimal KEEP_QUANTITY;
        public String GTS_STOCK_TYPE;
        public String MOVE_GTS_STOCK_TYPE;
        public String KEEP_QUANTITY_CONVERSION;
        public String ZERO_QUANTITY;
        public Decimal NUMERATOR;
        public Decimal DENOMINATR;
        public String INSP_DOC_NUMB;
        public String PCHG_TYPE;
    }
    public class BAPI_GOODSMVT_CREATE_RETURN
    {
        public String TYPE;
        public String ID;
        public Int32 NUMBER;
        public String MESSAGE;
        public String LOG_NO;
        public Int32 LOG_MSG_NO;
        public String MESSAGE_V1;
        public String MESSAGE_V2;
        public String MESSAGE_V3;
        public String MESSAGE_V4;
        public String PARAMETER;
        public Int32 ROW;
        public String FIELD;
        public String SYSTEM;
    }

}