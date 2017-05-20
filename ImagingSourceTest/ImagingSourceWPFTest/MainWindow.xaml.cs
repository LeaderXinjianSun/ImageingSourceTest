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
using System.Windows.Forms;
using System.Windows.Threading;

namespace ImagingSourceWPFTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myICImagingControlWFM.LoadDevice = !myICImagingControlWFM.LoadDevice;
        }

        private void myICImagingControlWFM_Loaded(object sender, RoutedEventArgs e)
        {
            myICImagingControlWFM.StartLive = !myICImagingControlWFM.StartLive;
        }
        private delegate void DeviceLostDelegate();
        private void myICImagingControlWFM_DeviceLost(object sender, RoutedEventArgs e)
        {
            var dispatcher = System.Windows.Application.Current.MainWindow.Dispatcher;
            dispatcher.BeginInvoke(new DeviceLostDelegate(ref DeviceLost));
        }
        private void DeviceLost()
        {
            //icImagingControl1.Device = "";
            System.Windows.Forms.MessageBox.Show("Device Lost!");
            //cmdLive.Text = "Start Live";
            //cmdLive.Enabled = false;
            //cmdProperties.Enabled = false;
        }
    }
}
