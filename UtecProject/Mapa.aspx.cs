using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Mapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            if (Session["userdata"] != null)
            {
                SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
                if (!ldata.isAdmin && Request["edit"] == "True")
                {
                    output.Text = "No tiene los permisos para editar";
                    return;
                }
                else
                {
                    Button btnEdit = new Button();
                    btnEdit.Text = "Guardar";
                    btnEdit.Click += BtnEdit_Click;
                    edit.Controls.Add(btnEdit);
                    SQLTrans.Restaurantes[] rest = client.GetRestaurantes();
                    string tab = "";
                    foreach (SQLTrans.Restaurantes r in rest)
                    {
                        string x = r.X == 0 ? "" : r.X.ToString();
                        string y = r.Y == 0 ? "" : r.Y.ToString();
                        tab += $"<tr><td>{r.NOMBRE}</td><td><span id='x{r.ID}'>{x}</span></td><td><span id='y{r.ID}'>{y}</span></td><td><a href=# OnClick='editid({r.ID})'>Editar</a>  <a href=# OnClick='delid({r.ID})'>Eliminar</a></td></tr>";
                    }
                    if(!IsPostBack)table.Text = tab;
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            SQLTrans.Restaurantes[] rest = client.GetRestaurantes();
            foreach (SQLTrans.Restaurantes r in rest)
            {
                HtmlContainerControl cx = FindControl("x"+r.ID) as HtmlContainerControl;
                HtmlContainerControl cy = FindControl("y" + r.ID) as HtmlContainerControl;
                string x = cx.InnerText;
                string y = cy.InnerText;
                int X = (x.Trim() == "") ? 0 : int.Parse(x);
                int Y = (y.Trim() == "") ? 0 : int.Parse(y);
                if (r.X != X || r.Y != Y) client.sp_AlterLocation(r.ID,X,Y);
            }
        }
    }
}