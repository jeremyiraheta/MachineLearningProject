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
            if(Request["offset"] == "2")
            {
                inicio += 10;
                fin += 10;
            }
            if (Request["offset"] == "3")
            {
                inicio += 20;
                fin += 20;
            }
            if (Request["offset"] == "4")
            {
                inicio += 30;
                fin += 30;
            }
            Platillos[] uplatillos = client.sp_UltimosPlatillos(inicio, fin);
            string splatillos = "";
            foreach (Platillos p in uplatillos)
            {
                splatillos += $"<div id='{p.ID_PLATILLOS}' class='clearfix post type-post status-publish format-standard has-post-thumbnail hentry'><div class='post-thumb'><a href='#' title='{p.NOMBRE}'>" +
                              $"<img src='{p.URL}' alt='{p.NOMBRE}' class='Thumbnail thumbnail loop ' width='180' height='155'></a></div><div class='details'><h2 class='title'><a href='Platos.aspx?id={p.ID_PLATILLOS}' title='{p.NOMBRE}'>{p.NOMBRE}</a></h2>" +
                              $"<div class='entry'><p>{p.DESCRIPCION}</p></div><p><a href='Platos.aspx?id={p.ID_PLATILLOS}' class='more-link'>Calificar</a></p></div><div class='cleaner'>&nbsp;</div></div>";
            }
            lastsdishes.InnerHtml = splatillos;
            Platillos[] rplatillos = ldata != null ? client.sp_RecomendarProductosPersonalizado(ldata.USER) : client.sp_RecomendarProductos();
            string nplatillos = "";
            Stack<Platillos> stk = new Stack<Platillos>();
            foreach (Platillos p in rplatillos)
            {
                nplatillos += getDishSlide(p.ID_PLATILLOS,p.NOMBRE,p.DESCRIPCION,p.RESTAURANTE,p.URL,Math.Round(p.RATE,2));
                stk.Push(p);
            }
            dishslider.InnerHtml = nplatillos;
            string pplatillos = "";            
            do
            {
                pplatillos += "<div class=\"row\">";
                Platillos p;
                if (stk.Count > 0)
                {
                    p = stk.Pop();
                    pplatillos += getCarrouselItem(p.ID_PLATILLOS, p.NOMBRE, p.URL);
                }
                if (stk.Count > 0)
                {
                    p = stk.Pop();
                    pplatillos += getCarrouselItem(p.ID_PLATILLOS, p.NOMBRE, p.URL);
                }
                if (stk.Count > 0)
                {
                    p = stk.Pop();
                    pplatillos += getCarrouselItem(p.ID_PLATILLOS, p.NOMBRE, p.URL);
                }
                pplatillos += "</div>" + (char)13;                
            } while (stk.Count > 0);
            c.InnerHtml = pplatillos;
        }
        private string getDishSlide(int id, string nombre, string descripcion, string restaurante, string img, decimal rate)
        {
            string dish = $"<li class=\"post-{id}\" style=\"width: 100%; float: left; margin-right: -100%; position: relative; display: none;\">" +
                                "<div>" +
                                    "<div class=\"thumb\">" +
                                        $"<a href=\"Platos.aspx?id={id}\" title=\"{nombre}\">" +
                                            $"<img src=\"{img}\" alt=\"{nombre}\" class=\"Thumbnail thumbnail featured \" width=\"600\" height=\"320\" /></a>" +
                                    "</div>" +
                                    $"<a href=\"Platos.aspx?id={id}\" class=\"more-link\">Calificar</a>" +
                                    $"<h3 class=\"title\"><a href=\"Platos.aspx?id={id}\" rel=\"bookmark\" title=\"{nombre}\">{nombre}</a></h3>" +
                                    "<div class=\"meta\">" +
                                        "<p><strong>" +
                                            "<img src=\"images/person.png\" />" +
                                            $"Restaurante:</strong> {restaurante}</p>" +
                                            "<p><strong>" +
                                            "<img src=\"images/difficulty.png\" />" +
                                            $"Rate:</strong> {rate}</p>" +
                                    "</div>" +
                                    "<div class=\"excerpt\">" +
                                        $"<p>{descripcion}</p>" +
                                    "</div>" +
                                "</div>" +
                            "</li>" + (char)13;

            return dish;
        }
        private string getCarrouselItem(int id, string nombre, string url)
        {
            string dish = "<div class=\"item\">"+
                                "<div class=\"thumb\">" +
                                    $"<a href=\"Platos.aspx?id={id}\" title=\"{nombre}\">" +
                                        $"<img src=\"{url}\" alt=\"{nombre}\" class=\"Thumbnail thumbnail carousel \" width=\"300\" height=\"200\" /></a>"+
                                "</div>"+
                                $"<h4 class=\"title\" style=\"min-height: 50px;\"><a href=\"Platos.aspx?id={id}\" rel=\"bookmark\" title=\"{nombre}\">{nombre}</a></h4>"+
                                "<div class=\"meta\">"+                                    
                                    "<p class=\"buttons\">"+
                                        $"<a href=\"Platos.aspx?id={id}\" class=\"more\">Calificar</a>"+
                                    "</p>"+
                                    "<div class=\"clear\"></div>"+
                                "</div>"+
                            "</div>" + (char)13;

            return dish;
        }
    }

    
}