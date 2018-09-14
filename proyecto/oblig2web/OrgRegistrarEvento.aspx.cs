using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class OrgRegistrarEvento : System.Web.UI.Page
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
                DDLServicios.DataSource = Empresa.Instancia.Servicios;
                DDLServicios.DataValueField = "Nombre";
                DDLServicios.DataBind();
                DDLServicios.Items.Insert(0, new ListItem("Seleccione un Servicio", "0"));

                PnlComun.Visible = false;
                PnlPremium.Visible = false;
            }

            if (Session["usuario"] != null)
            {
                LblMisDatos.Text = Empresa.Instancia.DatosDeOrganizador(Session["usuario"].ToString());
            }


        }

        protected void RbnComun_CheckedChanged(object sender, EventArgs e)
        {
            PnlComun.Visible = true;
            PnlPremium.Visible = false;
        }

        protected void RbnPremium_CheckedChanged(object sender, EventArgs e)
        {
            PnlComun.Visible = false;
            PnlPremium.Visible = true;
        }

        protected void BtnPremium_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string fechaString = TxtFecha.Text;
            DateTime.TryParse(fechaString, out fecha);
            DateTime hoy = DateTime.Now;
            int cantPersonasServicio = 0;
            int.TryParse(TxtCantPersonasServicio.Text, out cantPersonasServicio);
            int asistentes = 0;
            int.TryParse(TxtAsistentesPremium.Text, out asistentes);

            if (fecha.Year <= hoy.Year &&
                fecha.Month <= hoy.Month &&
                fecha.Day <= hoy.Day)
            {
                LblMensaje.Text = "La fecha ingresada no es correcta.";
            }
            else if (Empresa.Instancia.BuscarEvento(fecha) != null)
            {
                LblMensaje.Text = "Ya existe un Evento en esa fecha.";
            }
            else if (DDLTurno.Text == "Seleccione Turno")
            {
                LblMensaje.Text = "Seleccione Turno por favor.";
            }
            else if (TxtDescripcion.Text.Length < 8)
            {
                LblMensaje.Text = "La descripción debe tener al menos 8 caracteres.";
            }
            else if (TxtNombreCliente.Text.Length < 3)
            {
                LblMensaje.Text = "El nombre del cliente debe tener al menos 3 caracteres.";
            }
            else if (DDLServicios.Text == "0")
            {
                LblMensaje.Text = "Seleccione un Servicio por favor.";
            }
            else if (cantPersonasServicio < 1)
            {
                LblMensaje.Text = "La cantidad de personas para el servicio debe ser mayor a 0.";
            }
            else if (!FlpFoto.HasFile)
            {
                LblMensaje.Text = "Seleccione una foto por favor.";
            }
            else if (asistentes < 1 || asistentes > 100)
            {
                LblMensaje.Text = "La cantidad de asistentes debe ser un número entre 1 y 100 inclusive.";
            }
            else
            {
                FlpFoto.SaveAs(Server.MapPath("~/img/" + FlpFoto.FileName));
                string foto = FlpFoto.FileName;
                if (Empresa.Instancia.AltaEventoPremium(fecha, DDLTurno.Text, TxtDescripcion.Text, TxtNombreCliente.Text, DDLServicios.Text, cantPersonasServicio, asistentes, foto))
                {
                    Empresa.Instancia.AgregarEventoOrganizador(fecha, Session["usuario"].ToString());
                    LblMensaje.Text = "El Evento se registró correctamente.";
                }
                else
                {
                    LblMensaje.Text = "El Evento no pudo registrarse.";
                }
            }
        }

        protected void BtnComun_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string fechaString = TxtFecha.Text;
            DateTime.TryParse(fechaString, out fecha);
            DateTime hoy = DateTime.Now;
            int cantPersonasServicio = 0;
            int.TryParse(TxtCantPersonasServicio.Text, out cantPersonasServicio);
            int asistentes = 0;
            int.TryParse(TxtAsistentesComun.Text, out asistentes);
            int duracion = 0;
            int.TryParse(TxtDuracion.Text, out duracion);

            if (fecha.Year <= hoy.Year &&
                fecha.Month <= hoy.Month &&
                fecha.Day <= hoy.Day)
            {
                LblMensaje.Text = "La fecha ingresada no es correcta.";
            }
            else if (Empresa.Instancia.BuscarEvento(fecha) != null)
            {
                LblMensaje.Text = "Ya existe un Evento en esa fecha.";
            }
            else if (DDLTurno.Text == "Seleccione Turno")
            {
                LblMensaje.Text = "Seleccione Turno por favor.";
            }
            else if (TxtDescripcion.Text.Length < 8)
            {
                LblMensaje.Text = "La descripción debe tener al menos 8 caracteres.";
            }
            else if (TxtNombreCliente.Text.Length < 3)
            {
                LblMensaje.Text = "El nombre del cliente debe tener al menos 3 caracteres.";
            }
            else if (DDLServicios.Text == "0")
            {
                LblMensaje.Text = "Seleccione un Servicio por favor.";
            }
            else if (cantPersonasServicio < 1)
            {
                LblMensaje.Text = "La cantidad de personas para el servicio debe ser mayor a 0.";
            }
            else if (!FlpFoto.HasFile)
            {
                LblMensaje.Text = "Seleccione una foto por favor.";
            }
            else if (asistentes < 1 || asistentes > 10)
            {
                LblMensaje.Text = "La cantidad de asistentes debe ser un número entre 1 y 10 inclusive.";
            }
            else if (duracion > 4 || duracion < 1)
            {
                LblMensaje.Text = "La duración del evento debe ser un número entre 1 y 4 inclusive.";
            }
            else
            {
                FlpFoto.SaveAs(Server.MapPath("~/img/" + FlpFoto.FileName));
                string foto = FlpFoto.FileName;
                if (Empresa.Instancia.AltaEventoComun(fecha, DDLTurno.Text, TxtDescripcion.Text, TxtNombreCliente.Text, DDLServicios.Text, cantPersonasServicio, asistentes, foto, duracion))
                {
                    Empresa.Instancia.AgregarEventoOrganizador(fecha, Session["usuario"].ToString());
                    LblMensaje.Text = "El Evento se registró correctamente.";
                }
                else
                {
                    LblMensaje.Text = "El Evento no pudo registrarse.";
                }
            }

















        }
    }
}