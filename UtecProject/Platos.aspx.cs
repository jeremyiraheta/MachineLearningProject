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
        const string MSGNOUSER = "<center><div color=red><h1>No se encontro el platillo</h1></div></center>";
        SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.Restaurantes[] restaurantes = client.GetRestaurantes();
            SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
            bool admin = false;
            string[] tipos = client.GetTiposPlatillo();
            if (ldata != null)
                admin = ldata.isAdmin;            
            
            if (!admin && (Request["action"] == "edit" || Request["action"] == "delete"))
            {
                output.Text = MSGNOGRANT;
            }
            else if (Request["id"] != null)
            {
                foreach (SQLTrans.Restaurantes r in restaurantes)
                {
                    ddRestaurantes.Items.Add(new ListItem(r.NOMBRE, r.ID.ToString()));
                }
                foreach (string t in tipos)
                {
                    string[] sp = t.Split(',');
                    ddTipos.Items.Add(new ListItem(sp[1], sp[0]));
                }
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
                    img.ImageUrl = dish.URL;
                cdish.Text = dish.NOMBRE;
                txtNombre.Text = dish.NOMBRE;
                txtDescripcion.Text = dish.DESCRIPCION;
                txtPrecio.Text = "$" + Math.Round(dish.PRECIO,2).ToString();
                ddRestaurantes.SelectedValue = dish.ID_RESTAURANTES.ToString();
                ddTipos.SelectedValue = dish.ID_TIPO.ToString();
                if (dish.RATE >= 1 && dish.RATE < 2)
                    star1.Checked = true;
                else if (dish.RATE >= 2 && dish.RATE < 3)
                    star2.Checked = true;
                else if (dish.RATE >= 3 && dish.RATE < 4)
                    star3.Checked = true;
                else if (dish.RATE >= 4 && dish.RATE < 5)
                    star4.Checked = true;
                else if (dish.RATE > 5)
                    star5.Checked = true;
                SQLTrans.Comentarios[] comments = client.GetComentarios(id);
                string comentarios = string.Concat(comments.Length, " Comentarios\n<ol class='commentlist'>");

                foreach (SQLTrans.Comentarios c in comments)
                {
                    string url = (c.URL == null || c.URL == string.Empty) ? "/images/sin-imagen.gif" : c.URL;
                    comentarios = string.Concat(comentarios,$"<li class='comment byuser comment-author-demoadmin bypostauthor even thread-even depth-1' id='li-comment-{c.ID_COMENTARIOS}'>",
                        $"<div id='comment-{c.ID_COMENTARIOS}'><div class='comment-author vcard'>",$"<img src='{url}' clas='avatar avatar-48 photo' height='48' width='48'>", "<cite class='fn'>",
                        "<a href='Users.aspx?id=", c.ID_USUARIO,"'>", c.ID_USUARIO,"</a> <small><br/>", c.FECHA, "</small></div><div class='comment-body'><p>",c.COMENTARIOS,"</p></div></div></li>");
                }
                comentarios = string.Concat(comentarios, "</ol>");
                divcomments.InnerHtml = comentarios;
                if(ldata != null)
                    commentform.Attributes.Remove("class");
            }
            else
            {
                userlist.Attributes.Remove("class");                
                string platillos = "";
                foreach (SQLTrans.Platillos p in client.GetPlatillos())
                {
                    platillos += string.Concat("<tr><td><img src='", (p.URL == null || p.URL == "") ? "/images/sin-imagen.gif" : p.URL, "' height='200px' width='200px' /></td><td>", p.NOMBRE, "</td><td>", p.TIPO, "</td><td>", p.RESTAURANTE, "</td><td>", Math.Round(p.PRECIO, 2), "</td><td><a href=Platos.aspx?id=", p.ID_PLATILLOS, ">Ver</a>&emsp;");                        
                    if (ldata != null)
                        if (ldata.isAdmin)
                            platillos += string.Concat("<a href=Platos.aspx?id=", p.ID_PLATILLOS, "&action=edit>Editar</a>&emsp;<a href=Platos.aspx?id=", p.ID_PLATILLOS, "&action=delete>Eliminar</a></td></tr>\n");

                }
                tbody.InnerHtml = platillos;
            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
            try
            {                
                if (ldata == null)
                {
                    output.Text = MSGNOGRANT;
                    return;
                }
                client.sp_AgregarComentario(ldata, Request["id"], txtComment.Text);
                Page.Validate();
            }
            catch
            {
                output.Text = "Ocurrio un error en la transaccion!";
            }
        }
    }
}