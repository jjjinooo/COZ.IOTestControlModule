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

namespace COZ.IOControlApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        double OriginalWidth, OriginalHeight;
        ScaleTransform scale = new ScaleTransform();
        public MainWindow()
        {
            InitializeComponent();


            this.Loaded += new RoutedEventHandler(MainWindow_Load);
            Closing += MainWindow_Closing;
            this.StateChanged += MainWindow_StateChanged;

            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                // 창이 최소화되었을 때 특정 동작을 수행
                // 예: 최소화된 창 상태에서 특정 작업 수행
                // 실제로는 최소화된 창의 크기를 조정하는 것이 불가능합니다.
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("종료하시겠습니까?", "종료 확인", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // 종료 작업을 취소하여 창이 닫히지 않도록 설정
            }
            else
            {
                e.Cancel = false;
                Application.Current.Shutdown();
            }
        }

        //protected override void OnExit(ExitEventArgs e) => base.OnExit(e);


        void MainWinodw_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeSize(e.NewSize.Width, e.NewSize.Height);
        }

        void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            OriginalWidth = this.Width;
            OriginalHeight = this.Height;

            if (this.WindowState == WindowState.Maximized)
            {
                ChangeSize(this.ActualWidth, this.ActualHeight);
            }
            this.SizeChanged += new SizeChangedEventHandler(MainWinodw_SizeChanged);
        }

        private void ChangeSize(double width, double height)
        {
            scale.ScaleX = width / OriginalWidth; scale.ScaleY = height / OriginalHeight;
            FrameworkElement rootElement = this.Content as FrameworkElement;
            rootElement.LayoutTransform = scale;
        }
    }
}
