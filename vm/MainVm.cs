using CommonPublic;
using Microsoft.Expression.Interactivity.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BaiduImgDemo
{
    public partial class MainVm : baseVm
    {
        public static MainVm instance;
        static MainVm()
        {
            if (instance == null)
            {
                instance = new MainVm();
            }
        }

        MainVm()
        {
            LoadDataCmdFunc();
        }
        public baseCmd LoadCmd
        {
            get
            {
                return new baseCmd(() =>
                {
                    LoadDataCmdFunc();
                });
            }
        }
        public ActionCommand TitleFilterCmd
        {
            get
            {
                return new ActionCommand((o) =>
                {
                    TitleFilter = o.ToString();
                    Tag1 = o.ToString();
                    LoadDataCmdFunc();
                });
            }
        }

        public ActionCommand PageCmd
        {
            get
            {
                return new ActionCommand((o) =>
                {

                    switch (o.ToString())
                    {
                        case "0":
                            if (pageIndex > pageCount)
                                pageIndex = PageIndex - pageCount;
                            break;
                        case "1":
                            if (PageIndex < totalPage - pageCount)
                                pageIndex = PageIndex + pageCount;
                            break;
                    }
                    LoadDataCmdFunc();
                });
            }
        }
        public baseCmd PreviewShowCmd
        {
            get
            {
                return new baseCmd(() =>
                {
                    PreviewStatus = Visibility.Visible;
                });
            }
        }
        public baseCmd PreviewBtnCmd
        {
            get
            {
                return new baseCmd(() =>
                {
                    PreviewStatus = Visibility.Hidden;
                });
            }
        }

        public baseCmd CopyColorStrCmd
        {
            get
            {
                return new baseCmd(() =>
                {
                    Clipboard.SetDataObject(SelectedPreview.BackGroundStr, true);
                    TipMessageBox.Show("已经复制到剪贴板");
                });
            }
        }

        public baseCmd MinCmd
        {
            get
            {
                return new baseCmd(() =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                });
            }
        }
        public baseCmd CloseCmd
        {
            get
            {
                return new baseCmd(() =>
                {
                    Application.Current.Shutdown();
                });
            }
        }

        ObservableCollection<singleClassForPage> singlelist = new ObservableCollection<singleClassForPage>();
        string titleFilter;
        bool loadingActive = false;
        int pageIndex = 0;
        int pageCount = PageHelper.PageCount;
        int totalPage = 0;
        string tag1 = "设计";
        Visibility previewStatus = Visibility.Hidden;
        singleClassForPage selectedPreview = new singleClassForPage();
    }
}