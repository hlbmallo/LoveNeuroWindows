﻿using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Models;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Essentials;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Section5QuizMenu : Page
    {
        public ObservableCollection<QuizListClass> QuizListList { get; } = new ObservableCollection<QuizListClass>();

        public Section5QuizMenu()
        {
            this.InitializeComponent();
            QuizData();
        }

        void QuizData()
        {
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section51",
                QuizNumber = "Quiz 1",
                QuizName = "At The Cellular Level",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz1cellsjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section52",
                QuizNumber = "Quiz 2",
                QuizName = "The Central Nervous System",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz2centraljson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section53",
                QuizNumber = "Quiz 3",
                QuizName = "The Peripheral Nervous System",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz3peripheraljson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section54",
                QuizNumber = "Quiz 4",
                QuizName = "Neurological Disorders",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz4disordersjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section55",
                QuizNumber = "Quiz 5",
                QuizName = "Overall Quiz",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz5overalljson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section56",
                QuizNumber = "Quiz 6",
                QuizName = "Structures of the Brain",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz6brainjson.Json",
                QuizImage = new BitmapImage(new Uri("ms-appx:///Assets/Quizzes/quiz6image.png")),
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section57",
                QuizNumber = "Quiz 7",
                QuizName = "The Brachial Plexus",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz7brachialjson.Json",
                QuizImage = new BitmapImage(new Uri("ms-appx:///Assets/Quizzes/quiz7image.png")),
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section58",
                QuizNumber = "Quiz 8",
                QuizName = "The Cerebral Cortex",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz8cortexjson.Json",
                QuizImage = new BitmapImage(new Uri("ms-appx:///Assets/Quizzes/quiz8image.png")),
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section59",
                QuizNumber = "Quiz 9",
                QuizName = "The Cranial Nerves",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz9cranialjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section510",
                QuizNumber = "Quiz 10",
                QuizName = "Outside the Box",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz10boxjson.json",
                QuizImage = null,
            });


            GridView1.ItemsSource = QuizListList;
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = (QuizListClass)e.ClickedItem;
            Frame.Navigate(typeof(QuizDetail), MyClickedItem, new DrillInNavigationTransitionInfo());
        }

        private void ViewScoresButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewScores));
        }
    }
}

//public Section5QuizMenu()
//        {
//            this.InitializeComponent();
//        }

//        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            var comboBoxItem = e.AddedItems[0] as ComboBoxItem;
//            if (comboBoxItem == null) return;
//            var content = comboBoxItem.Content as string;
//            if (content != null && content.Equals("Quiz 1. At The Cellular Level"))
//            {
//                MyFrame.Navigate(typeof(Quiz1Cells));
//            }
//            //if (content != null && content.Equals("Quiz 2. Central Nervous System"))
//            //{
//            //    MyFrame.Navigate(typeof(QuizCNS));
//            //}
//            //if (content != null && content.Equals("Quiz 3. Peripheral Nervous System"))
//            //{
//            //    MyFrame.Navigate(typeof(QuizPNS));
//            //}
//            //if (content != null && content.Equals("Quiz 4. Neurological Disorders"))
//            //{
//            //    MyFrame.Navigate(typeof(QuizDISORDERS));
//            //}
//            //if (content != null && content.Equals("Quiz 5. Overall Quiz"))
//            //{
//            //    MyFrame.Navigate(typeof(QuizOVERALL));
//            //}
//            //if (content != null && content.Equals("Quiz 6. Labelling The Brain"))
//            //{
//            //    MyFrame.Navigate(typeof(Quiz6Brain));
//            //}
//            //if (content != null && content.Equals("Quiz 7. Labelling The Brachial Plexus"))
//            //{
//            //    MyFrame.Navigate(typeof(Quiz7BrachialPlexus));
//            //}
//            //if (content != null && content.Equals("Quiz 8. The Cerebral Cortex"))
//            //{
//            //    MyFrame.Navigate(typeof(Quiz8Cortex));
//            //}
//            //if (content != null && content.Equals("Quiz 9. The Cranial Nerves"))
//            //{
//            //    MyFrame.Navigate(typeof(Quiz9Cranial));
//            //}
//        }
//    }
//}
