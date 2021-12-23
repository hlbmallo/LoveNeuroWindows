using NerveCentreW10.Helpers;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.Media.Core;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NerveCentreW10.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            CloudClass cloudClass = new CloudClass();
            welcomeImage.Source = cloudClass.GetBlobSasUri("LN15.png");
            welcomeImage2.Source = cloudClass.GetBlobSasUri("LN16.png");

            //welcomeText.Source = "This educational app has been designed by a student, for students, with the aim of teaching neuroscience in a clear, concise and easy - to - understand way.I'd love to hear what you think about LoveNeuro, so please feel free to rate and review the app in the Microsoft Store. Thanks for your support.<br/>";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var videoIntro = new VideoIntro();
            await videoIntro.ShowAsync();
        }

        private async void RateAndReviewButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri($"ms-windows-store://review/?ProductId=9NBLGGGZLR7B"));
        }

        private void TeachTip1_CloseButtonClick(Microsoft.UI.Xaml.Controls.TeachingTip sender, object args)
        {

        }

        private void MyMPE_Loaded(object sender, RoutedEventArgs e)
        {
            CloudClass cloudClass = new CloudClass();
            MyMPE.Source = MediaSource.CreateFromUri(new Uri(cloudClass.GetBlobSasUri("LoveNeuroAdV2.mp4")));
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            MyMPE.MediaPlayer.Pause();
        }
    }
}
