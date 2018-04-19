using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaiduImgDemo
{
    public class PreviewCommon
    {
        public static void MouseWheelFunc(MainVm mainVm,int delta)
        {
            if (mainVm.PreviewStatus == Visibility.Visible)
            {
                //向前
                if (delta > 0)
                {
                    int i = mainVm.SingleList.IndexOf(mainVm.SelectedPreview) - 1;
                    if (i >= 0)
                        mainVm.SelectedPreview = mainVm.SingleList[i];
                }
                //向后
                else if (delta < 0)
                {
                    int i = mainVm.SingleList.IndexOf(mainVm.SelectedPreview) + 1;
                    if (i < mainVm.PageCount)
                        mainVm.SelectedPreview = mainVm.SingleList[i];
                }
                mainVm.GetAverageColorByLocalFile();
            }
        }
    }
}
