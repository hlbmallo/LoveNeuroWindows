namespace LoveNeuroWinUI3.Models
{
    public class ClinicalCaseModel //: BaseViewModel
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
        private string _myColor;
        public string myColor
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
                    //OnPropertyChanged("myColor");
                }
            }
        }
    }
}
