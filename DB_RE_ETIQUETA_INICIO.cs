using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace rfcBaika
{
    public class DB_RE_ETIQUETA_INICIO
    {
        public Array run(request_RE_ETIQUETA_INICIO datos)
        {
            List<responce_RE_ETIQUETA_INICIO> List = new List<responce_RE_ETIQUETA_INICIO>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("RE_ETIQUETA_INICIO", connection);
                cmd.Parameters.Add(new SqlParameter("@Proceso", datos.PROCESO));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        responce_RE_ETIQUETA_INICIO res = new responce_RE_ETIQUETA_INICIO();
                        res.id_zpl = dr[0].ToString();
                        res.zpl = dr[1].ToString();
                        res.stock = dr[2].ToString();
                        res.id_posicion = dr[3].ToString();
                        res.proceso = dr[4].ToString();
                        res.kilos_material = dr[5].ToString();
                        res.Line = dr[6].ToString();
                        res.ip_Zebra = dr[7].ToString();
                        res.salida = dr[8].ToString();
                        res.calibre = dr[9].ToString();
                        res.tipo_material = dr[10].ToString();
                        res.id_etiqueta = dr[11].ToString();
                        res.centro = dr[12].ToString();
                        res.especie = dr[13].ToString();
                        res.variedad = dr[14].ToString();
                        res.grsmunit = dr[15].ToString();
                        res.countapp = dr[16].ToString();
                        res.glosalibre = dr[17].ToString();
                        res.productor = dr[18].ToString();
                        res.ggn = dr[19].ToString();
                        res.prd_comuna = dr[20].ToString();
                        res.prd_provincia = dr[21].ToString();
                        res.prd_region = dr[22].ToString();
                        res.csg = dr[23].ToString();
                        res.idg = dr[24].ToString();
                        res.sdp = dr[25].ToString();
                        res.envaein14 = dr[26].ToString();
                        res.embasex14 = dr[27].ToString();
                        res.dun14 = dr[28].ToString();
                        res.lotegti = dr[29].ToString();
                        res.exportadora = dr[30].ToString();
                        res.exp_comuna = dr[31].ToString();
                        res.exp_provincia = dr[32].ToString();
                        res.csp = dr[33].ToString();
                        res.idp = dr[34].ToString();
                        res.fda = dr[35].ToString();
                        res.kilos = dr[36].ToString();
                        res.diametro = dr[37].ToString();
                        res.codigo_material = dr[38].ToString();
                        res.lote = dr[39].ToString();
                        res.fecha_prd = dr[40].ToString();
                        res.fecha_prd2 = dr[41].ToString();
                        res.voickb = dr[42].ToString();
                        res.voicka = dr[43].ToString();
                        res.correlativo = dr[44].ToString();
                        res.turno = dr[45].ToString();
                        res.linea = dr[46].ToString();
                        res.zpl_posicion = dr[47].ToString();
                        res.embalaje = dr[48].ToString();
                        res.material_kilos = dr[49].ToString();
                        res.variedad_value = dr[50].ToString();
                        res.calidad = dr[51].ToString();
                        res.tipo_frio = dr[52].ToString();
                        res.envaein14IMP = dr[53].ToString();
                        res.upc = dr[54].ToString();
                        res.ean13 = dr[55].ToString();
                        List.Add(res);
                    }

                }
            }
            catch (Exception e)
            {

                responce_RE_ETIQUETA_INICIO resp = new responce_RE_ETIQUETA_INICIO();
                resp.Error = e.ToString();
                List.Add(resp);
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_RE_ETIQUETA_INICIO
    {
        public String id_zpl;
        public String zpl;
        public String stock;
        public String id_posicion;
        public String proceso;
        public String kilos_material;
        public String Line;
        public String ip_Zebra;
        public String salida;
        public String calibre;
        public String tipo_material;
        public String id_etiqueta;
        public String centro;
        public String especie;
        public String variedad;
        public String grsmunit;
        public String countapp;
        public String glosalibre;
        public String productor;
        public String ggn;
        public String prd_comuna;
        public String prd_provincia;
        public String prd_region;
        public String csg;
        public String idg;
        public String sdp;
        public String envaein14;
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
        public String fecha_prd;
        public String fecha_prd2;
        public String voickb;
        public String voicka;
        public String correlativo;
        public String turno;
        public String linea;
        public String zpl_posicion;
        public String embalaje;
        public String material_kilos;
        public String variedad_value;
        public String calidad;
        public String tipo_frio;
        public String envaein14IMP;
        public String upc;
        public String ean13;
        public String Error;
    }
    public class request_RE_ETIQUETA_INICIO
    {
        public String PROCESO;
    }
}