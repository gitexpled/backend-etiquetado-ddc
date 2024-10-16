using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAP.Middleware.Connector;
using System.Data;
using System.Collections;

namespace rfcBaika
{
    public partial class createRFC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TextBox1.Text = "ZXPI_RECEPCION_BULK";

        }
        private string getType(RfcDataType t)
        {
            String tipo = "String";
            switch (t)
            {
                case RfcDataType.CHAR: tipo = "String"; break;
                case RfcDataType.STRING: tipo = "String"; break;
                case RfcDataType.NUM: tipo = "Int32"; break;
                case RfcDataType.DATE: tipo = "String"; break;
                case RfcDataType.BCD: tipo = "Decimal"; break;
                case RfcDataType.INT1: tipo = "Byte"; break;
                case RfcDataType.INT2: tipo = "Int16"; break;
                case RfcDataType.INT4: tipo = "Int32"; break;
                case RfcDataType.FLOAT: tipo = "Double"; break;

            }
            return "public " + tipo;
        }
        private string getType2(RfcDataType t)
        {
            String tipo = "String";
            switch (t)
            {
                case RfcDataType.CHAR: tipo = "String"; break;
                case RfcDataType.STRING: tipo = "String"; break;
                case RfcDataType.NUM: tipo = "Int32"; break;
                case RfcDataType.DATE: tipo = "String"; break;
                case RfcDataType.BCD: tipo = "Decimal"; break;
                case RfcDataType.INT1: tipo = "Byte"; break;
                case RfcDataType.INT2: tipo = "Int16"; break;
                case RfcDataType.INT4: tipo = "Int32"; break;
                case RfcDataType.FLOAT: tipo = "Double"; break;

            }
            return  tipo;
        } 

        protected void Button1_Click(object sender, EventArgs e)
        {



            try
            {
                Hashtable ht = new Hashtable();
                Hashtable htT = new Hashtable();
               
                if (TextBox2.Text.Length > 0)
                {
                    String[] strTemp = TextBox2.Text.Split(':');
                    int i=0;
                    for (i = 0; i < strTemp.Length; i++ )
                    {
                        if (strTemp[i].Length > 0)
                        {
                            String structura = strTemp[i].Split(';')[0];
                            String cam = strTemp[i].Split(';')[1];
                            String[] campos = cam.Split(',');
                            ht[structura] = campos;
                        }
                    }

                }
                if (TextBox5.Text.Length > 0)
                {
                    String[] strTemp = TextBox5.Text.Split(':');
                    int i = 0;
                    for (i = 0; i < strTemp.Length; i++)
                    {
                        if (strTemp[i].Length > 0)
                        {
                            String structura = strTemp[i].Split(';')[0];
                           
                            htT[structura] = "tabla";
                        }
                    }

                }

                RfcDestination configSap = RfcDestinationManager.GetDestination("DDC");
                RfcRepository SapRfcRepository = configSap.Repository;
                TextBox1.Text = TextBox1.Text.Trim();
                IRfcFunction rfcFunction = SapRfcRepository.CreateFunction(TextBox1.Text.Trim());

                String strClass = "public class request_" + TextBox1.Text + "\n{\n";
                String strClassStruck = "";

                String strMetodo = "public class " + TextBox1.Text + "\n{\n";

                strMetodo += "public responce_" + TextBox1.Text + " sapRun(request_" + TextBox1.Text + " import)\n{\n";
                strMetodo += "RfcDestination configSap = RfcDestinationManager.GetDestination(\"DDC\");\n";
                strMetodo += "RfcRepository SapRfcRepository = configSap.Repository;\n";
                strMetodo += "IRfcFunction rfcFunction = SapRfcRepository.CreateFunction(\"" + TextBox1.Text.Trim() + "\");\n";
                strMetodo += "\n";
                String todoTexto=rfcFunction.ToString();

                string text = "ELEMENTOS DE IMPORT \n\n";
                for (int element = 0; element < rfcFunction.ElementCount; element++)
                {

                    RfcElementMetadata metadata = rfcFunction.GetElementMetadata(element);
                    String nombreABP = "";
                    if (metadata.DataType.ToString() == "STRUCTURE")
                    {
                        nombreABP = rfcFunction.Metadata[element].ValueMetadataAsStructureMetadata.Name;
                    }

                    text += rfcFunction.Metadata[element].Direction + ", " + metadata.Name + "," + metadata.DataType.ToString() + "," + nombreABP + "\n";
                    String strTemp = "";
                    if (nombreABP.Length > 0)
                    {
                        if (ht[nombreABP] != null)
                        {
                            strClassStruck += "public class " + TextBox1.Text + "_" + metadata.Name + "\n{\n";
                            String nombre = rfcFunction.Metadata[element].ValueMetadataAsStructureMetadata.Name;
                            RfcStructureMetadata obj = SapRfcRepository.GetStructureMetadata(nombre);
                            strMetodo += "RfcStructureMetadata obj_" + nombre + " = SapRfcRepository.GetStructureMetadata(\"" + nombre + "\");\n";
                            IRfcStructure datos = obj.CreateStructure();
                            strMetodo += "IRfcStructure datos_" + nombre + " = obj_" + nombre + ".CreateStructure();\n";

                            String[] campos = (String[])ht[nombreABP];
                            for (int i = 0; i < obj.FieldCount; i++)
                            {
                                int j=0;
                                for (j = 0; j < campos.Length; j++)
                                {
                                    RfcElementMetadata field = obj[i];
                                    if (campos[j] == field.Name)
                                    {
                                        
                                        text += "       " + field.Name + "," + field.DataType.ToString() + "\n";
                                        strClassStruck += getType(field.DataType) + " " + field.Name + ";\n";
                                        strMetodo += "datos_" + nombre + ".SetValue(\"" + field.Name + "\", import." + metadata.Name + "." + field.Name + ");\n";
                                    }
                                }

                            }
                            strMetodo += "rfcFunction.SetValue(\"" + metadata.Name + "\", datos_" + nombre + ");\n";
                            rfcFunction.SetValue(metadata.Name, datos);
                            strClassStruck += "}\n";
                            strClass += "public " + TextBox1.Text + "_" + metadata.Name + " " + metadata.Name + ";\n";
                        }
                      
                    }
                    


                    if (rfcFunction.Metadata[element].Direction.ToString() == "IMPORT")
                    {

                        if (metadata.DataType.ToString() == "STRUCTURE")
                        {
                            strClassStruck += "public class " + TextBox1.Text + "_" + metadata.Name + "\n{\n";

                            String nombre = rfcFunction.Metadata[element].ValueMetadataAsStructureMetadata.Name;
                            RfcStructureMetadata obj = SapRfcRepository.GetStructureMetadata(nombre);
                            strMetodo += "RfcStructureMetadata obj_" + nombre + " = SapRfcRepository.GetStructureMetadata(\"" + nombre + "\");\n";
                            IRfcStructure datos = obj.CreateStructure();
                            strMetodo += "IRfcStructure datos_" + nombre + " = obj_" + nombre + ".CreateStructure();\n";
                            for (int i = 0; i < obj.FieldCount; i++)
                            {

                                RfcElementMetadata field = obj[i];
                                text += "       " + field.Name + "," + field.DataType.ToString() + "\n";
                                strClassStruck += getType(field.DataType) + " " + field.Name + ";\n";
                                strMetodo += "datos_" + nombre + ".SetValue(\"" + field.Name + "\", import." + metadata.Name + "." + field.Name + ");\n";
                                switch (field.DataType)
                                {

                                    case RfcDataType.DATE:
                                        datos.SetValue(field.Name, DateTime.Now);
                                        break;
                                    case RfcDataType.INT4:
                                        int num2 = 1;
                                        datos.SetValue(field.Name, num2);
                                        break;
                                    case RfcDataType.BCD:
                                        Decimal num = 1.2m;
                                       // datos.SetValue(field.Name, num);
                                        break;
                                    case RfcDataType.CHAR:

                                        datos.SetValue(field.Name, "1");
                                        break;
                                    default:
                                       // datos.SetValue(field.Name, "char");
                                        break;

                                }

                            }
                            strMetodo += "rfcFunction.SetValue(\"" + metadata.Name + "\", datos_" + nombre + ");\n";
                            rfcFunction.SetValue(metadata.Name, datos);
                            strClassStruck += "}\n";
                            strClass += "public " + TextBox1.Text + "_" + metadata.Name + " " + metadata.Name + ";\n";

                        }
                        else
                        {
                            strClass += getType(metadata.DataType) + " " + metadata.Name + ";\n";
                            strMetodo += "rfcFunction.SetValue(\"" + metadata.Name + "\", import." + metadata.Name + ");\n";
                         /*   switch (metadata.DataType)
                            {
                                case RfcDataType.DATE:
                                    rfcFunction.SetValue(metadata.Name, DateTime.Now);
                                    break;
                                case RfcDataType.INT4:
                                    rfcFunction.SetValue(metadata.Name, 1);
                                    break;
                                default:
                                    rfcFunction.SetValue(metadata.Name, "char");
                                    break;

                            }*/
                        }



                    }
                    if (htT[metadata.Name] != null)
                    {
                        String nombre = rfcFunction.Metadata[element].ValueMetadataAsTableMetadata.LineType.Name;
                        RfcStructureMetadata obj = SapRfcRepository.GetStructureMetadata(nombre);


                        IRfcTable rfcTable = rfcFunction.GetTable(metadata.Name);
                        strMetodo += "IRfcTable rfcTable_" + metadata.Name + "_I = rfcFunction.GetTable(\"" + metadata.Name + "\");\n";

                        strMetodo += " foreach (" + TextBox1.Text + "_" + metadata.Name + " row in import." + metadata.Name + ")\n";
                        strMetodo += "{\n";
                        strMetodo += "rfcTable_" + metadata.Name + "_I.Append();\n";


                        strMetodo += TextBox1.Text + "_" + metadata.Name + " datoTabla = new " + TextBox1.Text + "_" + metadata.Name + "();\n";
                        for (int i = 0; i < obj.FieldCount; i++)
                        {

                            RfcElementMetadata tb = obj[i];
                            strMetodo += "rfcTable_" + metadata.Name + "_I.SetValue(\"" + tb.Name + "\",row." + tb.Name + ");\n";






                        }

                        strMetodo += "}\n";
                        strMetodo += "rfcFunction.SetValue(\"" + metadata.Name + "\", rfcTable_" + metadata.Name + "_I);\n";
                        
                        strClass += "public " + TextBox1.Text + "_" + metadata.Name + "[] " + metadata.Name + ";\n";
                       
                    }

                }
               
                strClass += "}\n";

                strMetodo += " rfcFunction.Invoke(configSap);\n";
              //  rfcFunction.Invoke(configSap);

                string aa = rfcFunction.ToString();
                strMetodo += "string aa = rfcFunction.ToString();\n";

                string text2 = "";

                strMetodo += "responce_" + TextBox1.Text + " res = new responce_" + TextBox1.Text + "();\n";
                strClass += "public class responce_" + TextBox1.Text + "\n{\n";
                for (int element = 0; element < rfcFunction.ElementCount; element++)
                {

                    RfcElementMetadata metadata = rfcFunction.GetElementMetadata(element);

                    //text += rfcFunction.Metadata[element].Direction + ", " + metadata.Name + "," + metadata.DataType.ToString() + "\n";

                    if (rfcFunction.Metadata[element].Direction.ToString() == "EXPORT")
                    {
                        if (metadata.DataType.ToString() == "STRUCTURE")
                        {
                        }
                        else
                        {
                            strClass += getType(metadata.DataType) + " " + metadata.Name + ";\n";
                            switch (metadata.DataType)
                            {
                                case RfcDataType.DATE:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetString(\"" + metadata.Name + "\");\n";
                                    break;
                                case RfcDataType.BCD:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetDecimal(\"" + metadata.Name + "\");\n";
                                    break;
                                case RfcDataType.CHAR:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetString(\"" + metadata.Name + "\");\n";
                                    break;
                                case RfcDataType.STRING:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetString(\"" + metadata.Name + "\");\n";
                                    break;
                                case RfcDataType.INT1:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetInt(\"" + metadata.Name + "\");\n";
                                    break;
                                case RfcDataType.INT2:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetInt(\"" + metadata.Name + "\");\n";
                                    break;
                                case RfcDataType.NUM:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetInt(\"" + metadata.Name + "\");\n";
                                    break;
                                case RfcDataType.INT4:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetInt(\"" + metadata.Name + "\");\n";
                                    break;
                                case RfcDataType.FLOAT:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetDouble(\"" + metadata.Name + "\");\n";
                                    break;
                                default:
                                    strMetodo += "res." + metadata.Name + " = rfcFunction.GetString(\"" + metadata.Name + "\");\n";
                                    break;
                            }
                        }
                    }

                    if (metadata.DataType.ToString() == "TABLE")
                    {

                        strClassStruck += "public class " + TextBox1.Text + "_" + metadata.Name + "\n{\n";
                        String nombre = rfcFunction.Metadata[element].ValueMetadataAsTableMetadata.LineType.Name;
                        RfcStructureMetadata obj = SapRfcRepository.GetStructureMetadata(nombre);


                        IRfcTable rfcTable = rfcFunction.GetTable(metadata.Name);
                        strMetodo += "IRfcTable rfcTable_" + metadata.Name + " = rfcFunction.GetTable(\"" + metadata.Name + "\");\n";
                        strMetodo += "res." + metadata.Name + " = new " + TextBox1.Text + "_" + metadata.Name + "[rfcTable_" + metadata.Name + ".RowCount];\n";
                        strMetodo += "int i_" + metadata.Name + "=0;\n";
                        strMetodo += " foreach (IRfcStructure row in rfcTable_" + metadata.Name + ")\n";
                        strMetodo += "{\n";


                        strMetodo += TextBox1.Text + "_" + metadata.Name + " datoTabla = new " + TextBox1.Text + "_" + metadata.Name + "();\n";
                        for (int i = 0; i < obj.FieldCount; i++)
                        {

                            RfcElementMetadata tb = obj[i];
                            text += tb.Name + "," + tb.DataType + "," + tb.Documentation + "," + tb.ExtendedDescription + "\r";
                            strClassStruck += getType(tb.DataType) + " " + tb.Name + ";\n";


                            switch (tb.DataType)
                            {
                                case RfcDataType.DATE:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetString(\"" + tb.Name + "\");\n";
                                    break;
                                case RfcDataType.BCD:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetDecimal(\"" + tb.Name + "\");\n";
                                    break;
                                case RfcDataType.CHAR:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetString(\"" + tb.Name + "\");\n";
                                    break;
                                case RfcDataType.STRING:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetString(\"" + tb.Name + "\");\n";
                                    break;
                                case RfcDataType.INT1:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetInt(\"" + tb.Name + "\");\n";
                                    break;
                                case RfcDataType.INT2:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetInt(\"" + tb.Name + "\");\n";
                                    break;
                                case RfcDataType.NUM:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetInt(\"" + tb.Name + "\");\n";
                                    break;
                                case RfcDataType.INT4:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetInt(\"" + tb.Name + "\");\n";
                                    break;
                                case RfcDataType.FLOAT:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetDouble(\"" + tb.Name + "\");\n";
                                    break;
                                default:
                                    strMetodo += "datoTabla." + tb.Name + " = row.GetString(\"" + tb.Name + "\");\n";
                                    break;
                            }


                        }
                        strMetodo += "res." + metadata.Name + "[i_" + metadata.Name + "] =datoTabla;";
                        strMetodo += "++i_" + metadata.Name + ";\n";

                        strMetodo += "}\n";
                        strClassStruck += "}\n";
                        strClass += "public " + TextBox1.Text + "_" + metadata.Name + "[] " + metadata.Name + ";\n";


                    }
                }
                strMetodo += "\n return res; }\n}\n";
                strClass += "}\n" + strClassStruck;

                String str = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Web;\nusing SAP.Middleware.Connector;\n\n";
                str += " namespace rfcBaika\n{";
                TextBox4.Text = str + strMetodo + strClass + "\n}";


           

                TextBox3.Text = text + "\n\n\n\n\n" + todoTexto;
            }
            catch (Exception es)
            {
                TextBox4.Text = es.Message+"\n"+es.StackTrace;
            }
        }
    }
}