using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class OrgAgregarServicioAEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Solo para Organizadores
            if (Session["rol"] == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                if (Session["rol"].ToString() != "Organizador")
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            #endregion


            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    DDLEventos.DataSource = Empresa.Instancia.ListarEventosOrganizador(Session["usuario"].ToString());
                    DDLEventos.DataTextField = "DatosVarios";
                    DDLEventos.DataValueField = "Fecha";
                    DDLEventos.DataBind();
                    DDLEventos.Items.Insert(0, new ListItem("Seleccione un Evento", "0"));
                }
                DDLServicios.DataSource = Empresa.Instancia.Servicios;
                DDLServicios.DataValueField = "Nombre";
                DDLServicios.DataBind();
                DDLServicios.Items.Insert(0, new ListItem("Seleccione un Servicio", "0"));
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (DDLEventos.Text == "0")
            {
                LblMensaje.Text = "Seleccione un evento por favor.";
            }
            else if (DDLServicios.Text == "0")
            {
                LblMensaje.Text = "Seleccione un servicio por favor.";
            }
            else if (TxtCantPersonas.Text == "")
            {
                LblMensaje.Text = "Ingrese una cantidad de personas válida por favor.";
            }
            else
            {
                int cantPersonasServicio = 0;
                int.TryParse(TxtCantPersonas.Text, out cantPersonasServicio);
                DateTime fecha = DateTime.Now;
                string fechaString = DDLEventos.Text.ToString();
                DateTime.TryParse(fechaString, out fecha);
                Evento evento = Empresa.Instancia.BuscarEvento(fecha);

                if (evento != null)
                {
                    int asistentesEvento = evento.Asistentes;
                    string servicioNombre = DDLServicios.Text.ToString();

                    if (Empresa.Instancia.EventoTieneServicio(fecha, servicioNombre))
                    {
                        LblMensaje.Text = "Ese evento ya tiene contratado ese servicio.";
                    }
                    else if (cantPersonasServicio > asistentesEvento)
                    {
                        LblMensaje.Text = "La cantidad de personas del servicio no puede ser mayor a la cantidad de asistentes al evento.";
                    }
                    else
                    {
                        if (Empresa.Instancia.AgregarServicioEvento(servicioNombre, cantPersonasServicio, fecha))
                        {
                            LblMensaje.Text = "El servicio se agregó correctamente.";
                        }
                        else
                        {
                            LblMensaje.Text = "El servicio no pudo agregarse.";
                        }
                    }
                }
            }




            
            

            

        }
    }
}