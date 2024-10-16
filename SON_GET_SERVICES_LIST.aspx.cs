using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data.SqlClient;

namespace rfcBaika
{
    public partial class SON_GET_SERVICES_LIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var json2 = ToJSON(getServicios());//new JavaScriptSerializer().Serialize(obj);
            json.Text = json2.ToString();

        }
        public static string ToJSON( object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJSON( object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }

        public static List<Item> getServicios () { 
        
            responce_DB_LOGIN res = new responce_DB_LOGIN();
            String _connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            String sql = "select top 100 * from logws order by 1 desc";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            Int16 i = 0;
            //Read the data and store them in the list
            List<Item> items = new List<Item> { };
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    items.Add(new Item
                    {
                        idlog = dataReader[0].ToString(),
                        tipo = dataReader[1].ToString(),
                        fecha = dataReader[2].ToString(),
                        ingreso = dataReader[3].ToString(),
                        salida = dataReader[4].ToString(),
                    });
                    
                }
            }
            connection.Dispose();
            connection.Close();
            

            return items;
        }
    }


    public class Item
    {
        public string idlog { get; set; }
        public string tipo { get; set; }
        public string fecha { get; set; }
        public string ingreso { get; set; }
        public string salida { get; set; }
    }
}