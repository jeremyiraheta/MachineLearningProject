using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Prototipo
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SQLTrans.Service1Client client= new SQLTrans.Service1Client();
            DataSet ds = client.sp_ValidarUsuario(txtUser.Text, txtPass.Text);
            if (ds.Tables.Count > 0)
            {
                SQLTrans.LoginData linfo = new SQLTrans.LoginData();
                linfo.USER = txtUser.Text;
                linfo.PASS = txtPass.Text;
                Session["userdata"] = linfo;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session.Remove("userdata");
                output.Text = "Usuario o Password incorrectos!";
            }
        }
    }
}