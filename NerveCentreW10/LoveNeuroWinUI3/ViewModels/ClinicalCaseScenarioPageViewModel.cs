using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LoveNeuroWinUI3.Commands;
using LoveNeuroWinUI3.Helpers;
using LoveNeuroWinUI3.Models;
using LoveNeuroWinUI3.Views;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace LoveNeuroWinUI3.ViewModels
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

        public string MyParam { get; private set; }

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
        }

        public void LoadedCase1()
        {
            SubsectionList = new ObservableCollection<ClinicalCaseModel>();
            var myString = ReadFully("clinicalcase1.json");
            SubsectionList = JsonConvert.DeserializeObject<ObservableCollection<ClinicalCaseModel>>(myString);
            MyParam = "case1";
        }

        public void LoadedCase2()
        {
            SubsectionList = new ObservableCollection<ClinicalCaseModel>();
            var myString = ReadFully("clinicalcase2.json");
            SubsectionList = JsonConvert.DeserializeObject<ObservableCollection<ClinicalCaseModel>>(myString);
            MyParam = "case2";
        }

        public async Task<Stream> DownloadBlob(string blobUriAndSasToken)
        {
            var cloudClass = new CloudClass();
            BlobClient cloudBlockBlob = new BlobClient(new Uri(cloudClass.GetBlobSasUri(blobUriAndSasToken)));
            BlobDownloadInfo download = await cloudBlockBlob.DownloadAsync();
            return download.Content;
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


        public void SubmitEvent()
        {
            var lol = SubsectionList[ItemPosition];
            if (lol.IsCheckedA == true && lol.Answer1 == lol.CorrectAnswer)
            {
                ShowViewCell1 = true;
                ShowViewCell2 = false;
                ShowViewCell3 = false;
                lol.myColor = "#008E00";
            }

            else if (lol.IsCheckedB == true && lol.Answer1 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = true;
                ShowViewCell3 = false;
                lol.myColor = "FF0000";
            }

            else if (lol.IsCheckedC == true && lol.Answer1 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = false;
                ShowViewCell3 = true;
                lol.myColor = "FF0000";
            }

            if (lol.IsCheckedA == true && lol.Answer2 == lol.CorrectAnswer)
            {
                ShowViewCell1 = true;
                ShowViewCell2 = false;
                ShowViewCell3 = false;
                lol.myColor = "FF0000";
            }

            else if (lol.IsCheckedB == true && lol.Answer2 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = true;
                ShowViewCell3 = false;
                lol.myColor = "#008E00";
            }

            else if (lol.IsCheckedC == true && lol.Answer2 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = false;
                ShowViewCell3 = true;
                lol.myColor = "FF0000";
            }

            if (lol.IsCheckedA == true && lol.Answer3 == lol.CorrectAnswer)
            {
                ShowViewCell1 = true;
                ShowViewCell2 = false;
                ShowViewCell3 = false;
                lol.myColor = "FF0000";
            }

            else if (lol.IsCheckedB == true && lol.Answer3 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = true;
                ShowViewCell3 = false;
                lol.myColor = "FF0000";
            }

            else if (lol.IsCheckedC == true && lol.Answer3 == lol.CorrectAnswer)
            {
                ShowViewCell1 = false;
                ShowViewCell2 = false;
                ShowViewCell3 = true;
                lol.myColor = "#008E00";
            }
        }

        public async void ClickedEvent()
        {
            ShowViewCell1 = false;
            ShowViewCell2 = false;
            ShowViewCell3 = false;

            if (ItemPosition == 7)
            {
                var FinishedDialog = new ClinicalCaseFinishedDialog(MyParam);
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
    }
}
