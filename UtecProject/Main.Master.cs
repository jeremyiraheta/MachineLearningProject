using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Main : System.Web.UI.MasterPage
    {                
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] stipos = new SQLTrans.CrudServiceClient().GetTiposPlatillo();
            LiteralControl tipos = new LiteralControl();
            foreach (string t in stipos)
                tipos.Text += $"<li id=class='menu-item menu-item-type-taxonomy menu-item-object-category'><a href='Platos.aspx?tipo={t}'>{t}</a></li>";
            tipoplatillo.Controls.Add(tipos);
            if (Request["logout"] != null)
                Session.Clear();
            if(Session["userdata"] != null)
            {
                SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
                new SQLTrans.CrudServiceClient().sp_AgregarEstadistica(ldata);
                LiteralControl submenu = new LiteralControl();
                user.InnerText = ldata.USER;
                user.HRef = "~/Users.aspx?id=" + ldata.USER;                
                if(ldata.isAdmin)
                {

                }
                submenu.Text = string.Concat("<ul class='sub-menu' style='display: none; visibility: hidden;'>",
                                 "<li id = 'menu-item-47' class='menu-item menu-item-type-post_type menu-item-object-page'><a href = 'ARestaurantes.aspx' >Agregar Restaurante</a></li>",
                                "<li id = 'menu-item-43' class='menu-item menu-item-type-post_type menu-item-object-page'><a href = 'APlatos.aspx' >Agregar Platillo</a></li>",
                                (ldata.isAdmin) ? "<li id = 'menu-item-142' class='menu-item menu-item-type-custom menu-item-object-custom'><a href = 'AMapa.aspx' >Modificar mapa</a></li>" : ""
                                ,(ldata.isAdmin) ? "<li id = 'menu-item-144' class='menu-item menu-item-type-custom menu-item-object-custom'><a href = 'Users.aspx' >Ver usuarios</a></li>" : ""
                                , (ldata.isAdmin) ? "<li id = 'menu-item-145' class='menu-item menu-item-type-custom menu-item-object-custom'><a href = 'History.aspx' >Ver historial</a></li>" : ""
                                , "<li id = 'menu-item-143' class='menu-item menu-item-type-custom menu-item-object-custom'><a href = 'Default.aspx?Logout=true' >Cerrar sesion</a></li></ul>");

                usermenu.Controls.Add(submenu);
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