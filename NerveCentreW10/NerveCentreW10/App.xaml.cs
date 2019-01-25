﻿using System;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.Services;
using NerveCentreW10.Views;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

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
            InitializeComponent();

            // TODO WTS: Add your app in the app center and set your secret here. More at https://docs.microsoft.com/en-us/appcenter/sdk/getting-started/uwp
            AppCenter.Start("{Your App Secret}", typeof(Analytics), typeof(Crashes));

            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }

            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            await Singleton<DevCenterNotificationsService>.Instance.InitializeAsync();

        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);

            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            if (args.Kind == ActivationKind.Protocol)
            {
                ProtocolActivatedEventArgs uriArgs = args as ProtocolActivatedEventArgs;

                if (uriArgs != null)
                {
                    var helper = new LocalObjectStorageHelper();
                    string keyLargeObject = uriArgs.Uri.Host;

                    if (await helper.FileExistsAsync(keyLargeObject))
                    {
                        var subsectionContent = await helper.ReadFileAsync<SubsectionModel>(keyLargeObject);
                        var quizContent = await helper.ReadFileAsync<QuizListClass>(keyLargeObject);
                        var videoTutorialsContent = await helper.ReadFileAsync<VideoTutorialsClass>(keyLargeObject);

                        if (uriArgs.Uri.Host == subsectionContent.PageId)
                        {
                            NavigationService.Navigate(typeof(DetailPage), subsectionContent);
                            Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + subsectionContent.Title);
                        }
                        else if (uriArgs.Uri.Host == quizContent.QuizId)
                        {
                            NavigationService.Navigate(typeof(QuizDetail), quizContent);
                            Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + quizContent.QuizName);
                        }
                        else if (uriArgs.Uri.Host == videoTutorialsContent.VideoTutorialsPageId)
                        {
                            NavigationService.Navigate(typeof(VideoTutorialsDetail), videoTutorialsContent);
                            Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + videoTutorialsContent.VideoTutorialsName);
                        }
                    }

                    else if (uriArgs.Uri.Host == "section60")
                    {
                        NavigationService.Navigate(typeof(Section6InkingZoneMenu));
                        Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + "Quizzes Section");
                    }
                    else if (uriArgs.Uri.Host == "section80")
                    {
                        NavigationService.Navigate(typeof(Section8MoreResources));
                        Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + "More Resources Section");
                    }
                    else
                    {
                        NavigationService.Navigate(typeof(MainPage));
                        Analytics.TrackEvent(this.GetType().Name + " (Timeline): " + "Default");
                    }

                }

                await Singleton<DevCenterNotificationsService>.Instance.InitializeAsync();


                //Window.Current.Activate();
                //base.OnActivated(args);
            }
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
