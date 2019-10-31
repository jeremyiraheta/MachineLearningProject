using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class APlatos : System.Web.UI.Page
    {
        SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.Restaurantes[] restaurantes = client.GetRestaurantes();
            string[] tipos = client.GetTiposPlatillo();
            foreach (SQLTrans.Restaurantes r in restaurantes)
            {
                ddRestaurantes.Items.Add(new ListItem(r.NOMBRE, r.ID.ToString()));
            }
            foreach (string t in tipos)
            {
                string[] sp = t.Split(',');
                ddCategorias.Items.Add(new ListItem(sp[1],sp[0]));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string filename = "";
            string url = "";
            try
            {
                if (upload.HasFile)
                {
                    filename = System.IO.Path.Combine(Server.MapPath("~/images"), upload.FileName);
                    url = "/images/" + upload.FileName;
                }
                client.sp_AgregarPlatillo((SQLTrans.LoginData)Session["userdate"],txtDname.Text,float.Parse(txtPrice.Text),txtDescripcion.Text,Convert.ToInt32(ddCategorias.SelectedValue),Convert.ToInt32(ddRestaurantes.SelectedValue),url);
                output.Text = "Transaccion completada!";  
                if(upload.HasFile)
                    upload.SaveAs(filename);
            }
            catch (Exception)
            {

                output.Text = "Ocurrio un error y no se completo la transaccion!";
            }
        }
    }
}