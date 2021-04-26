using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace NerveCentreW10.CustomControls
{
    public sealed class GalleryFlipView : FlipView
    {
        public static readonly DependencyProperty IsFlipEnabledProperty =
            DependencyProperty.Register("IsFlipEnabled", typeof(bool), typeof(GalleryFlipView), new PropertyMetadata(true, IsFlipEnabledChanged));

        private static void IsFlipEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is GalleryFlipView control)
            {
                if (control.GetTemplateChild("ScrollingHost") is ScrollViewer scrollViewer)
                {
                    scrollViewer.HorizontalScrollMode = control.IsFlipEnabled ? ScrollMode.Auto : ScrollMode.Disabled;
                }

                if (control.ContainerFromItem(control.SelectedItem) is GalleryFlipViewItem flipViewItem)
                {
                    flipViewItem.IsFlipEnabled = control.IsFlipEnabled;
                }
            }
        }

        public bool IsFlipEnabled
        {
            get { return (bool)GetValue(IsFlipEnabledProperty); }
            set { SetValue(IsFlipEnabledProperty, value); }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new GalleryFlipViewItem
            {
                IsFlipEnabled = this.IsFlipEnabled
            };
        }

        //protected override void OnManipulationInertiaStarting(ManipulationInertiaStartingRoutedEventArgs e)
        //{
        //    e.Handled = !this.IsFlipEnabled;

        //    base.OnManipulationInertiaStarting(e);
        //}


        //protected override void OnManipulationDelta(ManipulationDeltaRoutedEventArgs e)
        //{
        //    e.Handled = !this.IsFlipEnabled;

        //    base.OnManipulationDelta(e);
        //}


        //protected override void OnManipulationStarted(ManipulationStartedRoutedEventArgs e)
        //{
        //    e.Handled = !this.IsFlipEnabled;

        //    base.OnManipulationStarted(e);
        //}
    }
}
