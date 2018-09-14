using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oblig2web
{
    public partial class OrgBienvenido : System.Web.UI.Page
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



        }
    }
}