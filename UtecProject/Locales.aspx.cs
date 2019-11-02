using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Locales : System.Web.UI.Page
    {
        const string MSGNOGRANT = "<center><div color=red><h1>No tienes permisos para ver este contenido</h1></div></center>";
        const string MSGNODISH = "<center><div color=red><h1>No se encontro al local</h1></div></center>";
        SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
            bool admin=false;
            if (ldata != null)
                admin = ldata.isAdmin;
            if (!admin && (Request["action"] == "edit" || Request["action"] == "delete"))
            {
                output.Text = MSGNOGRANT;
            }
            else if (Request["id"] != null)
            {
                portrait.Attributes.Remove("class");
                int id = Convert.ToInt32(Request["id"]);
                SQLTrans.Restaurantes restaurants;
                try
                {
                    restaurants = client.GetRestaurante(id)[0];
                }
                catch
                {
                    output.Text = MSGNODISH;
                    return;
                }
                if (restaurants.URL == null || restaurants.URL == "")
                    img.ImageUrl = "/images/sin-imagen.gif";
                else
                    img.ImageUrl = restaurants.URL;
                txtNombre.Text = restaurants.NOMBRE;
                txtReferencia.Text = restaurants.REFERENCIA;
            }
            else
            {
                userlist.Attributes.Remove("class");
                string locales = "";
                foreach (SQLTrans.Restaurantes r in client.GetRestaurantes())
                {
                    locales += string.Concat("<tr><td><img src='", (r.URL == null || r.URL == string.Empty) ? "/images/sin-imagen.gif" : r.URL, "' height='200px' width='200px' /></td><td>", r.NOMBRE, "</td><td>", r.REFERENCIA, "</td><td>", r.RATE, "</td><td><a href=Locales.aspx?id=", r.ID, ">Ver</a>&emsp;");
                    if(ldata!=null)
                        if(ldata.isAdmin)
                            locales+=string.Concat("<a href=Locales.aspx?id=",r.ID, "&action=edit>Editar</a>&emsp;<a href=Locales.aspx?id=", r.ID, "&action=delete>Eliminar</a></td></tr>\n");
                }
                tbody.InnerHtml = locales;
            }
        }
    }
}