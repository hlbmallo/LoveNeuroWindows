
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using LoveNeuroWinUI3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace LoveNeuroWinUI3.Views
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
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            if (await storageFolder.FileExistsAsync("obsCollection.txt") == true)
            {
                var temp1 = await storageFolder.GetFileAsync("obsCollection.txt");
                string text = await Windows.Storage.FileIO.ReadTextAsync(temp1);
                saved = JsonConvert.DeserializeObject<ObservableCollection<QuizScore>>(text);
                dataGrid.ItemsSource = saved;
            }
            else
            {
                var obsCollection = new ObservableCollection<QuizScore>();
                var temp1 = JsonConvert.SerializeObject(obsCollection);
                var contentToSaveToFile = await storageFolder.WriteTextToFileAsync(temp1, "obsCollection.txt");
            }


            //var helper = new LocalObjectStorageHelper(new JsonSerializer());
            //if (await helper.FileExistsAsync("obsCollection.txt") == true)
            //{
            //    saved = await helper.ReadFileAsync<ObservableCollection<QuizScore>>("obsCollection.txt");
            //    dataGrid.ItemsSource = saved;
            //}
            //else
            //{
            //    var obsCollection = new ObservableCollection<QuizScore>();
            //    var contentToSaveToFile = await helper.SaveFileAsync("obsCollection.txt", obsCollection);
            //}

        }

        private async void DeleteItemFlyout_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext as QuizScore;
            saved.Remove(item);

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var temp1 = JsonConvert.SerializeObject(saved);
            var contentToSaveToFile = await storageFolder.WriteTextToFileAsync(temp1, "obsCollection.txt");

            dataGrid.ItemsSource = saved;

            //var helper = new LocalObjectStorageHelper(new SystemSerializer());
            //await helper.SaveFileAsync("obsCollection.txt", saved);
            //dataGrid.ItemsSource = saved;

        }

        private void dataGrid_Sorting(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridColumnEventArgs e)
        {
            //Use the Tag property to pass the bound column name for the sorting implementation 
            if (e.Column.Tag.ToString() == "QuizName")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    dataGrid.ItemsSource = new ObservableCollection<QuizScore>(from item in saved
                                                                        orderby item.QuizName ascending
                                                                        select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    dataGrid.ItemsSource = new ObservableCollection<QuizScore>(from item in saved
                                                                        orderby item.QuizName descending
                                                                        select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }
            // add code to handle sorting by other columns as required

            // Remove sorting indicators from other columns
            foreach (var dgColumn in dataGrid.Columns)
            {
                if (dgColumn.Tag.ToString() != e.Column.Tag.ToString())
                {
                    dgColumn.SortDirection = null;
                }
            }

            //Use the Tag property to pass the bound column name for the sorting implementation 
            if (e.Column.Tag.ToString() == "MyScore")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    dataGrid.ItemsSource = new ObservableCollection<QuizScore>(from item in saved
                                                                               orderby item.MyScore ascending
                                                                               select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    dataGrid.ItemsSource = new ObservableCollection<QuizScore>(from item in saved
                                                                               orderby item.MyScore descending
                                                                               select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }
            // add code to handle sorting by other columns as required

            // Remove sorting indicators from other columns
            foreach (var dgColumn in dataGrid.Columns)
            {
                if (dgColumn.Tag.ToString() != e.Column.Tag.ToString())
                {
                    dgColumn.SortDirection = null;
                }
            }

            //Use the Tag property to pass the bound column name for the sorting implementation 
            if (e.Column.Tag.ToString() == "MyPercentage")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    dataGrid.ItemsSource = new ObservableCollection<QuizScore>(from item in saved
                                                                               orderby item.MyScore ascending
                                                                               select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    dataGrid.ItemsSource = new ObservableCollection<QuizScore>(from item in saved
                                                                               orderby item.MyScore descending
                                                                               select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }
            // add code to handle sorting by other columns as required

            // Remove sorting indicators from other columns
            foreach (var dgColumn in dataGrid.Columns)
            {
                if (dgColumn.Tag.ToString() != e.Column.Tag.ToString())
                {
                    dgColumn.SortDirection = null;
                }
            }

            //Use the Tag property to pass the bound column name for the sorting implementation 
            if (e.Column.Tag.ToString() == "MyDateForThatScore")
            {
                //Implement sort on the column "Range" using LINQ
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    dataGrid.ItemsSource = new ObservableCollection<QuizScore>(from item in saved
                                                                               orderby item.MyDateForThatScore ascending
                                                                               select item);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    dataGrid.ItemsSource = new ObservableCollection<QuizScore>(from item in saved
                                                                               orderby item.MyDateForThatScore descending
                                                                               select item);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }
            // add code to handle sorting by other columns as required

            // Remove sorting indicators from other columns
            foreach (var dgColumn in dataGrid.Columns)
            {
                if (dgColumn.Tag.ToString() != e.Column.Tag.ToString())
                {
                    dgColumn.SortDirection = null;
                }
            }
        }
    }
    }
