<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="AdmUsuarios.aspx.cs" Inherits="oblig2web.AdmUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <h1>Lista de Administradores</h1>
    <br />
    <asp:Label ID="LblMensaje1" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GVWAdmin" runat="server" Width="100%">
        <RowStyle HorizontalAlign="Center" />
</asp:GridView>
    <br />
    <br />
    <h1>Lista de Organizadores</h1>
    <br />
    <asp:Label ID="LblMensaje2" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GVWOrg" runat="server" Width="100%">
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <br />
</asp:Content>
