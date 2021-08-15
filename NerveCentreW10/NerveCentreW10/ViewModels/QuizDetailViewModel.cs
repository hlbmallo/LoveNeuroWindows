using Azure.Storage.Blobs;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Commands;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.MyData;
using NerveCentreW10.Services;
using NerveCentreW10.Views;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NerveCentreW10.ViewModels
{
    public class QuizDetailViewModel : BaseViewModel
    {
        public RelayCommand ViewScoresCommand { get; set; }
        public RelayCommand NextCommand { get; set; }
        public RelayCommand PrevCommand { get; set; }
        public RelayCommand SubmitButtonCommand { get; set; }
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
                    this.OnPropertyChanged("rootobject");
                }
            }
        }

        private int mySelectedIndex;
        public int MySelectedIndex
        {
            get { return this.mySelectedIndex; }
            set
            {
                if (this.mySelectedIndex != value)
                {
                    this.mySelectedIndex = value;
                    this.OnPropertyChanged("MySelectedIndex");
                }
            }
        }

        public QuizDetailViewModel()
        {
            ViewScoresCommand = new RelayCommand(ViewScoresEvent);
               NextCommand = new RelayCommand(NextEvent);
            PrevCommand = new RelayCommand(PrevEvent);
            SubmitButtonCommand = new RelayCommand(SubmitButtonEvent);
        }

        private void ViewScoresEvent()
        {
            NavigationService.Navigate(typeof(ViewScores));
        }

        private void NextEvent()
        {
            if (MySelectedIndex == 9)
            {

            }
            else
            {
                MySelectedIndex += 1;
            }
        }

        private void PrevEvent()
        {
            if (MySelectedIndex == 0)
            {

            }
            else
            {
                MySelectedIndex -= 1;
            }
        }

        public void OnNavTo(NavigationEventArgs e)
        {
            CloudClass cloudClass = new CloudClass();
            var MyClickedItem = (QuizListClass)e.Parameter;
            mySubsection = QuizzesObsCollectionClass.QuizListList.FirstOrDefault(m => m.QuizId == Uri.UnescapeDataString(MyClickedItem.QuizId));
            var jsonFromCloud = ReadFully(mySubsection.QuizFile);
            var temp1 = JsonConvert.DeserializeObject<ObservableCollection<QuizClass>>(jsonFromCloud);
            rootobject = temp1;
            if (mySubsection.QuizImage == null)
            {
                //Grid.SetColumnSpan(MyListView, 2);
            }
            else
            {
                //MyImage.Source = cloudClass.GetBlobSasUri(vM.mySubsection.QuizImage);
            }
        }

        public static string ReadFully(string blobUriAndSasToken)
        {
            var cloudClass = new CloudClass();

            BlobClient cloudBlockBlob = new BlobClient(new Uri(cloudClass.GetBlobSasUri(blobUriAndSasToken)));

            using (var stream = cloudBlockBlob.OpenReadAsync().Result)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        

        public async void LoadedPage()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            if (await storageFolder.FileExistsAsync("obsCollection.txt") == true)
            {

            }
            else
            {
                var obsCollection = new ObservableCollection<QuizScore>();
                var temp1 = JsonConvert.SerializeObject(obsCollection);
                var contentToSaveToFile = await storageFolder.WriteTextToFileAsync(temp1, "obsCollection.txt");
            }
        }

        private async void SubmitButtonEvent()
        {
            MySelectedIndex = 0;

            foreach (QuizClass item in rootobject)
            {

                if (item.QA == item.ANS && item.QAIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
                    item.ANSIsVisible = true;

                }

                else if (item.QB == item.ANS && item.QBIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
                    item.ANSIsVisible = true;

                }

                else if (item.QC == item.ANS && item.QCIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
                    item.ANSIsVisible = true;

                }

                else if (item.QD == item.ANS && item.QDIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Green);
                    item.ANSIsVisible = true;

                }
                else
                {
                    item.QCORRECT = "Incorrect";
                    item.QCOLOR = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Red);
                    item.ANSIsVisible = true;

                }
            }


            var dialog = new ContentDialog();
            dialog.Content = "Your overall score is: " + OverallScore;
            dialog.PrimaryButtonText = "Ok";
            dialog.SecondaryButtonText = "Save score";
            dialog.PrimaryButtonCommand = new RelayCommand(PrimaryButtonEvent);
            dialog.SecondaryButtonCommand = new RelayCommand(SecondaryButtonEvent);
            await dialog.ShowAsync();

        }

        private async void SecondaryButtonEvent()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var temp1 = await storageFolder.GetFileAsync("obsCollection.txt");
            string temp2 = await Windows.Storage.FileIO.ReadTextAsync(temp1);
            var temp3 = JsonConvert.DeserializeObject<ObservableCollection<QuizScore>>(temp2);


            var contentToDeserialise = new QuizScore()
            {
                MyScore = OverallScore,
                MyDateForThatScore = DateTime.Now,
                QuizName = mySubsection.QuizName,
                MyScoreInPercent = rootobject.Count,
            };

            temp3.Add(contentToDeserialise);

            var temp4 = JsonConvert.SerializeObject(temp3);
            var contentToSaveToFile = await storageFolder.WriteTextToFileAsync(temp4, "obsCollection.txt");

            OverallScore = 0;
        }

        private void PrimaryButtonEvent()
        {
            OverallScore = 0;
        }
    }
}
