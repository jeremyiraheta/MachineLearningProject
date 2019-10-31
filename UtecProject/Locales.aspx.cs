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
        const string MSGNOUSER = "<center><div color=red><h1>No se encontro al usuario</h1></div></center>";
        SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
                if (!ldata.isAdmin && Request["id"] == null)
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
                        output.Text = MSGNOUSER;
                        return;
                    }
                    if (restaurants.URL == null || restaurants.URL == "")
                        img.ImageUrl = "/images/sin-imagen.gif";
                    else
                        img.ImageUrl = "/images/" + restaurants.URL;
                    txtNombre.Text = restaurants.NOMBRE;
                    txtReferencia.Text = restaurants.REFERENCIA;
                }
                else
                {
                    userlist.Attributes.Remove("class");
                    string users = "";
                    foreach (SQLTrans.Restaurantes r in client.GetRestaurantes())
                    {
                        users += string.Concat("<tr><td>", r.NOMBRE, "</td><td>", r.REFERENCIA, "</td><td>", r.RATE, "</td><td><a href=Locales.aspx?id=", r.ID, ">Ver</a>&emsp;<a href=Locales.aspx?id=",
                            r.ID, "&action=edit>Editar</a>&emsp;<a href=Locales.aspx?id=", r.ID, "&action=delete>Eliminar</a></td></tr>\n");
                    }
                    tbody.InnerHtml = users;
                }
            }
            else
            {
                output.Text = MSGNOGRANT;
            }
        }
    }
}