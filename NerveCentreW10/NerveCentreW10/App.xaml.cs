using System;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.Services;
using NerveCentreW10.Views;
using Syncfusion.Licensing;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Essentials;

namespace NerveCentreW10
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense("NDgyMDI4QDMxMzkyZTMyMmUzME05U2kyYnJYK3ZtOGtHUWI1bmR6SzRrL0VlR1BBbjV3RE1yRmFIUVloYk09;NDgyMDI5QDMxMzkyZTMyMmUzMG5TSnBvb3BkbkhIVzVyRFU3UTZ1SW5RQnRRQVAyVmE5aUpvMjhvWnZSOFE9");

            InitializeComponent();

            // TODO WTS: Add your app in the app center and set your secret here. More at https://docs.microsoft.com/en-us/appcenter/sdk/getting-started/uwp
            AppCenter.Start("68857c49-67e3-412d-a031-d3e447111cce", typeof(Analytics), typeof(Crashes));

            //VersionTracking.Track();
            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);

        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            //CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            //coreTitleBar.ExtendViewIntoTitleBar = true;

            //var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            //// Set active window colors
            //titleBar.ButtonBackgroundColor = Windows.UI.Colors.WhiteSmoke;


            Windows.UI.Color NCBlue = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#01acff");
            Windows.UI.Color NCOrange = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
            App.Current.Resources["SystemControlHighlightListAccentLowBrush"] = new SolidColorBrush(NCOrange);
            App.Current.Resources["SystemControlHighlightListAccentMediumBrush"] = new SolidColorBrush(NCBlue);
            App.Current.Resources["SystemControlHighlightAltAccentBrush"] = new SolidColorBrush(NCBlue);

            await Singleton<DevCenterNotificationsService>.Instance.InitializeAsync();

            VersionTracking.Track();

            //FontSizeChecker();

        }

        public void FontSizeChecker()
        {
            //ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            //string localValue = (string)localSettings.Values["thefontsize"];

            //if(localValue == null || localValue == "small")
            //{
            //    Application.Current.Resources["thefontsizeresource"] = 16.0;
            //}
            //else if (localValue == null || localValue == "medium")
            //{
            //    Application.Current.Resources["thefontsizeresource"] = 20.0;
            //}
            //else if (localValue == null || localValue == "large")
            //{
            //    Application.Current.Resources["thefontsizeresource"] = 24.0;
            //}


            //if (localValue == 16)
            //{
            //    Application.Current.Resources["MyFontSize2"] = 16;
            //}
            //else if (localValue == 16)
            //{
            //    Application.Current.Resources["MyFontSize2"] = 20;
            //}
            //else if (localValue == 16)
            //{
            //    Application.Current.Resources["MyFontSize2"] = 24;
            //}
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);

            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;



            //Windows.UI.Color NCBlue = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#01acff");
            //Windows.UI.Color NCOrange = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
            //App.Current.Resources["SystemControlHighlightListAccentLowBrush"] = new SolidColorBrush(NCOrange);
            //App.Current.Resources["SystemControlHighlightListAccentMediumBrush"] = new SolidColorBrush(NCBlue);
            //App.Current.Resources["SystemControlHighlightAltAccentBrush"] = new SolidColorBrush(NCBlue);

            

            //if (args.Kind == ActivationKind.Protocol)
            //{
            //    ProtocolActivatedEventArgs uriArgs = args as ProtocolActivatedEventArgs;

            //    if (uriArgs != null)
            //    {
            //        var helper = new RoamingObjectStorageHelper();
            //        string keyLargeObject = uriArgs.Uri.Host;

            //        if (await helper.FileExistsAsync(keyLargeObject))
            //        {
            //            var subsectionContent = await helper.ReadFileAsync<SubsectionModel>(keyLargeObject);
            //            var quizContent = await helper.ReadFileAsync<QuizListClass>(keyLargeObject);
            //            var videoTutorialsContent = await helper.ReadFileAsync<VideoTutorialsClass>(keyLargeObject);

            //            if (uriArgs.Uri.Host == subsectionContent.PageId)
            //            {
            //                NavigationService.Navigate(typeof(DetailPage), subsectionContent);
            //                Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + subsectionContent.Title);
            //            }
            //            else if (uriArgs.Uri.Host == quizContent.QuizId)
            //            {
            //                NavigationService.Navigate(typeof(QuizDetail), quizContent);
            //                Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + quizContent.QuizName);
            //            }
            //            else if (uriArgs.Uri.Host == videoTutorialsContent.VideoTutorialsPageId)
            //            {
            //                NavigationService.Navigate(typeof(VideoTutorialsDetail), videoTutorialsContent);
            //                Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + videoTutorialsContent.VideoTutorialsName);
            //            }
            //        }

            //        else if (uriArgs.Uri.Host == "section60")
            //        {
            //            NavigationService.Navigate(typeof(Section6InkingZoneMenu));
            //            Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + "Quizzes Section");
            //        }
            //        else if (uriArgs.Uri.Host == "section80")
            //        {
            //            NavigationService.Navigate(typeof(Section8MoreResources));
            //            Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + "More Resources Section");
            //        }
            //        else
            //        {
            //            NavigationService.Navigate(typeof(MainPage));
            //            Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + "Default");
            //        }

            //    }

            //    await Singleton<DevCenterNotificationsService>.Instance.InitializeAsync();


                Window.Current.Activate();
                base.OnActivated(args);
            
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.MainPage), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
