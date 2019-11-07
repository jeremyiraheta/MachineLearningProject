using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
namespace PRProject
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                    new ScriptResourceDefinition
                    {
                                    Path = "~/js/jquery.lazy.min.js",
                        DebugPath = "~/js/jquery.js",
                        CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.4.min.js",
                        CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.12.4.js"
                });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        public static string ImgName(string filename, string path)
        {
            string ret = filename;
            string ext = filename.Substring(filename.LastIndexOf('.') + 1);
            while (File.Exists(Path.Combine(path, ret)))
                ret = "IMG_" + new Random(DateTime.Now.Millisecond).Next() + "." + ext;
            return ret;
        }
    }
}