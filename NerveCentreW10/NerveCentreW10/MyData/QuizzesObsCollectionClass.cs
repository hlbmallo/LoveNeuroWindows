using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCentreW10.MyData
{
    public static class QuizzesObsCollectionClass
    {
        public static ObservableCollection<QuizListClass> QuizListList { get; set; }

        static QuizzesObsCollectionClass()
        {
            QuizListList = new ObservableCollection<QuizListClass>();

            CloudClass cloudclass = new CloudClass();

            QuizListList.Add(new QuizListClass
            {
                QuizId = "section51",
                QuizNumber = "Quiz 1",
                QuizName = "At The Cellular Level",
                QuizFile = "Quiz1.json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section52",
                QuizNumber = "Quiz 2",
                QuizName = "The Central Nervous System",
                QuizFile = "Quiz2.json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section53",
                QuizNumber = "Quiz 3",
                QuizName = "The Peripheral Nervous System",
                QuizFile = "Quiz3.json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section54",
                QuizNumber = "Quiz 4",
                QuizName = "Neurological Disorders",
                QuizFile = "Quiz4.json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section55",
                QuizNumber = "Quiz 5",
                QuizName = "Mix Up (1)",
                QuizFile = "Quiz5.json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section56",
                QuizNumber = "Quiz 6",
                QuizName = "Structures of the Brain (Image-Based)",
                QuizFile = "Quiz6.json",
                QuizImage = "quiz6image.png",
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section57",
                QuizNumber = "Quiz 7",
                QuizName = "The Brachial Plexus (Image-Based)",
                QuizFile = "Quiz7.json",
                QuizImage = "quiz7image.png",
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section58",
                QuizNumber = "Quiz 8",
                QuizName = "The Cerebral Cortex (Image-Based)",
                QuizFile = "Quiz8.json",
                QuizImage = "quiz8image.png",
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section59",
                QuizNumber = "Quiz 9",
                QuizName = "The Cranial Nerves",
                QuizFile = "Quiz9.json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section510",
                QuizNumber = "Quiz 10",
                QuizName = "Mix Up (2)",
                QuizFile = "Quiz10.json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section511",
                QuizNumber = "Quiz 11",
                QuizName = "Mix Up (3)",
                QuizFile = "Quiz11.json",
                QuizImage = null,
            });
            QuizListList.Add(new QuizListClass
            {
                QuizId = "section512",
                QuizNumber = "Quiz 12",
                QuizName = "Mix Up (4)",
                QuizFile = "Quiz12.json",
                QuizImage = null,
            });
        }
    }
}
