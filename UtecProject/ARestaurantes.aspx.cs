using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace PRProject
{
    public partial class ARestaurantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name="";
            string url="";       
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            try
            {    
                if(upload.HasFile)
                {
                    name = Global.ImgName(upload.FileName, Server.MapPath("~/images/"));
                    url = "/images/" + name;
                }                    
                client.sp_AgregarRestaurante((SQLTrans.LoginData)Session["userdata"], txtRname.Text, txtReferencia.Text, url);                
                output.Text = "Transaccion completada!";
                if (upload.HasFile)
                    upload.SaveAs(Server.MapPath(Path.Combine("~/images/", name)));
                txtReferencia.Text = "";
                txtRname.Text = "";
            }
            catch (Exception)
            {

                output.Text = "Ocurrio un error y no se completo la transaccion!";
            }
            
        }       
    }
}