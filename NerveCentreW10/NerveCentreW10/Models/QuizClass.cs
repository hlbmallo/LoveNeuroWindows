using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NerveCentreW10.Models
{
    public class QuizClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
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
        private string _QCORRECT;
        public string QCORRECT
        {

            get
            {
                return _QCORRECT;
            }

            set
            {
                if (_QCORRECT != value)
                {
                    _QCORRECT = value;
                    OnPropertyChanged("QCORRECT");
                }
            }
        }
        private SolidColorBrush _QCOLOR;
        public SolidColorBrush QCOLOR
        {

            get
            {
                return _QCOLOR;
            }

            set
            {
                if (_QCOLOR != value)
                {
                    _QCOLOR = value;
                    OnPropertyChanged("QCOLOR");
                }
            }
        }
    }
}
