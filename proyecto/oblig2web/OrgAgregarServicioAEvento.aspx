<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="OrgAgregarServicioAEvento.aspx.cs" Inherits="oblig2web.OrgAgregarServicioAEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <h1>Agregar Servicio a Evento</h1>
    <br />

    <asp:Label ID="LblEvento" runat="server" Text="Evento" Width="150px"></asp:Label>
    <asp:DropDownList ID="DDLEventos" runat="server" Width="350px"></asp:DropDownList>
    <br />
    <asp:Label ID="LblServicio" runat="server" Text="Servicio" Width="150px"></asp:Label>
    <asp:DropDownList ID="DDLServicios" runat="server" Width="350px"></asp:DropDownList>
    <br />
    <asp:Label ID="LblCantPersonas" runat="server" Text="Cant. de personas" Width="150px"></asp:Label>
    <asp:TextBox ID="TxtCantPersonas" runat="server" Width="346px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" OnClick="BtnAgregar_Click" />
    <br />
    <br />
    <asp:Label ID="LblMensaje" runat="server" Text="" Width="100%"></asp:Label>

</asp:Content>
