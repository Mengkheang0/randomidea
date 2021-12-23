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
using System.Windows.Shapes;

namespace DataBots.Windows
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        Models.DataAccessEvent events = new Models.DataAccessEvent();
        CLASSES.FilesManage files = new CLASSES.FilesManage();
        public ProjectWindow(string path)
        {
            InitializeComponent();
            projectPath.Text = string.Format("Path : {0}",path);
            projectName.Text = System.IO.Path.GetFileName(path)+".sln";
            botActivity.ItemsSource = events.GetEvents();

            files.CopyFile(DateTime.Now, DateTime.Now.AddMinutes(1));

        }
        public ProjectWindow()
        {
            InitializeComponent();
            botActivity.ItemsSource = events.GetEvents();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        Pages.DeleteEventPage deletePage = new Pages.DeleteEventPage();
        Pages.CopyEventPage copyPage;
        private void eventOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            copyPage = new Pages.CopyEventPage(events, botActivity);
            if(eventOptions.SelectedIndex == 0)
            {
                eventFrame.Content = copyPage;
            }
            else
            {
                eventFrame.Content = deletePage;
            }

        }
    }
}
