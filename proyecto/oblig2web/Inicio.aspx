
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="oblig2web.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/estilos.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <img src="img/header.jpg" width="100%" />
    <form id="form1" runat="server">
    <div style="width: 400px; margin-left: auto; margin-right:auto;">
        <br />
        <br />
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" Height="158px" Width="380px">
        </asp:Login>
        <br />
        <asp:LinkButton ID="LnkRegistrarme" runat="server" PostBackUrl="~/RegOrganizador.aspx">Registrarme como Organizador</asp:LinkButton>
    </div>
    </form>
    <br />
    <p>Administrador: admin@eventos17.com - Admin!99</p>
    <p>Organizador: org@eventos17.com - Org!9999</p>
    <br /><br />
    <div>
        <hr />
        <p>Santiago C - Programación 2 Agosto 2017 - Analista Programador ORT.</p>
        <p>Sistema de gestión en  ASP.NET / C# / Visual Studio. </p>
        <hr />
    </div>
</body>
</html>
