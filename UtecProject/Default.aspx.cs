using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRProject.SQLTrans;
namespace PRProject
{
    public partial class Default : System.Web.UI.Page
    {
        CrudServiceClient client = new CrudServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int inicio = 0;
            int fin = 10;            
            Platillos[] uplatillos = client.sp_UltimosPlatillos(inicio, fin);
            string splatillos = "";
            foreach (Platillos p in uplatillos)
            {
                splatillos += $"<div id='{p.ID_PLATILLOS}' class='clearfix post type-post status-publish format-standard has-post-thumbnail hentry'><div class='post-thumb'><a href='#' title='{p.NOMBRE}'>" +
                              $"<img src='{p.URL}' alt='{p.NOMBRE}' class='Thumbnail thumbnail loop ' width='180' height='155'></a></div><div class='details'><h2 class='title'><a href='Platillos?id={p.ID_PLATILLOS}' title='{p.NOMBRE}'>{p.NOMBRE}</a></h2>" +
                              $"<div class='entry'><p>{p.DESCRIPCION}</p></div><p><a href='#' class='more-link'>Calificar</a></p></div><div class='cleaner'>&nbsp;</div></div>";
            }
            lastsdishes.InnerHtml = splatillos;
        }
    }
}