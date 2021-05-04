using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NerveCentreW10.Commands;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Essentials;

namespace NerveCentreW10.ViewModels
{
    public class ClinicalCasesScenarioPageViewModel : BaseViewModel
    {


        public RelayCommand ClickedCommand { get; set; }
        public RelayCommand ClickedCommandBack { get; set; }
        //public Command MyPositionChangedCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }

        private ObservableCollection<ClinicalCaseModel> _sublist;
        public ObservableCollection<ClinicalCaseModel> SubsectionList
        {
            get => _sublist;
            set
            {
                this._sublist = value;
                this.OnPropertyChanged("SubsectionList");
            }
        }


        private bool showviewcell1;
        public bool ShowViewCell1
        {
            get
            {
                return showviewcell1;
            }
            set
            {
                if (showviewcell1 != value)
                {
                    showviewcell1 = value;
                    this.OnPropertyChanged("ShowViewCell1");
                }
            }
        }

        private bool showviewcell2;
        public bool ShowViewCell2
        {
            get
            {
                return showviewcell2;
            }
            set
            {
                if (showviewcell2 != value)
                {
                    showviewcell2 = value;
                    this.OnPropertyChanged("ShowViewCell2");
                }
            }
        }

        private bool showviewcell3;
        public bool ShowViewCell3
        {
            get
            {
                return showviewcell3;
            }
            set
            {
                if (showviewcell3 != value)
                {
                    showviewcell3 = value;
                    this.OnPropertyChanged("ShowViewCell3");
                }
            }
        }

        //private bool _IsNextEnabled;
        //public bool IsNextEnabled
        //{
        //    get
        //    {
        //        return _IsNextEnabled;
        //    }
        //    set
        //    {
        //        if (_IsNextEnabled != value)
        //        {
        //            _IsNextEnabled = value;
        //            this.OnPropertyChanged("IsNextEnabled");
        //        }
        //    }
        //}

        private int _ItemPosition;
        public int ItemPosition
        {
            get
            {
                return _ItemPosition;
            }

            set
            {
                _ItemPosition = value;
                OnPropertyChanged("ItemPosition");
            }
        }

        public ClinicalCasesScenarioPageViewModel()
        {

            ClickedCommand = new RelayCommand(ClickedEvent);
            ClickedCommandBack = new RelayCommand(ClickedBackEvent);
            SubmitCommand = new RelayCommand(SubmitEvent);
            Loaded();
        }

        public void Loaded()
        {
            SubsectionList = new ObservableCollection<ClinicalCaseModel>();

            var myString = ReadFully("clinicalcase1.json");
            SubsectionList = JsonConvert.DeserializeObject<ObservableCollection<ClinicalCaseModel>>(myString);
        }

        public async Task<Stream> DownloadBlob(string blobUriAndSasToken)
        {
            var cloudClass = new CloudClass();

            BlobClient cloudBlockBlob = new BlobClient(new Uri(cloudClass.GetBlobSasUri(blobUriAndSasToken)));

            BlobDownloadInfo download = await cloudBlockBlob.DownloadAsync();

            return download.Content;



            //using (FileStream fs = File.Create(FileSystem.AppDataDirectory + "/download.txt"))
            //{
            //    var lol2 = download.Content.CopyToAsync(fs);
            //    return fs;
            //}
        }

        public static string ReadFully(string blobUriAndSasToken)
        {
            var cloudClass = new CloudClass();

            BlobClient cloudBlockBlob = new BlobClient(new Uri(cloudClass.GetBlobSasUri(blobUriAndSasToken)));

            using (var stream = cloudBlockBlob.OpenRead())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }






        //var cloudClass = new CloudClass();

        //BlobClient cloudBlockBlob = new BlobClient(new Uri(cloudClass.GetBlobSasUri(blobUriAndSasToken)));

        //var stream = await cloudBlockBlob.OpenReadAsync();

        //StreamReader reader = new StreamReader(stream);

        //  return   reader.ReadToEnd();

        //}


        public void SubmitEvent()
        {
            var lol = SubsectionList[ItemPosition];
            if (lol.IsCheckedA == true && lol.Answer1 == lol.CorrectAnswer)
            {
                ShowViewCell1 = true;
                ShowViewCell2 = false;
                ShowViewCell3 = false;
                lol.myColor = new SolidColorBrush(Colors.Green);
            }

            else if (lol.IsCheckedB == true && lol.Answer1 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = true;
                ShowViewCell3 = false;
                lol.myColor = new SolidColorBrush(Colors.Red);
            }

            else if (lol.IsCheckedC == true && lol.Answer1 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = false;
                ShowViewCell3 = true;
                lol.myColor = new SolidColorBrush(Colors.Red);
            }

            if (lol.IsCheckedA == true && lol.Answer2 == lol.CorrectAnswer)
            {
                ShowViewCell1 = true;
                ShowViewCell2 = false;
                ShowViewCell3 = false;
                lol.myColor = new SolidColorBrush(Colors.Red);
            }

            else if (lol.IsCheckedB == true && lol.Answer2 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = true;
                ShowViewCell3 = false;
                lol.myColor = new SolidColorBrush(Colors.Green);
            }

            else if (lol.IsCheckedC == true && lol.Answer2 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = false;
                ShowViewCell3 = true;
                lol.myColor = new SolidColorBrush(Colors.Red);
            }

            if (lol.IsCheckedA == true && lol.Answer3 == lol.CorrectAnswer)
            {
                ShowViewCell1 = true;
                ShowViewCell2 = false;
                ShowViewCell3 = false;
                lol.myColor = new SolidColorBrush(Colors.Red);
            }

            else if (lol.IsCheckedB == true && lol.Answer3 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = true;
                ShowViewCell3 = false;
                lol.myColor = new SolidColorBrush(Colors.Red);
            }

            else if (lol.IsCheckedC == true && lol.Answer3 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = false;
                ShowViewCell3 = true;
                lol.myColor = new SolidColorBrush(Colors.Green);
            }
        }

            public async void ClickedEvent()
        {
            ShowViewCell1 = false;
            ShowViewCell2 = false;
            ShowViewCell3 = false;

            if (ItemPosition == 7)
            {
                var FinishedDialog = new ClinicalCaseFinishedDialog();
                await FinishedDialog.ShowAsync();
            }

            else
            {
                ItemPosition += 1;
            }

        }

        public void ClickedBackEvent()
        {
            ShowViewCell1 = false;
            ShowViewCell2 = false;
            ShowViewCell3 = false;

            if (ItemPosition == 0)
            {

            }
            else
            {
                ItemPosition -= 1;
            }
        }

        //public void MyPositionChangedEvent()
        //{
        //    ShowViewCell1 = false;
        //    ShowViewCell2 = false;
        //    ShowViewCell3 = false;
        //}

    }
}
