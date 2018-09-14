using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using oblig1clases;

namespace oblig2web
{
    public partial class OrgMisEventos : System.Web.UI.Page
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

            if (Session["usuario"] != null)
            {
                LblMisDatos.Text = Empresa.Instancia.DatosDeOrganizador(Session["usuario"].ToString());

                List<Evento> misEventos = Empresa.Instancia.ListarEventosOrganizador(Session["usuario"].ToString());

                if (misEventos.Count == 0)
                {
                    LblMisEventos.Text = "No tengo ningún evento.";
                    GVWMisEventos.Visible = false;
                }
                else
                {
                    GVWMisEventos.DataSource = misEventos;
                    GVWMisEventos.DataBind();

                    LblTotalGenerado.Text = "TOTAL GENERADO: " + Empresa.Instancia.TotalGeneradoPorOrganizador(Session["usuario"].ToString()).ToString();
                }
                
            }

        }

        protected void GVWMisEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if e.CommandName=="nombre del commando ejecutado"
            DateTime fechaDateTime = DateTime.Now;
            int fila = GVWMisEventos.SelectedIndex;

            DateTime.TryParse(GVWMisEventos.DataKeys[fila].Value.ToString(), out fechaDateTime);

            GVWServicios.DataSource = Empresa.Instancia.ServiciosDeEvento(fechaDateTime);
            GVWServicios.DataBind();
        }

        //protected void GVWMisEventos_RowCommand(object sender, GridViewCommandEventArgs e)
        //{


        //}

        //protected void GVWMisEventos_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    DateTime fechaDateTime = DateTime.Now;
        //    //string fecha = (string)GVWMisEventos.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
        //    //DateTime.TryParse(fecha, out fechaDateTime);

        //    // TODO: acá hay lío, se rompe todo!

        //    //int codigo = 0;
        //    DateTime.TryParse(GVWMisEventos.DataKeys[e.NewEditIndex].Value.ToString(), out fechaDateTime);


        //    // TODO: como hago para pasarle el dato de que evento es?

        //    GVWServicios.DataSource = Empresa.Instancia.ServiciosDeEvento(fechaDateTime);
        //    GVWServicios.DataBind();
        //}


    }
}