using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DataBots
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declaring classes
        CLASSES.DataAccess dataAccess  = new CLASSES.DataAccess();
        CLASSES.FilesManage filesManage = new CLASSES.FilesManage();

        public static MainWindow main;
        public MainWindow()
        {
            InitializeComponent();
            Binding();
            main = this;

            //filesManage.CreateProject(@"D:\BG\myProject", "BotEvent.cvs");
        }
        private void Binding()
        {
            var listData = dataAccess.GetListOfFileInfo();
            solutionItemsControl.ItemsSource = listData;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void openFolder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.ShowDialog();

            if (ofd.SelectedPath.Length > 0)
            {
                var _selectedPath =ofd.SelectedPath;


            }
        }

        private void createNewProject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewsControl._ConfigurationProject _ConfigurationProject = new ViewsControl._ConfigurationProject(dataAccess,solutionItemsControl);
            _ConfigurationProject.ShowDialog();
        }
        private void searchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
           var path = dataAccess.SearchFileName(searchTb.Text);
            path.ForEach(item =>System.Diagnostics.Debug.WriteLine(item.FileName));

            solutionItemsControl.ItemsSource = path;
            solutionItemsControl.Items.Refresh();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(solutionItemsControl.ItemsSource != null)
            {
                var items = solutionItemsControl.SelectedItems;

                foreach (Models.FileInfoModel item in items)
                {
                    dataAccess.DeleteData(item.Id);
                }
                Binding();

            }
        }
    }
}
