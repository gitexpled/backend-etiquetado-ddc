using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;

namespace rfcBaika
{
    public class DB_execSp
    {
        public JObject run(String datos)
        {
            CultureInfo culture = new CultureInfo("es-CL");
            //responce_etiqueta res = new responce_etiqueta();
            String _connectionString = ConfigurationManager.ConnectionStrings["CSPORTAL"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            //String jss = datos;
            //String jss = Request["object"].ToString();
            JObject root = JObject.Parse(datos);
            JObject res = new JObject();
            JArray data = new JArray();
            JObject p = (JObject)root["params"];
            string sp = (string)root["sp"];
            String sql = "";
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = connection;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                sql += "EXEC " + sp + " ";
                int c = 0;
                List<String> titulos = new List<String>();
                cmd = new SqlCommand(sp, connection);
                
                foreach (var x in p)
                {
                    string name = x.Key;
                    JToken value = x.Value;
                    if (IsNumeric(value.ToString()) == true)
                    {
                        decimal d = decimal.Parse(value.ToString(), culture);
                        cmd.Parameters.Add(new SqlParameter("@" + name, decimal.Parse(value.ToString(), culture)));
                        sql += c != 0 ? ", @" + name + " = " + d : "@" + name + " = " + d.ToString();
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@" + name, value.ToString()));
                        sql += c != 0 ? ", @" + name + " = '" + value.ToString() + "'" : "@" + name + " = '" + value.ToString() + "'";
                    }
                    
                    //cmd.Parameters.Add(new SqlParameter("@" + name, value.ToString()));
                    c++;
                }
                //cmd = new SqlCommand(sql, connection);
                
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable schemaTable = dr.GetSchemaTable();
                string columns = "";
                foreach (DataRow row in schemaTable.Rows)
                {
                    columns = row[0].ToString();
                    titulos.Add(columns);
                }
                while (dr.Read())
                {
                    JObject e = new JObject();
                    foreach (String aPart in titulos)
                    {
                        e.Add(aPart, dr.GetValue(dr.GetOrdinal(aPart)).ToString());
                    }
                    data.Add(e);
                }
                res.Add("error", 0);
                res.Add("message", "Ok");
                res.Add("data", data);
                res.Add("sql", sql);
            }
            catch (Exception e)
            {
                res.Add("error", 1);
                res.Add("message", e.Message);
                res.Add("printStack", e.ToString());
                res.Add("sql", sql);
            }
            connection.Close();
            connection.Dispose();
            return res; 
            //return res.ToString().Replace("\r\n", "").Replace(@"\", ""); 

        }
        public bool getVariableType(String value) {
            bool o = true;
            float number;
            if (float.TryParse(value, out number))
            {
                o = true;
            }
            else
            {
                o = false;
            }
            return o;
        }
        static bool IsNumeric(string input)
        {
            CultureInfo culture = new CultureInfo("es-CL");

            // Verificar si la cadena contiene algún caracter que no sea dígito o punto
            int cou = 0;
            for (int i = 0; i < input.Length; i++) {
                if(input[i] == '.'){
                    cou++;
                }
            }
            if (cou > 1) {
                return false;
            }

                try
                {
                    decimal.Parse(input, culture);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
        }
        public bool EsNumeroDecimal(string valor)
        {
            // Intentar convertir el valor a decimal
            decimal resultado;
            if (decimal.TryParse(valor, out  resultado))
            {
                return true; // El valor es numérico
            }

            // Si el valor contiene un punto y no es el último carácter
            if (valor.Contains(".") && valor.IndexOf(".") < valor.Length - 1)
            {
                return false; // El valor es decimal pero no es el último carácter
            }

            return false; // El valor no es numérico ni decimal
        }
    }
}