using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class AdmEventosSinServicio : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                DDLServicios.DataSource = Empresa.Instancia.Servicios;
                DDLServicios.DataValueField = "Nombre";
                // si no and usar el DataTextField
                DDLServicios.DataBind();
                DDLServicios.Items.Insert(0, new ListItem("Seleccione un Servicio", "0"));
            }

        }

        protected void BtnMostrar_Click(object sender, EventArgs e)
        {
            if (DDLServicios.Text != "0")
            {
                GVWEventos.DataSource = Empresa.Instancia.EventosSinServicio(Empresa.Instancia.BuscarServicio(DDLServicios.Text));
                GVWEventos.DataBind();
                GVWEventos.Visible = true;
                LblMensaje.Visible = false;
            }
            else
            {
                LblMensaje.Text = "Seleccione un servicio por favor.";
                LblMensaje.Visible = true;
                GVWEventos.Visible = false;
            }




        }
    }
}