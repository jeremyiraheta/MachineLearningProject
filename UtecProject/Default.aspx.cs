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
            LoginData ldata = (LoginData)Session["userdata"];
            int inicio = 0;
            int fin = 10;            
            Platillos[] uplatillos = client.sp_UltimosPlatillos(inicio, fin);
            string splatillos = "";
            foreach (Platillos p in uplatillos)
            {
                splatillos += $"<div id='{p.ID_PLATILLOS}' class='clearfix post type-post status-publish format-standard has-post-thumbnail hentry'><div class='post-thumb'><a href='#' title='{p.NOMBRE}'>" +
                              $"<img src='{p.URL}' alt='{p.NOMBRE}' class='Thumbnail thumbnail loop ' width='180' height='155'></a></div><div class='details'><h2 class='title'><a href='Platillos.aspx?id={p.ID_PLATILLOS}' title='{p.NOMBRE}'>{p.NOMBRE}</a></h2>" +
                              $"<div class='entry'><p>{p.DESCRIPCION}</p></div><p><a href='Platillos.aspx?id={p.ID_PLATILLOS}' class='more-link'>Calificar</a></p></div><div class='cleaner'>&nbsp;</div></div>";
            }
            lastsdishes.InnerHtml = splatillos;
        }
        private string getDishSlide(int id, string nombre, string descripcion, string restaurante, string img, float rate)
        {
            string dish = $"<li class=\"post-{id}\" style=\"width: 100%; float: left; margin-right: -100%; position: relative; display: none;\">" +
                                "<div>" +
                                    "<div class=\"thumb\">" +
                                        $"<a href=\"Platillos.aspx?id={id}\" title=\"{nombre}\">" +
                                            $"<img src=\"{img}\" alt=\"{nombre}\" class=\"Thumbnail thumbnail featured \" width=\"600\" height=\"320\" /></a>" +
                                    "</div>" +
                                    $"<a href=\"Platillos.aspx?id={id}\" class=\"more-link\">Calificar</a>" +
                                    $"<h3 class=\"title\"><a href=\"Platillos.aspx?id={id}\" rel=\"bookmark\" title=\"{nombre}\">{nombre}</a></h3>" +
                                    "<div class=\"meta\">" +
                                        "<p><strong>" +
                                            "<img src=\"images/person.png\" />" +
                                            "Sirve:</strong> 2</p>" +
                                    "</div>" +
                                    "<div class=\"excerpt\">" +
                                        "<p>Texto de prueba. Texto de prueba. Texto de prueb. Texto de prueba. Texto de prueba […]</p>" +
                                    "</div>" +
                                "</div>" +
                            "</li>";

            return dish;
        }
    }

    
}