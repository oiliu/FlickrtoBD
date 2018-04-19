using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace BaiduImgDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainVm.instance;
            this.MouseWheel += MainWindow_MouseWheel;
        }
        MainVm mainVm;
        private void MainWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (this.DataContext != null)
            {
                mainVm = DataContext as MainVm;
            }
            PreviewCommon.MouseWheelFunc(mainVm, e.Delta);
        }
    }
}
