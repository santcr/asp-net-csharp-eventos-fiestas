<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="OrgMisEventos.aspx.cs" Inherits="oblig2web.OrgMisEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <h1>Mis Datos</h1>
    <asp:Label ID="LblMisDatos" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <h1>Mis Eventos</h1>
    <asp:Label ID="LblMisEventos" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GVWMisEventos" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="Fecha" OnSelectedIndexChanged="GVWMisEventos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="NombreCliente" HeaderText="Nombre del cliente" />
            <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto">
                <ControlStyle Width="150px" />
            </asp:ImageField>
            <asp:BoundField DataField="CostoCalculado" HeaderText="Costo total" />
            <asp:CommandField EditText="" HeaderText="Ver Servicios" SelectText="Ver Servicios" ShowSelectButton="True" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <br />
    <asp:Label ID="LblTotalGenerado" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
    <br />
    <br />
    <h1>Servicios del Evento</h1>
    <p>&nbsp;</p>

    <asp:GridView ID="GVWServicios" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:BoundField DataField="NombreServicio" HeaderText="Servicio" />
            <asp:BoundField DataField="CostoPorPersona" HeaderText="Costo por Persona" />
            <asp:BoundField DataField="CantPersonas" HeaderText="Cantidad de Personas" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>

</asp:Content>
