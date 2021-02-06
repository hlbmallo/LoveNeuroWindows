using HeartCentreW104.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    public sealed partial class VideoIntro : ContentDialog
    {
        public VideoIntro()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            MyMPE.MediaPlayer.Pause();
            this.Hide();
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var cloudClass = new CloudClass();
            MyMPE.Source = MediaSource.CreateFromUri(new Uri(cloudClass.GetBlobSasUri("LoveNeuroAd.mp4")));
        }

    }
}
