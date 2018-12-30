using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NerveCentreW10.Models
{
    public class SubsectionModel
    {
        public string PageId { get; set; }
        public string Title { get; set; }
        public string Subtitle1 { get; set; }
        public string Description1 { get; set; }
        public string Subtitle2 { get; set; }
        public string Description2 { get; set; }
        public string Subtitle3 { get; set; }
        public string Description3 { get; set; }
        public Uri ImageUri1 { get; set; }
        public Uri ImageUri2 { get; set; }

        public string Popup1Title { get; set; }
        public string Popup1Content { get; set; }
        public string Popup2Title { get; set; }
        public string Popup2Content { get; set; }
        public string Popup3Title { get; set; }
        public string Popup3Content { get; set; }

    }
}
