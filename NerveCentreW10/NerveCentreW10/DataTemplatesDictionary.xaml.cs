using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NerveCentreW10.Models;
using Microsoft.Toolkit;
using Microsoft.Toolkit.Parsers;
using Microsoft.Toolkit.Uwp.UI;
using NerveCentreW10.Views;
using Newtonsoft.Json;
using Windows.Storage;
using NerveCentreW10.ViewModels;
using System.Numerics;

namespace NerveCentreW10
{
    public partial class DataTemplatesDictionary
    {
        public DataTemplatesDictionary()
        {
            this.InitializeComponent();
        }

        FrameworkElement preElement = null;

        private void MyGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;
            AnimationBuilder.Create().Scale(1.05, 1, null, TimeSpan.FromMilliseconds(400), null, EasingType.Quintic).CenterPoint(Axis.X, preElement.Width/2).CenterPoint(Axis.Y, preElement.Height/2).StartAsync(preElement);
        }

        private void MyGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;
            AnimationBuilder.Create().Scale(1, 1.05, null, TimeSpan.FromMilliseconds(400), null, EasingType.Quintic).CenterPoint(Axis.X, preElement.Width / 2).CenterPoint(Axis.Y, preElement.Height / 2).StartAsync(preElement);

        }

        private void MyGrid_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;
            AnimationBuilder.Create().Scale(1, 1.05, null, TimeSpan.FromMilliseconds(400), null, EasingType.Quintic).CenterPoint(Axis.X, preElement.Width / 2).CenterPoint(Axis.Y, preElement.Height / 2).StartAsync(preElement);
        }

        private void MyGrid_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;
            AnimationBuilder.Create().Scale(1, 1.05, null, TimeSpan.FromMilliseconds(400), null, EasingType.Quintic).CenterPoint(Axis.X, preElement.Width / 2).CenterPoint(Axis.Y, preElement.Height / 2).StartAsync(preElement);
        }

        private void MyGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;
            AnimationBuilder.Create().Scale(1.07, 1.05, null, TimeSpan.FromMilliseconds(400), null, EasingType.Quintic).CenterPoint(Axis.X, preElement.Width / 2).CenterPoint(Axis.Y, preElement.Height / 2).StartAsync(preElement);
        }

        private void MyGrid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            //    preElement = sender as FrameworkElement;

        }

       
    }
}
