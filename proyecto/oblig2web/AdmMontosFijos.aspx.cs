using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class AdmMontosFijos : System.Web.UI.Page
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

            LblPorcAumValor.Text = Empresa.Instancia.VerPorcentajeDeAumento().ToString();
            LblMontFijoValor.Text = Empresa.Instancia.VerMontoFijoLimpieza().ToString();


        }

        protected void BtnPorcAum_Click(object sender, EventArgs e)
        {
            int valorNuevo = 0;
            int.TryParse(TxtPorcAum.Text, out valorNuevo);
            if (valorNuevo != 0 && Empresa.Instancia.CambiarPorcentajeDeAumento(valorNuevo))
            {
                Response.Redirect("AdmMontosFijos.aspx");
            }
            else
            {
                LblMensaje.Text = "La operación no pudo realizarse, intente nuevamente.";
            }

        }

        protected void BtnMontFijo_Click(object sender, EventArgs e)
        {
            int valorNuevo = 0;
            int.TryParse(TxtMontFijo.Text, out valorNuevo);
            if (valorNuevo != 0 && Empresa.Instancia.CambiarMontoFijoLimpieza(valorNuevo))
            {
                Response.Redirect("AdmMontosFijos.aspx");
            }
            else
            {
                LblMensaje.Text = "La operación no pudo realizarse, intente nuevamente.";
            }
        }
    }
}