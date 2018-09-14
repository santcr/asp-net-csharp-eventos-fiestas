<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="RegOrganizador.aspx.cs" Inherits="oblig2web.RegOrganizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <h1>Registro de Organizador</h1>
    <br />
    <asp:Label ID="LblMail" runat="server" Text="Mail" Width="122px"></asp:Label>
    <asp:TextBox ID="TxtMail" runat="server" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtMail" ErrorMessage="El Mail es un dato requerido.">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblContrasenia" runat="server" Text="Contraseña" Width="122px"></asp:Label>
    <asp:TextBox ID="TxtContrasenia" runat="server" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La Contraseña es un campo requerido." ControlToValidate="TxtContrasenia">*</asp:RequiredFieldValidator>
    
    <br />
    <asp:Label ID="LblNombre" runat="server" Text="Nombre" Width="122px"></asp:Label>
    <asp:TextBox ID="TxtNombre" runat="server" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtNombre" ErrorMessage="El Nombre es un campo requerido.">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblTelefono" runat="server" Text="Teléfono" Width="122px"></asp:Label>
    <asp:TextBox ID="TxtTelefono" runat="server" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="El Teléfono es un campo requerido.">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblDireccion" runat="server" Text="Dirección" Width="122px"></asp:Label>
    <asp:TextBox ID="TxtDireccion" runat="server" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="El Teléfono es un campo requerido.">*</asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" Width="200px" OnClick="BtnRegistrar_Click" />
    <br />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
    <br />
    <asp:Label ID="LblMensaje" runat="server" Width="766px"></asp:Label>
    <br />
    <asp:LinkButton ID="LnkVolver" runat="server" PostBackUrl="~/Inicio.aspx">Volver al Inicio</asp:LinkButton>
</asp:Content>
