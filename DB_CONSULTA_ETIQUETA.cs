using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_CONSULTA_ETIQUETA
    {
        public Array run(request_consulta_etiqueta datos)
        {
            List<responce_consulta_etiqueta> List = new List<responce_consulta_etiqueta>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select * from posicion_zpl where centro = '"+datos.centro+"'";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            //Int16 i = 0;
            //Read the data and store them in the list
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    responce_consulta_etiqueta res = new responce_consulta_etiqueta();
                    res.id = dataReader[0].ToString();
                    res.id_zpl = dataReader[1].ToString();
                    res.ip_pantalla = dataReader[2].ToString();
                    res.linea_zpl = dataReader[3].ToString();
                    res.fila_zpl = dataReader[4].ToString();
                    res.pantalla_zpl = dataReader[5].ToString();
                    res.pantalla = dataReader[6].ToString();
                    res.centro = dataReader[7].ToString();
                    res.zpl = dataReader[8].ToString();
                    res.especie = dataReader[9].ToString();
                    res.variedad = dataReader[10].ToString();
                    res.grsmunit = dataReader[11].ToString();
                    res.countapp = dataReader[12].ToString();
                    res.calibre = dataReader[13].ToString();
                    res.glosalibre = dataReader[14].ToString();
                    res.productor = dataReader[15].ToString();
                    res.gglote = dataReader[16].ToString();
                    res.compprod = dataReader[17].ToString();
                    res.proproduc = dataReader[18].ToString();
                    res.prodesc = dataReader[19].ToString();
                    res.csg = dataReader[20].ToString();
                    res.idg = dataReader[21].ToString();
                    res.sdp = dataReader[22].ToString();
                    res.envain14 = dataReader[23].ToString();
                    res.embasex14 = dataReader[24].ToString();
                    res.dun14 = dataReader[25].ToString();
                    res.lotegti = dataReader[26].ToString();
                    res.nomfrut = dataReader[27].ToString();
                    res.comfrut = dataReader[28].ToString();
                    res.provfrut = dataReader[29].ToString();
                    res.cspfrut = dataReader[30].ToString();
                    res.idpfrut = dataReader[31].ToString();
                    res.fdafrut = dataReader[32].ToString();
                    res.kilos = dataReader[33].ToString();
                    res.diametro = dataReader[34].ToString();
                    res.codma = dataReader[35].ToString();
                    res.codmakilos = dataReader[36].ToString();
                    res.nlote = dataReader[37].ToString();
                    res.fecha1 = dataReader[38].ToString();
                    res.fecha2 = dataReader[39].ToString();
                    res.voickb = dataReader[40].ToString();
                    res.voicka = dataReader[41].ToString();
                    res.salida = dataReader[42].ToString();
                    res.turno = dataReader[43].ToString();
                    res.lpack = dataReader[44].ToString();
                    res.tipoembalaje = dataReader[45].ToString();
                    res.variedad_val = dataReader[46].ToString();
                    res.calidad = dataReader[47].ToString();
                    res.tipo_frio = dataReader[48].ToString();
                    res.envaein14IMP = dataReader[49].ToString();
                    res.upc = dataReader[50].ToString();
                    res.ean13 = dataReader[51].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();
        }
    }
     public class responce_consulta_etiqueta
    {
        public String id;
        public String id_zpl;
        public String ip_pantalla;
        public String linea_zpl;
        public String fila_zpl;
        public String pantalla_zpl;
        public String pantalla;
        public String centro;
        public String zpl;
        public String especie;
        public String variedad;
        public String grsmunit;
        public String countapp;
        public String calibre;
        public String glosalibre;
        public String productor;
        public String gglote;
        public String compprod;
        public String proproduc;
        public String prodesc;
        public String csg;
        public String idg;
        public String sdp;
        public String envain14;
        public String embasex14;
        public String dun14;
        public String lotegti;
        public String nomfrut;
        public String comfrut;
        public String provfrut;
        public String cspfrut;
        public String idpfrut;
        public String fdafrut;
        public String kilos;
        public String diametro;
        public String codma;
        public String codmakilos;
        public String nlote;
        public String fecha1;
        public String fecha2;
        public String voickb;
        public String voicka;
        public String salida;
        public String turno;
        public String lpack;
        public String tipoembalaje;
        public String variedad_val;
        public String calidad;
        public String tipo_frio;
        public String envaein14IMP;
        public String upc;
        public String ean13;

    }
    public class request_consulta_etiqueta
    {
       public String centro;
    }
}
