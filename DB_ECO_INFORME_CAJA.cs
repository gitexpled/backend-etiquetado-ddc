using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_INFORME_CAJA
    {
        public Array run(request_ECO_INFORME_CAJA datos)
        {
            List<responce_ECO_INFORME_CAJA> List = new List<responce_ECO_INFORME_CAJA>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "";

            int sm1 = Convert.ToInt32(datos.SEMANA);
            int sm2 = sm1 + 1;
            int sm3 = sm1 + 2;
            int sm4 = sm1 + 3;
            int sm5 = sm1 + 4;
            int sm6 = sm1 + 5;
            int sm7 = sm1 + 6;
            if (sm1 == 52)
            {
                sm2 = 1;
                sm3 = 2;
                sm4 = 3;
                sm5 = 4;
                sm6 = 5;
                sm7 = 6;
            }
            if (sm1 == 51)
            {
                sm3 = 1;
                sm4 = 2;
                sm5 = 3;
                sm6 = 4;
                sm7 = 5;
            }
            if (sm1 == 50)
            {
                sm4 = 1;
                sm5 = 2;
                sm6 = 3;
                sm7 = 4;

            }
            if (sm1 == 49)
            {
                sm5 = 1;
                sm6 = 2;
                sm7 = 3;

            }
            if (sm1 == 48)
            {
                sm6 = 1;
                sm7 = 2;

            }
            if (sm1 == 47)
            {
                sm7 = 1;

            }


            sql += " SELECT  ";
            sql += "       ea.[centro] ";
            sql += "       ,ea.[productor] ";
            sql += "       ,ea.[Especie] ";
            sql += "       ,ea.[variedad] ";
            sql += "        ,[nombre] ";
            sql += "       ,CB.TIPO AS 'CALIBRE' ";
            sql += "       ,TP.TIPO AS 'TIPIFICACION' ";
            sql += "       ,IG.exportacion as 'EXPORTACION' ";
            sql += "      ,ISNULL((SE1.LUNES / ET.PESO2 * (TP.VALOR1 / 100) * (CB.VALOR1 / 100) * IG.EXPORTACION  /100),0) AS 'LUNES1' ";
            sql += "       ,ISNULL((SE1.MARTES / ET.PESO2 * (TP.VALOR1 / 100) * (CB.VALOR1 / 100) * IG.EXPORTACION  /100),0) AS 'MARTES1' ";
            sql += "       ,ISNULL((SE1.MIERCOLES / ET.PESO2 * (TP.VALOR1 / 100) * (CB.VALOR1 / 100) * IG.EXPORTACION  /100),0)  AS 'MIERCOLES1' ";
            sql += "       ,ISNULL((SE1.JUEVES / ET.PESO2 * (TP.VALOR1 / 100) * (CB.VALOR1 / 100) * IG.EXPORTACION  /100),0)  AS 'JUEVES1' ";
            sql += "       ,ISNULL((SE1.VIERNES / ET.PESO2 * (TP.VALOR1 / 100) * (CB.VALOR1 / 100) * IG.EXPORTACION  /100),0)  AS 'VIERNES1' ";
            sql += "      ,ISNULL((SE1.SABADO / ET.PESO2 * (TP.VALOR1 / 100) * (CB.VALOR1 / 100) * IG.EXPORTACION  /100),0)  AS 'SABADO1' ";
            sql += "      ,ISNULL((SE1.DOMINGO / ET.PESO2 * (TP.VALOR1 / 100) * (CB.VALOR1 / 100) * IG.EXPORTACION  /100),0)  AS 'DOMINGO1' ";
            sql += "       , CASE WHEN (SE1.TOTAL / ET.PESO * (TP.VALOR1 / 100) * (CB.VALOR1 / 100)  ) IS NULL ";
            sql += "       THEN (ea.S" + sm2 + " / ET.PESO * (TP.VALOR / 100) * (CB.VALOR / 100)  ) ";
            sql += "        ELSE (SE1.TOTAL / ET.PESO * (TP.VALOR1 / 100) * (CB.VALOR1 / 100)  ) END  AS 'TOTAL1' ";
            sql += "       ,ISNULL((SE2.LUNES / ET.PESO2 * (TP.VALOR2 / 100) * (CB.VALOR2 / 100) * IG.EXPORTACION  /100),0) AS 'LUNES2' ";
            sql += "       ,ISNULL((SE2.MARTES / ET.PESO2 * (TP.VALOR2 / 100) * (CB.VALOR2  / 100) * IG.EXPORTACION  /100),0)  AS 'MARTES2' ";
            sql += "       ,ISNULL((SE2.MIERCOLES / ET.PESO2 * (TP.VALOR2 / 100) * (CB.VALOR2 / 100) * IG.EXPORTACION  /100),0)  AS 'MIERCOLES2' ";
            sql += "       ,ISNULL((SE2.JUEVES / ET.PESO2 * (TP.VALOR2 / 100) * (CB.VALOR2 / 100) * IG.EXPORTACION  /100),0)  AS 'JUEVES2' ";
            sql += "       ,ISNULL((SE2.VIERNES / ET.PESO2 * (TP.VALOR2 / 100) * (CB.VALOR2 / 100) * IG.EXPORTACION  /100),0)  AS 'VIERNES2' ";
            sql += "      ,ISNULL((SE2.SABADO / ET.PESO2 * (TP.VALOR2 / 100) * (CB.VALOR2 / 100) * IG.EXPORTACION  /100),0) AS 'SABADO2' ";
            sql += "       ,ISNULL((SE2.DOMINGO / ET.PESO2 * (TP.VALOR2 / 100) * (CB.VALOR2 / 100) * IG.EXPORTACION  /100),0)  AS 'DOMINGO2' ";
            sql += "       , CASE WHEN (SE2.TOTAL / ET.PESO *  (TP.VALOR2 / 100) *(CB.VALOR2 / 100) ) IS NULL ";
            sql += "       THEN  (ea.S" + sm3 + " / ET.PESO *  (TP.VALOR / 100) *(CB.VALOR / 100) ) ";
            sql += "       ELSE (SE2.TOTAL / ET.PESO *  (TP.VALOR2 / 100) *(CB.VALOR2 / 100) ) END  AS 'TOTAL2' ";
            sql += "       , (SE3.TOTAL / ET.PESO * (TP.VALOR / 100) * (CB.VALOR / 100)  ) END AS 'TOTAL3' ";
            sql += "       , (SE4.TOTAL / ET.PESO * (TP.VALOR / 100) * (CB.VALOR / 100)  ) END AS 'TOTAL4' ";
            sql += "       , (SE5.TOTAL / ET.PESO * (TP.VALOR / 100) * (CB.VALOR / 100)  ) END AS 'TOTAL5' ";
            sql += "       , (SE6.TOTAL / ET.PESO * (TP.VALOR / 100) * (CB.VALOR / 100)  ) END AS 'TOTAL6' ";
            sql += "       ,ea.[ano] ,ea.[usuario] , ";
            sql += "   etp.frioconvencional , etp.atmosfera_controlada";
            //sql += " case when etp2.frioconvencional is null then etp.frioconvencional else etp2.frioconvencional end frioconvencional, ";
            //sql += " case when etp2.atmosfera_controlada is null then etp.atmosfera_controlada else etp2.atmosfera_controlada end atmosfera_controlada ";
          
            sql += "   FROM [ECO_ANUAL] ea ";
            sql += "   left join (SELECT TP.productor, TP.ESPECIE,TP.estimacion, TP.variedad, TP.usuario, ";
            sql += "    TP.centro, TP.ano, TP.anual,TP.TIPO, TP.VALOR, TP1.valor AS VALOR1, TP2.VALOR AS VALOR2 ";
            sql += "    FROM  ECO_tipificacion TP ";
            sql += "  Left JOIN (SELECT * FROM ECO_tipificacion WHERE EDITADO = " + sm1 + " and semana = " + sm2 + ") TP1 ON ";
            sql += "    TP1.ano = TP.ano AND TP1.centro = TP.centro AND TP1.especie = TP.especie AND TP.variedad = TP1.variedad ";
            sql += "    AND TP1.estimacion = TP.estimacion AND TP1.productor = TP.productor AND TP1.usuario = TP.usuario  ";
            sql += "    and TP1.tipo = TP.tipo ";
            sql += "  Left  JOIN (SELECT * FROM ECO_tipificacion WHERE EDITADO = " + sm1 + " and semana = " + sm3 + ") TP2 ON  ";
            sql += "    TP2.ano = TP.ano AND TP2.centro = TP.centro AND TP2.especie = TP.especie AND TP.variedad = TP2.variedad ";
            sql += "    AND TP2.estimacion = TP.estimacion AND TP2.productor = TP.productor AND TP2.usuario = TP.usuario  ";
            sql += "    and TP2.tipo = TP.tipo)  tp on tp.CENTRO = EA.CENTRO and tp.especie = ea.especie and tp.productor = ea.productor and tp.variedad = ea.variedad and tp.USUARIO = EA.USUARIO ";
            sql += "   left join (SELECT CB.productor, CB.ESPECIE,CB.estimacion, CB.variedad, CB.usuario, CB.centro, CB.ano, CB.anual  ";
            sql += "        ,CB.TIPO, CB.VALOR, CB1.valor AS VALOR1, CB2.VALOR AS VALOR2  ";
            sql += "        FROM  ECO_calibre CB  ";
            sql += "    Left    JOIN (SELECT * FROM ECO_calibre WHERE EDITADO = " + sm1 + " and semana = " + sm2 + ") CB1 ON   ";
            sql += "        CB1.ano = CB.ano AND CB1.centro = CB.centro AND CB1.especie = CB.especie AND CB.variedad = CB1.variedad  ";
            sql += "        AND CB1.estimacion = CB.estimacion AND CB1.productor = CB.productor AND CB1.usuario = CB.usuario   ";
            sql += "        and CB1.tipo = CB.tipo  ";
            sql += "   Left     JOIN (SELECT * FROM ECO_calibre WHERE EDITADO = " + sm1 + " and semana = " + sm3 + ") CB2 ON   ";
            sql += "        CB2.ano = CB.ano AND CB2.centro = CB.centro AND CB2.especie = CB.especie AND CB.variedad = CB2.variedad  ";
            sql += "        AND CB2.estimacion = CB.estimacion AND CB2.productor = CB.productor AND CB2.usuario = CB.usuario   ";
            sql += "        and CB2.tipo = CB.tipo)  cb on cb.CENTRO = EA.CENTRO and cb.especie = ea.especie and cb.productor = ea.productor and cb.variedad = ea.variedad and cb.USUARIO = EA.USUARIO ";
            sql += "   left join ECO_ingreso IG on IG.CENTRO = EA.CENTRO and IG.especie = ea.especie and IG.productor = ea.productor and IG.variedad = ea.variedad and IG.USUARIO = EA.USUARIO ";
            sql += "   left join eco_temporada et on et.ESPECIE = ea.ESPECIE  ";
            sql += "   left JOIN (SELECT * FROM eco_detalle_dia WHERE semana = " + sm2 + " AND editado = " + sm1 + ") SE1 ON SE1.id_anual = EA.id ";
            sql += "   left JOIN (SELECT * FROM eco_detalle_dia WHERE semana = " + sm3 + " AND editado = " + sm1 + ") SE2 ON SE2.id_anual = EA.id ";
            sql += "   left JOIN (SELECT * FROM eco_detalle_dia WHERE semana = " + sm4 + " AND editado = " + sm1 + ") SE3 ON SE3.id_anual = EA.id ";
            sql += "   left JOIN (SELECT * FROM eco_detalle_dia WHERE semana = " + sm5 + " AND editado = " + sm1 + ") SE4 ON SE4.id_anual = EA.id ";
            sql += "   left JOIN (SELECT * FROM eco_detalle_dia WHERE semana = " + sm6 + " AND editado = " + sm1 + ") SE5 ON SE5.id_anual = EA.id ";
            sql += "   left JOIN (SELECT * FROM eco_detalle_dia WHERE semana = " + sm7 + " AND editado = " + sm1 + ") SE6 ON SE6.id_anual = EA.id ";
            sql += "   LEFT JOIN eco_tipo_frio etp on etp.productor = ea.productor and etp.ano = ea.ano and etp.estimacion = ea.nombre ";
            sql += "   and etp.especie = ea.Especie and etp.variedad = ea.variedad and etp.estimacion = " + datos.ESTIMACION + " and etp.anual = 1  ";

            //sql += " LEFT JOIN eco_tipo_frio etp2 on etp2.productor = ea.productor and etp2.ano = ea.ano ";
            //sql += " and etp2.estimacion = ea.nombre    and etp2.especie = ea.Especie and etp2.variedad = ea.variedad  ";
            //sql += " and etp2.estimacion = 2 and etp2.anual = 0 and etp2.editado = " + sm1;

            sql += " where EA.ano = '" + datos.TEMPORADA + "' ";
            if (!datos.VARIEDAD.Equals("'0'"))
            {
                sql += " AND EA.VARIEDAD in (" + datos.VARIEDAD + ") ";
            }
            if (!datos.ESPECIE.Equals("'0'"))
            {
                sql += " AND EA.ESPECIE in (" + datos.ESPECIE + ") ";
            }
            if (!datos.PRODUCTOR.Equals("'0'"))
            {
                sql += " AND EA.PRODUCTOR in (" + datos.PRODUCTOR + ")";
            }
            sql += " AND EA.NOMBRE = '" + datos.ESTIMACION + "' ";
            sql += " AND TP.ESTIMACION  = '" + datos.ESTIMACION + "' ";
            sql += " AND CB.ESTIMACION  = '" + datos.ESTIMACION + "' ";
            sql += " AND IG.ESTIMACION  = '" + datos.ESTIMACION + "' ";
            //sql += " AND ea.S" + datos.SEMANA +" > 0 ";
            sql += " and (TP.VALOR  > 0  or tp.VALOR1 > 0 OR tp.VALOR2 > 0) ";
            sql += " and (CB.VALOR  > 0  or CB.VALOR1 > 0 OR CB.VALOR2 > 0) ";
            sql += " and tp.anual = 1 ";
            sql += " and CB.anual = 1 ";
            sql += " and IG.anual = 1 ";
            sql += " and EA.[estado] != 'HISTORICO' and EA.[estado] != 'PENDIENTE'";
            sql += " and (SE1.total > 0 OR SE2.total > 0 OR SE3.total > 0 OR SE4.total > 0 OR SE5.total > 0 OR SE6.TOTAL > 0 ";
            sql += " OR ea.S" + sm1 + " > 0 OR ea.S" + sm2 + " > 0 OR ea.S" + sm3 + " > 0 OR ea.S" + sm4 + " > 0 OR ea.S" + sm5 + " > 0 OR ea.S" + sm6 + " > 0 OR ea.S" + sm7 + " > 0)";


            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ECO_INFORME_CAJA res = new responce_ECO_INFORME_CAJA();

                    res.CENTRO = dataReader[0].ToString();
                    res.PRODUCTOR = dataReader[1].ToString();
                    res.ESPECIE = dataReader[2].ToString();
                    res.VARIEDAD = dataReader[3].ToString();
                    res.NOMBRE = dataReader[4].ToString();
                    res.CALIBRE = dataReader[5].ToString();
                    res.TIPIFICACION = dataReader[6].ToString();
                    res.EXPORTACION = dataReader[7].ToString();
                    res.LUNES1 = dataReader[8].ToString();
                    res.MARTES1 = dataReader[9].ToString();
                    res.MIERCOLES1 = dataReader[10].ToString();
                    res.JUEVES1 = dataReader[11].ToString();
                    res.VIERNES1 = dataReader[12].ToString();
                    res.SABADO1 = dataReader[13].ToString();
                    res.DOMINGO1 = dataReader[14].ToString();
                    res.TOTAL1 = dataReader[15].ToString();
                    res.LUNES2 = dataReader[16].ToString();
                    res.MARTES2 = dataReader[17].ToString();
                    res.MIERCOLES2 = dataReader[18].ToString();
                    res.JUEVES2 = dataReader[19].ToString();
                    res.VIERNES2 = dataReader[20].ToString();
                    res.SABADO2 = dataReader[21].ToString();
                    res.DOMINGO2 = dataReader[22].ToString();
                    res.TOTAL2 = dataReader[23].ToString();
                    res.TOTAL3 = dataReader[24].ToString();
                    res.TOTAL4 = dataReader[25].ToString();
                    res.TOTAL5 = dataReader[26].ToString();
                    res.TOTAL6 = dataReader[27].ToString();
                    res.ANO = dataReader[28].ToString();
                    res.USUARIO = dataReader[29].ToString();
                    res.FRIOCONVENCIONAL = dataReader[30].ToString();
                    res.ATMOSFERACONTROLADA = dataReader[31].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_INFORME_CAJA
    {

        public String CENTRO;
        public String PRODUCTOR;
        public String ESPECIE;
        public String VARIEDAD;
        public String NOMBRE;
        public String CALIBRE;
        public String TIPIFICACION;
        public String EXPORTACION;
        public String LUNES1;
        public String MARTES1;
        public String MIERCOLES1;
        public String JUEVES1;
        public String VIERNES1;
        public String SABADO1;
        public String DOMINGO1;
        public String TOTAL1;
        public String LUNES2;
        public String MARTES2;
        public String MIERCOLES2;
        public String JUEVES2;
        public String VIERNES2;
        public String SABADO2;
        public String DOMINGO2;
        public String TOTAL2;
        public String TOTAL3;
        public String TOTAL4;
        public String TOTAL5;
        public String TOTAL6;
        public String ANO;
        public String USUARIO;
        public String FRIOCONVENCIONAL;
        public String ATMOSFERACONTROLADA;


    }
    public class request_ECO_INFORME_CAJA
    {
        public String TEMPORADA;
        public String ESTIMACION;
        public String ESPECIE;
        public String VARIEDAD;
        public String PRODUCTOR;
        public String SEMANA;
    }
}