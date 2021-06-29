using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    public sealed partial class ClinicalCaseFinishedDialog : ContentDialog
    {
        public ClinicalCaseFinishedDialog(string MyParam)
        {
            this.InitializeComponent();
            if (MyParam == "case1")
            {
                MyTextBlock.Text = "In this Clinical Case, the patient suffered from Brown-Sequard syndrome after an extreme fall. Brown-Sequard develops when the left or right side of the spinal cord is transected. Well done on completing the questions. Now, hit the 'Back' button to go back to the main menu.";
            }
            else if (MyParam == "case2")
            {
                MyTextBlock.Text = "In this Clinical Case, the patient suffered from Parkinson's disease. In this neurodegenerative disease, dopaminergic neurons connecting the substantia nigra and putamen die, leading to tremor, bradykinesia and dystonia. Well done on completing the questions. Now, hit the 'Back' button to go back to the main menu.";
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NerveCentreW10.Services.NavigationService.Frame.GoBack();
        }
    }
}
