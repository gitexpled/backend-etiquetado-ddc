using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ETIQUETA_CONSULTA
    {
        public Array run(request_ETIQUETA_CONSULTA datos)
        {
            List<responce_ETIQUETA_CONSULTA> List = new List<responce_ETIQUETA_CONSULTA>();

            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select * from etiqueta";
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
                    responce_ETIQUETA_CONSULTA res = new responce_ETIQUETA_CONSULTA();
                    res.id = dataReader[0].ToString();
                    res.proceso = dataReader[1].ToString();
                    res.centro = dataReader[2].ToString();
                    res.especie = dataReader[3].ToString();
                    res.variedad = dataReader[4].ToString();
                    res.grsmunit = dataReader[5].ToString();
                    res.countapp = dataReader[6].ToString();
                    res.calibre = dataReader[7].ToString();
                    res.glosalibre = dataReader[8].ToString();
                    res.productor = dataReader[9].ToString();
                    res.ggn = dataReader[10].ToString();
                    res.prd_comuna = dataReader[11].ToString();
                    res.prd_provincia = dataReader[12].ToString();
                    res.prd_region = dataReader[13].ToString();
                    res.csg = dataReader[14].ToString();
                    res.idg = dataReader[15].ToString();
                    res.sdp = dataReader[16].ToString();
                    res.envaen14 = dataReader[17].ToString();
                    res.embasex14 = dataReader[18].ToString();
                    res.dun14 = dataReader[19].ToString();
                    res.lotegti = dataReader[20].ToString();
                    res.exportadora = dataReader[21].ToString();
                    res.exp_comuna = dataReader[2].ToString();
                    res.exp_provincia = dataReader[23].ToString();
                    res.csp = dataReader[24].ToString();
                    res.idp = dataReader[25].ToString();
                    res.fda = dataReader[26].ToString();
                    res.kilos = dataReader[27].ToString();
                    res.diametro = dataReader[28].ToString();
                    res.codigo_material = dataReader[29].ToString();
                    res.lote = dataReader[30].ToString();
                    res.fecha1 = dataReader[31].ToString();
                    res.fecha2 = dataReader[32].ToString();
                    res.voickb = dataReader[33].ToString();
                    res.voicka = dataReader[34].ToString();
                    res.correlativo = dataReader[35].ToString();
                    res.salida = dataReader[36].ToString();
                    res.turno = dataReader[37].ToString();
                    res.linea = dataReader[38].ToString();
                    res.posicion = dataReader[39].ToString();
                    res.embalaje = dataReader[40].ToString();
                    res.material_kilos = dataReader[41].ToString();
                    res.variedad_value = dataReader[42].ToString();
                    res.calidad = dataReader[43].ToString();
                    res.tipo_frio = dataReader[44].ToString();
                    res.envaein14IMP = dataReader[45].ToString();
                    res.upc = dataReader[46].ToString();
                    res.ean13 = dataReader[47].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_ETIQUETA_CONSULTA
    {
        public String id;
        public String proceso;
        public String centro;
        public String especie;
        public String variedad;
        public String grsmunit;
        public String countapp;
        public String calibre;
        public String glosalibre;
        public String productor;
        public String ggn;
        public String prd_comuna;
        public String prd_provincia;
        public String prd_region;
        public String csg;
        public String idg;
        public String sdp;
        public String envaen14;
        public String embasex14;
        public String dun14;
        public String lotegti;
        public String exportadora;
        public String exp_comuna;
        public String exp_provincia;
        public String csp;
        public String idp;
        public String fda;
        public String kilos;
        public String diametro;
        public String codigo_material;
        public String lote;
        public String fecha1;
        public String fecha2;
        public String voickb;
        public String voicka;
        public String correlativo;
        public String salida;
        public String turno;
        public String linea;
        public String posicion;
        public String embalaje;
        public String material_kilos;
        public String variedad_value;
        public String calidad;
        public String tipo_frio;
        public String envaein14IMP;
        public String upc;
        public String ean13;
    }
    public class request_ETIQUETA_CONSULTA
    {
        public String ID;
    }
}