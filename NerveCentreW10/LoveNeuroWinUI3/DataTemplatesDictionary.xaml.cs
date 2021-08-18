
using Microsoft.UI.Xaml;
using System.Numerics;

namespace LoveNeuroWinUI3
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

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.04f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.4f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);
        }

        private void MyGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.00f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);

            //    preElement = sender as FrameworkElement;

            //    var control = preElement.FindDescendant("MyGrid2");
            //    control.Scale(centerX: 150f, centerY: 100f, scaleX: 1.0f, scaleY: 1.0f,
            //                duration: 200, delay: 0, easingType: EasingType.Default).Start();

            //    var control2 = preElement.FindDescendant("MyDropShadow");
            //    control2.Fade(value: 0.0f, duration: 500, delay: 0).Start();
        }

        private void MyGrid_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.0f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);
        }

        private void MyGrid_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.0f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);
        }

        private void MyGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.02f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);
        }

        private void MyGrid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            //    preElement = sender as FrameworkElement;

        }

       
    }
}
