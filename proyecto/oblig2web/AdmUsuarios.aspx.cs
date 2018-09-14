using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class AdmUsuarios : System.Web.UI.Page
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

            List<Usuario> listaAdmins = Empresa.Instancia.ListarAdministradores();
            List<Organizador> listaOrgs = Empresa.Instancia.ListarOrganizadores();

            if (listaAdmins.Count == 0)
            {
                LblMensaje1.Text = "No existe ningún Administrador.";
            }
            else
            {
                GVWAdmin.DataSource = listaAdmins;
                GVWAdmin.DataBind();
            }

            if (listaOrgs.Count == 0)
            {
                LblMensaje2.Text = "No existe ningún Organizador.";
            }
            else
            {
                GVWOrg.DataSource = listaOrgs;
                GVWOrg.DataBind();
            }
            

            


        }
    }
}