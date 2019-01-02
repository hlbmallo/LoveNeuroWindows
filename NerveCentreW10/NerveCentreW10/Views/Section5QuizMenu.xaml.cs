using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

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
                QuizNumber = "Quiz 1",
                QuizName = "At The Cellular Level",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz1cellsjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 2",
                QuizName = "The Central Nervous System",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz2centraljson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 3",
                QuizName = "The Peripheral Nervous System",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz3peripheraljson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 4",
                QuizName = "Neurological Disorders",
                QuizFile = "ms-appx:///Assets/Others/quiz2cnsjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 5",
                QuizName = "Overall Quiz",
                QuizFile = "ms-appx:///Assets/Others/quiz2cnsjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 6",
                QuizName = "Structures of the Brain",
                QuizFile = "ms-appx:///Assets/Quizzes/quiz2centraljson.Json",
                QuizImage = new BitmapImage(new Uri("ms-appx:///Assets/Quizzes/quiz6image.png")),
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 7",
                QuizName = "The Brachial Plexus",
                QuizFile = "ms-appx:///Assets/Others/quiz2cnsjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 8",
                QuizName = "The Cerebral Cortex",
                QuizFile = "ms-appx:///Assets/Others/quiz2cnsjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 9",
                QuizName = "The Cranial Nerves",
                QuizFile = "ms-appx:///Assets/Others/quiz2cnsjson.Json",
                QuizImage = null,
            });

            GridView1.ItemsSource = QuizListList;
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = (QuizListClass)e.ClickedItem;
            Frame.Navigate(typeof(QuizDetail), MyClickedItem, new DrillInNavigationTransitionInfo());
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
