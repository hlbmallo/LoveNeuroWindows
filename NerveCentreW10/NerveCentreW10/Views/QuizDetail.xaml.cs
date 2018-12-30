﻿using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuizDetail : Page
    {
        public int OverallScore;

        public QuizDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var MyClickedItem = (QuizListClass)e.Parameter;

            FileIOHelper oFileHelper = new FileIOHelper();
            List<QuizClass> lstSettingInfo = oFileHelper.ReadFromDefaultFile(MyClickedItem.QuizFile);
            List<QuizClass> oSettingsObserv = new List<QuizClass>(lstSettingInfo);
            MyListView.ItemsSource = oSettingsObserv;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (QuizClass item in MyListView.Items)
            {
                if (item.QA == item.ANS && item.QAIsActive == true)
                {
                    OverallScore += 1;
                }

                else if (item.QB == item.ANS && item.QBIsActive == true)
                {
                    OverallScore += 1;
                }

                else if (item.QC == item.ANS && item.QCIsActive == true)
                {
                    OverallScore += 1;
                }

                else if (item.QD == item.ANS && item.QDIsActive == true)
                {
                    OverallScore += 1;
                }
            }

            var dialog = new MessageDialog("Overall Score: " + OverallScore);
            await dialog.ShowAsync();

            OverallScore = 0;
        }
    }
}