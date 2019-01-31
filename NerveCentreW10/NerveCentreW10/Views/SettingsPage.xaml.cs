using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        // To get application's name:
        public string ApplicationName => SystemInformation.ApplicationName;

        // To get application's version:
        public string ApplicationVersion => $"{SystemInformation.ApplicationVersion.Major}.{SystemInformation.ApplicationVersion.Minor}.{SystemInformation.ApplicationVersion.Build}.{SystemInformation.ApplicationVersion.Revision}";

        public SettingsPage()
        {
            this.InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);

            AppName.Text = ApplicationName;
            AppVersion.Text = ApplicationVersion;
            AppIconsList.Source = @"• <a href=""http://www.freepik.com"">Freepik (CC 3.0 BY)</a><br/>• <a href=""http://www.flaticon.com"">Flaticon (CC 3.0 BY)</a><br/>• <a href=""http://www.icons8.com"">Icons8 (CC 3.0 BY)</a><br/>• <a href=""http://www.flaticon.com/authors/chris-veigt"">Chris Veigt (CC 3.0 BY)</a><br/>• <a href=""http://www.flaticon.com/authors/icon-works"">Icon Works (CC 3.0 BY)</a><br/>• <a href=""http://www.flaticon.com/authors/madebyoliver"">Madebyoliver (CC 3.0 BY)</a><br/>• <a href=""https://www.flaticon.com/authors/smashicons"">Smashicons (CC 3.0 BY)</a>";
        }

        private async void RateButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri($"ms-windows-store://review/?ProductId=9wzdncrcs92r"));
        }

        private async void EmailSupport_Click(object sender, RoutedEventArgs e)
        {
            var mailto = new Uri("mailto:?to=goofyanatomist@outlook.com&subject=Neuroscience Question (LoveNeuro on Windows)");
            await Windows.System.Launcher.LaunchUriAsync(mailto);
        }

        private async void EmailCorrection_Click(object sender, RoutedEventArgs e)
        {
            var mailto = new Uri("mailto:?to=goofyanatomist@outlook.com&subject=Neuroscience Correction/Idea (LoveNeuro on Windows)");
            await Windows.System.Launcher.LaunchUriAsync(mailto);
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

        private async void PrivacyPolicyLink_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://thegoofyanatomist.weebly.com/privacy-policy-loveneuro.html"));
        }
    }
}
