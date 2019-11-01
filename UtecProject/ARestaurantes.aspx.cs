using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string filename="";
            string url="";       
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            try
            {    
                if(upload.HasFile)
                {
                    filename = System.IO.Path.Combine(Server.MapPath("~/images"), upload.FileName);
                    url = "/images/" + upload.FileName;
                }                    
                client.sp_AgregarRestaurante((SQLTrans.LoginData)Session["userdata"], txtRname.Text, txtReferencia.Text, url);                
                output.Text = "Transaccion completada!";
                if (upload.HasFile)
                {                    
                    upload.SaveAs(filename);
                }
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