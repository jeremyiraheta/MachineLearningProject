using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Platos : System.Web.UI.Page
    {
        const string MSGNOGRANT = "<center><div color=red><h1>No tienes permisos para ver este contenido</h1></div></center>";
        const string MSGNOUSER = "<center><div color=red><h1>No se encontro al usuario</h1></div></center>";
        SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.Restaurantes[] restaurantes = client.GetRestaurantes();
            string[] tipos = client.GetTiposPlatillo();
            foreach (SQLTrans.Restaurantes r in restaurantes)
            {
                ddRestaurantes.Items.Add(new ListItem(r.NOMBRE, r.ID.ToString()));
            }
            foreach (string t in tipos)
            {
                string[] sp = t.Split(',');
                ddTipos.Items.Add(new ListItem(sp[1], sp[0]));
            }
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
                    SQLTrans.Platillos dish;
                    try
                    {
                        dish = client.GetPlatillo(id)[0];
                    }
                    catch
                    {
                        output.Text = MSGNOUSER;
                        return;
                    }
                    if (dish.URL == null)
                        img.ImageUrl = "/images/sin-imagen.gif";
                    else
                        img.ImageUrl = "/images/" + dish.URL;
                    cdish.Text = dish.NOMBRE;
                    txtNombre.Text = dish.NOMBRE;
                    txtDescripcion.Text = dish.DESCRIPCION;
                    txtPrecio.Text = "$" + dish.PRECIO.ToString();
                    ddRestaurantes.SelectedValue = dish.ID_RESTAURANTES.ToString();
                    ddTipos.SelectedValue = dish.ID_TIPO.ToString();
                }
                else
                {
                    userlist.Attributes.Remove("class");
                    string users = "";
                    foreach (SQLTrans.Platillos p in client.GetPlatillos())
                    {
                        users += string.Concat("<tr><td>", p.NOMBRE, "</td><td>", p.TIPO, "</td><td>", p.RESTAURANTE, "</td><td>", p.PRECIO, "</td><td><a href=Platos.aspx?id=", p.ID_PLATILLOS, ">Ver</a>&emsp;<a href=Platos.aspx?id=",
                            p.ID_PLATILLOS, "&action=edit>Editar</a>&emsp;<a href=Platos.aspx?id=", p.ID_PLATILLOS, "&action=delete>Eliminar</a></td></tr>\n");
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