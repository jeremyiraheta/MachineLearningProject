using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace PRProject
{
    /// <summary>
    /// Descripción breve de Locaciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Locaciones : System.Web.Services.WebService
    {

        [WebMethod]
       [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getLocations()
        {
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            List<Location> rest = new List<Location>();
            foreach (SQLTrans.Restaurantes item in client.GetRestaurantes())
            {
                if(item.X!=0 && item.Y!=0) rest.Add(new Location { ID = item.ID, NOMBRE = item.NOMBRE, REFERENCIA = item.REFERENCIA, X = item.X, Y = item.Y,URL=item.URL,RATE=item.URL });
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(rest.ToArray()));

        }
    }
    public class Location
    {
        public string ID { get; set; }
        public string NOMBRE { get; set; }
        public string REFERENCIA { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string URL { get; set; }
        public decimal RATE { get; set; }
    }
}
