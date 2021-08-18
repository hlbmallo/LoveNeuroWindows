using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace LoveNeuroWinUI3.CustomControls
{
    public sealed class GalleryFlipViewItem : FlipViewItem
    {
        public bool IsFlipEnabled { get; set; }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            e.Handled = !this.IsFlipEnabled;

            base.OnKeyDown(e);
        }

        protected override void OnPointerWheelChanged(PointerRoutedEventArgs e)
        {
            e.Handled = !this.IsFlipEnabled;

            base.OnPointerWheelChanged(e);
        }
    }
}
