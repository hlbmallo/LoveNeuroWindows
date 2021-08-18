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
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Essentials;

namespace NerveCentreW10.ViewModels
{
    public class QuizDetailViewModel : BaseViewModel
    {
        public RelayCommand ViewScoresCommand { get; set; }
        public RelayCommand NextCommand { get; set; }
        public RelayCommand PrevCommand { get; set; }
        public RelayCommand SubmitButtonCommand { get; set; }
        public int OverallScore;
        private QuizListClass _mySubsection;
        public QuizListClass mySubsection
        {
            get { return _mySubsection; }
            set
            {
                if (_mySubsection != value)
                {
                    _mySubsection = value;
                    OnPropertyChanged("mySubsection");
                }
            }
        }
        public ObservableCollection<QuizScore> quizScores { get; set; }

        private ObservableCollection<QuizClass> _rootobject;
        public ObservableCollection<QuizClass> rootobject
        {
            get { return _rootobject; }
            set
            {
                if (_rootobject != value)
                {
                    _rootobject = value;
                    OnPropertyChanged("rootobject");
                }
            }
        }

        public QuizDetailViewModel()
        {
            ViewScoresCommand = new RelayCommand(ViewScoresEvent);
            SubmitButtonCommand = new RelayCommand(SubmitButtonEvent);            
        }

        private void ViewScoresEvent()
        {
            NavigationService.Navigate(typeof(ViewScores));
        }

        public QuizListClass MyClickedItem;

        public void OnNavTo(NavigationEventArgs e)
        {
            MyClickedItem = (QuizListClass)e.Parameter;
            rootobject = new ObservableCollection<QuizClass>();
            ReadData();
        }

        private void ReadData()
        {
            CloudClass cloudClass = new CloudClass();

           // mySubsection = QuizzesObsCollectionClass.QuizListList.FirstOrDefault(m => m.QuizId == Uri.UnescapeDataString(MyClickedItem.QuizId));

            BlobClient cloudBlockBlob = new BlobClient(new Uri(cloudClass.GetBlobSasUri(MyClickedItem.QuizFile)));

            var filename = "lnw.json";
            var path = Path.Combine(FileSystem.CacheDirectory, filename);

            var tempStream = new MemoryStream();
            var downloadedBlob = cloudBlockBlob.DownloadTo(tempStream);

            using (var fileStream = File.Create(path))
            {
                tempStream.Seek(0, SeekOrigin.Begin);
                tempStream.CopyTo(fileStream);
            }

            var contentToBeRead = File.ReadAllText(path);

            rootobject = JsonConvert.DeserializeObject<ObservableCollection<QuizClass>>(contentToBeRead);

            if (MyClickedItem.QuizImage == null)
            {
                //Grid.SetColumnSpan(MyListView, 2);
            }
            else
            {
                //MyImage.Source = cloudClass.GetBlobSasUri(vM.mySubsection.QuizImage);
            }

            //foreach (QuizClass item in rootobject)
            //{
            //    item.ANSIsVisible = false;
            //}
        }

        //public static string ReadFully(string blobUriAndSasToken)
        //{

        //using (var stream = cloudBlockBlob.OpenReadAsync().Result)
        //{
        //    using (StreamReader reader = new StreamReader(stream))
        //    {
        //        return reader.ReadToEnd();
        //    }
        //}
        //}



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

        public void SubmitButtonEvent()
        {
            var green = new SolidColorBrush(Colors.Green);
            var red = new SolidColorBrush(Colors.Red);

            foreach (QuizClass item in rootobject)
            {
                if (item.QA == item.ANS && item.QAIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = green;
                }

                else if (item.QB == item.ANS && item.QBIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = green;
                }

                else if (item.QC == item.ANS && item.QCIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = green;
                }

                else if (item.QD == item.ANS && item.QDIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                    item.QCOLOR = green;
                }
                else
                {
                    item.QCORRECT = "Incorrect";
                    item.QCOLOR = red;               

                }
                item.ANSIsVisible = true;

            }


            //var dialog = new ContentDialog();
            //dialog.Content = "Your overall score is: " + OverallScore;
            //dialog.PrimaryButtonText = "Ok";
            //dialog.SecondaryButtonText = "Save score";
            //dialog.PrimaryButtonCommand = new RelayCommand(PrimaryButtonEvent);
            //dialog.SecondaryButtonCommand = new RelayCommand(SecondaryButtonEvent);
            //await dialog.ShowAsync();

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
                QuizName = MyClickedItem.QuizNumber + ". " + MyClickedItem.QuizName,
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
