using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Users : System.Web.UI.Page
    {
        const string MSGNOGRANT = "<center><div color=red><h1>No tienes permisos para ver este contenido</h1></div></center>";
        const string MSGNOUSER = "<center><div color=red><h1>No se encontro al usuario</h1></div></center>";
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            if (Session["userdata"] != null)
            {
                SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
                if(!ldata.isAdmin && Request["id"] == null)
                {
                    output.Text = MSGNOGRANT;
                }else if(Request["id"] != null)
                {
                    portrait.Attributes.Remove("class");
                    string id = Request["id"];
                    SQLTrans.Usuarios user;
                    try
                    {
                        user = client.GetUsuario(id)[0];
                    }
                    catch
                    {
                        output.Text = MSGNOUSER;
                        return;
                    }
                    username.Text = ldata.USER;
                    if (user.URL == null)
                        img.ImageUrl = "/images/sin-imagen.gif";
                    else
                        img.ImageUrl = "/images/" +  user.URL;
                    chkAdmin.Checked = client.isAdmin(id);
                    txtNombre.Text = user.NOMBRE;
                    txtApellido.Text = user.APELLIDO;
                    txtBirth.Text = Convert.ToDateTime(user.FECHA_CUMPLE).ToShortDateString();
                    txtCorreo.Text = user.CORREO_ELECTRONICO;
                    lcount.Text = user.VISITAS.ToString();
                }
                else
                {
                    userlist.Attributes.Remove("class");
                    string users="";
                    foreach (SQLTrans.Usuarios u in client.GetUsuarios())
                    {
                        users += string.Concat("<tr><td>",u.ID_USUARIO,"</td><td>",u.ADMIN ? "Admin" : "Usuario","</td><td>",u.CORREO_ELECTRONICO, "</td><td><a href=Users.aspx?id=", u.ID_USUARIO, ">Ver</a>&emsp;<a href=Users.aspx?id=",
                            u.ID_USUARIO, "&action=edit>Editar</a>&emsp;<a href=Users.aspx?id=", u.ID_USUARIO,"&action=delete>Eliminar</a></td></tr>\n");
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