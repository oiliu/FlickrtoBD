using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace BaiduImgDemo
{
    class ImageSave
    {
        public static string GetFileName(string url)
        {
            string fileName = url.Substring(url.LastIndexOf("/") + 1, url.Length - url.LastIndexOf("/") - 1);
            return fileName;
        }
        public static void Save(string url, BitmapImage m)
        {
            string fileName = GetFileName(url);
            Bitmap bmp =
                new Bitmap(m.PixelWidth, m.PixelHeight, PixelFormat.Format32bppPArgb);

            BitmapData data = bmp.LockBits(
            new Rectangle(System.Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);

            m.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);
            string path = FileHelper.tempDirectory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string localName = Path.Combine(path + fileName);
            bmp.Save(localName);
            GlobalImageList.instance.ImageList.Add(Tuple.Create(fileName, localName));
        }
    }
}
