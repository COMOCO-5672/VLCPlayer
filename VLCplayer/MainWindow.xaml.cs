using System;
using System.Collections.Generic;
using System.IO;
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

namespace VLCplayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.VlcControl.Loaded += VlcControl_Loaded;
        }

        void
            VlcControl_Loaded(object sender, RoutedEventArgs e)
        {
            VlcControl_LoadVideo("E:\\迅雷下载\\公主日记I_hd.mp4");
        }

        void 
            VlcControl_LoadVideo(string videoPath)
        {
            var currentDir = AppDomain.CurrentDomain.BaseDirectory;
            var VlcDir = System.IO.Path.Combine(currentDir, "VLC");

            var VlcLibDirectory = new DirectoryInfo(VlcDir);

            var options=new string[]
            {

            };
            VlcControl.SourceProvider.CreatePlayer(VlcLibDirectory, options);
            VlcControl.SourceProvider.MediaPlayer.Play(new Uri(videoPath));
        }

        void
            OnForwardBtnClick()
        {

        }

        void
            ForwordBtn_Click(object sender, RoutedEventArgs e)
        {
            VlcControl.SourceProvider.MediaPlayer.Rate = 2;
        }
    }
}
