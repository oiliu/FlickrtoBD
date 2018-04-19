using CommonPublic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BaiduImgDemo
{
    public class singleClassForPage : baseVm
    {
        private int thumbnail_width;
        private int thumbnail_height;
        private string desc;
        private string image_url;
        private BitmapImage image_data;
        SolidColorBrush backGround =
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#006EDD"));
        string backGroundStr = "#006EDD";

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

        public SolidColorBrush BackGround
        {
            get
            {
                return backGround;
            }

            set
            {
                BackGroundStr = value.ToString();
                backGround = value;
                OnProperyChanged("BackGround");
            }
        }

        public string Image_url
        {
            get
            {
                return image_url;
            }

            set
            {
                image_url = value;
                OnProperyChanged("Image_url");
            }
        }

        public string BackGroundStr
        {
            get
            {
                return backGroundStr;
            }

            set
            {
                backGroundStr = value;
                OnProperyChanged("BackGroundStr");
            }
        }
    }
}
