<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="AdmEventosSinServicio.aspx.cs" Inherits="oblig2web.AdmEventosSinServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <h1>Eventos sin servicio determinado</h1>
    <br />
    <asp:DropDownList ID="DDLServicios" runat="server"></asp:DropDownList>
    <br /><br />
    <asp:Button ID="BtnMostrar" runat="server" Text="Mostrar" OnClick="BtnMostrar_Click" />

    <br />

    <br />
    <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>

        <asp:GridView ID="GVWEventos" runat="server" Width="100%" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Id" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="NombreCliente" HeaderText="Nombre del Cliente" />
            <asp:BoundField DataField="CostoCalculado" HeaderText="Costo" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>

</asp:Content>
