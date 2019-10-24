using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prototipo
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userdata"] != null)
            {                
                user.InnerText = ((SQLTrans.LoginData)Session["userdata"]).USER;
                user.HRef = "~/" + user.InnerText;
            }
        }
    }
}