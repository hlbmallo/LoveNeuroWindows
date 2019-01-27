using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NerveCentreW10.Views
{
    public sealed partial class FirstRunDialog : ContentDialog
    {
        public string HelloMessage = "This educational app has been designed by a student, for students, with the aim of teaching neuroscience in a clear, concise and easy-to-understand way. I'd love to hear what you think about LoveNeuro, so please feel free to rate and review the app in the Microsoft Store. Thanks for your support.<br/>";

        public FirstRunDialog()
        {
            // TODO WTS: Update the contents of this dialog with any important information you want to show when the app is used for the first time.
            RequestedTheme = (Window.Current.Content as FrameworkElement).RequestedTheme;
            InitializeComponent();
        }
    }
}
