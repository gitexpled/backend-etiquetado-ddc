using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_UPDATE_HU_ZFIELDS
    {
        public responce_ZMOV_UPDATE_HU_ZFIELDS sapRun(request_ZMOV_UPDATE_HU_ZFIELDS import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_UPDATE_HU_ZFIELDS");

            RfcStructureMetadata obj_ZSTR_SD_HU_FIELDS = SapRfcRepository.GetStructureMetadata("ZSTR_SD_HU_FIELDS");
            IRfcStructure datos_ZSTR_SD_HU_FIELDS = obj_ZSTR_SD_HU_FIELDS.CreateStructure();
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZTERM", import.IS_FIELDS.ZZTERM);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZTEMP", import.IS_FIELDS.ZZTEMP);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPOVEN", import.IS_FIELDS.ZZPOVEN);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_NO_SOL_SENASA", import.IS_FIELDS.ZZ_NO_SOL_SENASA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_NO_EXP_SENASA", import.IS_FIELDS.ZZ_NO_EXP_SENASA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_TECNOLOG", import.IS_FIELDS.ZZ_TECNOLOG);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_TERMOGRAFO", import.IS_FIELDS.ZZ_TERMOGRAFO);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_TRATAM", import.IS_FIELDS.ZZ_TRATAM);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_NUMTRA", import.IS_FIELDS.ZZ_NUMTRA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_FECTRA", import.IS_FIELDS.ZZ_FECTRA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_MOTTRA", import.IS_FIELDS.ZZ_MOTTRA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_PROD", import.IS_FIELDS.ZZ_PROD);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZLDDAT", import.IS_FIELDS.ZZLDDAT);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPPLAN", import.IS_FIELDS.ZZPPLAN);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZHRESULT", import.IS_FIELDS.ZZHRESULT);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZCLICONT", import.IS_FIELDS.ZZCLICONT);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZDEFCALIDAD", import.IS_FIELDS.ZZDEFCALIDAD);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZFOLIOCJ", import.IS_FIELDS.ZZFOLIOCJ);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZFOLIORIGENREP", import.IS_FIELDS.ZZFOLIORIGENREP);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZHORAFECHAREP", import.IS_FIELDS.ZZHORAFECHAREP);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZGUIATRASLADOMP", import.IS_FIELDS.ZZGUIATRASLADOMP);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPATENTE", import.IS_FIELDS.ZZPATENTE);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZORDDESCPALLET", import.IS_FIELDS.ZZORDDESCPALLET);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZCONS_PALLET", import.IS_FIELDS.ZCONS_PALLET);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZOBS", import.IS_FIELDS.ZZOBS);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_ORD_EMBARQ", import.IS_FIELDS.ZZ_HU_ORD_EMBARQ);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_CONTENEDOR", import.IS_FIELDS.ZZ_HU_CONTENEDOR);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_VERIFICADOR", import.IS_FIELDS.ZZ_HU_VERIFICADOR);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_FECHA_HOY", import.IS_FIELDS.ZZ_HU_FECHA_HOY);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TIPO_CARGA", import.IS_FIELDS.ZZ_HU_TIPO_CARGA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_SET_CONT", import.IS_FIELDS.ZZ_HU_SET_CONT);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_APERT_LAMPA", import.IS_FIELDS.ZZ_HU_APERT_LAMPA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_DESINFEC", import.IS_FIELDS.ZZ_HU_DESINFEC);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_BUFANDA", import.IS_FIELDS.ZZ_HU_BUFANDA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_ALFOMB", import.IS_FIELDS.ZZ_HU_ALFOMB);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_BOLSA", import.IS_FIELDS.ZZ_HU_BOLSA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_CONT_PRE_ENF", import.IS_FIELDS.ZZ_HU_CONT_PRE_ENF);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_CONT_B_EST", import.IS_FIELDS.ZZ_HU_CONT_B_EST);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_HR_INI_CARGA", import.IS_FIELDS.ZZ_HU_HR_INI_CARGA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_HR_TER_CARGA", import.IS_FIELDS.ZZ_HU_HR_TER_CARGA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_1", import.IS_FIELDS.ZZ_HU_TEMP_1);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_2", import.IS_FIELDS.ZZ_HU_TEMP_2);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TERMOGRAFO", import.IS_FIELDS.ZZ_HU_TERMOGRAFO);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TIPO_ENVIO", import.IS_FIELDS.ZZ_HU_TIPO_ENVIO);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_BASTIDOR", import.IS_FIELDS.ZZ_HU_BASTIDOR);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEC_CUB", import.IS_FIELDS.ZZ_HU_TEC_CUB);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_LADOS", import.IS_FIELDS.ZZ_HU_LADOS);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_LIM_OLOR", import.IS_FIELDS.ZZ_HU_LIM_OLOR);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_PUERTAS_INT", import.IS_FIELDS.ZZ_HU_PUERTAS_INT);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_PISO_INT", import.IS_FIELDS.ZZ_HU_PISO_INT);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_PARED_FRONT", import.IS_FIELDS.ZZ_HU_PARED_FRONT);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP11", import.IS_FIELDS.ZZPAIS_INSP11);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP12", import.IS_FIELDS.ZZPAIS_INSP12);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP13", import.IS_FIELDS.ZZPAIS_INSP13);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP14", import.IS_FIELDS.ZZPAIS_INSP14);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP15", import.IS_FIELDS.ZZPAIS_INSP15);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_PE_FECHA", import.IS_FIELDS.ZZ_HU_PE_FECHA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_PE_OBSER", import.IS_FIELDS.ZZ_HU_PE_OBSER);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP1", import.IS_FIELDS.ZZPAIS_INSP1);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP2", import.IS_FIELDS.ZZPAIS_INSP2);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP3", import.IS_FIELDS.ZZPAIS_INSP3);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP4", import.IS_FIELDS.ZZPAIS_INSP4);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP5", import.IS_FIELDS.ZZPAIS_INSP5);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP6", import.IS_FIELDS.ZZPAIS_INSP6);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP7", import.IS_FIELDS.ZZPAIS_INSP7);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP8", import.IS_FIELDS.ZZPAIS_INSP8);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP9", import.IS_FIELDS.ZZPAIS_INSP9);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZPAIS_INSP10", import.IS_FIELDS.ZZPAIS_INSP10);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZFEC_INSP", import.IS_FIELDS.ZZFEC_INSP);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZEST_INSP", import.IS_FIELDS.ZZEST_INSP);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZTIPO_RECHAZO", import.IS_FIELDS.ZZTIPO_RECHAZO);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZCLIENTE_DESTINO", import.IS_FIELDS.ZZCLIENTE_DESTINO);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZTEMP", import.IS_FIELDS.ZTEMP);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_GUIA", import.IS_FIELDS.ZZ_HU_GUIA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_A_PACK", import.IS_FIELDS.ZZ_HU_TEMP_A_PACK);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_PULP_PACK", import.IS_FIELDS.ZZ_HU_TEMP_PULP_PACK);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TIEMP_TRASL", import.IS_FIELDS.ZZ_HU_TIEMP_TRASL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_RECEP", import.IS_FIELDS.ZZ_HU_TEMP_RECEP);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_FECH_ING_TUNEL", import.IS_FIELDS.ZZ_HU_FECH_ING_TUNEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_HR_ING_TUNEL", import.IS_FIELDS.ZZ_HU_HR_ING_TUNEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_NRO_TUNEL", import.IS_FIELDS.ZZ_HU_NRO_TUNEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_ENT_TUNEL", import.IS_FIELDS.ZZ_HU_TEMP_ENT_TUNEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_SAL_TUNEL", import.IS_FIELDS.ZZ_HU_TEMP_SAL_TUNEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_FECH_SAL_TUNEL", import.IS_FIELDS.ZZ_HU_FECH_SAL_TUNEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_HR_SAL_TUNEL", import.IS_FIELDS.ZZ_HU_HR_SAL_TUNEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_NRO_CAMARA", import.IS_FIELDS.ZZ_HU_NRO_CAMARA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_AMB1", import.IS_FIELDS.ZZ_HU_TEMP_AMB1);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_AMB2", import.IS_FIELDS.ZZ_HU_TEMP_AMB2);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_AMB3", import.IS_FIELDS.ZZ_HU_TEMP_AMB3);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_PULP1", import.IS_FIELDS.ZZ_HU_TEMP_PULP1);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_PULP2", import.IS_FIELDS.ZZ_HU_TEMP_PULP2);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_PULP3", import.IS_FIELDS.ZZ_HU_TEMP_PULP3);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TIPO_CAMION", import.IS_FIELDS.ZZ_HU_TIPO_CAMION);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_FECH_LLEG_CAM", import.IS_FIELDS.ZZ_HU_FECH_LLEG_CAM);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_HR_LLEG_CAM", import.IS_FIELDS.ZZ_HU_HR_LLEG_CAM);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_FECH_S_CAM", import.IS_FIELDS.ZZ_HU_FECH_S_CAM);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_HR_S_CAM", import.IS_FIELDS.ZZ_HU_HR_S_CAM);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_OBSERVACION", import.IS_FIELDS.ZZ_HU_OBSERVACION);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_HR_INGR_PLANTA", import.IS_FIELDS.ZZ_HU_HR_INGR_PLANTA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_3HR_TUNEL", import.IS_FIELDS.ZZ_HU_TEMP_3HR_TUNEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_DESP_INV", import.IS_FIELDS.ZZ_HU_TEMP_DESP_INV);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_HR_COSECHA", import.IS_FIELDS.ZZ_HU_HR_COSECHA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_TEMP_COSECHA", import.IS_FIELDS.ZZ_HU_TEMP_COSECHA);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HU_LOT_PACK", import.IS_FIELDS.ZZ_HU_LOT_PACK);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_FINGFRI", import.IS_FIELDS.ZZ_FINGFRI);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HINGFRI", import.IS_FIELDS.ZZ_HINGFRI);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_FSALFRI", import.IS_FIELDS.ZZ_FSALFRI);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_HSALFRI", import.IS_FIELDS.ZZ_HSALFRI);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_DURPRE", import.IS_FIELDS.ZZ_DURPRE);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZZ_PREFRIO", import.IS_FIELDS.ZZ_PREFRIO);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZMM_HU_V_CUARTEL", import.IS_FIELDS.ZMM_HU_V_CUARTEL);
            datos_ZSTR_SD_HU_FIELDS.SetValue("ZMM_HU_V_HILERA", import.IS_FIELDS.ZMM_HU_V_HILERA);
            rfcFunction.SetValue("IS_FIELDS", datos_ZSTR_SD_HU_FIELDS);
            
            IRfcTable rfcTable_IT_HU_I = rfcFunction.GetTable("IT_HU");
            foreach (ZMOV_UPDATE_HU_ZFIELDS_IT_HU row in import.IT_HU)
            {
                rfcTable_IT_HU_I.Append();
                ZMOV_UPDATE_HU_ZFIELDS_IT_HU datoTabla = new ZMOV_UPDATE_HU_ZFIELDS_IT_HU();
                rfcTable_IT_HU_I.SetValue("EXIDV", row.EXIDV);
            }
            rfcFunction.SetValue("IT_HU", rfcTable_IT_HU_I);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_UPDATE_HU_ZFIELDS res = new responce_ZMOV_UPDATE_HU_ZFIELDS();
            res.E_ERROR = rfcFunction.GetString("E_ERROR");
            res.E_MSG = rfcFunction.GetString("E_MSG");
            IRfcTable rfcTable_IT_HU = rfcFunction.GetTable("IT_HU");
            res.IT_HU = new ZMOV_UPDATE_HU_ZFIELDS_IT_HU[rfcTable_IT_HU.RowCount];
            int i_IT_HU = 0;
            foreach (IRfcStructure row in rfcTable_IT_HU)
            {
                ZMOV_UPDATE_HU_ZFIELDS_IT_HU datoTabla = new ZMOV_UPDATE_HU_ZFIELDS_IT_HU();
                datoTabla.EXIDV = row.GetString("EXIDV");
                res.IT_HU[i_IT_HU] = datoTabla; ++i_IT_HU;
            }

            return res;
        }
    }
    public class request_ZMOV_UPDATE_HU_ZFIELDS
    {
        public ZMOV_UPDATE_HU_ZFIELDS_IS_FIELDS IS_FIELDS;
        public ZMOV_UPDATE_HU_ZFIELDS_IT_HU[] IT_HU;
    }
    public class responce_ZMOV_UPDATE_HU_ZFIELDS
    {
        public String E_ERROR;
        public String E_MSG;
        public ZMOV_UPDATE_HU_ZFIELDS_IT_HU[] IT_HU;
    }
    public class ZMOV_UPDATE_HU_ZFIELDS_IS_FIELDS
    {
        public String ZZTERM;
        public String ZZTEMP;
        public String ZZPOVEN;
        public String ZZ_NO_SOL_SENASA;
        public String ZZ_NO_EXP_SENASA;
        public String ZZ_TECNOLOG;
        public String ZZ_TERMOGRAFO;
        public String ZZ_TRATAM;
        public String ZZ_NUMTRA;
        public String ZZ_FECTRA;
        public String ZZ_MOTTRA;
        public String ZZ_PROD;
        public String ZZLDDAT;
        public String ZZPPLAN;
        public String ZZHRESULT;
        public String ZZCLICONT;
        public String ZZDEFCALIDAD;
        public String ZZFOLIOCJ;
        public String ZZFOLIORIGENREP;
        public String ZZHORAFECHAREP;
        public String ZZGUIATRASLADOMP;
        public String ZZPATENTE;
        public String ZZORDDESCPALLET;
        public String ZCONS_PALLET;
        public String ZZOBS;
        public String ZZ_HU_ORD_EMBARQ;
        public String ZZ_HU_CONTENEDOR;
        public String ZZ_HU_VERIFICADOR;
        public String ZZ_HU_FECHA_HOY;
        public String ZZ_HU_TIPO_CARGA;
        public String ZZ_HU_SET_CONT;
        public String ZZ_HU_APERT_LAMPA;
        public String ZZ_HU_DESINFEC;
        public String ZZ_HU_BUFANDA;
        public String ZZ_HU_ALFOMB;
        public String ZZ_HU_BOLSA;
        public String ZZ_HU_CONT_PRE_ENF;
        public String ZZ_HU_CONT_B_EST;
        public String ZZ_HU_HR_INI_CARGA;
        public String ZZ_HU_HR_TER_CARGA;
        public String ZZ_HU_TEMP_1;
        public String ZZ_HU_TEMP_2;
        public String ZZ_HU_TERMOGRAFO;
        public String ZZ_HU_TIPO_ENVIO;
        public String ZZ_HU_BASTIDOR;
        public String ZZ_HU_TEC_CUB;
        public String ZZ_HU_LADOS;
        public String ZZ_HU_LIM_OLOR;
        public String ZZ_HU_PUERTAS_INT;
        public String ZZ_HU_PISO_INT;
        public String ZZ_HU_PARED_FRONT;
        public String ZZPAIS_INSP11;
        public String ZZPAIS_INSP12;
        public String ZZPAIS_INSP13;
        public String ZZPAIS_INSP14;
        public String ZZPAIS_INSP15;
        public String ZZ_HU_PE_FECHA;
        public String ZZ_HU_PE_OBSER;
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
        public String ZZFEC_INSP;
        public String ZZEST_INSP;
        public String ZZTIPO_RECHAZO;
        public String ZZCLIENTE_DESTINO;
        public String ZTEMP;
        public String ZZ_HU_GUIA;
        public String ZZ_HU_TEMP_A_PACK;
        public String ZZ_HU_TEMP_PULP_PACK;
        public String ZZ_HU_TIEMP_TRASL;
        public String ZZ_HU_TEMP_RECEP;
        public String ZZ_HU_FECH_ING_TUNEL;
        public String ZZ_HU_HR_ING_TUNEL;
        public String ZZ_HU_NRO_TUNEL;
        public String ZZ_HU_TEMP_ENT_TUNEL;
        public String ZZ_HU_TEMP_SAL_TUNEL;
        public String ZZ_HU_FECH_SAL_TUNEL;
        public String ZZ_HU_HR_SAL_TUNEL;
        public String ZZ_HU_NRO_CAMARA;
        public String ZZ_HU_TEMP_AMB1;
        public String ZZ_HU_TEMP_AMB2;
        public String ZZ_HU_TEMP_AMB3;
        public String ZZ_HU_TEMP_PULP1;
        public String ZZ_HU_TEMP_PULP2;
        public String ZZ_HU_TEMP_PULP3;
        public String ZZ_HU_TIPO_CAMION;
        public String ZZ_HU_FECH_LLEG_CAM;
        public String ZZ_HU_HR_LLEG_CAM;
        public String ZZ_HU_FECH_S_CAM;
        public String ZZ_HU_HR_S_CAM;
        public String ZZ_HU_OBSERVACION;
        public String ZZ_HU_HR_INGR_PLANTA;
        public String ZZ_HU_TEMP_3HR_TUNEL;
        public String ZZ_HU_TEMP_DESP_INV;
        public String ZZ_HU_HR_COSECHA;
        public String ZZ_HU_TEMP_COSECHA;
        public String ZZ_HU_LOT_PACK;
        public String ZZ_FINGFRI;
        public String ZZ_HINGFRI;
        public String ZZ_FSALFRI;
        public String ZZ_HSALFRI;
        public String ZZ_DURPRE;
        public String ZZ_PREFRIO;
        public String ZMM_HU_V_CUARTEL;
        public String ZMM_HU_V_HILERA;
    }
    public class ZMOV_UPDATE_HU_ZFIELDS_IT_HU
    {
        public String EXIDV;
    }

}