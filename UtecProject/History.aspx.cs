using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class History : System.Web.UI.Page
    {
        const string MSGNOGRANT = "No tienes permisos para ver este contenido";        
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
            int inicio = 1, fin = 10;
            if (Session["userdata"] != null)
            {
                SQLTrans.LoginData ldata = ((SQLTrans.LoginData)Session["userdata"]);
                if (Request["inicio"] != null && Request["fin"] != null)
                {
                    try
                    {
                        inicio = Convert.ToInt32(Request["inicio"]);
                        fin = Convert.ToInt32(Request["fin"]);
                    }
                    catch {
                        inicio = 0;
                        fin = 10;
                        output.Text = "Valores no validos en parametros!";
                    }
                }
                string logs = "";
                if (!ldata.isAdmin && Request["id"] == null)
                {
                    output.Text = MSGNOGRANT;
                }
                else
                {
                    foreach (SQLTrans.Logs l in client.GetLogs(ldata, inicio, fin))
                    {
                        string t = "";
                        switch (l.TIPO)
                        {
                            case 'C': t = "Creacion"; break;
                            case 'U': t = "Actualizacion"; break;
                            case 'D': t = "Eliminacion"; break;
                            default: t = "Desconocido"; break;
                        }
                        logs += $"<tr><td>{l.ID_USUARIO}</td><td>{t}</td><td>{l.TABLA}</td><td>{DateTime.Parse(l.CREACION).ToShortDateString()}</td></tr>";
                    }
                    string h = "";
                    if (inicio - 10 < 0)
                        h = "display:none;";
                    logs += $"<tr><td><a style='text-align:right;{h}' href=History.aspx?inicio={inicio-10}&fin={fin-10}>Anterior</a></td><td></td><td></td><td style='text-align:right;'><a href=History.aspx?inicio={inicio+10}&fin={fin+10}>Siguiente</a></td></tr>";
                    tbody.InnerHtml = logs;
                }
            }
        }
    }
}