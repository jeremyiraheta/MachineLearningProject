using System;
using System.IO;


namespace PRProject.clases
{
    public class Tools
    {
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