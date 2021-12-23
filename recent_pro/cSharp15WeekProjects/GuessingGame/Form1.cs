using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{

    public partial class Form1 : Form
    {
        private List<Button> ListButton = new List<Button>();
        private int Points;
        public Form1()
        {
            InitializeComponent();
            ListButton.Add(button1);
            ListButton.Add(button2);


           
            RandomNumber();
        }


        private void RandomNumber()
        {
            Random ran= new Random();
            var ranValue1 = ran.Next(0,100);
            var ranValue2 = ran.Next(ranValue1);
            e2qjaadawd

            var randomBtn = ran.Next(0,ListButton.Count);

            for (int i = 0; i < 2; i++)
            {
                if(i == randomBtn)
                {
                    ListButton[randomBtn].Text = ranValue1.ToString();

                }
                else
                {
                    ListButton[i].Text = ranValue2.ToString();
                }
            }

            foreach (Control item in this.Controls)
            {
                if(item is Button)
                {
                    item.Click += Item_Click;

                    void Item_Click(object sender, EventArgs e)
                    {
                        var text = ((Button)(item)).Text;

                        if (text == ranValue1.ToString())
                        {
                            MessageBox.Show("You guess it right");
                            RandomNumber();
                            Points += 5;
                            label2.Text = String.Format("Points : {0}", Points);
                        }
                        else
                        {
                            MessageBox.Show("Bruh you 100% wrong dumpass ");
                            this.Close();

                        }
                    }
                } 
            }

        }

       
    }
}
