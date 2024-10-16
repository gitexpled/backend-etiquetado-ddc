using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;

namespace rfcBaika
{
    public class ZMOV_QUERY_PRODUCTOR
    {
        public responce_ZMOV_QUERY_PRODUCTOR sapRun(request_ZMOV_QUERY_PRODUCTOR import)
        {
            RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
            RfcRepository SapRfcRepository = configSap.Repository;
            IRfcFunction rfcFunction = SapRfcRepository.CreateFunction("ZMOV_QUERY_PRODUCTOR");

            rfcFunction.SetValue("I_BUKRS", import.I_BUKRS);
            rfcFunction.SetValue("I_COUNTRY", import.I_COUNTRY);
            rfcFunction.SetValue("I_ESPECIE", import.I_ESPECIE);
            rfcFunction.SetValue("I_KTOKK", import.I_KTOKK);
            rfcFunction.SetValue("I_LIFNR", import.I_LIFNR);
            rfcFunction.SetValue("I_PROVIG", import.I_PROVIG);
            rfcFunction.Invoke(configSap);
            string aa = rfcFunction.ToString();
            responce_ZMOV_QUERY_PRODUCTOR res = new responce_ZMOV_QUERY_PRODUCTOR();
            IRfcTable rfcTable_PRODUCTORES = rfcFunction.GetTable("PRODUCTORES");
            res.PRODUCTORES = new ZMOV_QUERY_PRODUCTOR_PRODUCTORES[rfcTable_PRODUCTORES.RowCount];
            int i_PRODUCTORES = 0;
            foreach (IRfcStructure row in rfcTable_PRODUCTORES)
            {
                ZMOV_QUERY_PRODUCTOR_PRODUCTORES datoTabla = new ZMOV_QUERY_PRODUCTOR_PRODUCTORES();
                datoTabla.LIFNR = row.GetString("LIFNR");
                datoTabla.COUNTRY = row.GetString("COUNTRY");
                datoTabla.REGION = row.GetString("REGION");
                datoTabla.NAME1 = row.GetString("NAME1");
                datoTabla.NAME2 = row.GetString("NAME2");
                datoTabla.NAME3 = row.GetString("NAME3");
                datoTabla.NAME4 = row.GetString("NAME4");
                datoTabla.CITY1 = row.GetString("CITY1");
                datoTabla.CITY2 = row.GetString("CITY2");
                datoTabla.HOME_CITY = row.GetString("HOME_CITY");
                datoTabla.PFACH = row.GetString("PFACH");
                datoTabla.PSTL2 = row.GetString("PSTL2");
                datoTabla.SORT1 = row.GetString("SORT1");
                datoTabla.SORT2 = row.GetString("SORT2");
                datoTabla.STREET = row.GetString("STREET");
                datoTabla.HOUSE_NUM1 = row.GetString("HOUSE_NUM1");
                datoTabla.STCD1 = row.GetString("STCD1");
                datoTabla.STCD2 = row.GetString("STCD2");
                datoTabla.ZPRD_EXPORTADORA = row.GetString("ZPRD_EXPORTADORA");
                datoTabla.ZPRD_TIPO = row.GetString("ZPRD_TIPO");
                datoTabla.ZPRD_VIGENTE = row.GetString("ZPRD_VIGENTE");
                datoTabla.ZPRD_SDP = row.GetString("ZPRD_SDP");
                datoTabla.ZPRD_CSP = row.GetString("ZPRD_CSP");
                datoTabla.ZPRD_CSG = row.GetString("ZPRD_CSG");
                datoTabla.ZPRD_GGN = row.GetString("ZPRD_GGN");
                datoTabla.ZPRD_ESPECIE = row.GetString("ZPRD_ESPECIE");
                datoTabla.ZPRD_VARIEDAD = row.GetString("ZPRD_VARIEDAD");
                datoTabla.REMARK = row.GetString("REMARK");
                res.PRODUCTORES[i_PRODUCTORES] = datoTabla; ++i_PRODUCTORES;
            }

            return res;
        }
    }
    public class request_ZMOV_QUERY_PRODUCTOR
    {
        public String I_BUKRS;
        public String I_COUNTRY;
        public String I_ESPECIE;
        public String I_KTOKK;
        public String I_LIFNR;
        public String I_PROVIG;
    }
    public class responce_ZMOV_QUERY_PRODUCTOR
    {
        public ZMOV_QUERY_PRODUCTOR_PRODUCTORES[] PRODUCTORES;
    }
    public class ZMOV_QUERY_PRODUCTOR_PRODUCTORES
    {
        public String LIFNR;
        public String COUNTRY;
        public String REGION;
        public String NAME1;
        public String NAME2;
        public String NAME3;
        public String NAME4;
        public String CITY1;
        public String CITY2;
        public String HOME_CITY;
        public String PFACH;
        public String PSTL2;
        public String SORT1;
        public String SORT2;
        public String STREET;
        public String HOUSE_NUM1;
        public String STCD1;
        public String STCD2;
        public String ZPRD_EXPORTADORA;
        public String ZPRD_TIPO;
        public String ZPRD_VIGENTE;
        public String ZPRD_SDP;
        public String ZPRD_CSP;
        public String ZPRD_CSG;
        public String ZPRD_GGN;
        public String ZPRD_ESPECIE;
        public String ZPRD_VARIEDAD;
        public String REMARK;
    }

}