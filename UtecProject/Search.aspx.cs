using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            SQLTrans.LoginData ldata = (SQLTrans.LoginData)Session["userdata"];
            string text = Request["s"];
            if (text != "")
            {
                string platillos = "";
                string tipo = Request["tipo"];
                foreach (SQLTrans.Platillos p in client.buscarPlatillo(text))
                {
                    if (tipo != null)
                        if (Convert.ToInt32(tipo) != p.ID_TIPO)
                            continue;
                    platillos += string.Concat("<tr><td><img src='", (p.URL == null || p.URL == "") ? "/images/sin-imagen.gif" : p.URL, "' height='200px' width='200px' /></td><td>", p.NOMBRE, "</td><td>", p.TIPO, "</td><td>", p.RESTAURANTE, "</td><td>$", Math.Round(p.PRECIO, 2), "</td><td><a href=Platos.aspx?id=", p.ID_PLATILLOS, ">Ver</a>&emsp;");
                    if (ldata != null)
                        if (ldata.isAdmin)
                            platillos += string.Concat("<a href=Platos.aspx?id=", p.ID_PLATILLOS, "&action=edit>Editar</a>&emsp;<a href=Platos.aspx?id=", p.ID_PLATILLOS, "&action=delete OnClick=\"if ( ! UserDeleteConfirmation()) return false;\">Eliminar</a></td></tr>\n");

                }
                tbody.InnerHtml = platillos;
            }
        }
    }
}