using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class Fotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            Dictionary<int, string> fotos = new Dictionary<int, string>();
            fotos = client.getGallery();
            string outstring = "";
            foreach (int id in fotos.Keys)
            {
                outstring += "<dl class=\"gallery-item\">" +
            "<dt class=\"gallery-icon landscape\">" +
                $"<a href=\"Platos.aspx?={id}\"><img width=\"150\" height=\"150\" src=\"{fotos[id]}\" class=\"attachment-thumbnail size-thumbnail\" alt=\"\" srcset=\"\" sizes=\"(max-width: 150px) 100vw, 150px\"></a>" +
            "</dt></dl>";
            }
            gallery.InnerHtml = outstring;
        }
    }
}