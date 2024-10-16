<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createRFC.aspx.cs" Inherits="rfcBaika.createRFC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" Width="1125px"></asp:TextBox>
        <br />
        parametros de ingreso 
        Structuras<br />
        <asp:TextBox ID="TextBox2" runat="server" Width="1125px"></asp:TextBox>
        <br />
         parametros de ingreso 
        Tablas<br />
        <asp:TextBox ID="TextBox5" runat="server" Width="1125px"></asp:TextBox>
      
        
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" /><br />
        metadata RFC<br />
        <asp:TextBox ID="TextBox3" runat="server" Height="293px" TextMode="MultiLine" 
            Width="1129px"></asp:TextBox>
        <br />
        <br />
        Clase RFC<br />
        <asp:TextBox ID="TextBox4" runat="server" Height="384px" TextMode="MultiLine" 
            Width="1125px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
