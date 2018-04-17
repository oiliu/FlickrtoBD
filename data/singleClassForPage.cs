using CommonPublic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BaiduImgDemo
{
    public class singleClassForPage : baseVm
    {
        private int thumbnail_width;
        private int thumbnail_height;
        private string desc;
        private BitmapImage image_data;

        public string Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
                OnProperyChanged("Desc");
            }
        }

        public BitmapImage Image_data
        {
            get
            {
                return image_data;
            }

            set
            {
                image_data = value;
                OnProperyChanged("Image_data");
            }
        }

        public int Thumbnail_width
        {
            get
            {
                return thumbnail_width;
            }

            set
            {
                thumbnail_width = value;
                OnProperyChanged("Thumbnail_width");
            }
        }

        public int Thumbnail_height
        {
            get
            {
                return thumbnail_height;
            }

            set
            {
                thumbnail_height = value;
                OnProperyChanged("Thumbnail_height");
            }
        }
    }
}
