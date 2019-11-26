using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class AlterPass : System.Web.UI.Page
    {
        SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);            
            if (ldata == null)
                Response.Redirect("Default.aspx");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
            if(ldata.PASS != txtOldPass.Text)
            {
                output.Text = "Escriba el password actual correctamente";
                return;
            }else
            {
                try
                {
                    SQLTrans.Usuarios u = client.GetUsuario(ldata.USER)[0];
                    client.sp_AlterUsuario(ldata, ldata.USER,-1, u.NOMBRE, u.APELLIDO, u.CORREO_ELECTRONICO, u.FECHA_CUMPLE, u.ADMIN, txtPass1.Text);
                    Session.Clear();
                    Response.Redirect("Login.aspx");
                }
                catch { output.Text = "No se pudo completar la trasaccion"; }
            }
        }
    }
}