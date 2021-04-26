using NerveCentreW10.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace NerveCentreW10.Models
{
    public class ClinicalCaseModel : BaseViewModel
    {
        public string OpeningStatement { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Ans1Reasoning { get; set; }
        public string Ans2Reasoning { get; set; }
        public string Ans3Reasoning { get; set; }
        public string CorrectAnswer { get; set; }
        public bool IsCheckedA { get; set; }
        public bool IsCheckedB { get; set; }
        public bool IsCheckedC { get; set; }
        private SolidColorBrush _myColor;
        public SolidColorBrush myColor
        {
            get
            {
                return _myColor;
            }
            set
            {
                if (_myColor != value)
                {
                    _myColor = value;
                    OnPropertyChanged("myColor");
                }
            }
        }
    }
}
