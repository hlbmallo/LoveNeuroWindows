using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Xamarin.Essentials;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewScores : Page
    {
        public ObservableCollection<QuizScore> saved = new ObservableCollection<QuizScore>();
        public ViewScores()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var helper = new RoamingObjectStorageHelper();
            saved = await helper.ReadFileAsync<ObservableCollection<QuizScore>>("obsCollection.txt");
            dataGrid.ItemsSource = saved;
        }

        private async void DeleteItemFlyout_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext as QuizScore;
            saved.Remove(item);

            var helper = new RoamingObjectStorageHelper();
            await helper.SaveFileAsync("obsCollection.txt",saved);
            dataGrid.ItemsSource = saved;

        }
    }
}
