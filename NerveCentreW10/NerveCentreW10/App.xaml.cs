using System;
using System.Linq;
using AppStudio.Uwp.Controls;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.Services;
using NerveCentreW10.Styles;
using NerveCentreW10.Views;
using Syncfusion.Licensing;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
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
            SyncfusionLicenseProvider.RegisterLicense("NTQ5NjU0QDMxMzkyZTM0MmUzMEZpanN2ak1zeWpNcEx3aWlrcEd3aDJQVk4xS09JS1dOWHpGU3ljSlVUdVE9");

            InitializeComponent();

            // TODO WTS: Add your app in the app center and set your secret here. More at https://docs.microsoft.com/en-us/appcenter/sdk/getting-started/uwp
            AppCenter.Start("68857c49-67e3-412d-a031-d3e447111cce", typeof(Analytics), typeof(Crashes));

            //VersionTracking.Track();
            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);

        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(ShellPage), args.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

    


    //protected override async void OnLaunched(LaunchActivatedEventArgs args)
    //{

    //    if (!args.PrelaunchActivated)
    //    {
    //        await ActivationService.ActivateAsync(args);
    //    }

    //    ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
    //    titleBar.ButtonBackgroundColor = Colors.Transparent;
    //    titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
    //    CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
    //    coreTitleBar.ExtendViewIntoTitleBar = true;

    //    //CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
    //    //coreTitleBar.ExtendViewIntoTitleBar = true;

    //    //var titleBar = ApplicationView.GetForCurrentView().TitleBar;

    //    //// Set active window colors
    //    //titleBar.ButtonBackgroundColor = Windows.UI.Colors.WhiteSmoke;


    //    Windows.UI.Color NCBlue = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#01acff");
    //    Windows.UI.Color NCOrange = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
    //    App.Current.Resources["SystemControlHighlightListAccentLowBrush"] = new SolidColorBrush(NCOrange);
    //    App.Current.Resources["SystemControlHighlightListAccentMediumBrush"] = new SolidColorBrush(NCBlue);
    //    App.Current.Resources["SystemControlHighlightAltAccentBrush"] = new SolidColorBrush(NCBlue);

    //    await Singleton<DevCenterNotificationsService>.Instance.InitializeAsync();

    //    VersionTracking.Track();

    //    //FontSizeChecker();

    //}

    public void FontSizeChecker()
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string localValue = (string)localSettings.Values["thefontsize"];

            if (localValue == null || localValue == "small")
            {
                Style style = (Style)App.Current.Resources["HTMLBlockTextStyle1"];
            }
            else if (localValue == null || localValue == "medium")
            {
                Application.Current.Resources["MyFontSize2"] = 20;
            }
            else if (localValue == null || localValue == "large")
            {
                Application.Current.Resources["MyFontSize2"] = 24;
            }


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

            //CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            //coreTitleBar.ExtendViewIntoTitleBar = true;



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
