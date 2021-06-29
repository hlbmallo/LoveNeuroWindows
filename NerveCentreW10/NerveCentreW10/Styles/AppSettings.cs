using NerveCentreW10.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCentreW10.Styles
{
    public class AppSettings : BaseViewModel
    {
        private double appFontSize;
        public double AppFontSize
        {
            get
            {
                return appFontSize;
            }
            set
            {
                if (appFontSize != value)
                {
                    appFontSize = value;
                    this.OnPropertyChanged("AppFontSize");
                }
            }
        }
    }
}
