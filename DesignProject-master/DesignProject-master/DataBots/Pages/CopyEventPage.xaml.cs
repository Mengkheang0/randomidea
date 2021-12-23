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

namespace DataBots.Pages
{
    /// <summary>
    /// Interaction logic for CopyEventPage.xaml
    /// </summary>
    public partial class CopyEventPage : Page
    {
        Models.DataAccessEvent _dataAccess = new Models.DataAccessEvent();

        ListView _listView = new ListView();
        public CopyEventPage(Models.DataAccessEvent dataAccess ,ListView listView)
        {
            InitializeComponent();
            _dataAccess = dataAccess;
            _listView = listView;

            UpdateDataSource();
        }
        void UpdateDataSource()
        {
            listInformation.ItemsSource = data.GetFiles();
            listInformation.Items.Refresh();

        }
        void UpdatePathInfo()
        {
            fileCount.Text = String.Format("Total File : {0}", System.IO.Directory.GetFiles(eventPath.Text).Count());
            folderCount.Text = String.Format("Total Folder : {0}", System.IO.Directory.GetDirectories(eventPath.Text).Count());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fd = new System.Windows.Forms.FolderBrowserDialog();
            fd.ShowDialog();

            if (fd.SelectedPath.Length>0)
            {
                var Path = fd.SelectedPath;
                eventPath.Text = Path;
            }
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fd = new System.Windows.Forms.FolderBrowserDialog();
            fd.ShowDialog();

            if (fd.SelectedPath.Length > 0)
            {
                var Path = fd.SelectedPath;
                copyToPath.Text = Path;
            }
        }
        Data data = new Data();
        private void eventPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            CLASSES.FilesManage File = new CLASSES.FilesManage();
            var isExist =File.CheckingPath(eventPath.Text);

            if (isExist)
            {
                data.listFile.Clear();
                string[] files = System.IO.Directory.GetFiles(eventPath.Text);
                foreach (var file in files)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                    data.Add(new Pages.file() { FileName = System.IO.Path.GetFileName(file),FileSize=fileInfo.Length/1000000.0});
                }

                UpdateDataSource();
                UpdatePathInfo();
            }
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            if(datePicker.Text != "" && copyToPath.Text != "" && eventPath.Text != "")
            {
                Models.EventModel myEvent = new Models.EventModel();

                myEvent.Id = _dataAccess.GetEvents().Max(x => x.Id)+1;
                myEvent.CopyFromPath = eventPath.Text;
                myEvent.CopyToPath = copyToPath.Text;
                myEvent.EndDate = DateTime.Parse(datePicker.Text);
                myEvent.EventName = "Random";
                _dataAccess.AddEvent(myEvent);

                _listView.ItemsSource = _dataAccess.GetEvents();
                _listView.Items.Refresh();
            }
        }
    }
    public class Data
    {
        public List<file> listFile = new List<file>();

        public List<file> GetFiles()
        {
            return listFile;
        }
        public void Add(file f)
        {
            listFile.Add(f);
        }

    }
    public class file 
    {
        public string FileName { get; set; }
        public double FileSize { get; set; }
    }
}
