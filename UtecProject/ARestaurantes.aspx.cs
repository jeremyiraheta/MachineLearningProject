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
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            try
            {                
                client.sp_AgregarRestaurante((SQLTrans.LoginData)Session["userdate"], txtRname.Text, txtReferencia.Text, filename);                
                output.Text = "Transaccion completada!";
                if (upload.HasFile)
                {
                    filename = System.IO.Path.Combine(Server.MapPath("~/images"), upload.FileName);
                    upload.SaveAs(filename);
                }
            }
            catch (Exception)
            {

                output.Text = "Ocurrio un error y no se completo la transaccion!";
            }
            
        }
    }
}