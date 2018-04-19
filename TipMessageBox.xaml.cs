using CommonPublic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BaiduImgDemo
{
    /// <summary>
    /// TipMessageBox.xaml 的交互逻辑
    /// </summary>
    public sealed partial class TipMessageBox : Window, INotifyPropertyChanged
    {
        public TipMessageBox()
        {
            InitializeComponent();
            Loaded += TipMessageBox_Loaded;
        }

        private void TipMessageBox_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = SystemParameters.MaximizedPrimaryScreenWidth;
            timerStatus = true;
            SelfClose();
        }

        public static void Show(string str, Window owner = null)
        {
            TipMessageBox t = new TipMessageBox();
            t.Owner = owner == null ? Application.Current.MainWindow : owner;
            t.TipContent.Text = str;
            t.ShowDialog();
        }

        bool timerStatus = false;
        int timerCount = 0;
        private bool windowStatus = true;

        public event PropertyChangedEventHandler PropertyChanged;

        void SelfClose()
        {
            Task.Run(() =>
            {
                while (timerStatus)
                {
                    timerCount++;
                    Thread.Sleep(100);
                    if (timerCount == 20)
                    {
                        WindowStatus = false;
                        Thread.Sleep(500);
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            timerStatus = false;
                            timerCount = 0;
                            Close();
                        }));
                    }
                }
            });
        }

        public bool WindowStatus
        {
            get
            {
                return windowStatus;
            }

            set
            {
                windowStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WindowStatus"));
            }
        }
    }
}
