﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bajausuario.aspx.cs" Inherits="adm1.bajausuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Baja de Usuarios</h1>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
            Nombre: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Borrar" OnClick="Button1_Click" /><br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" Text="Volver a la Página Principal"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
