using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_G_FT
    {
        public Array run(request_ECO_CONSULTA_G_FT datos)
        {
            List<responce_ECO_CONSULTA_G_FT> List = new List<responce_ECO_CONSULTA_G_FT>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "SELECT * FROM prd_ficha_tecnica ft ";
            sql += " left join prd_padre_hijo pr on pr.id = ft.id_productor ";
            sql += " left join prd_especie es on es.id = ft.id_especie ";
            sql += " left join especie_variedad vr on vr.id = ft.id_variedad ";
            sql += " where (pr.productor = '" + datos.CODIGO + "' or '" + datos.CODIGO + "' = '')";
            sql += " and ft.temporada = '"+ datos.TEMPORADA +"'";
            sql += " and (usuario = '" + datos.USUARIO + "' or '" + datos.USUARIO + "' = '')";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            Int16 i = 0;
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_ECO_CONSULTA_G_FT res = new responce_ECO_CONSULTA_G_FT();  
                    res.id = dataReader[0].ToString();    
                    res.prd_hijo = dataReader[7].ToString();
                    res.nombre = dataReader[8].ToString();
                    res.huerto = dataReader[9].ToString();
                    res.csg = dataReader[10].ToString();
                    res.idp_e = dataReader[11].ToString();
                    res.georeferenciacion = dataReader[12].ToString();                    
                    res.id_e = dataReader[13].ToString();
                    res.especie = dataReader[14].ToString();
                    res.cuartel = dataReader[15].ToString();
                    res.tipo_certificacion = dataReader[16].ToString();
                    res.gobla_gap_number = dataReader[17].ToString();
                    res.ggn_desde = dataReader[18].ToString();
                    res.ggn_hasta = dataReader[19].ToString();                   
                    res.id_v = dataReader[20].ToString();
                    res.variedad = dataReader[21].ToString();
                    res.dis_entre_hileras = dataReader[22].ToString();
                    res.dis_sobre_hileras = dataReader[23].ToString();
                    res.arb_productivos = dataReader[24].ToString();
                    res.planta_por_ha = dataReader[25].ToString();
                    res.superficie = dataReader[26].ToString();
                    res.plantas_totales = dataReader[27].ToString();
                    res.ano_plantacion = dataReader[28].ToString();
                    res.uniformidad = dataReader[29].ToString();
                    res.central_cargo = dataReader[30].ToString();
                    res.tipo_packing = dataReader[31].ToString();
                    res.tipo_riesgo = dataReader[32].ToString();
                    res.csp = dataReader[33].ToString();
                    res.idp_v = dataReader[34].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ECO_CONSULTA_G_FT
    {
    
        public String id; 
        public String prd_hijo;
        public String nombre;
        public String huerto;
        public String csg;
        public String idp_e;
        public String georeferenciacion;
        
        public String cuartel;
        public String id_e;
        public String especie;
        public String gobla_gap_number;
        public String ggn_desde;
        public String ggn_hasta;
        public String tipo_certificacion;
        public String id_v;

        public String variedad;
        public String dis_entre_hileras;
        public String dis_sobre_hileras;
        public String arb_productivos;
        public String planta_por_ha;
        public String superficie;
        public String plantas_totales;

        public String ano_plantacion;
        public String uniformidad;
        public String central_cargo;
        public String tipo_packing;
        public String tipo_riesgo;
        public String csp;
        public String idp_v;
        
    }
    public class request_ECO_CONSULTA_G_FT
    {
        public String CODIGO;
        public String TEMPORADA;
        public String USUARIO;
    }
}