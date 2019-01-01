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

    public string PrivacyPolicy = "<b>App Name:</b> Heart Centre<br/>" +
        "<b>Platforms:</b>Windows 10 devices (Fall Creators Update, April Update & October Update); Android 4.4-9.0 devices<br/>" +
        "<b>Publisher:</b> The Goofy Anatomist<br/>" +
        "<b>Effective Date:</b> 22 August 2016<br/>" +
        "<b>Updated On:</b> 12 December 2018<br/><br/>" +
        "<b>Policy:</b> The Goofy Anatomist respects your privacy. The Heart Centre app does not require you to input any personal data. You can, however, choose to send an email to The Goofy Anatomist using the link provided on the homescreen of the app. All emails received, and the email addresses from which they are sent, will be treated in such a way as to respect your privacy. Crash data, the number of users and the number of user sessions from this app may be collected using HockeyApp/App Center (all of this data is anonymous) and used to improve the performance of the app.​<br/><br/>By continuing to use the  Heart Centre app, you are in agreement with this Privacy Policy.<br/><br/>" +
        @"<b>Contact:</b> goofyanatomist@outlook.com";

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
        var mailto = new Uri("mailto:?to=goofyanatomist@outlook.com&subject=Question/Feedback on Heart Centre");
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
}
}
