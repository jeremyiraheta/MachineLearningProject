using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Users : System.Web.UI.Page
    {
        const string MSGNOGRANT = "No tienes permisos para ver este contenido";
        const string MSGNOUSER = "No se encontro al usuario";                
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
                    if (Request["action"] == "edit" && ldata.isAdmin)
                    {
                        Button btnEdit = new Button();                                                
                        btnEdit.Text = "Editar";
                        btnEdit.Click += BtnEdit_Click;                        
                        editcontrols.Controls.Add(btnEdit);                        
                        txtApellido.ReadOnly = false;
                        txtBirth.ReadOnly = false;
                        txtCorreo.ReadOnly = false;
                        txtNombre.ReadOnly = false;
                        chkAdmin.Enabled = true;
                    }
                    else if(Request["edit"] == "true" && ldata.USER == Request["id"])
                    {
                        Button btnEdit = new Button();
                        btnEdit.Text = "Editar";
                        btnEdit.Click += BtnEdit_Click;
                        editcontrols.Controls.Add(btnEdit);
                        txtApellido.ReadOnly = false;
                        txtBirth.ReadOnly = false;
                        txtCorreo.ReadOnly = false;
                        txtNombre.ReadOnly = false;
                    }                
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
                    username.Text = id;
                    if(!IsPostBack)
                    {
                        if (user.URL == null || user.URL == "")
                            img.ImageUrl = "/images/sin-imagen.gif";
                        else
                            img.ImageUrl = user.URL;
                        chkAdmin.Checked = client.isAdmin(id);
                        txtNombre.Text = user.NOMBRE;
                        txtApellido.Text = user.APELLIDO;
                        txtBirth.Text = Convert.ToDateTime(user.FECHA_CUMPLE).ToShortDateString();
                        txtCorreo.Text = user.CORREO_ELECTRONICO;
                        lcount.Text = user.VISITAS.ToString();
                    }
                }
                else
                {
                    userlist.Attributes.Remove("class");
                    string users="";
                    foreach (SQLTrans.Usuarios u in client.GetUsuarios())
                    {
                        users += string.Concat("<tr><td>",u.ID_USUARIO,"</td><td>",u.ADMIN ? "Admin" : "Usuario","</td><td>",u.CORREO_ELECTRONICO, "</td><td><a href=Users.aspx?id=", u.ID_USUARIO, ">Ver</a>&emsp;<a href=Users.aspx?id=",
                            u.ID_USUARIO, "&action=edit>Editar</a></td></tr>\n");
                    }
                    tbody.InnerHtml = users;
                }
            }
            else
            {
                output.Text = MSGNOGRANT;
            }
        }
       

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
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
                string id = Request["id"].ToString();                
                if(ldata.isAdmin)
                    client.sp_AlterUsuario(ldata, id, img, txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtBirth.Text, chkAdmin.Checked, null);
                else
                    client.sp_AlterUsuario(ldata, id, img, txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtBirth.Text, ldata.isAdmin, null);
                output.Text = "Transaccion realizada!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                output.Text = "Ocurrio un error!";
            }
        }
    }
}