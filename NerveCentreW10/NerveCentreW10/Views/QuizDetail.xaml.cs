using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.ApplicationModel.UserActivities;
using NerveCentreW10.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuizDetail : Page
    {
        public int OverallScore;

        private UserActivitySession _currentSession;

        public QuizDetail()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            QuizListClass MyClickedItem = (QuizListClass)e.Parameter;

            FileIOHelper oFileHelper = new FileIOHelper();
            List<QuizClass> lstSettingInfo = oFileHelper.ReadFromDefaultFile(MyClickedItem.QuizFile);
            List<QuizClass> oSettingsObserv = new List<QuizClass>(lstSettingInfo);
            MyListView.ItemsSource = oSettingsObserv;

            if (MyClickedItem.QuizImage == null)
            {
                MyImage.Visibility = Visibility.Collapsed;
            }
            else
            {
                MyImage.Source = MyClickedItem.QuizImage;
            }

            Title.Text = MyClickedItem.QuizNumber + " " + MyClickedItem.QuizName;

            // Save complex/large objects 
            var helper = new LocalObjectStorageHelper();
            string keyLargeObject = MyClickedItem.QuizId;

            var o = new QuizListClass
            {
                QuizId = MyClickedItem.QuizId,
                QuizName = MyClickedItem.QuizName,
                QuizNumber = MyClickedItem.QuizNumber,
                QuizImage = MyClickedItem.QuizImage,
                QuizFile = MyClickedItem.QuizFile,
            };

            await helper.SaveFileAsync(keyLargeObject, o);

            //this.RegisterElementForConnectedAnimation("key", MyImage);

            // Get channel and create activity.
            UserActivityChannel channel = UserActivityChannel.GetDefault();
            UserActivity activity = await channel.GetOrCreateUserActivityAsync("ln" + o.QuizId);

            // Set deep-link and properties.
            activity.ActivationUri = new Uri("loveneuro://" + o.QuizId);
            activity.VisualElements.DisplayText = o.QuizNumber + " " + o.QuizName;

            // Create and set Adaptive Card.
            activity.VisualElements.Content = Helpers.AdaptiveCardCreation.CreateAdaptiveCardWithoutImage(MyClickedItem.QuizNumber + " " + MyClickedItem.QuizName);
            Windows.UI.Color color = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
            activity.VisualElements.BackgroundColor = color;

            // Save to activity feed.
            await activity.SaveAsync();

            // Create a session, which indicates that the user is engaged
            // in the activity.
            _currentSession?.Dispose();

            _currentSession = activity.CreateSession();

        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (QuizClass item in MyListView.Items)
            {
                if (item.QA == item.ANS && item.QAIsActive == true)
                {
                    OverallScore += 1;
                }

                else if (item.QB == item.ANS && item.QBIsActive == true)
                {
                    OverallScore += 1;
                }

                else if (item.QC == item.ANS && item.QCIsActive == true)
                {
                    OverallScore += 1;
                }

                else if (item.QD == item.ANS && item.QDIsActive == true)
                {
                    OverallScore += 1;
                }
            }

            var dialog = new MessageDialog("Overall Score: " + OverallScore);
            await dialog.ShowAsync();

            OverallScore = 0;
        }

        private void RevealHideAnswersButton_Checked(object sender, RoutedEventArgs e)
        {
            RevealHideAnswersButton.Content = "Hide Answers";
        }

        private void RevealHideAnswersButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RevealHideAnswersButton.Content = "Show Answers";
        }
    }
}
