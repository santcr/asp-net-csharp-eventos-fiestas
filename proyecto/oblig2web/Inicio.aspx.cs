using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string rol = Empresa.Instancia.ValidarUsuario(Login1.UserName, Login1.Password);
            if (rol == "Administrador")
            {
                Session["usuario"] = Login1.UserName;
                Session["rol"] = rol;
                Response.Redirect("AdmBienvenido.aspx");
            }
            else if (rol == "Organizador")
            {
                Session["usuario"] = Login1.UserName;
                Session["rol"] = rol;
                Response.Redirect("OrgBienvenido.aspx");
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }



        }
    }
}