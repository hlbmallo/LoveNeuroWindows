using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Extensions;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Quiz1Cells : Page
    {
        public Quiz1Cells()
        {
            this.InitializeComponent();
        }

        private void MyListView_Loaded(object sender, RoutedEventArgs e)
        {
            //string jsonContent = File.OpenText("ms-appx:///Assets/Others/convertcsv.json");
            //var myList = JsonConvert.DeserializeObject<RootObject>(jsonContent);
            //    DeserializeFileAsync("")
            //    MyListView.ItemsSource = fileName;
            //}

            LoadListContent();
        }

        public string DefaultFilePath = "ms-appx:///Assets/Others/quiz1bonesjson.Json";
        public string fileContents;

        private async void LoadListContent()
        {
            //StorageFile sFile = await Package.Current.InstalledLocation.GetFileAsync(@"Assets\Others\" + DefaultFileName);
            //var fileStream = await sFile.OpenStreamForReadAsync();

            //using (System.IO.StreamReader r = new System.IO.StreamReader(fileStream))
            //{
            //    string json = r.ReadToEnd();
            //    globallist = JsonConvert.DeserializeObject<List<RootObject>>(json);
            //    MyListView.ItemsSource = globallist;
            //}

            FileIOHelper oFileHelper = new FileIOHelper();
            List<QuizClass> lstSettingInfo = oFileHelper.ReadFromDefaultFile(DefaultFilePath);//Call to helper file for getting the details 
            List<QuizClass> oSettingsObserv = new List<QuizClass>(lstSettingInfo);
            MyListView.ItemsSource = oSettingsObserv;//Binding the values to list




            //StorageFile sFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\Others\" + DefaultFileName);
            //var fileStream = await sFile.OpenStreamForReadAsync();



            //using (StreamReader file = File.OpenText(DefaultFilePath))
            //{
            //    var json = file.ReadToEnd();
            //    Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            //    string contacts = result["convertcsv"].ToString();
            //    List<RootObject> objResponse = JsonConvert.DeserializeObject<List<RootObject>>(contacts);
            //    MyListView.ItemsSource = objResponse;
            //}


            //FileIOHelper oFileHelper = new FileIOHelper();
            //List<QuizClass> lstSettingInfo = oFileHelper.ReadFromDefaultFile(DefaultFileName);//Call to helper file for getting the details 
            //ObservableCollection<QuizClass> oSettingsObserv = new ObservableCollection<QuizClass>(lstSettingInfo);
            //MyListView.ItemsSource = oSettingsObserv;//Binding the values to list 
        }

        //var controlA = MyListView.FindDescendants<RadioButton>();
        //var controlB = MyListView.FindDescendantByName("QB") as RadioButton;
        //var controlC = MyListView.FindDescendantByName("QC") as RadioButton;
        //var controlD = MyListView.FindDescendantByName("QD") as RadioButton;


        public int OverallScore;

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

            //foreach (QuizClass itemRow in this.MyListView.Items)
            //{
            //    for (int i = 0; i < itemRow..Count; i++)
            //    {
            //        yield return itemRow.SubItems[i]);
            //}


            //foreach (QuizClass item in MyListView.Items)
            //{
            //    var controlA = MyListView.FindDescendantByName("QA") as RadioButton;

            //    if (controlA.IsChecked == true && item.ANS == item.Q1A)
            //    {
            //        OverallScore += 1;

            //    }
            //    if (controlA.IsChecked == true && item.ANS == item.Q1B)
            //    {
            //        OverallScore += 1;

            //    }
            //    if (controlA.IsChecked == true && item.ANS == item.Q1C)
            //    {
            //        OverallScore += 1;

            //    }
            //}

            //for (int i = 0; i < MyListView.SelectedItems.Count; i++)
            //{
            //    QuizClass du = MyListView[i];
            //    // do your stuff here with du

            //}

            //foreach (QuizClass item in MyListView.Items)
            //{



            //    if (item.Q1A == item.ANS && controlA.IsChecked == true)
            //    {
            //        OverallScore += 1;
            //    }

            //    else
            //    {
            //        OverallScore += 0;
            //    }

            //    if (item.Q1B == item.ANS && controlB.IsChecked == true)
            //    {
            //        OverallScore += 1;
            //    }

            //    else
            //    {
            //        OverallScore += 0;
            //    }

            //    if (item.Q1C == item.ANS && controlC.IsChecked == true)
            //    {
            //        OverallScore += 1;
            //    }

            //    else
            //    {
            //        OverallScore += 0;
            //    }

            //    if (item.Q1D == item.ANS && controlD.IsChecked == true)
            //    {
            //        OverallScore += 1;
            //    }

            //    else
            //    {
            //        OverallScore += 0;
            //    }
            //}

            //if (element.Q1A == element.ANS)
            //    {
            //        OverallScore += 1;
            //        var dialog = new MessageDialog("Overall Score: " + OverallScore);
            //        await dialog.ShowAsync();
            //    }



            //    foreach (QuizClass item in MyListView.Items)
            //{
            //    //var controlA = MyListView.FindDescendantByName("QA") as RadioButton;
            //    //var controlB = MyListView.FindDescendantByName("QB") as RadioButton;
            //    //var controlC = MyListView.FindDescendantByName("QC") as RadioButton;
            //    //var controlD = MyListView.FindDescendantByName("QD") as RadioButton;
            //    //var controlAnswer = MyListView.FindDescendantByName("ANS") as TextBlock;



            //    if (controlA.Content.ToString() == item.Q1A)
            //    {
            //        var dialog = new MessageDialog("A ");
            //        await dialog.ShowAsync();
            //    }
            //}







        }
    }










                //StackPanel stackPanel = MyListView.FindDescendantByName("Q1") as StackPanel;
                //var controlA = MyListView.FindDescendantByName("QA") as RadioButton;
                //var controlB = MyListView.FindDescendantByName("QB") as RadioButton;
                //var controlC = MyListView.FindDescendantByName("QC") as RadioButton;
                //var controlD = MyListView.FindDescendantByName("QD") as RadioButton;
                //var controlAnswer = MyListView.FindDescendantByName("ANS") as TextBlock;

                //foreach (QuizClass item in MyListView.Items.Where(item =>  is item2))
                //{

                //    if (item.Q1B == item.ANS)
                //    {
                //        var dialog = new MessageDialog("Yes!");
                //        await dialog.ShowAsync();
                //    }









                //if (listViewItem.Q1D == listViewItem.ANS && controlD.IsChecked == true)
                //{
                //    OverallScore += 1;
                //}

                //if (controlAnswer.Text == controlB.Content.ToString() && controlB.IsChecked == true)
                //{
                //    OverallScore += 1;
                //}

                //if (controlAnswer.Text == controlC.Content.ToString() && controlC.IsChecked == true)
                //{
                //    OverallScore += 1;
                //}

                //if (controlAnswer.Text == controlD.Content.ToString() && controlD.IsChecked == true)
                //{
                //    OverallScore += 1;
                //}

