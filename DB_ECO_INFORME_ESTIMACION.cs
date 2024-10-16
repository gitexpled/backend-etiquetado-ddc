using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_INFORME_ESTIMACION
    {
        public Array run(request_ECO_INFORME_ESTIMACION datos)
        {
            List<responce_ECO_INFORME_ESTIMACION> List = new List<responce_ECO_INFORME_ESTIMACION>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "";
            for (int i = 1; i <= 52; i ++)
            {

                sql += "SELECT EA.[ano] ";
	            sql += " ,EA.[nombre] ";
                sql += " ,EA.[centro] ";
                sql += " ,EA.[Especie] ";
                sql += " ,EA.[variedad] ";
                sql += " ,EA.[productor] ";   
                sql += " ,TP.TIPO AS 'TIPIFICACION' ";
                sql += ", case ";
                //sql += " when tem.INICIO <= '" + i + "' AND tem.FIN <= '" + i + "' then ";
                sql += " when 42 <= '" + i + "' then ";
                sql += " CONVERT(varchar(10), (EA.ANO -1)) + '" + i + "' else ";
                sql += " EA.ANO + '" + i + "' end AS 'ANO - SEMANA' ";  
                //sql += " ,EA.ANO + '"+i+"' AS 'ANO - SEMANA' ";
                sql += " ,IG.EXPORTACION AS EXPORTACION ";
                sql += " ,CB.TIPO AS 'CALIBRE', ";
                //sql += " CASE WHEN EA.variedad = 'DAGEN' THEN ";
                //sql += " (EA.S"+i+" /  ET.PESO3 * (TP.VALOR / 100) * (CB.VALOR / 100) * IG.EXPORTACION  /100)";
                //sql += " else ";
                //sql += " (EA.S" + i + " /  ET.PESO2 * (TP.VALOR / 100) * (CB.VALOR / 100) * IG.EXPORTACION  /100)";
                //sql += "end AS 'CAJAS'";
                //sql += " ,(EA.S" + i + " / ET.PESO *  (TP.VALOR / 100) *(CB.VALOR / 100) ) AS 'ENVASES' ";
                sql += " CASE WHEN EA.variedad = 'DAGEN'  ";
                sql += " THEN  (EA.S" + i + " /  ET.PESO3 * (TP.VALOR / 100) * (CB.VALOR / 100) * IG.EXPORTACION  /100)  ";
                sql += " else   ";
                //sql += " case when  ";
                //sql += " bct.tipificacion is null then ";
                //sql += " case when  ";
                //sql += " sumTip.valorTipificacion > 0 then ";
                //sql += " (EA.S" + i + " /  ET.PESO2 * ((TP.VALOR / 100) / (sumTip.valorTipificacion/100)  ) * (CB.VALOR / 100) * IG.EXPORTACION  /100)  ";
                //sql += " else 0 end ";
                //sql += " else 0 end ";
                //sql += " end AS 'CAJAS'  ";
                sql += " (EA.S" + i + " /  ET.PESO2 * ((TP.VALOR / 100)  ) * (CB.VALOR / 100) * IG.EXPORTACION  /100) end AS 'CAJAS' ";
                //sql += " ,case when  ";
                //sql += " bct.tipificacion is null then ";
                //sql += " case when ";
                //sql += " sumTip.valorTipificacion > 0 then ";
                //sql += " (EA.S" + i + " / ET.PESO *  ((TP.VALOR / 100) / (sumTip.valorTipificacion/100)  ) *(CB.VALOR / 100) )  ";
                //sql += " else 0 end ";
                //sql += " else 0 end ";
                //sql += "  AS 'ENVASES' ";
                sql += " ,(EA.S" + i + " / ET.PESO *  (TP.VALOR / 100) * (CB.VALOR / 100) ) AS 'ENVASES' ";
                sql += " ,ET.ENVASE ";
                sql += " ,us.nombre + ' ' + us.apellido    as 'AGRONOMO' ";
                sql += " ,EA.[USUARIO] ";
                sql += "  ,tf.frioconvencional, tf.atmosfera_controlada ";
                sql += " FROM [ECO_ANUAL] ea ";
                sql += " left join eco_tipificacion  tp on tp.CENTRO = EA.CENTRO and tp.especie = ea.especie and tp.productor = ea.productor and tp.variedad = ea.variedad and tp.USUARIO = EA.USUARIO ";
                sql += " left join eco_calibre  cb on cb.CENTRO = EA.CENTRO and cb.especie = ea.especie and cb.productor = ea.productor and cb.variedad = ea.variedad and cb.USUARIO = EA.USUARIO ";
                sql += " left join ECO_ingreso IG on IG.CENTRO = EA.CENTRO and IG.especie = ea.especie and IG.productor = ea.productor and IG.variedad = ea.variedad and IG.USUARIO = EA.USUARIO ";
                sql += " left join usuario us on us.idusuario = ea.usuario ";
                sql += " left join eco_temporada et on et.ESPECIE = ea.ESPECIE ";
                sql += " left join dbo.eco_temporada tem on tem.ESPECIE = ea.ESPECIE ";
                sql += " LEFT JOIN dbo.eco_tipo_frio tf on tf.centro=ea.centro and tf.productor=ea.productor and tf.variedad=ea.variedad and tf.especie=ea.Especie and tf.estimacion=ea.nombre and tf.usuario=ea.usuario and tf.anual = 1 ";
                //sql += " left join bloqueo_calibre_tipificacion bct on bct.especie = ea.Especie and bct.calibre = cb.tipo ";
                //sql += " and bct.tipificacion = tp.tipo ";
                //sql += " LEFT join (SELECT sum(et.valor) valorTipificacion ,  cb.tipo calibre, et.productor, et.variedad, et.Especie ";
                //sql += " FROM eco_tipificacion et ";
                //sql += " left join eco_calibre cb on  cb.especie = et.especie  ";
                //sql += " and cb.productor = et.productor and cb.variedad = et.variedad and cb.USUARIO = et.USUARIO  ";
                //sql += " and et.estimacion = cb.estimacion ";
                //sql += " where  et.anual = 1 and cb.anual = 1  ";
                //sql += " and et.tipo not in (select tipificacion from bloqueo_calibre_tipificacion where calibre = cb.tipo)  ";
                //sql += " group by  cb.tipo, et.productor, et.variedad, et.Especie)  ";
	            //sql += " sumTip on  sumTip.calibre = cb.tipo and sumTip.productor = ea.productor  ";
	            //sql += " and  sumTip.especie = ea.Especie and ea.variedad = sumTip.variedad ";
                
                sql += " where EA.ano = '"+ datos.TEMPORADA +"' ";
                
                //sql += " AND (EA.VARIEDAD = '" + datos.VARIEDAD + "' OR '" + datos.VARIEDAD + "' = 0 )";
                //sql += " AND (EA.ESPECIE = '" + datos.ESPECIE + "' OR '" + datos.ESPECIE + "' = 0 )";
                //sql += " AND (EA.PRODUCTOR = '" + datos.PRODUCTOR + "' OR '" + datos.PRODUCTOR + "' = 0 )";
                sql += " AND EA.NOMBRE = '"+datos.ESTIMACION+"' ";
                sql += " AND TP.ESTIMACION  = '" + datos.ESTIMACION + "' ";
                sql += " AND CB.ESTIMACION  = '" + datos.ESTIMACION + "' ";
                sql += " AND IG.ESTIMACION  = '" + datos.ESTIMACION + "' ";
                sql += " and TP.VALOR  > 0 ";
                sql += " and CB.VALOR  > 0 ";
                sql += " and tp.anual = 1 ";
                sql += " and CB.anual = 1 ";
                sql += " and IG.anual = 1 ";
                sql += " and EA.[estado] != 'HISTORICO' and EA.[estado] != 'PENDIENTE'";
                sql += " AND EA.S"+i+" > 0";
                //sql += " AND EA.productor = 'A458'";
                if (i < 52)
                {
                    sql += " UNION ";
                }
            }
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ECO_INFORME_ESTIMACION res = new responce_ECO_INFORME_ESTIMACION();  
                    res.ANO = dataReader[0].ToString();
                    res.NOMBRE = dataReader[1].ToString();
                    res.CENTRO = dataReader[2].ToString();
                    res.ESPECIE = dataReader[3].ToString();
                    res.VARIEDAD = dataReader[4].ToString();
                    res.PRODUCTOR = dataReader[5].ToString();
                    res.TIPIFICACION = dataReader[6].ToString();
                    res.SEMANA = dataReader[7].ToString();
                    res.EXPORTACION = dataReader[8].ToString();
                    res.CALIBRE = dataReader[9].ToString();
                    res.CAJAS = dataReader[10].ToString();
                    res.ENVASES = dataReader[11].ToString();
                    res.ENVASE = dataReader[12].ToString();
                    res.AGRONOMO = dataReader[13].ToString();
                    res.USUARIO = dataReader[14].ToString();
                    res.FRIOCONVENCIONAL = dataReader[15].ToString();
                    res.ATMOSFERACONTROLADA = dataReader[16].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_INFORME_ESTIMACION
    {
    
        public String ANO; 
        public String NOMBRE;
        public String CENTRO;
        public String ESPECIE;
        public String VARIEDAD;
        public String PRODUCTOR;
        public String TIPIFICACION;
        public String SEMANA;        
        public String EXPORTACION;
        public String CALIBRE;
        public String CAJAS;
        public String ENVASES;
        public String ENVASE;
        public String AGRONOMO;
        public String USUARIO;
        public String FRIOCONVENCIONAL;
        public String ATMOSFERACONTROLADA;
       
        
    }
    public class request_ECO_INFORME_ESTIMACION
    {
        public String TEMPORADA;
        public String ESTIMACION;
        public String ESPECIE;
        public String VARIEDAD;
        public String PRODUCTOR;
    }
}