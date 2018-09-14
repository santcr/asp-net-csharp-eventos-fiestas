using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oblig2web
{
    public partial class AdmBienvenido : System.Web.UI.Page
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






    }
}