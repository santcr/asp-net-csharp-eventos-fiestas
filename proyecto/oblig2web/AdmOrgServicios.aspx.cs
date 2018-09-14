using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class AdmOrgServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Solo para Administradores y Organizadores
            if (Session["rol"] == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                if (Session["rol"].ToString() != "Organizador" && Session["rol"].ToString() != "Administrador")
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            #endregion


            List<Servicio> listaServicios = Empresa.Instancia.Servicios;
            if (listaServicios.Count == 0)
            {
                GRVServicios.Visible = false;
                LblMensaje.Text = "No hay ningún servicio.";
            }
            else
            {
                GRVServicios.DataSource = listaServicios;
                GRVServicios.DataBind();
            }

            

        }
    }
}