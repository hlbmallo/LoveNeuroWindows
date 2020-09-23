using HeartCentreW104.Helpers;
using Microsoft.Azure.Storage.Blob;
using NerveCentreW10.Commands;
using NerveCentreW10.Models;
using NerveCentreW10.MyData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace NerveCentreW10.ViewModels
{
    public class QuizDetailViewModel
    {
        public ObservableCollection<QuizScore> quizScores { get; set; }
        public QuizListClass mySubsection { get; set; }
        public List<QuizClass> rootobject;

        public int OverallScore;

        public QuizDetailViewModel()
        {
            ToggleToRevealAnswers = new RelayCommand(ToggleToRevealAnswersEvent);
        }

        private void ToggleToRevealAnswersEvent()
        {

        }

        public void LoadedOne()
        { 

            CloudClass cloudClass = new CloudClass();

            var MyClickedItem = (QuizListClass)e.Parameter;
            //Title.Text = MyClickedItem.QuizNumber + " " + MyClickedItem.QuizName;
            mySubsection = QuizzesObsCollectionClass.QuizListList.FirstOrDefault(m => m.QuizId == Uri.UnescapeDataString(MyClickedItem.QuizId));

            if (mySubsection.QuizImage == null)
            {
            }
            else
            {
                //MyImage.Source = cloudClass.GetBlobSasUri(mySubsection.QuizImage);
            }

            var jsonFromCloud = ReadFully(mySubsection.QuizFile);
            rootobject = JsonConvert.DeserializeObject<List<QuizClass>>(jsonFromCloud);
        }
        public RelayCommand ToggleToRevealAnswers { get; set; }
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
    }
}
