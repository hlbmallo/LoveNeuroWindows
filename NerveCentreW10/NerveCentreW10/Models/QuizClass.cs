using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace NerveCentreW10.Models
{
    public class QuizClass
    {
        public string QTEXT { get; set; }
        public string QA { get; set; }
        public string QB { get; set; }
        public string QC { get; set; }
        public string QD { get; set; }
        public string ANS { get; set; }
        public string REA { get; set; }
        public bool QAIsActive { get; set; }
        public bool QBIsActive { get; set; }
        public bool QCIsActive { get; set; }
        public bool QDIsActive { get; set; }
        public bool ANSIsVisible { get; set; }
        public string QCorrect { get; set; }

    }

    //public class RootObject
    //{
    //    public List<QuizClass> MyData { get; set; }
    //}
}
