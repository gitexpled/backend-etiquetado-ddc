using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace rfcBaika
{
    public class DB_CARGA_INICIAL_RE
    {
        public Array run(request_CARGA_INICIAL_RE datos)
        {
            List<responce_CARGA_INICIAL_RE> List = new List<responce_CARGA_INICIAL_RE>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                cmd = new SqlCommand("Carga_Inicial_RE", connection);
                cmd.Parameters.Add(new SqlParameter("@Proceso", datos.PROCESO));
                cmd.Parameters.Add(new SqlParameter("@centro", datos.CENTRO));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        responce_CARGA_INICIAL_RE res = new responce_CARGA_INICIAL_RE();
                        res.id_Posicion = dr[0].ToString();
                        res.centro = dr[1].ToString();
                        res.pantalla_zpl = dr[2].ToString();
                        res.id_etiqueta = dr[3].ToString();
                        res.proceso = dr[4].ToString();
                        res.stock = dr[5].ToString();
                        res.zpl = dr[6].ToString();
                        res.ip_Zebra = dr[7].ToString();
                        res.salida = dr[8].ToString();
                        res.especie = dr[9].ToString();
                        res.variedad = dr[10].ToString();
                        res.grsmunit = dr[11].ToString();
                        res.countapp = dr[12].ToString();
                        res.calibre = dr[13].ToString();
                        res.glosalibre = dr[14].ToString();
                        res.productor = dr[15].ToString();
                        res.ggn = dr[16].ToString();
                        res.prd_comuna = dr[17].ToString();
                        res.prd_provincia = dr[18].ToString();
                        res.prd_region = dr[19].ToString();
                        res.csg = dr[20].ToString();
                        res.idg = dr[21].ToString();
                        res.sdp = dr[22].ToString();
                        res.envaen14 = dr[23].ToString();
                        res.embasex14 = dr[24].ToString();
                        res.dun14 = dr[25].ToString();
                        res.lotegti = dr[26].ToString();
                        res.exportadora = dr[27].ToString();
                        res.exp_comuna = dr[28].ToString();
                        res.exp_provincia = dr[29].ToString();
                        res.csp = dr[30].ToString();
                        res.idp = dr[31].ToString();
                        res.fda = dr[32].ToString();
                        res.kilos = dr[33].ToString();
                        res.diametro = dr[34].ToString();
                        res.codigo_material = dr[35].ToString();
                        res.lote = dr[36].ToString();
                        res.fecha1 = dr[37].ToString();
                        res.fecha2 = dr[38].ToString();
                        res.voickb = dr[39].ToString();
                        res.voicka = dr[40].ToString();
                        res.correlativo = dr[41].ToString();
                        res.salida2 = dr[42].ToString();
                        res.turno = dr[43].ToString();
                        res.linea = dr[44].ToString();
                        res.zpl_posicion = dr[45].ToString();
                        res.embalaje = dr[46].ToString();
                        res.material_kilos = dr[47].ToString();
                        res.variedad_value = dr[48].ToString();
                        res.calidad = dr[49].ToString();
                        res.tipo_frio = dr[50].ToString();
                        res.envaein14IMP = dr[51].ToString();
                        res.upc = dr[52].ToString();
                        res.ean13 = dr[53].ToString();
                        List.Add(res);
                    }

                }
            }
            catch (Exception e)
            {

                responce_CARGA_INICIAL_RE resp = new responce_CARGA_INICIAL_RE();
                resp.Error = e.ToString();
                List.Add(resp);
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
    public class responce_CARGA_INICIAL_RE
    {
        public String id_Posicion;
        public String centro;
        public String pantalla_zpl;
        public String id_etiqueta;
        public String proceso;
        public String stock;
        public String zpl;
        public String ip_Zebra;
        public String salida;
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
        public String salida2;
        public String turno;
        public String linea;
        public String zpl_posicion;
        public String embalaje;
        public String material_kilos;
        public String variedad_value;
        public String calidad;
        public String tipo_frio;
        public String Error;
        public String envaein14IMP;
        public String upc;
        public String ean13;
    }
    public class request_CARGA_INICIAL_RE
    {
        public String CENTRO;
        public String PROCESO;
    }
}