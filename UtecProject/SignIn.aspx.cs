using System;
using System.Collections.Generic;
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
            string filename = "";
            string url = "";
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            try
            {
                
                if (upload.HasFile)
                {
                    filename = System.IO.Path.Combine(Server.MapPath("~/images"), upload.FileName);
                    url = "/images/" + upload.FileName;
                }
                client.sp_AgregarUsuario(txtUsername.Text, txtNombre.Text, txtApellidos.Text, txtEmail.Text, txtBirth.Text, txtPassword.Text, url);
                output.Text = "Transaccion completada!";
                Response.Redirect("LogIn.aspx");
            }
            catch (Exception)
            {

                output.Text = "Ocurrio un error y no se completo la transaccion!";
            }
        }
    }
}