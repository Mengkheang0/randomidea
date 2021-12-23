using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formuiidea
{
    public partial class Form1 : Form
    {
        //images url https://www.icegif.com/wp-content/uploads/icegif-2013.gif
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0)
            {
                AddPanel();
            }
            else
            {
                this.Controls.Remove(listsearch);

            }
            Console.WriteLine(this.Controls.Count.ToString());

        }
        controls.listsearch listsearch = new controls.listsearch();

        private void AddPanel()
        {
            this.Controls.Add(listsearch);
            listsearch.Top = textBox1.Bottom + 5;
            listsearch.Left = textBox1.Left;
        }
    }
}
