<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="AdmEventosEntreFechas.aspx.cs" Inherits="oblig2web.AdmEventosEntreFechas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <h1>Eventos entre dos fechas ordenados por organizador/fecha</h1>
    <br />
    <asp:Label ID="LblFecha1" runat="server" Text="Fecha 1" Width="150px"></asp:Label>
    <asp:TextBox ID="TxtFecha1" runat="server" TextMode="Date"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Fecha 1." ControlToValidate="TxtFecha1">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblFecha2" runat="server" Text="Fecha 2" Width="150px"></asp:Label>
    <asp:TextBox ID="TxtFecha2" runat="server" TextMode="Date"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Fecha 2." ControlToValidate="TxtFecha2">*</asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="BtnMostrar" runat="server" Text="Mostrar Eventos" OnClick="BtnMostrar_Click" />
    <br />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
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
    <br />

    <asp:Label ID="LblTotalGenerado" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>


</asp:Content>
