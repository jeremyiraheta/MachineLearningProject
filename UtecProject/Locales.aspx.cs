using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Locales : System.Web.UI.Page
    {
        const string MSGNOGRANT = "No tienes permisos para ver este contenido";
        const string MSGNODISH = "No se encontro al local";
        const string MSGDEL = "Local Eliminado!";
        const string MSGNODEL = "No fue posible eliminar el local!";
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
                int id = Convert.ToInt32(Request["id"]);
                if (Request["action"] == "delete")
                {
                    try
                    {
                        client.sp_Delete(ldata, SQLTrans.DeleteType.Restaurante, id);
                        output.Text = MSGDEL;
                    }
                    catch { output.Text = MSGNODEL; }
                    return;
                }
                if (Request["action"] == "edit")
                {
                    Button btnEdit = new Button();
                    Button btnDel = new Button();                    
                    btnEdit.Text = "Editar";
                    btnDel.Text = "Eliminar";
                    btnDel.OnClientClick = "if ( ! UserDeleteConfirmation()) return false;";
                    btnDel.Click += BtnDel_Click;
                    btnEdit.Click += BtnEdit_Click;
                    editcontrols.Controls.Add(btnEdit);
                    editcontrols.Controls.Add(btnDel);
                    txtNombre.ReadOnly = false;
                    txtReferencia.ReadOnly = false;
                    upload.Enabled = true;
                    upload.CssClass = "";
                }
                portrait.Attributes.Remove("class");
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
                if(!IsPostBack)
                {
                    if (restaurants.URL == null || restaurants.URL == "")
                        img.ImageUrl = "/images/sin-imagen.gif";
                    else
                        img.ImageUrl = restaurants.URL;
                    txtNombre.Text = restaurants.NOMBRE;
                    txtReferencia.Text = restaurants.REFERENCIA;
                }
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
                            locales+=string.Concat("<a href=Locales.aspx?id=",r.ID, "&action=edit>Editar</a>&emsp;<a href=Locales.aspx?id=", r.ID, "&action=delete onclick=\"if ( ! UserDeleteConfirmation()) return false;\">Eliminar</a></td></tr>\n");
                }
                tbody.InnerHtml = locales;
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
                client.sp_AlterRestaurant(ldata, id, img, -1, txtNombre.Text, txtReferencia.Text);
                output.Text = "Transaccion realizada!";
            }
            catch (Exception)
            {

                output.Text = "Ocurrio un error!";
            }           
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Locales.aspx?id=" + Request["id"] + "&action=delete");
        }
    }
}