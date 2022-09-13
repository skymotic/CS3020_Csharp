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
using System.IO;

namespace CellsExsample
{
    public partial class Form1 : Form
    {
        Cell[,] cells = new Cell[10,10]; //(0),(1)
        Random rand = new Random();
        List<Cell> bombLocations = new List<Cell>();

        int bombs = 10;
        bool firstClick = true;

        //The number of clicks that need to happen to win
        int winNum;

        //statistics temp varibles
        int _Timer;
        bool _GamesWon;
        string fileName = @"stats.gamedat";

        public Form1()
        {
            InitializeComponent();
            CreateGrid();

            //calculates the number of clicks needed to win
            winNum = (cells.GetLength(0) * cells.GetLength(1)) - (bombs+7);


            _Timer = 0;
        }

        /// <summary>
        /// Creates a grid of Cells and set their location
        /// Additionally subscribes each cell to the eventhandlers
        /// </summary>
        private void CreateGrid()
        {
            for (int row = 0; row < cells.GetLength(0); row++)
            {
                for (int col = 0; col < cells.GetLength(1); col++)
                {
                    Cell temp = new Cell();
                    temp.X = col;
                    temp.Y = row;
                    temp.Location = new Point(col * temp.Size.Height, row * temp.Size.Width);
                    this.Controls.Add(temp);
                    temp.ButtonIsBomb += OnBombClick;
                    temp.CellClicked += OnCellClick;
                    cells[row, col] = temp;
                }
            }
        }

        /// <summary>
        /// Event; Trigers when user clicks on bomb
        /// Clears Board, Genreates stats report and restarts game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBombClick(object sender, EventArgs e)
        {
            foreach(Cell cc in cells)
            {
                cc.CellButton.Visible = false;
            }
            MessageBox.Show("You FAILED!");
            GenerateStatsReport();
            Application.Restart();
        }

        /// <summary>
        /// Event; Tigers every time a cell is clicked
        /// Checks if first click, if so: (would) triger pathfinding
        /// Also Checks if user has won.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCellClick(object sender, EventArgs e)
        {
            winNum = winNum - 1;
            if(winNum == 1)
            {
                MessageBox.Show("You Won!!!");
                _GamesWon = true;
                GenerateStatsReport();
                Application.Restart();
            }
            if (firstClick)
            {
                timer1.Enabled = true;
                Cell temp = ((Cell)sender);

                //places bombs basied on first click
                firstClick = false;
                PlaceBombs(temp.Y, temp.X);
                SetNumbers();

                
                cells[temp.Y, temp.X].MyColor = Color.Cyan;

                //Removes cells around where user would click (In place of pathfinder)
                cells[temp.Y-1, temp.X].CellButton.Visible = false;
                cells[temp.Y+1, temp.X].CellButton.Visible = false;
                cells[temp.Y, temp.X-1].CellButton.Visible = false;
                cells[temp.Y, temp.X+1].CellButton.Visible = false;
                cells[temp.Y-1, temp.X-1].CellButton.Visible = false;
                cells[temp.Y+1, temp.X+1].CellButton.Visible = false;
                cells[temp.Y-1, temp.X+1].CellButton.Visible = false;
                cells[temp.Y+1, temp.X-1].CellButton.Visible = false;
            }
        }

        /// <summary>
        /// Places bombs around where use has clicks, avoiding a 3x3 area
        /// from where user has clicked.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void PlaceBombs(int y, int x)
        {
            while(bombs > 0)
            {
                //Random Number generator for bomb placement
                int tempX = rand.Next(cells.GetLength(1));
                int tempY = rand.Next(cells.GetLength(0));

                if(!cells[tempY, tempX].IsBomb && (tempX != x && tempY != y) && (tempY != (y+1) && tempY != (y-1)) && (tempX != (x+1) && tempX != (x-1)) )
                {
                    cells[tempY, tempX].IsBomb = true;
                    cells[tempY, tempX].SetLabel("*");
                    bombLocations.Add(cells[tempY, tempX]);
                    bombs = bombs - 1;
                }
            }
        }

