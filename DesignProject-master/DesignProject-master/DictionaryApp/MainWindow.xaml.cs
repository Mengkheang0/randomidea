using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DataAccess.DictionaryDataAccess dictionaryDataAccess = new DataAccess.DictionaryDataAccess();

        public MainWindow()
        {
            InitializeComponent();
            listViewItems.ItemsSource = dictionaryDataAccess.GetDictionaryData();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

       
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewItems.ItemsSource = dictionaryDataAccess.SearchDictionaryData(searchBox.Text);

        }

        private void listViewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listViewItems.SelectedItems.Count>0)
            {
                Models.DictionaryModel txt = listViewItems.SelectedItem as Models.DictionaryModel;
                UserControls.DefinitionUserControl definition = new UserControls.DefinitionUserControl(mainGrid, txt);
                mainGrid.Children.Add(definition);

                definition.SetValue(Grid.RowProperty, 2);
            }
           
        }
    }
}
