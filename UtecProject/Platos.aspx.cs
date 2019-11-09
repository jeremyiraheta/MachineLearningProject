using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Platos : System.Web.UI.Page
    {
        const string MSGNOGRANT = "No tienes permisos para ver este contenido";
        const string MSGNOUSER = "No se encontro el platillo";
        const string MSGDEL = "Platillo Eliminado!";
        const string MSGNODEL = "No fue posible eliminar el platillo!";
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
                int id = Convert.ToInt32(Request["id"]);
                if (Request["action"] == "delete")
                {
                    try
                    {
                        client.sp_Delete(ldata, SQLTrans.DeleteType.Platillo, id);
                        output.Text = MSGDEL;
                    }
                    catch { output.Text = MSGNODEL; }
                    return;
                }
                if(Request["commentdelete"] != null)
                {
                    try
                    {
                        int i = Convert.ToInt32(Request["commentdelete"]);
                        client.sp_Delete(ldata, SQLTrans.DeleteType.Comentario, i);
                        output.Text = "Comentario eliminado!";
                    }
                    catch (Exception)
                    {

                        output.Text = "Ocurrio un error!";
                    }
                }
                if (Request["action"] == "edit")
                {
                    Button btnEdit = new Button();
                    Button btnDel = new Button();
                    btnEdit.Text = "Editar";
                    btnDel.Text = "Eliminar";
                    btnDel.Click += BtnDel_Click;
                    btnEdit.Click += BtnEdit_Click;
                    editcontrols.Controls.Add(btnEdit);
                    editcontrols.Controls.Add(btnDel);
                    ddRestaurantes.Enabled = true;
                    ddTipos.Enabled = true;
                    txtNombre.ReadOnly = false;
                    txtDescripcion.ReadOnly = false;
                    txtPrecio.ReadOnly = false;
                    upload.Enabled = true;
                    upload.CssClass = "";
                }
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
                rate.Controls.Add(LoadControl("rating.ascx"));
                if (!IsPostBack)
                {
                    if (dish.URL == null || dish.URL == "")
                        img.ImageUrl = "/images/sin-imagen.gif";
                    else
                        img.ImageUrl = dish.URL;
                    cdish.Text = dish.NOMBRE;
                    txtNombre.Text = dish.NOMBRE;
                    txtDescripcion.Text = dish.DESCRIPCION;
                    txtPrecio.Text = Math.Round(dish.PRECIO, 2).ToString();
                    ddRestaurantes.SelectedValue = dish.ID_RESTAURANTES.ToString();
                    ddTipos.SelectedValue = dish.ID_TIPO.ToString();
                    dishrate.Text = dish.RATE.ToString();
                }
                SQLTrans.Comentarios[] comments = client.GetComentarios(id);
                string comentarios = string.Concat(comments.Length, " Comentarios\n<ol class='commentlist'>");

                foreach (SQLTrans.Comentarios c in comments)
                {
                    string url = (c.URL == null || c.URL == string.Empty) ? "/images/sin-imagen.gif" : c.URL;
                    comentarios = string.Concat(comentarios,$"<li class='comment byuser comment-author-demoadmin bypostauthor even thread-even depth-1' id='li-comment-{c.ID_COMENTARIOS}'>",
                        $"<div id='comment-{c.ID_COMENTARIOS}'><div class='comment-author vcard'>",$"<img src='{url}' clas='avatar avatar-48 photo' height='48' width='48'>", "<cite class='fn'>",
                        "<a href='Users.aspx?id=", c.ID_USUARIO,"'>", c.ID_USUARIO,"</a> <small><br/>", c.FECHA, "</small></div><div class='comment-body'><p>",c.COMENTARIOS,"</p></div><div class='reply'><a href='Platos.aspx?id=",
                        id,"&commentdelete=", c.ID_COMENTARIOS,"'",(!admin) ? " class=hidden " : "" ,">Eliminar</a></div></div></li>");
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
                string tipo = Request["tipo"];
                foreach (SQLTrans.Platillos p in client.GetPlatillos())
                {
                    if (tipo != null)
                        if (Convert.ToInt32(tipo) != p.ID_TIPO)
                            continue;
                    platillos += string.Concat("<tr><td><img src='", (p.URL == null || p.URL == "") ? "/images/sin-imagen.gif" : p.URL, "' height='200px' width='200px' /></td><td>", p.NOMBRE, "</td><td>", p.TIPO, "</td><td>", p.RESTAURANTE, "</td><td>$", Math.Round(p.PRECIO, 2), "</td><td><a href=Platos.aspx?id=", p.ID_PLATILLOS, ">Ver</a>&emsp;");                        
                    if (ldata != null)
                        if (ldata.isAdmin)
                            platillos += string.Concat("<a href=Platos.aspx?id=", p.ID_PLATILLOS, "&action=edit>Editar</a>&emsp;<a href=Platos.aspx?id=", p.ID_PLATILLOS, "&action=delete OnClientClick=\"return confirm('Are you sure?');\">Eliminar</a></td></tr>\n");

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
                if(txtComment.Text.Trim().Length < 5)
                {
                    output.Text = "No hay nada que comentar, minimo 5 letras!";
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
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
            try
            {
                int img = -1;
                string name = "";
                string url = "";
                if (upload.HasFile)
                {
                    name = clases.Tools.ImgName(upload.FileName, Server.MapPath("~/images/"));
                    url = "/images/" + name;
                    img = client.sp_AgregarImagen(ldata, url);
                    upload.SaveAs(Server.MapPath(Path.Combine("~/images/", name)));
                }
                int id = int.Parse(Request["id"]);
                client.sp_AlterPlatillo(ldata, id, Convert.ToInt32(ddRestaurantes.SelectedValue), img, Convert.ToInt32(ddTipos.SelectedValue),txtNombre.Text,float.Parse(txtPrecio.Text), txtDescripcion.Text);
                output.Text = "Transaccion realizada!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                output.Text = "Ocurrio un error!";
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Platos.aspx?id=" + Request["id"] + "&action=delete");
        }
        private void createRating()
        {
            RadioButton r1 = new RadioButton();
            RadioButton r2 = new RadioButton();
            RadioButton r3 = new RadioButton();
            RadioButton r4 = new RadioButton();
            RadioButton r5 = new RadioButton();
            r1.CssClass = "radio-btn hide";
            r1.AutoPostBack = true;
            r1.CheckedChanged += (object sender, EventArgs e) => {

            };
            r2.CssClass = "radio-btn hide";
            r2.AutoPostBack = true;
            r2.CheckedChanged += (object sender, EventArgs e) => {

            };
            r3.CssClass = "radio-btn hide";
            r3.AutoPostBack = true;
            r3.CheckedChanged += (object sender, EventArgs e) => {

            };
            r4.CssClass = "radio-btn hide";
            r4.AutoPostBack = true;
            r4.CheckedChanged += (object sender, EventArgs e) => {

            };
            r5.CssClass = "radio-btn hide";
            r5.AutoPostBack = true;
            r5.CheckedChanged += (object sender, EventArgs e) => {

            };
        }
    }
}