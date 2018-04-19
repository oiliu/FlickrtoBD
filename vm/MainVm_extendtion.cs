using CommonPublic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BaiduImgDemo
{
    public partial class MainVm : baseVm
    {
        internal async void LoadDataCmdFunc()
        {
            LoadingActive = true;
            instance?.SingleList?.Clear();
            LoadDataCommon.InitData(PageIndex, PageCount, Tag1);
            totalClass t = await LoadDataCommon.LoadData();
            if (t != null && t.data.Count > 0)
            {
                t.data.ForEach((o) =>
                {
                    if (!string.IsNullOrEmpty(o.image_url))
                    {
                        BitmapImage bit = new BitmapImage(new Uri(o.image_url, UriKind.RelativeOrAbsolute));
                        instance.SingleList.Add(
                            new singleClassForPage()
                            {
                                Desc = o.desc,
                                Image_data = bit,
                                Thumbnail_height = 60,  //220,250
                                Thumbnail_width = 60,
                                Image_url = o.image_url
                            });
                    }
                });
            }
            instance.totalPage = t.totalNum;
            LoadingActive = false;
        }

        SolidColorBrush GetAverageColor(BitmapImage bitm)
        {
            BitmapPixelHelper p = new BitmapPixelHelper(bitm);
            return new SolidColorBrush(p.GetAverageColor());
        }

        public ObservableCollection<singleClassForPage> SingleList
        {
            get
            {
                return singlelist;
            }

            set
            {
                singlelist = value;
                OnProperyChanged("SingleList");
            }
        }

        public string TitleFilter
        {
            get
            {
                return titleFilter;
            }

            set
            {
                titleFilter = value;
                OnProperyChanged("TitleFilter");
            }
        }
        public bool LoadingActive
        {
            get
            {
                return loadingActive;
            }

            set
            {
                loadingActive = value;
                OnProperyChanged("LoadingActive");
            }
        }

        public int PageIndex
        {
            get
            {
                return pageIndex;
            }

            set
            {
                pageIndex = value;
                OnProperyChanged("PageIndex");
            }
        }

        public int PageCount
        {
            get
            {
                return pageCount;
            }

            set
            {
                pageCount = value;
                OnProperyChanged("PageCount");
            }
        }

        public string Tag1
        {
            get
            {
                return tag1;
            }

            set
            {
                tag1 = value;
                OnProperyChanged("Tag1");
            }
        }

        public Visibility PreviewStatus
        {
            get
            {
                return previewStatus;
            }

            set
            {
                previewStatus = value;
                OnProperyChanged("PreviewStatus");
            }
        }

        public singleClassForPage SelectedPreview
        {
            get
            {
                return selectedPreview;
            }

            set
            {
                selectedPreview = value;
                OnProperyChanged("SelectedPreview");
            }
        }

        public void GetAverageColorByLocalFile()
        {
            singleClassForPage o = SelectedPreview;
            string localName = "";
            if (GlobalImageList.instance.ImageList.Count > 0 && o != null)
            {
                localName = GlobalImageList.instance.ImageList.Where(j => j.Item1 == ImageSave.GetFileName(o.Image_url)).LastOrDefault().Item2;
            }

            try
            {
                BitmapImage bit = new BitmapImage(new Uri(localName, UriKind.RelativeOrAbsolute));
                SolidColorBrush s = GetAverageColor(bit);
                SelectedPreview.BackGround = s;
            }
            catch
            {

            }
        }
    }
}
