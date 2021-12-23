using DataBots.CLASSES;
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

namespace DataBots.ViewsControl
{
    /// <summary>
    /// Interaction logic for _ConfigurationProject.xaml
    /// </summary>
    public partial class _ConfigurationProject : Window
    {
        private DataAccess _dataAccess;
        ListView _listView;

        public _ConfigurationProject()
        {
            InitializeComponent();
        }
        
        public _ConfigurationProject(DataAccess dataAccess,ListView listView)
        {
            InitializeComponent();
            _dataAccess = dataAccess;
            _listView = listView;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog ofd = new System.Windows.Forms.FolderBrowserDialog();
            ofd.ShowDialog();

            if (ofd.SelectedPath.Length > 0)
            {
                var _selectedPath = ofd.SelectedPath;
                projectPath.Text = _selectedPath;

            }
        }

        private void creeateBtn_Click(object sender, RoutedEventArgs e)
        {
            if(projectName.Text.Length > 0 && projectPath.Text.Length > 0)
            {
                if(erorMsg.Visibility == Visibility.Visible) erorMsg.Visibility = Visibility.Hidden;

                Models.FileInfoModel _model = new Models.FileInfoModel();
                _model.Id = _dataAccess.GetListOfFileInfo().Max(x => x.Id) + 1;
                _model.FileName = projectName.Text;
                _model.TimeCreated = DateTime.Now.AddDays(10);
                _model.Path = System.IO.Path.Combine(projectPath.Text, projectName.Text);

                _dataAccess.AddData(_model);
                UpdateDateBinding();

                //Close window and start new one
                CloseWindow();

            }
            else
            {
                erorMsg.Visibility = Visibility.Visible;
            }

        }
        void UpdateDateBinding()
        {
            var val = _dataAccess.GetListOfFileInfo();
            _listView.ItemsSource = val;
            _listView.Items.Refresh();
        }
        void CloseWindow()
        {
            MainWindow.main.Close();
            Windows.ProjectWindow projectWindow = new Windows.ProjectWindow(projectPath.Text);
            projectWindow.Show();
            this.Close();
        }
    }
}
