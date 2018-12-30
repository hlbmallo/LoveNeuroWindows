using System;

using NerveCentreW10.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NerveCentreW10.Views
{
    public sealed partial class QuizMDDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(QuizMDDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public QuizMDDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as QuizMDDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
