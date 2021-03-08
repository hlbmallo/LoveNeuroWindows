using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCentreW10.Models
{
    public class QuizScore
    {
        public int MyScore { get; set; }
        public DateTime MyDateForThatScore { get; set; }
        public string QuizName { get; set; }
        public double MyScoreInPercent { get; set; }
    }
}
