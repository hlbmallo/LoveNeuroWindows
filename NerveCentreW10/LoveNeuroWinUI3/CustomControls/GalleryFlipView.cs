using LoveNeuroWinUI3.CustomControls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;


namespace LoveNeuroWinUI3.CustomControls
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
    }
}
