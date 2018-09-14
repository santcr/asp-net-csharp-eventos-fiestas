using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class AdmEventosEntreFechas : System.Web.UI.Page
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

        protected void BtnMostrar_Click(object sender, EventArgs e)
        {
            DateTime fecha1 = DateTime.Now;
            DateTime.TryParse(TxtFecha1.Text, out fecha1);
            DateTime fecha2 = DateTime.Now;
            DateTime.TryParse(TxtFecha2.Text, out fecha2);

            List<Evento> lista = Empresa.Instancia.EventosEntre(fecha1, fecha2);
            if (lista.Count == 0)
            {
                LblMensaje.Text = "No hay ningún evento entre esas fechas.";
                LblMensaje.Visible = true;
                GVWEventos.Visible = false;
                LblTotalGenerado.Visible = false;
            }
            else
            {
                LblMensaje.Visible = false;
                GVWEventos.Visible = true;
                LblTotalGenerado.Visible = true;
                GVWEventos.DataSource = lista;
                GVWEventos.DataBind();
                LblTotalGenerado.Text = "Total generado: " +  Empresa.Instancia.EventosEntreTotalGenerado(fecha1, fecha2).ToString();
            }
            



        }
    }
}