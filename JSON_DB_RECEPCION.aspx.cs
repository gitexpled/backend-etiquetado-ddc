﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace rfcBaika
{
    public partial class JSON_DB_RECEPCION : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String dataGranel = (Request["dataGranel"] != null) ? Request["dataGranel"].ToString() : "";
            String proceso = (Request["proceso"] != null) ? Request["proceso"].ToString() : "";
            String guia = (Request["guia"] != null) ? Request["guia"].ToString() : "";
            String patente = (Request["patente"] != null) ? Request["patente"].ToString() : "";
            String centro = (Request["centro"] != null) ? Request["centro"].ToString() : "";
            String DatosGen = (Request["dato"] != null) ? Request["dato"].ToString() : "";
            String especie = (Request["especie"] != null) ? Request["especie"].ToString() : "";
            string result = "";
            if (proceso == "nuevaRecepcion")
            {
                deleteRecepcion(guia, patente, centro, especie);
                result = crearRecepcion(guia, patente, centro, especie, dataGranel, DatosGen);
            }
            if (proceso == "deleteRecepcion")
            {
                deleteRecepcion(guia, patente, centro, especie);
                result = "{\"result\":0,\"message\":\"Recepcion Eliminada Correctamente\"}";
            }
            if (proceso == "listaRecepcion")
            {
                result = getListaRecepcion(centro, especie);
            }

            var json2 = "";//new JavaScriptSerializer().Serialize(obj);
            json.Text = result;

        }
        [WebMethod]
        public static string GetParametro(string dataGranel, string proceso, string guia, string patente, string centro, string dato, string especie)
        {
            string result = "";
            JSON_DB_RECEPCION dr = new JSON_DB_RECEPCION();
            if (proceso == "nuevaRecepcion")
            {
                dr.deleteRecepcion(guia, patente, centro, especie);
                result = dr.crearRecepcion(guia, patente, centro, especie, dataGranel, dato);
            }
            if (proceso == "deleteRecepcion")
            {
                dr.deleteRecepcion(guia, patente, centro, especie);
                result = "{\"result\":0,\"message\":\"Recepcion Eliminada Correctamente\"}";
            }
            if (proceso == "listaRecepcion")
            {
                result = dr.getListaRecepcion(centro, especie);
            }
            return result;
        }
        public string getListaRecepcion(string centro, string especie)
        {
            string lista = "[";
            String _connectionStringd = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connectiond = new SqlConnection(_connectionStringd);
            connectiond.Open();
            String sql2 = "select TOP 50 * from [recepciones] where centro ='" + centro + "' and especie ='" + especie + "' and estado = 'VIGENTE' order by id desc";
            SqlCommand cmd2 = new SqlCommand(sql2, connectiond);
            cmd2.Connection = connectiond;
            cmd2.CommandTimeout = 0;
            SqlDataReader dataReader = cmd2.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    string data= "[]";
                    if (dataReader[6].ToString() != "")
                    {
                        data = dataReader[6].ToString();
                    }
                    lista += "{\"guia\":\"" + dataReader[1].ToString() + "\",";
                    lista += "\"patente\":\"" + dataReader[2].ToString() + "\",";
                    lista += "\"dataGranel\":" + dataReader[3].ToString() + ",";
                    lista += "\"centro\":\"" + dataReader[4].ToString() + "\",";
                    lista += "\"especie\":\"" + dataReader[5].ToString() + "\",";
                    lista += "\"datosCer\":" + data + "}";
                    lista += ",";
                }
            }
            lista += "]";
            lista = lista.Replace(",]", "]");
            cmd2.Dispose();
            connectiond.Dispose();
            connectiond.Close();
            return lista;
        }
        public int deleteRecepcion(string guia, string patente, string centro, string especie)
        {
            String _connectionStringd = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connectiond = new SqlConnection(_connectionStringd);
            connectiond.Open();
            //String sql2 = "delete from [recepciones] where guia='" + guia + "' and patente ='" + patente + "' and centro='" + centro + "' and especie='" + especie + "'";
            String sql2 = "UPDATE recepciones SET estado= 'CERRADO' where guia='" + guia + "' and patente ='" + patente + "' and centro='" + centro + "' and especie='" + especie + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, connectiond);
            cmd2.Connection = connectiond;
            cmd2.CommandTimeout = 0;
            SqlDataReader dataReader2 = cmd2.ExecuteReader();
            cmd2.Dispose();
            connectiond.Dispose();
            connectiond.Close();
            return 0;
        }
        public string crearRecepcion(string guia, string patente, string centro, string especie, string dataGranel, string DatosGen)
        {
            string resp = "";
            if (deleteOption(guia, patente, centro, especie))
            {
                String _connectionStringd = ConfigurationManager.ConnectionStrings["CS"].ToString();
                SqlConnection connectiond = new SqlConnection(_connectionStringd);
                connectiond.Open();
                String sql2 = "insert into [recepciones](guia,patente,dataGranel,centro,especie,datosCer,estado)values('" + guia + "','" + patente + "','" + dataGranel + "','" + centro + "','" + especie + "','" + DatosGen + "','VIGENTE')";
                SqlCommand cmd2 = new SqlCommand(sql2, connectiond);
                cmd2.Connection = connectiond;
                cmd2.CommandTimeout = 0;
                SqlDataReader dataReader2 = cmd2.ExecuteReader();
                cmd2.Dispose();
                connectiond.Dispose();
                connectiond.Close();
                resp =  "{\"result\":0,\"message\":\"Recepcion Guardada Correctamente\"}";
            }

            return resp;            
        }
        public bool deleteOption(string guia, string patente, string centro, string especie)
        {
            String _connectionStringd = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connectiond = new SqlConnection(_connectionStringd);
            connectiond.Open();
            String sql2 = "delete from [recepciones] where guia='" + guia + "' and patente ='" + patente + "' and centro='" + centro + "' and especie='" + especie + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, connectiond);
            cmd2.Connection = connectiond;
            cmd2.CommandTimeout = 0;
            SqlDataReader dataReader2 = cmd2.ExecuteReader();
            cmd2.Dispose();
            connectiond.Dispose();
            connectiond.Close();
            return true;
        }
    }
}