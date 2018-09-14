using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class RegOrganizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LnkVolver.Visible = false;
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Empresa.Instancia.ValidarMail(TxtMail.Text))
            {
                LblMensaje.Text = "El Mail ingresado no es válido.";
            }
            else if (Empresa.Instancia.BuscarUsuario(TxtMail.Text)!= null)
            {
                LblMensaje.Text = "Ese usuario ya está registrado.";
            }
            else if (!Empresa.Instancia.ValidarContrasenia(TxtContrasenia.Text))
            {
                LblMensaje.Text = "La Contraseña ingresada no es válida.";
            }
            else if (!Empresa.Instancia.ValidarNombre(TxtNombre.Text))
            {
                LblMensaje.Text = "El Nombre ingresado no es válido.";
            }
            else if (Empresa.Instancia.AltaOrganizador(TxtMail.Text, TxtContrasenia.Text, TxtNombre.Text, TxtTelefono.Text, TxtDireccion.Text))
            {
                LblMensaje.Text = "Se registró correctamente al nuevo Organizador";
                LnkVolver.Visible = true;
            }
            else
            {
                LblMensaje.Text = "El registro no pudo realizarse correctamente";
            }

        }
    }
}