<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="AdmRegAdministrador.aspx.cs" Inherits="oblig2web.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <h1>Registro de Administrador</h1>
    <br />
    <asp:Label ID="LblMail" runat="server" Text="Mail" Width="122px"></asp:Label>
    <asp:TextBox ID="TxtMail" runat="server" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtMail" ErrorMessage="El Mail es un campo requerido.">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblContrasenia" runat="server" Text="Contraseña" Width="122px"></asp:Label>
    <asp:TextBox ID="TxtContrasenia" runat="server" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtContrasenia" ErrorMessage="La Contraseña es un campo requerido.">*</asp:RequiredFieldValidator>
    <br /><br />
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" Width="200px" OnClick="Button1_Click" />
    <br />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
    <br />
    <asp:Label ID="LblMensaje" runat="server" Text="" Width="100%"></asp:Label>
    <br />
</asp:Content>
