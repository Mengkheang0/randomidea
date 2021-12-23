using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            update();
        }
        void update()
        {
            listBox1.DataSource = myDataAccess.GetPeople();
            listBox1.DisplayMember = "Path";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();

            if(fd.SelectedPath != null)
            {
                var listFiles = System.IO.Directory.GetFiles(fd.SelectedPath);

                foreach(var file in listFiles)
                {
                    myDataAccess.AddPeople(new PersonModel() { Name = System.IO.Path.GetFileName(file),Path =file });
                }
                update();
            }
        }
    }
}


/* using(MySqlConnection con = new MySqlConnection("server=sql6.freesqldatabase.com;user=sql6449059,database=sql6449059; port=3306;password=gksVCnnWTG"))
           {
               MySqlCommand cmd = new MySqlCommand("select * from dbo.Person", con);

               con.Open();
               *//*MySqlDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {
                   Console.WriteLine("hi");
               }*//*
           }*/