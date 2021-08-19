using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace NerveCentreW10.Helpers
{
    public class QuizNameConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                QuizListClass temp1 = (QuizListClass)value;
                return temp1.QuizNumber + ". " + temp1.QuizName;
            }
            else
            {
                return null;

            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
