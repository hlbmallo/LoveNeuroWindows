using Acr.UserDialogs;
using Microsoft.Toolkit.Uwp.Helpers;
using LoveNeuroWinUI3.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Essentials;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoveNeuroWinUI3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Section5QuizMenu : Page
    {
        //public ObservableCollection<QuizListClass> QuizListList { get; } = new ObservableCollection<QuizListClass>();
        public Section5QuizMenu()
        {
            this.InitializeComponent();
            //QuizData();
        }

        //void QuizData()
        //{
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section51",
        //        QuizNumber = "Quiz 1",
        //        QuizName = "At The Cellular Level",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz1cellsjson.Json",
        //        QuizImage = null,
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section52",
        //        QuizNumber = "Quiz 2",
        //        QuizName = "The Central Nervous System",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz2centraljson.Json",
        //        QuizImage = null,
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section53",
        //        QuizNumber = "Quiz 3",
        //        QuizName = "The Peripheral Nervous System",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz3peripheraljson.Json",
        //        QuizImage = null,
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section54",
        //        QuizNumber = "Quiz 4",
        //        QuizName = "Neurological Disorders",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz4disordersjson.Json",
        //        QuizImage = null,
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section55",
        //        QuizNumber = "Quiz 5",
        //        QuizName = "Overall Quiz",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz5overalljson.Json",
        //        QuizImage = null,
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section56",
        //        QuizNumber = "Quiz 6",
        //        QuizName = "Structures of the Brain",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz6brainjson.Json",
        //        QuizImage = new BitmapImage(new Uri("ms-appx:///Assets/Quizzes/quiz6image.png")),
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section57",
        //        QuizNumber = "Quiz 7",
        //        QuizName = "The Brachial Plexus",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz7brachialjson.Json",
        //        QuizImage = new BitmapImage(new Uri("ms-appx:///Assets/Quizzes/quiz7image.png")),
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section58",
        //        QuizNumber = "Quiz 8",
        //        QuizName = "The Cerebral Cortex",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz8cortexjson.Json",
        //        QuizImage = new BitmapImage(new Uri("ms-appx:///Assets/Quizzes/quiz8image.png")),
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section59",
        //        QuizNumber = "Quiz 9",
        //        QuizName = "The Cranial Nerves",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz9cranialjson.Json",
        //        QuizImage = null,
        //    });
        //    QuizListList.Add(new QuizListClass
        //    {
        //        QuizId = "section510",
        //        QuizNumber = "Quiz 10",
        //        QuizName = "Outside the Box",
        //        QuizFile = "ms-appx:///Assets/Quizzes/quiz10boxjson.json",
        //        QuizImage = null,
        //    });


        //    GridView1.ItemsSource = QuizListList;
        //}

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool isNetworkConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isNetworkConnected == true)
            {
                var MyClickedItem = (QuizListClass)e.ClickedItem;
                Frame.Navigate(typeof(QuizDetail), MyClickedItem, new DrillInNavigationTransitionInfo());
            }
            else
            {
                UserDialogs.Instance.Alert("Looks like you're not connected to the Internet at the moment. Once you've reconnected, try clicking this quiz again.", "No Internet Connection","Ok");
            }
        }

        private void ViewScoresButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewScores));
        }
    }
}
