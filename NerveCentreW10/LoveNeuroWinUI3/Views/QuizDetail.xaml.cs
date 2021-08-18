using LoveNeuroWinUI3.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Helpers;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using LoveNeuroWinUI3.Helpers;

using LoveNeuroWinUI3.MyData;
using System.Linq;
using Windows.UI;
using LoveNeuroWinUI3.ViewModels;
using Azure.Storage.Blobs;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoveNeuroWinUI3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuizDetail : Page
    {
        public QuizDetail()
        {
            this.InitializeComponent();
            var cloudClass = new CloudClass();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            vM.OnNavTo(e);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            vM.LoadedPage();
        }
    }
}
