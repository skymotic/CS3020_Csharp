/*
 *  Author: Luke O'Brien 
 *  Class:  CS3020:001
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellsExsample
{
    public partial class Cell : UserControl
    {
        Panel myPanel;
        Button myButton;
        Label myLabel;
        bool isBomb;
        private int size = 25*3;
        public event EventHandler ButtonIsBomb;
        public event EventHandler CellClicked;

        int x;
        int y;
        int bombsNear;

        public Cell()
        {
            InitializeComponent();
            CreateButton();
            CreateLabel();
            CreatePannel();
            this.Size = new Size(size, size);
            bombsNear = 0;
        }

        //X and Y of where the cell is stored
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        //How many bombs are near the cell
        public int BombsNear { get => bombsNear; set => bombsNear = value; }

        //Stores if the cell is a bomb or not
        public bool IsBomb { get => isBomb; set => isBomb = value; }

        //--------

        public Button CellButton { get => myButton; }

        public Color MyColor { get => myLabel.BackColor; set => myLabel.BackColor = value; }

        //--------

        private void CreateButton()
        {
            myButton = new Button();
            myButton.Size = new Size(size, size);
            myButton.Location = this.Location;
            this.Controls.Add(myButton);
            CellButton.Click += OnCellClick;
        }

        private void CreatePannel()
        {
            myPanel = new Panel();
            myPanel.Size = new Size(size, size);
            myPanel.Location = this.Location;
            myPanel.BackColor = Color.Cyan;
            this.Controls.Add(myPanel);
        }

        private void CreateLabel()
        {
            myLabel = new Label();
            myLabel.Size = new Size(size, size);
            myLabel.Location = this.Location;
            myLabel.ForeColor = Color.Black;
            myLabel.Font = new Font("Arial", 25, FontStyle.Regular);
            myLabel.AutoSize = false;
            myLabel.TextAlign = ContentAlignment.MiddleCenter;
            myLabel.Dock = DockStyle.Fill;
            this.Controls.Add(myLabel);
        }

        /// <summary>
        /// Event; Trigers when cell is clicked on
        /// Checks if is bomb
        /// Sets cell visablility to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCellClick(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            temp.Visible = false;

            if(isBomb && ButtonIsBomb != null)
            {
                ButtonIsBomb(this, new EventArgs());
            }
            if(CellClicked != null)
            {
                CellClicked(this, new EventArgs());
            }
        }

        /// <summary>
        /// Sets the Text shown once button is clicked
        /// </summary>
        /// <param name="labelText"></param>
        public void SetLabel(string labelText)
        {
            myLabel.Text = labelText;
        }
    }
}
