/*
 * Name: Luke O'Brien
 * Class: 3020:001
 * Due Date: 10/8/21 ->(moved to) 10/11/21
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBrienLA2
{
    public partial class Form1 : Form
    {
        //Stores Primary Data set
        private Cerial[] cerialData;

        //Form Input Data
        private double maxNum;
        private double minNum;
        private int nutriType;
        private bool ascending;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When form Loads, run the following
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            FileParse_CSV();
            dataGrid.DataSource = cerialData;
        }

        private void nutriDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormFilledOut())
            {
                searchButton.Enabled = true;
            }
        }
        private void minTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FormFilledOut())
            {
                searchButton.Enabled = true;
            }
        }

        private void maxTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FormFilledOut())
            {
                searchButton.Enabled = true;
            }
        }

        private void orderDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormFilledOut())
            {
                searchButton.Enabled = true;
            }
        }

        //Search button only enables after data entered
        private void searchButton_Click(object sender, EventArgs e)
        {
            Get_FormEntries();
            Find searcher = new Find(cerialData);
            dataGrid.DataSource = searcher.Search(minNum, maxNum, nutriType, ascending);
        }

        /// <summary>
        /// Reads in and parses out a CSV file; then stores data in an array : type Cerial
        /// </summary>
        private void FileParse_CSV()
        {
            string filePath_CSV = @"cereal.csv";

            //Reads in data by line; stores in fileLines
            string[] fileLines = File.ReadAllLines(filePath_CSV);
            cerialData = new Cerial[fileLines.Length];

            //For each line: seperates by comma; stores data in temp; creates new Cerial object
            for(int x=1; x<fileLines.Length; x++)
            {
                string[] temp = fileLines[x].Split(',');
                cerialData[x] = new Cerial(temp);
            }
        }

        /// <summary>
        /// Gets the pre-drtermine index number baised on Nutrient
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int NutriKey_Index(string str)
        {
            string[] nutriKey = {"calories", "protein", "fat", "sodium", "fiber",
                                    "carbohydrates", "sugars", "potassium", "vitamins"};

            for(int x=0; x<nutriKey.Length; x++)
            {
                if (str.ToLower().Equals(nutriKey[x]))
                {
                    return x;
                }
            }

            return -1;
        }

        /// <summary>
        /// Get's inputed user data on the Form and store it in variables
        /// </summary>
        private void Get_FormEntries()
        {

            nutriType = NutriKey_Index(nutriDropDown.SelectedItem.ToString());
            
            //If there is data in the field, save it to maxNum
            if(maxTextBox.Text.ToString() != "")
            {
                maxNum = double.Parse(maxTextBox.Text.ToString());
            }
            else
            {
                maxNum = -1;
            }
            
            //If there is data entered into the field, save it to minNum
            if(minTextBox.Text.ToString() != "")
            {
                minNum = double.Parse(minTextBox.Text.ToString());
            }
            else
            {
                minNum = -1;
            }

            //Sets if we are ascending or decending by true/false statement
            if (orderDropDown.SelectedItem.ToString().ToLower().Equals("highest to lowest"))
                ascending = false;
            else
                ascending = true;
        }

        /// <summary>
        /// Checks to see if Required fields are filled out on the form; True : False
        /// </summary>
        /// <returns></returns>
        private bool FormFilledOut()
        {
            string[] nutriKey = {"calories", "protein", "fat", "sodium", "fiber",
                                    "carbohydrates", "sugars", "potassium", "vitamins"};
            string[] orderKey = { "highest to lowest", "lowest  to highest" };
            bool tempNutri = false;
            bool tempOrder = false;
            for(int x=0; x<nutriKey.Length; x++)
            {
                if (nutriKey[x].Equals(nutriDropDown.Text.ToString().ToLower()))
                {
                    tempNutri = true;
                }
            }
            for(int y=0; y<orderKey.Length; y++)
            {
                if (orderKey[y].Equals(orderDropDown.Text.ToString().ToLower()))
                {
                    tempOrder = true;
                }
            }
            return tempNutri && tempOrder;
        }
    }
}
