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
                        Button btnCPass = new Button();
                        btnCPass.Text = "Cambiar password";
                        btnEdit.Text = "Editar";
                        btnEdit.Click += BtnEdit_Click;
                        btnCPass.Click += BtnCPass_Click;
                        editcontrols.Controls.Add(btnEdit);
                        editcontrols.Controls.Add(btnCPass);
                        txtApellido.ReadOnly = false;
                        txtBirth.ReadOnly = false;
                        txtCorreo.ReadOnly = false;
                        txtNombre.ReadOnly = false;
                        chkAdmin.Enabled = true;
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
                            img.ImageUrl = "/images/" + user.URL;
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

        private void BtnCPass_Click(object sender, EventArgs e)
        {
            pass.Controls.Add(LoadControl("changepass.ascx"));                 
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
                TextBox c = (TextBox)FindControl("txtnewpass");
                TextBox old = (TextBox)FindControl("txtoldpass");
                if(old != null)
                    if(old.Text != ldata.PASS)
                    {
                        output.Text = "Ingrese su password actual correctamente!";
                        return;
                    }
                client.sp_AlterUsuario(ldata, img, txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtBirth.Text, chkAdmin.Checked, c != null ? c.Text : ldata.PASS);
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