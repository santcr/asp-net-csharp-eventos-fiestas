using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Solo para Administradores
            if (Session["rol"] == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                if (Session["rol"].ToString() != "Administrador")
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            #endregion


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Empresa.Instancia.ValidarMail(TxtMail.Text))
            {
                LblMensaje.Text = "El Mail ingresado no es válido";
            }
            else if (Empresa.Instancia.BuscarUsuario(TxtMail.Text) != null)
            {
                LblMensaje.Text = "Ese usuario ya está registrado.";
            }
            else if (!Empresa.Instancia.ValidarContrasenia(TxtContrasenia.Text))
            {
                LblMensaje.Text = "La Contraseña no es válida.";
            }
            else if (Empresa.Instancia.AltaAdministrador(TxtMail.Text, TxtContrasenia.Text))
            {
                LblMensaje.Text = "El Administrador se registró correctamente";
            }
            else
            {
                LblMensaje.Text = "El Administrador NO pudo registrarse correctamente";
            }
        }




    }
}