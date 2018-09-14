<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="AdmMontosFijos.aspx.cs" Inherits="oblig2web.AdmMontosFijos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <h1>Cambiar Montos Fijos</h1>
    <br />
    <asp:Label ID="LblPorcAum" runat="server" Text="Porcentaje de Aumento para Eventos Premium" Width="350px"></asp:Label>
    <asp:Label ID="LblPorcAumValor" runat="server" Text="" Width="50px" Font-Bold="False" Font-Underline="True"></asp:Label>
    <asp:TextBox ID="TxtPorcAum" runat="server"></asp:TextBox>
    <asp:Button ID="BtnPorcAum" runat="server" Text="Cambiar" OnClick="BtnPorcAum_Click" />
    <br /><br />
    <asp:Label ID="LblMontFijo" runat="server" Text="Monto Fijo de Limpieza para Eventos Comunes" Width="350px"></asp:Label>
    <asp:Label ID="LblMontFijoValor" runat="server" Text="" Width="50px" Font-Bold="False" Font-Underline="True"></asp:Label>
    <asp:TextBox ID="TxtMontFijo" runat="server"></asp:TextBox>
    <asp:Button ID="BtnMontFijo" runat="server" Text="Cambiar" OnClick="BtnMontFijo_Click" />
    <br /><br />
    <asp:Label ID="LblMensaje" runat="server" Font-Bold="True"></asp:Label>

</asp:Content>
