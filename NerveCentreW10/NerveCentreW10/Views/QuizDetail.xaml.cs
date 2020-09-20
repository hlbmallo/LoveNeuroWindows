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
using System.Drawing;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Windows.Storage;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using System.IO;
using System.Globalization;
using HeartCentreW104.Helpers;
using Microsoft.Azure.Storage.Blob;
using NerveCentreW10.MyData;
using System.Linq;

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
        public QuizListClass mySubsection { get; set; }

        public ObservableCollection<QuizScore> quizScores { get; set; }
        private Color colorSwatch1;
        private Color colorSwatch2;
        private Color colorSwatch3;
        private Color colorSwatch4;

        public Color ColorSwatch1
        {
            get { return this.colorSwatch1; }
            set
            {
                this.colorSwatch1 = value;
                this.OnPropertyChanged();
            }
        }
        public Color ColorSwatch2
        {
            get { return this.colorSwatch2; }
            set
            {
                this.colorSwatch2 = value;
                this.OnPropertyChanged();
            }
        }
        public Color ColorSwatch3
        {
            get { return this.colorSwatch3; }
            set
            {
                this.colorSwatch3 = value;
                this.OnPropertyChanged();
            }
        }
        public Color ColorSwatch4
        {
            get { return this.colorSwatch4; }
            set
            {
                this.colorSwatch4 = value;
                this.OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public QuizDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            CloudClass cloudClass = new CloudClass();

            var MyClickedItem = (QuizListClass)e.Parameter;
            Title.Text = MyClickedItem.QuizNumber + " " + MyClickedItem.QuizName;
            mySubsection = QuizzesObsCollectionClass.QuizListList.FirstOrDefault(m => m.QuizId == Uri.UnescapeDataString(MyClickedItem.QuizId));

            if (mySubsection.QuizImage == null)
            {
            }
            else
            {
                MyImage.Source = cloudClass.GetBlobSasUri(mySubsection.QuizImage);
            }

            var jsonFromCloud = ReadFully(mySubsection.QuizFile);
            var rootobject = JsonConvert.DeserializeObject<List<QuizClass>>(jsonFromCloud);
            MyListView.ItemsSource = rootobject;

            //FileIOHelper oFileHelper = new FileIOHelper();
            //List<QuizClass> lstSettingInfo = oFileHelper.ReadFromDefaultFile(MyClickedItem.QuizFile);
            //List<QuizClass> oSettingsObserv = new List<QuizClass>(lstSettingInfo);
            //MyListView.ItemsSource = oSettingsObserv;

            //if (MyClickedItem.QuizImage == null)
            //{
            //    MyImage.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    MyImage.Source = MyClickedItem.QuizImage;
            //}

            //Title.Text = MyClickedItem.QuizNumber + " " + MyClickedItem.QuizName;

            // Save complex/large objects 
            //var helper = new RoamingObjectStorageHelper();
            //string keyLargeObject = MyClickedItem.QuizId;

            //var o = new QuizListClass
            //{
            //    QuizId = MyClickedItem.QuizId,
            //    QuizName = MyClickedItem.QuizName,
            //    QuizNumber = MyClickedItem.QuizNumber,
            //    QuizImage = MyClickedItem.QuizImage,
            //    QuizFile = MyClickedItem.QuizFile,
            //};

            //await helper.SaveFileAsync(keyLargeObject, o);


            //UserActivityChannel channel = UserActivityChannel.GetDefault();
            //UserActivity activity = await channel.GetOrCreateUserActivityAsync("ln" + o.QuizId);

            //activity.ActivationUri = new Uri("loveneuro://" + o.QuizId);
            //activity.VisualElements.DisplayText = o.QuizNumber + " " + o.QuizName;

            //activity.VisualElements.Content = Helpers.AdaptiveCardCreation.CreateAdaptiveCardWithoutImage(MyClickedItem.QuizNumber + " " + MyClickedItem.QuizName);
            //Windows.UI.Color color = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
            //activity.VisualElements.BackgroundColor = color;

            //await activity.SaveAsync();

            //_currentSession?.Dispose();

            //_currentSession = activity.CreateSession();

        }

        public static string ReadFully(string blobUriAndSasToken)
        {
            var cloudClass = new CloudClass();
            CloudBlockBlob cloudBlockBlob = new CloudBlockBlob(new Uri(cloudClass.GetBlobSasUri(blobUriAndSasToken)));

            using (var stream = cloudBlockBlob.OpenReadAsync().Result)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
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

            var dialog = new ContentDialog();
            dialog.Content = "Your overall score is: " + OverallScore;
                dialog.PrimaryButtonText = "Ok";
            dialog.SecondaryButtonText = "Save score";
            dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
            dialog.SecondaryButtonClick += Dialog_SecondaryButtonClick;
            await dialog.ShowAsync();

        }

        private async void Dialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var helper = new RoamingObjectStorageHelper();
            var temp1 = await helper.ReadFileAsync<ObservableCollection<QuizScore>>("obsCollection.txt");

            var contentToDeserialise = new QuizScore()
            {
                MyScore = OverallScore,
                MyDateForThatScore = DateTime.Now,
                QuizName = Title.Text,
                MyScoreInPercent = MyListView.Items.Count,
      
        };

            temp1.Add(contentToDeserialise);



            await helper.SaveFileAsync("obsCollection.txt", temp1);
            OverallScore = 0;
        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            OverallScore = 0;
        }

        private void RevealHideAnswersButton_Checked(object sender, RoutedEventArgs e)
        {

            foreach (QuizClass item in MyListView.Items)
            {
                if (item.QA == item.ANS && item.QAIsActive == true)
                {
                    item.QCorrect = "Correct";
                }

                else if (item.QB == item.ANS && item.QBIsActive == true)
                {
                    item.QCorrect = "Correct";
                }

                else if (item.QC == item.ANS && item.QCIsActive == true)
                {
                    item.QCorrect = "Correct";
                }

                else if (item.QD == item.ANS && item.QDIsActive == true)
                {
                    item.QCorrect = "Correct";
                }
                //else
                //{
                //    item.QCorrect = "Incorrect";
                //}
            }

            RevealHideAnswersButton.Content = "Hide Answers";
        }

        private void RevealHideAnswersButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RevealHideAnswersButton.Content = "Show Answers";
        }

        private void ViewScoresButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewScores));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {


            var helper = new RoamingObjectStorageHelper();

            var checkIfExistsFile = await helper.FileExistsAsync("obsCollection.txt");
            if (checkIfExistsFile == true)
            {

            }
            else
            {
                var obsCollection = new ObservableCollection<QuizScore>();
                var contentToSaveToFile = await helper.SaveFileAsync("obsCollection.txt", obsCollection);
            }


        }
    }
}
