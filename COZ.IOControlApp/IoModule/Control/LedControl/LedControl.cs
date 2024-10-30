using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace IoModule.Control.LedControl
{
    public class LedControl : UserControl
    {
        #region Case 1

        public LedControl()
        {
            SizeChanged += ColorLightControl_SizeChanged;
        }

        public void ColorLightControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LightRadius = ActualWidth < ActualHeight ? ActualWidth : ActualHeight;
        }

        public double CircularThickness
        {
            get { return (double)GetValue(CircularThicknessProperty); }
            set { SetValue(CircularThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CircularThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CircularThicknessProperty =
            DependencyProperty.Register("CircularThickness", typeof(double), typeof(LedControl), new PropertyMetadata(0.0));

        public double LightRadius
        {
            get { return (double)GetValue(LightRadiusProperty); }
            set { SetValue(LightRadiusProperty, value); }
        }

        public static readonly DependencyProperty LightRadiusProperty =
            DependencyProperty.Register("LightRadius", typeof(double), typeof(LedControl), new PropertyMetadata(0.1));

        public string OuterName
        {
            get { return (string)GetValue(OuterNameProperty); }
            set { SetValue(OuterNameProperty, value); }
        }

        public static readonly DependencyProperty OuterNameProperty =
            DependencyProperty.Register(
                "OuterName",
                typeof(string),
                typeof(LedControl)
                );

        public int State
        {
            get { return (int)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register(
                "State",
                typeof(int),
                typeof(LedControl),
                new PropertyMetadata(0, OnStateChanged)
                );

        public static void OnStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LedControl light)
            {
                if (e.NewValue is int index)
                {
                    if (light.ColorList.Count > index)
                    {
                        light.CurrentLight = light.ColorList.ElementAt(index);
                        return;
                    }
                }

                //light.CurrentLight = Brushes.LightGray;
            }
        }

        public IList<Brush> ColorList
        {
            get { return (IList<Brush>)GetValue(ColorListProperty); }
            set { SetValue(ColorListProperty, value); }
        }

        public static readonly DependencyProperty ColorListProperty =
            DependencyProperty.Register(
                "ColorList",
                typeof(IList<Brush>),
                typeof(LedControl),
                new PropertyMetadata(OnColorListChanged) //{ Brushes.LightGray, Brushes.Lime }, OnColorListChanged)
                );

        public static void OnColorListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LedControl light)
            {
                if (e.NewValue is IList<Brush> colorList && colorList != null)
                {
                    if (colorList.Count > light.State)
                    {
                        light.CurrentLight = colorList.ElementAt(light.State);
                        return;
                    }
                }
                // light.CurrentLight = Brushes.LightGray;
            }
        }

        public Brush CurrentLight
        {

            get { return (Brush)GetValue(CurrentLightProperty); }
            set { SetValue(CurrentLightProperty, value); }
        }

        public static readonly DependencyProperty CurrentLightProperty =
            DependencyProperty.Register(
                "CurrentLight",
                typeof(Brush),
                typeof(LedControl)
                //, new PropertyMetadata(Brushes.LightGray)
                );


        #endregion



        #region Case 2

        //#region Dependency properties
        ///// <summary>Dependency property to Get/Set the current IsActive (True/False)</summary>
        //public static readonly DependencyProperty IsCheckedProperty =
        //    DependencyProperty.Register("IsChecked", typeof(bool?), typeof(LedLightControl),
        //        new PropertyMetadata(null, new PropertyChangedCallback(LedLightControl.IsCheckedPropertyChanced)));
        //
        ///// <summary>Dependency property to Get/Set Color when IsActive is true</summary>
        //public static readonly DependencyProperty ColorProperty =
        //    DependencyProperty.Register("Color", typeof(Color), typeof(LedLightControl),
        //        new PropertyMetadata(Colors.Green, new PropertyChangedCallback(LedLightControl.OnColorPropertyChanged)));
        //
        //public static readonly DependencyProperty CurrentLightProperty =
        //        DependencyProperty.Register(
        //            "CurrentLight", 
        //            typeof(Brush), 
        //            typeof(LedLightControl)
        //            //, new PropertyMetadata(Brushes.LightGray)
        //            );
        //#endregion
        //
        //#region Properties
        ///// <summary>Gets/Sets Value</summary>
        //public bool? IsChecked 
        //{
        //    get { return (bool?)GetValue(IsCheckedProperty); }
        //    set { SetValue(IsCheckedProperty, value); }
        //}
        ///// <summary>Gets/Sets Color</summary>
        //public Color Color 
        //{ 
        //    get { return (Color)GetValue(ColorProperty); }
        //    set { SetValue(ColorProperty, value); } 
        //}
        //
        //public Brush CurrentLight
        //{
        //    get { return (Brush)GetValue(CurrentLightProperty); }
        //    set { SetValue(CurrentLightProperty, value); }
        //}
        //#endregion
        //
        //#region Constructor
        //public LedLightControl()
        //{
        //    this.IsChecked = false;
        //    if (this.IsChecked == true)
        //    {
        //        Color = Color.FromArgb(255,255,255,255);
        //        CurrentLight = new SolidColorBrush(Colors.GreenYellow);
        //    }
        //    else if (this.IsChecked == false)
        //    {
        //        Color = Color.FromArgb(255, 255, 255, 255);
        //        CurrentLight = new SolidColorBrush(Colors.Gray);
        //    }
        //}
        //
        //#endregion
        //
        //#region Callbacks
        //
        //private static void IsCheckedPropertyChanced(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    LedLightControl led = (LedLightControl)d;
        //
        //    
        //    if (led.IsChecked == true)
        //    {
        //        led.Color = Color.FromArgb(255, 255, 255, 255);
        //        led.CurrentLight = new SolidColorBrush(Colors.GreenYellow);
        //    }
        //    else
        //    {
        //        led.Color = Color.FromArgb(255, 255, 255, 255);
        //        led.CurrentLight = new SolidColorBrush(Colors.Gray);
        //        // led.LEDColor.Color = Colors.Gray;   // TODO calculate dark/gray color
        //    }
        //}
        //
        //private static void OnColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    LedLightControl led = (LedLightControl)d;
        //    led.Color = (Color)e.NewValue;
        //    if (led.IsChecked == true)
        //    {
        //        led.Color = Color.FromArgb(255, 255, 255, 255);
        //    }
        //    else
        //    {
        //        led.Color = Color.FromArgb(0, 0, 0, 0);
        //    }
        //}
        //
        //#endregion
        #endregion
    }
}