        /// <summary>
        /// Runs through Bomb locations, adding a '1' to each cell around
        /// the bomb. Then runs through all the cells to set the label to
        /// the bomb location number
        /// </summary>
        private void SetNumbers()
        {
            foreach(Cell cc in bombLocations)
            {
                SetBombCount(cc.Y, cc.X);
            }

            for (int row = 0; row < cells.GetLength(0); row++)
            {
                for (int col = 0; col < cells.GetLength(1); col++)
                {
                    if(cells[row,col].BombsNear > 0 && !cells[row, col].IsBomb)
                    {
                        cells[row, col].SetLabel((cells[row, col].BombsNear).ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Helper class for 'SetNumbers'
        /// Moves around bomb, adding 1 number to the cells
        /// </summary>
        /// <param name="cellY"></param>
        /// <param name="cellX"></param>
        private void SetBombCount(int cellY, int cellX)
        {
            //put the algorithum to count the bombs around a single space in here
            //Accounts for checks that go off the edges using try catch blocks

            //Up
            try { cells[cellY - 1, cellX].BombsNear++; } catch (IndexOutOfRangeException e) {  }

            //Upper-Right
            try { cells[cellY - 1, cellX + 1].BombsNear++; } catch (IndexOutOfRangeException e) {  }

            //Right
            try { cells[cellY, cellX + 1].BombsNear++;  } catch (IndexOutOfRangeException e) {  }

            //Lower-Right
            try { cells[cellY + 1, cellX + 1].BombsNear++; } catch (IndexOutOfRangeException e) {  }

            //Bellow
            try { cells[cellY + 1, cellX].BombsNear++; } catch (IndexOutOfRangeException e) {  }

            //Lower-Left
            try { cells[cellY + 1, cellX - 1].BombsNear++;  } catch (IndexOutOfRangeException e) {  }

            //Left
            try { cells[cellY, cellX - 1].BombsNear++; } catch (IndexOutOfRangeException e) {  }

            //Upper-Left
            try { cells[cellY - 1, cellX - 1].BombsNear++; } catch (IndexOutOfRangeException e) {  }
        }

        /// <summary>
        /// Generates a File that has the Statistics of all
        /// gameplays
        /// </summary>
        private void GenerateStatsReport()
        {
            if (!File.Exists(fileName))
            {
                using(StreamWriter writer = File.CreateText(fileName))
                {
                    writer.WriteLine($"{_Timer},{_GamesWon}");
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{_Timer},{_GamesWon}");
                }
            }
        }

        /// <summary>
        /// Event; Triggers with each second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            _Timer++;
            StatusStrip.Text = $"Timer: {_Timer}";
        }

        /// <summary>
        /// Event; Trigers when 'Stats' is clicked in Menu "Game > stats"
        /// Reads .gamedat file and parses out the data, calculating
        /// lifetime game averages and ratios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileName))
            {
                using(StreamReader reader = new StreamReader(fileName))
                {
                    //Temp Vars
                    int _AverageTime = 0;
                    int _GamesPlayed = 0;
                    int _WonRat = 0;
                    string[] temp;

                    //Reads in Stats
                    while (!reader.EndOfStream)
                    {
                        temp = reader.ReadLine().Split(',');
                        _AverageTime = int.Parse(temp[0]);
                        _GamesPlayed++;
                        if (bool.Parse(temp[1]))
                        {
                            _WonRat++;
                        }
                    }

                    //Displays Stats
                    MessageBox.Show($"All Time Stats:\n" +
                        $"--------------------------\n" +
                        $"Average Time: {_AverageTime / _GamesPlayed}\n" +
                        $"Win/Loss Ratio: {_WonRat}/{_GamesPlayed}");
                }
            }
        }

        /// <summary>
        /// Event; Tigers when 'restart' is clicked in the menu "Game > Restart"
        /// Restarts the Program without tracking statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To restart the game, Press \"Okay\"\nThis game will not be counted");
            Application.Restart();
        }

        /// <summary>
        /// Event; Trigers when 'Exit' is click in menu "Game > Exit"
        /// Exits Appliction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Event; Tigers when 'Instructions' is clicked in menu "Info > Instructions"
        /// Displays game instructions to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Instructions\n" +
                $"----------------------------------------\n\n" +
                $"To play MineSweeper, Start the game and click on any square.\n" +
                $"This will start the game. Any numbers you see indicate that there is\n" +
                $"a bomb within 1 cell of said number. (This includes diagnoaly)\n" +
                $"If the number is \'2\' That means there are 2 bombs within 1 square of\n" +
                $"the number. Be it up, left, right, down or diagonaly.\n\n" +
                $"Your goal is to click on all the squairs that dont have bombs in them");

        }

        /// <summary>
        /// Event; Tigers when 'about' is clicked in menu "Info > About"
        /// Displays information about the programers and Game Creator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"About\n" +
                $"----------------------------------------\n\n" +
                $"Name of programer: Luke O'Brien\n" +
                $"For Class: CS3020:001\n" +
                $"MineSweeper Creater: Curt Jognson");
        }
    }
}
