using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRProject
{
    public partial class rating : System.Web.UI.UserControl
    {
        int id = -1;
        SQLTrans.CrudServiceClient client = new SQLTrans.CrudServiceClient();
        SQLTrans.LoginData ldata = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["id"], out id);
            ldata = ((SQLTrans.LoginData)Session["userdata"]);  
            if(!IsPostBack)
            {
                int v = 0;
                if (ldata == null) return;
                v = client.GetValoracion(ldata.USER, id);
                switch(v)
                {
                    case 1:
                        star1.Checked = true;
                        break;
                    case 2:
                        star2.Checked = true;
                        break;
                    case 3:
                        star3.Checked = true;
                        break;
                    case 4:
                        star4.Checked = true;
                        break;
                    case 5:
                        star5.Checked = true;
                        break;
                    default:
                        star1.Checked = false;
                        star2.Checked = false;
                        star3.Checked = false;
                        star4.Checked = false;
                        star5.Checked = false;
                        break;
                }
            }
        }

        protected void star5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                client.sp_AgregarValoracion(ldata, id.ToString(), 5);
            }
            catch {}
        }

        protected void star4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                client.sp_AgregarValoracion(ldata, id.ToString(), 4);
            }
            catch { }
        }

        protected void star3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                client.sp_AgregarValoracion(ldata, id.ToString(), 3);
            }
            catch { }
        }

        protected void star2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                client.sp_AgregarValoracion(ldata, id.ToString(), 2);
            }
            catch { }
        }

        protected void star1_CheckedChanged(object sender, EventArgs e)
        {
            client.sp_AgregarValoracion(ldata, id.ToString(), 1);
        }
    }
}