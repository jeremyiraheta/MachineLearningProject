using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Users : System.Web.UI.Page
    {
        const string MSGNOGRANT = "<center><div color=red><h1>No tienes permisos para ver este contenido</h1></div></center>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
                if(!ldata.isAdmin && Request["id"] == null)
                {
                    output.Text = MSGNOGRANT;
                }else if(Request["id"] != null)
                {
                    string userdata = "<h1>Datos del usuario: " + ldata.USER  + "</h1>";
                    SQLTrans.Usuarios user = new SQLTrans.CrudServiceClient().GetUsuarios(ldata.USER)[0];
                    userdata += "<table style='border: solid 2px; '>";
                    userdata += $"<tr>< td colspan = 2 ><img src={user.URL}></img></ td ></ tr > ";
                    userdata += $"< tr >< td style = 'padding: 10px 20px 0px 20px' >Nombre: </td><td>{user.NOMBRE}</td></tr>";
                    userdata += $"< tr >< td style = 'padding: 10px 20px 0px 20px' >Apellido: </td><td>{user.APELLIDO}</td></tr>";
                    userdata += $"< tr >< td style = 'padding: 10px 20px 0px 20px' >Correo: </td><td>{user.CORREO_ELECTRONICO}</td></tr>";
                    userdata += $"< tr >< td style = 'padding: 10px 20px 0px 20px' >Nacimiento: </td><td>{user.FECHA_CUMPLE}</td></tr>";
                    userdata += $"< tr >< td style = 'padding: 10px 20px 0px 20px' >Visitas: </td><td>{user.VISITAS}</td></tr>";
                    userdata += $"< tr >< td style = 'padding: 10px 20px 0px 20px' >Admin: </td><td>{user.VISITAS}</td></tr>";
                    output.Text = $"<div style='padding: 55px 25 % 37px'>{userdata}</table></div>";
                }
            }
        }
    }
}