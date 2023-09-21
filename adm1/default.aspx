<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="adm1._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <h1>Bienvenido a la Administración de Usuarios</h1>
            <ul>
                <li><a href="altausuario.aspx">Alta de Usuarios</a></li>
                <li><a href="bajausuario.aspx">Baja de Usuarios</a></li>
                <li><a href="modificacionusuario.aspx">Modificación de Usuarios</a></li>
                <li><a href="consultausuario.aspx">Consulta de Usuarios</a></li>
            </ul>
        </div>
    </form>
</body>
</html>
