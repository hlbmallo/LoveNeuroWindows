using NerveCentreW10.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Helpers;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using HeartCentreW104.Helpers;
using Microsoft.Azure.Storage.Blob;
using NerveCentreW10.MyData;
using System.Linq;
using Windows.UI;
using NerveCentreW10.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuizDetail : Page
    {
        public int OverallScore;
        public QuizListClass mySubsection { get; set; }
        public ObservableCollection<QuizScore> quizScores { get; set; }
        private ObservableCollection<QuizClass> _rootobject;
        public ObservableCollection<QuizClass> rootobject
        {
            get { return this._rootobject; }
            set
            {
                if (this._rootobject != value)
                {
                    this._rootobject = value;
                    this.NotifyPropertyChanged("rootobject");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
                Grid.SetColumnSpan(MyListView, 2);
            }
            else
            {
                MyImage.Source = cloudClass.GetBlobSasUri(mySubsection.QuizImage);
            }

            var jsonFromCloud = ReadFully(mySubsection.QuizFile);
            var temp1 = JsonConvert.DeserializeObject<ObservableCollection<QuizClass>>(jsonFromCloud);
            rootobject = temp1;
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
            MyListView.SelectedIndex = 9;

            foreach (QuizClass item in rootobject)
            {
                item.ANSIsVisible = true;

                if (item.QA == item.ANS && item.QAIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
                }

                else if (item.QB == item.ANS && item.QBIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
                }

                else if (item.QC == item.ANS && item.QCIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
                }

                else if (item.QD == item.ANS && item.QDIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
                }
                else
                {
                    item.QCORRECT = "Incorrect";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Red);
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
                MyScoreInPercent = rootobject.Count,
      
        };

            temp1.Add(contentToDeserialise);



            await helper.SaveFileAsync("obsCollection.txt", temp1);
            OverallScore = 0;
        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            OverallScore = 0;
        }

        //private void RevealHideAnswersButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    MyListView.SelectedIndex = 0;

        //    foreach (var item in rootobject)
        //    {
        //        if (item.QA == item.ANS && item.QAIsActive == true)
        //        {
        //        }

        //        else if (item.QB == item.ANS && item.QBIsActive == true)
        //        {
        //            item.QCORRECT = "Correct";
        //            item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
        //        }

        //        else if (item.QC == item.ANS && item.QCIsActive == true)
        //        {
        //            item.QCORRECT = "Correct";
        //            item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
        //        }

        //        else if (item.QD == item.ANS && item.QDIsActive == true)
        //        {
        //            item.QCORRECT = "Correct";
        //            item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
        //        }

        //        else
        //        {
        //            item.QCORRECT = "Incorrect";
        //            item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Red);
        //        }
        //    }

        //    RevealHideAnswersButton.Content = "Hide Answers";
        //    MyListView.SelectedIndex = 0;

        //}

        //private void RevealHideAnswersButton_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    RevealHideAnswersButton.Content = "Show Answers";
        //}

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

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyListView.SelectedIndex == 0)
            {

            }
            else
            {
                MyListView.SelectedIndex -= 1;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

            if (MyListView.SelectedIndex == 9)
            {

            }
            else
            {
                MyListView.SelectedIndex += 1;
            }
        }
    }
}
