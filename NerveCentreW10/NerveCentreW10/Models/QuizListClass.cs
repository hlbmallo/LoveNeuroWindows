using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NerveCentreW10.Models
{
    public class QuizListClass
    {
        public string QuizId { get; set; }
        public string QuizNumber { get; set; }
        public string QuizName { get; set; }
        public string QuizFile { get; set; }
        public ImageSource QuizImage { get; set; }
    }
}
