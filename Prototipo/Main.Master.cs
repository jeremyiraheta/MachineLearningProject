using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototipo
{
    public partial class Main : System.Web.UI.MasterPage
    {
        LiteralControl submenu = new LiteralControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["logout"] != null)
                Session.Clear();
            if(Session["userdata"] != null)
            {
                SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
                user.InnerText = ldata.USER;
                user.HRef = "~/" + user.InnerText;                
                submenu.Text = @"<ul class='sub-menu' style='display: none; visibility: hidden; '>                                
                                 < li id = 'menu-item-47' class='menu-item menu-item-type-post_type menu-item-object-page'><a href = 'ARestaurantes.aspx' > Agregar Restaurante</a></li>
                                <li id = 'menu-item-43' class='menu-item menu-item-type-post_type menu-item-object-page'><a href = 'APlatos.aspx' >Agregar Platillo</a></li>
                                <li id = 'menu-item-142' class='menu-item menu-item-type-custom menu-item-object-custom'><a href = 'AMapa.aspx' >Modificar mapa</a></li>
                                <li id = 'menu-item-143' class='menu-item menu-item-type-custom menu-item-object-custom'><a href = 'Default.aspx?Logout=true' >Cerrar sesion</a></li>
                            </ul>";

                usermenu.Controls.Add(submenu);
            }
            else
            {
                submenu.Controls.Remove(submenu);
            }
            
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            user.InnerText = "Logear";
            user.HRef = "Login.aspx";
            user.Attributes.Remove("class");
            Session.Remove("userdata");
        }
    }
}