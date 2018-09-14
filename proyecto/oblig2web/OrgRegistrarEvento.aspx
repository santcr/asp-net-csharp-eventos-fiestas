<%@ Page Title="" Language="C#" MasterPageFile="~/oblig2.Master" AutoEventWireup="true" CodeBehind="OrgRegistrarEvento.aspx.cs" Inherits="oblig2web.OrgRegistrarEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidarDatos()
        {
            var personasServicio = document.getElementById("<%=TxtCantPersonasServicio.ClientID%>").value;
            var personasTotal = 0;

            if (document.getElementById("<%=RbnComun.ClientID%>").checked)
            {
                personasTotal = document.getElementById("<%=TxtAsistentesComun.ClientID%>").value;
            }
            else if (document.getElementById("<%=RbnPremium.ClientID%>").checked)
            {
                personasTotal = document.getElementById("<%=TxtAsistentesPremium.ClientID%>").value;
            }

            if (personasTotal < personasServicio) {
                alert("La cantidad de personas para el servicio no puede ser mayor a la cantidad de personas que asisten al evento.");
                return false;
            }
            else { return true; }

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <h1>Mis Datos</h1>
    <asp:Label ID="LblMisDatos" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <h1>Registrar Evento</h1>
    <br />
    <asp:Label ID="LblFecha" runat="server" Text="Fecha" Width="200px"></asp:Label>
    <asp:TextBox ID="TxtFecha" runat="server" Width="200px" TextMode="Date"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtFecha" ErrorMessage="La Fecha es un campo requerido.">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblTurno" runat="server" Text="Turno" Width="200px"></asp:Label>
    <asp:DropDownList ID="DDLTurno" runat="server" Width="204px">
        <asp:ListItem>Seleccione Turno</asp:ListItem>
        <asp:ListItem>mañana</asp:ListItem>
        <asp:ListItem>tarde</asp:ListItem>
        <asp:ListItem>noche</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="LblDescripcion" runat="server" Text="Descripción" Width="200px"></asp:Label>
    <asp:TextBox ID="TxtDescripcion" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtDescripcion" ErrorMessage="La Descripción es un campo requerido.">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblNombreCliente" runat="server" Text="Nombre del cliente" Width="200px"></asp:Label>
    <asp:TextBox ID="TxtNombreCliente" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtNombreCliente" ErrorMessage="El Nombre del cliente es un campo requerido.">*</asp:RequiredFieldValidator>

    <br />
    <asp:Label ID="LblServicio" runat="server" Text="Servicio" Width="200px"></asp:Label>
    <asp:DropDownList ID="DDLServicios" runat="server" Width="204px"></asp:DropDownList>
    <br />
    <asp:Label ID="LblCantPersonasServicio" runat="server" Text="Cant. personas (Servicio)" Width="200px"></asp:Label>
    <asp:TextBox ID="TxtCantPersonasServicio" runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtCantPersonasServicio" ErrorMessage="La Cant. personas (Servicio) es un campo requerido.">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LblFoto" runat="server" Text="Foto" Width="200px"></asp:Label>
    <asp:FileUpload ID="FlpFoto" runat="server" Width="200px" />
    <br /><br />
    <asp:RadioButton ID="RbnComun" runat="server" AutoPostBack="True" GroupName="TipoEvento" Text="Evento Común" Width="150px" OnCheckedChanged="RbnComun_CheckedChanged" />
    <asp:RadioButton ID="RbnPremium" runat="server" AutoPostBack="True" GroupName="TipoEvento"  Text="Evento Premium" Width="150px" OnCheckedChanged="RbnPremium_CheckedChanged" />
    <br /><br />
    <asp:Panel ID="PnlComun" runat="server">
        <asp:Label ID="LblDuracion" runat="server" Text="Duración" Width="200px"></asp:Label>
        <asp:TextBox ID="TxtDuracion" runat="server" Width="200px" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDuracion" ErrorMessage="La duración es un campo requerido.">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="TxtDuracion" ErrorMessage="La duración debe ser un numero entre 1 y 4" MaximumValue="4" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
        <br />
        <asp:Label ID="LblAsistentesComun" runat="server" Text="Cant. asistentes (Evento)" Width="200px"></asp:Label>
        <asp:TextBox ID="TxtAsistentesComun" runat="server" Width="200px" TextMode="Number"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtAsistentesComun" ErrorMessage="La Cant de asistentes es un campo requerido." Type="String">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtAsistentesComun" ErrorMessage="Cant de asistentes debe ser un numero entre 1 y 10" MaximumValue="10" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
        
        <br /><br />
        <asp:Button ID="BtnComun" runat="server" Text="Registrar Evento Común" OnClientClick="return ValidarDatos();" OnClick="BtnComun_Click" />
    </asp:Panel>
    <asp:Panel ID="PnlPremium" runat="server">
        <asp:Label ID="LblAsistentesPremium" runat="server" Text="Cant. asistentes (Evento)" Width="200px"></asp:Label>
        <asp:TextBox ID="TxtAsistentesPremium" runat="server" Width="200px" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtAsistentesPremium" ErrorMessage="La Cant de asistentes es un campo requerido.">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TxtAsistentesPremium" ErrorMessage="Cant de asistentes debe ser un numero entre 1 y 100" MaximumValue="100" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
        <br /><br />
        <asp:Button ID="BtnPremium" runat="server" Text="Registrar Evento Premium" OnClientClick="return ValidarDatos();" OnClick="BtnPremium_Click" />
    </asp:Panel>
    <br />

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />

    <asp:Label ID="LblMensaje" runat="server" Text="" Width="500px"></asp:Label>

    <br /><br />
    
</asp:Content>
