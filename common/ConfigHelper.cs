using CommonPublic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduImgDemo
{
    class PageHelper
    {
        //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"RigourTech\ScreenConfig\Config");
        private static string iniFilePath = Path.Combine(Environment.CurrentDirectory, @"Config.ini"); 
        public static int PageCount
        {
            get
            {
                try
                {
                    string IsShowRotateImage = IniFileHelper.GetValue("PageConfig", "PageCount", iniFilePath);
                    return Convert.ToInt32(IsShowRotateImage);
                }
                catch
                {
                    return 1;
                }
            }
        }
    }
}
