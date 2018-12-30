using NerveCentreW10.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuizList : Page
    {
        public ObservableCollection<QuizListClass> QuizListList { get; } = new ObservableCollection<QuizListClass>();

        public QuizList()
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
                QuizFile = "ms-appx:///Assets/Others/quiz1cellsjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 2",
                QuizName = "The Central Nervous System",
                QuizFile = "ms-appx:///Assets/Others/quiz2cnsjson.Json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizNumber = "Quiz 3",
                QuizName = "The Peripheral Nervous System",
                QuizFile = "ms-appx:///Assets/Others/quiz2cnsjson.Json",
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
                QuizFile = "ms-appx:///Assets/Others/quiz2cnsjson.Json",
                QuizImage = null,
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
            Frame.Navigate(typeof(QuizDetail), MyClickedItem);
        }
    }
}
