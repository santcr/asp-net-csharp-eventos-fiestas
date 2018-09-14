<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="AdmOrgServicios.aspx.cs" Inherits="oblig2web.AdmOrgServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <h1>Catalogo de Servicios</h1>
    <br>
    <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GRVServicios" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="PrecioPorPersonaString" HeaderText="Precio" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>



</asp:Content>
