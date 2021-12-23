using Database.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class Form1 : Form
    {
        myBtnDataAccess myBtnDataAccess = new myBtnDataAccess();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        }

        string oldValue;
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            oldValue = dataGridView1.CurrentCell.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateData();
            label1.Text = String.Format("item count : {0}", dataGridView1.Rows.Count + dataGridView1.Columns.Count);


            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int z = 0; z < dataGridView1.Rows.Count; z++)
                {
                    Console.WriteLine(dataGridView1.Rows[z].Cells[i].Value);
                    PictureBox pb = new PictureBox();

                    try
                    {
                        pb.Size = new Size(70, 70);
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Image = Image.FromFile(dataGridView1.Rows[z].Cells[i].Value.ToString());
                    }
                    catch (Exception)
                    {
                        pb.ImageLocation = "https://pbs.twimg.com/profile_images/1387288305289424901/ColMT-_p.jpg";

                    }
                }
            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        void UpdateData()
        {
            dataGridView1.DataSource = myBtnDataAccess.GetButtonsData();

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewTextBoxCell item in dataGridView1.SelectedCells)
            {
                Console.WriteLine(item.Value);
                myBtnDataAccess.DeleteButtonsData(item.Value.ToString());
            }
            UpdateData();
            label1.Text = String.Format("item count : {0}", dataGridView1.Rows.Count + dataGridView1.Columns.Count);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();

            if(fd.SelectedPath != null)
            {
                var listFiles = System.IO.Directory.GetFiles(fd.SelectedPath);

                listFiles.ToList().ForEach(file => myBtnDataAccess.AdddButtonsData(file,System.IO.Path.GetFileNameWithoutExtension(file)));
            }
            UpdateData();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //update values in database
            var newValues = dataGridView1.CurrentCell.Value.ToString();
            myBtnDataAccess.UpdateButtonsData(oldValue, newValues);

            UpdateData();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = myBtnDataAccess.SearchButtonsData(textBox1.Text);
        }
    }
}
