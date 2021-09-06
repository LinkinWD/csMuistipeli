using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muistipeli
{
    public partial class Muistipeli : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "b", "b",
            "v", "v", "w", "w", "z", "z"
        };
        Label firstClicked, secondClicked;
        public Muistipeli()
        {
            InitializeComponent();
            assingIcons();
        }

        private void label_click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;
            if (clickedLabel.ForeColor == Color.Black)
                return;
            if(firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            checkVinner();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;


        }
        private void checkVinner()
        {
            Label label;
            for( int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("Kaikki ikonit käännetty");
            Close();
        }
        private void assingIcons()
        {
            Label label;
            int randomNumber;

            for(int i = 0; i<tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);

            }
        }
    }
}
