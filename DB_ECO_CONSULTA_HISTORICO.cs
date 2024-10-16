using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public class DB_ECO_CONSULTA_HISTORICO
    {
        public Array run(request_ECO_CONSULTA_HISTORICO datos)
        {
            List<responce_ECO_CONSULTA_HISTORICO> List = new List<responce_ECO_CONSULTA_HISTORICO>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            String sql = "";
            connection.Open();
            if(datos.CENTRO == "0" && datos.ESPECIE == "0" && datos.PRODUCTOR == "0")
            {
                sql = "Select * from ECO_ANUAL where usuario = '"+datos.USUARIO+"'";
            }
            else{
                sql = "Select centro,centro,usuario,productor,especie,variedad,variedad,nombre,estado,";
                sql += "sum(s1),sum(s2),sum(s3),sum(s4),sum(s5),sum(s6),sum(s7),sum(s8),sum(s9),sum(s10),";
                sql += "sum(s11),sum(s12),sum(s13),sum(s14),sum(s15),sum(s16),sum(s17),sum(s18),sum(s19),sum(s20),";
                sql += "sum(s21),sum(s22),sum(s23),sum(s24),sum(s25),sum(s26),sum(s27),sum(s28),sum(s29),sum(s30),";
                sql += "sum(s31),sum(s32),sum(s33),sum(s34),sum(s35),sum(s36),sum(s37),sum(s38),sum(s39),sum(s40),";
                sql += "sum(s41),sum(s42),sum(s43),sum(s44),sum(s45),sum(s46),sum(s47),sum(s48),sum(s49),sum(s50),";
                sql += "sum(s51),sum(s52),";
                sql += "tipo,ano ";
                sql += " from ECO_ANUAL where centro = '" + datos.CENTRO + "' and productor='" + datos.PRODUCTOR + "' and Especie= '" + datos.ESPECIE + "' and variedad = '"+ datos.VARIEDAD +"' and estado = 'HISTORICO' and tipo = 'ANUAL'";
                sql += " group by centro,usuario,productor,especie,variedad,nombre,estado,tipo,ano";
            }
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
                    responce_ECO_CONSULTA_HISTORICO res = new responce_ECO_CONSULTA_HISTORICO();
                    res.id = dataReader[0].ToString();
                    res.centro = dataReader[1].ToString();
                    res.usuario = dataReader[2].ToString();
                    res.productor = dataReader[3].ToString();
                    res.especie = dataReader[4].ToString();
                    res.variedad = dataReader[5].ToString();
                    res.fecha = dataReader[6].ToString();
                    res.Nombre = dataReader[7].ToString();
                    res.Estado = dataReader[8].ToString();
                    res.s1 = dataReader[9].ToString();
                    res.s2 = dataReader[10].ToString();
                    res.s3 = dataReader[11].ToString();
                    res.s4 = dataReader[12].ToString();
                    res.s5 = dataReader[13].ToString();
                    res.s6 = dataReader[14].ToString();
                    res.s7 = dataReader[15].ToString();
                    res.s8 = dataReader[16].ToString();
                    res.s9 = dataReader[17].ToString();
                    res.s10 = dataReader[18].ToString();
                    res.s11 = dataReader[19].ToString();
                    res.s12 = dataReader[20].ToString();
                    res.s13 = dataReader[21].ToString();
                    res.s14 = dataReader[22].ToString();
                    res.s15 = dataReader[23].ToString();
                    res.s16 = dataReader[24].ToString();
                    res.s17 = dataReader[25].ToString();
                    res.s18 = dataReader[26].ToString();
                    res.s19 = dataReader[27].ToString();
                    res.s20 = dataReader[28].ToString();
                    res.s21 = dataReader[29].ToString();
                    res.s22 = dataReader[30].ToString();
                    res.s23 = dataReader[31].ToString();
                    res.s24 = dataReader[32].ToString();
                    res.s25 = dataReader[33].ToString();
                    res.s26 = dataReader[34].ToString();
                    res.s27 = dataReader[35].ToString();
                    res.s28 = dataReader[36].ToString();
                    res.s29 = dataReader[37].ToString();
                    res.s30 = dataReader[38].ToString();
                    res.s31 = dataReader[39].ToString();
                    res.s32 = dataReader[40].ToString();
                    res.s33 = dataReader[41].ToString();
                    res.s34 = dataReader[42].ToString();
                    res.s35 = dataReader[43].ToString();
                    res.s36 = dataReader[44].ToString();
                    res.s37 = dataReader[45].ToString();
                    res.s38 = dataReader[46].ToString();
                    res.s39 = dataReader[47].ToString();
                    res.s40 = dataReader[48].ToString();
                    res.s41 = dataReader[49].ToString();
                    res.s42 = dataReader[50].ToString();
                    res.s43 = dataReader[51].ToString();
                    res.s44 = dataReader[52].ToString();
                    res.s45 = dataReader[53].ToString();
                    res.s46 = dataReader[54].ToString();
                    res.s47 = dataReader[55].ToString();
                    res.s48 = dataReader[56].ToString();
                    res.s49 = dataReader[57].ToString();
                    res.s50 = dataReader[58].ToString();
                    res.s51 = dataReader[59].ToString();
                    res.s52 = dataReader[60].ToString();
                    res.Tipo = dataReader[61].ToString();
                    res.Ano = dataReader[62].ToString();
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
    }
    public class request_ECO_CONSULTA_HISTORICO
    {
        public String CENTRO;
        public String PRODUCTOR;
        public String ESPECIE;
        public String USUARIO;
        public String VARIEDAD;
    }
    public class responce_ECO_CONSULTA_HISTORICO
    {
        public String centro;
        public String usuario;
        public String productor;
        public String especie;
        public String variedad;
        public String fecha;
        public String s1;
        public String s2;
        public String s3;
        public String s4;
        public String s5;
        public String s6;
        public String s7;
        public String s8;
        public String s9;
        public String s10;
        public String s11;
        public String s12;
        public String s13;
        public String s14;
        public String s15;
        public String s16;
        public String s17;
        public String s18;
        public String s19;
        public String s20;
        public String s21;
        public String s22;
        public String s23;
        public String s24;
        public String s25;
        public String s26;
        public String s27;
        public String s28;
        public String s29;
        public String s30;
        public String s31;
        public String s32;
        public String s33;
        public String s34;
        public String s35;
        public String s36;
        public String s37;
        public String s38;
        public String s39;
        public String s40;
        public String s41;
        public String s42;
        public String s43;
        public String s44;
        public String s45;
        public String s46;
        public String s47;
        public String s48;
        public String s49;
        public String s50;
        public String s51;
        public String s52;
        public String Nombre;
        public String Estado;
        public String id;
        public String Tipo;
        public String Ano;

    }
}