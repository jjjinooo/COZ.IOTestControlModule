using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;


namespace IoModule.Control.TabControl
{
    [TemplatePart(Name = "ToggleRactangle", Type = typeof(Rectangle))]
    [TemplatePart(Name = "ToggleEllipse", Type = typeof(Ellipse))]

    public class TabControl : ToggleButton
    {
        #region Icon Fields Setting
        private Rectangle _backRectangle = new Rectangle();
        private Ellipse _dot = new Ellipse();
        private Thickness LeftSide = new Thickness(-39, 0, 0, 0);
        private Thickness RightSide = new Thickness(0, 0, -39, 0);
        #endregion

        private static int _toggleCount = 0;
        public static int ToggleCount
        {
            get { return _toggleCount; }
            set { _toggleCount = value; }
        }

        // public int CurrentToggleCount = 0;
        private int _currentToggleCount = 0;
        public int CurrentToggleCount
        {
            get { return _currentToggleCount; }
            set { _currentToggleCount = value; }
        }





        #region On Apply Template . 컨트롤 호출 될때 마다 실행.
        /// <summary>
        /// 사용자 정의 컨트롤을 만들 때 종종 해당 컨트롤의 모양과 동작을 정의하는 템플릿.. 
        /// OnApplyTemplate 메서드는 이러한 템플릿이 컨트롤에 적용될 때 호출. 
        /// 이 메서드를 사용하여 컨트롤의 템플릿에서 요소를 참조하고 초기화하는 작업을 수행 할 수 있다.
        /// </summary>
        public override void OnApplyTemplate()
        {
            _backRectangle = GetTemplateChild("ToggleRactangle") as Rectangle;
            _dot = GetTemplateChild("ToggleEllipse") as Ellipse;

            if (_dot != null)
                _dot.MouseLeftButtonDown += DotOnMouseLeftButtonDown;

            if (_backRectangle != null)
                _backRectangle.MouseLeftButtonDown += BackRectangleOnMouseLeftButtonDown;

            Loaded += OnLoaded;
            // Unloaded += OnUnloaded;

            _toggleCount++;
            CurrentToggleCount = _toggleCount;

        }
        #endregion

        #region EventHandlers
        /// <summary>
        /// Ractangle Mouse left Button Down Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BackRectangleOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsChecked)
            {
                IsChecked = !IsChecked;
                IsCheckCommand?.Execute(false);
                //IsCheckCommand = "off";
            }
            else
            {
                IsChecked = !IsChecked;
                IsCheckCommand?.Execute(true);
                //IsCheckCommand = "On";
            }


            IsCurrentToggleCheck?.Execute(CurrentToggleCount);
        }

        /// <summary>
        /// Ellipse Mouse left Button Down Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DotOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsChecked)
            {
                IsChecked = !IsChecked;
                IsCheckCommand?.Execute(false);
                //IsCheckCommand = "off";
            }
            else
            {
                IsChecked = !IsChecked;
                IsCheckCommand?.Execute(true);
                //IsCheckCommand = "On";
            }


            IsCurrentToggleCheck?.Execute(CurrentToggleCount);
        }

        public void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoaded;
            if (_dot != null)
                _dot.MouseLeftButtonDown -= DotOnMouseLeftButtonDown;

            if (_backRectangle != null)
                _backRectangle.MouseLeftButtonDown -= BackRectangleOnMouseLeftButtonDown;

            Unloaded -= OnUnloaded;
            _toggleCount = 0;
        }

        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_backRectangle != null)
                _backRectangle.Fill = OffBackgroundColor;

            if (_dot != null)
                _dot.Margin = LeftSide;

            IsChecked = false;
            //_toggleCount++;
        }
        #endregion

        static TabControl()
        {
            // 이 속성은 주로 컨트롤 클래스 내에서 컨트롤의 기본 스타일 키를 지정하는 데 사용.
            // 스타일 키를 지정하면 해당 컨트롤의 스타일을 테마별로 또는 사용자 정의로 정의 가능.
            // 기본적으로 컨트롤은 자체의 기본 스타일을 가지고 있다.
            // 그러나 이 스타일을 변경하거나 사용자 정의 스타일을 만들려면 DefaultStyleKey 속성을 사용하여 스타일 키를 설정 해야 사용 가능.
            // DefaultStyleKeyProperty는 이러한 목적으로 사용.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabControl), new FrameworkPropertyMetadata(typeof(TabControl)));

            // 위의 코드에서 DefaultStyleKeyProperty를 사용하여 ToggleSwitchControl 의 기본 스타일 키를 ToggleSwitchControl로 설정한다. \
            // 이렇게 하면 프레임워크는 해당 스타일 키를 사용하여 기본 스타일 리소스를 찾고 컨트롤의 스타일을 적용한다.
        }




        #region DependencyProperty
        #region OffBackgroundColor
        public SolidColorBrush OffBackgroundColor
        {
            get { return (SolidColorBrush)GetValue(OffBackgroundColorProperty); }
            set { SetValue(OffBackgroundColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OffBackgroundColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffBackgroundColorProperty =
            DependencyProperty.Register(
                "OffBackgroundColor",
                typeof(SolidColorBrush),
                typeof(TabControl),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(160, 160, 160))));
        #endregion

        #region OnBackgroundColor
        public SolidColorBrush OnBackgroundColor
        {
            get { return (SolidColorBrush)GetValue(OnBackgroundColorProperty); }
            set { SetValue(OnBackgroundColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnBackgroundColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnBackgroundColorProperty =
            DependencyProperty.Register(
                "OnBackgroundColor",
                typeof(SolidColorBrush),
                typeof(TabControl),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(130, 190, 125))));
        #endregion

        #region IsChecked Define.
        public new bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        #endregion

        #region toggle Change Event DependencyProperty Setting
        // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
        public static new readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(
                "IsChecked",                                                                                                                 // 종속 속성의 name 
                typeof(bool),                                                                                                                // 종속 속성 데이터 형식
                typeof(TabControl),                                                                                                 // 종속 속성을 소유한 클래스의 형식.
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChangedCallback));       // 종속 속성의 기본 값.

        public static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is TabControl) || !(e.NewValue is bool))
                return;

            var switchControl = d as TabControl;

            if ((bool)e.NewValue)
            {
                switchControl._backRectangle.Fill = switchControl.OnBackgroundColor;
                switchControl._dot.Margin = switchControl.RightSide;
            }
            else
            {
                switchControl._backRectangle.Fill = switchControl.OffBackgroundColor;
                switchControl._dot.Margin = switchControl.LeftSide;
            }
        }
        #endregion

        #region IsCheckCommand
        public RelayCommand<bool> IsCheckCommand
        {
            get { return (RelayCommand<bool>)GetValue(IsCheckCommandProperty); }
            set { SetValue(IsCheckCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCheckCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckCommandProperty =
            DependencyProperty.Register(
                "IsCheckCommand",
                typeof(RelayCommand<bool>),
                typeof(TabControl));
        #endregion


        #region IsCheckCount
        public RelayCommand<int> IsCurrentToggleCheck
        {
            //get { return CurrentToggleCount; }
            get { return (RelayCommand<int>)GetValue(IsToggleCheckedProperty); }
            set { SetValue(IsToggleCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsToggleCheckedProperty =
            DependencyProperty.Register(
                "IsCurrentToggleCheck",
                typeof(RelayCommand<int>),
                typeof(TabControl)
                );//,                                                                                               
                  // new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChangedCallback));     
        #endregion
        #endregion
    }
}
