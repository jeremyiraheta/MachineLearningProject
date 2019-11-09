using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {            
            string url = "";
            string name = "";
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            try
            {
                
                if (upload.HasFile)
                {
                    name = clases.Tools.ImgName(upload.FileName, Server.MapPath("~/images/"));
                    url = "/images/" + name;
                }
                client.sp_AgregarUsuario(txtUsername.Text, txtNombre.Text, txtApellidos.Text, txtEmail.Text, txtBirth.Text, txtPassword.Text, url);
                output.Text = "Transaccion completada!";
                if(upload.HasFile)
                {
                    upload.SaveAs(Path.Combine(Server.MapPath("~/images"), name));
                }
                Response.Redirect("LogIn.aspx");
            }
            catch (Exception)
            {

                output.Text = "Ocurrio un error y no se completo la transaccion!";
            }
        }
        
    }
}