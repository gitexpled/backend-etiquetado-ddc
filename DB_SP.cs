using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;

namespace rfcBaika
{
    public class DB_SP
    {
        public responce_db_sp run(HttpRequest Request)
        {
            responce_db_sp response = new responce_db_sp();
            JObject res = new JObject();

            JObject p = (JObject)Request["PARAMS"];
            JObject json = JObject.Parse(Request.ToString());
            //JObject p = JObject.Parse(json.GetValue("PARAMS").ToString());
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            char pc = ';';
            char pc2 = '=';
            String[] b = _connectionString.Split(pc);
            String cat = b[1].Split(pc2)[1];

            connection.Open();
            JArray array = new JArray();
            JObject item;
            String sql = "";
            List<string> col = new List<string>();
            List<string> par = new List<string>();
            // JToken jtoken;
            //for (int i = 0; i < items.Count; i++) //loop through rows
            //{
                //item = (JObject)items[i];
                try
                {
                    String sqlP = "SELECT *FROM INFORMATION_SCHEMA.PARAMETERS where SPECIFIC_NAME = '" + json.GetValue("SP") + "' AND SPECIFIC_CATALOG = '" + cat + "'";
                    SqlCommand cmd = new SqlCommand(sqlP, connection);
                    cmd.Connection = connection;
                    cmd.CommandTimeout = 0;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            string param = dataReader.GetValue(dataReader.GetOrdinal("PARAMETER_NAME")).ToString();
                            par.Add(param);
                        }
                    }
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = connection;
                    SqlCommand cmdSp = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmdSp = new SqlCommand(json.GetValue("SP").ToString(), connection);
                    for (int e = 0; e < par.Count; e++)
                    {
                        cmdSp.Parameters.Add(new SqlParameter(par[e], p.GetValue(par[e])));
                    }
                    cmdSp.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmdSp.ExecuteReader();
                    DataTable dt = dr.GetSchemaTable();
                    int c = dt.Columns.Count;
                    for (int ix = 0; ix <= c; ix++)
                    {
                        DataColumn column = dt.Columns[ix];
                        string typeOfColumn = column.DataType.Name;
                        col.Add(typeOfColumn);
                    }
                    if (dr.Read())
                    {
                        JObject ob = new JObject();
                        for (int e = 0; e < col.Count; e++)
                        {
                            ob.Add(dr.GetValue(dr.GetOrdinal(col[e])));
                        }
                        array.Add(ob);

                    }
                    res.Add("data", array);
                    res.Add("message", "ok");
                    res.Add("error", 0);
                    response.json = res.ToString(Newtonsoft.Json.Formatting.None);
                }
                catch (Exception e)
                {
                    res.Add("data", array);
                    res.Add("message", e.Message);
                    res.Add("error", 1);
                    response.json = res.ToString(Newtonsoft.Json.Formatting.None);
                }

            //}
            connection.Close();
            connection.Dispose();
            return response;

        }
    }
    public class responce_db_sp
    {
        public String json;

    }
}