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
