using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduImgDemo
{
    public class FileHelper
    {
        public static string tempDirectory = Environment.CurrentDirectory + "\\_temp\\";

        public static void DeleteFile()
        {
            if (Directory.Exists(tempDirectory))
            {
                Task.Run(() =>
                {
                    string[] files = Directory.GetFiles(tempDirectory);
                    if (files.Length > 0)
                    {
                        files.ToList().ForEach((o) =>
                        {
                            File.Delete(o);
                        });
                    }
                });
            }
        }
    }
}
