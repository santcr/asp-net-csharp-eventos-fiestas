using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace oblig2web
{
    public partial class oblig2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                string rol = Session["rol"].ToString();
                if (rol == "Administrador")
                {
                    MenuAdmin.Visible = true;
                    MenuOrg.Visible = false;
                }
                else if (rol == "Organizador")
                {
                    MenuAdmin.Visible = false;
                    MenuOrg.Visible = true;
                }
                else
                {
                    MenuAdmin.Visible = false;
                    MenuOrg.Visible = false;
                }
            }

        }

        protected void MenuAdmin_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "CerrarSession") {

                Session.Clear();
                Response.Redirect("Inicio.aspx");
            }
                        
        }

        protected void MenuOrg_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "CerrarSession")
            {

                Session.Clear();
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}