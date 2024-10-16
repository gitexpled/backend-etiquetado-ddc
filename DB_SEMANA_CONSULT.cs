using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace rfcBaika
{
    public class DB_SEMANA_CONSULT
    {
        public Array run(request_SEMANA_CONSULT datos)
        {
            List<responce_SEMANA_CONSULT> List = new List<responce_SEMANA_CONSULT>();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            String sql = "";
            connection.Open();
            int s2 = 0;
            if (datos.SEMANA != "") {
                if (datos.SEMANA == "52")
                {
                    s2 = 1;  
                }
                else
                {
                    s2 = Convert.ToInt32(datos.SEMANA) + 1;
                }
            }
            if (datos.CENTRO == "0" && datos.ESPECIE == "0" && datos.PRODUCTOR == "0")
            {
                sql = "Select DD.*, EA.Nombre, EA.ano, EA.variedad  from eco_detalle_dia DD RIGHT JOIN ECO_ANUAL EA ON DD.ID_ANUAL = EA.ID";
                sql += " where (editado in ('" + datos.SEMANA + "','" + s2 + "') OR '" + datos.SEMANA + "' = '' ) order by semana";
            }
            else
            {
                if (datos.VARIEDAD != "")
                {
                    sql = "Select DD.*, EA.Nombre, EA.ano, EA.variedad  from eco_detalle_dia DD RIGHT JOIN ECO_ANUAL EA ON DD.ID_ANUAL = EA.ID where  EA.productor='" + datos.PRODUCTOR + "' and EA.Especie= '" + datos.ESPECIE + "'and EA.Variedad= '" + datos.VARIEDAD + "' and editado = '" + datos.SEMANA + "'  and EA.estado = 'ACTIVO' and EA.tipo = 'ANUAL' order by semana";
                }
                else
                {
                    sql = "Select DD.*, EA.Nombre, EA.ano, EA.variedad  from eco_detalle_dia DD RIGHT JOIN ECO_ANUAL EA ";
                    sql += " ON DD.ID_ANUAL = EA.ID where EA.productor='" + datos.PRODUCTOR;
                    sql += "' and EA.Especie= '" + datos.ESPECIE + "'  and EA.estado = 'ACTIVO' AND ea.usuario = '"+datos.USUARIO+"' and EA.tipo = 'ANUAL'";
                    sql += " and (editado = '" + datos.SEMANA + "' OR '" + datos.SEMANA + "' = '' ) order by semana";
                
                }
            }
            Console.WriteLine(sql);
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
                    responce_SEMANA_CONSULT res = new responce_SEMANA_CONSULT();
                    res.semana = dataReader[1].ToString();
                    res.lunes = dataReader[2].ToString();
                    res.martes = dataReader[3].ToString();
                    res.miercoles = dataReader[4].ToString();
                    res.jueves = dataReader[5].ToString();
                    res.viernes = dataReader[6].ToString();
                    res.sabado = dataReader[7].ToString();
                    res.domingo = dataReader[8].ToString();
                    res.total = dataReader[9].ToString();
                    res.idanual = dataReader[10].ToString();
                    res.Nombre = dataReader[12].ToString();
                    res.Ano = dataReader[13].ToString();
                    res.variedad = dataReader[14].ToString(); 
                    List.Add(res);
                }
            }
            connection.Close();
            connection.Dispose();
            cmd.Dispose();
            return List.ToArray();

        }
    }
    public class request_SEMANA_CONSULT
    {
        public String CENTRO;
        public String PRODUCTOR;
        public String ESPECIE;
        public String USUARIO;
        public String VARIEDAD;
        public String SEMANA;
    }
    public class responce_SEMANA_CONSULT
    {
       /* public String centro;
        public String usuario;
        public String productor;
        public String especie;
        public String variedad;
        public String fecha;*/
        public String semana;
        public String lunes;
        public String martes;
        public String miercoles;
        public String jueves;
        public String viernes;
        public String sabado;
        public String domingo;
        public String total;
        public String idanual;
        public String Nombre;
        public String Ano;
        public String variedad;
        /*public String s10;
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
        public String Tipo;*/

    }
}