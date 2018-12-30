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
using Microsoft.Toolkit.Uwp.UI.Extensions;

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

            var control = preElement.FindDescendantByName("MyGrid2");
            control.Scale(centerX: 150f, centerY: 100f, scaleX: 1.04f, scaleY: 1.04f,
                        duration: 200, delay: 0, easingType: EasingType.Default).Start();

            var control2 = preElement.FindDescendantByName("MyDropShadow");
            control2.Fade(value: 0.4f, duration: 500, delay: 0).Start();
        }

        private void MyGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendantByName("MyGrid2");
            control.Scale(centerX: 150f, centerY: 100f, scaleX: 1.0f, scaleY: 1.0f,
                        duration: 200, delay: 0, easingType: EasingType.Default).Start();

            var control2 = preElement.FindDescendantByName("MyDropShadow");
            control2.Fade(value: 0.0f, duration: 500, delay: 0).Start();
        }

        private void MyGrid_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendantByName("MyGrid2");
            control.Scale(centerX: 150f, centerY: 100f, scaleX: 1.0f, scaleY: 1.0f,
                        duration: 200, delay: 0, easingType: EasingType.Default).Start();

            var control2 = preElement.FindDescendantByName("MyDropShadow");
            control2.Fade(value: 0.0f, duration: 500, delay: 0).Start();
        }

        private void MyGrid_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendantByName("MyGrid2");
            control.Scale(centerX: 150f, centerY: 100f, scaleX: 1.0f, scaleY: 1.0f,
                        duration: 200, delay: 0, easingType: EasingType.Default).Start();

            var control2 = preElement.FindDescendantByName("MyDropShadow");
            control2.Fade(value: 0.0f, duration: 500, delay: 0).Start();
        }

        private void MyGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendantByName("MyGrid2");
            control.Scale(centerX: 150f, centerY: 100f, scaleX: 1.02f, scaleY: 1.02f,
            duration: 200, delay: 0, easingType: EasingType.Default).Start();
        }

        private void MyGrid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

        }
    }
}
