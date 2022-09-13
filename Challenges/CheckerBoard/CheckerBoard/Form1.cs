using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerBoard
{
    public partial class Form1 : Form
    {
        int buttonSize = 32*4;
        Button[,] buttons = new Button[10, 10];
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            LoadButtons();
        }

        private void LoadButtons()
        {
            for(int row=0; row < buttons.GetLength(0); row++)
            {
                for (int col = 0; col < buttons.GetLength(1); col++)
                {
                    var temp = new Button();
                    temp.Size = new Size(buttonSize, buttonSize);
                    temp.Location = new Point(col * buttonSize, row * buttonSize);
                    temp.BackColor = ((row+col)%2==0)?Color.Cyan:Color.Magenta;
                    temp.FlatStyle = FlatStyle.Flat;
                    temp.Click += SpeicalOnClickHandler;
                    this.Controls.Add(temp);
                    buttons[row, col] = temp;
                }
            }
        }

        public void OnClickHandler(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            var targetColor = clickedButton.BackColor;
            var newColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            for (int row = 0; row < buttons.GetLength(0); row++)
            {
                for (int col = 0; col < buttons.GetLength(1); col++)
                {
                    if (buttons[col, row].BackColor == targetColor)
                    {
                        buttons[col, row].BackColor = newColor;
                    }
                }
            }
        }

        public void SpeicalOnClickHandler(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            var targetColor = clickedButton.BackColor;
            var newColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            for (int row = 0; row < buttons.GetLength(0); row++)
            {
                for (int col = 0; col < buttons.GetLength(1); col++)
                {
                    if (buttons[col, row].BackColor == targetColor)
                    {
                        buttons[col, row].PerformClick();
                    }
                }
            }
        }
    }
}
