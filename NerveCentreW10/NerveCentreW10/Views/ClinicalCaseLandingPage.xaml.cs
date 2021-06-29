using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClinicalCaseLandingPage : Page
    {
        public ClinicalCaseLandingPage()
        {
            this.InitializeComponent();
            HtmlLabel.Source = "In this section you will find fictional patients with neurological symptoms. The goal is to answer the 8 questions correctly about the neuroscience underlying their conditions. The questions are not timed.<br/>< br/>When you select an answer, tap 'Submit' and this will reveal if you are correct. Then, tap 'Next' to proceed. Tap a clinical case below to get started.";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ClinicalCaseScenarioPage), "case1");
        }

        private void Case2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ClinicalCaseScenarioPage), "case2");
        }
    }
}
