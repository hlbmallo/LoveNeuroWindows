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
        public QuizListClass mySubsection { get; set; }
        public ObservableCollection<QuizScore> quizScores { get; set; }
        //public ObservableCollection<QuizClass> rootobject { get;set; }
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

        //private bool qGlyph;
        //public bool QGlyph
        //{
        //    get { return this.qGlyph; }
        //    set
        //    {
        //        if (this.qGlyph != value)
        //        {
        //            this.qGlyph = value;
        //            this.OnPropertyChanged("QGlyph");
        //        }
        //    }
        //}

        public QuizDetailViewModel()
        {
            ViewScoresCommand = new RelayCommand(ViewScoresEvent);
            SubmitButtonCommand = new RelayCommand(SubmitButtonEvent);
            
        }

        private void ViewScoresEvent()
        {
            NavigationService.Navigate(typeof(ViewScores));
        }

        public void OnNavTo(NavigationEventArgs e)
        {
            ObservableCollection<QuizClass> roobject = new ObservableCollection<QuizClass>();
            CloudClass cloudClass = new CloudClass();
            var MyClickedItem = (QuizListClass)e.Parameter;
            mySubsection = QuizzesObsCollectionClass.QuizListList.FirstOrDefault(m => m.QuizId == Uri.UnescapeDataString(MyClickedItem.QuizId));

            BlobClient cloudBlockBlob = new BlobClient(new Uri(cloudClass.GetBlobSasUri(mySubsection.QuizFile)));

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

            if (mySubsection.QuizImage == null)
            {
                //Grid.SetColumnSpan(MyListView, 2);
            }
            else
            {
                //MyImage.Source = cloudClass.GetBlobSasUri(vM.mySubsection.QuizImage);
            }
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

        private async void SubmitButtonEvent()
        {
            foreach (QuizClass item in rootobject)
            {
                if (item.QA == item.ANS && item.QAIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                }

                else if (item.QB == item.ANS && item.QBIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                }

                else if (item.QC == item.ANS && item.QCIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                }

                else if (item.QD == item.ANS && item.QDIsActive == true)
                {
                    OverallScore += 1;
                    item.QCORRECT = "Correct";
                }
                else
                {
                    item.QCORRECT = "Incorrect";
                }

                item.ANSIsVisible = Windows.UI.Xaml.Visibility.Visible;

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
                QuizName = mySubsection.QuizNumber + ". " + mySubsection.QuizName,
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
